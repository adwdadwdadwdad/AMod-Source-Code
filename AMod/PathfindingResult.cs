using System;

// Token: 0x02000002 RID: 2
public enum PathfindingResult : byte
{
	// Token: 0x04000002 RID: 2
	SUCCESSFUL,
	// Token: 0x04000003 RID: 3
	CANCELLED,
	// Token: 0x04000004 RID: 4
	ERROR_START_OUT_OF_BOUNDS,
	// Token: 0x04000005 RID: 5
	ERROR_END_OUT_OF_BOUNDS,
	// Token: 0x04000006 RID: 6
	Same_Block,
	// Token: 0x04000007 RID: 7
	ERROR_PATH_TOO_LONG,
	// Token: 0x04000008 RID: 8
	Start_Not_Valid,
	// Token: 0x04000009 RID: 9
	Invalid_Ending_Pos,
	// Token: 0x0400000A RID: 10
	Path_Not_Found,
	// Token: 0x0400000B RID: 11
	Path_Not_Found_Block
}
