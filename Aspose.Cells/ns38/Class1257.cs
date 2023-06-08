using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns38;

internal class Class1257
{
	private WorksheetCollection worksheetCollection_0;

	internal bool bool_0;

	internal Class1257(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal Class1661 method_0(Cell cell_0, byte[] byte_0, int int_0)
	{
		bool_0 = false;
		int num = 0;
		int num2 = 0;
		if (byte_0 == null)
		{
			byte_0 = cell_0.method_41();
			ushort num3 = BitConverter.ToUInt16(byte_0, 0);
			int_0 = 2;
			num2 = (num = 2 + num3);
		}
		else if (int_0 == -1)
		{
			ushort num3 = BitConverter.ToUInt16(byte_0, 0);
			int_0 = 2;
			num2 = (num = 2 + num3);
		}
		else
		{
			ushort num3;
			num2 = (num = (num3 = (ushort)byte_0.Length));
		}
		ArrayList arrayList = new ArrayList();
		Class1661 @class = null;
		while (int_0 < num)
		{
			switch (byte_0[int_0])
			{
			case 3:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("+");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 3;
				method_6(@class, arrayList);
				int_0++;
				if (arrayList.Count == 0)
				{
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
				}
				else
				{
					arrayList.Add(@class);
				}
				break;
			case 4:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("-");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 4;
				method_6(@class, arrayList);
				int_0++;
				if (arrayList.Count == 0)
				{
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
				}
				else
				{
					arrayList.Add(@class);
				}
				break;
			case 5:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("*");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 5;
				method_6(@class, arrayList);
				int_0++;
				if (arrayList.Count == 0)
				{
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
				}
				else
				{
					arrayList.Add(@class);
				}
				break;
			case 6:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("/");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 6;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 7:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("^");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 7;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 8:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("&");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 8;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 9:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("<");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 9;
				@class.Type = Enum180.const_2;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 10:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("<=");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 10;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 11:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("=");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 11;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 12:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4(">=");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 12;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 13:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4(">");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 13;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 14:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("<>");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 14;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 15:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4(" ");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 15;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 16:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4(",");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 16;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 17:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4(":");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 17;
				method_6(@class, arrayList);
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 18:
				int_0++;
				if (int_0 >= byte_0.Length)
				{
					return @class;
				}
				break;
			case 19:
				if (arrayList.Count >= 1)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_4("-");
					@class.method_10(new byte[1]);
					@class.method_9()[0] = 19;
					@class.Type = Enum180.const_2;
					Class1661 class2 = (Class1661)arrayList[arrayList.Count - 1];
					class2.method_6(@class);
					@class.method_8(new ArrayList());
					@class.method_7().Add(class2);
					arrayList[arrayList.Count - 1] = @class;
					int_0++;
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					break;
				}
				return null;
			case 20:
				if (arrayList.Count >= 1)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_4("%");
					@class.method_10(new byte[1]);
					@class.method_9()[0] = 20;
					@class.Type = Enum180.const_2;
					Class1661 class2 = (Class1661)arrayList[arrayList.Count - 1];
					class2.method_6(@class);
					@class.method_8(new ArrayList());
					@class.method_7().Add(class2);
					arrayList[arrayList.Count - 1] = @class;
					int_0++;
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					break;
				}
				return null;
			case 21:
				if (arrayList.Count >= 1)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_4("()");
					@class.method_10(new byte[1]);
					@class.method_9()[0] = 21;
					@class.Type = Enum180.const_2;
					Class1661 class2 = (Class1661)arrayList[arrayList.Count - 1];
					class2.method_6(@class);
					@class.method_8(new ArrayList());
					@class.method_7().Add(class2);
					arrayList[arrayList.Count - 1] = @class;
					int_0++;
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					break;
				}
				return null;
			case 22:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 22;
				@class.Type = Enum180.const_1;
				int_0++;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 23:
			{
				@class = new Class1661(worksheetCollection_0);
				int num5 = ((((uint)byte_0[int_0 + 2] & (true ? 1u : 0u)) != 0) ? (byte_0[int_0 + 1] * 2 + 3) : (byte_0[int_0 + 1] + 3));
				@class.method_10(new byte[num5]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, num5);
				int_0 += num5;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			}
			case 24:
				if (byte_0[int_0 + 1] == 25)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_10(new byte[14]);
					Array.Copy(byte_0, int_0, @class.method_9(), 0, 14);
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
					int_0 += 14;
				}
				else if (byte_0[int_0 + 1] == 29)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_10(new byte[6]);
					Array.Copy(byte_0, int_0, @class.method_9(), 0, 6);
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
					int_0 += 6;
				}
				else if (byte_0[int_0 + 1] == 7)
				{
					@class = new Class1661(worksheetCollection_0);
					@class.method_10(new byte[6]);
					Array.Copy(byte_0, int_0, @class.method_9(), 0, 6);
					if (int_0 >= byte_0.Length)
					{
						return @class;
					}
					arrayList.Add(@class);
					int_0 += 6;
				}
				else
				{
					int_0++;
				}
				break;
			case 25:
				if (byte_0[int_0 + 1] <= 2)
				{
					int_0 += 4;
					break;
				}
				@class = method_1(byte_0, ref int_0, arrayList, cell_0);
				if (@class == null)
				{
					if (int_0 < byte_0.Length)
					{
						break;
					}
					return @class;
				}
				if (int_0 < byte_0.Length)
				{
					if (!(@class.method_3() == " "))
					{
						arrayList.Add(@class);
					}
					break;
				}
				if (@class.method_3() == " ")
				{
					return (Class1661)arrayList[arrayList.Count - 1];
				}
				return @class;
			case 28:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[2]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 2);
				int_0 += 2;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 29:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[2]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 2);
				int_0 += 2;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 30:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[3]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 3);
				int_0 += 3;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 31:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[9]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 9);
				int_0 += 9;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 32:
			case 64:
			case 96:
				@class = new Class1661(worksheetCollection_0);
				@class.method_4("{}");
				@class.method_10(new byte[1]);
				@class.method_9()[0] = 96;
				method_7(@class, byte_0, int_0, ref num2);
				int_0 += 8;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 33:
			case 65:
			case 97:
				_ = arrayList.Count;
				@class = method_4(byte_0, int_0, arrayList, cell_0);
				@class.method_10(new byte[3]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 3);
				@class.method_9()[0] = 33;
				int_0 += 3;
				if (int_0 >= byte_0.Length)
				{
					return @class;
				}
				break;
			case 34:
			case 66:
			case 98:
				_ = arrayList.Count;
				@class = method_5(byte_0, int_0, arrayList, cell_0);
				@class.method_10(new byte[4]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 4);
				@class.method_9()[0] = 34;
				int_0 += 4;
				if (int_0 >= byte_0.Length)
				{
					return @class;
				}
				break;
			case 35:
			case 67:
			case 99:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[5]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 5);
				int_0 += 5;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 38:
			case 70:
			case 102:
				int_0 += 7;
				break;
			case 39:
			case 71:
			case 103:
				int_0 += 7;
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
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[5]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 5);
				int_0 += 5;
				arrayList.Add(@class);
				break;
			case 43:
			case 75:
			case 107:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[9]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 9);
				int_0 += 9;
				arrayList.Add(@class);
				break;
			case 36:
			case 44:
			case 68:
			case 76:
			case 100:
			case 108:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[5]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 5);
				int_0 += 5;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 37:
			case 45:
			case 69:
			case 77:
			case 101:
			case 109:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[9]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 9);
				int_0 += 9;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 57:
			case 89:
			case 121:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[7]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 7);
				int_0 += 7;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 58:
			case 90:
			case 122:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[7]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 7);
				int_0 += 7;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 59:
			case 91:
			case 123:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[11]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 11);
				int_0 += 11;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 60:
			case 92:
			case 124:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[7]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 7);
				int_0 += 7;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 61:
			case 93:
			case 125:
				@class = new Class1661(worksheetCollection_0);
				@class.method_10(new byte[11]);
				Array.Copy(byte_0, int_0, @class.method_9(), 0, 11);
				int_0 += 11;
				if (int_0 < byte_0.Length)
				{
					arrayList.Add(@class);
					break;
				}
				return @class;
			case 1:
			{
				ushort num4 = BitConverter.ToUInt16(byte_0, int_0 + 1);
				byte b = byte_0[int_0 + 3];
				Cell cell = cell_0;
				cell = ((cell_0.Row != num4 || cell_0.Column != b) ? cell_0.method_4().GetCell(num4, b, bool_2: false) : cell_0);
				if (cell.method_50() != null)
				{
					return method_0(cell_0, cell.method_50().Formula, -1);
				}
				return null;
			}
			default:
				return null;
			}
		}
		return @class;
	}

	private Class1661 method_1(byte[] byte_0, ref int int_0, ArrayList arrayList_0, Cell cell_0)
	{
		Class1661 @class = new Class1661(worksheetCollection_0);
		switch (byte_0[int_0 + 1])
		{
		case 8:
			int_0 += 4;
			return null;
		case 1:
			int_0 += 4;
			return null;
		case 2:
			if (arrayList_0 != null && arrayList_0.Count != 0)
			{
				int_0 += 4;
				return null;
			}
			return null;
		case 4:
		{
			Class1661 class2 = (Class1661)arrayList_0[arrayList_0.Count - 1];
			class2.method_6(@class);
			ArrayList arrayList = new ArrayList();
			arrayList.Add(class2);
			@class.method_8(arrayList);
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			@class.Type = Enum180.const_3;
			@class.method_4("CHOOSE");
			int num = BitConverter.ToUInt16(byte_0, int_0 + 2);
			int[] array = new int[num + 1];
			for (int i = 0; i < num + 1; i++)
			{
				int startIndex = int_0 + 4 + 2 * i;
				array[i] = BitConverter.ToUInt16(byte_0, startIndex);
			}
			for (int j = 0; j < num; j++)
			{
				int num2 = array[j];
				int num3 = array[j + 1];
				int num4 = num3 - num2 - 4;
				byte[] array2 = new byte[num4];
				Array.Copy(byte_0, int_0 + 4 + num2, array2, 0, num4);
				Class1661 class3 = method_0(cell_0, array2, 0);
				@class.method_7().Add(class3);
				class3.method_6(@class);
			}
			int num5 = BitConverter.ToUInt16(byte_0, int_0 + 4 + 2 * num);
			int_0 += num5 + 8;
			return @class;
		}
		default:
			int_0 += 4;
			return null;
		case 64:
			@class.method_4(" ");
			int_0 += 4;
			return @class;
		case 16:
			if (arrayList_0 != null && arrayList_0.Count != 0)
			{
				Class1661 class2 = (Class1661)arrayList_0[arrayList_0.Count - 1];
				class2.method_6(@class);
				ArrayList arrayList = new ArrayList();
				arrayList.Add(class2);
				@class.method_8(arrayList);
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
				@class.Type = Enum180.const_3;
				@class.method_4("SUM");
				int_0 += 4;
				return @class;
			}
			return null;
		}
	}

	private Class1661 method_2(string string_0, int int_0, ArrayList arrayList_0, Cell cell_0)
	{
		Class1661 @class = new Class1661(worksheetCollection_0);
		@class.Type = Enum180.const_3;
		@class.method_4(string_0);
		ArrayList arrayList = new ArrayList();
		for (int num = int_0 - 1; num > 0; num--)
		{
			Class1661 class2 = (Class1661)arrayList_0[arrayList_0.Count - num];
			class2.method_6(@class);
			arrayList.Add(class2);
		}
		@class.method_8(arrayList);
		for (int i = 0; i < int_0; i++)
		{
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
		}
		arrayList_0.Add(@class);
		return @class;
	}

	private Class1661 method_3(string string_0, int int_0, ArrayList arrayList_0, Cell cell_0)
	{
		Class1661 @class = new Class1661(worksheetCollection_0);
		@class.Type = Enum180.const_3;
		@class.method_4(string_0);
		ArrayList arrayList = new ArrayList();
		for (int num = int_0; num > 0; num--)
		{
			Class1661 class2 = (Class1661)arrayList_0[arrayList_0.Count - num];
			class2.method_6(@class);
			arrayList.Add(class2);
		}
		@class.method_8(arrayList);
		for (int i = 0; i < int_0; i++)
		{
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
		}
		arrayList_0.Add(@class);
		return @class;
	}

	private Class1661 method_4(byte[] byte_0, int int_0, ArrayList arrayList_0, Cell cell_0)
	{
		new Class1661(worksheetCollection_0);
		ushort num = BitConverter.ToUInt16(byte_0, int_0 + 1);
		switch (num)
		{
		case 48:
			return method_3("TEXT", 2, arrayList_0, cell_0);
		case 2:
			return method_3("ISNA", 1, arrayList_0, cell_0);
		case 3:
			return method_3("ISERROR", 1, arrayList_0, cell_0);
		case 10:
			return method_3("NA", 0, arrayList_0, cell_0);
		case 15:
			return method_3("SIN", 1, arrayList_0, cell_0);
		case 16:
			return method_3("COS", 1, arrayList_0, cell_0);
		case 17:
			return method_3("TAN", 1, arrayList_0, cell_0);
		case 18:
			return method_3("ATAN", 1, arrayList_0, cell_0);
		case 19:
			return method_3("PI", 0, arrayList_0, cell_0);
		case 20:
			return method_3("SQRT", 1, arrayList_0, cell_0);
		case 21:
			return method_3("EXP", 1, arrayList_0, cell_0);
		case 22:
			return method_3("LN", 1, arrayList_0, cell_0);
		case 23:
			return method_3("LOG10", 1, arrayList_0, cell_0);
		case 24:
			return method_3("ABS", 1, arrayList_0, cell_0);
		case 25:
			return method_3("INT", 1, arrayList_0, cell_0);
		case 26:
			return method_3("SIGN", 1, arrayList_0, cell_0);
		case 27:
			return method_3("ROUND", 2, arrayList_0, cell_0);
		case 30:
			return method_3("REPT", 2, arrayList_0, cell_0);
		case 31:
			return method_3("MID", 3, arrayList_0, cell_0);
		case 32:
			return method_3("LEN", 1, arrayList_0, cell_0);
		case 33:
			return method_3("VALUE", 1, arrayList_0, cell_0);
		case 38:
			return method_3("NOT", 1, arrayList_0, cell_0);
		case 39:
			return method_3("MOD", 2, arrayList_0, cell_0);
		case 97:
			return method_3("ATAN2", 2, arrayList_0, cell_0);
		case 98:
			return method_3("ASIN", 1, arrayList_0, cell_0);
		case 99:
			return method_3("ACOS", 1, arrayList_0, cell_0);
		case 63:
			return method_3("RAND", 0, arrayList_0, cell_0);
		case 65:
			return method_3("DATE", 3, arrayList_0, cell_0);
		case 66:
			return method_3("TIME", 3, arrayList_0, cell_0);
		case 67:
			return method_3("DAY", 1, arrayList_0, cell_0);
		case 68:
			return method_3("MONTH", 1, arrayList_0, cell_0);
		case 69:
			return method_3("YEAR", 1, arrayList_0, cell_0);
		case 71:
			return method_3("HOUR", 1, arrayList_0, cell_0);
		case 72:
			return method_3("MINUTE", 1, arrayList_0, cell_0);
		case 73:
			return method_3("SECOND", 1, arrayList_0, cell_0);
		case 74:
			return method_3("NOW", 0, arrayList_0, cell_0);
		case 76:
			return method_3("ROWS", 1, arrayList_0, cell_0);
		case 77:
			return method_3("COLUMNS", 1, arrayList_0, cell_0);
		case 83:
			return method_3("TRANSPOSE", 1, arrayList_0, cell_0);
		case 86:
			return method_3("TYPE", 1, arrayList_0, cell_0);
		case 111:
			return method_3("CHAR", 1, arrayList_0, cell_0);
		case 113:
			return method_3("UPPER", 1, arrayList_0, cell_0);
		case 117:
			return method_3("EXACT", 2, arrayList_0, cell_0);
		case 118:
			return method_3("TRIM", 1, arrayList_0, cell_0);
		case 119:
			return method_3("REPLACE", 4, arrayList_0, cell_0);
		case 105:
			return method_3("ISREF", 1, arrayList_0, cell_0);
		case 190:
			return method_3("ISNONTEXT", 1, arrayList_0, cell_0);
		case 140:
			return method_3("DATEVALUE", 1, arrayList_0, cell_0);
		case 141:
			return method_3("TIMEVALUE", 1, arrayList_0, cell_0);
		case 142:
			return method_3("SLN", 3, arrayList_0, cell_0);
		case 143:
			return method_3("SYD", 4, arrayList_0, cell_0);
		case 126:
			return method_3("ISERR", 1, arrayList_0, cell_0);
		case 127:
			return method_3("ISTEXT", 1, arrayList_0, cell_0);
		case 128:
			return method_3("ISNUMBER", 1, arrayList_0, cell_0);
		case 129:
			return method_3("ISBLANK", 1, arrayList_0, cell_0);
		case 221:
			return method_3("TODAY", 0, arrayList_0, cell_0);
		case 212:
			return method_3("ROUNDUP", 2, arrayList_0, cell_0);
		case 213:
			return method_3("ROUNDDOWN", 2, arrayList_0, cell_0);
		case 273:
			return method_3("BINOMDIST", 4, arrayList_0, cell_0);
		case 274:
			return method_3("CHIDIST", 2, arrayList_0, cell_0);
		case 275:
			return method_3("CHIINV", 2, arrayList_0, cell_0);
		case 279:
			return method_3("EVEN", 1, arrayList_0, cell_0);
		case 280:
			return method_3("EXPONDIST", 3, arrayList_0, cell_0);
		case 281:
			return method_3("FDIST", 3, arrayList_0, cell_0);
		case 282:
			return method_3("FINV", 3, arrayList_0, cell_0);
		case 285:
			return method_3("FLOOR", 2, arrayList_0, cell_0);
		case 286:
			return method_3("GAMMADIST", 4, arrayList_0, cell_0);
		case 287:
			return method_3("GAMMAINV", 3, arrayList_0, cell_0);
		case 288:
			return method_3("CEILING", 2, arrayList_0, cell_0);
		case 293:
			return method_3("NORMDIST", 4, arrayList_0, cell_0);
		case 294:
			return method_3("NORMSDIST", 1, arrayList_0, cell_0);
		case 295:
			return method_3("NORMINV", 3, arrayList_0, cell_0);
		case 296:
			return method_3("NORMSINV", 1, arrayList_0, cell_0);
		case 300:
			return method_3("POISSON", 3, arrayList_0, cell_0);
		case 301:
			return method_3("TDIST", 3, arrayList_0, cell_0);
		case 307:
			return method_3("CORREL", 2, arrayList_0, cell_0);
		case 309:
			return method_3("FORECAST", 3, arrayList_0, cell_0);
		case 312:
			return method_3("PEARSON", 2, arrayList_0, cell_0);
		case 313:
			return method_3("RSQ", 2, arrayList_0, cell_0);
		case 252:
			return method_3("FREQUENCY", 2, arrayList_0, cell_0);
		case 229:
			return method_3("SINH", 1, arrayList_0, cell_0);
		case 230:
			return method_3("COSH", 1, arrayList_0, cell_0);
		case 231:
			return method_3("TANH", 1, arrayList_0, cell_0);
		case 232:
			return method_3("ASINH", 1, arrayList_0, cell_0);
		case 233:
			return method_3("ACOSH", 1, arrayList_0, cell_0);
		case 234:
			return method_3("ATANH", 1, arrayList_0, cell_0);
		case 332:
			return method_3("TINV", 2, arrayList_0, cell_0);
		case 325:
			return method_3("LARGE", 2, arrayList_0, cell_0);
		case 326:
			return method_3("SMALL", 2, arrayList_0, cell_0);
		case 328:
			return method_3("PERCENTILE", 2, arrayList_0, cell_0);
		case 351:
			return method_3("DATEDIF", 3, arrayList_0, cell_0);
		case 342:
			return method_3("RADIANS", 1, arrayList_0, cell_0);
		case 343:
			return method_3("DEGREES", 1, arrayList_0, cell_0);
		default:
		{
			Class1663 @class = Class1663.smethod_3(num);
			if (@class != null)
			{
				return method_3(@class.string_0, @class.byte_1, arrayList_0, cell_0);
			}
			throw new CellsException(ExceptionType.Formula, "Unsupported function in formula calculation engine - code " + num);
		}
		case 346:
			return method_3("COUNTIF", 2, arrayList_0, cell_0);
		case 347:
			return method_3("COUNTBLANK", 1, arrayList_0, cell_0);
		case 337:
			return method_3("POWER", 2, arrayList_0, cell_0);
		}
	}

	private Class1661 method_5(byte[] byte_0, int int_0, ArrayList arrayList_0, Cell cell_0)
	{
		new Class1661(worksheetCollection_0);
		byte b = byte_0[int_0 + 1];
		if (b != 0 && (arrayList_0 == null || arrayList_0.Count < b))
		{
			return null;
		}
		ushort num = BitConverter.ToUInt16(byte_0, int_0 + 2);
		switch (num)
		{
		case 36:
			return method_3("AND", b, arrayList_0, cell_0);
		case 37:
			return method_3("OR", b, arrayList_0, cell_0);
		case 28:
			return method_3("LOOKUP", b, arrayList_0, cell_0);
		case 29:
			return method_3("INDEX", b, arrayList_0, cell_0);
		case 0:
			return method_3("COUNT", b, arrayList_0, cell_0);
		case 1:
			return method_3("IF", b, arrayList_0, cell_0);
		case 4:
			return method_3("SUM", b, arrayList_0, cell_0);
		case 5:
			return method_3("AVERAGE", b, arrayList_0, cell_0);
		case 6:
			return method_3("MIN", b, arrayList_0, cell_0);
		case 7:
			return method_3("MAX", b, arrayList_0, cell_0);
		case 8:
			return method_3("ROW", b, arrayList_0, cell_0);
		case 9:
			return method_3("COLUMN", b, arrayList_0, cell_0);
		case 11:
			return method_3("NPV", b, arrayList_0, cell_0);
		case 12:
			return method_3("STDEV", b, arrayList_0, cell_0);
		case 14:
			return method_3("FIXED", b, arrayList_0, cell_0);
		case 82:
			return method_3("SEARCH", b, arrayList_0, cell_0);
		case 78:
			return method_3("OFFSET", b, arrayList_0, cell_0);
		case 49:
			return method_3("LINEST", b, arrayList_0, cell_0);
		case 50:
			return method_3("TREND", b, arrayList_0, cell_0);
		case 51:
			return method_3("LOGEST", b, arrayList_0, cell_0);
		case 52:
			return method_3("GROWTH", b, arrayList_0, cell_0);
		case 56:
			return method_3("PV", b, arrayList_0, cell_0);
		case 57:
			return method_3("FV", b, arrayList_0, cell_0);
		case 58:
			return method_3("NPER", b, arrayList_0, cell_0);
		case 59:
			return method_3("PMT", b, arrayList_0, cell_0);
		case 60:
			return method_3("RATE", b, arrayList_0, cell_0);
		case 62:
			return method_3("IRR", b, arrayList_0, cell_0);
		case 64:
			return method_3("MATCH", b, arrayList_0, cell_0);
		case 70:
			return method_3("WEEKDAY", b, arrayList_0, cell_0);
		case 120:
			return method_3("SUBSTITUTE", b, arrayList_0, cell_0);
		case 115:
			return method_3("LEFT", b, arrayList_0, cell_0);
		case 116:
			return method_3("RIGHT", b, arrayList_0, cell_0);
		case 100:
			return method_3("CHOOSE", b, arrayList_0, cell_0);
		case 101:
			return method_3("HLOOKUP", b, arrayList_0, cell_0);
		case 102:
			return method_3("VLOOKUP", b, arrayList_0, cell_0);
		case 148:
			return method_3("INDIRECT", b, arrayList_0, cell_0);
		case 144:
			return method_3("DDB", b, arrayList_0, cell_0);
		case 124:
			return method_3("FIND", b, arrayList_0, cell_0);
		case 125:
			return method_3("CELL", b, arrayList_0, cell_0);
		case 193:
			return method_3("STDEVP", b, arrayList_0, cell_0);
		case 183:
			return method_3("PRODUCT", b, arrayList_0, cell_0);
		case 167:
			return method_3("IPMT", b, arrayList_0, cell_0);
		case 168:
			return method_3("PPMT", b, arrayList_0, cell_0);
		case 169:
			return method_3("COUNTA", b, arrayList_0, cell_0);
		case 216:
			return method_3("RANK", b, arrayList_0, cell_0);
		case 219:
			return method_3("ADDRESS", b, arrayList_0, cell_0);
		case 220:
			return method_3("DAYS360", b, arrayList_0, cell_0);
		case 13:
		case 184:
		case 204:
			return method_3("DOLLAR", b, arrayList_0, cell_0);
		case 197:
			return method_3("TRUNC", b, arrayList_0, cell_0);
		case 270:
			return method_3("BETADIST", b, arrayList_0, cell_0);
		case 272:
			return method_3("BETAINV", b, arrayList_0, cell_0);
		case 255:
		{
			Class1661 class2 = (Class1661)arrayList_0[arrayList_0.Count - b];
			byte[] array = class2.method_9();
			int num2;
			if (array[0] != 35 && array[0] != 67)
			{
				ushort int_ = BitConverter.ToUInt16(array, 1);
				num2 = BitConverter.ToUInt16(array, 3);
				int int_2 = worksheetCollection_0.method_32().method_12(int_);
				Class1303 class3 = worksheetCollection_0.method_39();
				if (class3 != null && class3.Count != 0)
				{
					Class1718 class4 = class3[int_2];
					Class1653 class5 = (Class1653)class4.method_0()[num2 - 1];
					return method_2(class5.Name.ToUpper(), b, arrayList_0, cell_0);
				}
				return null;
			}
			arrayList_0.RemoveAt(arrayList_0.Count - b);
			num2 = BitConverter.ToUInt16(array, 1) - 1;
			Name name = worksheetCollection_0.Names[num2];
			if (!bool_0)
			{
				bool_0 = Class1663.smethod_0(name.Text);
			}
			return method_3(name.Text, b - 1, arrayList_0, cell_0);
		}
		case 227:
			return method_3("MEDIAN", b, arrayList_0, cell_0);
		case 228:
			return method_3("SUMPRODUCT", b, arrayList_0, cell_0);
		case 336:
			return method_3("CONCATENATE", b, arrayList_0, cell_0);
		case 319:
			return method_3("GEOMEAN", b, arrayList_0, cell_0);
		case 359:
			return method_3("HYPERLINK", b, arrayList_0, cell_0);
		default:
		{
			Class1663 @class = Class1663.smethod_3(num);
			if (@class != null)
			{
				return method_3(@class.string_0, b, arrayList_0, cell_0);
			}
			throw new CellsException(ExceptionType.Formula, "Unsupported function in formula calculation engine - code " + num);
		}
		case 361:
			return method_3("AVERAGEA", b, arrayList_0, cell_0);
		case 362:
			return method_3("MAXA", b, arrayList_0, cell_0);
		case 363:
			return method_3("MINA", b, arrayList_0, cell_0);
		case 364:
			return method_3("STDEVPA", b, arrayList_0, cell_0);
		case 344:
			return method_3("SUBTOTAL", b, arrayList_0, cell_0);
		case 345:
			return method_3("SUMIF", b, arrayList_0, cell_0);
		}
	}

	private void method_6(Class1661 class1661_0, ArrayList arrayList_0)
	{
		class1661_0.Type = Enum180.const_2;
		ArrayList arrayList = new ArrayList();
		Class1661 @class = (Class1661)arrayList_0[arrayList_0.Count - 2];
		@class.method_6(class1661_0);
		arrayList.Add(@class);
		@class = (Class1661)arrayList_0[arrayList_0.Count - 1];
		@class.method_6(class1661_0);
		arrayList.Add(@class);
		arrayList_0.RemoveAt(arrayList_0.Count - 1);
		arrayList_0.RemoveAt(arrayList_0.Count - 1);
		class1661_0.method_8(arrayList);
	}

	private void method_7(Class1661 class1661_0, byte[] byte_0, int int_0, ref int int_1)
	{
		int num = byte_0[int_1] + 1;
		int num2 = BitConverter.ToUInt16(byte_0, int_1 + 1) + 1;
		class1661_0.method_8(new ArrayList());
		object[][] array = new object[num2][];
		class1661_0.method_7().Add(array);
		int_1 += 3;
		for (int i = 0; i < num2; i++)
		{
			array[i] = new object[num];
			for (int j = 0; j < num; j++)
			{
				switch (byte_0[int_1])
				{
				case 16:
					array[i][j] = Class1673.smethod_5(byte_0[int_1 + 1]);
					int_1 += 9;
					break;
				case 0:
					int_1 += 9;
					break;
				case 1:
					int_1++;
					array[i][j] = BitConverter.ToDouble(byte_0, int_1);
					int_1 += 8;
					break;
				case 2:
				{
					int_1++;
					int num3 = BitConverter.ToUInt16(byte_0, int_1);
					if (num3 != 0)
					{
						string text = null;
						if (byte_0[int_1 + 2] == 0)
						{
							text = Encoding.ASCII.GetString(byte_0, int_1 + 3, num3);
							int_1 += 3 + num3;
						}
						else
						{
							text = Encoding.Unicode.GetString(byte_0, int_1 + 3, num3 * 2);
							int_1 += 3 + num3 * 2;
						}
						array[i][j] = text;
					}
					else
					{
						int_1 += 3;
					}
					break;
				}
				case 4:
					array[i][j] = byte_0[int_1 + 1] == 1;
					int_1 += 9;
					break;
				}
			}
		}
	}
}
