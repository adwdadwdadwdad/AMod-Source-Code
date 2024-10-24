using System;
using System.Collections;
using System.Collections.Generic;

namespace Priority_Queue
{
	// Token: 0x0200004D RID: 77
	internal interface IFixedSizePriorityQueue<TItem, in TPriority> : IPriorityQueue<TItem, TPriority>, IEnumerable<TItem>, IEnumerable
	{
		// Token: 0x06000240 RID: 576
		void Resize(int maxNodes);

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000241 RID: 577
		int MaxSize { get; }

		// Token: 0x06000242 RID: 578
		void ResetNode(TItem node);
	}
}
