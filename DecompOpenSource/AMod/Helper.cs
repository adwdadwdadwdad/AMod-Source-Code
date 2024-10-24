using System;
using System.Text;
using Il2CppKernys.Bson;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace AMod
{
	// Token: 0x02000055 RID: 85
	public class Helper
	{
		// Token: 0x0600027C RID: 636 RVA: 0x00014360 File Offset: 0x00012560
		public static string GenerateRandomString(int Lenght)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_^{[]}";
			StringBuilder stringBuilder = new StringBuilder();
			Random random = new Random();
			for (int i = 0; i < Lenght; i++)
			{
				stringBuilder.Append(text[random.Next(text.Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000143BC File Offset: 0x000125BC
		public static string DumpBSON(BSONObject _BSONObject)
		{
			byte[] bytes = SimpleBSON.Dump(_BSONObject);
			BsonDocument obj = BsonSerializer.Deserialize<BsonDocument>(bytes, null);
			return "\n" + obj.ToJson(new JsonWriterSettings
			{
				Indent = true
			}, null, null, default(BsonSerializationArgs));
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0001440C File Offset: 0x0001260C
		public static long FixTicks(long Tick)
		{
			string text = Convert.ToString(Tick);
			text = text.Remove(11) + "2468010";
			return Convert.ToInt64(text);
		}
	}
}
