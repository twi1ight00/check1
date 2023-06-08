using System;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns2;

namespace ns27;

internal class Class640 : Class538
{
	internal Class640(byte[] byte_1)
	{
		method_2(6);
		method_0((short)(20 + byte_1.Length));
		byte_0 = new byte[base.Length];
		byte_0[19] = byte.MaxValue;
		Array.Copy(byte_1, 0, byte_0, 20, byte_1.Length);
	}

	internal void method_4(ushort ushort_0, byte byte_1, ushort ushort_1, object object_0, bool bool_0, byte byte_2, bool bool_1)
	{
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
		byte_0[2] = byte_1;
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 4, 2);
		byte_0[14] |= byte_2;
		if (bool_0)
		{
			byte_0[14] |= 8;
		}
		if (object_0 != null)
		{
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			case TypeCode.Double:
				Array.Copy(BitConverter.GetBytes((double)object_0), 0, byte_0, 6, 8);
				break;
			case TypeCode.DateTime:
				Array.Copy(BitConverter.GetBytes(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_1)), 0, byte_0, 6, 8);
				break;
			default:
				if (object_0 is Class1719)
				{
					byte_0[6] = 0;
					byte_0[12] = byte.MaxValue;
					byte_0[13] = byte.MaxValue;
				}
				break;
			case TypeCode.String:
			{
				byte_0[6] = 0;
				byte_0[12] = byte.MaxValue;
				byte_0[13] = byte.MaxValue;
				string key;
				if ((key = (string)object_0) == null)
				{
					break;
				}
				if (Class1742.dictionary_227 == null)
				{
					Class1742.dictionary_227 = new Dictionary<string, int>(8)
					{
						{ "#DIV/0!", 0 },
						{ "#N/A", 1 },
						{ "#NAME?", 2 },
						{ "#NULL!", 3 },
						{ "#NUM!", 4 },
						{ "#REF!", 5 },
						{ "#VALUE!", 6 },
						{ "#Recursive Reference!", 7 }
					};
				}
				if (Class1742.dictionary_227.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						byte_0[6] = 2;
						byte_0[8] = 7;
						break;
					case 1:
						byte_0[6] = 2;
						byte_0[8] = 42;
						break;
					case 2:
						byte_0[6] = 2;
						byte_0[8] = 29;
						break;
					case 3:
						byte_0[6] = 2;
						byte_0[8] = 0;
						break;
					case 4:
						byte_0[6] = 2;
						byte_0[8] = 36;
						break;
					case 5:
						byte_0[6] = 2;
						byte_0[8] = 23;
						break;
					case 6:
						byte_0[6] = 2;
						byte_0[8] = 15;
						break;
					case 7:
						byte_0[6] = 3;
						break;
					}
				}
				break;
			}
			case TypeCode.Int32:
				Array.Copy(BitConverter.GetBytes((double)(int)object_0), 0, byte_0, 6, 8);
				break;
			case TypeCode.Boolean:
				byte_0[6] = 1;
				byte_0[8] = (byte)(((bool)object_0) ? 1u : 0u);
				byte_0[12] = byte.MaxValue;
				byte_0[13] = byte.MaxValue;
				break;
			}
		}
		else
		{
			byte_0[6] = 3;
			byte_0[12] = byte.MaxValue;
			byte_0[13] = byte.MaxValue;
		}
	}
}
