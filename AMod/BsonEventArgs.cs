using System;
using Il2CppKernys.Bson;

namespace AMod
{
	// Token: 0x02000053 RID: 83
	public class BsonEventArgs : EventArgs
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00012CAE File Offset: 0x00010EAE
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00012CB6 File Offset: 0x00010EB6
		public BSONObject BSON { get; set; }

		// Token: 0x06000264 RID: 612 RVA: 0x00012CBF File Offset: 0x00010EBF
		public BsonEventArgs(BSONObject bSONObject)
		{
			this.BSON = bSONObject;
		}
	}
}
