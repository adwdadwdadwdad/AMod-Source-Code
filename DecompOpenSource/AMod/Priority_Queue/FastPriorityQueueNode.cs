using System;

namespace Priority_Queue
{
	// Token: 0x0200004C RID: 76
	public class FastPriorityQueueNode
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000239 RID: 569 RVA: 0x0000A2AC File Offset: 0x000084AC
		// (set) Token: 0x0600023A RID: 570 RVA: 0x0000A2B4 File Offset: 0x000084B4
		public float Priority { get; protected internal set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000A2BD File Offset: 0x000084BD
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000A2C5 File Offset: 0x000084C5
		public int QueueIndex { get; internal set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000A2CE File Offset: 0x000084CE
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000A2D6 File Offset: 0x000084D6
		public object Queue { get; internal set; }
	}
}
