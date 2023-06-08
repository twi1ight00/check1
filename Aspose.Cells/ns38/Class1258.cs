using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns12;
using ns2;

namespace ns38;

internal class Class1258
{
	internal static byte[] smethod_0(object object_0)
	{
		byte[] array = null;
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			array = new byte[11]
			{
				9, 0, 31, 0, 0, 0, 0, 0, 0, 0,
				0
			};
			Array.Copy(BitConverter.GetBytes((double)object_0), 0, array, 3, 8);
			break;
		case TypeCode.DateTime:
			array = new byte[11]
			{
				9, 0, 31, 0, 0, 0, 0, 0, 0, 0,
				0
			};
			Array.Copy(BitConverter.GetBytes(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, date1904: false)), 0, array, 3, 8);
			break;
		case TypeCode.String:
		{
			string text = (string)object_0;
			array = new byte[5 + text.Length * 2];
			Array.Copy(BitConverter.GetBytes((ushort)(array.Length - 2)), 0, array, 0, 2);
			array[2] = 23;
			array[3] = (byte)text.Length;
			array[4] = 1;
			Array.Copy(Encoding.Unicode.GetBytes(text), 0, array, 5, text.Length * 2);
			break;
		}
		case TypeCode.Int16:
			array = new byte[11]
			{
				9, 0, 31, 0, 0, 0, 0, 0, 0, 0,
				0
			};
			Array.Copy(BitConverter.GetBytes((double)(short)object_0), 0, array, 3, 8);
			break;
		case TypeCode.Int32:
			array = new byte[11]
			{
				9, 0, 31, 0, 0, 0, 0, 0, 0, 0,
				0
			};
			Array.Copy(BitConverter.GetBytes((double)(int)object_0), 0, array, 3, 8);
			break;
		}
		return array;
	}

	internal static object smethod_1(byte[] byte_0, int int_0)
	{
		int num = byte_0.Length;
		if (int_0 == -1)
		{
			num = BitConverter.ToUInt16(byte_0, 0);
			int_0 = 2;
		}
		if (num == 0)
		{
			return null;
		}
		switch (byte_0[int_0])
		{
		case 28:
			if (num == 2)
			{
				return Class1673.smethod_6(byte_0[int_0 + 1]);
			}
			break;
		case 30:
			if (num == 3)
			{
				return (int)BitConverter.ToUInt16(byte_0, int_0 + 1);
			}
			break;
		case 31:
			if (num == 9)
			{
				return BitConverter.ToDouble(byte_0, int_0 + 1);
			}
			break;
		case 23:
		{
			int num2 = byte_0[int_0 + 1];
			if (byte_0[int_0 + 2] == 0)
			{
				if (num2 + 3 == num)
				{
					return Encoding.ASCII.GetString(byte_0, int_0 + 3, num2);
				}
			}
			else if (num2 * 2 + 3 == num)
			{
				return Encoding.Unicode.GetString(byte_0, int_0 + 3, num2 * 2);
			}
			break;
		}
		}
		return null;
	}

	internal static bool smethod_2(byte[] byte_0, int int_0, bool bool_0)
	{
		int num = byte_0.Length;
		if (int_0 == -1)
		{
			num = BitConverter.ToUInt16(byte_0, 0);
			int_0 = 2;
		}
		switch (byte_0[int_0])
		{
		case 28:
			return num == 2;
		default:
			return false;
		case 30:
			return num == 3;
		case 31:
			return num == 9;
		case 23:
		{
			if (bool_0)
			{
				return false;
			}
			int num2 = byte_0[int_0 + 1];
			if (byte_0[int_0 + 2] == 0)
			{
				return num2 + 3 == num;
			}
			return num2 * 2 + 3 == num;
		}
		}
	}

	internal static void smethod_3(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, int int_2, Class1718 class1718_0, bool bool_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = int_0;
		if (num3 == -1)
		{
			num3 = 2;
			int_1 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		Cells cells = null;
		Cell cell = null;
		while (num3 < int_1)
		{
			switch (byte_0[num3])
			{
			default:
				return;
			case 1:
			case 2:
				num3 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num3++;
				break;
			case 23:
			{
				byte b = byte_0[num3 + 1];
				num3 = ((byte_0[num3 + 2] != 0) ? (num3 + (ushort)(b * 2 + 3)) : (num3 + (ushort)(b + 3)));
				break;
			}
			case 24:
				num3 = ((byte_0[num3 + 1] != 25) ? ((byte_0[num3 + 1] != 29) ? (num3 + 1) : (num3 + 6)) : (num3 + 14));
				break;
			case 25:
				switch (byte_0[num3 + 1])
				{
				case 8:
					num3 += 4;
					break;
				case 1:
					num3 += 4;
					break;
				case 2:
					num3 += 4;
					break;
				case 4:
				{
					ushort num9 = BitConverter.ToUInt16(byte_0, num3 + 2);
					num3 += num9 + 5;
					break;
				}
				default:
					num3 += 4;
					break;
				case 64:
					num3 += 4;
					break;
				case 32:
					num3 += 4;
					break;
				case 16:
					num3 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num3 += 2;
				break;
			case 31:
				num3 += 9;
				break;
			case 32:
			case 64:
			case 96:
				num3 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num3 += 3;
				break;
			case 34:
			case 66:
			case 98:
				num3 += 4;
				break;
			case 35:
			case 67:
			case 99:
				num3 += 5;
				break;
			case 36:
			case 68:
			case 100:
				num3 += 5;
				break;
			case 37:
			case 69:
			case 101:
				num3 += 9;
				break;
			case 40:
			case 72:
			case 104:
				num3 += 7;
				break;
			case 41:
			case 73:
			case 105:
				num3 += 3;
				break;
			case 42:
			case 74:
			case 106:
				num3 += 5;
				break;
			case 43:
			case 75:
			case 107:
				num3 += 9;
				break;
			case 44:
			case 76:
			case 108:
				num3 += 5;
				break;
			case 45:
			case 77:
			case 109:
				num3 += 9;
				break;
			case 57:
			case 89:
			case 121:
				num3 += 7;
				break;
			case 58:
			case 90:
			case 122:
				if (bool_0)
				{
					int num11 = BitConverter.ToUInt16(byte_0, num3 + 1);
					BitConverter.ToUInt16(byte_0, num3 + 3);
					num4 = BitConverter.ToUInt16(byte_0, num3 + 5);
					num5 = byte_0[num3 + 7];
					num8 = num11;
				}
				else
				{
					num = BitConverter.ToUInt16(byte_0, num3 + 1);
					num2 = worksheetCollection_0.method_32().method_12(num);
					if (num2 != int_2)
					{
						num3 += 7;
						break;
					}
					num8 = worksheetCollection_0.method_32().method_13(num);
					if (num8 < 0 || num8 >= worksheetCollection_1.Count)
					{
						num3 += 7;
						break;
					}
					num4 = BitConverter.ToUInt16(byte_0, num3 + 3);
					num5 = byte_0[num3 + 5];
				}
				cells = worksheetCollection_1[num8].Cells;
				cell = cells.CheckCell(num4, num5);
				if (cell != null)
				{
					Class1373 class2 = class1718_0.method_9(num8);
					class2.method_5(num4, num5, cell.Value);
				}
				num3 = ((!bool_0) ? (num3 + 7) : (num3 + 9));
				break;
			case 59:
			case 91:
			case 123:
			{
				if (bool_0)
				{
					int num10 = BitConverter.ToUInt16(byte_0, num3 + 1);
					BitConverter.ToUInt16(byte_0, num3 + 3);
					num4 = BitConverter.ToUInt16(byte_0, num3 + 5);
					num6 = BitConverter.ToUInt16(byte_0, num3 + 7);
					num5 = byte_0[num3 + 9];
					num7 = byte_0[num3 + 11];
					num8 = num10;
				}
				else
				{
					num = BitConverter.ToUInt16(byte_0, num3 + 1);
					num2 = worksheetCollection_0.method_32().method_12(num);
					if (num2 != int_2)
					{
						num3 += 11;
						break;
					}
					num8 = worksheetCollection_0.method_32().method_13(num);
					if (num8 < 0 || num8 >= worksheetCollection_1.Count)
					{
						num3 += 11;
						break;
					}
					num4 = BitConverter.ToUInt16(byte_0, num3 + 3);
					num6 = BitConverter.ToUInt16(byte_0, num3 + 5);
					num5 = byte_0[num3 + 7];
					num7 = byte_0[num3 + 9];
				}
				cells = worksheetCollection_1[num8].Cells;
				for (int i = num4; i <= num6; i++)
				{
					Row row = cells.CheckRow(i);
					if (row == null)
					{
						continue;
					}
					for (int j = num5; j <= num7; j++)
					{
						cell = row.GetCellOrNull(j);
						if (cell != null)
						{
							Class1373 @class = class1718_0.method_9(num8);
							@class.method_5(i, j, cell.Value);
						}
					}
				}
				num3 = ((!bool_0) ? (num3 + 11) : (num3 + 13));
				break;
			}
			case 60:
			case 92:
			case 124:
				num3 = ((!bool_0) ? (num3 + 7) : (num3 + 9));
				break;
			case 61:
			case 93:
			case 125:
				num3 = ((!bool_0) ? (num3 + 11) : (num3 + 13));
				break;
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static int smethod_4(byte[] byte_0, int int_0, int int_1)
	{
		int num = 0;
		int num2 = int_0;
		if (num2 == -1)
		{
			num2 = 2;
			int_1 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		while (num2 < int_1)
		{
			switch (byte_0[num2])
			{
			case 1:
				num2 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num2++;
				break;
			case 23:
			{
				byte b = byte_0[num2 + 1];
				num2 = ((byte_0[num2 + 2] != 0) ? (num2 + (ushort)(b * 2 + 3)) : (num2 + (ushort)(b + 3)));
				break;
			}
			case 24:
				if (byte_0[num2 + 1] == 25)
				{
					num++;
					num2 += 14;
				}
				else
				{
					num2 = ((byte_0[num2 + 1] != 29) ? (num2 + 1) : (num2 + 6));
				}
				break;
			case 25:
				switch (byte_0[num2 + 1])
				{
				case 8:
					num2 += 4;
					break;
				case 1:
					num2 += 4;
					break;
				case 2:
					num2 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, num2 + 2);
					num2 += num3 + 5;
					break;
				}
				default:
					num2 += 4;
					break;
				case 64:
					num2 += 4;
					break;
				case 32:
					num2 += 4;
					break;
				case 16:
					num2 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num2 += 2;
				break;
			case 31:
				num2 += 9;
				break;
			case 32:
			case 64:
			case 96:
				num2 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num2 += 3;
				break;
			case 34:
			case 66:
			case 98:
				num2 += 4;
				break;
			case 35:
			case 67:
			case 99:
				num2 += 5;
				break;
			case 36:
			case 68:
			case 100:
				num2 += 5;
				break;
			case 37:
			case 69:
			case 101:
				num2 += 9;
				break;
			case 40:
			case 72:
			case 104:
				num2 += 7;
				break;
			case 41:
			case 73:
			case 105:
				num2 += 3;
				break;
			case 42:
			case 74:
			case 106:
				num2 += 5;
				break;
			case 43:
			case 75:
			case 107:
				num2 += 9;
				break;
			case 44:
			case 76:
			case 108:
				num2 += 5;
				break;
			case 45:
			case 77:
			case 109:
				num2 += 9;
				break;
			case 57:
			case 89:
			case 121:
				num2 += 7;
				break;
			case 58:
			case 90:
			case 122:
				num2 += 7;
				break;
			case 59:
			case 91:
			case 123:
				num2 += 11;
				break;
			case 60:
			case 92:
			case 124:
				num2 += 7;
				break;
			case 61:
			case 93:
			case 125:
				num2 += 11;
				break;
			default:
				return num;
			}
		}
		return num;
	}

	internal static byte[] smethod_5(byte[] byte_0, int int_0, int int_1, Worksheet worksheet_0)
	{
		int num = smethod_4(byte_0, int_0, int_1);
		if (num == 0)
		{
			return byte_0;
		}
		int num2 = int_0;
		byte[] array = new byte[byte_0.Length - num * 3];
		int num3 = 0;
		if (num2 == -1)
		{
			num2 = 2;
			int num4 = BitConverter.ToUInt16(byte_0, 0);
			int_1 = 2 + num4;
			num3 = 2;
			int num5 = (short)(num4 - num * 3);
			Array.Copy(BitConverter.GetBytes(num5), 0, array, 0, 2);
			if (int_1 <= byte_0.Length)
			{
				Array.Copy(byte_0, int_1, array, num5 + 2, byte_0.Length - int_1);
			}
		}
		int num6 = worksheet_0.method_2().method_32().method_8(worksheet_0.method_2().method_36(), worksheet_0.Index);
		byte[] array2 = new byte[3] { 91, 0, 0 };
		Array.Copy(BitConverter.GetBytes((ushort)num6), 0, array2, 1, 2);
		if (int_0 == -1)
		{
			num3 = 2;
		}
		while (num2 < int_1)
		{
			switch (byte_0[num2])
			{
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				array[num3++] = byte_0[num2++];
				break;
			case 23:
			{
				byte b2 = byte_0[num2 + 1];
				if (byte_0[num2 + 2] == 0)
				{
					Array.Copy(byte_0, num2, array, num3, b2 + 3);
					num3 += b2 + 3;
					num2 += (ushort)(b2 + 3);
				}
				else
				{
					Array.Copy(byte_0, num2, array, num3, b2 * 2 + 3);
					num3 += b2 * 2 + 3;
					num2 += (ushort)(b2 * 2 + 3);
				}
				break;
			}
			case 24:
				if (byte_0[num2 + 1] == 25)
				{
					int int_2 = BitConverter.ToInt32(byte_0, num2 + 6);
					int num8 = BitConverter.ToUInt16(byte_0, num2 + 10);
					ListObject listObject = worksheet_0.ListObjects.method_3(int_2);
					if (listObject != null && num8 < listObject.ListColumns.Count)
					{
						Array.Copy(array2, 0, array, num3, 3);
						if ((byte_0[num2 + 5] & 8u) != 0)
						{
							array[num3] = 123;
						}
						else if ((byte_0[num2 + 5] & 4u) != 0)
						{
							array[num3] = 91;
						}
						else
						{
							array[num3] = 59;
						}
						int num9 = listObject.StartColumn + num8;
						int num10 = listObject.StartRow;
						if (listObject.method_48() > 0)
						{
							num10++;
						}
						int num11 = listObject.EndRow;
						if (listObject.method_19())
						{
							num11--;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num10), 0, array, num3 + 3, 2);
						Array.Copy(BitConverter.GetBytes((ushort)num11), 0, array, num3 + 5, 2);
						array[num3 + 7] = (byte)num9;
						array[num3 + 9] = (byte)num9;
					}
					else
					{
						array[num3] = 61;
					}
					num3 += 11;
					num2 += 14;
				}
				else if (byte_0[num2 + 1] == 29)
				{
					Array.Copy(byte_0, num2, array, num3, 6);
					num3 += 6;
					num2 += 6;
				}
				else
				{
					array[num3++] = byte_0[num2++];
				}
				break;
			case 25:
			{
				byte b = byte_0[num2 + 1];
				if (b == 4)
				{
					ushort num7 = BitConverter.ToUInt16(byte_0, num2 + 2);
					Array.Copy(byte_0, num2, array, num3, num7 + 53);
					num3 += num7 + 5;
					num2 += num7 + 5;
				}
				else
				{
					Array.Copy(byte_0, num2, array, num3, 4);
					num3 += 4;
					num2 += 4;
				}
				break;
			}
			case 28:
			case 29:
				Array.Copy(byte_0, num2, array, num3, 2);
				num3 += 2;
				num2 += 2;
				break;
			case 32:
			case 64:
			case 96:
				Array.Copy(byte_0, num2, array, num3, 8);
				num3 += 8;
				num2 += 8;
				break;
			case 34:
			case 66:
			case 98:
				Array.Copy(byte_0, num2, array, num3, 4);
				num3 += 4;
				num2 += 4;
				break;
			case 30:
			case 33:
			case 41:
			case 65:
			case 73:
			case 97:
			case 105:
				Array.Copy(byte_0, num2, array, num3, 3);
				num3 += 3;
				num2 += 3;
				break;
			case 1:
			case 35:
			case 36:
			case 42:
			case 44:
			case 67:
			case 68:
			case 74:
			case 76:
			case 99:
			case 100:
			case 106:
			case 108:
				Array.Copy(byte_0, num2, array, num3, 5);
				num3 += 5;
				num2 += 5;
				break;
			case 31:
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				Array.Copy(byte_0, num2, array, num3, 9);
				num3 += 9;
				num2 += 9;
				break;
			case 40:
			case 57:
			case 58:
			case 60:
			case 72:
			case 89:
			case 90:
			case 92:
			case 104:
			case 121:
			case 122:
			case 124:
				Array.Copy(byte_0, num2, array, num3, 7);
				num3 += 7;
				num2 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				Array.Copy(byte_0, num2, array, num3, 11);
				num3 += 11;
				num2 += 11;
				break;
			case 26:
			case 27:
				array[num3++] = byte_0[num2++];
				return array;
			default:
				return array;
			}
		}
		return array;
	}

	internal static void smethod_6(byte[] byte_0, int int_0, int int_1, Cell cell_0)
	{
		int num = int_0;
		if (num == -1)
		{
			num = 2;
			int_1 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		int num2 = 0;
		Cell cell = null;
		Cells cells = cell_0.method_4();
		WorksheetCollection worksheetCollection = cells.method_19();
		while (num < int_1)
		{
			switch (byte_0[num])
			{
			default:
				return;
			case 1:
				num += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b * 2 + 3)) : (num + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num3 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
				num2 = BitConverter.ToUInt16(byte_0, num + 1) - 1;
				if (num2 < worksheetCollection.Names.Count && num2 >= 0)
				{
					Name name = worksheetCollection.Names[num2];
					if (name.method_2() != null)
					{
						smethod_6(name.method_2(), -1, -1, cell_0);
					}
				}
				num += 5;
				break;
			case 36:
			case 68:
			case 100:
			{
				int row = BitConverter.ToUInt16(byte_0, num + 1);
				int column = byte_0[num + 3];
				cells.CheckCell(row, column)?.method_1(cell_0);
				num += 5;
				break;
			}
			case 37:
			case 69:
			case 101:
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
				num += 5;
				break;
			case 45:
			case 77:
			case 109:
				num += 9;
				break;
			case 57:
			case 89:
			case 121:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection.method_32().method_12(num2) == worksheetCollection.method_36())
				{
					num2 = BitConverter.ToUInt16(byte_0, num + 3) - 1;
					if (num2 < worksheetCollection.Names.Count && num2 >= 0)
					{
						Name name2 = worksheetCollection.Names[num2];
						if (name2.method_2() != null)
						{
							smethod_6(name2.method_2(), -1, -1, cell_0);
						}
					}
				}
				num += 7;
				break;
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num2 = worksheetCollection.method_32().method_13(num2);
				if (num2 >= 0 && num2 < worksheetCollection.Count)
				{
					int row = BitConverter.ToUInt16(byte_0, num + 3);
					int column = byte_0[num + 5];
					worksheetCollection[num2].Cells.CheckCell(row, column)?.method_1(cell_0);
					num += 7;
				}
				else
				{
					num += 7;
				}
				break;
			case 59:
			case 91:
			case 123:
				num += 11;
				break;
			case 60:
			case 92:
			case 124:
				num += 7;
				break;
			case 61:
			case 93:
			case 125:
				num += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_7(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0, int int_6, int int_7)
	{
		int num = int_6;
		if (num == -1)
		{
			num = 2;
			int_7 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		byte b = 0;
		while (num < int_7)
		{
			switch (byte_0[num])
			{
			default:
				return;
			case 1:
				if (int_1 != 0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, num + 1);
					num2 += int_1;
					if (num2 < 0)
					{
						num2 = 0;
					}
					else if (num2 > 65535)
					{
						num2 = 65535;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 1, 2);
				}
				if (int_4 != 0)
				{
					int num3 = byte_0[num + 3];
					num3 += int_4;
					if (num3 < 0)
					{
						num3 = 0;
					}
					else if (num3 > 255)
					{
						num3 = 255;
					}
					byte_0[num + 3] = (byte)num3;
				}
				num += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b2 = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b2 * 2 + 3)) : (num + (ushort)(b2 + 3)));
				break;
			}
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num4 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num4 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
				num += 5;
				break;
			case 36:
			case 68:
			case 100:
				b = byte_0[num + 4];
				if (int_1 != 0 && (b & 0x80u) != 0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, num + 1);
					num2 += int_1;
					if (num2 > 65535)
					{
						num2 = 65535;
					}
					else
					{
						if (num2 < 0)
						{
							byte_0[num] = (byte)(byte_0[num] + 6);
							num += 5;
							break;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 1, 2);
					}
				}
				if (int_4 != 0 && (b & 0x40u) != 0)
				{
					int num3 = byte_0[num + 3] + int_4;
					if (num3 < 0)
					{
						byte_0[num] = (byte)(byte_0[num] + 6);
						num += 5;
						break;
					}
					if (num3 > 255)
					{
						num3 = 255;
					}
					byte_0[num + 3] = (byte)num3;
				}
				num += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (int_1 != 0)
				{
					b = byte_0[num + 6];
					if ((b & 0x80u) != 0)
					{
						int num2 = BitConverter.ToUInt16(byte_0, num + 1);
						num2 += int_1;
						if (num2 > 65535)
						{
							num2 = 65535;
						}
						else if (num2 < 0)
						{
							num2 = 0;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 1, 2);
					}
					b = byte_0[num + 8];
					if ((b & 0x80u) != 0)
					{
						int num2 = BitConverter.ToUInt16(byte_0, num + 3);
						num2 += int_1;
						if (num2 > 65535)
						{
							num2 = 65535;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 3, 2);
					}
				}
				if (int_4 != 0)
				{
					b = byte_0[num + 6];
					if ((b & 0x40u) != 0)
					{
						int num3 = byte_0[num + 5] + int_4;
						if (num3 < 0)
						{
							byte_0[num] = (byte)(byte_0[num] + 6);
							num += 9;
							break;
						}
						if (num3 > 255)
						{
							num3 = 255;
						}
						byte_0[num + 5] = (byte)num3;
					}
					b = byte_0[num + 8];
					if ((b & 0x40u) != 0)
					{
						int num3 = byte_0[num + 7] + int_4;
						if (num3 < 0)
						{
							num3 = 0;
						}
						else if (num3 > 255)
						{
							num3 = 255;
						}
						byte_0[num + 7] = (byte)num3;
					}
				}
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
				num += 5;
				break;
			case 45:
			case 77:
			case 109:
				num += 9;
				break;
			case 57:
			case 89:
			case 121:
				num += 7;
				break;
			case 58:
			case 90:
			case 122:
				if (int_1 != 0 && smethod_28(byte_0[num + 6]))
				{
					int num2 = BitConverter.ToUInt16(byte_0, num + 3);
					num2 += int_1;
					if (num2 > 65535)
					{
						num2 = 65535;
					}
					else if (num2 < 0)
					{
						num2 = 0;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 3, 2);
				}
				if (int_4 != 0 && smethod_29(byte_0[num + 6]))
				{
					int num3 = byte_0[num + 5];
					num3 += int_4;
					if (num3 < 0)
					{
						byte_0[num] = (byte)(byte_0[num] + 2);
						num += 7;
						break;
					}
					if (num3 > 255)
					{
						num3 = 255;
					}
					byte_0[num + 5] = (byte)num3;
				}
				num += 7;
				break;
			case 59:
			case 91:
			case 123:
				if (int_1 != 0)
				{
					if (smethod_28(byte_0[num + 8]))
					{
						int num2 = BitConverter.ToUInt16(byte_0, num + 3);
						num2 += int_1;
						if (num2 > 65535)
						{
							num2 = 65535;
						}
						else if (num2 < 0)
						{
							num2 = 0;
						}
						else if (num2 < int_2 && int_1 < 0)
						{
							num2 = int_2;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 3, 2);
					}
					if (smethod_28(byte_0[num + 10]))
					{
						int num2 = BitConverter.ToUInt16(byte_0, num + 5);
						if (num2 != 65535)
						{
							num2 += int_1;
							if (num2 > 65535)
							{
								num2 = 65535;
							}
							if (num2 < int_2 && int_1 < 0)
							{
								num2 = int_2;
							}
							Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, num + 5, 2);
						}
					}
				}
				if (int_4 != 0)
				{
					if (smethod_29(byte_0[num + 8]))
					{
						int num3 = byte_0[num + 7];
						num3 += int_4;
						if (num3 < 0)
						{
							byte_0[num] = (byte)(byte_0[num] + 2);
							num += 11;
							break;
						}
						if (num3 > 255)
						{
							num3 = 255;
						}
						byte_0[num + 7] = (byte)num3;
					}
					if (smethod_29(byte_0[num + 10]))
					{
						int num3 = byte_0[num + 9];
						num3 += int_4;
						if (num3 > 255)
						{
							num3 = 255;
						}
						if (num3 < int_5)
						{
							num3 = int_5;
						}
						byte_0[num + 9] = (byte)num3;
					}
				}
				num += 11;
				break;
			case 60:
			case 92:
			case 124:
				num += 7;
				break;
			case 61:
			case 93:
			case 125:
				num += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static bool smethod_8(Hashtable hashtable_0, Hashtable hashtable_1, Worksheet worksheet_0, Worksheet worksheet_1, Hashtable hashtable_2, int int_0, int int_1, int int_2, byte[] byte_0)
	{
		WorksheetCollection worksheetCollection = worksheet_0.method_2();
		WorksheetCollection worksheetCollection2 = worksheet_1.method_2();
		bool flag = worksheetCollection != worksheetCollection2;
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			case 1:
			case 2:
				int_1 += 7;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				int num7 = BitConverter.ToUInt16(byte_0, int_1 + 1);
				int_1 += num7 * 2 + 3;
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num2 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 15;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num3 = BitConverter.ToUInt16(byte_0, int_1 + 1) - 1;
				int num4 = -1;
				if (hashtable_1[num3] != null)
				{
					num4 = (int)hashtable_1[num3] + 1;
				}
				else if (flag)
				{
					Name name = worksheetCollection.Names[num3];
					if (name.SheetIndex != -1)
					{
						return false;
					}
					int int_3 = worksheet_1.Index;
					if (worksheetCollection2.Names.method_8(name.Text, -1, bool_0: false) == -1)
					{
						int_3 = -1;
					}
					int num5 = worksheetCollection2.Names.method_0(int_3, name.method_16());
					Name name2 = worksheetCollection2.Names[num5];
					name2.method_29(name);
					hashtable_1.Add(num3, num5);
					num4 = num5 + 1;
				}
				Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_1 + 1, 2);
				int_1 += 5;
				break;
			}
			case 36:
			case 68:
			case 100:
				int_1 += 5;
				break;
			case 37:
			case 69:
			case 101:
				int_1 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_1 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_1 += 9;
				break;
			case 44:
			case 76:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (flag)
					{
						int num6 = worksheetCollection.method_32().method_12(num);
						if (worksheetCollection.method_36() == num6)
						{
							return false;
						}
						num = Class1377.smethod_0(num, worksheetCollection, worksheetCollection2, hashtable_0, hashtable_2);
						if (num == -1)
						{
							return false;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 7;
				break;
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (flag)
					{
						num = Class1377.smethod_0(num, worksheetCollection, worksheetCollection2, hashtable_0, hashtable_2);
						if (num == -1)
						{
							num = int_0;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (flag)
					{
						num = Class1377.smethod_0(num, worksheetCollection, worksheetCollection2, hashtable_0, hashtable_2);
						if (num == -1)
						{
							num = int_0;
						}
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 11;
				break;
			default:
				return false;
			}
		}
		return true;
	}

	internal static void smethod_9(Hashtable hashtable_0, bool bool_0, int int_0, int int_1, int int_2, byte[] byte_0)
	{
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			default:
				return;
			case 1:
				int_1 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				byte b = byte_0[int_1 + 1];
				int_1 = ((byte_0[int_1 + 2] != 0) ? (int_1 + (ushort)(b * 2 + 3)) : (int_1 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num2 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_1 += 5;
				break;
			case 36:
			case 68:
			case 100:
				int_1 += 5;
				break;
			case 37:
			case 69:
			case 101:
				int_1 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_1 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_1 += 9;
				break;
			case 44:
			case 76:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_1 += 7;
				break;
			case 58:
			case 90:
			case 122:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (!bool_0)
					{
						num = int_0;
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 7;
				break;
			case 59:
			case 91:
			case 123:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (!bool_0)
					{
						num = int_0;
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 11;
				break;
			case 60:
			case 92:
			case 124:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (!bool_0)
					{
						num = int_0;
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 7;
				break;
			case 61:
			case 93:
			case 125:
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (hashtable_0[num] == null)
				{
					if (!bool_0)
					{
						num = int_0;
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
					}
				}
				else
				{
					num = (int)hashtable_0[num];
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void InsertRows(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0)
	{
		if (int_4 == -1)
		{
			int_4 = 2;
			int_5 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		while (int_4 < int_5)
		{
			switch (byte_0[int_4])
			{
			default:
				return;
			case 1:
				if (bool_0)
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					if (int_7 >= int_0)
					{
						int_7 += int_1;
						if (int_7 > 65535)
						{
							int_7 = 65535;
						}
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_4++;
				break;
			case 23:
			{
				byte b = byte_0[int_4 + 1];
				int_4 = ((byte_0[int_4 + 2] != 0) ? (int_4 + (ushort)(b * 2 + 3)) : (int_4 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_4 + 1])
				{
				case 8:
					int_4 += 4;
					break;
				case 1:
					int_4 += 4;
					break;
				case 2:
					int_4 += 4;
					break;
				case 4:
				{
					ushort num = BitConverter.ToUInt16(byte_0, int_4 + 4);
					int_4 += num + 4;
					break;
				}
				default:
					int_4 += 4;
					break;
				case 64:
					int_4 += 4;
					break;
				case 32:
					int_4 += 4;
					break;
				case 16:
					int_4 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_4 += 2;
				break;
			case 31:
				int_4 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_4 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_4 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_4 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_4 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					if (smethod_30(int_0, int_1, ref int_7, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					int int_8 = BitConverter.ToUInt16(byte_0, int_4 + 3);
					if (int_7 == 0 && int_8 == 65535)
					{
						int_4 += 9;
						break;
					}
					if (smethod_31(int_0, int_1, ref int_7, ref int_8, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
						Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 3, 2);
					}
				}
				int_4 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_4 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_4 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_4 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_4 += 9;
				break;
			case 44:
			case 76:
			case 108:
				if (bool_0)
				{
					bool flag;
					int int_7 = ((!(flag = smethod_28(byte_0[int_4 + 4]))) ? BitConverter.ToUInt16(byte_0, int_4 + 1) : (BitConverter.ToInt16(byte_0, int_4 + 1) + int_2));
					if (smethod_30(int_0, int_1, ref int_7, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else if (flag)
					{
						Array.Copy(BitConverter.GetBytes((short)(int_7 - int_3)), 0, byte_0, int_4 + 1, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 45:
			case 77:
			case 109:
				if (bool_0)
				{
					bool flag2 = smethod_28(byte_0[int_4 + 6]);
					bool flag3 = smethod_28(byte_0[int_4 + 8]);
					int int_7 = ((!flag2) ? BitConverter.ToUInt16(byte_0, int_4 + 1) : (BitConverter.ToInt16(byte_0, int_4 + 1) + int_2));
					int int_8 = ((!flag3) ? BitConverter.ToUInt16(byte_0, int_4 + 3) : (BitConverter.ToInt16(byte_0, int_4 + 3) + int_2));
					if (smethod_31(int_0, int_1, ref int_7, ref int_8, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else
					{
						if (flag2)
						{
							Array.Copy(BitConverter.GetBytes((short)(int_7 - int_3)), 0, byte_0, int_4 + 1, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
						}
						if (flag3)
						{
							Array.Copy(BitConverter.GetBytes((short)(int_8 - int_3)), 0, byte_0, int_4 + 3, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 3, 2);
						}
					}
				}
				int_4 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_4 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) != worksheet_0.Index)
				{
					int_4 += 7;
					break;
				}
				int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 3);
				if (smethod_30(int_0, int_1, ref int_7, 65535))
				{
					byte_0[int_4] = (byte)(byte_0[int_4] + 2);
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 3, 2);
				}
				int_4 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) != worksheet_0.Index)
				{
					int_4 += 11;
					break;
				}
				int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 3);
				int int_8 = BitConverter.ToUInt16(byte_0, int_4 + 5);
				if (int_7 == 0 && int_8 == 65535)
				{
					int_4 += 11;
					break;
				}
				if (smethod_31(int_0, int_1, ref int_7, ref int_8, 65535))
				{
					byte_0[int_4] = (byte)(byte_0[int_4] + 2);
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 3, 2);
					Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 5, 2);
				}
				int_4 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_4 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_4 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_10(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, ref byte[] byte_0)
	{
		if (int_4 == -1)
		{
			int_4 = 2;
			int_5 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		while (int_4 < int_5)
		{
			switch (byte_0[int_4])
			{
			default:
				return;
			case 1:
				if (bool_0)
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					if (int_7 >= int_0)
					{
						int_7 += int_1;
						if (int_7 > 65535)
						{
							int_7 = 65535;
						}
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_4++;
				break;
			case 23:
			{
				byte b = byte_0[int_4 + 1];
				int_4 = ((byte_0[int_4 + 2] != 0) ? (int_4 + (ushort)(b * 2 + 3)) : (int_4 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_4 + 1])
				{
				case 8:
					int_4 += 4;
					break;
				case 1:
					int_4 += 4;
					break;
				case 2:
					int_4 += 4;
					break;
				case 4:
				{
					ushort num = BitConverter.ToUInt16(byte_0, int_4 + 2);
					int_4 += num + 5;
					break;
				}
				default:
					int_4 += 4;
					break;
				case 64:
					int_4 += 4;
					break;
				case 32:
					int_4 += 4;
					break;
				case 16:
					int_4 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_4 += 2;
				break;
			case 31:
				int_4 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_4 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_4 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_4 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_4 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0 & smethod_28(byte_0[int_4 + 4]))
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					if (smethod_30(int_0, int_1, ref int_7, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 1);
					int int_8 = BitConverter.ToUInt16(byte_0, int_4 + 3);
					if (smethod_32(int_0, int_1, ref int_7, byte_0[int_4 + 6], ref int_8, byte_0[int_4 + 8], 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
						Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 3, 2);
					}
				}
				int_4 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_4 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_4 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_4 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_4 += 9;
				break;
			case 44:
			case 76:
			case 108:
				if (bool_0)
				{
					bool flag;
					int int_7 = ((!(flag = smethod_28(byte_0[int_4 + 4]))) ? BitConverter.ToUInt16(byte_0, int_4 + 1) : (BitConverter.ToInt16(byte_0, int_4 + 1) + int_2));
					if (smethod_30(int_0, int_1, ref int_7, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else if (flag)
					{
						Array.Copy(BitConverter.GetBytes((short)(int_7 - int_3)), 0, byte_0, int_4 + 1, 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
					}
				}
				int_4 += 5;
				break;
			case 45:
			case 77:
			case 109:
				if (bool_0)
				{
					bool flag2 = smethod_28(byte_0[int_4 + 6]);
					bool flag3 = smethod_28(byte_0[int_4 + 8]);
					int int_7 = ((!flag2) ? BitConverter.ToUInt16(byte_0, int_4 + 1) : (BitConverter.ToInt16(byte_0, int_4 + 1) + int_2));
					int int_8 = ((!flag3) ? BitConverter.ToUInt16(byte_0, int_4 + 3) : (BitConverter.ToInt16(byte_0, int_4 + 3) + int_2));
					if (smethod_31(int_0, int_1, ref int_7, ref int_8, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else
					{
						if (flag2)
						{
							Array.Copy(BitConverter.GetBytes((short)(int_7 - int_3)), 0, byte_0, int_4 + 1, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 1, 2);
						}
						if (flag3)
						{
							Array.Copy(BitConverter.GetBytes((short)(int_8 - int_3)), 0, byte_0, int_4 + 3, 2);
						}
						else
						{
							Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 3, 2);
						}
					}
				}
				int_4 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_4 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) == worksheet_0.Index && smethod_28(byte_0[int_4 + 6]))
				{
					int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 3);
					if (smethod_30(int_0, int_1, ref int_7, 65535))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 2);
					}
					else
					{
						Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 3, 2);
					}
					int_4 += 7;
				}
				else
				{
					int_4 += 7;
				}
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) != worksheet_0.Index)
				{
					int_4 += 11;
					break;
				}
				int int_7 = BitConverter.ToUInt16(byte_0, int_4 + 3);
				int int_8 = BitConverter.ToUInt16(byte_0, int_4 + 5);
				if (smethod_32(int_0, int_1, ref int_7, byte_0[int_4 + 8], ref int_8, byte_0[int_4 + 10], 65535))
				{
					byte_0[int_4] = (byte)(byte_0[int_4] + 2);
				}
				else
				{
					Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, byte_0, int_4 + 3, 2);
					Array.Copy(BitConverter.GetBytes((ushort)int_8), 0, byte_0, int_4 + 5, 2);
				}
				int_4 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_4 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_4 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void InsertColumns(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0)
	{
		if (int_4 == -1)
		{
			int_4 = 2;
			int_5 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		int num = 0;
		while (int_4 < int_5)
		{
			switch (byte_0[int_4])
			{
			default:
				return;
			case 1:
				if (bool_0)
				{
					int int_7 = byte_0[int_4 + 3];
					if (int_7 >= int_0)
					{
						int_7 += int_1;
						if (int_7 > 255)
						{
							int_7 = 255;
						}
						byte_0[int_4 + 3] = (byte)int_7;
					}
				}
				int_4 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_4++;
				break;
			case 23:
			{
				byte b = byte_0[int_4 + 1];
				int_4 = ((byte_0[int_4 + 2] != 0) ? (int_4 + (ushort)(b * 2 + 3)) : (int_4 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_4 + 1])
				{
				case 8:
					int_4 += 4;
					break;
				case 1:
					int_4 += 4;
					break;
				case 2:
					int_4 += 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_4 + 4);
					int_4 += num2 + 4;
					break;
				}
				default:
					int_4 += 4;
					break;
				case 64:
					int_4 += 4;
					break;
				case 32:
					int_4 += 4;
					break;
				case 16:
					int_4 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_4 += 2;
				break;
			case 31:
				int_4 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_4 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_4 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_4 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_4 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int int_7 = byte_0[int_4 + 3];
					if (smethod_30(int_0, int_1, ref int_7, 255))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						byte_0[int_4 + 3] = (byte)int_7;
					}
				}
				int_4 += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					int int_7 = byte_0[int_4 + 5];
					num = byte_0[int_4 + 7];
					if (int_7 == 0 && num == 255)
					{
						int_4 += 9;
						break;
					}
					if (smethod_31(int_0, int_1, ref int_7, ref num, 255))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] + 6);
					}
					else
					{
						byte_0[int_4 + 5] = (byte)int_7;
						byte_0[int_4 + 7] = (byte)num;
					}
				}
				int_4 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_4 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_4 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_4 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_4 += 9;
				break;
			case 44:
			case 76:
			case 108:
				if (bool_0)
				{
					bool flag3 = smethod_29(byte_0[int_4 + 4]);
					int int_7 = byte_0[int_4 + 3];
					if (flag3)
					{
						int_7 = ((int_7 >= 127) ? (int_7 - 255 - 1 + int_2) : (int_7 + int_2));
					}
					if (smethod_30(int_0, int_1, ref int_7, 255))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else if (flag3)
					{
						if (int_7 > int_3)
						{
							byte_0[int_4 + 3] = (byte)(int_7 - int_3);
						}
						else
						{
							byte_0[int_4 + 3] = (byte)(255 - int_3 + int_7 + 1);
						}
					}
					else
					{
						byte_0[int_4 + 3] = (byte)int_7;
					}
				}
				int_4 += 5;
				break;
			case 45:
			case 77:
			case 109:
				if (bool_0)
				{
					bool flag = smethod_29(byte_0[int_4 + 6]);
					bool flag2 = smethod_29(byte_0[int_4 + 8]);
					int int_7 = byte_0[int_4 + 5];
					if (flag)
					{
						int_7 = byte_0[int_4 + 5];
						int_7 = ((int_7 >= 127) ? (int_7 - 255 - 1 + int_2) : (int_7 + int_2));
					}
					num = byte_0[int_4 + 7];
					if (flag)
					{
						num = ((num >= 127) ? (num - 255 - 1 + int_2) : (num + int_2));
					}
					if (smethod_31(int_0, int_1, ref int_7, ref num, 255))
					{
						byte_0[int_4] = (byte)(byte_0[int_4] - 2);
					}
					else
					{
						if (flag)
						{
							if (int_7 > int_3)
							{
								byte_0[int_4 + 5] = (byte)(int_7 - int_3);
							}
							else
							{
								byte_0[int_4 + 5] = (byte)(255 - int_3 + int_7 + 1);
							}
						}
						else
						{
							byte_0[int_4 + 5] = (byte)int_7;
						}
						if (flag2)
						{
							if (num > int_3)
							{
								byte_0[int_4 + 7] = (byte)(num - int_3);
							}
							else
							{
								byte_0[int_4 + 7] = (byte)(255 - int_3 + num + 1);
							}
						}
						else
						{
							byte_0[int_4 + 7] = (byte)num;
						}
					}
				}
				int_4 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_4 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) != worksheet_0.Index)
				{
					int_4 += 7;
					break;
				}
				int int_7 = byte_0[int_4 + 5];
				if (smethod_30(int_0, int_1, ref int_7, 255))
				{
					byte_0[int_4] = (byte)(byte_0[int_4] + 2);
				}
				else
				{
					byte_0[int_4 + 5] = (byte)int_7;
				}
				int_4 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				int int_6 = BitConverter.ToUInt16(byte_0, int_4 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_6) != worksheet_0.Index)
				{
					int_4 += 11;
					break;
				}
				int int_7 = byte_0[int_4 + 7];
				num = byte_0[int_4 + 9];
				if (int_7 == 0 && num == 255)
				{
					int_4 += 11;
					break;
				}
				if (smethod_31(int_0, int_1, ref int_7, ref num, 255))
				{
					byte_0[int_4] = (byte)(byte_0[int_4] + 2);
				}
				else
				{
					byte_0[int_4 + 7] = (byte)int_7;
					byte_0[int_4 + 9] = (byte)num;
				}
				int_4 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_4 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_4 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static bool GetPrecedents(byte[] byte_0, int int_0, int int_1, int int_2, int int_3, WorksheetCollection worksheetCollection_0, Cells cells_0, ReferredAreaCollection referredAreaCollection_0, bool bool_0, string string_0, string string_1)
	{
		int num = int_0;
		if (num == -1)
		{
			num = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num2 = 0;
		int num3 = -1;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		ReferredArea referredArea = null;
		while (num < int_1)
		{
			switch (byte_0[num])
			{
			case 1:
			{
				num5 = BitConverter.ToUInt16(byte_0, num + 1);
				num6 = byte_0[num + 3];
				Cell cell = cells_0.CheckCell(num5, num6);
				if (cell == null)
				{
					num += 5;
					break;
				}
				Class1348 class5 = cell.method_50();
				byte_0 = class5.Formula;
				return GetPrecedents(byte_0, -1, -1, int_2, int_3, worksheetCollection_0, cells_0, referredAreaCollection_0, bool_0, string_0, string_1);
			}
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b4 = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b4 * 2 + 3)) : (num + (ushort)(b4 + 3)));
				break;
			}
			case 24:
				num = ((byte_0[num + 1] != 25) ? ((byte_0[num + 1] != 29) ? (num + 1) : (num + 6)) : (num + 14));
				break;
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num9 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num9 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
				if (!bool_0)
				{
					int index2 = BitConverter.ToUInt16(byte_0, num + 1) - 1;
					Name name3 = worksheetCollection_0.Names[index2];
					byte[] array3 = name3.method_2();
					if (array3 != null)
					{
						GetPrecedents(array3, -1, -1, int_2, int_3, worksheetCollection_0, cells_0, referredAreaCollection_0, bool_0, string_0, string_1);
					}
				}
				num += 5;
				break;
			case 36:
			case 68:
			case 100:
				num5 = BitConverter.ToUInt16(byte_0, num + 1);
				num6 = byte_0[num + 3];
				referredArea = new ReferredArea(bool_0, string_0, string_1, num5, num6);
				referredAreaCollection_0.Add(referredArea);
				num += 5;
				break;
			case 37:
			case 69:
			case 101:
				num5 = BitConverter.ToUInt16(byte_0, num + 1);
				num7 = BitConverter.ToUInt16(byte_0, num + 3);
				num6 = byte_0[num + 5];
				num8 = byte_0[num + 7];
				referredArea = new ReferredArea(bool_0, string_0, string_1, num5, num6, num7, num8);
				referredAreaCollection_0.Add(referredArea);
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
			{
				ushort num12 = BitConverter.ToUInt16(byte_0, num + 1);
				byte b3 = byte_0[num + 3];
				num5 = (((byte_0[num + 4] & 0x80u) != 0) ? ((ushort)(int_2 + num12)) : num12);
				num6 = (((byte_0[num + 4] & 0x40u) != 0) ? ((byte)(int_3 + b3)) : b3);
				referredArea = new ReferredArea(bool_0, string_0, string_1, num5, num6);
				referredAreaCollection_0.Add(referredArea);
				num += 5;
				break;
			}
			case 45:
			case 77:
			case 109:
			{
				ushort num10 = BitConverter.ToUInt16(byte_0, num + 1);
				ushort num11 = BitConverter.ToUInt16(byte_0, num + 3);
				byte b = byte_0[num + 5];
				byte b2 = byte_0[num + 7];
				num5 = (((byte_0[6] & 0x80u) != 0) ? ((ushort)(int_2 + num10)) : num10);
				num6 = (((byte_0[6] & 0x40u) != 0) ? ((byte)(int_3 + b)) : b);
				num7 = (((byte_0[8] & 0x80u) != 0) ? ((ushort)(int_2 + num11)) : num11);
				num8 = (((byte_0[8] & 0x40u) != 0) ? ((byte)(int_3 + b2)) : b2);
				referredArea = new ReferredArea(bool_0, string_0, string_1, num5, num6, num7, num8);
				referredAreaCollection_0.Add(referredArea);
				num += 9;
				break;
			}
			case 57:
			case 89:
			case 121:
			{
				if (bool_0)
				{
					num += 7;
					break;
				}
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num4 = worksheetCollection_0.method_32().method_12(num2);
				num3 = worksheetCollection_0.method_32().method_13(num2);
				int index = BitConverter.ToUInt16(byte_0, num + 3) - 1;
				Class1718 class2 = worksheetCollection_0.method_39()[num4];
				Class1653 class3 = (Class1653)class2.method_0()[index];
				GetPrecedents(class3.method_5(), -1, -1, int_2, int_3, worksheetCollection_0, cells_0, referredAreaCollection_0, bool_0: true, class2.method_18(), string_1);
				num += 7;
				break;
			}
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num4 = worksheetCollection_0.method_32().method_12(num2);
				num3 = worksheetCollection_0.method_32().method_13(num2);
				num5 = BitConverter.ToUInt16(byte_0, num + 3);
				num6 = byte_0[num + 5];
				if (!bool_0 && num4 == worksheetCollection_0.method_36())
				{
					if (num3 < 0 || num3 > worksheetCollection_0.Count)
					{
						num += 7;
						break;
					}
					string name2 = worksheetCollection_0[num3].Name;
					referredArea = new ReferredArea(bool_2: false, string_0, name2, num5, num6);
					referredAreaCollection_0.Add(referredArea);
				}
				else
				{
					Class1718 class4 = worksheetCollection_0.method_39()[num4];
					string[] array2 = class4.method_4();
					if (array2 == null || num3 < 0 || num3 >= array2.Length)
					{
						num += 7;
						break;
					}
					string string_3 = array2[num3];
					referredArea = new ReferredArea(bool_2: true, class4.method_18(), string_3, num5, num6);
					referredAreaCollection_0.Add(referredArea);
				}
				num += 7;
				break;
			case 59:
			case 91:
			case 123:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				num4 = worksheetCollection_0.method_32().method_12(num2);
				num3 = worksheetCollection_0.method_32().method_13(num2);
				num5 = BitConverter.ToUInt16(byte_0, num + 3);
				num7 = BitConverter.ToUInt16(byte_0, num + 5);
				num6 = byte_0[num + 7];
				num8 = byte_0[num + 9];
				if (!bool_0 && num4 == worksheetCollection_0.method_36())
				{
					if (num3 < 0 || num3 > worksheetCollection_0.Count)
					{
						num += 11;
						break;
					}
					string name = worksheetCollection_0[num3].Name;
					referredArea = new ReferredArea(bool_2: false, string_0, name, num5, num6, num7, num8);
					referredAreaCollection_0.Add(referredArea);
				}
				else
				{
					Class1718 @class = worksheetCollection_0.method_39()[num4];
					string[] array = worksheetCollection_0.method_39()[num4].method_4();
					if (array == null || num3 < 0 || num3 >= array.Length)
					{
						num += 11;
						break;
					}
					string string_2 = array[num3];
					referredArea = new ReferredArea(bool_2: true, @class.method_18(), string_2, num5, num6, num7, num8);
					referredAreaCollection_0.Add(referredArea);
				}
				num += 11;
				break;
			case 60:
			case 92:
			case 124:
				num += 7;
				break;
			case 61:
			case 93:
			case 125:
				num += 11;
				break;
			default:
				return false;
			}
		}
		return false;
	}

	internal static bool GetDependents(int int_0, int int_1, byte[] byte_0, int int_2, int int_3, int int_4, int int_5, int int_6, Cells cells_0, bool bool_0, Hashtable hashtable_0)
	{
		cells_0.method_19();
		int num = int_2;
		if (num == -1)
		{
			num = 2;
			int_3 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		while (num < int_3)
		{
			switch (byte_0[num])
			{
			case 1:
			{
				num3 = BitConverter.ToUInt16(byte_0, num + 1);
				num4 = byte_0[num + 3];
				Cell cell = cells_0.CheckCell(num3, num4);
				if (cell == null)
				{
					num += 5;
					break;
				}
				Class1348 @class = cell.method_50();
				byte_0 = @class.Formula;
				return GetDependents(int_0, int_1, byte_0, -1, -1, int_4, int_5, int_6, cells_0, bool_0, hashtable_0);
			}
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b * 2 + 3)) : (num + (ushort)(b + 3)));
				break;
			}
			case 24:
				num = ((byte_0[num + 1] != 25) ? ((byte_0[num + 1] != 29) ? (num + 1) : (num + 6)) : (num + 14));
				break;
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num8 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num8 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num7 = BitConverter.ToUInt16(byte_0, num + 1) - 1;
				if (hashtable_0[num7] == null)
				{
					num += 5;
					break;
				}
				return true;
			}
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					num3 = BitConverter.ToUInt16(byte_0, num + 1);
					num4 = byte_0[num + 3];
					if (num3 == int_4 && num4 == int_5)
					{
						return true;
					}
				}
				num += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					num3 = BitConverter.ToUInt16(byte_0, num + 1);
					num5 = BitConverter.ToUInt16(byte_0, num + 3);
					num4 = byte_0[num + 5];
					num6 = byte_0[num + 7];
					if (int_4 >= num3 && int_4 <= num5 && int_5 >= num4 && int_5 <= num6)
					{
						return true;
					}
				}
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
				if (bool_0)
				{
					num3 = Class932.smethod_1(byte_0, num + 1, int_0, byte_0[num + 4]);
					num4 = Class932.smethod_2(byte_0, num + 3, int_1, byte_0[num + 4]);
					if (num3 == int_4 && num4 == int_5)
					{
						return true;
					}
				}
				num += 5;
				break;
			case 45:
			case 77:
			case 109:
				if (bool_0)
				{
					num3 = Class932.smethod_1(byte_0, num + 1, int_0, byte_0[num + 6]);
					num5 = Class932.smethod_1(byte_0, num + 3, int_0, byte_0[num + 8]);
					num4 = Class932.smethod_2(byte_0, num + 5, int_1, byte_0[num + 6]);
					num6 = Class932.smethod_2(byte_0, num + 7, int_1, byte_0[num + 8]);
					if (int_4 >= num3 && int_4 <= num5 && int_5 >= num4 && int_5 <= num6)
					{
						return true;
					}
				}
				num += 9;
				break;
			case 57:
			case 89:
			case 121:
				num += 7;
				break;
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (num2 == int_6)
				{
					num3 = BitConverter.ToUInt16(byte_0, num + 3);
					num4 = byte_0[num + 5];
					if (num3 == int_4 && num4 == int_5)
					{
						return true;
					}
				}
				num += 7;
				break;
			case 59:
			case 91:
			case 123:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (int_6 == num2)
				{
					num3 = BitConverter.ToUInt16(byte_0, num + 3);
					num5 = BitConverter.ToUInt16(byte_0, num + 5);
					num4 = byte_0[num + 7];
					num6 = byte_0[num + 9];
					if (int_4 >= num3 && int_4 <= num5 && int_5 >= num4 && int_5 <= num6)
					{
						return true;
					}
				}
				num += 11;
				break;
			case 60:
			case 92:
			case 124:
				num += 7;
				break;
			case 61:
			case 93:
			case 125:
				num += 11;
				break;
			default:
				return false;
			}
		}
		return false;
	}

	internal static bool smethod_11(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0)
	{
		int num = int_0;
		if (num == -1)
		{
			num = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num2 = 0;
		while (num < int_1)
		{
			switch (byte_0[num])
			{
			case 1:
				num += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b * 2 + 3)) : (num + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num3 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
				num += 5;
				break;
			case 36:
			case 68:
			case 100:
				num += 5;
				break;
			case 37:
			case 69:
			case 101:
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
				num += 5;
				break;
			case 45:
			case 77:
			case 109:
				num += 9;
				break;
			case 57:
			case 89:
			case 121:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection_0.method_32().method_12(num2) == worksheetCollection_0.method_36())
				{
					num += 7;
					break;
				}
				return true;
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection_0.method_32().method_12(num2) == worksheetCollection_0.method_36())
				{
					num += 7;
					break;
				}
				return true;
			case 59:
			case 91:
			case 123:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection_0.method_32().method_12(num2) == worksheetCollection_0.method_36())
				{
					num += 11;
					break;
				}
				return true;
			case 60:
			case 92:
			case 124:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection_0.method_32().method_12(num2) == worksheetCollection_0.method_36())
				{
					num += 7;
					break;
				}
				return true;
			case 61:
			case 93:
			case 125:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (worksheetCollection_0.method_32().method_12(num2) == worksheetCollection_0.method_36())
				{
					num += 11;
					break;
				}
				return true;
			default:
				return false;
			}
		}
		return false;
	}

	internal static bool smethod_12(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		int num = int_0;
		if (num == -1)
		{
			num = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num2 = 0;
		while (num < int_1)
		{
			switch (byte_0[num])
			{
			case 1:
				num += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				num++;
				break;
			case 23:
			{
				byte b = byte_0[num + 1];
				num = ((byte_0[num + 2] != 0) ? (num + (ushort)(b * 2 + 3)) : (num + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[num + 1])
				{
				case 8:
					num += 4;
					break;
				case 1:
					num += 4;
					break;
				case 2:
					num += 4;
					break;
				case 4:
				{
					ushort num4 = BitConverter.ToUInt16(byte_0, num + 2);
					num += num4 + 5;
					break;
				}
				default:
					num += 4;
					break;
				case 64:
					num += 4;
					break;
				case 32:
					num += 4;
					break;
				case 16:
					num += 4;
					break;
				}
				break;
			case 28:
			case 29:
				num += 2;
				break;
			case 31:
				num += 9;
				break;
			case 32:
			case 64:
			case 96:
				num += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				num += 3;
				break;
			case 34:
			case 66:
			case 98:
				num += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num3 = BitConverter.ToUInt16(byte_0, num + 1) - 1;
				if (hashtable_1[num3] == null || !(bool)hashtable_1[num3])
				{
					num += 5;
					break;
				}
				return true;
			}
			case 36:
			case 68:
			case 100:
				num += 5;
				break;
			case 37:
			case 69:
			case 101:
				num += 9;
				break;
			case 40:
			case 72:
			case 104:
				num += 7;
				break;
			case 41:
			case 73:
			case 105:
				num += 3;
				break;
			case 42:
			case 74:
			case 106:
				num += 5;
				break;
			case 43:
			case 75:
			case 107:
				num += 9;
				break;
			case 44:
			case 76:
			case 108:
				num += 5;
				break;
			case 45:
			case 77:
			case 109:
				num += 9;
				break;
			case 57:
			case 89:
			case 121:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (hashtable_0[num2] == null)
				{
					num += 7;
					break;
				}
				return true;
			case 58:
			case 90:
			case 122:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (hashtable_0[num2] == null)
				{
					num += 7;
					break;
				}
				return true;
			case 59:
			case 91:
			case 123:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (hashtable_0[num2] == null)
				{
					num += 11;
					break;
				}
				return true;
			case 60:
			case 92:
			case 124:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (hashtable_0[num2] == null)
				{
					num += 7;
					break;
				}
				return true;
			case 61:
			case 93:
			case 125:
				num2 = BitConverter.ToUInt16(byte_0, num + 1);
				if (hashtable_0[num2] == null)
				{
					num += 11;
					break;
				}
				return true;
			default:
				return false;
			}
		}
		return false;
	}

	internal static bool smethod_13(byte[] byte_0, int int_0, int int_1, int int_2)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num2 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num3 = BitConverter.ToUInt16(byte_0, int_0 + 1) - 1;
				if (num3 != int_2)
				{
					int_0 += 5;
					break;
				}
				return true;
			}
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
			{
				int num = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
				if (num != int_2)
				{
					int_0 += 7;
					break;
				}
				return true;
			}
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				int_0 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				int_0 += 11;
				break;
			default:
				return false;
			}
		}
		return false;
	}

	internal static void smethod_14(byte[] byte_0, int int_0, int int_1, bool[] bool_0)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			default:
				return;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num3 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1) - 1;
				bool_0[num2] = true;
				int_0 += 5;
				break;
			}
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
			{
				int num = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
				bool_0[num] = true;
				int_0 += 7;
				break;
			}
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				int_0 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				int_0 += 11;
				break;
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_15(byte[] byte_0, int int_0, int int_1, SortedList sortedList_0)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			default:
				return;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num2 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num2 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num3 = BitConverter.ToUInt16(byte_0, int_0 + 1) - 1;
				if (sortedList_0[num3] != null)
				{
					sortedList_0[num3] = true;
				}
				int_0 += 5;
				break;
			}
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
			{
				int num = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
				if (sortedList_0[num] != null)
				{
					sortedList_0[num] = true;
				}
				int_0 += 7;
				break;
			}
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				int_0 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				int_0 += 11;
				break;
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static ArrayList GetRanges(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, Cells cells_0)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		ArrayList arrayList = new ArrayList();
		Range range = null;
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num6 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num6 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_0 += 5;
				break;
			case 36:
			case 68:
			case 100:
			{
				int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int num4 = byte_0[int_0 + 3];
				range = new Range(num4, num4, 1, 1, cells_0);
				arrayList.Add(range);
				int_0 += 5;
				break;
			}
			case 37:
			case 69:
			case 101:
			{
				int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int num3 = BitConverter.ToUInt16(byte_0, int_0 + 3);
				int num4 = byte_0[int_0 + 5];
				int num5 = byte_0[int_0 + 7];
				range = new Range(num4, num4, num3 - num2 + 1, num5 - num4 + 1, cells_0);
				arrayList.Add(range);
				int_0 += 9;
				break;
			}
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_0 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_0 += 9;
				break;
			case 44:
			case 76:
			case 108:
				int_0 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_0 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				int int_2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int num = worksheetCollection_0.method_32().method_15(worksheetCollection_0, int_2);
				if (num >= 0 && num < worksheetCollection_0.Count)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_0 + 3);
					int num4 = byte_0[int_0 + 5];
					range = new Range(num2, num4, 1, 1, worksheetCollection_0[num].Cells);
					arrayList.Add(range);
				}
				int_0 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				int int_2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				int num = worksheetCollection_0.method_32().method_15(worksheetCollection_0, int_2);
				if (num >= 0 && num < worksheetCollection_0.Count)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_0 + 3);
					int num3 = BitConverter.ToUInt16(byte_0, int_0 + 5);
					int num4 = byte_0[int_0 + 7];
					int num5 = byte_0[int_0 + 9];
					range = new Range(num2, num4, num3 - num2 + 1, num5 - num4 + 1, worksheetCollection_0[num].Cells);
					arrayList.Add(range);
				}
				int_0 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_0 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_0 += 11;
				break;
			default:
				return arrayList;
			}
		}
		return arrayList;
	}

	internal static void smethod_16(byte[] byte_0, int int_0, int int_1, Hashtable hashtable_0, WorksheetCollection worksheetCollection_0)
	{
		if (hashtable_0 == null || hashtable_0.Count == 0)
		{
			return;
		}
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			default:
				return;
			case 1:
			case 2:
				int_0 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num5 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num5 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num3 = BitConverter.ToUInt16(byte_0, int_0 + 1) - 1;
				if (hashtable_0[num3] != null)
				{
					int num4 = (int)hashtable_0[num3];
					if (num4 != num3 && num4 >= 0)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(num4 + 1)), 0, byte_0, int_0 + 1, 2);
					}
				}
				int_0 += 5;
				break;
			}
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
			{
				int num = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
				int int_2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				if (hashtable_0[num] != null && worksheetCollection_0.method_32().method_12(int_2) == worksheetCollection_0.method_36())
				{
					int num2 = (int)hashtable_0[num];
					if (num2 != num && num2 >= 0)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(num2 + 1)), 0, byte_0, int_0 + 3, 2);
					}
				}
				int_0 += 7;
				break;
			}
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				int_0 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				int_0 += 11;
				break;
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_17(byte[] byte_0, int int_0, int int_1, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			default:
				return;
			case 1:
			case 2:
				int_0 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num5 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num5 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
			{
				int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1) - 1;
				if (hashtable_1[num2] != null)
				{
					int num3 = (int)hashtable_1[num2];
					if (num3 != num2 && num3 >= 0)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(num3 + 1)), 0, byte_0, int_0 + 1, 2);
					}
				}
				int_0 += 5;
				break;
			}
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 45:
			case 69:
			case 75:
			case 77:
			case 101:
			case 107:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
			{
				int num6 = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
				if (hashtable_1[num6] != null)
				{
					int num7 = (int)hashtable_1[num6];
					if (num7 != num6 && num7 >= 0)
					{
						Array.Copy(BitConverter.GetBytes((ushort)(num7 + 1)), 0, byte_0, int_0 + 3, 2);
					}
				}
				int_0 += 7;
				break;
			}
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
			{
				int num4 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				num4 = ((hashtable_0[num4] != null) ? ((int)hashtable_0[num4]) : 0);
				Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_0 + 1, 2);
				int_0 += 7;
				break;
			}
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
			{
				int num = BitConverter.ToUInt16(byte_0, int_0 + 1);
				num = ((hashtable_0[num] != null) ? ((int)hashtable_0[num]) : 0);
				Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_0 + 1, 2);
				int_0 += 11;
				break;
			}
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_18(byte[] byte_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			default:
				return;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, int_0 + 2);
					int_0 += num3 + 5;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_0 += 5;
				break;
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				int_0 += 9;
				break;
			case 44:
			case 76:
			case 108:
				byte_0[int_0] &= 247;
				if ((byte_0[int_0 + 4] & 0x80u) != 0)
				{
					int num = BitConverter.ToUInt16(byte_0, int_0 + 1);
					num += int_2;
					if (num > 65535)
					{
						num -= 65536;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_0 + 1, 2);
				}
				if ((byte_0[int_0 + 4] & 0x40u) != 0)
				{
					int num2 = byte_0[int_0 + 3];
					num2 += int_3;
					if (num2 > 255)
					{
						num2 -= 256;
					}
					byte_0[int_0 + 3] = (byte)num2;
				}
				int_0 += 5;
				break;
			case 45:
			case 77:
			case 109:
				byte_0[int_0] &= 247;
				if ((byte_0[int_0 + 6] & 0x80u) != 0)
				{
					int num = BitConverter.ToUInt16(byte_0, int_0 + 1);
					num += int_2;
					if (num > 65535)
					{
						num -= 65536;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_0 + 1, 2);
				}
				if ((byte_0[int_0 + 6] & 0x40u) != 0)
				{
					int num2 = byte_0[int_0 + 5];
					num2 += int_3;
					if (num2 > 255)
					{
						num2 -= 256;
					}
					byte_0[int_0 + 5] = (byte)num2;
				}
				if ((byte_0[int_0 + 8] & 0x80u) != 0)
				{
					int num = BitConverter.ToUInt16(byte_0, int_0 + 3);
					num += int_2;
					if (num > 65535)
					{
						num -= 65536;
					}
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_0 + 3, 2);
				}
				if ((byte_0[int_0 + 8] & 0x40u) != 0)
				{
					int num2 = byte_0[int_0 + 7];
					num2 += int_3;
					if (num2 > 255)
					{
						num2 -= 256;
					}
					byte_0[int_0 + 7] = (byte)num2;
				}
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_0 += 7;
				break;
			case 58:
			case 60:
			case 90:
			case 92:
			case 122:
			case 124:
				int_0 += 7;
				break;
			case 59:
			case 61:
			case 91:
			case 93:
			case 123:
			case 125:
				int_0 += 11;
				break;
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_19(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (int_0 == 0)
		{
			return;
		}
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			default:
				return;
			case 1:
			{
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
				byte b = byte_0[int_1 + 3];
				if (num2 >= cellArea_0.StartRow && b >= cellArea_0.StartColumn && b <= cellArea_0.EndColumn)
				{
					num2 += int_0;
					Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 1, 2);
				}
				int_1 += 5;
				break;
			}
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				byte b3 = byte_0[int_1 + 1];
				int_1 = ((byte_0[int_1 + 2] != 0) ? (int_1 + (ushort)(b3 * 2 + 3)) : (int_1 + (ushort)(b3 + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num3 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_1 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					byte b = byte_0[int_1 + 3];
					if (num2 >= cellArea_0.StartRow && b >= cellArea_0.StartColumn && b <= cellArea_0.EndColumn)
					{
						num2 += int_0;
						Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 1, 2);
					}
				}
				int_1 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				if (bool_0)
				{
					byte b = byte_0[int_1 + 5];
					byte b2 = byte_0[int_1 + 7];
					if (cellArea_0.StartColumn <= b && cellArea_0.EndColumn >= b2)
					{
						int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
						if (num2 >= cellArea_0.StartRow)
						{
							num2 += int_0;
							Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 1, 2);
						}
						num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
						if (num2 >= cellArea_0.StartRow)
						{
							num2 += int_0;
							if (num2 > 65535)
							{
								num2 = 65535;
							}
							Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 3, 2);
						}
					}
				}
				int_1 += 9;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_1 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 7;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				byte b = byte_0[int_1 + 5];
				if (num2 >= cellArea_0.StartRow && b >= cellArea_0.StartColumn && b <= cellArea_0.EndColumn)
				{
					num2 += int_0;
					Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 3, 2);
				}
				int_1 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 11;
					break;
				}
				byte b = byte_0[int_1 + 7];
				byte b2 = byte_0[int_1 + 9];
				if (cellArea_0.StartColumn <= b && cellArea_0.EndColumn >= b)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
					if (num2 >= cellArea_0.StartRow)
					{
						num2 += int_0;
						Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 3, 2);
					}
					num2 = BitConverter.ToUInt16(byte_0, int_1 + 5);
					if (num2 >= cellArea_0.StartRow)
					{
						num2 += int_0;
						if (num2 > 65535)
						{
							num2 = 65535;
						}
						Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 5, 2);
					}
				}
				int_1 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_1 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_1 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_20(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (int_0 == 0)
		{
			return;
		}
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			default:
				return;
			case 1:
				int_1 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				byte b = byte_0[int_1 + 1];
				int_1 = ((byte_0[int_1 + 2] != 0) ? (int_1 + (ushort)(b * 2 + 3)) : (int_1 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num5 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num5 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_1 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					byte startColumnIndex = byte_0[int_1 + 3];
					if (startColumnIndex >= cellArea_0.StartColumn && startColumnIndex <= cellArea_0.EndColumn)
					{
						if (num2 > cellArea_0.EndRow)
						{
							num2 -= int_0;
							Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 1, 2);
						}
						else if (num2 >= cellArea_0.StartRow)
						{
							byte_0[int_1] = (byte)(byte_0[int_1] + 6);
						}
					}
				}
				int_1 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					byte startColumnIndex = byte_0[int_1 + 5];
					int num4 = BitConverter.ToUInt16(byte_0, int_1 + 3);
					int endColumnIndex2 = byte_0[int_1 + 7];
					bool flag2;
					bool delete2;
					CellArea cellArea2 = smethod_22(cellArea_0, int_0, num2, startColumnIndex, num4, endColumnIndex2, out flag2, out delete2);
					if (delete2)
					{
						byte_0[int_1] = (byte)(byte_0[int_1] + 6);
					}
					else if (flag2)
					{
						if (cellArea2.StartRow != num2)
						{
							Array.Copy(BitConverter.GetBytes((ushort)cellArea2.StartRow), 0, byte_0, int_1 + 1, 2);
						}
						if (cellArea2.EndRow != num4)
						{
							Array.Copy(BitConverter.GetBytes((ushort)cellArea2.EndRow), 0, byte_0, int_1 + 3, 2);
						}
						byte_0[int_1 + 5] = (byte)cellArea2.StartColumn;
						byte_0[int_1 + 7] = (byte)cellArea2.EndColumn;
					}
				}
				int_1 += 9;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_1 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 7;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				byte startColumnIndex = byte_0[int_1 + 5];
				if (startColumnIndex >= cellArea_0.StartColumn && startColumnIndex <= cellArea_0.EndColumn)
				{
					if (num2 > cellArea_0.EndRow)
					{
						num2 -= int_0;
						Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_1 + 3, 2);
					}
					else if (num2 >= cellArea_0.StartRow)
					{
						byte_0[int_1] = (byte)(byte_0[int_1] + 2);
					}
				}
				int_1 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 11;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				byte startColumnIndex = byte_0[int_1 + 7];
				int num3 = BitConverter.ToUInt16(byte_0, int_1 + 5);
				int endColumnIndex = byte_0[int_1 + 9];
				bool flag;
				bool delete;
				CellArea cellArea = smethod_22(cellArea_0, int_0, num2, startColumnIndex, num3, endColumnIndex, out flag, out delete);
				if (delete)
				{
					byte_0[int_1] = (byte)(byte_0[int_1] + 6);
				}
				else if (flag)
				{
					if (cellArea.StartRow != num2)
					{
						Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, int_1 + 3, 2);
					}
					if (cellArea.EndRow != num3)
					{
						Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, int_1 + 5, 2);
					}
					byte_0[int_1 + 7] = (byte)cellArea.StartColumn;
					byte_0[int_1 + 9] = (byte)cellArea.EndColumn;
				}
				int_1 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_1 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_1 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void smethod_21(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6)
	{
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			default:
				return;
			case 1:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					int num4 = byte_0[int_1 + 3];
					if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow && num4 >= cellArea_0.StartColumn)
					{
						num4 += int_0;
						byte_0[int_1 + 3] = (byte)num4;
					}
				}
				int_1 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				byte b = byte_0[int_1 + 1];
				int_1 = ((byte_0[int_1 + 2] != 0) ? (int_1 + (ushort)(b * 2 + 3)) : (int_1 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num5 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num5 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_1 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					int num4 = byte_0[int_1 + 3];
					if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow && num4 >= cellArea_0.StartColumn)
					{
						num4 += int_0;
						byte_0[int_1 + 3] = (byte)num4;
					}
				}
				int_1 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					int num3 = BitConverter.ToUInt16(byte_0, int_1 + 3);
					if (cellArea_0.StartRow <= num2 && cellArea_0.EndRow >= num3)
					{
						int num4 = byte_0[int_1 + 5];
						if (num4 >= cellArea_0.StartColumn)
						{
							num4 += int_0;
							if (num4 > 255)
							{
								num4 = 255;
							}
							byte_0[int_1 + 5] = (byte)num4;
						}
						num4 = byte_0[int_1 + 7];
						if (num4 >= cellArea_0.StartColumn)
						{
							num4 += int_0;
							if (num4 > 255)
							{
								num4 = 255;
							}
							byte_0[int_1 + 7] = (byte)num4;
						}
					}
				}
				int_1 += 9;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_1 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 7;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				int num4 = byte_0[int_1 + 5];
				if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow && num4 >= cellArea_0.StartColumn)
				{
					num4 += int_0;
					byte_0[int_1 + 5] = (byte)num4;
				}
				int_1 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 11;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				int num3 = BitConverter.ToUInt16(byte_0, int_1 + 5);
				if (cellArea_0.StartRow <= num2 && cellArea_0.EndRow >= num3)
				{
					int num4 = byte_0[int_1 + 7];
					if (num4 >= cellArea_0.StartColumn)
					{
						num4 += int_0;
						if (num4 > 255)
						{
							num4 = 255;
						}
						byte_0[int_1 + 7] = (byte)num4;
					}
					num4 = byte_0[int_1 + 9];
					if (num4 >= cellArea_0.StartColumn)
					{
						num4 += int_0;
						if (num4 > 255)
						{
							num4 = 255;
						}
						byte_0[int_1 + 9] = (byte)num4;
					}
				}
				int_1 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_1 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_1 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static CellArea smethod_22(CellArea ca, int shiftNumber, int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, out bool flag, out bool delete)
	{
		CellArea result = default(CellArea);
		flag = false;
		delete = false;
		if (ca.StartColumn > endColumnIndex)
		{
			return result;
		}
		if (ca.StartColumn > startColumnIndex)
		{
			if (ca.EndColumn >= endColumnIndex && ca.StartRow <= startRowIndex && ca.EndRow >= endRowIndex)
			{
				flag = true;
				result.StartRow = startRowIndex;
				result.EndRow = endRowIndex;
				result.StartColumn = startColumnIndex;
				result.EndColumn = ca.StartColumn - 1;
				return result;
			}
		}
		else
		{
			if (ca.EndColumn < startColumnIndex)
			{
				return result;
			}
			if (ca.EndColumn < endColumnIndex)
			{
				if (ca.StartRow <= startRowIndex && ca.EndRow >= endRowIndex)
				{
					flag = true;
					result.StartRow = startRowIndex;
					result.EndRow = endRowIndex;
					result.StartColumn = ca.EndColumn + 1;
					result.EndColumn = endColumnIndex;
					return result;
				}
			}
			else
			{
				if (ca.EndRow < startRowIndex)
				{
					flag = true;
					result.StartRow = startRowIndex - shiftNumber;
					result.EndRow = endRowIndex - shiftNumber;
					result.StartColumn = startColumnIndex;
					result.EndColumn = endColumnIndex;
					return result;
				}
				if (ca.EndRow < endRowIndex)
				{
					flag = true;
					if (ca.StartRow <= startRowIndex)
					{
						result.StartRow = ca.StartRow;
					}
					else
					{
						result.StartRow = startRowIndex;
					}
					result.EndRow = endRowIndex - shiftNumber;
					result.StartColumn = startColumnIndex;
					result.EndColumn = endColumnIndex;
					return result;
				}
				if (ca.StartRow <= startRowIndex)
				{
					delete = true;
					return result;
				}
				if (ca.StartRow <= endRowIndex)
				{
					flag = true;
					result.StartRow = startRowIndex;
					result.EndRow = ca.StartRow - 1;
					result.StartColumn = startColumnIndex;
					result.EndColumn = endColumnIndex;
					return result;
				}
			}
		}
		return result;
	}

	internal static CellArea smethod_23(CellArea ca, int shiftNumber, int startRowIndex, int startColumnIndex, int endRowIndex, int endColumnIndex, out bool flag, out bool delete)
	{
		CellArea result = default(CellArea);
		flag = false;
		delete = false;
		if (ca.StartRow > endRowIndex)
		{
			return result;
		}
		if (ca.StartRow > startRowIndex)
		{
			if (ca.EndRow >= endRowIndex && ca.StartColumn <= startColumnIndex && ca.EndColumn >= endColumnIndex)
			{
				flag = true;
				result.StartRow = startRowIndex;
				result.EndRow = ca.StartRow - 1;
				result.StartColumn = startColumnIndex;
				result.EndColumn = endColumnIndex;
				return result;
			}
		}
		else
		{
			if (ca.EndRow < startRowIndex)
			{
				return result;
			}
			if (ca.EndRow < endRowIndex)
			{
				if (ca.StartColumn <= startColumnIndex && ca.EndColumn >= endColumnIndex)
				{
					flag = true;
					result.StartRow = ca.EndRow + 1;
					result.EndRow = endRowIndex;
					result.StartColumn = startColumnIndex;
					result.EndColumn = endColumnIndex;
					return result;
				}
			}
			else
			{
				if (ca.EndColumn < startColumnIndex)
				{
					flag = true;
					result.StartRow = startRowIndex;
					result.EndRow = endRowIndex;
					result.StartColumn = startColumnIndex - shiftNumber;
					result.EndColumn = endColumnIndex - shiftNumber;
					return result;
				}
				if (ca.EndColumn < endColumnIndex)
				{
					flag = true;
					result.StartRow = startRowIndex;
					result.EndRow = endRowIndex;
					if (ca.StartColumn <= startColumnIndex)
					{
						result.StartColumn = ca.StartColumn;
					}
					else
					{
						result.StartColumn = startColumnIndex;
					}
					result.EndColumn = endColumnIndex - shiftNumber;
					return result;
				}
				if (ca.StartColumn <= startColumnIndex)
				{
					delete = true;
					return result;
				}
				if (ca.StartColumn <= endColumnIndex)
				{
					flag = true;
					result.StartRow = startRowIndex;
					result.EndRow = endRowIndex;
					result.StartColumn = startColumnIndex;
					result.EndColumn = ca.StartColumn - 1;
					return result;
				}
			}
		}
		return result;
	}

	internal static void smethod_24(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (int_1 == -1)
		{
			int_1 = 2;
			int_2 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num = 0;
		while (int_1 < int_2)
		{
			switch (byte_0[int_1])
			{
			default:
				return;
			case 1:
				int_1 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_1++;
				break;
			case 23:
			{
				byte b = byte_0[int_1 + 1];
				int_1 = ((byte_0[int_1 + 2] != 0) ? (int_1 + (ushort)(b * 2 + 3)) : (int_1 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_1 + 1])
				{
				case 8:
					int_1 += 4;
					break;
				case 1:
					int_1 += 4;
					break;
				case 2:
					int_1 += 4;
					break;
				case 4:
				{
					ushort num5 = BitConverter.ToUInt16(byte_0, int_1 + 2);
					int_1 += num5 + 5;
					break;
				}
				default:
					int_1 += 4;
					break;
				case 64:
					int_1 += 4;
					break;
				case 32:
					int_1 += 4;
					break;
				case 16:
					int_1 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_1 += 2;
				break;
			case 31:
				int_1 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_1 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_1 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_1 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_1 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					int startColumnIndex = byte_0[int_1 + 3];
					if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow)
					{
						if (startColumnIndex > cellArea_0.EndColumn)
						{
							startColumnIndex -= int_0;
							byte_0[int_1 + 3] = (byte)startColumnIndex;
						}
						else if (startColumnIndex >= cellArea_0.StartColumn)
						{
							byte_0[int_1] = (byte)(byte_0[int_1] + 6);
						}
					}
				}
				int_1 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_1 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_1 += 3;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				if (bool_0)
				{
					int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1);
					int startColumnIndex = byte_0[int_1 + 5];
					int num4 = BitConverter.ToUInt16(byte_0, int_1 + 3);
					int endColumnIndex2 = byte_0[int_1 + 7];
					bool flag2;
					bool delete2;
					CellArea cellArea2 = smethod_23(cellArea_0, int_0, num2, startColumnIndex, num4, endColumnIndex2, out flag2, out delete2);
					if (delete2)
					{
						byte_0[int_1] = (byte)(byte_0[int_1] + 6);
					}
					else if (flag2)
					{
						if (num2 != cellArea2.StartRow)
						{
							Array.Copy(BitConverter.GetBytes((ushort)cellArea2.StartRow), 0, byte_0, int_1 + 1, 2);
						}
						if (num4 != cellArea2.EndRow)
						{
							Array.Copy(BitConverter.GetBytes((ushort)cellArea2.EndRow), 0, byte_0, int_1 + 3, 2);
						}
						byte_0[int_1 + 5] = (byte)cellArea2.StartColumn;
						byte_0[int_1 + 7] = (byte)cellArea2.EndColumn;
					}
				}
				int_1 += 9;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_1 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_1 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_1 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 7;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				int startColumnIndex = byte_0[int_1 + 5];
				if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow && startColumnIndex >= cellArea_0.StartColumn)
				{
					if (startColumnIndex > cellArea_0.EndColumn)
					{
						startColumnIndex -= int_0;
						byte_0[int_1 + 5] = (byte)startColumnIndex;
					}
					else if (startColumnIndex >= cellArea_0.StartColumn)
					{
						byte_0[int_1] = (byte)(byte_0[int_1] + 2);
					}
				}
				int_1 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num = BitConverter.ToUInt16(byte_0, int_1 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_1 += 11;
					break;
				}
				int num2 = BitConverter.ToUInt16(byte_0, int_1 + 3);
				int startColumnIndex = byte_0[int_1 + 7];
				int num3 = BitConverter.ToUInt16(byte_0, int_1 + 5);
				int endColumnIndex = byte_0[int_1 + 9];
				bool flag;
				bool delete;
				CellArea cellArea = smethod_23(cellArea_0, int_0, num2, startColumnIndex, num3, endColumnIndex, out flag, out delete);
				if (delete)
				{
					byte_0[int_1] = (byte)(byte_0[int_1] + 2);
				}
				else if (flag)
				{
					if (num2 != cellArea.StartRow)
					{
						Array.Copy(BitConverter.GetBytes((ushort)cellArea.StartRow), 0, byte_0, int_1 + 3, 2);
					}
					if (num3 != cellArea.EndRow)
					{
						Array.Copy(BitConverter.GetBytes((ushort)cellArea.EndRow), 0, byte_0, int_1 + 5, 2);
					}
					byte_0[int_1 + 7] = (byte)cellArea.StartColumn;
					byte_0[int_1 + 9] = (byte)cellArea.EndColumn;
				}
				int_1 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_1 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_1 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static void MoveRange(CellArea cellArea_0, int int_0, int int_1, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_2, int int_3)
	{
		if (int_2 == -1)
		{
			int_2 = 2;
			int_3 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		int num = 0;
		int num2 = int_0 + cellArea_0.EndRow - cellArea_0.StartRow;
		int num3 = int_1 + cellArea_0.EndColumn - cellArea_0.StartColumn;
		while (int_2 < int_3)
		{
			switch (byte_0[int_2])
			{
			default:
				return;
			case 1:
			case 2:
				int_2 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_2++;
				break;
			case 23:
			{
				byte b2 = byte_0[int_2 + 1];
				int_2 = ((byte_0[int_2 + 2] != 0) ? (int_2 + (ushort)(b2 * 2 + 3)) : (int_2 + (ushort)(b2 + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_2 + 1])
				{
				case 8:
					int_2 += 4;
					break;
				case 1:
					int_2 += 4;
					break;
				case 2:
					int_2 += 4;
					break;
				case 4:
				{
					ushort num9 = BitConverter.ToUInt16(byte_0, int_2 + 2);
					int_2 += num9 + 5;
					break;
				}
				default:
					int_2 += 4;
					break;
				case 64:
					int_2 += 4;
					break;
				case 32:
					int_2 += 4;
					break;
				case 16:
					int_2 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_2 += 2;
				break;
			case 31:
				int_2 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_2 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_2 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_2 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_2 += 5;
				break;
			case 36:
			case 68:
			case 100:
				if (bool_0)
				{
					int num4 = BitConverter.ToUInt16(byte_0, int_2 + 1);
					byte b = byte_0[int_2 + 3];
					if (num4 >= cellArea_0.StartRow && num4 <= cellArea_0.EndRow && b >= cellArea_0.StartColumn && b <= cellArea_0.EndColumn)
					{
						num4 = int_0 + num4 - cellArea_0.StartRow;
						b = (byte)(int_1 + b - cellArea_0.StartColumn);
						Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_2 + 1, 2);
						byte_0[int_2 + 3] = b;
					}
					else if (num4 >= int_0 && num4 <= num2 && b >= int_1 && b <= num3)
					{
						byte_0[int_2] = (byte)(byte_0[int_2] + 6);
					}
				}
				int_2 += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					int num4 = BitConverter.ToUInt16(byte_0, int_2 + 1);
					byte b = byte_0[int_2 + 5];
					int num7 = BitConverter.ToUInt16(byte_0, int_2 + 3);
					int num8 = byte_0[int_2 + 7];
					if (num4 >= cellArea_0.StartRow && num7 <= cellArea_0.EndRow && b >= cellArea_0.StartColumn && num8 <= cellArea_0.EndColumn)
					{
						num4 = int_0 + num4 - cellArea_0.StartRow;
						b = (byte)(int_1 + b - cellArea_0.StartColumn);
						Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_2 + 1, 2);
						byte_0[int_2 + 5] = b;
						num7 = int_0 + num7 - cellArea_0.StartRow;
						num8 = (byte)(int_1 + num8 - cellArea_0.StartColumn);
						Array.Copy(BitConverter.GetBytes((ushort)num7), 0, byte_0, int_2 + 3, 2);
						byte_0[int_2 + 7] = (byte)num8;
					}
					else if (num4 >= int_0 && num7 <= num2 && b >= int_1 && num8 <= num3)
					{
						byte_0[int_2] = (byte)(byte_0[int_2] + 6);
					}
				}
				int_2 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_2 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_2 += 3;
				break;
			case 43:
			case 75:
			case 107:
				int_2 += 9;
				break;
			case 42:
			case 44:
			case 74:
			case 76:
			case 106:
			case 108:
				int_2 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_2 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_2 += 7;
				break;
			case 58:
			case 90:
			case 122:
			{
				num = BitConverter.ToUInt16(byte_0, int_2 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_2 += 7;
					break;
				}
				int num4 = BitConverter.ToUInt16(byte_0, int_2 + 3);
				byte b = byte_0[int_2 + 5];
				if (num4 >= cellArea_0.StartRow && num4 <= cellArea_0.EndRow && b >= cellArea_0.StartColumn && b <= cellArea_0.EndColumn)
				{
					num4 = int_0 + num4 - cellArea_0.StartRow;
					b = (byte)(int_1 + b - cellArea_0.StartColumn);
					Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_2 + 3, 2);
					byte_0[int_2 + 5] = b;
				}
				else if (num4 >= int_0 && num4 <= num2 && b >= int_1 && b <= num3)
				{
					byte_0[int_2] = (byte)(byte_0[int_2] + 2);
				}
				int_2 += 7;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				num = BitConverter.ToUInt16(byte_0, int_2 + 1);
				if (worksheet_0.method_2().method_32().method_13(num) != worksheet_0.Index)
				{
					int_2 += 11;
					break;
				}
				int num4 = BitConverter.ToUInt16(byte_0, int_2 + 3);
				byte b = byte_0[int_2 + 7];
				int num5 = BitConverter.ToUInt16(byte_0, int_2 + 5);
				int num6 = byte_0[int_2 + 9];
				if (num4 >= cellArea_0.StartRow && num5 <= cellArea_0.EndRow && b >= cellArea_0.StartColumn && num6 <= cellArea_0.EndColumn)
				{
					num4 = int_0 + num4 - cellArea_0.StartRow;
					b = (byte)(int_1 + b - cellArea_0.StartColumn);
					Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, int_2 + 3, 2);
					byte_0[int_2 + 7] = b;
					num5 = int_0 + num5 - cellArea_0.StartRow;
					num6 = (byte)(int_1 + num6 - cellArea_0.StartColumn);
					Array.Copy(BitConverter.GetBytes((ushort)num5), 0, byte_0, int_2 + 5, 2);
					byte_0[int_2 + 9] = (byte)num6;
				}
				else if (num4 >= int_0 && num5 <= num2 && b >= int_1 && num6 <= num3)
				{
					byte_0[int_2] = (byte)(byte_0[int_2] + 2);
				}
				int_2 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_2 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_2 += 11;
				break;
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static bool smethod_25(byte[] byte_0, int int_0, int int_1, int int_2, int int_3, CellArea cellArea_0)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			case 1:
			case 2:
				int_0 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, int_0 + 4);
					int_0 += num3 + 4;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_0 += 5;
				break;
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				int_0 += 9;
				break;
			case 44:
			case 76:
			case 108:
				if ((byte_0[int_0 + 4] & 0x80u) != 0)
				{
					int num = BitConverter.ToUInt16(byte_0, int_0 + 1);
					if (num != 0 && num + int_2 < 65535)
					{
						int num2 = num + int_2;
						if (num2 >= cellArea_0.StartRow && num2 <= cellArea_0.EndRow)
						{
							return true;
						}
					}
				}
				int_0 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_0 += 7;
				break;
			case 58:
			case 90:
			case 122:
				int_0 += 7;
				break;
			case 59:
			case 91:
			case 123:
				int_0 += 11;
				break;
			case 60:
			case 92:
			case 124:
				int_0 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_0 += 11;
				break;
			}
		}
		return false;
	}

	internal static bool smethod_26(byte[] byte_0, int int_0, int int_1)
	{
		if (int_0 == -1)
		{
			int_0 = 2;
			int_1 = BitConverter.ToUInt16(byte_0, 0) + 2;
		}
		while (int_0 < int_1)
		{
			switch (byte_0[int_0])
			{
			case 1:
			case 2:
				int_0 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_0++;
				break;
			case 23:
			{
				byte b = byte_0[int_0 + 1];
				int_0 = ((byte_0[int_0 + 2] != 0) ? (int_0 + (ushort)(b * 2 + 3)) : (int_0 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_0 + 1])
				{
				case 8:
					int_0 += 4;
					break;
				case 1:
					int_0 += 4;
					break;
				case 2:
					int_0 += 4;
					break;
				case 4:
				{
					ushort num = BitConverter.ToUInt16(byte_0, int_0 + 4);
					int_0 += num + 4;
					break;
				}
				default:
					int_0 += 4;
					break;
				case 64:
					int_0 += 4;
					break;
				case 32:
					int_0 += 4;
					break;
				case 16:
					int_0 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_0 += 2;
				break;
			case 31:
				int_0 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_0 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_0 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_0 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_0 += 5;
				break;
			case 36:
			case 68:
			case 100:
				int_0 += 5;
				break;
			case 40:
			case 72:
			case 104:
				int_0 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_0 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_0 += 5;
				break;
			case 37:
			case 43:
			case 69:
			case 75:
			case 101:
			case 107:
				int_0 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_0 += 7;
				break;
			case 58:
			case 90:
			case 122:
				int_0 += 7;
				break;
			case 59:
			case 91:
			case 123:
				int_0 += 11;
				break;
			case 60:
			case 92:
			case 124:
				int_0 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_0 += 11;
				break;
			case 44:
			case 45:
			case 76:
			case 77:
			case 108:
			case 109:
				return true;
			}
		}
		return false;
	}

	internal static void smethod_27(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, bool bool_1, int int_2, int int_3, int int_4, byte[] byte_0)
	{
		if (int_3 == -1)
		{
			int_3 = 2;
			int_4 = 2 + BitConverter.ToUInt16(byte_0, 0);
		}
		while (int_3 < int_4)
		{
			switch (byte_0[int_3])
			{
			default:
				return;
			case 1:
				int_3 += 5;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
				int_3++;
				break;
			case 23:
			{
				byte b = byte_0[int_3 + 1];
				int_3 = ((byte_0[int_3 + 2] != 0) ? (int_3 + (ushort)(b * 2 + 3)) : (int_3 + (ushort)(b + 3)));
				break;
			}
			case 25:
				switch (byte_0[int_3 + 1])
				{
				case 8:
					int_3 += 4;
					break;
				case 1:
					int_3 += 4;
					break;
				case 2:
					int_3 += 4;
					break;
				case 4:
				{
					ushort num3 = BitConverter.ToUInt16(byte_0, int_3 + 2);
					int_3 += num3 + 5;
					break;
				}
				default:
					int_3 += 4;
					break;
				case 64:
					int_3 += 4;
					break;
				case 32:
					int_3 += 4;
					break;
				case 16:
					int_3 += 4;
					break;
				}
				break;
			case 28:
			case 29:
				int_3 += 2;
				break;
			case 31:
				int_3 += 9;
				break;
			case 32:
			case 64:
			case 96:
				int_3 += 8;
				break;
			case 30:
			case 33:
			case 65:
			case 97:
				int_3 += 3;
				break;
			case 34:
			case 66:
			case 98:
				int_3 += 4;
				break;
			case 35:
			case 67:
			case 99:
				int_3 += 5;
				break;
			case 36:
			case 68:
			case 100:
				int_3 += 5;
				break;
			case 37:
			case 69:
			case 101:
				if (bool_0)
				{
					if (bool_1)
					{
						int num = BitConverter.ToUInt16(byte_0, int_3 + 3);
						if (num == int_0)
						{
							num += int_2;
							Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_3 + 3, 2);
						}
					}
					else
					{
						int num2 = byte_0[int_3 + 7];
						if (num2 == int_1)
						{
							num2 += int_2;
							byte_0[int_3 + 7] = (byte)num2;
						}
					}
				}
				int_3 += 9;
				break;
			case 40:
			case 72:
			case 104:
				int_3 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_3 += 3;
				break;
			case 42:
			case 74:
			case 106:
				int_3 += 5;
				break;
			case 43:
			case 75:
			case 107:
				int_3 += 9;
				break;
			case 44:
			case 76:
			case 108:
				int_3 += 5;
				break;
			case 45:
			case 77:
			case 109:
				int_3 += 9;
				break;
			case 57:
			case 89:
			case 121:
				int_3 += 7;
				break;
			case 58:
			case 90:
			case 122:
				int_3 += 7;
				break;
			case 59:
			case 91:
			case 123:
			{
				int int_5 = BitConverter.ToUInt16(byte_0, int_3 + 1);
				if (worksheet_0.method_2().method_32().method_13(int_5) != worksheet_0.Index)
				{
					int_3 += 11;
					break;
				}
				if (bool_1)
				{
					int num = BitConverter.ToUInt16(byte_0, int_3 + 5);
					if (num == int_0)
					{
						num += int_2;
						Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, int_3 + 5, 2);
					}
				}
				else
				{
					int num2 = byte_0[int_3 + 9];
					if (num2 == int_1)
					{
						num2 += int_2;
						byte_0[int_3 + 9] = (byte)num2;
					}
				}
				int_3 += 11;
				break;
			}
			case 60:
			case 92:
			case 124:
				int_3 += 7;
				break;
			case 61:
			case 93:
			case 125:
				int_3 += 11;
				break;
			case 2:
			case 24:
			case 26:
			case 27:
			case 38:
			case 39:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 62:
			case 63:
			case 70:
			case 71:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 94:
			case 95:
			case 102:
			case 103:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
				return;
			}
		}
	}

	internal static bool smethod_28(byte byte_0)
	{
		return (byte_0 & 0x80) != 0;
	}

	internal static bool smethod_29(byte byte_0)
	{
		return (byte_0 & 0x40) != 0;
	}

	internal static bool smethod_30(int int_0, int int_1, ref int int_2, int int_3)
	{
		if (int_2 >= int_0)
		{
			int_2 += int_1;
			if (int_2 < int_0)
			{
				return true;
			}
			if (int_2 > int_3)
			{
				int_2 = int_3;
			}
		}
		return false;
	}

	internal static bool smethod_31(int int_0, int int_1, ref int int_2, ref int int_3, int int_4)
	{
		if (int_2 >= int_0)
		{
			int_2 += int_1;
			if (int_2 < int_0)
			{
				int_2 = int_0;
			}
			else if (int_2 > int_4)
			{
				int_2 = int_4;
			}
		}
		if (int_3 >= int_0)
		{
			int_3 += int_1;
			if (int_3 < int_0)
			{
				int_3 = int_0 - 1;
			}
			else if (int_3 > int_4)
			{
				int_3 = int_4;
			}
		}
		return int_3 < int_2;
	}

	internal static bool smethod_32(int int_0, int int_1, ref int int_2, byte byte_0, ref int int_3, byte byte_1, int int_4)
	{
		if (smethod_28(byte_0) && int_2 >= int_0)
		{
			int_2 += int_1;
			if (int_2 < int_0)
			{
				int_2 = int_0;
			}
			else if (int_2 > int_4)
			{
				int_2 = int_4;
			}
		}
		if (smethod_28(byte_1) && int_3 >= int_0)
		{
			int_3 += int_1;
			if (int_3 < int_0)
			{
				int_3 = int_0 - 1;
			}
			else if (int_3 > int_4)
			{
				int_3 = int_4;
			}
		}
		return int_3 < int_2;
	}
}
