using System;
using System.IO;
using System.Windows.Forms;
using HarmonyLib;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppKernys.Bson;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;

namespace AMod
{
	// Token: 0x02000052 RID: 82
	internal class ChatCommands
	{
		// Token: 0x04000148 RID: 328
		public static World world;

		// Token: 0x04000149 RID: 329
		private static int totalgems;

		// Token: 0x02000063 RID: 99
		[HarmonyPatch(typeof(ChatUI), "Submit")]
		private static class CUI_SUBMIT
		{
			// Token: 0x060002AA RID: 682 RVA: 0x00015294 File Offset: 0x00013494
			private static bool Prefix(ref string text)
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				bool flag = array[0] == "/credits";
				if (flag)
				{
					ChatUI.SendMinigameMessage("-----<BR AMod v2.1<BR Creator: Airbronze<BR -----");
					ChatUI.SendLogMessage("-----<BR Huge Thanks to Jepe, Nekto, JED5729, Kelasponssaa , Zeppelin, Krak, Shiuki<BR <3<BR <BR Press Tab to show/hide GUI, type /help or /ahelp to view list of commands.<BR Join our Discord Server: https://discord.gg/aKTa85hrwG<BR -----");
				}
				bool flag2 = array[0] == "/help";
				if (flag2)
				{
					ChatUI.SendMinigameMessage("AMOD v2.1<BR Credits to Jepe, Nekto, JED5729, Kelasponssaa , Zeppelin, Krak, Shiuki<BR ==========<BR How To Use:<BR /command Arguements..<BR To view command info type /command ?<BR ==========<BR AMod Commands List<BR ==========<BR /credits, /help, /ahelp, /keys, /love, /pet1, /pet2, /sleep, /wake. /quit, /pwe, /support, /gbt, /rsc, /ait, /rit, /uait, /urit, /sbt, /cdata, /ref, /aref, /drop, /dall, /d1, /dupe, /cdupe, /poblock, /piblock, /iclear, /oclear, /eject<BR ==========");
				}
				bool flag3 = array[0] == "/ahelp";
				if (flag3)
				{
					ChatUI.SendMinigameMessage("AMOD v2.1<BR Credits to Jepe, Nekto, JED5729, Kelasponssaa , Zeppelin, Krak, Shiuki<BR ==========<BR How To Use:<BR /command Arguements..<BR To view command info type /command ?<BR ==========<BR AMod Commands List<BR ==========<BR /credits, /help, /ahelp, /keys, /love, /pet1, /pet2, /sleep, /wake. /quit, /pwe, /support, /gbt, /rsc, /ait, /rit, /uait, /urit, /sbt, /cdata, /ref, /aref, /drop, /dall, /d1, /dupe, /cdupe, /poblock, /piblock, /iclear, /oclear, /eject<BR ==========");
				}
				bool flag4 = array[0] == "/keys";
				if (flag4)
				{
					ChatUI.SendMinigameMessage("=====<BR AMOD HOTKEYS<BR =====<BR GUI On/Off [Tab]<BR Invis Hack [ ALT + 1 ]<BR JetSpammer [ALT + 2]<BR =====");
				}
				bool flag5 = array[0] == "/love";
				if (flag5)
				{
					OutgoingMessages.SendPetPetMessage(3);
				}
				bool flag6 = array[0] == "/pet1";
				if (flag6)
				{
					OutgoingMessages.SendPetCleanMessage(3);
				}
				bool flag7 = array[0] == "/pet2";
				if (flag7)
				{
					OutgoingMessages.SendPetTrainMessage(3, AIPetTrainingType.None);
				}
				bool flag8 = array[0] == "/sleep";
				if (flag8)
				{
					ConfigData.playerChangeToSleepSeconds = 0;
				}
				bool flag9 = array[0] == "/wake";
				if (flag9)
				{
					ConfigData.playerChangeToSleepSeconds = 120;
				}
				bool flag10 = array[0] == "/quit";
				if (flag10)
				{
					UnityEngine.Application.Quit();
				}
				bool flag11 = array[0] == "/pwe";
				if (flag11)
				{
					Vector2i currentPlayerMapPoint = Globals.Player.currentPlayerMapPoint;
					Globals.WorldController.SetBlock(World.BlockType.PWETerminal, currentPlayerMapPoint.x, currentPlayerMapPoint.y);
					Globals.world.SetBlock(World.BlockType.PWETerminal, currentPlayerMapPoint.x, currentPlayerMapPoint.y, "", "", false);
				}
				bool flag12 = array[0] == "/support";
				if (flag12)
				{
					SceneLoader.CheckIfWeCanGoFromWorldToWorld("GIFTBRONZE", "", null, false, null);
				}
				bool flag13 = array[0] == "/gbt";
				if (flag13)
				{
					PlayerData.InventoryKey currentSelection = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					InfoPopupUI.SetupInfoPopup("BlockType ID Copied!", "BlockType ID: " + currentSelection.blockType.ToString());
					InfoPopupUI.ForceShowMenu();
					string text2 = currentSelection.blockType.ToString();
					Clipboard.SetText(text2);
				}
				bool flag14 = array[0] == "/rsc";
				if (flag14)
				{
					Clipboard.Clear();
				}
				bool flag15 = array[0] == "/ait";
				if (flag15)
				{
					int num = 0;
					num++;
					PlayerData.InventoryKey currentSelection2 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					World.BlockType blockType = Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint);
					WorldItemBase worldItemData = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					bool flag16 = worldItemData != null && ConfigData.IsBlockStorage(blockType);
					BSONObject asBSON = worldItemData.GetAsBSON();
					List<int> int32ListValue = asBSON["storageItemsAsInventoryKeys"].int32ListValue;
					List<int> int32ListValue2 = asBSON["storageItemsAmounts"].int32ListValue;
					int item = PlayerData.InventoryKey.InventoryKeyToInt(currentSelection2);
					int item2 = 1;
					int32ListValue.Add(item);
					int32ListValue2.Add(item2);
					asBSON["storageItemsAsInventoryKeys"] = int32ListValue;
					asBSON["storageItemsAmounts"] = int32ListValue2;
					asBSON["blockType"] = (int)blockType;
					asBSON["class"] = blockType.ToString() + "Data";
					BSONObject bsonobject = new BSONObject();
					bsonobject["ID"] = "ASI";
					bsonobject["WiB"] = asBSON;
					bsonobject["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject["y"] = Globals.Player.currentPlayerMapPoint.y;
					bsonobject["PT"] = 1;
					OutgoingMessages.AddOneMessageToList(bsonobject);
					Globals.PlayerData.RemoveItemFromInventory(currentSelection2);
					ChatUtils.D("Success");
				}
				bool flag17 = array[0] == "/rit";
				if (flag17)
				{
					int num2 = 0;
					num2++;
					PlayerData.InventoryKey currentSelection3 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					World.BlockType blockType2 = Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint);
					WorldItemBase worldItemData2 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					bool flag18 = worldItemData2 != null && ConfigData.IsBlockStorage(blockType2);
					BSONObject asBSON2 = worldItemData2.GetAsBSON();
					List<int> int32ListValue3 = asBSON2["storageItemsAsInventoryKeys"].int32ListValue;
					List<int> int32ListValue4 = asBSON2["storageItemsAmounts"].int32ListValue;
					int32ListValue3.Clear();
					int32ListValue4.Clear();
					asBSON2["storageItemsAsInventoryKeys"] = int32ListValue3;
					asBSON2["storageItemsAmounts"] = int32ListValue4;
					asBSON2["blockType"] = (int)blockType2;
					asBSON2["class"] = blockType2.ToString() + "Data";
					BSONObject bsonobject2 = new BSONObject();
					bsonobject2["ID"] = "ASI";
					bsonobject2["WiB"] = asBSON2;
					bsonobject2["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject2["y"] = Globals.Player.currentPlayerMapPoint.y;
					bsonobject2["PT"] = 1;
					OutgoingMessages.AddOneMessageToList(bsonobject2);
					BSONObject bsonobject3 = new BSONObject();
					bsonobject3["ID"] = "AGI";
					bsonobject3["PT"] = 0;
					OutgoingMessages.AddOneMessageToList(bsonobject3);
					ChatUtils.D("Success");
				}
				bool flag19 = array[0] == "/uait";
				if (flag19)
				{
					int num3 = 0;
					num3++;
					PlayerData.InventoryKey currentSelection4 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					World.BlockType blockType3 = Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint);
					WorldItemBase worldItemData3 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					bool flag20 = worldItemData3 != null && ConfigData.IsBlockStorage(blockType3);
					BSONObject asBSON3 = worldItemData3.GetAsBSON();
					List<int> int32ListValue5 = asBSON3["storageItemsAsInventoryKeys"].int32ListValue;
					List<int> int32ListValue6 = asBSON3["storageItemsAmounts"].int32ListValue;
					int item3 = PlayerData.InventoryKey.InventoryKeyToInt(currentSelection4);
					int item4 = 1;
					int32ListValue5.Add(item3);
					int32ListValue6.Add(item4);
					asBSON3["storageItemsAsInventoryKeys"] = int32ListValue5;
					asBSON3["storageItemsAmounts"] = int32ListValue6;
					asBSON3["blockType"] = 2270;
					asBSON3["class"] = blockType3.ToString() + "Data";
					BSONObject bsonobject4 = new BSONObject();
					bsonobject4["ID"] = "ASI";
					bsonobject4["WiB"] = asBSON3;
					bsonobject4["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject4["y"] = Globals.Player.currentPlayerMapPoint.y;
					bsonobject4["PT"] = 1;
					OutgoingMessages.AddOneMessageToList(bsonobject4);
					Globals.PlayerData.RemoveItemFromInventory(currentSelection4);
					ChatUtils.D("Success");
				}
				bool flag21 = array[0] == "/urit";
				if (flag21)
				{
					int num4 = 0;
					num4++;
					PlayerData.InventoryKey currentSelection5 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					World.BlockType blockType4 = Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint);
					WorldItemBase worldItemData4 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
					bool flag22 = worldItemData4 != null && ConfigData.IsBlockStorage(blockType4);
					BSONObject asBSON4 = worldItemData4.GetAsBSON();
					List<int> int32ListValue7 = asBSON4["storageItemsAsInventoryKeys"].int32ListValue;
					List<int> int32ListValue8 = asBSON4["storageItemsAmounts"].int32ListValue;
					int32ListValue7.Clear();
					int32ListValue8.Clear();
					asBSON4["storageItemsAsInventoryKeys"] = int32ListValue7;
					asBSON4["storageItemsAmounts"] = int32ListValue8;
					asBSON4["blockType"] = 2270;
					asBSON4["class"] = blockType4.ToString() + "Data";
					BSONObject bsonobject5 = new BSONObject();
					bsonobject5["ID"] = "ASI";
					bsonobject5["WiB"] = asBSON4;
					bsonobject5["x"] = Globals.Player.currentPlayerMapPoint.x;
					bsonobject5["y"] = Globals.Player.currentPlayerMapPoint.y;
					bsonobject5["PT"] = 1;
					OutgoingMessages.AddOneMessageToList(bsonobject5);
					BSONObject bsonobject6 = new BSONObject();
					bsonobject6["ID"] = "AGI";
					bsonobject6["PT"] = 0;
					OutgoingMessages.AddOneMessageToList(bsonobject6);
					ChatUtils.D("Success");
				}
				bool flag23 = array[0] == "/sbt";
				if (flag23)
				{
					bool flag24 = Globals.Player != null && Globals.Player != null;
					bool flag25 = flag24;
					if (flag25)
					{
						World.BlockType blockType5 = Globals.world.GetBlockType(Globals.Player.currentPlayerMapPoint);
						WorldItemBase worldItemData5 = Globals.world.GetWorldItemData(Globals.Player.currentPlayerMapPoint);
						bool flag26 = worldItemData5 != null && ConfigData.IsBlockStorage(blockType5);
						bool flag27 = flag26;
						if (flag27)
						{
							BSONObject asBSON5 = worldItemData5.GetAsBSON();
							bool flag28 = asBSON5["inventoryDatas"]["DatasCount"].int32Value > 0;
							bool flag29 = flag28;
							if (flag29)
							{
								List<int> int32ListValue9 = asBSON5["storageItemsAsInventoryKeys"].int32ListValue;
								List<int> int32ListValue10 = asBSON5["storageItemsAmounts"].int32ListValue;
								PlayerData.InventoryKey inventoryKey = PlayerData.InventoryKey.IntToInventoryKey(int32ListValue9[0]);
								short num5 = (short)int32ListValue10[0];
								bool flag30 = num5 < 2;
								bool flag31 = flag30;
								if (flag31)
								{
									bool flag32 = Globals.PlayerData.GetCount(inventoryKey) > 0;
									bool flag33 = !flag32;
									if (flag33)
									{
										ChatUtils.Error("You dont have " + TextManager.GetBlockTypeOrSeedName(inventoryKey) + "!");
									}
									int32ListValue10[0] = 2;
									Globals.PlayerData.RemoveItemFromInventory(inventoryKey);
								}
								else
								{
									int32ListValue10[0] = 1;
									Globals.PlayerData.AddItemToInventory(inventoryKey, null);
								}
								asBSON5["storageItemsAmounts"] = int32ListValue10;
								asBSON5["blockType"] = (int)((asBSON5["blockType"].int32Value == 2270) ? blockType5 : World.BlockType.StorageForUntradeables);
								asBSON5["class"] = blockType5.ToString() + "Data";
								BSONObject bsonobject7 = new BSONObject();
								bsonobject7["ID"] = "ASI";
								bsonobject7["WiB"] = asBSON5;
								bsonobject7["x"] = Globals.Player.currentPlayerMapPoint.x;
								bsonobject7["y"] = Globals.Player.currentPlayerMapPoint.y;
								bsonobject7["PT"] = 1;
								OutgoingMessages.AddOneMessageToList(bsonobject7);
								BSONObject bsonobject8 = new BSONObject();
								bsonobject8["ID"] = "AGI";
								bsonobject8["PT"] = 0;
								OutgoingMessages.AddOneMessageToList(bsonobject8);
								ChatUtils.D("Success");
							}
							else
							{
								ChatUtils.Error("Put an item inside the chest.");
							}
						}
						else
						{
							ChatUtils.Error("Not a chest!");
						}
					}
				}
				bool flag34 = array[0] == "/cdata";
				if (flag34)
				{
					BSONObject asBSON6 = Globals.PlayerData.GetInventoryData(Globals.gameplayUI.inventoryControl.GetCurrentSelection()).GetAsBSON();
					bool flag35 = asBSON6 != null;
					if (flag35)
					{
						ChatUtils.D("Copied item data to clipboard!");
						Clipboard.SetText(Utils.DumpBSON(asBSON6));
					}
					else
					{
						ChatUtils.Error("Item does not contain data!");
					}
				}
				bool flag36 = array[0] == "/ref";
				if (flag36)
				{
					BSONObject bsonobject9 = new BSONObject();
					bsonobject9["ID"] = "AGI";
					bsonobject9["PT"] = 0;
					OutgoingMessages.AddOneMessageToList(bsonobject9);
				}
				bool flag37 = array[0] == "/aref";
				if (flag37)
				{
					Globals.IRef = !Globals.IRef;
					bool iref = Globals.IRef;
					if (iref)
					{
						ChatUI.SendMinigameMessage("Auto Inventory-Refresh enabled!");
					}
					else
					{
						ChatUI.SendMinigameMessage("Auto Inventory-Refreshed disabled!");
					}
				}
				bool flag38 = array[0] == "/drop";
				if (flag38)
				{
					PlayerData.InventoryKey currentSelection6 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					Vector2i nextPlayerPositionBasedOnLookDirection = Globals.Player.GetNextPlayerPositionBasedOnLookDirection(0);
					BSONObject bsonobject10 = new BSONObject();
					bsonobject10["ID"] = "Di";
					bsonobject10["x"] = nextPlayerPositionBasedOnLookDirection.x;
					bsonobject10["y"] = nextPlayerPositionBasedOnLookDirection.y;
					BSONValue bsonvalue = bsonobject10;
					string key = "dI";
					BSONObject bsonobject11 = new BSONObject();
					bsonobject11["CollectableID"] = 0;
					bsonobject11["BlockType"] = (int)currentSelection6.blockType;
					bsonobject11["Amount"] = int.Parse(array[1]);
					bsonobject11["InventoryType"] = (int)currentSelection6.itemType;
					bsonobject11["PosX"] = 0;
					bsonobject11["PosY"] = 0;
					bsonobject11["IsGem"] = false;
					bsonobject11["GemType"] = 0;
					bsonvalue[key] = bsonobject11;
					BSONObject bsonobject12 = bsonobject10;
					InventoryItemBase inventoryData = Globals.PlayerData.GetInventoryData(currentSelection6);
					bool flag39 = inventoryData != null;
					bool flag40 = flag39;
					if (flag40)
					{
						bsonobject12["dI"]["InventoryDataKey"] = inventoryData.GetAsBSON();
					}
					OutgoingMessages.AddOneMessageToList(bsonobject12);
				}
				bool flag41 = array[0] == "/debugparse";
				if (flag41)
				{
					int num6 = 0;
					try
					{
						string path = Directory.GetCurrentDirectory() + "\\AMod Official\\Parse.txt";
						string text3 = "#LEGEND: ID|InventoryItemType|Health|Tier|Name|IsTradeable|CanBeBehindWater|RecallAllowed|HotSpots|Complexity|HasCollider|DropGemsMin|DropGemsMax|XpAfterDestroy\n";
						Array values = Enum.GetValues(typeof(World.BlockType));
						int num7;
						for (int i = 0; i < values.Length - 1; i = num7 + 1)
						{
							World.BlockType blockType6 = World.BlockType.None;
							blockType6 = (World.BlockType)i;
							text3 += string.Format("{0}|", i);
							text3 += string.Format("{0}|", ConfigData.GetBlockTypeInventoryItemType((World.BlockType)i));
							text3 += string.Format("{0}|", ConfigData.GetHitsRequired(blockType6));
							bool flag42 = ConfigData.blockTiers[blockType6] == "n/a";
							bool flag43 = flag42;
							if (flag43)
							{
								text3 += "0|";
							}
							else
							{
								text3 = text3 + ConfigData.blockTiers[(World.BlockType)i] + "|";
							}
							text3 = text3 + TextManager.GetBlockTypeName(blockType6) + "|";
							text3 = text3 + (ConfigData.IsBlockUntradeable(blockType6) ? "0" : "1") + "|";
							text3 = text3 + (ConfigData.CanBlockBeBehindWater(blockType6) ? "1" : "0") + "|";
							text3 = text3 + (ConfigData.IsBlockRecallItem(blockType6) ? "1" : "0") + "|";
							Il2CppStructArray<AnimationHotSpots> animationHotSpots = ControllerHelper.genericStorage.GetAnimationHotSpots(blockType6);
							bool flag44 = animationHotSpots.Count < 1;
							bool flag45 = flag44;
							if (flag45)
							{
								text3 += "0|";
							}
							else
							{
								foreach (AnimationHotSpots animationHotSpots2 in animationHotSpots)
								{
									string str = text3;
									num7 = (int)animationHotSpots2;
									text3 = str + num7.ToString() + ",";
								}
								text3 = text3.Remove(text3.Length - 1) + "|";
							}
							text3 = text3 + ConfigData.GetBlockComplexity(blockType6).ToString() + "|";
							text3 = text3 + (ConfigData.DoesBlockHaveCollider(blockType6) ? "1" : "0") + "|";
							bool flag46 = (short)ConfigData.GetBlockGemDropAverage(blockType6) >= 10 && (short)ConfigData.GetBlockGemDropAverage(blockType6) == ConfigData.GetBlockDropGemRangeMin(blockType6) && ConfigData.GetBlockDropGemRangeMin(blockType6) <= 20;
							bool flag47 = flag46;
							if (flag47)
							{
								text3 += "0|";
								text3 = text3 + ((int)(ConfigData.GetBlockDropGemRangeMax(blockType6) / 10)).ToString() + "|";
							}
							else
							{
								text3 = text3 + ConfigData.GetBlockDropGemRangeMin(blockType6).ToString() + "|";
								text3 = text3 + ConfigData.GetBlockDropGemRangeMax(blockType6).ToString() + "|";
							}
							text3 = text3 + ConfigData.GetDestroyBlockExperience(blockType6).ToString() + "|";
							bool flag48 = ConfigData.ShouldSkipDoesPlayerHaveRightToModifyItemData(blockType6);
							bool flag49 = flag48;
							if (flag49)
							{
								Console.WriteLine(string.Format("case BlockType.{0}:", blockType6));
							}
							text3 += "\n";
							num6 = i;
							num7 = i;
						}
						File.WriteAllText(path, text3);
						ChatUtils.D("Success.");
					}
					catch (Exception ex)
					{
						MelonLogger.Error(ex.ToString());
						MelonLogger.Msg("Last Index was " + num6.ToString());
					}
				}
				bool flag50 = array[0] == "/dall";
				if (flag50)
				{
					PlayerData.InventoryKey currentSelection7 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					bool flag51 = currentSelection7.blockType > World.BlockType.None;
					bool flag52 = flag51;
					if (flag52)
					{
						Vector2i nextPlayerPositionBasedOnLookDirection2 = Globals.Player.GetNextPlayerPositionBasedOnLookDirection(0);
						BSONObject bsonobject13 = new BSONObject();
						bsonobject13["ID"] = "Di";
						bsonobject13["x"] = nextPlayerPositionBasedOnLookDirection2.x;
						bsonobject13["y"] = nextPlayerPositionBasedOnLookDirection2.y;
						BSONValue bsonvalue2 = bsonobject13;
						string key2 = "dI";
						BSONObject bsonobject14 = new BSONObject();
						bsonobject14["CollectableID"] = 0;
						bsonobject14["BlockType"] = (int)currentSelection7.blockType;
						bsonobject14["Amount"] = (int)Globals.PlayerData.GetCount(currentSelection7);
						bsonobject14["InventoryType"] = (int)currentSelection7.itemType;
						bsonobject14["PosX"] = 0;
						bsonobject14["PosY"] = 0;
						bsonobject14["IsGem"] = false;
						bsonobject14["GemType"] = 0;
						bsonvalue2[key2] = bsonobject14;
						BSONObject bsonobject15 = bsonobject13;
						InventoryItemBase inventoryData2 = Globals.PlayerData.GetInventoryData(currentSelection7);
						bool flag53 = inventoryData2 != null;
						bool flag54 = flag53;
						if (flag54)
						{
							bsonobject15["dI"]["InventoryDataKey"] = inventoryData2.GetAsBSON();
						}
						OutgoingMessages.AddOneMessageToList(bsonobject15);
					}
				}
				bool flag55 = array[0] == "/d1";
				if (flag55)
				{
					PlayerData.InventoryKey currentSelection8 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					bool flag56 = currentSelection8.blockType > World.BlockType.None;
					bool flag57 = flag56;
					if (flag57)
					{
						Vector2i nextPlayerPositionBasedOnLookDirection3 = Globals.Player.GetNextPlayerPositionBasedOnLookDirection(0);
						BSONObject bsonobject16 = new BSONObject();
						bsonobject16["ID"] = "Di";
						bsonobject16["x"] = nextPlayerPositionBasedOnLookDirection3.x;
						bsonobject16["y"] = nextPlayerPositionBasedOnLookDirection3.y;
						BSONValue bsonvalue3 = bsonobject16;
						string key3 = "dI";
						BSONObject bsonobject17 = new BSONObject();
						bsonobject17["CollectableID"] = 0;
						bsonobject17["BlockType"] = (int)currentSelection8.blockType;
						bsonobject17["Amount"] = 1;
						bsonobject17["InventoryType"] = (int)currentSelection8.itemType;
						bsonobject17["PosX"] = 0;
						bsonobject17["PosY"] = 0;
						bsonobject17["IsGem"] = false;
						bsonobject17["GemType"] = 0;
						bsonvalue3[key3] = bsonobject17;
						BSONObject bsonobject18 = bsonobject16;
						InventoryItemBase inventoryData3 = Globals.PlayerData.GetInventoryData(currentSelection8);
						bool flag58 = inventoryData3 != null;
						bool flag59 = flag58;
						if (flag59)
						{
							bsonobject18["dI"]["InventoryDataKey"] = inventoryData3.GetAsBSON();
						}
						OutgoingMessages.AddOneMessageToList(bsonobject18);
					}
				}
				bool flag60 = array[0] == "/dupe";
				if (flag60)
				{
					PlayerData.InventoryKey currentSelection9 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					ChatUI.SendMinigameMessage("Duping Selected Item: " + currentSelection9.blockType.ToString());
					bool flag61 = currentSelection9.blockType > World.BlockType.None;
					bool flag62 = flag61;
					if (flag62)
					{
						Vector2i nextPlayerPositionBasedOnLookDirection4 = Globals.Player.GetNextPlayerPositionBasedOnLookDirection(0);
						BSONObject bsonobject19 = new BSONObject();
						bsonobject19["ID"] = "Di";
						bsonobject19["x"] = nextPlayerPositionBasedOnLookDirection4.x;
						bsonobject19["y"] = nextPlayerPositionBasedOnLookDirection4.y;
						BSONValue bsonvalue4 = bsonobject19;
						string key4 = "dI";
						BSONObject bsonobject20 = new BSONObject();
						bsonobject20["CollectableID"] = 0;
						bsonobject20["BlockType"] = PlayerData.InventoryKey.InventoryKeyToInt(currentSelection9);
						bsonobject20["Amount"] = (int)Globals.PlayerData.GetCount(currentSelection9);
						bsonobject20["InventoryType"] = 2;
						bsonobject20["PosX"] = 0;
						bsonobject20["PosY"] = 0;
						bsonobject20["IsGem"] = false;
						bsonobject20["GemType"] = 0;
						bsonvalue4[key4] = bsonobject20;
						BSONObject bsonobject21 = bsonobject19;
						InventoryItemBase inventoryData4 = Globals.PlayerData.GetInventoryData(currentSelection9);
						bool flag63 = inventoryData4 != null;
						bool flag64 = flag63;
						if (flag64)
						{
							bsonobject21["dI"]["InventoryDataKey"] = inventoryData4.GetAsBSON();
						}
						InfoPopupUI.SetupInfoPopup("Dupe has been initialized!", "Pick up the dropped seed and type command /ref \r\n Dupe was Discovered by Jepe \r\n  Made by discord.gg/amod");
						ChatUtils.Msg("Pick up the dropped seed and type command /ref \r\n Dupe was Discovered by Jepe \r\n  Made by discord.gg/amod");
						InfoPopupUI.ForceShowMenu();
						OutgoingMessages.AddOneMessageToList(bsonobject21);
						BSONObject bsonobject22 = new BSONObject();
						bsonobject22["ID"] = "AGI";
						bsonobject22["PT"] = 0;
						OutgoingMessages.AddOneMessageToList(bsonobject22);
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.SpiritAppear, 0f, -1);
					}
				}
				bool flag65 = array[0] == "/cdupe";
				if (flag65)
				{
					PlayerData.InventoryKey currentSelection10 = Globals.gameplayUI.inventoryControl.GetCurrentSelection();
					ChatUI.SendMinigameMessage("Duping Selected Item: " + currentSelection10.blockType.ToString());
					bool flag66 = currentSelection10.blockType > World.BlockType.None;
					bool flag67 = flag66;
					if (flag67)
					{
						Vector2i nextPlayerPositionBasedOnLookDirection5 = Globals.Player.GetNextPlayerPositionBasedOnLookDirection(0);
						BSONObject bsonobject23 = new BSONObject();
						bsonobject23["ID"] = "Di";
						bsonobject23["x"] = nextPlayerPositionBasedOnLookDirection5.x;
						bsonobject23["y"] = nextPlayerPositionBasedOnLookDirection5.y;
						BSONValue bsonvalue5 = bsonobject23;
						string key5 = "dI";
						BSONObject bsonobject24 = new BSONObject();
						bsonobject24["CollectableID"] = 0;
						bsonobject24["BlockType"] = PlayerData.InventoryKey.InventoryKeyToInt(currentSelection10);
						bsonobject24["Amount"] = int.Parse(array[1]);
						bsonobject24["InventoryType"] = 2;
						bsonobject24["PosX"] = 0;
						bsonobject24["PosY"] = 0;
						bsonobject24["IsGem"] = false;
						bsonobject24["GemType"] = 0;
						bsonvalue5[key5] = bsonobject24;
						BSONObject bsonobject25 = bsonobject23;
						InventoryItemBase inventoryData5 = Globals.PlayerData.GetInventoryData(currentSelection10);
						bool flag68 = inventoryData5 != null;
						bool flag69 = flag68;
						if (flag69)
						{
							bsonobject25["dI"]["InventoryDataKey"] = inventoryData5.GetAsBSON();
						}
						InfoPopupUI.SetupInfoPopup("Dupe has been initialized!", "Pick up the dropped seed and type command /ref \r\n Dupe was Discovered by Jepe \r\n  Made by discord.gg/amod");
						ChatUtils.Msg("Pick up the dropped seed and type command /ref \r\n Dupe was Discovered by Jepe \r\n  Made by discord.gg/amod");
						InfoPopupUI.ForceShowMenu();
						OutgoingMessages.AddOneMessageToList(bsonobject25);
						BSONObject bsonobject26 = new BSONObject();
						bsonobject26["ID"] = "AGI";
						bsonobject26["PT"] = 0;
						OutgoingMessages.AddOneMessageToList(bsonobject26);
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.SpiritAppear, 0f, -1);
					}
				}
				bool flag70 = array[0] == "/poblock";
				if (flag70)
				{
					Globals.OutgoingBlock.Add(array[1]);
					string str2 = "";
					foreach (string str3 in Globals.OutgoingBlock)
					{
						str2 = str2 + str3 + ", ";
					}
				}
				bool flag71 = array[0] == "/piblock";
				if (flag71)
				{
					Globals.IncomingBlock.Add(array[1]);
					string text4 = "";
					foreach (string str4 in Globals.IncomingBlock)
					{
						text4 = text4 + str4 + ", ";
					}
					ChatUI.SendMinigameMessage("Ignoring these packets: " + text4);
				}
				bool flag72 = array[0] == "/iclear";
				if (flag72)
				{
					Globals.IncomingBlock.Clear();
					string text5 = "";
					foreach (string str5 in Globals.IncomingBlock)
					{
						text5 = text5 + str5 + ", ";
					}
					ChatUI.SendMinigameMessage("Outgoing Ignores cleared! " + text5);
				}
				bool flag73 = array[0] == "/oclear";
				if (flag73)
				{
					Globals.OutgoingBlock.Clear();
					string text6 = "";
					foreach (string str6 in Globals.OutgoingBlock)
					{
						text6 = text6 + str6 + ", ";
					}
					ChatUI.SendMinigameMessage("Outgoing Ignores cleared! " + text6);
				}
				bool flag74 = array[0] == "/eject";
				if (flag74)
				{
					MelonBase.FindMelon("AMod", "Airbronze").Unregister("Ejected by user (you).", false);
					ChatUI.SendMinigameMessage("Successfully ejected AMod from the game session. If you'd like to re-add it, restart your game.");
				}
				bool flag75 = array[0] == "/info";
				if (flag75)
				{
					bool flag76 = Globals.Commands.ContainsKey(array[1].ToLower());
					if (flag76)
					{
						string key6 = array[1].ToLower();
						ChatUtils.Msg(Globals.Commands[key6]);
					}
					else
					{
						ChatUtils.Error("Please specify a correct command!");
					}
				}
				return !text.StartsWith('/'.ToString());
			}
		}
	}
}
