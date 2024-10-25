using System;
using System.IO;
using System.Text;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppInterop.Runtime;
using Il2CppKernys.Bson;
using Il2CppSystem;
using MelonLoader;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace AMod
{
	// Token: 0x02000050 RID: 80
	public class AMod : MelonMod
	{
		// Token: 0x0600024F RID: 591 RVA: 0x0000A3B1 File Offset: 0x000085B1
		public override void OnInitializeMelon()
		{
			MelonLogger.Msg(" \r\n   ___    __  _______  ____ \r\n   /   |  /  |/  / __ \\/ __ \\\r\n  / /| | / /|_/ / / / / / / /\r\n / ___ |/ /  / / /_/ / /_/ / \r\n/_/  |_/_/  /_/\\____/____/  \r\n                             ");
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000A3C0 File Offset: 0x000085C0
		public override void OnLateInitializeMelon()
		{
			bool flag = !Directory.Exists(Directory.GetCurrentDirectory() + "\\AMod Official");
			bool flag2 = flag;
			if (flag2)
			{
				try
				{
					MelonLogger.Msg("AMod File not found! Creating..");
					Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AMod Official");
				}
				catch
				{
					Application.Quit();
				}
			}
			bool flag3 = !Directory.Exists(Directory.GetCurrentDirectory() + "\\AMod Official\\Accounts");
			bool flag4 = flag3;
			if (flag4)
			{
				try
				{
					MelonLogger.Msg("Saved Accounts Folder not found! Creating..");
					Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AMod Official\\Accounts");
				}
				catch
				{
					Application.Quit();
				}
			}
			bool flag5 = !Directory.Exists(Directory.GetCurrentDirectory() + "\\AMod Official\\Packets");
			bool flag6 = flag5;
			if (flag6)
			{
				try
				{
					MelonLogger.Msg("Packets folder not found! Creating..");
					Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\AMod Official\\Packets");
				}
				catch
				{
					Application.Quit();
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000A4E4 File Offset: 0x000086E4
		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			bool custompack = Globals.Custompack;
			if (custompack)
			{
				bool flag = !(sceneName == "MainMenu");
				if (flag)
				{
					bool flag2 = sceneName == "WelcomeScene";
					if (flag2)
					{
						try
						{
							UnityEngine.Object.FindObjectOfType<WelcomeSceneLogic>().canvas.transform.FindChild("Background").GetComponent<Image>().color = new Color(0.4f, 0.2235f, 0.9804f, 1f);
						}
						catch
						{
						}
					}
				}
				else
				{
					try
					{
						Image component = UnityEngine.Object.FindObjectOfType<MainMenuBackgroundClouds>().transform.FindChild("Clouds1").GetComponent<Image>();
						UnityEngine.Object.Destroy(component);
						Image component2 = UnityEngine.Object.FindObjectOfType<MainMenuBackgroundClouds>().transform.FindChild("Clouds2").GetComponent<Image>();
						UnityEngine.Object.Destroy(component2);
						Image component3 = UnityEngine.Object.FindObjectOfType<MainMenuBackgroundClouds>().transform.FindChild("Clouds3").GetComponent<Image>();
						UnityEngine.Object.Destroy(component3);
						Image component4 = UnityEngine.Object.FindObjectOfType<MainMenuBackgroundClouds>().transform.FindChild("Clouds4").GetComponent<Image>();
						UnityEngine.Object.Destroy(component4);
						MainMenuLogic.GetInstance().canvas.transform.FindChild("MainMenuBG").GetComponent<Image>().color = new Color(0.4f, 0.2235f, 0.9804f, 1f);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000A660 File Offset: 0x00008860
		public static void SendCustomPacket()
		{
			bool flag = string.IsNullOrEmpty(Globals.CustomPacket);
			if (flag)
			{
				MelonLogger.BigError("Packets", "Your current packet is empty.");
			}
			else
			{
				try
				{
					BsonDocument obj = BsonSerializer.Deserialize<BsonDocument>(Globals.CustomPacket, null);
					byte[] array = obj.ToBson(null, null, null, default(BsonSerializationArgs), 0);
					BSONObject bsonobject = SimpleBSON.Load(obj.ToBson(null, null, null, default(BsonSerializationArgs), 0));
					BSONObject bsonobject2 = BsonHelper.FormatBson(bsonobject);
					bool flag2 = bsonobject2 != null;
					if (flag2)
					{
						bsonobject = bsonobject2;
					}
					OutgoingMessages.AddOneMessageToList(bsonobject);
					System.Console.WriteLine("CUSTOM SEND: \r\n" + Utils.DumpBSON(bsonobject) + "\r\n");
				}
				catch (System.Exception ex)
				{
					MelonLogger.Error("Could not load or format BSON from Custom Packet Exception: " + ex.Message);
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000A744 File Offset: 0x00008944
		public static void SendCustomPacket2()
		{
			bool flag = string.IsNullOrEmpty(Globals.CustomPacket);
			if (!flag)
			{
				try
				{
					BsonDocument obj = BsonSerializer.Deserialize<BsonDocument>(Globals.CustomPacket, null);
					byte[] array = obj.ToBson(null, null, null, default(BsonSerializationArgs), 0);
					BSONObject bsonobject = SimpleBSON.Load(obj.ToBson(null, null, null, default(BsonSerializationArgs), 0));
					BSONObject bsonobject2 = BsonHelper.FormatBson(bsonobject);
					bool flag2 = bsonobject2 != null;
					if (flag2)
					{
						bsonobject = bsonobject2;
					}
					OutgoingMessages.AddOneMessageToList(bsonobject);
				}
				catch (System.Exception ex)
				{
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000A7E0 File Offset: 0x000089E0
		public override void OnUpdate()
		{
			bool autoGear = Globals.AutoGear;
			if (autoGear)
			{
			}
			bool autoBP = Globals.AutoBP;
			if (autoBP)
			{
			}
			this.vendTime += Time.deltaTime;
			bool flag = Globals.AutoVendor && this.vendTime >= 0.05f;
			if (flag)
			{
				PlayerData.InventoryKey inventoryKey = PlayerData.InventoryKey.IntToInventoryKey(Globals.VendIK);
				BSONObject bsonobject = new BSONObject();
				bsonobject["ID"] = "PVi";
				bsonobject["x"] = Globals.Player.currentPlayerMapPoint.x;
				bsonobject["y"] = Globals.Player.currentPlayerMapPoint.y;
				bsonobject["vC"] = Globals.VendCID;
				bsonobject["vI"] = Globals.VendID;
				bsonobject["IK"] = Globals.VendIK;
				OutgoingMessages.AddOneMessageToList(bsonobject);
				Globals.EndAmtVend = (int)Globals.EndAmtVend2;
				bool flag2 = Globals.VendIK != 0;
				if (flag2)
				{
					Globals.PlayerData.AddItemToInventory(inventoryKey, null);
				}
				bool flag3 = (int)Globals.PlayerData.GetCount(inventoryKey) == Globals.EndAmtVend;
				if (flag3)
				{
					Globals.AutoVendor = false;
					Globals.vendIKAMT = 0;
					Globals.VendIK = 0;
					Globals.VendID = 0;
					Globals.VendCID = 0;
					BSONObject bsonobject2 = new BSONObject();
					bsonobject2["ID"] = "AGI";
					bsonobject2["PT"] = 0;
					OutgoingMessages.AddOneMessageToList(bsonobject2);
					InfoPopupUI.SetupInfoPopup("AutoVendor stopped!", "You have reached your selected amount.");
					InfoPopupUI.ForceShowMenu();
				}
			}
			bool autoOPENER = Globals.autoOPENER;
			if (autoOPENER)
			{
				PlayerData.InventoryKey inventoryKey2 = PlayerData.InventoryKey.IntToInventoryKey(Globals.AOINVK);
				OutgoingMessages.SendOpenPresentMessage(inventoryKey2);
				bool flag4 = Globals.PlayerData.GetCount(inventoryKey2) == 25;
				if (flag4)
				{
					Globals.autoOPENER = false;
					Globals.AOINVK = 0;
				}
			}
			bool byteGemmer = Globals.ByteGemmer;
			if (byteGemmer)
			{
				for (int i = 0; i < 2; i++)
				{
					OutgoingMessages.BuyItemPack("ByteCoin04");
					OutgoingMessages.BuyItemPack("ByteCoin04");
					Globals.PlayerData.AddByteCoins(12000);
				}
			}
			this.Gemmer22 += Time.deltaTime;
			bool flag5 = Globals.ByteGemmer && this.Gemmer22 >= 0.08f;
			if (flag5)
			{
				this.Gemmer22 = 0f;
				PlayerData.InventoryKey fishIK = default(PlayerData.InventoryKey);
				fishIK.blockType = (World.BlockType)117445102;
				foreach (CollectableData collectableData in Globals.world.collectables)
				{
					bool flag6 = collectableData.mapPoint == Globals.CurrentMapPoint;
					if (flag6)
					{
						OutgoingMessages.SendCollectCollectableMessage(collectableData.id);
					}
				}
				OutgoingMessages.RecycleFish(fishIK, 999);
				Globals.PlayerData.AddGems(9590400);
			}
			bool clearCh = Globals.clearCh;
			if (clearCh)
			{
				ChatUI x = UnityEngine.Object.FindObjectOfType<ChatUI>();
				bool flag7 = x != null;
				if (flag7)
				{
					UnityEngine.Object.FindObjectOfType<ChatUI>().chatMainWindow.Clear();
				}
			}
			this.AutoBuyTimer += Time.deltaTime;
			bool flag8 = Globals.AutoBuy1 && Globals.IPID1 != null && this.AutoBuyTimer >= Globals.AutoBuyCT;
			if (flag8)
			{
				ItemPacks.ItemPack itemPack = ItemPacks.GetItemPack(Globals.IPID1);
				this.AutoBuyTimer = 0f;
				OutgoingMessages.BuyItemPack(Globals.IPID1);
				for (int j = 0; j < itemPack.sureDrops.Length; j++)
				{
					Globals.PlayerData.AddItemToInventory(itemPack.sureDrops[j], itemPack.sureDropAmounts[j], null);
					bool flag9 = Globals.PlayerData.GetCount(itemPack.sureDrops[j]) > 998;
					if (flag9)
					{
						Globals.AutoBuy1 = false;
						Globals.IPID1 = "";
					}
				}
			}
			bool flag10 = !Globals.AutoBuy1;
			if (flag10)
			{
				Globals.IPID1 = "";
			}
			this.PTimerP += Time.deltaTime;
			bool flag11 = Globals.PSpamP && this.PTimerP >= Globals.PTimerP2;
			if (flag11)
			{
				this.PTimerP = 0f;
				bool flag12 = !Globals.ViewOcaptureOrICapture;
				if (flag12)
				{
					Globals.CustomPacket = Globals.CurrentCaptureOUTGOING;
				}
				bool viewOcaptureOrICapture = Globals.ViewOcaptureOrICapture;
				if (viewOcaptureOrICapture)
				{
					Globals.CustomPacket = Globals.CurrentCaptureINCOMING;
				}
				AMod.SendCustomPacket2();
			}
			bool flag13 = Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.InMenus;
			if (flag13)
			{
				Globals.InvisibleHack = false;
				Globals.autoGM = false;
				Globals.StartGM = false;
				Globals.Base64Msg = "";
				Globals.PSpamP = false;
				Globals.BytesBuyer = false;
				Globals.BytesBuyer2 = false;
				Globals.GemmerOG = false;
				Globals.GemGemGem = false;
				Globals.PLCv = false;
				Globals.PLCv2 = false;
				Globals.clearCh = false;
				Globals.AutoVendor = false;
			}
			bool flag14 = Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.Authentication;
			if (flag14)
			{
				Globals.InvisibleHack = false;
				Globals.autoGM = false;
				Globals.StartGM = false;
				Globals.Base64Msg = "";
				Globals.PSpamP = false;
				Globals.BytesBuyer = false;
				Globals.BytesBuyer2 = false;
				Globals.GemmerOG = false;
				Globals.GemGemGem = false;
				Globals.PLCv = false;
				Globals.PLCv2 = false;
				Globals.clearCh = false;
				Globals.AutoVendor = false;
			}
			bool flag15 = Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.CheckingGameVersion;
			if (flag15)
			{
				Globals.InvisibleHack = false;
				Globals.autoGM = false;
				Globals.StartGM = false;
				Globals.Base64Msg = "";
				Globals.PSpamP = false;
				Globals.BytesBuyer = false;
				Globals.BytesBuyer2 = false;
				Globals.GemmerOG = false;
				Globals.GemGemGem = false;
				Globals.PLCv = false;
				Globals.PLCv2 = false;
				Globals.clearCh = false;
				Globals.AutoVendor = false;
			}
			bool flag16 = Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.ConnectionFailed;
			if (flag16)
			{
				Globals.InvisibleHack = false;
				Globals.autoGM = false;
				Globals.StartGM = false;
				Globals.Base64Msg = "";
				Globals.PSpamP = false;
				Globals.BytesBuyer = false;
				Globals.BytesBuyer2 = false;
				Globals.GemmerOG = false;
				Globals.GemGemGem = false;
				Globals.PLCv = false;
				Globals.PLCv2 = false;
				Globals.clearCh = false;
				Globals.AutoVendor = false;
			}
			int num = Globals.cardAmt;
			this.Encime += Time.deltaTime;
			bool flag17 = Globals.Disencht && this.Encime >= 2f;
			if (flag17)
			{
				num--;
				BSONObject bsonobject3 = new BSONObject();
				bsonobject3["ID"] = "DCard";
				bsonobject3["ccD"] = Globals.cardID;
				bsonobject3["Amt"] = 1;
				OutgoingMessages.AddOneMessageToList(bsonobject3);
				bool flag18 = num == 2;
				if (flag18)
				{
					Globals.Disencht = false;
					Globals.cardID = 0;
					Globals.cardAmt = 0;
				}
			}
			this.VIPTIME += Time.deltaTime;
			bool flag19 = Globals.autoVIP && Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.InRoom;
			if (flag19)
			{
				PlayerData.InventoryKey inventoryKey3 = default(PlayerData.InventoryKey);
				inventoryKey3.blockType = World.BlockType.ConsumableMiningToken;
				inventoryKey3.itemType = PlayerData.InventoryItemType.Consumable;
				foreach (CollectableData collectableData2 in Globals.world.collectables)
				{
					bool flag20 = collectableData2.mapPoint == Globals.CurrentMapPoint;
					if (flag20)
					{
						OutgoingMessages.SendCollectCollectableMessage(collectableData2.id);
					}
				}
				for (int k = 0; k < 5; k++)
				{
					OutgoingMessages.SendSpinMiningRouletteMessage();
				}
			}
			this.VIPTIME += Time.deltaTime;
			bool flag21 = Globals.autoVIP2 && Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.InRoom;
			if (flag21)
			{
				PlayerData.InventoryKey inventoryKey4 = default(PlayerData.InventoryKey);
				inventoryKey4.blockType = World.BlockType.JetRaceCrestGold;
				inventoryKey4.itemType = PlayerData.InventoryItemType.Consumable;
				foreach (CollectableData collectableData3 in Globals.world.collectables)
				{
					bool flag22 = collectableData3.mapPoint == Globals.CurrentMapPoint;
					if (flag22)
					{
						OutgoingMessages.SendCollectCollectableMessage(collectableData3.id);
					}
				}
				for (int l = 0; l < 5; l++)
				{
					foreach (CollectableData collectableData4 in Globals.world.collectables)
					{
						bool flag23 = collectableData4.mapPoint == Globals.CurrentMapPoint;
						if (flag23)
						{
							OutgoingMessages.SendCollectCollectableMessage(collectableData4.id);
						}
					}
					OutgoingMessages.SendSpinJetRaceRouletteMessage();
				}
			}
			bool flag24 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Alpha9);
			if (flag24)
			{
				try
				{
					WorldItemBase worldItemData = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					bool flag25 = worldItemData != null;
					bool flag26 = flag25;
					if (flag26)
					{
						BSONObject asBSON = worldItemData.GetAsBSON();
						BSONObject bsonobject4 = new BSONObject();
						bsonobject4["ID"] = "WIU";
						bsonobject4["WiB"] = asBSON;
						bsonobject4["x"] = Globals.Player.currentPlayerMapPoint.x;
						bsonobject4["y"] = Globals.Player.currentPlayerMapPoint.y;
						asBSON["text"] = "<br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br <br HELLOOOOOOOOOOOOOO THIS IS A TEST 123123123123123123123123123132123123123123123123123123123123";
						bsonobject4["PT"] = 1;
						Globals.world.WorldItemUpdate(bsonobject4);
						OutgoingMessages.SendWorldItemUpdateMessage(Globals.Player.currentPlayerMapPoint, worldItemData, ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint)));
					}
					OutgoingMessages.SendWorldItemUpdateMessage(Globals.Player.currentPlayerMapPoint, worldItemData, ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint)));
				}
				catch
				{
				}
			}
			this.iTTT += Time.deltaTime;
			bool flag27 = Globals.IRef && this.iTTT >= 0.5f;
			if (flag27)
			{
				this.iTTT = 0f;
				BSONObject bsonobject5 = new BSONObject();
				bsonobject5["ID"] = "AGI";
				bsonobject5["PT"] = 0;
				OutgoingMessages.AddOneMessageToList(bsonobject5);
			}
			bool bytesBuyer = Globals.BytesBuyer;
			if (bytesBuyer)
			{
				int num2 = 0;
				while ((float)num2 < Globals.Speed)
				{
					OutgoingMessages.BuyItemPack("ByteCoin04");
					OutgoingMessages.BuyItemPack("ByteCoin03");
					OutgoingMessages.BuyItemPack("ByteCoin02");
					OutgoingMessages.BuyItemPack("ByteCoin01");
					Globals.PlayerData.AddByteCoins(7800);
					num2++;
				}
				bool flag28 = Globals.PlayerData.bc > 1900000000;
				if (flag28)
				{
					Globals.BytesBuyer = false;
				}
			}
			bool bytesBuyer2 = Globals.BytesBuyer2;
			if (bytesBuyer2)
			{
				int num3 = 0;
				while ((float)num3 < Globals.Speed)
				{
					OutgoingMessages.BuyItemPack("ByteCoin04");
					OutgoingMessages.BuyItemPack("ByteCoin04");
					Globals.PlayerData.AddByteCoins(12000);
					num3++;
				}
				bool flag29 = Globals.PlayerData.bc > 1900000000;
				if (flag29)
				{
					Globals.BytesBuyer2 = false;
				}
			}
			this.Gemmer22 += Time.deltaTime;
			bool gemGemGem = Globals.GemGemGem;
			if (gemGemGem)
			{
				Globals.GemmerOG = false;
				PlayerData.InventoryKey fishIK2 = default(PlayerData.InventoryKey);
				fishIK2.blockType = (World.BlockType)117445102;
				foreach (CollectableData collectableData5 in Globals.world.collectables)
				{
					bool flag30 = collectableData5.mapPoint == Globals.CurrentMapPoint;
					if (flag30)
					{
						OutgoingMessages.SendCollectCollectableMessage(collectableData5.id);
					}
				}
				for (int m = 0; m < 1; m++)
				{
					OutgoingMessages.RecycleFish(fishIK2, 999);
					Globals.PlayerData.AddGems(9590400);
				}
			}
			this.Gemmer22 += Time.deltaTime;
			bool flag31 = Globals.GemmerOG && this.Gemmer22 >= 0.08f;
			if (flag31)
			{
				Globals.GemGemGem = false;
				this.Gemmer22 = 0f;
				PlayerData.InventoryKey fishIK3 = default(PlayerData.InventoryKey);
				fishIK3.blockType = (World.BlockType)117445102;
				foreach (CollectableData collectableData6 in Globals.world.collectables)
				{
					bool flag32 = collectableData6.mapPoint == Globals.CurrentMapPoint;
					if (flag32)
					{
						OutgoingMessages.SendCollectCollectableMessage(collectableData6.id);
					}
				}
				OutgoingMessages.RecycleFish(fishIK3, 999);
				Globals.PlayerData.AddGems(9590400);
			}
			bool keyDown = Input.GetKeyDown(KeyCode.Tab);
			if (keyDown)
			{
				AMod.showGUI = !AMod.showGUI;
			}
			bool viewNotes = Globals.viewNotes;
			if (viewNotes)
			{
				AMod.showNotes = true;
			}
			else
			{
				AMod.showNotes = false;
			}
			bool flag33 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Alpha2);
			if (flag33)
			{
				Globals.Jetpacker = !Globals.Jetpacker;
				bool flag34 = !Globals.Jetpacker;
				if (flag34)
				{
					InfoPopupUI.SetupInfoPopup("JetSpammer Toggled!", "Currently: Off");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleDisappear, 0f, -1);
				}
				bool jetpacker = Globals.Jetpacker;
				if (jetpacker)
				{
					InfoPopupUI.SetupInfoPopup("JetSpammer Toggled!", "Currently: On");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleAppear, 0f, -1);
				}
			}
			bool flag35 = Globals.VisualName && Globals.Player;
			if (flag35)
			{
				this.ticks += 0.03f;
				string theRealPlayername = StaticPlayer.theRealPlayername;
				StringBuilder stringBuilder = new StringBuilder();
				for (int n = 0; n < theRealPlayername.Length; n++)
				{
					Color color = new Color
					{
						r = 0.5f + 0.5f * Mathf.Cos(this.ticks + (float)n / ((float)theRealPlayername.Length / 4f)),
						g = 0.5f + 0.5f * Mathf.Cos(this.ticks + (float)n / ((float)theRealPlayername.Length / 4f) + 2f),
						b = 0.5f + 0.5f * Mathf.Cos(this.ticks + (float)n / ((float)theRealPlayername.Length / 4f) + 4f),
						a = 1f
					};
					string arg = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", new object[]
					{
						(int)(color.r * 255f),
						(int)(color.g * 255f),
						(int)(color.b * 255f),
						(int)(color.a * 255f)
					});
					stringBuilder.Append(string.Format("<color={0}>{1}</color>", arg, theRealPlayername[n]));
				}
				ControllerHelper.worldController.player.playerNameTextMeshPro.SetText(stringBuilder.ToString(), true);
			}
			bool flag36 = Globals.AirbronzeName && Globals.Player;
			if (flag36)
			{
				this.ticks += 0.03f;
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int num4 = 0; num4 < this.VisualPlayerName.Length; num4++)
				{
					Color color2 = new Color
					{
						r = 0.2f + 0.6f * Mathf.Cos(this.ticks + (float)num4 / ((float)this.VisualPlayerName.Length / 4f)),
						g = 0.2f + 0.6f * Mathf.Cos(this.ticks + (float)num4 / ((float)this.VisualPlayerName.Length / 4f) + 2f),
						b = 0.5f + 0.2f * Mathf.Cos(this.ticks + (float)num4 / ((float)this.VisualPlayerName.Length / 4f) + 4f),
						a = 1f
					};
					string arg2 = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", new object[]
					{
						(int)(color2.r * 255f),
						(int)(color2.g * 255f),
						(int)(color2.b * 255f),
						(int)(color2.a * 255f)
					});
					stringBuilder2.Append(string.Format("<color={0}>{1}</color>", arg2, this.VisualPlayerName[num4]));
				}
				ControllerHelper.worldController.player.playerNameTextMeshPro.SetText(stringBuilder2.ToString(), true);
			}
			this.GemPouchTimer += Time.deltaTime;
			bool flag37 = Globals.GemPoucher2 && this.GemPouchTimer >= 0.02f;
			if (flag37)
			{
				this.GemPouchTimer = 0f;
				OutgoingMessages.SendOpenTreasureMessage(new PlayerData.InventoryKey
				{
					blockType = (World.BlockType)Globals.GemPoucher1,
					itemType = ConfigData.GetBlockTypeInventoryItemType((World.BlockType)Globals.GemPoucher1)
				}, true);
			}
			this.CardPackTimer += Time.deltaTime;
			bool flag38 = Globals.CardPack1 && this.CardPackTimer >= 0.02f;
			if (flag38)
			{
				this.CardPackTimer = 0f;
				OutgoingMessages.OpenCardPack(PlayerData.InventoryKey.IntToInventoryKey(117445216));
			}
			this.GambleTimer += Time.deltaTime;
			bool flag39 = Globals.Gambler && this.GambleTimer >= 0.3f;
			if (flag39)
			{
				this.GambleTimer = 0f;
				Vector2i currentPlayerMapPoint = Globals.Player.currentPlayerMapPoint;
				OutgoingMessages.SendDonateByteCoinsMessage(new PlayerData.InventoryKey
				{
					blockType = World.BlockType.FantasyWell
				}, currentPlayerMapPoint, 1);
			}
			this.RecyclerTimer += Time.deltaTime;
			bool flag40 = Globals.Recycler && this.RecyclerTimer >= 1f;
			if (flag40)
			{
				this.RecyclerTimer = 0f;
				Vector2i currentPlayerMapPoint2 = Globals.Player.currentPlayerMapPoint;
				PlayerData.InventoryKey currentSelection = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
				OutgoingMessages.RecycleBlock(currentSelection, 1, currentPlayerMapPoint2);
			}
			this.DropTrashTimer += Time.deltaTime;
			bool flag41 = Globals.Trasher && this.DropTrashTimer >= 1f;
			if (flag41)
			{
				this.DropTrashTimer = 0f;
				PlayerData.InventoryKey currentSelection2 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
				short count = Globals.PlayerData.GetCount(currentSelection2);
				Globals.gameplayUI.inventoryControl.ActualTrashOrRecycleAction(currentSelection2, count);
			}
			this.DropTrashTimer += Time.deltaTime;
			bool flag42 = Globals.Dropper && this.DropTrashTimer >= 1f;
			if (flag42)
			{
				this.DropTrashTimer = 0f;
				PlayerData.InventoryKey currentSelection3 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
				short count2 = Globals.PlayerData.GetCount(currentSelection3);
				Globals.Player.DropItems(currentSelection3, count2);
				Globals.PlayerData.RemoveItemsFromInventory(currentSelection3, count2);
			}
			this.PotionCrafterTimer += Time.deltaTime;
			bool flag43 = Globals.PotionCrafter && this.PotionCrafterTimer >= 0.5f;
			if (flag43)
			{
				this.PotionCrafterTimer = 0f;
				Vector2i currentPlayerMapPoint3 = Globals.Player.currentPlayerMapPoint;
				WorldItemBase worldItemData2 = Globals.world.GetWorldItemData(Globals.CurrentMapPoint);
				bool flag44 = worldItemData2 != null;
				bool flag45 = flag44;
				if (flag45)
				{
					BSONObject asBSON2 = worldItemData2.GetAsBSON();
					bool flag46 = ConfigData.IsConsumablePotion((World.BlockType)Globals.PotionID);
					bool flag47 = flag46;
					if (flag47)
					{
						asBSON2["craftingStartTimeInTicks"] = 0L;
						worldItemData2.SetViaBSON(asBSON2);
						PlayerData.InventoryKey foodType = default(PlayerData.InventoryKey);
						foodType.blockType = (World.BlockType)Globals.PotionID;
						foodType.itemType = ConfigData.GetBlockTypeInventoryItemType((World.BlockType)Globals.PotionID);
						OutgoingMessages.SendCraftFAMFoodMessage(currentPlayerMapPoint3, Globals.world.GetWorldItemData(currentPlayerMapPoint3), foodType);
						OutgoingMessages.SendCollectFAMFoodMessage(currentPlayerMapPoint3, Globals.world.GetWorldItemData(currentPlayerMapPoint3), foodType);
					}
				}
			}
			this.AnimationTimer += Time.deltaTime;
			bool flag48 = Globals.AnimOnner && this.AnimationTimer >= 0.2f;
			if (flag48)
			{
				try
				{
					Vector2i vector2i = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
					WorldItemBase worldItemData3 = Globals.world.GetWorldItemData(vector2i);
					bool flag49 = worldItemData3 != null;
					bool flag50 = flag49;
					if (flag50)
					{
						BSONObject asBSON3 = worldItemData3.GetAsBSON();
						asBSON3["animOn"] = true;
						BSONObject bsonobject6 = new BSONObject();
						bsonobject6["ID"] = "WIU";
						bsonobject6["WiB"] = asBSON3;
						bsonobject6["x"] = vector2i.x;
						bsonobject6["y"] = vector2i.y;
						bsonobject6["PT"] = 1;
						bsonobject6["U"] = "AverageAModUser";
						Globals.world.WorldItemUpdate(bsonobject6);
						OutgoingMessages.SendWorldItemUpdateMessage(vector2i, Globals.world.GetWorldItemData(vector2i), ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(vector2i)));
					}
				}
				catch
				{
				}
			}
			this.AnimationTimer += Time.deltaTime;
			bool flag51 = Globals.AnimOffer && this.AnimationTimer >= 0.2f;
			if (flag51)
			{
				try
				{
					Vector2i vector2i2 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
					WorldItemBase worldItemData4 = Globals.world.GetWorldItemData(vector2i2);
					bool flag52 = worldItemData4 != null;
					bool flag53 = flag52;
					if (flag53)
					{
						BSONObject asBSON4 = worldItemData4.GetAsBSON();
						asBSON4["animOn"] = false;
						BSONObject bsonobject7 = new BSONObject();
						bsonobject7["ID"] = "WIU";
						bsonobject7["WiB"] = asBSON4;
						bsonobject7["x"] = vector2i2.x;
						bsonobject7["y"] = vector2i2.y;
						bsonobject7["PT"] = 1;
						bsonobject7["U"] = "AverageAModUser";
						Globals.world.WorldItemUpdate(bsonobject7);
						OutgoingMessages.SendWorldItemUpdateMessage(vector2i2, Globals.world.GetWorldItemData(vector2i2), ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(vector2i2)));
					}
				}
				catch
				{
				}
			}
			this.JetSpammerTimer += Time.deltaTime;
			bool flag54 = Globals.Jetpacker && this.JetSpammerTimer >= 0.3f;
			if (flag54)
			{
				this.JetSpammerTimer = 0f;
				OutgoingMessages.SendPlayPlayerAudioMessage(66, 881);
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.PlayerRocketEmpty, World.BlockType.JetPackDark, 0f, -1);
			}
			this.LizoTimer += Time.deltaTime;
			bool flag55 = Globals.LizoEffect && this.LizoTimer >= 1f;
			if (flag55)
			{
				this.LizoTimer = 0f;
				OutgoingMessages.SendPlayerPoisonStart(World.BlockType.PoisonTrap);
				Globals.Player.CheckPoisoned();
			}
			this.WLPlacerTimer += Time.deltaTime;
			bool flag56 = Globals.WLPlacer && this.WLPlacerTimer >= 0.02f;
			if (flag56)
			{
				this.WLPlacerTimer = 0f;
				Vector2i mapPoint = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				OutgoingMessages.SendSetBlockMessage(mapPoint, World.BlockType.LockWorld);
			}
			bool instantRes = Globals.InstantRes;
			if (instantRes)
			{
				ConfigData.playerIsDeadBackupTimerCheck = 0f;
				Globals.Player.portalAnimationSpeed = 50f;
				Globals.Player.portalScaleAnimationSpeed = 50f;
			}
			bool antiPush = Globals.AntiPush;
			if (antiPush)
			{
				ConfigData.playerHitOtherPlayerVelocityMax = 0f;
			}
			bool infiniteText = Globals.InfiniteText;
			if (infiniteText)
			{
				ConfigData.chatCharacterLimit = byte.MaxValue;
				ConfigData.maxChatLines = byte.MaxValue;
				ConfigData.maxCharsPerSign = 9999;
				ConfigData.maxEmojisPerMessage = byte.MaxValue;
			}
			bool flyHack = Globals.FlyHack;
			if (flyHack)
			{
				ConfigData.jumpMinHeight = 0.3f;
				ConfigData.jumpMinHeightRocket = 0.3f;
				ConfigData.rocketFuelConsumptionSpeed = 0f;
				ConfigData.rocketFuelConsumptionSpeed60FPS = 0f;
				Globals.Player.rocketFuelRegenerationSpeed = 99999f;
				Globals.Player.rocketFuel = 99999f;
			}
			bool flag57 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Alpha1);
			if (flag57)
			{
				Globals.InvisibleHack = !Globals.InvisibleHack;
				bool flag58 = !Globals.InvisibleHack;
				if (flag58)
				{
					InfoPopupUI.SetupInfoPopup("GhostHack Toggled!", "Currently: Off");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleDisappear, 0f, -1);
				}
				bool invisibleHack = Globals.InvisibleHack;
				if (invisibleHack)
				{
					InfoPopupUI.SetupInfoPopup("GhostHack Toggled!", "Currently: On");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleAppear, 0f, -1);
				}
			}
			this.InvisibleHackTimer += Time.deltaTime;
			bool flag59 = Globals.InvisibleHack && this.InvisibleHackTimer >= 0.2f;
			if (flag59)
			{
				this.InvisibleHackTimer = 0f;
				OutgoingMessages.SendPlayerActivateInPortal(Globals.world.playerStartPosition);
				OutgoingMessages.SendPlayerActivateOutPortal(Globals.world.playerStartPosition);
			}
			this.SpikeBomberTimer += Time.deltaTime;
			bool flag60 = Globals.SpikeBomber && this.SpikeBomberTimer >= 0.1f;
			if (flag60)
			{
				this.SpikeBomberTimer = 0f;
				OutgoingMessages.SendPlayPlayerAudioMessage(14, 959);
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.GotHitFromBlock, World.BlockType.SpikeBall, -1f, -1);
			}
			this.TeamSwitcherTimer += Time.deltaTime;
			bool flag61 = Globals.TeamSwitcher && this.TeamSwitcherTimer >= 0.1f;
			if (flag61)
			{
				this.TeamSwitcherTimer = 0f;
				PlayerData.Gender gender = (PlayerData.Gender)this.random.Next(0, 2);
				int num5 = this.random.Next(0, 15);
				OutgoingMessages.PlayerInfoUpdated(gender, Globals.PlayerData.countryCode, num5, Globals.PlayerData.skinColorIndexBeforeOverride);
				Globals.Player.ChangeSkinColor(num5);
				Globals.PlayerData.gender = gender;
			}
			this.PWEBuyerTImer += Time.deltaTime;
			bool flag62 = Globals.PWEBuyerAuto && this.PWEBuyerTImer >= 0.5f;
			if (flag62)
			{
				this.PWEBuyerTImer = 0f;
				Vector2i currentPlayerMapPoint4 = Globals.Player.currentPlayerMapPoint;
				OutgoingMessages.SendBuyOutAuctionHouseItem(currentPlayerMapPoint4, new PlayerData.InventoryKey
				{
					blockType = (World.BlockType)int.Parse(Globals.InventoryKeyBT),
					itemType = ConfigData.GetBlockTypeInventoryItemType((World.BlockType)int.Parse(Globals.InventoryKeyIT))
				}, 1L);
			}
			this.DropTimer += Time.deltaTime;
			bool flag63 = Globals.CustomItemDrop && this.DropTimer >= 0.02f;
			if (flag63)
			{
				this.DropTimer = 0f;
				Vector2i vector2i3 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				PlayerData.InventoryKey inventoryKey5 = default(PlayerData.InventoryKey);
				inventoryKey5.blockType = (World.BlockType)int.Parse(Globals.InventoryKeyBT);
				inventoryKey5.itemType = ConfigData.GetBlockTypeInventoryItemType((World.BlockType)int.Parse(Globals.InventoryKeyIT));
				Globals.DropAmtRandomized = this.random.Next(1, 999);
				OutgoingMessages.SendBuyOutAuctionHouseItem(vector2i3, inventoryKey5, 999L);
				OutgoingMessages.SendDropItemMessage(vector2i3, inventoryKey5, (short)Globals.DropAmtRandomized, Globals.PlayerData.GetInventoryData(Globals.gameplayUI.inventoryControl.GetCurrentSelection()));
			}
			this.DropTimer += Time.deltaTime;
			bool flag64 = Globals.RandomCDrop && this.DropTimer >= 0.02f;
			if (flag64)
			{
				this.DropTimer = 0f;
				Vector2i vector2i4 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				PlayerData.InventoryKey inventoryKey6 = default(PlayerData.InventoryKey);
				inventoryKey6.blockType = (World.BlockType)this.random.Next(1, 5000);
				inventoryKey6.itemType = ConfigData.GetBlockTypeInventoryItemType((World.BlockType)this.random.Next(0, 10));
				Globals.DropAmtRandomized = this.random.Next(1, 999);
				OutgoingMessages.SendBuyOutAuctionHouseItem(vector2i4, inventoryKey6, 999L);
				OutgoingMessages.SendDropItemMessage(vector2i4, inventoryKey6, (short)Globals.DropAmtRandomized, Globals.PlayerData.GetInventoryData(Globals.gameplayUI.inventoryControl.GetCurrentSelection()));
			}
			this.SeedTimer += Time.deltaTime;
			bool flag65 = Globals.CustomSeeder && this.SeedTimer >= 0.02f;
			if (flag65)
			{
				try
				{
					Vector2i vector2i5 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
					WorldItemBase worldItemData5 = Globals.world.GetWorldItemData(vector2i5);
					bool flag66 = worldItemData5 != null;
					bool flag67 = flag66;
					if (flag67)
					{
						BSONObject asBSON5 = worldItemData5.GetAsBSON();
						BSONObject bsonobject8 = new BSONObject();
						bsonobject8["ID"] = "WIU";
						bsonobject8["WiB"] = asBSON5;
						bsonobject8["x"] = vector2i5.x;
						bsonobject8["y"] = vector2i5.y;
						asBSON5["itemInventoryKeyAsInt"] = this.random.Next(1, 5000);
						asBSON5["itemAmount"] = 999;
						asBSON5["takeAmount"] = this.random.Next(1, 999);
						asBSON5["PT"] = 1;
						Globals.world.WorldItemUpdate(bsonobject8);
						OutgoingMessages.SendWorldItemUpdateMessage(vector2i5, Globals.world.GetWorldItemData(vector2i5), ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(vector2i5)));
					}
				}
				catch
				{
				}
			}
			this.WearTimer += Time.deltaTime;
			bool flag68 = Globals.Wearer && this.WearTimer >= 0.02f;
			if (flag68)
			{
				Globals.BValue = this.random.Next(1, 5000);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)Globals.BValue);
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)Globals.BValue, 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
				OutgoingMessages.SendWearableOrWeaponChange((World.BlockType)this.random.Next(1, 5000));
				Globals.Player.ChangeWearableOrWeaponRemote((World.BlockType)this.random.Next(1, 5000), 0);
			}
			this.ForcePlace += Time.deltaTime;
			bool flag69 = Globals.ForcePlace && this.ForcePlace >= 0.02f;
			if (flag69)
			{
				Vector2i mapPoint2 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				OutgoingMessages.SendSetBlockBackgroundMessage(mapPoint2, World.BlockType.LockWorld);
			}
			this.BedrockBreaker += Time.deltaTime;
			bool flag70 = Globals.Bbreak && this.BedrockBreaker >= 0.02f;
			if (flag70)
			{
				Vector2i mapPoint3 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				this.BedrockBreaker = 0f;
				OutgoingMessages.SendSetBlockBackgroundMessage(mapPoint3, World.BlockType.Bedrock);
				OutgoingMessages.SendHitBlockBackgroundMessage(mapPoint3, Il2CppSystem.DateTime.Now);
			}
			this.BFarmerTime += Time.deltaTime;
			bool flag71 = Globals.BFarmer && this.BFarmerTime >= 0.02f;
			if (flag71)
			{
				this.BFarmerTime = 0f;
				Vector2i mapPoint4 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				OutgoingMessages.SendSetBlockBackgroundMessage(mapPoint4, (World.BlockType)int.Parse(Globals.BFValue));
				OutgoingMessages.SendHitBlockBackgroundMessage(mapPoint4, Il2CppSystem.DateTime.Now);
			}
			this.NukeTimer += Time.deltaTime;
			bool flag72 = Globals.Nuker && this.NukeTimer >= 0.2f;
			if (flag72)
			{
				Vector2i mapPoint5 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				this.NukeTimer = 0f;
				OutgoingMessages.SendHitBlockMessage(mapPoint5, Il2CppSystem.DateTime.Now, false);
				OutgoingMessages.SendHitBlockBackgroundMessage(mapPoint5, Il2CppSystem.DateTime.Now);
			}
			this.SpamBotTimer += Time.deltaTime;
			this.JoinRandomWorlds += Time.deltaTime;
			bool flag73 = Globals.SpamTexter && this.SpamBotTimer > Globals.SendMsgTime;
			if (flag73)
			{
				this.SpamBotTimer = 0f;
				OutgoingMessages.SubmitWorldChatMessage(Globals.SpamTextOfChoice);
				Globals.chatUI.Submit(Globals.SpamTextOfChoice);
				bool flag74 = Globals.JoinRandomWorlds && Globals.SpamTexter && this.JoinRandomWorlds > Globals.WorldTime;
				if (flag74)
				{
					this.JoinRandomWorlds = 0f;
					OutgoingMessages.SendTryToJoinRandomMessage();
				}
			}
			this.FriendReqTimer += Time.deltaTime;
			bool flag75 = Globals.FriendReqSpam && Globals.NetworkClient.playerConnectionStatus == PlayerConnectionStatus.InRoom;
			if (flag75)
			{
				bool flag76 = this.FriendReqTimer > Globals.SendMsgTime;
				if (flag76)
				{
					foreach (NetworkPlayer networkPlayer in NetworkPlayers.otherPlayers)
					{
						this.FriendReqTimer = 0f;
						OutgoingMessages.AddFriend(networkPlayer.clientId);
					}
				}
			}
			this.EmoteTimer += Time.deltaTime;
			bool flag77 = Globals.EmoteSpam && this.EmoteTimer > 2f;
			if (flag77)
			{
				this.EmoteTimer = 0f;
				OutgoingMessages.SendPetPetMessage(3);
			}
			this.ReqTimer += Time.deltaTime;
			bool flag78 = Globals.TradeSpam && this.ReqTimer > 3f;
			if (flag78)
			{
				this.ReqTimer = 0f;
				foreach (NetworkPlayer networkPlayer2 in NetworkPlayers.otherPlayers)
				{
					OutgoingMessages.AskTrade(networkPlayer2.clientId);
				}
			}
			this.MSwapTimer += Time.deltaTime;
			bool flag79 = Globals.MannequinSpam && this.MSwapTimer > 0.002f;
			if (flag79)
			{
				this.MSwapTimer = 0f;
				Vector2i currentPlayerMapPoint5 = Globals.Player.currentPlayerMapPoint;
				OutgoingMessages.SendAdjustMannequinAndInventoryMessage(currentPlayerMapPoint5, Globals.world.GetWorldItemData(currentPlayerMapPoint5), true);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000CE48 File Offset: 0x0000B048
		private void DrawMenu(int ID)
		{
			bool flag = GUI.Button(new Rect(1f, 15f, 50f, 35f), "Main");
			if (flag)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Main;
			}
			bool flag2 = GUI.Button(new Rect(51f, 15f, 50f, 35f), "Data");
			if (flag2)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Data;
			}
			bool flag3 = GUI.Button(new Rect(101f, 15f, 50f, 35f), "Misc");
			if (flag3)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Misc;
			}
			bool flag4 = GUI.Button(new Rect(151f, 15f, 75f, 35f), "Accounts");
			if (flag4)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Accounts;
			}
			bool flag5 = GUI.Button(new Rect(226f, 15f, 50f, 35f), "Utils");
			if (flag5)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Utils;
			}
			bool flag6 = GUI.Button(new Rect(276f, 15f, 70f, 35f), "Settings");
			if (flag6)
			{
				Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				this.tab = AMod.Tab.Settings;
			}
			bool flag7 = GUI.Button(new Rect(356f, 15f, 36f, 35f), "$");
			if (flag7)
			{
				this.tab = AMod.Tab.DExtra;
			}
			switch (this.tab)
			{
			case AMod.Tab.Main:
			{
				Globals.GodMode = GUI.Toggle(new Rect(10f, 55f, 85f, 25f), Globals.GodMode, "GodMode");
				Globals.AutoMath = GUI.Toggle(new Rect(130f, 55f, 90f, 25f), Globals.AutoMath, "AutoMath");
				Globals.MuteGMs = GUI.Toggle(new Rect(130f, 75f, 90f, 25f), Globals.MuteGMs, "Mute GMs");
				Globals.WLPlacer = GUI.Toggle(new Rect(130f, 95f, 90f, 25f), Globals.WLPlacer, "Auto-WL");
				Globals.ignoreFwk = GUI.Toggle(new Rect(130f, 115f, 90f, 25f), Globals.ignoreFwk, "Anti-Fireworks");
				Globals.PlaceholderBool = GUI.Toggle(new Rect(130f, 135f, 90f, 25f), Globals.PlaceholderBool, "Placeholder");
				Globals.PlaceholderBool = GUI.Toggle(new Rect(130f, 155f, 90f, 25f), Globals.PlaceholderBool, "PlaceHolder");
				Globals.PlaceholderBool = GUI.Toggle(new Rect(130f, 175f, 90f, 25f), Globals.PlaceholderBool, "PlaceHolder");
				Globals.PlaceholderBool = GUI.Toggle(new Rect(130f, 195f, 90f, 25f), Globals.PlaceholderBool, "PlaceHolder");
				Globals.Custompack = GUI.Toggle(new Rect(130f, 215f, 90f, 25f), Globals.Custompack, "C-Pack");
				Globals.IRef = GUI.Toggle(new Rect(130f, 235f, 90f, 20f), Globals.IRef, "Inv. Refresh");
				Globals.FlyHack = GUI.Toggle(new Rect(10f, 75f, 85f, 25f), Globals.FlyHack, "Fly");
				Globals.AntiVortex = GUI.Toggle(new Rect(10f, 95f, 95f, 25f), Globals.AntiVortex, "Anti-Vortex");
				Globals.AntiPush = GUI.Toggle(new Rect(10f, 115f, 105f, 25f), Globals.AntiPush, "No KnockBack");
				Globals.BlockKill = GUI.Toggle(new Rect(10f, 135f, 110f, 25f), Globals.BlockKill, "Block Kill");
				Globals.InstantRes = GUI.Toggle(new Rect(10f, 155f, 95f, 25f), Globals.InstantRes, "Instant Res");
				Globals.InfiniteText = GUI.Toggle(new Rect(10f, 175f, 95f, 25f), Globals.InfiniteText, "Long Text");
				Globals.AntiCollect = GUI.Toggle(new Rect(10f, 195f, 85f, 25f), Globals.AntiCollect, "Anti-Collect");
				Globals.AntiBounce = GUI.Toggle(new Rect(10f, 215f, 85f, 25f), Globals.AntiBounce, "Anti-Bounce");
				Globals.Test = GUI.Toggle(new Rect(10f, 235f, 85f, 25f), Globals.Test, "Test");
				Globals.SpikeBomber = GUI.Toggle(new Rect(10f, 255f, 105f, 25f), Globals.SpikeBomber, "Annoy Sounds");
				Globals.VisualName = GUI.Toggle(new Rect(10f, 275f, 105f, 25f), Globals.VisualName, "Colored Name");
				bool flag8 = GUI.Button(new Rect(100f, 350f, 90f, 25f), "AUTOBUY");
				if (flag8)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.AutoBuy;
				}
				bool flag9 = !Globals.Fwker;
				if (flag9)
				{
					bool flag10 = GUI.Button(new Rect(190f, 350f, 130f, 25f), "Firework OFF");
					if (flag10)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Fwker = true;
					}
				}
				else
				{
					bool flag11 = GUI.Button(new Rect(190f, 350f, 130f, 25f), "Firework ON");
					if (flag11)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Fwker = false;
					}
				}
				bool flag12 = GUI.Button(new Rect(10f, 320f, 90f, 25f), "Support us?");
				if (flag12)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					SceneLoader.CheckIfWeCanGoFromWorldToWorld("GIFTBRONZE", "", null, false, null);
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				bool flag13 = GUI.Button(new Rect(10f, 350f, 90f, 25f), "Join Discord");
				if (flag13)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Application.OpenURL("https://discord.gg/aKTa85hrwG");
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				bool flag14 = GUI.Button(new Rect(100f, 320f, 90f, 25f), "More");
				if (flag14)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Main2;
				}
				break;
			}
			case AMod.Tab.Data:
			{
				Globals.cmIncoming = GUI.Toggle(new Rect(15f, 55f, 120f, 25f), Globals.cmIncoming, "Capture Incoming");
				Globals.cmOutgoing = GUI.Toggle(new Rect(15f, 85f, 120f, 25f), Globals.cmOutgoing, "Capture Outgoing");
				bool flag15 = !Globals.ViewOcaptureOrICapture;
				if (flag15)
				{
					bool flag16 = GUI.Button(new Rect(190f, 55f, 150f, 25f), "Outgoing Packet:");
					if (flag16)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.ViewOcaptureOrICapture = true;
					}
					Globals.CurrentCaptureOUTGOING = GUI.TextArea(new Rect(155f, 85f, 220f, 250f), Globals.CurrentCaptureOUTGOING);
				}
				else
				{
					bool flag17 = GUI.Button(new Rect(190f, 55f, 150f, 25f), "Incoming Packet:");
					if (flag17)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.ViewOcaptureOrICapture = false;
					}
					Globals.CurrentCaptureINCOMING = GUI.TextArea(new Rect(155f, 85f, 220f, 250f), Globals.CurrentCaptureINCOMING);
				}
				bool flag18 = GUI.Button(new Rect(15f, 115f, 120f, 25f), "Send Packet");
				if (flag18)
				{
					bool flag19 = !Globals.ViewOcaptureOrICapture;
					if (flag19)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomPacket = Globals.CurrentCaptureOUTGOING;
					}
					bool viewOcaptureOrICapture = Globals.ViewOcaptureOrICapture;
					if (viewOcaptureOrICapture)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomPacket = Globals.CurrentCaptureINCOMING;
					}
					AMod.SendCustomPacket();
				}
				bool flag20 = GUI.Button(new Rect(15f, 145f, 120f, 25f), "Load Packet");
				if (flag20)
				{
					string path = System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json";
					bool flag21 = !Globals.ViewOcaptureOrICapture;
					if (flag21)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CurrentCaptureOUTGOING = File.ReadAllText(path);
					}
					bool viewOcaptureOrICapture2 = Globals.ViewOcaptureOrICapture;
					if (viewOcaptureOrICapture2)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CurrentCaptureINCOMING = File.ReadAllText(path);
					}
				}
				bool flag22 = GUI.Button(new Rect(15f, 175f, 120f, 25f), "Save Packet");
				if (flag22)
				{
					bool flag23 = !Globals.ViewOcaptureOrICapture;
					if (flag23)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						FileStream fileStream = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", FileMode.Create);
						fileStream.Close();
						File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", Globals.CurrentCaptureOUTGOING);
					}
					bool viewOcaptureOrICapture3 = Globals.ViewOcaptureOrICapture;
					if (viewOcaptureOrICapture3)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						FileStream fileStream2 = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", FileMode.Create);
						fileStream2.Close();
						File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", Globals.CurrentCaptureINCOMING);
					}
				}
				bool flag24 = GUI.Button(new Rect(15f, 205f, 120f, 25f), "More");
				if (flag24)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.PacketExtra;
				}
				Globals.PSpamP = GUI.Toggle(new Rect(15f, 235f, 120f, 25f), Globals.PSpamP, "Spam Packet");
				bool flag25 = GUI.Button(new Rect(15f, 265f, 120f, 25f), "Spam Settings");
				if (flag25)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.SpamSettingsPacket;
				}
				break;
			}
			case AMod.Tab.PacketExtra:
			{
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "Save/Load Packet as:");
				GUI.Label(new Rect(170f, 95f, 10000f, 10000f), ".json");
				Globals.CPacketFile = GUI.TextArea(new Rect(15f, 95f, 150f, 25f), Globals.CPacketFile);
				bool flag26 = GUI.Button(new Rect(15f, 125f, 120f, 25f), "Load Packet");
				if (flag26)
				{
					string path2 = System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json";
					bool flag27 = !Globals.ViewOcaptureOrICapture;
					if (flag27)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CurrentCaptureOUTGOING = File.ReadAllText(path2);
					}
					bool viewOcaptureOrICapture4 = Globals.ViewOcaptureOrICapture;
					if (viewOcaptureOrICapture4)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CurrentCaptureINCOMING = File.ReadAllText(path2);
					}
				}
				bool flag28 = GUI.Button(new Rect(140f, 125f, 120f, 25f), "Save Packet");
				if (flag28)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					FileStream fileStream3 = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", FileMode.Create);
					fileStream3.Close();
					File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Packets\\" + Globals.CPacketFile + ".json", Globals.CustomPacket);
				}
				bool flag29 = GUI.Button(new Rect(15f, 165f, 120f, 25f), "Back?");
				if (flag29)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Data;
				}
				Globals.ignoreID = GUI.TextArea(new Rect(15f, 195f, 120f, 25f), Globals.ignoreID);
				bool flag30 = GUI.Button(new Rect(15f, 225f, 120f, 25f), "Ignore Outgoing");
				if (flag30)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.OutgoingBlock.Add(Globals.ignoreID);
					string text = "";
					foreach (string str in Globals.OutgoingBlock)
					{
						text = text + str + ", ";
					}
					ChatUI.SendMinigameMessage("Outgoing Ignores: " + text);
					MelonLogger.Msg("Outgoing Ignores: " + text);
				}
				bool flag31 = GUI.Button(new Rect(135f, 225f, 120f, 25f), "Ignore Incoming");
				if (flag31)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.IncomingBlock.Add(Globals.ignoreID);
					string text2 = "";
					foreach (string str2 in Globals.IncomingBlock)
					{
						text2 = text2 + str2 + ", ";
					}
					ChatUI.SendMinigameMessage("Incoming Ignores: " + text2);
					MelonLogger.Msg("Incoming Ignores: " + text2);
				}
				bool flag32 = GUI.Button(new Rect(255f, 225f, 120f, 25f), "Reset Ignores");
				if (flag32)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					ChatUI.SendMinigameMessage("Ignore Packets list cleared!");
					Globals.IncomingBlock.Clear();
					Globals.OutgoingBlock.Clear();
				}
				break;
			}
			case AMod.Tab.Troll:
			{
				bool flag33 = GUI.Button(new Rect(15f, 55f, 110f, 30f), "ClothesBugger");
				if (flag33)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.ClothesBugger;
				}
				bool flag34 = GUI.Button(new Rect(15f, 85f, 110f, 30f), "MusicBugger");
				if (flag34)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Music;
				}
				bool flag35 = GUI.Button(new Rect(15f, 115f, 125f, 25f), "Donation Bugger");
				if (flag35)
				{
					Vector2i currentPlayerMapPoint = Globals.Player.currentPlayerMapPoint;
					PlayerData.InventoryKey ik = default(PlayerData.InventoryKey);
					ik.blockType = World.BlockType.Poop;
					ik.itemType = PlayerData.InventoryItemType.BlockWater;
					OutgoingMessages.SendAddItemToDonationBox(currentPlayerMapPoint, Globals.world.GetWorldItemData(currentPlayerMapPoint), ik, -420, null);
					InfoPopupUI.SetupInfoPopup("Donation Box Bugged!", "Can be used 3 times on any donation box!");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.HalloweenTowerStart, 0f, -1);
				}
				Globals.LizoEffect = GUI.Toggle(new Rect(15f, 145f, 105f, 25f), Globals.LizoEffect, "Lizo Effect");
				bool flag36 = GUI.Button(new Rect(15f, 175f, 105f, 25f), "ChestBugger");
				if (flag36)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					InfoPopupUI.SetupInfoPopup("Unfinished :(", "");
					InfoPopupUI.ForceShowMenu();
					InfoPopupUI.maxWindowLifetime = 10f;
				}
				bool flag37 = GUI.Button(new Rect(150f, 365f, 105f, 25f), "Back?");
				if (flag37)
				{
					this.tab = AMod.Tab.Misc;
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				break;
			}
			case AMod.Tab.Misc:
			{
				bool flag38 = GUI.Button(new Rect(15f, 55f, 90f, 30f), "Troll");
				if (flag38)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Troll;
				}
				bool flag39 = GUI.Button(new Rect(15f, 85f, 90f, 30f), "WL Hack");
				if (flag39)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.WLPlacing;
				}
				bool flag40 = !Globals.GWarper;
				if (flag40)
				{
					bool flag41 = GUI.Button(new Rect(15f, 230f, 130f, 25f), "Global Finder OFF");
					if (flag41)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GWarper = true;
					}
				}
				else
				{
					bool flag42 = GUI.Button(new Rect(15f, 230f, 130f, 25f), "Global Finder ON");
					if (flag42)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GWarper = false;
					}
				}
				GUI.Label(new Rect(15f, 155f, 10000f, 10000f), "Global Finder KEYWORD:");
				Globals.LocateGM = GUI.TextArea(new Rect(15f, 195f, 150f, 25f), Globals.LocateGM);
				GUI.Label(new Rect(15f, 255f, 100f, 25f), "Ignore Worlds:");
				Globals.GIgn = GUI.TextArea(new Rect(15f, 275f, 100f, 25f), Globals.GIgn);
				bool flag43 = GUI.Button(new Rect(15f, 305f, 100f, 25f), "Ignore World");
				if (flag43)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.IgnoreGMW.Add(Globals.GIgn.ToLower());
					ChatUI.SendMinigameMessage("Inoring world: @" + Globals.GIgn);
				}
				bool flag44 = GUI.Button(new Rect(15f, 335f, 100f, 25f), "Reset Ignores?");
				if (flag44)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.IgnoreGMW.Clear();
					ChatUI.SendMinigameMessage("GM Ignore Worlds reset!");
				}
				bool flag45 = GUI.Button(new Rect(155f, 55f, 90f, 25f), "Botting");
				if (flag45)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Botting;
				}
				break;
			}
			case AMod.Tab.Accounts:
			{
				GUI.Label(new Rect(150f, 55f, 100f, 100f), "Username");
				Globals.AccountName = GUI.TextArea(new Rect(150f, 85f, 100f, 20f), Globals.AccountName);
				GUI.Label(new Rect(150f, 115f, 100f, 100f), "Password");
				Globals.AccountPassy = GUI.TextArea(new Rect(150f, 145f, 100f, 20f), Globals.AccountPassy);
				bool flag46 = GUI.Button(new Rect(150f, 175f, 90f, 30f), "Login");
				if (flag46)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					UserIdent.LoginWithUsernameAndPassword(Globals.AccountName, Globals.AccountPassy, false);
					SceneLoader.ReloadGame();
					FileStream fileStream4 = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + ".json", FileMode.Create);
					fileStream4.Close();
					File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + ".json", UserIdent.CognitoID);
					FileStream fileStream5 = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + "2.json", FileMode.Create);
					fileStream5.Close();
					File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + "2.json", UserIdent.lastLogin);
					Globals.AccountName = "";
					Globals.AccountPassy = "";
					MelonLogger.Msg("Account saved!");
				}
				bool flag47 = GUI.Button(new Rect(260f, 90f, 130f, 30f), "Saved Accounts");
				if (flag47)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.SavedAccs;
				}
				bool flag48 = GUI.Button(new Rect(15f, 90f, 115f, 30f), "Refresh Cognito");
				if (flag48)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					UserIdent.ForceNewCognitoId();
					SceneLoader.ReloadGame();
					File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + ".json", UserIdent.CognitoID);
					File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + "2.json", UserIdent.lastLogin);
				}
				bool flag49 = GUI.Button(new Rect(15f, 120f, 115f, 30f), "Get Cognito");
				if (flag49)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					MelonLogger.Msg(string.Concat(new string[]
					{
						StaticPlayer.theRealPlayername,
						"'s Cognito:\r\n \r\n Cognito ID: \r\n",
						UserIdent.CognitoID,
						"\r\n \r\n Cognito Key:\r\n",
						UserIdent.lastLogin
					}));
				}
				bool flag50 = GUI.Button(new Rect(15f, 150f, 115f, 30f), "LogOut");
				if (flag50)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					UserIdent.LogOut();
					SceneLoader.ReloadGame();
				}
				break;
			}
			case AMod.Tab.Utils:
			{
				bool flag51 = GUI.Button(new Rect(15f, 55f, 110f, 30f), "AutoPouch");
				if (flag51)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.GemPouch;
				}
				GUI.Label(new Rect(150f, 55f, 1000f, 1000f), "This only opens Basic Card Packs!");
				bool flag52 = !Globals.CardPack1;
				if (flag52)
				{
					bool flag53 = GUI.Button(new Rect(190f, 90f, 150f, 25f), "CardPack Opener OFF");
					if (flag53)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						InfoPopupUI.SetupInfoPopup("Opener Started!", "You may disconnect, if so, turn off the opener.");
						InfoPopupUI.ForceShowMenu();
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleAppear, 0f, -1);
						Globals.CardPack1 = true;
					}
				}
				else
				{
					bool flag54 = GUI.Button(new Rect(190f, 90f, 150f, 25f), "CardPack Opener ON");
					if (flag54)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CardPack1 = false;
					}
				}
				bool flag55 = GUI.Button(new Rect(190f, 140f, 120f, 30f), "Potion Exploits");
				if (flag55)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Potions;
				}
				bool flag56 = Globals.SwordPuller = GUI.Toggle(new Rect(15f, 85f, 105f, 25f), Globals.SwordPuller, "Sword in Stone");
				if (flag56)
				{
					bool flag57 = GUI.Button(new Rect(15f, 115f, 125f, 25f), "Info");
					if (flag57)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						BluePopupUI.SetPopupValue(PopupMode.JustClose, "", "How to use", "This allows you to pull any Sword in Stone!<br Even after it's already been pulled, you can still pull. <br No rights on lock needed to pull them, so you can go to any world and pull!<br Note: The 24hour cooldown still applies!<br <br Have fun!<br by Airbronze <3", "Continue", "", null, null, 0f, 0, false, false, false);
						ControllerHelper.rootUI.OnOrOffMenu(Il2CppType.Of<BluePopupUI>());
					}
					bool flag58 = GUI.Button(new Rect(15f, 145f, 125f, 25f), "Begin Exploit");
					if (flag58)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Vector2i currentPlayerMapPoint2 = Globals.Player.currentPlayerMapPoint;
						OutgoingMessages.SendPullSwordInStone(currentPlayerMapPoint2);
					}
				}
				Globals.AnimOnner = GUI.Toggle(new Rect(15f, 175f, 125f, 25f), Globals.AnimOnner, "AnimOn Spam");
				Globals.AnimOffer = GUI.Toggle(new Rect(15f, 205f, 125f, 25f), Globals.AnimOffer, "AnimOff Spam");
				bool flag59 = !Globals.Gambler;
				if (flag59)
				{
					bool flag60 = GUI.Button(new Rect(15f, 235f, 130f, 25f), "Gambler OFF");
					if (flag60)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Gambler = true;
						InfoPopupUI.SetupInfoPopup("Gambler activated!", "Stand on any Wishing Well to start! \r\n To update your BC amount, turn off Gambler");
						InfoPopupUI.ForceShowMenu();
						InfoPopupUI.maxWindowLifetime = 100f;
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleAppear, 0f, -1);
					}
				}
				else
				{
					bool flag61 = GUI.Button(new Rect(15f, 235f, 130f, 25f), "Gambler ON");
					if (flag61)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Gambler = false;
						ChatUI.SendLogMessage("Updating BC Amount..");
						SceneLoader.ReloadGame();
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleDisappear, 0f, -1);
					}
				}
				bool flag62 = GUI.Button(new Rect(15f, 265f, 130f, 25f), "Free Panorama");
				if (flag62)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendTakePhoto(World.BlockType.ConsumableCameraWorld);
				}
				bool flag63 = !Globals.Recycler;
				if (flag63)
				{
					bool flag64 = GUI.Button(new Rect(15f, 295f, 130f, 25f), "Auto-Recycle OFF");
					if (flag64)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Recycler = true;
					}
				}
				else
				{
					bool flag65 = GUI.Button(new Rect(15f, 295f, 130f, 25f), "Auto-Recycle ON");
					if (flag65)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Recycler = false;
					}
				}
				GUI.Label(new Rect(15f, 325f, 10000f, 100000f), "Select the item in your inventory \r\n you want to recycle!");
				bool flag66 = GUI.Button(new Rect(230f, 290f, 130f, 25f), "Extra");
				if (flag66)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Extra;
				}
				bool flag67 = GUI.Button(new Rect(230f, 245f, 130f, 25f), "Skip EvolveTime");
				if (flag67)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Vector2i currentPlayerMapPoint3 = Globals.Player.currentPlayerMapPoint;
					WorldItemBase worldItemData = Globals.world.GetWorldItemData(currentPlayerMapPoint3);
					BSONObject asBSON = worldItemData.GetAsBSON();
					asBSON["evolveStartTimeInTicks"] = 0L;
					asBSON["level"] = 5;
					worldItemData.SetViaBSON(asBSON);
				}
				bool flag68 = GUI.Button(new Rect(230f, 340f, 130f, 25f), "Private Servers");
				if (flag68)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.PrivateServers;
				}
				break;
			}
			case AMod.Tab.ClothesBugger:
			{
				bool flag69 = GUI.Button(new Rect(15f, 10f, 0.3f, 0.3f), "E");
				if (flag69)
				{
					BluePopupUI.SetPopupValue(PopupMode.JustClose, "", "Easter Egg Unlocked", "Type: Secret Button ;)<br <br Congratulations on finding this easter egg!<br <br Your Name: " + StaticPlayer.theRealPlayername + "<br <br (This was also sent in console)", "Close", "", null, null, 0f, 0, true, false, false);
					ControllerHelper.rootUI.OnOrOffMenu(Il2CppType.Of<BluePopupUI>());
					MelonLogger.Msg("Easter Egg Winner: Secret Button - Name: " + StaticPlayer.theRealPlayername);
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.RoulettePrizeFiveStar, 0f, -1);
				}
				bool flag70 = GUI.Button(new Rect(15f, 55f, 90f, 30f), "Face");
				if (flag70)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicFace);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicFace);
				}
				bool flag71 = GUI.Button(new Rect(15f, 85f, 90f, 30f), "Eyeballs");
				if (flag71)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyeballs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyeballs);
				}
				bool flag72 = GUI.Button(new Rect(15f, 115f, 90f, 30f), "Pupils");
				if (flag72)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicPupil);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicPupil);
				}
				bool flag73 = GUI.Button(new Rect(15f, 145f, 90f, 30f), "Eyebrows");
				if (flag73)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyebrows);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyebrows);
				}
				bool flag74 = GUI.Button(new Rect(15f, 175f, 90f, 30f), "Eyelashes (useless)");
				if (flag74)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyelashes);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyelashes);
				}
				bool flag75 = GUI.Button(new Rect(15f, 205f, 90f, 30f), "Mouth");
				if (flag75)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicMouth);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicMouth);
				}
				bool flag76 = GUI.Button(new Rect(15f, 235f, 90f, 30f), "Torso");
				if (flag76)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTorso);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTorso);
				}
				bool flag77 = GUI.Button(new Rect(15f, 265f, 90f, 30f), "TopArm");
				if (flag77)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTopArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTopArm);
				}
				bool flag78 = GUI.Button(new Rect(15f, 295f, 90f, 30f), "BottomArm");
				if (flag78)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicBottomArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicBottomArm);
				}
				bool flag79 = GUI.Button(new Rect(115f, 55f, 90f, 30f), "Legs");
				if (flag79)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicLegs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicLegs);
				}
				bool flag80 = GUI.Button(new Rect(115f, 85f, 90f, 30f), "Maskless");
				if (flag80)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.MaskHoodBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.MaskHoodBlack);
				}
				bool flag81 = GUI.Button(new Rect(115f, 115f, 90f, 30f), "Hatless");
				if (flag81)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.HatHeroHoodBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.HatHeroHoodBlack);
				}
				bool flag82 = GUI.Button(new Rect(115f, 145f, 90f, 30f), "Torsoless");
				if (flag82)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.ShirtGargoyle);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.ShirtGargoyle);
				}
				bool flag83 = GUI.Button(new Rect(115f, 175f, 90f, 30f), "Bodyless");
				if (flag83)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.SuitPWRBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.SuitPWRBlack);
				}
				bool flag84 = GUI.Button(new Rect(115f, 205f, 90f, 30f), "Legless");
				if (flag84)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.PantsGargoyle);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.PantsGargoyle);
				}
				bool flag85 = GUI.Button(new Rect(115f, 235f, 90f, 30f), "Legless 2");
				if (flag85)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.Underwear);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.Underwear);
				}
				bool flag86 = GUI.Button(new Rect(115f, 265f, 90f, 30f), "Gloves");
				if (flag86)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.GlovesPWRBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.GlovesPWRBlack);
				}
				bool flag87 = GUI.Button(new Rect(115f, 295f, 90f, 30f), "Back Item");
				if (flag87)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.JetPackDark);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.JetPackDark);
				}
				bool flag88 = GUI.Button(new Rect(115f, 325f, 90f, 30f), "Headless");
				if (flag88)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.HatHelmetVisorPWRBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.HatHelmetVisorPWRBlack);
				}
				bool flag89 = GUI.Button(new Rect(15f, 325f, 90f, 30f), "Weaponless");
				if (flag89)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.WeaponPickAxe);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.WeaponPickAxe);
				}
				Globals.TeamSwitcher = GUI.Toggle(new Rect(15f, 365f, 115f, 25f), Globals.TeamSwitcher, "Team Switcher");
				bool flag90 = GUI.Button(new Rect(180f, 365f, 105f, 25f), "Back?");
				if (flag90)
				{
					this.tab = AMod.Tab.Troll;
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				bool flag91 = GUI.Button(new Rect(215f, 55f, 90f, 30f), "MaskBugger");
				if (flag91)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.MaskHoodBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.MaskHoodBlack);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicMouth);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicMouth);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyebrows);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyebrows);
					OutgoingMessages.PlayerInfoUpdated(Globals.PlayerData.gender, Globals.PlayerData.countryCode, Globals.PlayerData.skinColorIndex, Globals.PlayerData.skinColorIndexBeforeOverride);
				}
				bool flag92 = GUI.Button(new Rect(215f, 240f, 90f, 30f), "Reset Set");
				if (flag92)
				{
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.SuitCamouflageSoilblock);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.SuitCamouflageSoilblock);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicLegs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicLegs);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTorso);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTorso);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicFace);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicFace);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicPupil);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicPupil);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyeballs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyeballs);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyebrows);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyebrows);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicBottomArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicBottomArm);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTopArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTopArm);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicMouth);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicMouth);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicEyelashes);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicEyelashes);
					InfoPopupUI.SetupInfoPopup("Character Reset!", "");
					InfoPopupUI.ForceShowMenu();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.BlueParticleAppear, 0f, -1);
				}
				bool flag93 = GUI.Button(new Rect(215f, 95f, 110f, 30f), "MaskBugger 2");
				if (flag93)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.SuitCamouflageSoilblock);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.SuitCamouflageSoilblock);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicLegs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicLegs);
				}
				GUI.Label(new Rect(235f, 135f, 150f, 150f), "Works on DIM and similar masks");
				bool flag94 = GUI.Button(new Rect(235f, 175f, 120f, 25f), "Reset Wolf");
				if (flag94)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponChange(World.BlockType.CostumeWerewolf);
					Globals.Player.ChangeWearableOrWeaponRemote(World.BlockType.CostumeWerewolf, 0);
				}
				bool flag95 = GUI.Button(new Rect(215f, 325f, 90f, 30f), "EPWR Float");
				if (flag95)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.SuitPWRBlack);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.SuitPWRBlack);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.Underwear);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.Underwear);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicLegs);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicLegs);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTopArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTopArm);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicBottomArm);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicBottomArm);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.BasicTorso);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.BasicTorso);
					OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.JetPackDark);
					Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.JetPackDark);
				}
				break;
			}
			case AMod.Tab.Music:
			{
				Globals.MusicPicker = GUI.HorizontalSlider(new Rect(15f, 90f, 300f, 20f), Globals.MusicPicker, 1f, 27f);
				int num = (int)System.Math.Round((double)Globals.MusicPicker);
				Globals.MusicName = Globals.AudioManager.GetMusicName(num);
				GUI.Label(new Rect(125f, 70f, 2E+12f, 33f), string.Format("[{0}]  " + Globals.MusicName, num));
				bool flag96 = GUI.Button(new Rect(110f, 120f, 125f, 35f), "Play Music");
				if (flag96)
				{
					Vector2i currentPlayerMapPoint4 = Globals.Player.currentPlayerMapPoint;
					OutgoingMessages.SendChangeWorldMusicMessage(currentPlayerMapPoint4, num, PlayerTool.WrenchTool);
					Globals.AudioManager.PlayMusic(num);
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				bool flag97 = GUI.Button(new Rect(150f, 365f, 105f, 25f), "Back?");
				if (flag97)
				{
					this.tab = AMod.Tab.Troll;
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				break;
			}
			case AMod.Tab.GemPouch:
			{
				Globals.GemPoucher1 = GUI.HorizontalSlider(new Rect(125f, 90f, 100f, 20f), Globals.GemPoucher1, 3364f, 3366f);
				int num2 = (int)System.Math.Round((double)Globals.GemPoucher1);
				GUI.Label(new Rect(125f, 70f, 130f, 33f), string.Format("[{0}] GemPouch", num2));
				GUI.Label(new Rect(15f, 55f, 150f, 150f), "GemPouch IDs \r\n 3364 - Puny\r\n 3365 - Fine \r\n 3366 - Lux");
				bool flag98 = !Globals.GemPoucher2;
				if (flag98)
				{
					bool flag99 = GUI.Button(new Rect(125f, 110f, 115f, 25f), "Auto-Pouch OFF");
					if (flag99)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemPoucher2 = true;
					}
				}
				else
				{
					bool flag100 = GUI.Button(new Rect(125f, 110f, 115f, 25f), "Auto-Pouch ON");
					if (flag100)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemPoucher2 = false;
					}
				}
				bool flag101 = GUI.Button(new Rect(180f, 365f, 105f, 25f), "Back?");
				if (flag101)
				{
					this.tab = AMod.Tab.Utils;
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
				}
				break;
			}
			case AMod.Tab.SavedAccs:
			{
				GUI.Label(new Rect(150f, 55f, 100f, 100f), "Username");
				Globals.AccountName = GUI.TextArea(new Rect(150f, 85f, 100f, 20f), Globals.AccountName);
				bool flag102 = GUI.Button(new Rect(150f, 115f, 90f, 30f), "Login");
				if (flag102)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					string path3 = System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + ".json";
					string path4 = System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\Accounts\\" + Globals.AccountName + "2.json";
					ChatUI.SendLogMessage("Logging In..");
					UserIdent.LogOut();
					UserIdent.SetCognitoIDAndMarkReady(File.ReadAllText(path3));
					UserIdent.UpdateLastLogin(File.ReadAllText(path4));
					SceneLoader.ReloadGame();
					Globals.AccountName = "";
					Globals.AccountPassy = "";
				}
				GUI.Label(new Rect(150f, 150f, 150f, 150f), "Your account names save so you only have to write the username!");
				break;
			}
			case AMod.Tab.Potions:
			{
				Globals.PotionID = GUI.HorizontalSlider(new Rect(15f, 90f, 300f, 20f), Globals.PotionID, 2303f, 2309f);
				int num3 = (int)System.Math.Round((double)Globals.PotionID);
				Globals.PotionName = TextManager.GetBlockTypeName((World.BlockType)num3);
				GUI.Label(new Rect(125f, 70f, 2E+12f, 33f), string.Format("[{0}]  " + Globals.PotionName, num3));
				bool flag103 = !Globals.PotionCrafter;
				if (flag103)
				{
					bool flag104 = GUI.Button(new Rect(125f, 110f, 130f, 25f), "Auto-Cauldron OFF");
					if (flag104)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.PotionCrafter = true;
					}
				}
				else
				{
					bool flag105 = GUI.Button(new Rect(125f, 110f, 130f, 25f), "Auto-Cauldron ON");
					if (flag105)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.PotionCrafter = false;
					}
				}
				bool flag106 = GUI.Button(new Rect(125f, 145f, 130f, 25f), "Skip CraftTime");
				if (flag106)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Vector2i currentPlayerMapPoint5 = Globals.Player.currentPlayerMapPoint;
					WorldItemBase worldItemData2 = Globals.world.GetWorldItemData(Globals.CurrentMapPoint);
					BSONObject asBSON2 = worldItemData2.GetAsBSON();
					asBSON2["craftingStartTimeInTicks"] = 0L;
					worldItemData2.SetViaBSON(asBSON2);
				}
				break;
			}
			case AMod.Tab.Extra:
			{
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "Select items in your inventory to AutoDrop!");
				bool flag107 = !Globals.Dropper;
				if (flag107)
				{
					bool flag108 = GUI.Button(new Rect(15f, 85f, 150f, 25f), "AutoDropper OFF");
					if (flag108)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Dropper = true;
					}
				}
				else
				{
					bool flag109 = GUI.Button(new Rect(15f, 85f, 150f, 25f), "AutoDropper ON");
					if (flag109)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Dropper = false;
					}
				}
				GUI.Label(new Rect(15f, 125f, 10000f, 10000f), "Select items in your inventory to AutoTrash!");
				bool flag110 = !Globals.Trasher;
				if (flag110)
				{
					bool flag111 = GUI.Button(new Rect(15f, 155f, 150f, 25f), "AutoTrasher OFF");
					if (flag111)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Trasher = true;
					}
				}
				else
				{
					bool flag112 = GUI.Button(new Rect(15f, 155f, 150f, 25f), "AutoTrasher ON");
					if (flag112)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Trasher = false;
					}
				}
				bool flag113 = !Globals.Disencht;
				if (flag113)
				{
					bool flag114 = GUI.Button(new Rect(15f, 185f, 150f, 25f), "Disenchanter OFF");
					if (flag114)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Disencht = true;
					}
				}
				else
				{
					bool flag115 = GUI.Button(new Rect(15f, 185f, 150f, 25f), "Disenchanter ON");
					if (flag115)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Disencht = false;
					}
				}
				Globals.captureCard = GUI.Toggle(new Rect(15f, 225f, 90f, 25f), Globals.captureCard, "Capture Card");
				break;
			}
			case AMod.Tab.Botting:
			{
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "Botting \r\n Manual Botting, use alt");
				GUI.Label(new Rect(15f, 85f, 100f, 100f), "Username");
				Globals.AccountName = GUI.TextArea(new Rect(15f, 115f, 100f, 20f), Globals.AccountName);
				GUI.Label(new Rect(15f, 145f, 100f, 100f), "Password");
				Globals.AccountPassy = GUI.TextArea(new Rect(15f, 175f, 100f, 20f), Globals.AccountPassy);
				bool flag116 = GUI.Button(new Rect(15f, 205f, 90f, 30f), "Login");
				if (flag116)
				{
					UserIdent.LoginWithUsernameAndPassword(Globals.AccountName, Globals.AccountPassy, false);
					SceneLoader.ReloadGame();
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.AccountName = "";
					Globals.AccountPassy = "";
				}
				GUI.Label(new Rect(15f, 255f, 10000f, 10000f), "Current Account: " + StaticPlayer.theRealPlayername);
				bool flag117 = GUI.Button(new Rect(15f, 285f, 120f, 25f), "SpamBot");
				if (flag117)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.SpamBotting;
				}
				break;
			}
			case AMod.Tab.SpamBotting:
			{
				GUI.Label(new Rect(15f, 65f, 10000f, 10000f), "Write text to spam");
				Globals.SpamTextOfChoice = GUI.TextArea(new Rect(15f, 95f, 150f, 180f), Globals.SpamTextOfChoice);
				bool flag118 = !Globals.SpamTexter;
				if (flag118)
				{
					bool flag119 = GUI.Button(new Rect(15f, 295f, 160f, 25f), "Message Spammer OFF");
					if (flag119)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.SpamTexter = true;
					}
				}
				else
				{
					bool flag120 = GUI.Button(new Rect(15f, 295f, 160f, 25f), "Message Spammer ON");
					if (flag120)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.SpamTexter = false;
					}
				}
				Globals.JoinRandomWorlds = GUI.Toggle(new Rect(15f, 325f, 130f, 25f), Globals.JoinRandomWorlds, "Join random worlds");
				Globals.TeamSwitcher = GUI.Toggle(new Rect(15f, 355f, 120f, 25f), Globals.TeamSwitcher, "Skin Blink");
				Globals.EmoteSpam = GUI.Toggle(new Rect(145f, 325f, 90f, 25f), Globals.EmoteSpam, "Spam Emote");
				Globals.FriendReqSpam = GUI.Toggle(new Rect(115f, 355f, 150f, 25f), Globals.FriendReqSpam, "Friend Req Spam");
				Globals.TradeSpam = GUI.Toggle(new Rect(175f, 295f, 100f, 25f), Globals.TradeSpam, "SpamTrade");
				bool flag121 = !Globals.MannequinSpam;
				if (flag121)
				{
					bool flag122 = GUI.Button(new Rect(220f, 250f, 150f, 25f), "Mannequin Spam OFF");
					if (flag122)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.MannequinSpam = true;
					}
				}
				else
				{
					bool flag123 = GUI.Button(new Rect(220f, 250f, 150f, 25f), "Mannequin Spam ON");
					if (flag123)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.MannequinSpam = false;
					}
				}
				bool flag124 = GUI.Button(new Rect(255f, 55f, 120f, 25f), "Settings");
				if (flag124)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.SpamBottingSettings;
				}
				break;
			}
			case AMod.Tab.SpamBottingSettings:
			{
				Globals.SendMsgTime = GUI.HorizontalSlider(new Rect(15f, 145f, 100f, 20f), Globals.SendMsgTime, 5f, 15f);
				int num4 = (int)System.Math.Round((double)Globals.SendMsgTime);
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "How fast should your bot \r\n Spam Messages?");
				GUI.Label(new Rect(15f, 115f, 2E+12f, 33f), "Every " + string.Format("[{0}]   Seconds", num4));
				GUI.Label(new Rect(15f, 165f, 10000f, 10000f), "We reccommend using it at 3-4 seconds \r\n to prevent disconnects.");
				Globals.WorldTime = GUI.HorizontalSlider(new Rect(15f, 310f, 100f, 20f), Globals.WorldTime, 10f, 30f);
				int num5 = (int)System.Math.Round((double)Globals.WorldTime);
				GUI.Label(new Rect(15f, 230f, 10000f, 10000f), "How fast should your bot \r\n Join/Leave Worlds?");
				GUI.Label(new Rect(15f, 280f, 2E+12f, 33f), "Every " + string.Format("[{0}]   Seconds", num5));
				bool flag125 = GUI.Button(new Rect(255f, 55f, 90f, 25f), "Back?");
				if (flag125)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.SpamBotting;
				}
				break;
			}
			case AMod.Tab.Settings:
			{
				GUI.Label(new Rect(10f, 55f, 10000f, 10000f), "Mod Detector & Logging:");
				Globals.LeaveOnDetect = GUI.Toggle(new Rect(10f, 85f, 150f, 25f), Globals.LeaveOnDetect, "Leave on Detect");
				Globals.HardDetect = GUI.Toggle(new Rect(10f, 115f, 150f, 25f), Globals.HardDetect, "Hard-Detect");
				Globals.LogAllPlayers = GUI.Toggle(new Rect(10f, 145f, 150f, 25f), Globals.LogAllPlayers, "Log All Players (lag)");
				bool flag126 = GUI.Button(new Rect(190f, 85f, 145f, 25f), "Lookup Mod/Admin ID");
				if (flag126)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.IDLookup;
				}
				bool flag127 = !Globals.viewNotes;
				if (flag127)
				{
					bool flag128 = GUI.Button(new Rect(15f, 175f, 150f, 25f), "My Notepad OFF");
					if (flag128)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.viewNotes = true;
					}
				}
				else
				{
					bool flag129 = GUI.Button(new Rect(15f, 175f, 150f, 25f), "My Notepad ON");
					if (flag129)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.viewNotes = false;
					}
				}
				bool flag130 = GUI.Button(new Rect(15f, 205f, 180f, 25f), "Experimental");
				if (flag130)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Experi;
				}
				break;
			}
			case AMod.Tab.PrivateServers:
			{
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "Private Server Tools");
				GUI.Label(new Rect(15f, 75f, 1000f, 1000f), "Block Type");
				Globals.InventoryKeyBT = GUI.TextArea(new Rect(15f, 95f, 100f, 20f), Globals.InventoryKeyBT);
				GUI.Label(new Rect(15f, 125f, 1000f, 1000f), "Inventory Type");
				Globals.InventoryKeyIT = GUI.TextArea(new Rect(15f, 155f, 100f, 20f), Globals.InventoryKeyIT);
				bool flag131 = GUI.Button(new Rect(15f, 185f, 150f, 25f), "Purchase Custom Item");
				if (flag131)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Vector2i currentPlayerMapPoint6 = Globals.Player.currentPlayerMapPoint;
					OutgoingMessages.SendBuyOutAuctionHouseItem(currentPlayerMapPoint6, new PlayerData.InventoryKey
					{
						blockType = (World.BlockType)int.Parse(Globals.InventoryKeyBT),
						itemType = (PlayerData.InventoryItemType)int.Parse(Globals.InventoryKeyIT)
					}, 1L);
				}
				bool flag132 = !Globals.PWEBuyerAuto;
				if (flag132)
				{
					bool flag133 = GUI.Button(new Rect(15f, 215f, 185f, 25f), "Auto-Buy Custom Item OFF");
					if (flag133)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.PWEBuyerAuto = true;
					}
				}
				else
				{
					bool flag134 = GUI.Button(new Rect(15f, 215f, 185f, 25f), "Auto-Buy Custom Item ON");
					if (flag134)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.PWEBuyerAuto = false;
					}
				}
				bool flag135 = !Globals.CustomItemDrop;
				if (flag135)
				{
					bool flag136 = GUI.Button(new Rect(15f, 245f, 185f, 25f), "Custom Item Dropper OFF");
					if (flag136)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomItemDrop = true;
						Globals.AntiCollect = true;
					}
				}
				else
				{
					bool flag137 = GUI.Button(new Rect(15f, 245f, 185f, 25f), "Custom Item Dropper ON");
					if (flag137)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomItemDrop = false;
						Globals.AntiCollect = false;
					}
				}
				bool flag138 = !Globals.RandomCDrop;
				if (flag138)
				{
					bool flag139 = GUI.Button(new Rect(15f, 275f, 185f, 25f), "Random Item Dropper OFF");
					if (flag139)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.RandomCDrop = true;
						Globals.AntiCollect = true;
					}
				}
				else
				{
					bool flag140 = GUI.Button(new Rect(15f, 275f, 185f, 25f), "Random Item Dropper ON");
					if (flag140)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.RandomCDrop = false;
						Globals.AntiCollect = false;
					}
				}
				bool flag141 = !Globals.Nuker;
				if (flag141)
				{
					bool flag142 = GUI.Button(new Rect(15f, 305f, 150f, 25f), "World Nuker OFF");
					if (flag142)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Nuker = true;
						Globals.AntiCollect = true;
					}
				}
				else
				{
					bool flag143 = GUI.Button(new Rect(15f, 305f, 150f, 25f), "World Nuker ON");
					if (flag143)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Nuker = false;
						Globals.AntiCollect = false;
					}
				}
				bool flag144 = !Globals.CustomSeeder;
				if (flag144)
				{
					bool flag145 = GUI.Button(new Rect(15f, 345f, 150f, 25f), "Seeder OFF");
					if (flag145)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomSeeder = true;
					}
				}
				else
				{
					bool flag146 = GUI.Button(new Rect(15f, 345f, 150f, 25f), "Seeder ON");
					if (flag146)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.CustomSeeder = false;
					}
				}
				bool flag147 = !Globals.Wearer;
				if (flag147)
				{
					bool flag148 = GUI.Button(new Rect(205f, 345f, 150f, 25f), "Wearer OFF");
					if (flag148)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Wearer = true;
					}
				}
				else
				{
					bool flag149 = GUI.Button(new Rect(205f, 345f, 150f, 25f), "Wearer ON");
					if (flag149)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Wearer = false;
					}
				}
				bool flag150 = !Globals.ForcePlace;
				if (flag150)
				{
					bool flag151 = GUI.Button(new Rect(205f, 305f, 150f, 25f), "ForcePlace OFF");
					if (flag151)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.ForcePlace = true;
					}
				}
				else
				{
					bool flag152 = GUI.Button(new Rect(205f, 305f, 150f, 25f), "ForcePlace ON");
					if (flag152)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					}
					Globals.ForcePlace = false;
				}
				bool flag153 = !Globals.Bbreak;
				if (flag153)
				{
					bool flag154 = GUI.Button(new Rect(215f, 265f, 150f, 25f), "BBreak OFF");
					if (flag154)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Bbreak = true;
					}
				}
				else
				{
					bool flag155 = GUI.Button(new Rect(215f, 265f, 150f, 25f), "BBreak ON");
					if (flag155)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.Bbreak = false;
					}
				}
				Globals.BFValue = GUI.TextArea(new Rect(215f, 185f, 90f, 25f), Globals.BFValue);
				bool flag156 = !Globals.BFarmer;
				if (flag156)
				{
					bool flag157 = GUI.Button(new Rect(215f, 225f, 150f, 25f), "BFarmer OFF");
					if (flag157)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.BFarmer = true;
					}
				}
				else
				{
					bool flag158 = GUI.Button(new Rect(215f, 225f, 150f, 25f), "BFarmer ON");
					if (flag158)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.BFarmer = false;
					}
				}
				break;
			}
			case AMod.Tab.Csign:
				Globals.SignText12 = GUI.TextArea(new Rect(15f, 55f, 300f, 300f), Globals.SignText12);
				break;
			case AMod.Tab.SpamSettingsPacket:
			{
				GUI.Label(new Rect(10f, 55f, 2E+12f, 33f), "Packet Spam Speed: every " + string.Format("[{0}] seconds.", Globals.PTimerP2));
				Globals.PTimerP2 = GUI.HorizontalSlider(new Rect(10f, 85f, 100f, 20f), Globals.PTimerP2, 0.1f, 10f);
				GUI.Label(new Rect(10f, 105f, 10000f, 10000f), "Custom SpamTimer:");
				Globals.PTimerP3 = GUI.TextArea(new Rect(10f, 130f, 100f, 20f), Globals.PTimerP3);
				bool flag159 = GUI.Button(new Rect(10f, 160f, 105f, 20f), "Set SpamTime");
				if (flag159)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.PTimerP2 = float.Parse(Globals.PTimerP3);
				}
				bool flag160 = GUI.Button(new Rect(10f, 190f, 120f, 20f), "Reset SpamTime");
				if (flag160)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.PTimerP2 = 1f;
				}
				GUI.Label(new Rect(10f, 220f, 10000f, 10000f), "Recommended Time: 0.5 - 1");
				Globals.PSpamP = GUI.Toggle(new Rect(10f, 255f, 120f, 25f), Globals.PSpamP, "Spam Packet");
				break;
			}
			case AMod.Tab.AutoBuy:
			{
				bool flag161 = !Globals.AutoBuy1;
				if (flag161)
				{
					bool flag162 = GUI.Button(new Rect(15f, 55f, 130f, 25f), "AUTOBUY OFF");
					if (flag162)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AutoBuy1 = true;
						InfoPopupUI.SetupInfoPopup("AutoBuyer ENABLED!", "Buy an item from gem shop to start!");
						InfoPopupUI.ForceShowMenu();
					}
				}
				else
				{
					bool flag163 = GUI.Button(new Rect(15f, 55f, 130f, 25f), "AUTOBUY ON");
					if (flag163)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AutoBuy1 = false;
						InfoPopupUI.SetupInfoPopup("AutoBuyer DISABLED!", "");
						InfoPopupUI.ForceShowMenu();
					}
				}
				GUI.Label(new Rect(155f, 55f, 10000f, 10000f), "Current: " + Globals.IPID1);
				GUI.Label(new Rect(10f, 85f, 2E+12f, 33f), "Speed: every " + string.Format("[{0}] seconds.", Globals.AutoBuyCT));
				Globals.AutoBuyCT = GUI.HorizontalSlider(new Rect(10f, 115f, 100f, 20f), Globals.AutoBuyCT, 0.01f, 5f);
				Globals.AutoBuyCT2 = GUI.TextArea(new Rect(10f, 165f, 70f, 20f), Globals.AutoBuyCT2);
				bool flag164 = GUI.Button(new Rect(15f, 195f, 100f, 20f), "Set Speed");
				if (flag164)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.AutoBuyCT = float.Parse(Globals.AutoBuyCT2);
				}
				bool flag165 = GUI.Button(new Rect(15f, 215f, 100f, 25f), "Reset All");
				if (flag165)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					Globals.AutoBuyCT = 1f;
					Globals.AutoBuy1 = false;
					Globals.IPID1 = "";
				}
				break;
			}
			case AMod.Tab.IDLookup:
			{
				GUI.Label(new Rect(15f, 55f, 10000f, 10000f), "Write ID:");
				Globals.IDLookup1 = GUI.TextArea(new Rect(15f, 85f, 125f, 25f), Globals.IDLookup1);
				bool flag166 = GUI.Button(new Rect(15f, 115f, 100f, 25f), "Get name");
				if (flag166)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					bool flag167 = Globals.PWStaff.ContainsKey(Globals.IDLookup1);
					if (flag167)
					{
						Globals.GNameID = Globals.PWStaff[Globals.IDLookup1];
					}
					bool flag168 = !Globals.PWStaff.ContainsKey(Globals.IDLookup1);
					if (flag168)
					{
						Globals.GNameID = "Mod / Admin does not match with ID!";
					}
				}
				GUI.Label(new Rect(15f, 140f, 10000f, 10000f), Globals.GNameID);
				break;
			}
			case AMod.Tab.Experi:
			{
				bool flag169 = GUI.Button(new Rect(15f, 55f, 110f, 25f), "Send Sign?");
				if (flag169)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					WorldItemBase worldItemData3 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					BSONObject asBSON3 = worldItemData3.GetAsBSON();
					BSONObject bsonobject = new BSONObject();
					bsonobject["ID"] = "WIU";
					bsonobject["WiB"] = asBSON3;
					bsonobject["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject["y"] = Globals.Player.currentPlayerMapPoint.y;
					asBSON3["text"] = Globals.SignText12;
					bsonobject["PT"] = 1;
					asBSON3["PT"] = 1;
					Globals.world.WorldItemUpdate(bsonobject);
					OutgoingMessages.SendWorldItemUpdateMessage(Globals.Player.currentPlayerMapPoint, worldItemData3, ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint)));
				}
				bool flag170 = GUI.Button(new Rect(15f, 85f, 110f, 25f), "Send Portal?");
				if (flag170)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					WorldItemBase worldItemData4 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					BSONObject asBSON4 = worldItemData4.GetAsBSON();
					BSONObject bsonobject2 = new BSONObject();
					bsonobject2["ID"] = "WIU";
					bsonobject2["WiB"] = asBSON4;
					bsonobject2["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject2["y"] = Globals.Player.currentPlayerMapPoint.y;
					asBSON4["name"] = Globals.SignText12;
					bsonobject2["PT"] = 1;
					asBSON4["PT"] = 1;
					Globals.world.WorldItemUpdate(bsonobject2);
					OutgoingMessages.SendWorldItemUpdateMessage(Globals.Player.currentPlayerMapPoint, worldItemData4, ConfigData.GetToolUsableForBlock(Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint)));
				}
				bool flag171 = GUI.Button(new Rect(15f, 115f, 110f, 25f), "C-Sign");
				if (flag171)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.Csign;
				}
				break;
			}
			case AMod.Tab.DExtra:
			{
				bool flag172 = !Globals.BytesBuyer2;
				if (flag172)
				{
					bool flag173 = GUI.Button(new Rect(15f, 125f, 130f, 25f), "ByteBuyer OFF");
					if (flag173)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.BytesBuyer2 = true;
					}
				}
				else
				{
					bool flag174 = GUI.Button(new Rect(15f, 125f, 130f, 25f), "ByteBuyer ON");
					if (flag174)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.BytesBuyer2 = false;
					}
				}
				Globals.Speed = GUI.HorizontalSlider(new Rect(15f, 85f, 100f, 20f), Globals.Speed, 1f, 5f);
				int num6 = (int)System.Math.Round((double)Globals.Speed);
				GUI.Label(new Rect(15f, 55f, 2E+12f, 33f), "ByteSpeed: " + string.Format("[{0}] times every Frame.", num6));
				bool flag175 = !Globals.GemmerOG;
				if (flag175)
				{
					bool flag176 = GUI.Button(new Rect(15f, 155f, 130f, 25f), "OG-Gem OFF");
					if (flag176)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemmerOG = true;
						Globals.GemGemGem = false;
					}
				}
				else
				{
					bool flag177 = GUI.Button(new Rect(15f, 155f, 130f, 25f), "OG-Gem ON");
					if (flag177)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemmerOG = false;
					}
				}
				bool flag178 = !Globals.GemGemGem;
				if (flag178)
				{
					bool flag179 = GUI.Button(new Rect(165f, 155f, 130f, 25f), "FastGem OFF");
					if (flag179)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemGemGem = true;
					}
				}
				else
				{
					bool flag180 = GUI.Button(new Rect(165f, 155f, 130f, 25f), "FastGem ON");
					if (flag180)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.GemGemGem = false;
					}
				}
				bool flag181 = !Globals.ByteGemmer;
				if (flag181)
				{
					bool flag182 = GUI.Button(new Rect(15f, 255f, 130f, 25f), "ByteGemmer OFF");
					if (flag182)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.ByteGemmer = true;
					}
				}
				else
				{
					bool flag183 = GUI.Button(new Rect(15f, 255f, 130f, 25f), "ByteGemmer ON");
					if (flag183)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.ByteGemmer = false;
					}
				}
				bool flag184 = GUI.Button(new Rect(15f, 315f, 130f, 25f), "More");
				if (flag184)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					this.tab = AMod.Tab.CashExtra;
				}
				Globals.IRef = GUI.Toggle(new Rect(15f, 185f, 130f, 20f), Globals.IRef, "Inventory Refresher");
				Globals.autoVIP = GUI.Toggle(new Rect(165f, 185f, 90f, 20f), Globals.autoVIP, "Auto-VIP");
				Globals.autoVIP2 = GUI.Toggle(new Rect(165f, 225f, 90f, 20f), Globals.autoVIP2, "Auto-VIP 2");
				bool flag185 = GUI.Button(new Rect(165f, 255f, 90f, 25f), "AutoVIP Info");
				if (flag185)
				{
					Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
					BluePopupUI.SetPopupValue(PopupMode.JustClose, "", "How to use", "AutoVIP 1 - Stand on a duped Mining Token seed, and enable AutoVIP.<br <br AutoVIP 2 - Stand on a duped JetRace token seed, and enable AutoVIP.<br <br Yes, they both spam the Mining Wheel and JetRace Wheel packets.<br Huge credit to JED5729", "Continue", "", null, null, 0f, 0, false, false, false);
					ControllerHelper.rootUI.OnOrOffMenu(Il2CppType.Of<BluePopupUI>());
				}
				bool flag186 = GUI.Button(new Rect(15f, 225f, 90f, 25f), "Back?");
				if (flag186)
				{
					this.tab = AMod.Tab.Main;
				}
				break;
			}
			case AMod.Tab.CashExtra:
			{
				bool flag187 = !Globals.AutoVendor;
				if (flag187)
				{
					bool flag188 = GUI.Button(new Rect(15f, 55f, 130f, 25f), "AutoVendor OFF");
					if (flag188)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AutoVendor = true;
					}
				}
				else
				{
					bool flag189 = GUI.Button(new Rect(15f, 55f, 130f, 25f), "AutoVendor ON");
					if (flag189)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.AutoVendor = false;
					}
				}
				Globals.EndAmtVend2 = GUI.HorizontalSlider(new Rect(15f, 125f, 300f, 20f), Globals.EndAmtVend2, 100f, 999f);
				int num7 = (int)System.Math.Round((double)Globals.EndAmtVend2);
				GUI.Label(new Rect(15f, 90f, 2E+12f, 33f), string.Format("AutoVendor will stop at  {0}  amount of the item.", num7));
				Globals.GetOpen = GUI.Toggle(new Rect(15f, 155f, 130f, 25f), Globals.GetOpen, "Get Auto-Open ID");
				bool flag190 = !Globals.autoOPENER;
				if (flag190)
				{
					bool flag191 = GUI.Button(new Rect(15f, 185f, 130f, 25f), "Auto-Opener OFF");
					if (flag191)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.autoOPENER = true;
					}
				}
				else
				{
					bool flag192 = GUI.Button(new Rect(15f, 185f, 130f, 25f), "Auto-Opener ON");
					if (flag192)
					{
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.ButtonClick, 0f, -1);
						Globals.autoOPENER = false;
						InfoPopupUI.SetupInfoPopup("Auto-Opener OFF!", "Disabled manually by user. \r\n InventoryKey has been reset.");
						Globals.AOINVK = 0;
						InfoPopupUI.ForceShowMenu();
					}
				}
				break;
			}
			}
			GUI.DragWindow();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00011E20 File Offset: 0x00010020
		private void DrawMenu2(int id)
		{
			AMod.Tab2 tab = this.tab2;
			AMod.Tab2 tab2 = tab;
			if (tab2 != AMod.Tab2.Writing)
			{
				if (tab2 == AMod.Tab2.Saving)
				{
					bool flag = GUI.Button(new Rect(15f, 55f, 120f, 25f), "Save Notes");
					if (flag)
					{
						FileStream fileStream = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\" + Globals.SaveAs + ".json", FileMode.Create);
						fileStream.Close();
						File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\" + Globals.SaveAs + ".json", Globals.Notes);
					}
					bool flag2 = GUI.Button(new Rect(15f, 85f, 120f, 25f), "Load Notes");
					if (flag2)
					{
						string path = System.AppDomain.CurrentDomain.BaseDirectory + "AMod Official\\" + Globals.SaveAs + ".json";
						Globals.Notes = File.ReadAllText(path);
					}
					GUI.Label(new Rect(135f, 55f, 10000f, 10000f), "Write the name to save/load file as:");
					Globals.SaveAs = GUI.TextArea(new Rect(135f, 85f, 150f, 25f), Globals.SaveAs);
					bool flag3 = GUI.Button(new Rect(15f, 115f, 90f, 25f), "Back?");
					if (flag3)
					{
						this.tab2 = AMod.Tab2.Writing;
					}
				}
			}
			else
			{
				Globals.Notes = GUI.TextArea(new Rect(15f, 35f, 365f, 320f), Globals.Notes);
				bool flag4 = GUI.Button(new Rect(15f, 350f, 120f, 25f), "Options");
				if (flag4)
				{
					this.tab2 = AMod.Tab2.Saving;
				}
				bool flag5 = GUI.Button(new Rect(135f, 350f, 120f, 25f), "Close Notes");
				if (flag5)
				{
					AMod.showNotes = false;
					Globals.viewNotes = false;
				}
			}
			GUI.DragWindow();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00012039 File Offset: 0x00010239
		private void DrawMenu3(int id)
		{
			GUI.DragWindow();
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00012044 File Offset: 0x00010244
		public override void OnGUI()
		{
			GUIStyle guistyle = new GUIStyle();
			guistyle.normal.textColor = Color.yellow;
			guistyle.fontStyle = FontStyle.Bold;
			bool flag = AMod.showGUI;
			if (flag)
			{
				this.WindowSize = GUI.Window(2008, this.WindowSize, new System.Action<int>(this.DrawMenu), "<color=yellow>AMod v2.1</color>");
			}
			bool flag2 = AMod.showNotes;
			if (flag2)
			{
				this.WindowSize2 = GUI.Window(1515, this.WindowSize2, new System.Action<int>(this.DrawMenu2), "My Notes");
			}
		}

		// Token: 0x04000108 RID: 264
		public Rect WindowSize = new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 400f, 400f);

		// Token: 0x04000109 RID: 265
		public Rect WindowSize2 = new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 400f, 400f);

		// Token: 0x0400010A RID: 266
		private System.Random random = new System.Random();

		// Token: 0x0400010B RID: 267
		private static bool showGUI = true;

		// Token: 0x0400010C RID: 268
		private static bool showNotes = false;

		// Token: 0x0400010D RID: 269
		private static bool showPacketsGUI = false;

		// Token: 0x0400010E RID: 270
		private static bool showCaptureGUI = false;

		// Token: 0x0400010F RID: 271
		private float TeamSwitcherTimer = 0f;

		// Token: 0x04000110 RID: 272
		private float SpikeBomberTimer = 0f;

		// Token: 0x04000111 RID: 273
		private float PotionCrafterTimer = 0f;

		// Token: 0x04000112 RID: 274
		private float InvisibleHackTimer = 0f;

		// Token: 0x04000113 RID: 275
		private float WLPlacerTimer = 0f;

		// Token: 0x04000114 RID: 276
		private float WLPlacerAboveTimer = 0f;

		// Token: 0x04000115 RID: 277
		private float WLPlacerBelowTimer = 0f;

		// Token: 0x04000116 RID: 278
		private float WLPlacerLeftTimer = 0f;

		// Token: 0x04000117 RID: 279
		private float WLPlacerRightTimer = 0f;

		// Token: 0x04000118 RID: 280
		private float JetSpammerTimer = 0f;

		// Token: 0x04000119 RID: 281
		private float LizoTimer = 0f;

		// Token: 0x0400011A RID: 282
		private float GemPouchTimer = 0f;

		// Token: 0x0400011B RID: 283
		private float CardPackTimer = 0f;

		// Token: 0x0400011C RID: 284
		public float ticks = 0f;

		// Token: 0x0400011D RID: 285
		public string VisualPlayerName = "Airbronze";

		// Token: 0x0400011E RID: 286
		private float AnimationTimer = 0f;

		// Token: 0x0400011F RID: 287
		private float GambleTimer = 0f;

		// Token: 0x04000120 RID: 288
		private float RecyclerTimer = 0f;

		// Token: 0x04000121 RID: 289
		private float PWEBuyerTImer = 0f;

		// Token: 0x04000122 RID: 290
		private float DropTimer = 0f;

		// Token: 0x04000123 RID: 291
		private float RandomItemPicker = 0f;

		// Token: 0x04000124 RID: 292
		private float NukeTimer = 0f;

		// Token: 0x04000125 RID: 293
		private float FPTimer = 0f;

		// Token: 0x04000126 RID: 294
		private float DropTrashTimer = 0f;

		// Token: 0x04000127 RID: 295
		private float SpamBotTimer = 0f;

		// Token: 0x04000128 RID: 296
		private float JoinRandomWorlds = 0f;

		// Token: 0x04000129 RID: 297
		private float EmoteTimer = 0f;

		// Token: 0x0400012A RID: 298
		private float ReqTimer = 0f;

		// Token: 0x0400012B RID: 299
		private float FriendReqTimer = 0f;

		// Token: 0x0400012C RID: 300
		private float MSwapTimer = 0f;

		// Token: 0x0400012D RID: 301
		private float CollectTimer = 0f;

		// Token: 0x0400012E RID: 302
		private float SeedTimer = 0f;

		// Token: 0x0400012F RID: 303
		private float WearTimer = 0f;

		// Token: 0x04000130 RID: 304
		private float ForcePlace = 0f;

		// Token: 0x04000131 RID: 305
		private float BedrockBreaker = 0f;

		// Token: 0x04000132 RID: 306
		private float BFarmerTime = 0f;

		// Token: 0x04000133 RID: 307
		private float SelectRandom = 0f;

		// Token: 0x04000134 RID: 308
		private float Temporary = 0f;

		// Token: 0x04000135 RID: 309
		private float Gemmer22 = 0f;

		// Token: 0x04000136 RID: 310
		private float BBT = 0f;

		// Token: 0x04000137 RID: 311
		private int integer = 0;

		// Token: 0x04000138 RID: 312
		private float iTTT = 0f;

		// Token: 0x04000139 RID: 313
		private float TPTrsh = 0f;

		// Token: 0x0400013A RID: 314
		private float GMTimer = 0f;

		// Token: 0x0400013B RID: 315
		private float PTimerP = 0f;

		// Token: 0x0400013C RID: 316
		private float AutoBuyTimer = 0f;

		// Token: 0x0400013D RID: 317
		private float ItemIDChecker = 0f;

		// Token: 0x0400013E RID: 318
		private float removeTime = 0f;

		// Token: 0x0400013F RID: 319
		private float Encime = 0f;

		// Token: 0x04000140 RID: 320
		private float VIPTIME = 0f;

		// Token: 0x04000141 RID: 321
		private float ChT = 0f;

		// Token: 0x04000142 RID: 322
		private float cnvT = 0f;

		// Token: 0x04000143 RID: 323
		private float vendTime = 0f;

		// Token: 0x04000144 RID: 324
		public AMod.Tab tab = AMod.Tab.Main;

		// Token: 0x04000145 RID: 325
		public AMod.Tab2 tab2 = AMod.Tab2.Writing;

		// Token: 0x02000061 RID: 97
		public enum Tab
		{
			// Token: 0x0400024A RID: 586
			Main,
			// Token: 0x0400024B RID: 587
			Data,
			// Token: 0x0400024C RID: 588
			PacketExtra,
			// Token: 0x0400024D RID: 589
			Troll,
			// Token: 0x0400024E RID: 590
			Misc,
			// Token: 0x0400024F RID: 591
			Accounts,
			// Token: 0x04000250 RID: 592
			Utils,
			// Token: 0x04000251 RID: 593
			PatchNotes,
			// Token: 0x04000252 RID: 594
			ClothesBugger,
			// Token: 0x04000253 RID: 595
			Music,
			// Token: 0x04000254 RID: 596
			WLPlacing,
			// Token: 0x04000255 RID: 597
			GemPouch,
			// Token: 0x04000256 RID: 598
			SavedAccs,
			// Token: 0x04000257 RID: 599
			Potions,
			// Token: 0x04000258 RID: 600
			Extra,
			// Token: 0x04000259 RID: 601
			Botting,
			// Token: 0x0400025A RID: 602
			SpamBotting,
			// Token: 0x0400025B RID: 603
			SpamBottingSettings,
			// Token: 0x0400025C RID: 604
			Settings,
			// Token: 0x0400025D RID: 605
			Auto,
			// Token: 0x0400025E RID: 606
			PrivateServers,
			// Token: 0x0400025F RID: 607
			Temp,
			// Token: 0x04000260 RID: 608
			Portal,
			// Token: 0x04000261 RID: 609
			Csign,
			// Token: 0x04000262 RID: 610
			GMer9000,
			// Token: 0x04000263 RID: 611
			SpamSettingsPacket,
			// Token: 0x04000264 RID: 612
			AutoBuy,
			// Token: 0x04000265 RID: 613
			IDLookup,
			// Token: 0x04000266 RID: 614
			Experi,
			// Token: 0x04000267 RID: 615
			DExtra,
			// Token: 0x04000268 RID: 616
			Main2,
			// Token: 0x04000269 RID: 617
			Textures,
			// Token: 0x0400026A RID: 618
			SimplePack,
			// Token: 0x0400026B RID: 619
			RecolorPack,
			// Token: 0x0400026C RID: 620
			CitemPack,
			// Token: 0x0400026D RID: 621
			AllApplied,
			// Token: 0x0400026E RID: 622
			Memeified,
			// Token: 0x0400026F RID: 623
			TTTHack,
			// Token: 0x04000270 RID: 624
			TTTHack2,
			// Token: 0x04000271 RID: 625
			CashExtra
		}

		// Token: 0x02000062 RID: 98
		public enum Tab2
		{
			// Token: 0x04000273 RID: 627
			Writing,
			// Token: 0x04000274 RID: 628
			Saving
		}
	}
}
