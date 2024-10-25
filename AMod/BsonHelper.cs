using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Il2Cpp;
using Il2CppKernys.Bson;
using Il2CppSystem.Collections.Generic;

namespace AMod
{
	// Token: 0x02000051 RID: 81
	internal static class BsonHelper
	{
		// Token: 0x0600025B RID: 603 RVA: 0x000123B4 File Offset: 0x000105B4
		public static BSONObject FormatBson(BSONObject bson)
		{
			try
			{
				Il2CppSystem.Collections.Generic.Dictionary<string, BSONValue>.KeyCollection keys = bson.mMap.Keys;
				foreach (string key in keys)
				{
					string[] array = bson.mMap.Values.dictionary[key].stringValue.ToLower().Replace(':', ',').Split(new char[]
					{
						','
					});
					bool flag = BsonHelper.sValueKeys.Contains(array[0]);
					bool flag2 = flag;
					if (flag2)
					{
						string text = array[0];
						string text2 = text;
						string text3 = text2;
						string hex = BsonHelper.ComputeHash(text3);
						uint num = BsonHelper.ConvertToUInt(hex);
						bool flag3 = num <= 936371955U;
						if (flag3)
						{
							bool flag4 = num <= 312129319U;
							if (flag4)
							{
								bool flag5 = num != 223174175U;
								if (flag5)
								{
									bool flag6 = num == 312129319U;
									if (flag6)
									{
										bool flag7 = text3 == "$wib";
										if (flag7)
										{
											bool flag8 = array.Length < 3;
											bool flag9 = flag8;
											if (flag9)
											{
												throw new Exception("Invalid args, please use: \"WiB:X,Y\"");
											}
											bson.mMap.Values.dictionary[key] = Globals.world.GetWorldItemData(int.Parse(array[1]), int.Parse(array[2])).GetAsBSON();
										}
									}
								}
								else
								{
									bool flag10 = text3 == "$ik";
									if (flag10)
									{
										bool flag11 = array.Length < 3;
										bool flag12 = flag11;
										if (flag12)
										{
											throw new Exception("Invalid args, please use: \"IK:blockId,itemType\"");
										}
										bson.mMap.Values.dictionary[key] = PlayerData.InventoryKey.InventoryKeyToInt(new PlayerData.InventoryKey((World.BlockType)int.Parse(array[1]), (PlayerData.InventoryItemType)int.Parse(array[2])));
									}
								}
							}
							else
							{
								bool flag13 = num != 433279108U;
								if (flag13)
								{
									bool flag14 = num == 936371955U;
									if (flag14)
									{
										bool flag15 = text3 == "$iid";
										if (flag15)
										{
											bool flag16 = array.Length < 2;
											bool flag17 = flag16;
											if (flag17)
											{
												throw new Exception("Invalid args, please use: \"IiD:inventoryKey\"");
											}
											bson.mMap.Values.dictionary[key] = Globals.PlayerData.GetInventoryData(PlayerData.InventoryKey.IntToInventoryKey(int.Parse(array[1]))).GetAsBSON();
										}
									}
								}
								else
								{
									bool flag18 = text3 == "$inventorykey";
									if (flag18)
									{
										bool flag19 = array.Length < 3;
										bool flag20 = flag19;
										if (flag20)
										{
											throw new Exception("Invalid args, please use: \"InventoryKey:blockId,itemType\"");
										}
										bson.mMap.Values.dictionary[key] = PlayerData.InventoryKey.InventoryKeyToInt(new PlayerData.InventoryKey((World.BlockType)int.Parse(array[1]), (PlayerData.InventoryItemType)int.Parse(array[2])));
									}
								}
							}
						}
						else
						{
							bool flag21 = num <= 1275578154U;
							if (flag21)
							{
								bool flag22 = num != 1206597225U;
								if (flag22)
								{
									bool flag23 = num == 1275578154U;
									if (flag23)
									{
										bool flag24 = text3 == "$time";
										if (flag24)
										{
											bson.mMap.Values.dictionary[key] = DateTime.Now.Ticks;
										}
									}
								}
								else
								{
									bool flag25 = text3 == "$worlddata";
									if (flag25)
									{
										bool flag26 = array.Length < 3;
										bool flag27 = flag26;
										if (flag27)
										{
											throw new Exception("Invalid args, please use: \"$WorldData:X,Y\"");
										}
										bson.mMap.Values.dictionary[key] = Globals.world.GetWorldItemData(int.Parse(array[1]), int.Parse(array[2])).GetAsBSON();
									}
								}
							}
							else
							{
								bool flag28 = num != 2115231304U;
								if (flag28)
								{
									bool flag29 = num == 3552972909U;
									if (flag29)
									{
										bool flag30 = text3 == "$inventorydata";
										if (flag30)
										{
											bool flag31 = array.Length < 2;
											bool flag32 = flag31;
											if (flag32)
											{
												throw new Exception("Invalid args, please use: \"InventoryData:inventoryKey\"");
											}
											bson.mMap.Values.dictionary[key] = Globals.PlayerData.GetInventoryData(PlayerData.InventoryKey.IntToInventoryKey(int.Parse(array[1]))).GetAsBSON();
										}
									}
								}
								else
								{
									bool flag33 = text3 == "$timeutc";
									if (flag33)
									{
										bson.mMap.Values.dictionary[key] = DateTime.UtcNow.Ticks;
									}
								}
							}
						}
					}
				}
				return bson;
			}
			catch (Exception ex)
			{
				bool flag34 = ex.GetType() != typeof(InvalidOperationException);
				bool flag35 = flag34;
				if (flag35)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return null;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00012890 File Offset: 0x00010A90
		public static string GetBsonAsString(BSONObject SinglePacket, string Parent = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in BsonHelper.Keys)
			{
				try
				{
					BSONValue bsonvalue = SinglePacket[text];
					switch (bsonvalue.valueType)
					{
					case BSONValue.ValueType.Double:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.doubleValue
						}));
						continue;
					case BSONValue.ValueType.String:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.stringValue
						}));
						continue;
					case BSONValue.ValueType.Array:
					{
						string text2 = string.Join("; ", new object[]
						{
							bsonvalue.stringListValue
						});
						stringBuilder.AppendLine(string.Concat(new string[]
						{
							Parent,
							" = ",
							text,
							" = ",
							text2
						}));
						continue;
					}
					case BSONValue.ValueType.Binary:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2}", Parent, text, bsonvalue.valueType));
						stringBuilder.Append(BsonHelper.GetBsonAsString(SimpleBSON.Load(bsonvalue.binaryValue), text));
						continue;
					case BSONValue.ValueType.Boolean:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.boolValue
						}));
						continue;
					case BSONValue.ValueType.UTCDateTime:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.dateTimeValue
						}));
						continue;
					case BSONValue.ValueType.Int32:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.int32Value
						}));
						continue;
					case BSONValue.ValueType.Int64:
						stringBuilder.AppendLine(string.Format("{0} = {1} | {2} = {3}", new object[]
						{
							Parent,
							text,
							bsonvalue.valueType,
							bsonvalue.int64Value
						}));
						continue;
					}
					stringBuilder.AppendLine(string.Format("{0} = {1} = {2}", Parent, text, bsonvalue.valueType));
				}
				catch
				{
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00012B84 File Offset: 0x00010D84
		private static string ComputeHash(string input)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				byte[] bytes = Encoding.ASCII.GetBytes(input);
				byte[] value = md.ComputeHash(bytes);
				result = BitConverter.ToString(value).Replace("-", "").ToLower();
			}
			return result;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00012BE8 File Offset: 0x00010DE8
		private static uint ConvertToUInt(string hex)
		{
			return uint.Parse(hex.Substring(0, 8), NumberStyles.HexNumber);
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00012C0C File Offset: 0x00010E0C
		public static System.Collections.Generic.ICollection<string> Keys
		{
			get
			{
				return BsonHelper.mMap.Keys;
			}
		}

		// Token: 0x04000146 RID: 326
		public static System.Collections.Generic.List<string> sValueKeys = new System.Collections.Generic.List<string>
		{
			"$time",
			"$timeutc",
			"$worlddata",
			"$wib",
			"$wiringdata",
			"$inventorydata",
			"$iib",
			"$inventorykey",
			"$ik"
		};

		// Token: 0x04000147 RID: 327
		public static System.Collections.Generic.Dictionary<string, BSONValue> mMap = new System.Collections.Generic.Dictionary<string, BSONValue>();
	}
}
