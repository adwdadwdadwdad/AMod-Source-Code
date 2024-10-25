using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppSystem;
using Il2CppTMPro;
using UnityEngine;

namespace AMod
{
	// Token: 0x02000054 RID: 84
	internal class Globals
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00012CD4 File Offset: 0x00010ED4
		public static WorldController WorldController
		{
			get
			{
				WorldController result;
				try
				{
					result = ControllerHelper.worldController;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00012D04 File Offset: 0x00010F04
		public static AudioManager AudioManager
		{
			get
			{
				AudioManager result;
				try
				{
					result = ControllerHelper.audioManager;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00012D34 File Offset: 0x00010F34
		public static Player Player
		{
			get
			{
				Player result;
				try
				{
					result = Globals.WorldController.player;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00012D68 File Offset: 0x00010F68
		public static PlayerData PlayerData
		{
			get
			{
				PlayerData result;
				try
				{
					result = Globals.Player.myPlayerData;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00012D9C File Offset: 0x00010F9C
		public static World world
		{
			get
			{
				World result;
				try
				{
					result = Globals.WorldController.world;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00012DD0 File Offset: 0x00010FD0
		public static RootUI rootUI
		{
			get
			{
				RootUI result;
				try
				{
					result = Globals.rootUI;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00012E00 File Offset: 0x00011000
		public static ChatUI chatUI
		{
			get
			{
				ChatUI result;
				try
				{
					result = ControllerHelper.chatUI;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00012E34 File Offset: 0x00011034
		public static GameplayUI GameplayUI
		{
			get
			{
				GameplayUI result;
				try
				{
					result = ControllerHelper.gameplayUI;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00012E68 File Offset: 0x00011068
		public static Vector2i CurrentMapPoint
		{
			get
			{
				Vector2i currentPlayerMapPoint;
				try
				{
					currentPlayerMapPoint = Globals.Player.currentPlayerMapPoint;
				}
				catch
				{
					currentPlayerMapPoint = new Vector2i(-1, -1);
				}
				return currentPlayerMapPoint;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00012EA8 File Offset: 0x000110A8
		public static NotificationController notificationController
		{
			get
			{
				NotificationController result;
				try
				{
					result = ControllerHelper.notificationController;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00012EDC File Offset: 0x000110DC
		public static NetworkClient NetworkClient
		{
			get
			{
				NetworkClient result;
				try
				{
					result = ControllerHelper.networkClient;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00012F0C File Offset: 0x0001110C
		public static GameplayUI gameplayUI
		{
			get
			{
				GameplayUI result;
				try
				{
					result = ControllerHelper.gameplayUI;
				}
				catch
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00012F40 File Offset: 0x00011140
		public static void DoCustomNotification(string text, Vector2i mapPoint)
		{
			bool flag = mapPoint.y >= ControllerHelper.worldController.world.worldSizeY;
			bool flag2 = flag;
			if (flag2)
			{
				mapPoint.y = ControllerHelper.worldController.world.worldSizeY - 1;
			}
			bool flag3 = Globals.notificationController.notifications[Globals.notificationController.notificationsIndex] == null;
			bool flag4 = flag3;
			if (flag4)
			{
				Globals.notificationController.notifications[Globals.notificationController.notificationsIndex] = UnityEngine.Object.Instantiate<GameObject>(Globals.notificationController.notificationPrefab, ControllerHelper.worldController.ConvertMapPointToWorldPoint(mapPoint), Globals.notificationController.notificationPrefab.transform.rotation);
				Globals.notificationController.notificationTextMeshPros[Globals.notificationController.notificationsIndex] = Globals.notificationController.notifications[Globals.notificationController.notificationsIndex].GetComponent<TextMeshPro>();
				Globals.notificationController.notificationDestroyTextAnimation[Globals.notificationController.notificationsIndex] = Globals.notificationController.notifications[Globals.notificationController.notificationsIndex].GetComponent<DestroyTextAnimation>();
			}
			Globals.notificationController.notifications[Globals.notificationController.notificationsIndex].transform.position = ControllerHelper.worldController.ConvertMapPointToWorldPoint(mapPoint);
			Globals.notificationController.notificationTextMeshPros[Globals.notificationController.notificationsIndex].text = text;
			Globals.notificationController.notificationDestroyTextAnimation[Globals.notificationController.notificationsIndex].StartAnimation();
			Globals.notificationController.notifications[Globals.notificationController.notificationsIndex].SetActive(true);
			NotificationController notificationController = Globals.notificationController;
			int notificationsIndex = notificationController.notificationsIndex;
			notificationController.notificationsIndex = notificationsIndex + 1;
			bool flag5 = Globals.notificationController.notificationsIndex >= Globals.notificationController.notifications.Length;
			bool flag6 = flag5;
			if (flag6)
			{
				Globals.notificationController.notificationsIndex = 0;
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0001314C File Offset: 0x0001134C
		public static void StartTeleportation2(int currentX, int currentY, int targetX, int targetY)
		{
			Globals.Player.gravity = 9.17f;
			Vector2i start = new Vector2i(currentX, currentY);
			Vector2i end = new Vector2i(targetX, targetY);
			pathfinder pathfinder = new pathfinder();
			pathfinder.Run(start, end);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00013190 File Offset: 0x00011390
		public static void StartTeleportation(int currentX, int currentY, int targetX, int targetY)
		{
			bool isteleporting = Globals.Isteleporting;
			if (!isteleporting)
			{
				Globals.Player.gravity = 9.17f;
				Debug.Log(string.Format("Start teleportation from ({0}, {1}) to ({2}, {3})", new object[]
				{
					currentX,
					currentY,
					targetX,
					targetY
				}));
				Vector2i start = new Vector2i(currentX, currentY);
				Vector2i end = new Vector2i(targetX, targetY);
				pathfinder pathfinder = new pathfinder();
				pathfinder.Run(start, end);
				bool flag = Globals.TeleportPath.Count > 0;
				if (flag)
				{
					Globals.CurrentTp = 0;
					Globals.targetIndex = 0;
					Globals.targetPosition = Utils.ConvertMapPointToWorldPoint(new Vector2i(Globals.TeleportPath[Globals.targetIndex].x, Globals.TeleportPath[Globals.targetIndex].y));
					Globals.Isteleporting = true;
				}
				else
				{
					PathfindingResult result = pathfinder.Result;
					Debug.Log("No path found for teleportation.");
					string pathfindingErrorReason = Globals.GetPathfindingErrorReason(result);
					Debug.Log("Pathfinding error: " + pathfindingErrorReason);
				}
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000132C0 File Offset: 0x000114C0
		public static void ProcessTeleportation(int currentX, int currentY, int targetX, int targetY)
		{
			bool flag = !Globals.Isteleporting;
			if (!flag)
			{
				bool flag2 = Globals.CurrentTp >= Globals.TeleportPath.Count;
				if (flag2)
				{
					Globals.FinalizeTeleportation(null);
				}
				else
				{
					try
					{
						Vector3 position = Globals.Player.myTransform.position;
						Vector3 vector = Globals.targetPosition - position;
						float magnitude = vector.magnitude;
						float num = (float)((Time.captureFramerate > 0) ? Time.captureFramerate : 60);
						float num2 = Globals.teleportSpeed * (num / 60f);
						bool flag3 = magnitude < num2 * Time.deltaTime;
						if (flag3)
						{
							Globals.Player.myTransform.position = Globals.targetPosition;
							Globals.CurrentTp++;
							bool flag4 = Globals.CurrentTp >= Globals.TeleportPath.Count;
							if (flag4)
							{
								Globals.FinalizeTeleportation(Globals.TeleportPath[Globals.CurrentTp - -1]);
							}
							else
							{
								Globals.targetIndex = Globals.CurrentTp;
								Globals.targetPosition = Utils.ConvertMapPointToWorldPoint(new Vector2i(Globals.TeleportPath[Globals.targetIndex].x, Globals.TeleportPath[Globals.targetIndex].y));
							}
						}
						else
						{
							Globals.Player.myTransform.position += vector.normalized * num2 * Time.deltaTime;
						}
					}
					catch (System.Exception ex)
					{
						Globals.HandleTeleportationError(ex);
					}
				}
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00013468 File Offset: 0x00011668
		private static void FinalizeTeleportation(PNode pnode)
		{
			Globals.TeleportPath.Clear();
			Globals.CurrentTp = 0;
			Globals.Isteleporting = false;
			bool flag = pnode != null;
			if (flag)
			{
				Vector3 vector = Utils.ConvertMapPointToWorldPoint(new Vector2i(pnode.x, pnode.y));
				vector += new Vector3(0.1f, 0.2f, 0f);
				Globals.Player.myTransform.position = vector;
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000134DF File Offset: 0x000116DF
		private static void HandleTeleportationError(System.Exception ex)
		{
			Debug.LogError("Teleport failed! Error: " + ex.Message + " | StackTrace: " + ex.StackTrace);
			Globals.TeleportPath.Clear();
			Globals.CurrentTp = 0;
			Globals.Isteleporting = false;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00013520 File Offset: 0x00011720
		public static string GetPathfindingErrorReason(PathfindingResult result)
		{
			string result2;
			switch (result)
			{
			case PathfindingResult.ERROR_START_OUT_OF_BOUNDS:
				result2 = "Start position is out of bounds.";
				break;
			case PathfindingResult.ERROR_END_OUT_OF_BOUNDS:
				result2 = "End position is out of bounds.";
				break;
			case PathfindingResult.Same_Block:
				result2 = "Start and end positions are the same.";
				break;
			case PathfindingResult.ERROR_PATH_TOO_LONG:
				result2 = "The path is too long.";
				break;
			case PathfindingResult.Start_Not_Valid:
				result2 = "Start position is not valid.";
				break;
			case PathfindingResult.Invalid_Ending_Pos:
				result2 = "Ending position is invalid.";
				break;
			case PathfindingResult.Path_Not_Found:
				result2 = "No path could be found.";
				break;
			case PathfindingResult.Path_Not_Found_Block:
				result2 = "End position is blocked by a block.";
				break;
			default:
				result2 = "Unknown error.";
				break;
			}
			return result2;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000135A8 File Offset: 0x000117A8
		public static void WarpPortal(int targetX, int targetY)
		{
			try
			{
				bool flag = targetX < 0 || targetY < 0 || targetX >= Globals.world.worldSizeX || targetY >= Globals.world.worldSizeY;
				if (flag)
				{
					ChatUI.SendLogMessage("Error: Map point out of bounds.");
				}
				else
				{
					Vector2i mapPoint = new Vector2i(targetX, targetY);
					bool flag2 = !Globals.world.DoesPlayerHaveRightToModifyItemData(mapPoint, Globals.PlayerData, false);
					if (flag2)
					{
						ChatUI.SendLogMessage("Error: No rights to teleport to the specified location.");
					}
					else
					{
						Vector2i vector2i = new Vector2i((int)Globals.Player.myTransform.position.x, (int)Globals.Player.myTransform.position.z);
						Vector2i vector2i2 = new Vector2i(targetX, vector2i.y);
						Vector2i vector2i3 = new Vector2i(vector2i.x, targetY);
						Vector2i vector2i4 = Globals.WorldController.ConvertWorldPointToMapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
						Vector3 vector = new Vector3((float)vector2i4.x, (float)vector2i4.y, 0f);
						Globals.Player.myTransform.position = vector;
						System.Console.WriteLine(string.Format("Warping to map point: {0}", vector));
						ControllerHelper.audioManager.PlaySFX(AudioManager.SoundType.CardCollectionDust, 0f, -1);
						Globals.ShowPopupMessage("Teleport V2", "Interportal TP made by Zeppy");
					}
				}
			}
			catch (System.Exception ex)
			{
				Globals.HandleTeleportationError(ex);
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001372C File Offset: 0x0001192C
		public static void ShowPopupMessage(string title, string message)
		{
			InfoPopupUI.SetupInfoPopup(title, message);
			InfoPopupUI.ForceShowMenu();
		}

		// Token: 0x0400014B RID: 331
		public static bool GodMode = false;

		// Token: 0x0400014C RID: 332
		public static bool FlyHack = false;

		// Token: 0x0400014D RID: 333
		public static bool AntiVortex = false;

		// Token: 0x0400014E RID: 334
		public static bool AntiPush = false;

		// Token: 0x0400014F RID: 335
		public static bool BlockKill = false;

		// Token: 0x04000150 RID: 336
		public static bool InstantRes = false;

		// Token: 0x04000151 RID: 337
		public static bool AntiCollect = false;

		// Token: 0x04000152 RID: 338
		public static bool AntiBounce = false;

		// Token: 0x04000153 RID: 339
		public static bool Test = false;

		// Token: 0x04000154 RID: 340
		public static bool WLPlacer = false;

		// Token: 0x04000155 RID: 341
		public static bool WLPlacerAbove = false;

		// Token: 0x04000156 RID: 342
		public static bool WLPlacerBelow = false;

		// Token: 0x04000157 RID: 343
		public static bool WLPlacerLeft = false;

		// Token: 0x04000158 RID: 344
		public static bool WLPlacerRight = false;

		// Token: 0x04000159 RID: 345
		public static bool TeamSwitcher = false;

		// Token: 0x0400015A RID: 346
		public static bool InvisibleHack = false;

		// Token: 0x0400015B RID: 347
		public static bool PotionCrafter = false;

		// Token: 0x0400015C RID: 348
		public static bool SpikeBomber = false;

		// Token: 0x0400015D RID: 349
		public static bool Jetpacker = false;

		// Token: 0x0400015E RID: 350
		public static bool LizoEffect = false;

		// Token: 0x0400015F RID: 351
		public static bool ProDono = false;

		// Token: 0x04000160 RID: 352
		public static bool PotionCrafterXHealPots = false;

		// Token: 0x04000161 RID: 353
		public static bool InfiniteText = true;

		// Token: 0x04000162 RID: 354
		public static bool Musically = false;

		// Token: 0x04000163 RID: 355
		public static int AnimationCount;

		// Token: 0x04000164 RID: 356
		public static bool AutoTittyrial = false;

		// Token: 0x04000165 RID: 357
		public static bool AutoTittyrial2 = false;

		// Token: 0x04000166 RID: 358
		public static bool AutoTittyrial3 = false;

		// Token: 0x04000167 RID: 359
		public static bool AutoTittyrial4 = false;

		// Token: 0x04000168 RID: 360
		public static bool AutoTittyrial5 = false;

		// Token: 0x04000169 RID: 361
		public static bool SwordPuller = true;

		// Token: 0x0400016A RID: 362
		public static Vector2i lastpos = new Vector2i(0, 0);

		// Token: 0x0400016B RID: 363
		public static string AccountName = "";

		// Token: 0x0400016C RID: 364
		public static string AccountPassy = "";

		// Token: 0x0400016D RID: 365
		public static string LastLoginString1 = "";

		// Token: 0x0400016E RID: 366
		public static string LastLoginString2 = "";

		// Token: 0x0400016F RID: 367
		public static bool AirbronzeButton = false;

		// Token: 0x04000170 RID: 368
		public static bool AirbronzeName = false;

		// Token: 0x04000171 RID: 369
		public static float GemPoucher1 = 3364f;

		// Token: 0x04000172 RID: 370
		public static bool GemPoucher2 = false;

		// Token: 0x04000173 RID: 371
		public static float MusicPicker = 1f;

		// Token: 0x04000174 RID: 372
		public static string MusicName = "";

		// Token: 0x04000175 RID: 373
		public static int WorldPage = 1;

		// Token: 0x04000176 RID: 374
		public static bool CardPack1 = false;

		// Token: 0x04000177 RID: 375
		public static bool Troll = false;

		// Token: 0x04000178 RID: 376
		public static bool handleKick = false;

		// Token: 0x04000179 RID: 377
		public static float PotionID = 2303f;

		// Token: 0x0400017A RID: 378
		public static string PotionName = "";

		// Token: 0x0400017B RID: 379
		public static bool VisualName = false;

		// Token: 0x0400017C RID: 380
		public static bool AnimOnner = false;

		// Token: 0x0400017D RID: 381
		public static bool AnimOffer = false;

		// Token: 0x0400017E RID: 382
		public static bool Gambler = false;

		// Token: 0x0400017F RID: 383
		public static bool Recycler = false;

		// Token: 0x04000180 RID: 384
		public static int RecycledItem = 0;

		// Token: 0x04000181 RID: 385
		public static string WorldNameSecret = "AIRBRONZE";

		// Token: 0x04000182 RID: 386
		public static string WorldNameSecret2 = "JEPE";

		// Token: 0x04000183 RID: 387
		public static string WorldNameRiddle1 = "RIDDLE";

		// Token: 0x04000184 RID: 388
		public static string WorldNameRiddle2 = "SUN";

		// Token: 0x04000185 RID: 389
		public static string WorldNameRiddle3 = "WINTER";

		// Token: 0x04000186 RID: 390
		public static string WorldNameRiddle4 = "JAKE";

		// Token: 0x04000187 RID: 391
		public static string WorldNameRiddle5 = "EARTH";

		// Token: 0x04000188 RID: 392
		public static bool Trasher = false;

		// Token: 0x04000189 RID: 393
		public static bool Dropper = false;

		// Token: 0x0400018A RID: 394
		public static bool LeaveOnDetect = true;

		// Token: 0x0400018B RID: 395
		public static bool HardDetect = false;

		// Token: 0x0400018C RID: 396
		public static bool LogAllPlayers = false;

		// Token: 0x0400018D RID: 397
		public static bool AntiRetard = false;

		// Token: 0x0400018E RID: 398
		public static bool viewNotes = false;

		// Token: 0x0400018F RID: 399
		public static string Notes = "Write your notes here!";

		// Token: 0x04000190 RID: 400
		public static string SaveAs = "MyNotes";

		// Token: 0x04000191 RID: 401
		public static bool CaptureIncomingID = false;

		// Token: 0x04000192 RID: 402
		public static bool CaptureOutgoingID = false;

		// Token: 0x04000193 RID: 403
		public static bool ViewOcaptureOrICapture = false;

		// Token: 0x04000194 RID: 404
		public static string CurrentCaptureINCOMING = "";

		// Token: 0x04000195 RID: 405
		public static string CurrentCaptureOUTGOING = "";

		// Token: 0x04000196 RID: 406
		public static string CustomPacket = "";

		// Token: 0x04000197 RID: 407
		public static string CPacketFile = "";

		// Token: 0x04000198 RID: 408
		public static string LocateGM = "";

		// Token: 0x04000199 RID: 409
		public static bool GWarper = false;

		// Token: 0x0400019A RID: 410
		public static bool PlaceSeedOnAir = false;

		// Token: 0x0400019B RID: 411
		public static bool CollectOn = true;

		// Token: 0x0400019C RID: 412
		public static string INK = "";

		// Token: 0x0400019D RID: 413
		public static string INKKey = "";

		// Token: 0x0400019E RID: 414
		public static string INKAMT = "";

		// Token: 0x0400019F RID: 415
		public static bool GemGemGem = false;

		// Token: 0x040001A0 RID: 416
		public static bool BytesBuyer = false;

		// Token: 0x040001A1 RID: 417
		public static bool BytesBuyer2 = false;

		// Token: 0x040001A2 RID: 418
		public static bool AutoMath = false;

		// Token: 0x040001A3 RID: 419
		public static string GIgn = "";

		// Token: 0x040001A4 RID: 420
		public static bool ItemID = false;

		// Token: 0x040001A5 RID: 421
		public static int ID1 = 0;

		// Token: 0x040001A6 RID: 422
		public static int ID2 = 0;

		// Token: 0x040001A7 RID: 423
		public static bool shouldRem = false;

		// Token: 0x040001A8 RID: 424
		public static float BValueB = 1f;

		// Token: 0x040001A9 RID: 425
		public static string JustIdk123 = "";

		// Token: 0x040001AA RID: 426
		public static bool GemmerOG = false;

		// Token: 0x040001AB RID: 427
		public static bool PlaceholderBool = false;

		// Token: 0x040001AC RID: 428
		public static bool Custompack = true;

		// Token: 0x040001AD RID: 429
		public static int Timer = 1;

		// Token: 0x040001AE RID: 430
		public static bool startTime = false;

		// Token: 0x040001AF RID: 431
		public static bool Disencht = false;

		// Token: 0x040001B0 RID: 432
		public static int cardID = 0;

		// Token: 0x040001B1 RID: 433
		public static int cardAmt = 0;

		// Token: 0x040001B2 RID: 434
		public static bool captureCard = false;

		// Token: 0x040001B3 RID: 435
		public static bool autoVIP = false;

		// Token: 0x040001B4 RID: 436
		public static bool autoVIP2 = false;

		// Token: 0x040001B5 RID: 437
		public static bool clearCh = false;

		// Token: 0x040001B6 RID: 438
		public static bool PLCv = false;

		// Token: 0x040001B7 RID: 439
		public static bool PLCv2 = false;

		// Token: 0x040001B8 RID: 440
		public static bool ByteGemmer = false;

		// Token: 0x040001B9 RID: 441
		public static bool ignoreFwk = false;

		// Token: 0x040001BA RID: 442
		public static int VendID;

		// Token: 0x040001BB RID: 443
		public static int VendCID;

		// Token: 0x040001BC RID: 444
		public static int VendIK;

		// Token: 0x040001BD RID: 445
		public static bool AutoVendor = false;

		// Token: 0x040001BE RID: 446
		public static int EndAmtVend = 0;

		// Token: 0x040001BF RID: 447
		public static float EndAmtVend2 = 100f;

		// Token: 0x040001C0 RID: 448
		public static int vendIKAMT = 0;

		// Token: 0x040001C1 RID: 449
		public static bool autoOPENER = false;

		// Token: 0x040001C2 RID: 450
		public static bool GetOpen = false;

		// Token: 0x040001C3 RID: 451
		public static int AOINVK = 0;

		// Token: 0x040001C4 RID: 452
		public static bool AutoGear = false;

		// Token: 0x040001C5 RID: 453
		public static bool AutoBP = false;

		// Token: 0x040001C6 RID: 454
		public static Dictionary<string, string> Commands = new Dictionary<string, string>
		{
			{
				"info",
				"Dawg?"
			},
			{
				"credits",
				"Displays credits of people who helped make AMod what it is today."
			},
			{
				"help",
				"Displays a list of all commands."
			},
			{
				"ahelp",
				"Displays a list of all commands. AMod-Exclusive command so it does not interfere with other clients."
			},
			{
				"keys",
				"Displays hotkeys and what they do."
			},
			{
				"love",
				"Does the pet love emote."
			},
			{
				"pet1",
				"Does the pet cleaning emote."
			},
			{
				"pet2",
				"Does the pet training emote."
			},
			{
				"sleep",
				"Activate sleep animation."
			},
			{
				"wake",
				"De-activate sleep animation."
			},
			{
				"quit",
				"Close your game."
			},
			{
				"pwe",
				"Place a PWE on your mapPoint."
			},
			{
				"support",
				"Visit our support world!"
			},
			{
				"gbt",
				"Copy itemID of the current selected item."
			},
			{
				"rsc",
				"Reset your clipboard."
			},
			{
				"ait",
				"Add an item inside a regular chest you are standing on. Buggy command."
			},
			{
				"rit",
				"Remove an item from a chest. Best to use if you have an untradable stuck inside chest. Stand on chest to use."
			},
			{
				"uait",
				"Select an untradable item in your inventory, stand on a swapped BT chest, and type /uait to add the item inside."
			},
			{
				"urit",
				"Originally planned to remove untradeables from chest, but pretty buggy and useless."
			},
			{
				"sbt",
				"Swap BlockType of a chest, from normal to untradable chest, or the other way around. \r\n WARNING: If you leave the world with the chest as untradable, you will lose the items inside!"
			},
			{
				"cdata",
				"Just copy paste the data of the current selected item."
			},
			{
				"ref",
				"Refreshes your inventory if you collected a bugged duped seed."
			},
			{
				"aref",
				"Auto-Refreshes your inventory if you collected a bugged duped seed. Can be toggled on/off with the command."
			},
			{
				"drop",
				"Click an item in your inventory and use /drop amount to drop a custom amount of the item!"
			},
			{
				"dall",
				"Drop all of the current selected item!"
			},
			{
				"d1",
				"Drop only 1 of the current selected item!"
			},
			{
				"dupe",
				"Creates a duped seed of the current selected item. Only works on seeds, consumables, & familiars."
			},
			{
				"cdupe",
				"Creates a custom amount duped seed of the current selected item. Only works on seeds consumables & familiars."
			},
			{
				"poblock",
				"Block a specific outgoing packet ID from being sent or captured. /poblock packetID"
			},
			{
				"piblock",
				"Block a specific incoming packet ID from being received or captured. /piblock packetID"
			},
			{
				"iclear",
				"Clear the list of blocked incoming packets."
			},
			{
				"oclear",
				"Clear the list of blocked outgoing packets"
			},
			{
				"eject",
				"Removes AMod from your game until next game session!"
			}
		};

		// Token: 0x040001C7 RID: 455
		public static List<string> IgnoreGMW = new List<string>();

		// Token: 0x040001C8 RID: 456
		public static Dictionary<string, string> PWStaff = new Dictionary<string, string>
		{
			{
				"DY4LVBNE",
				"|BlackWight|"
			},
			{
				"1BYM5371",
				"Rabia"
			},
			{
				"VSL1HVDO",
				"Citrina"
			},
			{
				"LKB469T7",
				"Starfire1178"
			},
			{
				"95F6JEWA",
				"ionas"
			},
			{
				"I501W0UX",
				"xSHANEx"
			},
			{
				"60FPOJ55",
				"Invalid"
			},
			{
				"VZ7RALO",
				"ColdUnwanted"
			},
			{
				"LNBJ9SK",
				"Quqqo"
			},
			{
				"IRIME6M",
				"Lupuss"
			},
			{
				"SAZUT30",
				"Freak"
			},
			{
				"OMD5ECO",
				"Hinter"
			},
			{
				"2SYJQ2R",
				"SEAF"
			},
			{
				"5V6MYXQ3",
				"NicoKapell"
			},
			{
				"G2D8FGE",
				"MrGrandman"
			},
			{
				"48WESIAE",
				"|Serxan|"
			},
			{
				"WUAOAQ4T",
				"Luucsas"
			},
			{
				"MXH9XJ3I",
				"MrBeast"
			},
			{
				"LSPMU8CV",
				"[MOD_CADET]"
			},
			{
				"B7D7Q1YI",
				"Kaluub"
			},
			{
				"VAVR096E",
				"Decay"
			},
			{
				"EIOFU41X",
				"Miwsky"
			},
			{
				"HDAEYVAA",
				"RetNos"
			},
			{
				"FBNA4ZK",
				"Sign"
			},
			{
				"FT066B8B",
				"zithii"
			},
			{
				"Y35ID055",
				"AP0KALYPSE"
			},
			{
				"HKD2ARL4",
				"Baroness"
			},
			{
				"EIR62J9A",
				"lemz"
			},
			{
				"RRP2BPSP",
				"BubblySky"
			},
			{
				"WU73CSFL",
				"Bergelmir"
			},
			{
				"14MCSJHG",
				"JennyFei"
			},
			{
				"34N8P51",
				"Jake"
			},
			{
				"HN55GSS",
				"EndlesS"
			},
			{
				"74RL1AE",
				"MidnightWalker"
			},
			{
				"8HN45WF",
				"Dev"
			},
			{
				"F2RQK1W",
				"Commander_K"
			},
			{
				"666",
				"Commander_K/Server"
			},
			{
				"NZRV2SD",
				"Sorsa"
			},
			{
				"FAL8MX5Y",
				"Siskea"
			},
			{
				"1YAFK4YS",
				"Lokalapsi"
			},
			{
				"Q38SV2L8",
				"bbricks"
			},
			{
				"HF3VQSK5",
				"PIXELLOX"
			}
		};

		// Token: 0x040001C9 RID: 457
		public static Dictionary<string, string> PacketsToIgnore = new Dictionary<string, string>
		{
			{
				"mP",
				""
			},
			{
				"PSicU",
				""
			},
			{
				"PPA",
				""
			}
		};

		// Token: 0x040001CA RID: 458
		public static Dictionary<string, string> Retards = new Dictionary<string, string>
		{
			{
				"G2OK9IVV",
				"ImAGoddess"
			},
			{
				"IJ0CLEM3",
				"JokingWomen"
			}
		};

		// Token: 0x040001CB RID: 459
		public static List<string> oCapture = new List<string>();

		// Token: 0x040001CC RID: 460
		public static List<string> iCapture = new List<string>();

		// Token: 0x040001CD RID: 461
		public static List<string> OutgoingFullCapture = new List<string>();

		// Token: 0x040001CE RID: 462
		public static List<string> OutgoingBlock = new List<string>();

		// Token: 0x040001CF RID: 463
		public static List<string> IncomingBlock = new List<string>();

		// Token: 0x040001D0 RID: 464
		public static bool cmIncoming = false;

		// Token: 0x040001D1 RID: 465
		public static bool cmOutgoing = false;

		// Token: 0x040001D2 RID: 466
		public static string SpamTextOfChoice = "Hello, World!";

		// Token: 0x040001D3 RID: 467
		public static bool SpamTexter = false;

		// Token: 0x040001D4 RID: 468
		public static bool JoinRandomWorlds = false;

		// Token: 0x040001D5 RID: 469
		public static bool EmoteSpam = false;

		// Token: 0x040001D6 RID: 470
		public static bool FriendReqSpam = false;

		// Token: 0x040001D7 RID: 471
		public static bool TradeSpam = false;

		// Token: 0x040001D8 RID: 472
		public static float SendMsgTime = 5f;

		// Token: 0x040001D9 RID: 473
		public static float WorldTime = 10f;

		// Token: 0x040001DA RID: 474
		public static bool MannequinSpam = false;

		// Token: 0x040001DB RID: 475
		public static bool MuteGMs = true;

		// Token: 0x040001DC RID: 476
		public static string ignoreID = "";

		// Token: 0x040001DD RID: 477
		public static string GNameID = "";

		// Token: 0x040001DE RID: 478
		public static string IDLookup1 = "";

		// Token: 0x040001DF RID: 479
		public static float AutoBuySlct = 1f;

		// Token: 0x040001E0 RID: 480
		public static string SetABNick = "";

		// Token: 0x040001E1 RID: 481
		public static bool CaptureAB = false;

		// Token: 0x040001E2 RID: 482
		public static string AutoBuyCT2 = "";

		// Token: 0x040001E3 RID: 483
		public static float AutoBuyCT = 1f;

		// Token: 0x040001E4 RID: 484
		public static string IPID1 = "";

		// Token: 0x040001E5 RID: 485
		public static bool AutoBuy1 = false;

		// Token: 0x040001E6 RID: 486
		public static string PTimerP3 = "";

		// Token: 0x040001E7 RID: 487
		public static float PTimerP2 = 1f;

		// Token: 0x040001E8 RID: 488
		public static bool PSpamP = false;

		// Token: 0x040001E9 RID: 489
		public static int InventoryKeyCP;

		// Token: 0x040001EA RID: 490
		public static string CAmtSpd = "";

		// Token: 0x040001EB RID: 491
		public static float GMSpeed = 0.5f;

		// Token: 0x040001EC RID: 492
		public static bool StartGM = false;

		// Token: 0x040001ED RID: 493
		public static bool autoGM = false;

		// Token: 0x040001EE RID: 494
		public static string Base64Msg = "";

		// Token: 0x040001EF RID: 495
		public static string SignText12 = "";

		// Token: 0x040001F0 RID: 496
		public static bool PickyTrasher = false;

		// Token: 0x040001F1 RID: 497
		public static bool seeFwk = false;

		// Token: 0x040001F2 RID: 498
		public static bool Fwker = false;

		// Token: 0x040001F3 RID: 499
		public static bool IRef = false;

		// Token: 0x040001F4 RID: 500
		public static string TWorld;

		// Token: 0x040001F5 RID: 501
		public static string NameVis;

		// Token: 0x040001F6 RID: 502
		public static float Speed = 1f;

		// Token: 0x040001F7 RID: 503
		public static List<PNode> TeleportPath = new List<PNode>();

		// Token: 0x040001F8 RID: 504
		public static int CurrentTp = 0;

		// Token: 0x040001F9 RID: 505
		public static bool Isteleporting = false;

		// Token: 0x040001FA RID: 506
		public static float TeleportTimer = 0f;

		// Token: 0x040001FB RID: 507
		public static int targetIndex;

		// Token: 0x040001FC RID: 508
		public static Vector3 targetPosition;

		// Token: 0x040001FD RID: 509
		public static float teleportTimer = 0f;

		// Token: 0x040001FE RID: 510
		public static float teleportSpeed = 100f;

		// Token: 0x040001FF RID: 511
		public static float teleportInterval = 0f;

		// Token: 0x04000200 RID: 512
		public static bool ACBPass = false;

		// Token: 0x04000201 RID: 513
		public static bool RSect = false;

		// Token: 0x04000202 RID: 514
		public static int Niggerr = 1;

		// Token: 0x04000203 RID: 515
		public static List<string> AutoBanPackets = new List<string>
		{
			"SetGoThroughDoorsByAdmin",
			"SetEditWorldByAdmin ",
			"LockWorld",
			"UnlockWorld",
			"SetAdminWantsToBeSummoned",
			"SetAdminWantsToGoGhostMode",
			"SetAdminWantsToGoUndercoverMode",
			"SetAdminWantsToIgnorePortals",
			"SetAdminWantsToShowKickBanInfo",
			"SetAdminWantsToGoNoobMode",
			"QueryReportsByAdmin",
			"QueryPlayerLocationByAdmin",
			"MarkReportAsResolvedByAdmin",
			"WarnPlayer",
			"BanPlayerFromGame",
			"AdminKillPlayer",
			"SetGoThroughDoorsByMod",
			"AdminTeleportMenuOpen",
			"AdminTeleportedTo",
			"MGMbP",
			"MFMbP",
			"BanPlayerFromGameByHammer"
		};

		// Token: 0x04000204 RID: 516
		public static bool ignoreAutoban = false;

		// Token: 0x04000205 RID: 517
		internal static List<Vector2i> mps = new List<Vector2i>();

		// Token: 0x04000206 RID: 518
		public static Task Auto1 = new Task(delegate()
		{
			Vector2i currentPlayerMapPoint = Globals.Player.currentPlayerMapPoint;
			Globals.Auto1.Wait(2000);
			OutgoingMessages.SendCharacterCreatedMessage(PlayerData.Gender.Male, 6, 8);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendWearableOrWeaponChange(World.BlockType.HatJumpsuitMale);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendWearableOrWeaponChange(World.BlockType.JumpsuitMale);
			Globals.Auto1.Wait(2000);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 5, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting = Globals.Isteleporting;
			if (isteleporting)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 5, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(2000);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y + 1);
			bool isteleporting2 = Globals.Isteleporting;
			if (isteleporting2)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag2 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag2)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y + 1);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(2000);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting3 = Globals.Isteleporting;
			if (isteleporting3)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag3 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag3)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(2000);
			OutgoingMessages.SendGoFromPortalMessage(Globals.Player.currentPlayerMapPoint);
			OutgoingMessages.SendPlayerActivateInPortal(Globals.Player.currentPlayerMapPoint);
			OutgoingMessages.SendPlayerActivateOutPortal(Globals.Player.currentPlayerMapPoint);
			Globals.Auto1.Wait(2000);
			OutgoingMessages.SendSetBlockMessage(Globals.Player.currentPlayerRightMapPoint, World.BlockType.GemSoil);
			Globals.Auto1.Wait(2000);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting4 = Globals.Isteleporting;
			if (isteleporting4)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag4 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag4)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendSetBlockMessage(Globals.Player.currentPlayerAboveMapPoint, World.BlockType.GemSoil);
			Globals.Auto1.Wait(500);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting5 = Globals.Isteleporting;
			if (isteleporting5)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag5 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag5)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendSetBlockMessage(Globals.Player.currentPlayerAboveMapPoint, World.BlockType.GemSoil);
			Globals.Auto1.Wait(500);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting6 = Globals.Isteleporting;
			if (isteleporting6)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag6 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag6)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendSetBlockMessage(Globals.Player.currentPlayerAboveMapPoint, World.BlockType.GemSoil);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting7 = Globals.Isteleporting;
			if (isteleporting7)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag7 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag7)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting8 = Globals.Isteleporting;
			if (isteleporting8)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag8 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag8)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerAboveMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting9 = Globals.Isteleporting;
			if (isteleporting9)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag9 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag9)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + 1, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerRightMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerRightMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(500);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerRightMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerRightMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerRightMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendSetSeedMessage(Globals.Player.currentPlayerLeftMapPoint, World.BlockType.GemSoil);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendSetSeedMessage(Globals.Player.currentPlayerLeftMapPoint, World.BlockType.Fertilizer);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.SendHitBlockMessage(Globals.Player.currentPlayerLeftMapPoint, Il2CppSystem.DateTime.Now, false);
			Globals.Auto1.Wait(1000);
			Globals.CollectOn = true;
			Globals.Auto1.Wait(1000);
			Globals.StartTeleportation2(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -2, Globals.Player.currentPlayerMapPoint.y);
			bool isteleporting10 = Globals.Isteleporting;
			if (isteleporting10)
			{
				Globals.teleportTimer += Time.deltaTime;
				bool flag10 = Globals.teleportTimer >= Globals.teleportInterval;
				if (flag10)
				{
					Globals.ProcessTeleportation(Globals.Player.currentPlayerMapPoint.x, Globals.Player.currentPlayerMapPoint.y, Globals.Player.currentPlayerMapPoint.x + -2, Globals.Player.currentPlayerMapPoint.y);
					Globals.TeleportTimer = 0f;
				}
			}
			Globals.Auto1.Wait(1000);
			Globals.Auto1.Wait(1000);
			OutgoingMessages.BuyItemPack("BasicClothes");
			Globals.Auto1.Wait(1000);
			OutgoingMessages.LeaveWorld();
			Globals.Auto1.Wait(4000);
			SceneLoader.ReloadGame();
		});

		// Token: 0x04000207 RID: 519
		public static string InventoryKeyIT = "";

		// Token: 0x04000208 RID: 520
		public static bool PWEBuyerAuto = false;

		// Token: 0x04000209 RID: 521
		public static bool CustomItemDrop = false;

		// Token: 0x0400020A RID: 522
		public static bool RandomCDrop = false;

		// Token: 0x0400020B RID: 523
		public static int DropAmtRandomized = 1;

		// Token: 0x0400020C RID: 524
		public static bool Nuker = false;

		// Token: 0x0400020D RID: 525
		public static bool ForcePlace = false;

		// Token: 0x0400020E RID: 526
		public static string InventoryKeyBT = "";

		// Token: 0x0400020F RID: 527
		public static bool CustomSeeder = false;

		// Token: 0x04000210 RID: 528
		public static int BValue = 0;

		// Token: 0x04000211 RID: 529
		public static bool Wearer = false;

		// Token: 0x04000212 RID: 530
		public static bool Bbreak = false;

		// Token: 0x04000213 RID: 531
		public static string BFValue = "";

		// Token: 0x04000214 RID: 532
		public static bool BFarmer = false;
	}
}
