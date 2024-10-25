using System;
using System.Collections.Generic;
using System.Text;
using Il2Cpp;
using Il2CppBasicTypes;
using Il2CppKernys.Bson;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using UnityEngine;

namespace AMod
{
	// Token: 0x02000058 RID: 88
	internal class Utils
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00014E38 File Offset: 0x00013038
		public static string DumpBSON(BSONObject obj)
		{
			byte[] bytes = SimpleBSON.Dump(obj);
			BsonDocument obj2 = BsonSerializer.Deserialize<BsonDocument>(bytes, null);
			return obj2.ToJson(new JsonWriterSettings
			{
				Indent = true
			}, null, null, default(BsonSerializationArgs));
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00014E7C File Offset: 0x0001307C
		public static Vector2 ConvertMapPointToWorldPoint(Vector2i mapPoint)
		{
			float tileSizeX = ConfigData.tileSizeX;
			float tileSizeY = ConfigData.tileSizeY;
			float x = (float)mapPoint.x * tileSizeX;
			float y = (float)mapPoint.y * tileSizeY;
			return new Vector2(x, y);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00014EB8 File Offset: 0x000130B8
		public static List<Vector2i> GetMapPointsGridInRange(int range)
		{
			List<Vector2i> result;
			try
			{
				List<Vector2i> list = new List<Vector2i>();
				Vector2i vector2i = new Vector2i(Globals.Player.currentPlayerMapPoint.x - range, Globals.Player.currentPlayerMapPoint.y + range);
				int num = vector2i.x;
				int num2 = vector2i.y;
				for (int i = 0; i < 2 * range + 1; i++)
				{
					for (int j = 0; j < 2 * range + 1; j++)
					{
						bool flag = num >= 0 && num2 >= 0 && num <= Globals.world.worldSizeX && num2 <= Globals.world.worldSizeY;
						bool flag2 = flag;
						if (flag2)
						{
							list.Add(new Vector2i(num, num2));
						}
						num++;
					}
					num = vector2i.x;
					num2--;
				}
				result = list;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00014FBC File Offset: 0x000131BC
		public static string ReadBSON(BSONObject SinglePacket, string Parent = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in SinglePacket.mMap.Keys)
			{
				try
				{
					BSONValue bsonvalue = SinglePacket[text];
					stringBuilder.Append(string.Format("{0} = {1} | {2} = ", Parent, text, bsonvalue.valueType));
					switch (bsonvalue.valueType)
					{
					case BSONValue.ValueType.Double:
						stringBuilder.AppendLine(bsonvalue.doubleValue.ToString());
						continue;
					case BSONValue.ValueType.String:
						stringBuilder.AppendLine(bsonvalue.stringValue);
						continue;
					case BSONValue.ValueType.Array:
					case BSONValue.ValueType.Binary:
					case BSONValue.ValueType.Object:
						stringBuilder.AppendLine(string.Format("Complex type: {0}", bsonvalue.valueType));
						continue;
					case BSONValue.ValueType.Boolean:
						stringBuilder.AppendLine(bsonvalue.boolValue.ToString());
						continue;
					case BSONValue.ValueType.Int32:
						stringBuilder.AppendLine(bsonvalue.int32Value.ToString());
						continue;
					case BSONValue.ValueType.Int64:
						stringBuilder.AppendLine(bsonvalue.int64Value.ToString());
						continue;
					}
					stringBuilder.AppendLine("Unknown Type");
				}
				catch
				{
					stringBuilder.AppendLine("Error processing " + text);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
