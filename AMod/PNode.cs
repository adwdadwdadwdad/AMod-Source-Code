using System;
using Il2Cpp;
using Il2CppBasicTypes;
using Priority_Queue;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class PNode : FastPriorityQueueNode, IComparable<PNode>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static PNode Create(int x, int y)
	{
		return new PNode(x, y);
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x00002069 File Offset: 0x00000269
	// (set) Token: 0x06000003 RID: 3 RVA: 0x00002071 File Offset: 0x00000271
	public int X { get; private set; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000004 RID: 4 RVA: 0x0000207A File Offset: 0x0000027A
	// (set) Token: 0x06000005 RID: 5 RVA: 0x00002082 File Offset: 0x00000282
	public int Y { get; private set; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000006 RID: 6 RVA: 0x0000208B File Offset: 0x0000028B
	// (set) Token: 0x06000007 RID: 7 RVA: 0x00002093 File Offset: 0x00000293
	public PNode Parent { get; private set; }

	// Token: 0x06000008 RID: 8 RVA: 0x0000209C File Offset: 0x0000029C
	public PNode(int x, int y, PNode parent, int gCost, int hCost)
	{
		this.x = x;
		this.y = y;
		this.parent = parent;
		this.gCost = gCost;
		this.hCost = hCost;
		this.f = (float)(gCost + hCost);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000020D7 File Offset: 0x000002D7
	public PNode(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000020F0 File Offset: 0x000002F0
	public static explicit operator Vector2i(PNode pn)
	{
		return new Vector2i(pn.X, pn.Y);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002114 File Offset: 0x00000314
	public Vector2i ToVector2i()
	{
		return new Vector2i(this.x, this.y);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002138 File Offset: 0x00000338
	public Vector2 ToVector2()
	{
		return ControllerHelper.worldController.ConvertMapPointToWorldPoint(new Vector2i(this.x, this.y));
	}

	// Token: 0x0600000D RID: 13 RVA: 0x0000216C File Offset: 0x0000036C
	public Vector2 GetVector2()
	{
		return new Vector2((float)this.x, (float)this.y);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002194 File Offset: 0x00000394
	public override bool Equals(object obj)
	{
		PNode pnode = (PNode)obj;
		return this.X == pnode.X && this.Y == pnode.Y;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000021CC File Offset: 0x000003CC
	public override int GetHashCode()
	{
		return this.X + this.Y * 7;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000021F0 File Offset: 0x000003F0
	public override string ToString()
	{
		return string.Concat(new string[]
		{
			"(",
			this.X.ToString(),
			", ",
			this.Y.ToString(),
			")"
		});
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00002248 File Offset: 0x00000448
	public int CompareTo(PNode other)
	{
		return (this.gCost + this.hCost).CompareTo(other.gCost + other.hCost);
	}

	// Token: 0x0400000E RID: 14
	public int x;

	// Token: 0x0400000F RID: 15
	public int y;

	// Token: 0x04000010 RID: 16
	public float g;

	// Token: 0x04000011 RID: 17
	public float h;

	// Token: 0x04000012 RID: 18
	public float f;

	// Token: 0x04000013 RID: 19
	public PNode parent;

	// Token: 0x04000014 RID: 20
	public new float Priority;

	// Token: 0x04000015 RID: 21
	public float G;

	// Token: 0x04000016 RID: 22
	public float H;

	// Token: 0x04000017 RID: 23
	public int blockType;

	// Token: 0x04000018 RID: 24
	public int gCost;

	// Token: 0x04000019 RID: 25
	public int hCost;
}
