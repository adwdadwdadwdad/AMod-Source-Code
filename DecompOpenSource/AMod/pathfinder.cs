using System;
using System.Collections.Generic;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppKernys.Bson;

namespace AMod
{
	// Token: 0x02000057 RID: 87
	public class pathfinder
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00014450 File Offset: 0x00012650
		public static bool[,] GetMap()
		{
			int worldSizeX = Globals.world.worldSizeX;
			int worldSizeY = Globals.world.worldSizeY;
			bool flag = worldSizeX <= 0 || worldSizeY <= 0;
			if (flag)
			{
				throw new ArgumentException("Invalid world size");
			}
			bool[,] array = new bool[worldSizeX, worldSizeY];
			int num = pathfinder.CalculateNumObstacles(worldSizeX, worldSizeY);
			Random random = new Random();
			for (int i = 0; i < num; i++)
			{
				int num2;
				int num3;
				do
				{
					num2 = random.Next(0, worldSizeX);
					num3 = random.Next(0, worldSizeY);
				}
				while (array[num2, num3]);
				array[num2, num3] = true;
			}
			return array;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00014500 File Offset: 0x00012700
		private static int CalculateNumObstacles(int worldSizeX, int worldSizeY)
		{
			int minValue = worldSizeX * worldSizeY / 4;
			int num = worldSizeX * worldSizeY / 2;
			Random random = new Random();
			return random.Next(minValue, num + 1);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00014530 File Offset: 0x00012730
		public static bool IsTileWalkable(int x, int y, Vector2i cpos, bool diag = false, bool isnether = false)
		{
			pathfinder pathfinder = new pathfinder();
			World.BlockType blockType = Globals.world.GetBlockType(new Vector2i(x, y));
			bool flag = !Globals.world.IsMapPointInWorld(new Vector2i(x, y));
			bool flag2 = flag;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = pathfinder.IsBlockCloud(blockType);
				bool flag4 = flag3;
				if (flag4)
				{
					result = true;
				}
				else
				{
					bool flag5 = ConfigData.IsBlockPlatform(blockType) || blockType == World.BlockType.EntrancePortal;
					bool flag6 = flag5;
					if (flag6)
					{
						bool flag7 = Globals.lastpos.y <= y;
						bool flag8 = flag7;
						if (flag8)
						{
							return true;
						}
					}
					bool flag9 = ConfigData.IsAnyDoor(blockType);
					bool flag10 = flag9;
					if (flag10)
					{
						bool flag11 = Globals.WorldController.DoesPlayerHaveRightToGoDoorForCollider(new Vector2i(x, y));
						bool flag12 = flag11;
						if (flag12)
						{
							return true;
						}
					}
					bool flag13 = ConfigData.IsBlockBattleBarrier(blockType);
					bool flag14 = flag13;
					if (flag14)
					{
						BattleBarrierBasicData battleBarrierBasicData = new BattleBarrierBasicData(1);
						battleBarrierBasicData.SetViaBSON(Globals.world.GetWorldItemData(new Vector2i(x, y)).GetAsBSON());
						bool isOpen = battleBarrierBasicData.isOpen;
						bool flag15 = isOpen;
						if (flag15)
						{
							return true;
						}
					}
					bool flag16 = ConfigData.IsBlockDisappearingBlock(blockType);
					bool flag17 = flag16;
					if (flag17)
					{
						DisappearingBlockData disappearingBlockData = new DisappearingBlockData(1);
						disappearingBlockData.SetViaBSON(Globals.world.GetWorldItemData(new Vector2i(x, y)).GetAsBSON());
						bool isOpen2 = disappearingBlockData.isOpen;
						bool flag18 = isOpen2;
						if (flag18)
						{
							return true;
						}
					}
					bool flag19 = blockType == World.BlockType.NetherKey || blockType == World.BlockType.JetRaceForcefieldStart || blockType == World.BlockType.JetRaceFinishline || blockType == World.BlockType.JetRaceCrestGold || blockType == World.BlockType.PortalMiningEntry || blockType == World.BlockType.PortalMineExit;
					bool flag20 = flag19;
					if (flag20)
					{
						result = true;
					}
					else
					{
						bool flag21 = ConfigData.doesBlockHaveCollider[(int)blockType];
						result = !flag21;
					}
				}
			}
			return result;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00014710 File Offset: 0x00012910
		public bool IsBlockCloud(World.BlockType blockType)
		{
			return blockType == World.BlockType.CloudPlatform || blockType == World.BlockType.TrapdoorMetalPlatform;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00014738 File Offset: 0x00012938
		public bool IsBlockCloudOn(int x, int y)
		{
			return this.IsBlockCloud(Globals.world.GetBlockType(x, y));
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0001475C File Offset: 0x0001295C
		private static List<PNode> TracePath(PNode end)
		{
			List<PNode> list = new List<PNode>();
			for (PNode pnode = end; pnode != null; pnode = pnode.parent)
			{
				list.Add(pnode);
			}
			list.Reverse();
			return list;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00014799 File Offset: 0x00012999
		public virtual void ResetSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000147AC File Offset: 0x000129AC
		private void ResetMap()
		{
			this.ResetSize(Globals.world.worldSizeX, Globals.world.worldSizeY);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000147CC File Offset: 0x000129CC
		public void Run(Vector2i start, Vector2i end)
		{
			this.ResetMap();
			ValueTuple<List<PNode>, PathfindingResult> valueTuple = pathfinder.FindPath(start, end, pathfinder.GetMap());
			List<PNode> item = valueTuple.Item1;
			PathfindingResult item2 = valueTuple.Item2;
			bool flag = item2 == PathfindingResult.SUCCESSFUL;
			if (flag)
			{
				bool flag2 = item.Count == 0;
				if (flag2)
				{
					ChatUI.SendLogMessage("Error: Path found but path list is empty.");
				}
				else
				{
					AMod amod = new AMod();
					Globals.TeleportPath = item;
					Globals.CurrentTp = 0;
					Globals.Isteleporting = true;
					Globals.TeleportTimer = 0f;
					bool flag3 = Globals.TeleportPath.Count > 0;
					if (flag3)
					{
						Globals.targetIndex = 0;
						Globals.targetPosition = Globals.WorldController.ConvertMapPointToWorldPoint(new Vector2i(Globals.TeleportPath[Globals.targetIndex].x, Globals.TeleportPath[Globals.targetIndex].y));
					}
					else
					{
						ChatUI.SendLogMessage("Error: Path found but no valid targets.");
					}
				}
			}
			else
			{
				pathfinder.HandlePathfindingError(item2);
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000148BC File Offset: 0x00012ABC
		public static void HandlePathfindingError(PathfindingResult result)
		{
			switch (result)
			{
			case PathfindingResult.ERROR_START_OUT_OF_BOUNDS:
				ChatUI.SendLogMessage("Error: Start position is out of bounds.");
				break;
			case PathfindingResult.ERROR_END_OUT_OF_BOUNDS:
				ChatUI.SendLogMessage("Error: End position is out of bounds.");
				break;
			case PathfindingResult.Same_Block:
				ChatUI.SendLogMessage("Error: Start and end positions are the same.");
				break;
			case PathfindingResult.ERROR_PATH_TOO_LONG:
				ChatUI.SendLogMessage("Error: The path is too long.");
				break;
			case PathfindingResult.Start_Not_Valid:
				ChatUI.SendLogMessage("Error: Start position is not valid.");
				break;
			case PathfindingResult.Invalid_Ending_Pos:
				ChatUI.SendLogMessage("Error: Ending position is invalid.");
				break;
			case PathfindingResult.Path_Not_Found:
				ChatUI.SendLogMessage("Error: No path could be found.");
				break;
			case PathfindingResult.Path_Not_Found_Block:
				ChatUI.SendLogMessage("Error: End position is blocked by an obstacle.");
				break;
			default:
				ChatUI.SendLogMessage("Error: Unknown pathfinding error.");
				break;
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00014970 File Offset: 0x00012B70
		public static ValueTuple<List<PNode>, PathfindingResult> FindPath(Vector2i _from, Vector2i _to, bool[,] map)
		{
			pathfinder.PriorityQueue<PNode> priorityQueue = new pathfinder.PriorityQueue<PNode>();
			bool[,] array = new bool[Globals.world.worldSizeX, Globals.world.worldSizeY];
			PNode item = new PNode(_from.x, _from.y, null, 0, pathfinder.Heuristic(_from, _to));
			priorityQueue.Enqueue(item);
			array[_from.x, _from.y] = true;
			while (priorityQueue.Count > 0)
			{
				PNode pnode = priorityQueue.Dequeue();
				bool flag = pnode.x == _to.x && pnode.y == _to.y;
				if (flag)
				{
					return new ValueTuple<List<PNode>, PathfindingResult>(pathfinder.ReconstructPath(pnode), PathfindingResult.SUCCESSFUL);
				}
				int[] array2 = new int[]
				{
					-1,
					1,
					0,
					0,
					-1,
					1,
					1,
					-1
				};
				int[] array3 = new int[]
				{
					0,
					0,
					-1,
					1,
					1,
					-1,
					-1,
					1
				};
				int i = 0;
				while (i < 8)
				{
					int num = pnode.x + array2[i];
					int num2 = pnode.y + array3[i];
					bool flag2 = Math.Abs(array2[i]) == 1 && Math.Abs(array3[i]) == 1;
					bool flag3 = pathfinder.IsValidPosition(num, num2, array) && pathfinder.IsTileWalkable(num, num2, Globals.CurrentMapPoint, true, false);
					if (flag3)
					{
						World.BlockType blockType = Globals.world.GetBlockType(num, num2);
						bool flag4 = ConfigData.IsBlockPlatform(blockType);
						bool flag5 = blockType == World.BlockType.TrapdoorMetalPlatform || blockType == World.BlockType.CloudPlatform;
						bool flag6 = num2 < pnode.y;
						bool flag7 = num2 > pnode.y;
						bool flag8 = flag4;
						if (flag8)
						{
							bool flag9 = flag6 && !flag5;
							if (flag9)
							{
								goto IL_251;
							}
							bool flag10 = flag7 || flag5;
							if (flag10)
							{
							}
						}
						bool flag11 = !flag2 || (pathfinder.IsTileWalkable(pnode.x, pnode.y + array3[i], Globals.CurrentMapPoint, false, false) && pathfinder.IsTileWalkable(pnode.x + array2[i], pnode.y, Globals.CurrentMapPoint, false, false));
						bool flag12 = flag11;
						if (flag12)
						{
							int gCost = pnode.gCost + 1;
							int hCost = pathfinder.Heuristic(new Vector2i(num, num2), _to);
							PNode item2 = new PNode(num, num2, pnode, gCost, hCost);
							bool flag13 = !array[num, num2];
							if (flag13)
							{
								priorityQueue.Enqueue(item2);
								array[num, num2] = true;
							}
						}
					}
					IL_251:
					i++;
					continue;
					goto IL_251;
				}
			}
			bool flag14 = ConfigData.DoesBlockHaveCollider(Globals.world.GetBlockType(_to.x, _to.y));
			if (flag14)
			{
				return new ValueTuple<List<PNode>, PathfindingResult>(new List<PNode>(), PathfindingResult.Path_Not_Found_Block);
			}
			return new ValueTuple<List<PNode>, PathfindingResult>(new List<PNode>(), pathfinder.DeterminePathfindingError(_from, _to, map));
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00014C40 File Offset: 0x00012E40
		private static PathfindingResult DeterminePathfindingError(Vector2i from, Vector2i to, bool[,] map)
		{
			bool flag = !pathfinder.IsValidPosition(from.x, from.y, map);
			PathfindingResult result;
			if (flag)
			{
				result = PathfindingResult.ERROR_START_OUT_OF_BOUNDS;
			}
			else
			{
				bool flag2 = !pathfinder.IsValidPosition(to.x, to.y, map);
				if (flag2)
				{
					result = PathfindingResult.ERROR_END_OUT_OF_BOUNDS;
				}
				else
				{
					bool flag3 = from.x == to.x && from.y == to.y;
					if (flag3)
					{
						result = PathfindingResult.Same_Block;
					}
					else
					{
						bool flag4 = map[from.x, from.y] || map[to.x, to.y];
						if (flag4)
						{
							result = PathfindingResult.Start_Not_Valid;
						}
						else
						{
							result = PathfindingResult.Path_Not_Found;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00014CE8 File Offset: 0x00012EE8
		private static bool IsValidPosition(int x, int y, bool[,] map)
		{
			return x >= 0 && x < Globals.world.worldSizeX && y >= 0 && y < Globals.world.worldSizeY && !map[x, y];
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00014D2C File Offset: 0x00012F2C
		private static int Heuristic(Vector2i from, Vector2i to)
		{
			return Math.Abs(from.x - to.x) + Math.Abs(from.y - to.y);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00014D64 File Offset: 0x00012F64
		private static List<PNode> ReconstructPath(PNode endNode)
		{
			List<PNode> list = new List<PNode>();
			for (PNode pnode = endNode; pnode != null; pnode = pnode.parent)
			{
				list.Add(pnode);
			}
			list.Reverse();
			return list;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00014DA4 File Offset: 0x00012FA4
		public static bool IsWithinBounds(int x, int y)
		{
			return x >= 0 && x < Globals.world.worldSizeX && y >= 0 && y < Globals.world.worldSizeY;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00014DDB File Offset: 0x00012FDB
		// (set) Token: 0x06000292 RID: 658 RVA: 0x00014DE3 File Offset: 0x00012FE3
		public PathfindingResult Result { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00014DEC File Offset: 0x00012FEC
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00014DF4 File Offset: 0x00012FF4
		public PathfindingResult LastResult { get; private set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00014DFD File Offset: 0x00012FFD
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00014E05 File Offset: 0x00013005
		public int Width { get; private set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00014E0E File Offset: 0x0001300E
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00014E16 File Offset: 0x00013016
		public int Height { get; private set; }

		// Token: 0x04000215 RID: 533
		private int[,] gridmap = new int[100, 100];

		// Token: 0x04000216 RID: 534
		private int _width;

		// Token: 0x04000217 RID: 535
		private int _height;

		// Token: 0x04000218 RID: 536
		private Func<PNode, int> _getWeight;

		// Token: 0x0400021D RID: 541
		public BSONObject[][] worldsItemBson;

		// Token: 0x02000076 RID: 118
		public class PriorityQueue<T> where T : IComparable<T>
		{
			// Token: 0x060002BF RID: 703 RVA: 0x00019078 File Offset: 0x00017278
			public void Enqueue(T item)
			{
				this.data.Add(item);
				int num;
				for (int i = this.data.Count - 1; i > 0; i = num)
				{
					num = (i - 1) / 2;
					T t = this.data[i];
					bool flag = t.CompareTo(this.data[num]) >= 0;
					if (flag)
					{
						break;
					}
					T value = this.data[i];
					this.data[i] = this.data[num];
					this.data[num] = value;
				}
			}

			// Token: 0x060002C0 RID: 704 RVA: 0x00019120 File Offset: 0x00017320
			public T Dequeue()
			{
				int num = this.data.Count - 1;
				T result = this.data[0];
				this.data[0] = this.data[num];
				this.data.RemoveAt(num);
				num--;
				int num2 = 0;
				for (;;)
				{
					int num3 = num2 * 2 + 1;
					bool flag = num3 > num;
					if (flag)
					{
						break;
					}
					int num4 = num3 + 1;
					T t;
					bool flag2;
					if (num4 <= num)
					{
						t = this.data[num4];
						flag2 = (t.CompareTo(this.data[num3]) < 0);
					}
					else
					{
						flag2 = false;
					}
					bool flag3 = flag2;
					if (flag3)
					{
						num3 = num4;
					}
					t = this.data[num2];
					bool flag4 = t.CompareTo(this.data[num3]) <= 0;
					if (flag4)
					{
						break;
					}
					T value = this.data[num2];
					this.data[num2] = this.data[num3];
					this.data[num3] = value;
					num2 = num3;
				}
				return result;
			}

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x060002C1 RID: 705 RVA: 0x0001924E File Offset: 0x0001744E
			public int Count
			{
				get
				{
					return this.data.Count;
				}
			}

			// Token: 0x04000276 RID: 630
			private List<T> data = new List<T>();
		}
	}
}
