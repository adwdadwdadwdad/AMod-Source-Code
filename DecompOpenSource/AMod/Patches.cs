using System;
using System.Data;
using HarmonyLib;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppKernys.Bson;
using MelonLoader;
using UnityEngine;

namespace AMod
{
	// Token: 0x02000056 RID: 86
	public class Patches
	{
		// Token: 0x02000065 RID: 101
		[HarmonyPatch(typeof(ConfigData), "CanPlayerPickCollectableFromBlock")]
		private static class AntiCollect
		{
			// Token: 0x060002AE RID: 686 RVA: 0x00017DE8 File Offset: 0x00015FE8
			private static bool Prefix()
			{
				return !Globals.AntiCollect;
			}
		}

		// Token: 0x02000066 RID: 102
		[HarmonyPatch(typeof(ConfigData), "IsBlockHot")]
		private static class AntiBounce
		{
			// Token: 0x060002AF RID: 687 RVA: 0x00017E04 File Offset: 0x00016004
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x02000067 RID: 103
		[HarmonyPatch(typeof(Player), "ShouldBelowBlockDoBounce")]
		private static class AntiBounce2
		{
			// Token: 0x060002B0 RID: 688 RVA: 0x00017E20 File Offset: 0x00016020
			private static bool Prefix()
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x02000068 RID: 104
		[HarmonyPatch(typeof(ConfigData), "IsBlockPinball")]
		private static class AntiBounce3
		{
			// Token: 0x060002B1 RID: 689 RVA: 0x00017E3C File Offset: 0x0001603C
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x02000069 RID: 105
		[HarmonyPatch(typeof(ConfigData), "IsBlockSpring")]
		private static class AntiBounce4
		{
			// Token: 0x060002B2 RID: 690 RVA: 0x00017E58 File Offset: 0x00016058
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x0200006A RID: 106
		[HarmonyPatch(typeof(ConfigData), "IsBlockTrampolin")]
		private static class AntiBounce5
		{
			// Token: 0x060002B3 RID: 691 RVA: 0x00017E74 File Offset: 0x00016074
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x0200006B RID: 107
		[HarmonyPatch(typeof(ConfigData), "IsBlockElastic")]
		private static class AntiBounce6
		{
			// Token: 0x060002B4 RID: 692 RVA: 0x00017E90 File Offset: 0x00016090
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x0200006C RID: 108
		[HarmonyPatch(typeof(ConfigData), "IsBlockWind")]
		private static class AntiBounce7
		{
			// Token: 0x060002B5 RID: 693 RVA: 0x00017EAC File Offset: 0x000160AC
			private static bool Prefix(World.BlockType blockType)
			{
				return !Globals.AntiBounce;
			}
		}

		// Token: 0x0200006D RID: 109
		[HarmonyPatch(typeof(WorldController), "BlockColliderAndLayerHelper")]
		private static class WC_BCALH
		{
			// Token: 0x060002B6 RID: 694 RVA: 0x00017EC8 File Offset: 0x000160C8
			private static void Prefix(ref World.BlockType blockType, GameObject blockGameObject, Vector2i mapPoint)
			{
				bool flag = ConfigData.IsBlockInstakill(blockType) && Globals.AntiBounce;
				if (flag)
				{
					blockType = World.BlockType.SoilBlock;
				}
			}
		}

		// Token: 0x0200006E RID: 110
		[HarmonyPatch(typeof(Player), "IsPlayerInMapPoint")]
		private static class BlockKill
		{
			// Token: 0x060002B7 RID: 695 RVA: 0x00017EF0 File Offset: 0x000160F0
			private static bool Prefix()
			{
				bool blockKill = Globals.BlockKill;
				bool flag = blockKill;
				return !flag && !Globals.BlockKill;
			}
		}

		// Token: 0x0200006F RID: 111
		[HarmonyPatch(typeof(ConfigData), "IsBlockPortal")]
		private static class AntiVortex
		{
			// Token: 0x060002B8 RID: 696 RVA: 0x00017F1C File Offset: 0x0001611C
			private static bool Prefix()
			{
				bool antiVortex = Globals.AntiVortex;
				bool flag = antiVortex;
				if (flag)
				{
					ConfigData.vortexPortalActivateDistance = 0f;
				}
				else
				{
					ConfigData.vortexPortalActivateDistance = 0.14f;
				}
				return !Globals.AntiVortex;
			}
		}

		// Token: 0x02000070 RID: 112
		[HarmonyPatch(typeof(ConfigData), "ShowLoungeWorldInMainMenu")]
		internal static class LoungeByNekto
		{
			// Token: 0x060002B9 RID: 697 RVA: 0x00017F60 File Offset: 0x00016160
			private static bool Prefix(ref bool __result, TextManager.LanguageSelection languageSelection)
			{
				bool custompack = Globals.Custompack;
				if (custompack)
				{
					__result = true;
				}
				else
				{
					__result = false;
				}
				return false;
			}
		}

		// Token: 0x02000071 RID: 113
		[HarmonyPatch(typeof(Player), "ActivatePortalInAnimation")]
		private static class JoinWorldFirstTime
		{
			// Token: 0x060002BA RID: 698 RVA: 0x00017F88 File Offset: 0x00016188
			private static void Prefix(World.BlockType blockType)
			{
				Globals.AnimationCount++;
				bool flag = Globals.AnimationCount == 1;
				if (flag)
				{
					ChatUI.SendMinigameMessage("-----<BR AMod 2.1<BR Creator: Airbronze<BR -----");
					ChatUI.SendLogMessage("-----<BR Huge Thanks to @ne.kto, @notkrak for pathfinder, @shiuki for pathfinder, @0jepe, @JED5729, @sexyzeppelin, <BR and the AMod Community <3<BR <BR Press Tab to show/hide GUI, type /help or /ahelp to view list of commands.<BR Join our Discord Server: https://discord.gg/amod<BR -----");
				}
			}
		}

		// Token: 0x02000072 RID: 114
		[HarmonyPatch(typeof(ChatUI), "NewMessage")]
		private static class Test1221121
		{
			// Token: 0x060002BB RID: 699 RVA: 0x00017FC8 File Offset: 0x000161C8
			private static bool Prefix(ref ChatMessage msg)
			{
				bool flag = msg == null || msg.message == null;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = msg.channelType == 1 || (msg.channelType == 2 && !msg.message.Contains("(" + msg.channel + ")") && msg.nick != StaticPlayer.theRealPlayername);
					if (flag2)
					{
						msg.message = msg.message + " [" + msg.channel + "] ";
						string text = Globals.IgnoreGMW.ToString();
						bool flag3 = msg.channel.Contains(text.ToLower());
						string text2 = "\u2029";
						string text3 = msg.message.ToLower();
						string text4 = "<br";
						bool flag4 = text3.Contains(text4.ToLower());
						if (flag4)
						{
							msg.message = msg.message.Replace("<br", "");
						}
						bool flag5 = text3.Contains(text2);
						if (flag5)
						{
							msg.message = msg.message.Replace(text2, "");
						}
						bool flag6 = text3.Contains("\r\n");
						if (flag6)
						{
							msg.message = msg.message.Replace("\r\n", " ");
						}
					}
					bool flag7 = msg.channelType == 1 && !msg.message.Contains("(" + msg.channel + ")") && msg.nick != StaticPlayer.theRealPlayername;
					if (flag7)
					{
						string text5 = Globals.IgnoreGMW.ToString();
						bool flag8 = msg.channel.Contains(text5.ToLower());
						bool muteGMs = Globals.MuteGMs;
						if (muteGMs)
						{
							msg.message = "";
							msg.nick = "";
							msg.message = null;
						}
						bool flag9 = Globals.GWarper && msg.message.Contains(Globals.LocateGM.ToLower()) && !flag8;
						if (flag9)
						{
							SceneLoader.CheckIfWeCanGoFromWorldToWorld(msg.channel, "", null, false, null);
							Globals.GWarper = false;
							Globals.LocateGM = "";
							InfoPopupUI.SetupInfoPopup("GM Found!", "Warping..");
							InfoPopupUI.ForceShowMenu();
							Globals.AudioManager.PlaySFX(AudioManager.SoundType.EasterEggAppear, 0f, -1);
						}
						string text6 = "\u2029";
						string text7 = msg.message.ToLower();
						string text8 = "<br";
						bool flag10 = text7.Contains(text8.ToLower());
						if (flag10)
						{
							msg.message = msg.message.Replace("<br", "");
						}
						bool flag11 = text7.Contains(text6);
						if (flag11)
						{
							msg.message = msg.message.Replace(text6, "");
						}
						bool flag12 = text7.Contains("\r\n");
						if (flag12)
						{
							msg.message = msg.message.Replace("\r\n", " ");
						}
					}
					result = true;
				}
				return result;
			}
		}

		// Token: 0x02000073 RID: 115
		[HarmonyPatch(typeof(NetworkClient), "HandleMessages")]
		public static class AutoMath
		{
			// Token: 0x060002BC RID: 700 RVA: 0x00018314 File Offset: 0x00016514
			public static void Prefix(ref BSONObject messages)
			{
				BSONObject bsonobject = messages;
				for (int i = 0; i < bsonobject["mc"]; i++)
				{
					BSONObject bsonobject2 = bsonobject["m" + i.ToString()].TryCast<BSONObject>();
					string[] array = new string[]
					{
						"mP",
						"ST",
						"BcsU",
						"GPd",
						"p"
					};
					foreach (string b in array)
					{
						bool flag = bsonobject2["ID"].stringValue == b;
						bool flag2 = flag;
						if (flag2)
						{
							return;
						}
					}
					try
					{
						BSONObject bsonobject3 = bsonobject2["CmB"].TryCast<BSONObject>();
						bool flag3 = bsonobject3["channelIndex"] == 1;
						if (flag3)
						{
							break;
						}
						bool flag4 = bsonobject3["channelIndex"] == 2;
						if (flag4)
						{
							try
							{
								string stringValue = bsonobject3["channel"].stringValue;
								MelonLogger.Msg("Sent From World: " + stringValue);
							}
							catch
							{
							}
						}
						Utils.ReadBSON(bsonobject3, "");
						string stringValue2 = bsonobject3["message"].stringValue;
						bool flag5 = bsonobject3["channelIndex"] == 2;
						if (flag5)
						{
							try
							{
								string stringValue3 = bsonobject3["channel"].stringValue;
								ChatUI.SendMinigameMessage("World: " + stringValue3 + " Message: " + stringValue2);
							}
							catch
							{
							}
						}
						string[] array3 = stringValue2.ToLower().Split(new char[]
						{
							' '
						}, StringSplitOptions.None);
						string text = array3[0];
						string[] array4 = new string[]
						{
							"1",
							"2",
							"3",
							"4",
							"5",
							"6",
							"7",
							"8",
							"9",
							"0"
						};
						bool autoMath = Globals.AutoMath;
						if (autoMath)
						{
							System.Random random = new System.Random();
							foreach (string value in array4)
							{
								bool flag6 = stringValue2.StartsWith(value);
								bool flag7 = flag6;
								if (flag7)
								{
									bool flag8 = stringValue2.Length > 2;
									bool flag9 = flag8;
									if (flag9)
									{
										string stringValue4 = bsonobject3["message"].stringValue;
										try
										{
											string text2 = stringValue4.Replace("x", "*").Replace("÷", "/").Replace("=", "").Replace(" ", "").Replace("✖", "*").Replace("×", "*");
											double num = Convert.ToDouble(new DataTable().Compute(text2, null));
											bool flag10 = num.ToString() == text2;
											bool flag11 = !flag10;
											if (flag11)
											{
												BSONObject bsonobject4 = new BSONObject();
												bsonobject4["ID"] = "WCM";
												bsonobject4["msg"] = "​" + num.ToString();
												BSONObject toAdd = bsonobject4;
												ChatUI.SendMinigameMessage(string.Format("Question: {0} Answer: {1}", text2, num));
												OutgoingMessages.AddOneMessageToList(toAdd);
												Globals.chatUI.Submit(num.ToString());
											}
										}
										catch
										{
										}
									}
								}
							}
						}
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x02000074 RID: 116
		[HarmonyPatch(typeof(NetworkClient), "HandleMessages")]
		private static class HandleMessagesIncoming
		{
			// Token: 0x060002BD RID: 701 RVA: 0x00018754 File Offset: 0x00016954
			private static bool Prefix(BSONObject messages)
			{
				bool result = true;
				for (int i = 0; i < messages["mc"].int32Value; i++)
				{
					BSONValue bsonvalue = messages["m" + i.ToString()];
					string stringValue = bsonvalue["ID"].stringValue;
					bool flag = Globals.IncomingBlock.Contains(stringValue);
					bool flag2 = flag;
					if (flag2)
					{
						result = false;
					}
					bool flag3 = Globals.ignoreFwk && stringValue == "Fwk";
					if (flag3)
					{
						result = false;
					}
					bool flag4 = stringValue == "TTjW" && Globals.JoinRandomWorlds;
					if (flag4)
					{
						SceneLoader.CheckIfWeCanGoFromWorldToWorld(bsonvalue["WN"].stringValue, "", null, false, null);
					}
					bool flag5 = Globals.cmIncoming && stringValue != "mP" && stringValue != "PSicU" && stringValue != "ST" && stringValue != "p";
					if (flag5)
					{
						Globals.CurrentCaptureINCOMING = Utils.DumpBSON(bsonvalue.Cast<BSONObject>());
						Console.WriteLine("\r\n \r\n" + Utils.DumpBSON(bsonvalue.Cast<BSONObject>()) + "\r\n \r\n");
					}
					bool flag6 = bsonvalue.ContainsKey("U");
					if (flag6)
					{
						bool flag7 = stringValue != "mP" && Globals.PWStaff.ContainsKey(bsonvalue["U"].stringValue);
						if (flag7)
						{
							Globals.DoCustomNotification("Mod / Admin Found with ID: [ " + bsonvalue["U"].stringValue + " ]  Username: " + Globals.PWStaff[bsonvalue["U"]], Globals.CurrentMapPoint);
							Globals.AudioManager.PlaySFX(AudioManager.SoundType.NetherBossWraithShieldAppear, 0f, -1);
							ChatUI.SendMinigameMessage("Mod / Admin found with ID  " + bsonvalue["U"].stringValue + "  Username:  " + Globals.PWStaff[bsonvalue["U"]]);
							ChatUI.SendMinigameMessage("Mod / Admin detected with Packet: " + bsonvalue["ID"].stringValue);
							MelonLogger.Msg(string.Concat(new string[]
							{
								"Mod / Admin ",
								Globals.PWStaff[bsonvalue["U"]],
								"(ID: ",
								bsonvalue["U"],
								") Detected with Packet: ",
								bsonvalue["ID"].stringValue
							}));
							bool leaveOnDetect = Globals.LeaveOnDetect;
							if (leaveOnDetect)
							{
								OutgoingMessages.LeaveWorld();
								MelonLogger.Msg(string.Concat(new string[]
								{
									"Mod / Admin Detected! \r\n ID: [ ",
									bsonvalue["U"].stringValue,
									" ] \r\n Username: ",
									Globals.PWStaff[bsonvalue["U"]],
									"\r\n Left world because you enabled LeaveOnDetect!"
								}));
							}
						}
					}
					bool flag8 = stringValue == "Recall";
					if (flag8)
					{
						bool flag9 = bsonvalue["RecallBT"].int32Value == 4367;
						if (flag9)
						{
							OutgoingMessages.SendWearableOrWeaponUndress(World.BlockType.MountFlyingBathtub);
							Globals.Player.UndressWearableOrWeaponRemote(World.BlockType.MountFlyingBathtub);
						}
					}
					bool flag10 = bsonvalue.ContainsKey("ID");
					if (flag10)
					{
						bool flag11 = Globals.CaptureIncomingID && stringValue != "mP" && stringValue != "PSicU";
						if (flag11)
						{
							Globals.CurrentCaptureINCOMING = "{ \r\n" + bsonvalue["ID"].stringValue + "\r\n }";
						}
					}
					bool flag12 = Globals.AutoBuy1 && stringValue == "BIPack";
					if (flag12)
					{
						Globals.IPID1 = bsonvalue["IPId"].stringValue;
						bool flag13 = bsonvalue.ContainsKey("ER");
						if (flag13)
						{
							string stringValue2 = bsonvalue["ER"].stringValue;
							MelonLogger.Msg("Error on AutoBuy:" + stringValue2);
							Globals.AutoBuy1 = false;
							Globals.IPID1 = "";
						}
					}
					bool flag14 = Globals.LogAllPlayers && stringValue != "mP" && bsonvalue.ContainsKey("U");
					if (flag14)
					{
						Globals.DoCustomNotification("Player action logged! \r\n Incoming Packet ID: " + bsonvalue["ID"], Globals.CurrentMapPoint);
						Globals.AudioManager.PlaySFX(AudioManager.SoundType.NetherBossWraithShieldAppear, 0f, -1);
						ChatUI.SendMinigameMessage(NetworkPlayers.GetNameWithId(bsonvalue["U"], false) + "'s action logged with Incoming Packet ID: " + bsonvalue["ID"]);
						MelonLogger.Msg(NetworkPlayers.GetNameWithId(bsonvalue["U"], false) + "'s action logged with Incoming Packet ID: " + bsonvalue["ID"]);
					}
					bool flag15 = Globals.HardDetect && bsonvalue.ContainsKey("U");
					if (flag15)
					{
						bool flag16 = Globals.PWStaff.ContainsKey(bsonvalue["U"].stringValue);
						if (flag16)
						{
							Globals.DoCustomNotification("Mod / Admin Found with ID: [ " + bsonvalue["U"].stringValue + " ]", Globals.CurrentMapPoint);
							Globals.AudioManager.PlaySFX(AudioManager.SoundType.NetherBossWraithShieldAppear, 0f, -1);
							ChatUI.SendMinigameMessage("Mod / Admin found with ID  " + bsonvalue["U"].stringValue + "  Username:  " + Globals.PWStaff[bsonvalue["ID"]]);
							MelonLogger.Msg("Mod Detected with Packet: " + bsonvalue["ID"].stringValue + "  Name: " + Globals.PWStaff[bsonvalue["ID"]]);
						}
					}
					bool flag17 = Globals.AntiRetard && stringValue == "AnP" && bsonvalue.ContainsKey("U");
					if (flag17)
					{
						bool flag18 = Globals.Retards.ContainsKey(bsonvalue["U"].stringValue);
						if (flag18)
						{
							Globals.DoCustomNotification("Retard found! Username: " + NetworkPlayers.GetNameWithId(bsonvalue["U"], false), Globals.CurrentMapPoint);
							OutgoingMessages.BanAndKickPlayer(bsonvalue["U"].stringValue);
							OutgoingMessages.KickPlayer(bsonvalue["U"].stringValue);
							ChatUI.SendMinigameMessage("Retard found! Banned " + NetworkPlayers.GetNameWithId(bsonvalue["U"], false) + " from the world!");
						}
					}
				}
				return result;
			}
		}

		// Token: 0x02000075 RID: 117
		[HarmonyPatch(typeof(OutgoingMessages), "AddOneMessageToList")]
		private static class OutgoingPackets
		{
			// Token: 0x060002BE RID: 702 RVA: 0x00018E54 File Offset: 0x00017054
			private static bool Prefix(BSONObject toAdd)
			{
				bool result = true;
				string stringValue = toAdd["ID"].stringValue;
				bool flag = Globals.OutgoingBlock.Contains(stringValue);
				if (flag)
				{
					result = false;
				}
				bool flag2 = Globals.AutoBanPackets.Contains(stringValue);
				if (flag2)
				{
					result = false;
				}
				bool flag3 = Globals.AutoVendor && toAdd["ID"].stringValue == "PVi";
				if (flag3)
				{
					Globals.VendCID = toAdd["vC"].int32Value;
					Globals.VendID = toAdd["vI"].int32Value;
					Globals.VendIK = toAdd["IK"].int32Value;
				}
				bool flag4 = Globals.GetOpen && toAdd["ID"].stringValue == "OpenPresent";
				if (flag4)
				{
					Globals.AOINVK = toAdd["IK"].int32Value;
					Globals.GetOpen = false;
				}
				bool flag5 = Globals.cmOutgoing && stringValue != "PSicU" && stringValue != "" && stringValue != "";
				if (flag5)
				{
					Globals.CurrentCaptureOUTGOING = Utils.DumpBSON(toAdd);
					Console.WriteLine("\r\n \r\n" + Utils.DumpBSON(toAdd) + "\r\n \r\n");
				}
				bool flag6 = Globals.captureCard && toAdd["ID"].stringValue == "DCard";
				if (flag6)
				{
					InfoPopupUI.SetupInfoPopup("Disenchanter started!", "");
					InfoPopupUI.ForceShowMenu();
					Globals.cardID = toAdd["ccD"].int32Value;
					Globals.cardAmt = toAdd["Amt"].int32Value;
					Globals.captureCard = false;
				}
				bool flag7 = Globals.autoGM && toAdd["ID"].stringValue == "GM";
				if (flag7)
				{
					Globals.Base64Msg = toAdd["msg"].stringValue;
					ChatUI.SendMinigameMessage("=====<br [AUTOGM]: Base64 Msg Acquired!<br =====");
					Globals.autoGM = false;
				}
				return result;
			}
		}
	}
}
