using System;
using System.Collections;
using System.Collections.Generic;

namespace Priority_Queue
{
	// Token: 0x0200004E RID: 78
	public interface IPriorityQueue<TItem, in TPriority> : IEnumerable<TItem>, IEnumerable
	{
		// Token: 0x06000243 RID: 579
		void Enqueue(TItem node, TPriority priority);

		// Token: 0x06000244 RID: 580
		TItem Dequeue();

		// Token: 0x06000245 RID: 581
		void Clear();

		// Token: 0x06000246 RID: 582
		bool Contains(TItem node);

		// Token: 0x06000247 RID: 583
		void Remove(TItem node);

		// Token: 0x06000248 RID: 584
		void UpdatePriority(TItem node, TPriority priority);

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000249 RID: 585
		TItem First { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600024A RID: 586
		int Count { get; }
	}
}
