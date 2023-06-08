using System;
using System.Collections;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns12;
using ns16;
using ns2;
using ns22;
using ns45;
using ns58;

namespace ns51;

internal class Class1274
{
	private int int_0;

	private Hashtable hashtable_0;

	private StringBuilder stringBuilder_0;

	private WorksheetCollection worksheetCollection_0;

	private Cell cell_0;

	private int int_1;

	private int int_2;

	internal void method_0()
	{
		int_0 = 1;
		hashtable_0 = new Hashtable();
		int num = 0;
		for (int i = 0; i < worksheetCollection_0.method_39().Count; i++)
		{
			Class1718 @class = worksheetCollection_0.method_39()[i];
			if (@class.method_12())
			{
				num++;
			}
			else if (@class.method_25() != null && !(@class.method_25().Trim() == ""))
			{
				hashtable_0.Add(i, i + 1 - num);
			}
			else
			{
				num++;
			}
		}
	}

	internal void method_1()
	{
		int_0 = 0;
		hashtable_0 = null;
	}

	internal Class1274(WorksheetCollection worksheetCollection_1)
	{
		stringBuilder_0 = new StringBuilder();
		worksheetCollection_0 = worksheetCollection_1;
	}

	private void method_2(StringBuilder stringBuilder_1, byte[] byte_0, int int_3)
	{
		int index = BitConverter.ToUInt16(byte_0, int_3) - 1;
		stringBuilder_1.Append(worksheetCollection_0.Names[index].Text);
	}

	internal string method_3(Cell cell_1)
	{
		cell_0 = cell_1;
		int num = 4;
		byte[] array = cell_1.method_41();
		if (array[4] == 1 && array[0] == 7)
		{
			int row = BitConverter.ToInt32(array, num + 1);
			int column = Class1268.smethod_1(array, num + 5);
			Cell cell = cell_1.method_4().CheckCell(row, column);
			if (cell != null && cell.method_50() != null)
			{
				return method_5(-1, -1, cell.method_50().Formula, cell_1.Row, cell_1.Column, !cell.method_50().method_1());
			}
			return null;
		}
		if (array[num] == 2 && array[0] == 7)
		{
			int num2 = BitConverter.ToInt32(array, num + 1);
			int num3 = Class1268.smethod_1(array, num + 5);
			Cell cell2 = cell_1.method_4().GetCell(num2, num3, bool_2: false);
			if (cell2.method_52() != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				Class1119 @class = cell2.method_52();
				stringBuilder.Append("{=TABLE(");
				if (@class.method_9())
				{
					stringBuilder.Append(@class.method_12());
				}
				stringBuilder.Append(",");
				if (@class.method_11())
				{
					stringBuilder.Append(@class.method_14());
				}
				stringBuilder.Append(")}");
				return stringBuilder.ToString();
			}
			return null;
		}
		return method_5(-1, -1, array, cell_1.Row, cell_1.Column, bool_0: false);
	}

	internal void method_4(StringBuilder stringBuilder_1, Class1661 class1661_0, int int_3, int int_4, bool bool_0)
	{
		int int_5 = 0;
		byte[] array = class1661_0.method_9();
		switch (array[0])
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
			method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[0], int_3, int_4, bool_0);
			stringBuilder_1.Append(class1661_0.method_3());
			method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[1], int_3, int_4, bool_0);
			break;
		case 18:
		case 19:
			stringBuilder_1.Append(class1661_0.method_3());
			method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[0], int_3, int_4, bool_0);
			break;
		case 20:
			method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[0], int_3, int_4, bool_0);
			stringBuilder_1.Append(class1661_0.method_3());
			break;
		case 21:
			stringBuilder_1.Append("(");
			method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[0], int_3, int_4, bool_0);
			stringBuilder_1.Append(")");
			break;
		case 23:
			try
			{
				int_5++;
				int num6 = BitConverter.ToUInt16(array, int_5);
				stringBuilder_1.Append("\"");
				if (num6 > 0)
				{
					string @string = Encoding.Unicode.GetString(array, int_5 + 2, 2 * num6);
					@string = @string.Replace("\"", "\"\"");
					if (int_0 == 1)
					{
						stringBuilder_1.Append(Class1618.smethod_4(@string));
					}
					else
					{
						stringBuilder_1.Append(@string);
					}
				}
				stringBuilder_1.Append("\"");
				break;
			}
			catch
			{
				throw new CellsException(ExceptionType.Formula, "Invalid formula.");
			}
		case 24:
		{
			string value = method_6(array, ref int_5, int_3, int_4);
			stringBuilder_1.Append(value);
			break;
		}
		case 25:
			if (class1661_0.method_3() != null && class1661_0.method_7().Count > 0)
			{
				stringBuilder_1.Append(class1661_0.method_3());
				stringBuilder_1.Append("(");
				for (int l = 0; l < class1661_0.method_7().Count; l++)
				{
					method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[l], int_3, int_4, bool_0);
				}
				stringBuilder_1.Append(")");
			}
			break;
		case 28:
			int_5++;
			stringBuilder_1.Append(Class1673.smethod_6(array[int_5]));
			int_5++;
			break;
		case 29:
			if (array[1] == 0)
			{
				stringBuilder_1.Append("FALSE");
			}
			else
			{
				stringBuilder_1.Append("TRUE");
			}
			break;
		case 30:
			stringBuilder_1.Append(BitConverter.ToUInt16(array, 1).ToString(CultureInfo.InvariantCulture));
			break;
		case 31:
		{
			double num2 = BitConverter.ToDouble(array, 1);
			if (!(num2 >= 1E+21) && Math.Abs(num2) > 1E-21)
			{
				stringBuilder_1.Append(Class1025.smethod_3(num2));
			}
			else
			{
				stringBuilder_1.Append(num2.ToString());
			}
			break;
		}
		case 32:
		case 64:
		case 96:
		{
			object[][] array2 = ((class1661_0.method_7() == null || class1661_0.method_7().Count == 0) ? null : ((object[][])class1661_0.method_7()[0]));
			for (int j = 0; j < array2.Length; j++)
			{
				for (int k = 0; k < array2[j].Length; k++)
				{
					stringBuilder_1.Append(array2[j].ToString());
					if (k != array2[j].Length - 1)
					{
						stringBuilder_1.Append(',');
					}
				}
				if (j != array2.Length - 1)
				{
					stringBuilder_1.Append(';');
				}
			}
			int_5 += 8;
			break;
		}
		case 33:
		case 34:
		case 65:
		case 66:
		case 97:
		case 98:
		{
			stringBuilder_1.Append(class1661_0.method_3());
			stringBuilder_1.Append("(");
			for (int i = 0; i < class1661_0.method_7().Count; i++)
			{
				method_4(stringBuilder_1, (Class1661)class1661_0.method_7()[i], int_3, int_4, bool_0);
			}
			stringBuilder_1.Append(")");
			break;
		}
		case 35:
		case 67:
		case 99:
			method_2(stringBuilder_1, array, 1);
			break;
		case 36:
		case 68:
		case 100:
			stringBuilder_1.Append(GetCell(array, 1));
			break;
		case 37:
		case 69:
		case 101:
			stringBuilder_1.Append(GetCellArea(array, 1));
			break;
		case 42:
		case 74:
		case 106:
			stringBuilder_1.Append("#REF!");
			break;
		case 44:
		case 76:
		case 108:
			stringBuilder_1.Append(method_10(array, 1, int_3, int_4));
			break;
		case 45:
		case 77:
		case 109:
			stringBuilder_1.Append(GetCellArea(array, 1));
			break;
		case 22:
		case 26:
		case 27:
		case 38:
		case 39:
		case 40:
		case 41:
		case 43:
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
		case 72:
		case 73:
		case 75:
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
		case 104:
		case 105:
		case 107:
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
			break;
		case 57:
		case 89:
		case 121:
		{
			int_5++;
			int num = BitConverter.ToUInt16(array, int_5);
			int num3 = worksheetCollection_0.method_32().method_12(num);
			Class1718 @class = null;
			if (worksheetCollection_0.method_39() != null && num3 < worksheetCollection_0.method_39().Count)
			{
				@class = worksheetCollection_0.method_39()[num3];
				if (@class.method_12())
				{
					@class = null;
				}
			}
			int_5 += 2;
			int num4 = BitConverter.ToUInt16(array, int_5);
			if (@class == null)
			{
				Name name = worksheetCollection_0.Names[num4 - 1];
				if (name.SheetIndex == 0)
				{
					stringBuilder_1.Append(name.Text);
				}
				else
				{
					string text3 = worksheetCollection_0[name.SheetIndex - 1].Name;
					if (text3.IndexOf(" ") != -1 || text3.IndexOf("-") != -1 || text3.IndexOf("&") != -1 || Class1677.smethod_19(text3) || Class1267.smethod_1(text3))
					{
						text3 = "'" + text3 + "'";
					}
					stringBuilder_1.Append(text3 + "!" + name.Text);
				}
			}
			else if (@class.method_14())
			{
				Class1653 class2 = (Class1653)@class.method_0()[num4 - 1];
				stringBuilder_1.Append(class2.Name.ToUpper());
			}
			else if (@class.Type == Enum194.const_0)
			{
				string text4 = null;
				if (@class.method_4() != null)
				{
					int num5 = worksheetCollection_0.method_32().method_13(num);
					if (num5 >= 0 && num5 < @class.method_4().Length)
					{
						text4 = @class.method_4()[num5];
					}
				}
				if (int_0 == 1)
				{
					bool flag;
					if (flag = text4 != null && Class1677.smethod_21(text4))
					{
						stringBuilder_1.Append('\'');
					}
					stringBuilder_1.Append('[');
					stringBuilder_1.Append(hashtable_0[num3]);
					stringBuilder_1.Append(']');
					if (text4 != null)
					{
						stringBuilder_1.Append(text4);
					}
					if (flag)
					{
						stringBuilder_1.Append('\'');
					}
				}
				else
				{
					stringBuilder_1.Append('\'');
					if (text4 != null)
					{
						stringBuilder_1.Append('[');
					}
					stringBuilder_1.Append(@class.method_25());
					if (text4 != null)
					{
						stringBuilder_1.Append(']');
						stringBuilder_1.Append(text4);
					}
					stringBuilder_1.Append('\'');
				}
				stringBuilder_1.Append("!");
				Class1653 class3 = (Class1653)@class.method_0()[num4 - 1];
				stringBuilder_1.Append(class3.Name.ToUpper());
			}
			else
			{
				if (@class.Type != Enum194.const_3)
				{
					break;
				}
				if (int_0 == 1)
				{
					stringBuilder_1.Append('[');
					stringBuilder_1.Append(hashtable_0[num3]);
					stringBuilder_1.Append(']');
				}
				else
				{
					@class.method_20(out var progId, out var fileName);
					stringBuilder_1.Append(progId);
					stringBuilder_1.Append("|");
					stringBuilder_1.Append(fileName);
				}
				stringBuilder_1.Append("!");
				Class1653 class4 = (Class1653)@class.method_0()[num4 - 1];
				stringBuilder_1.Append('\'');
				stringBuilder_1.Append(class4.Name.ToUpper());
				stringBuilder_1.Append('\'');
			}
			int_5 += 4;
			break;
		}
		case 58:
		case 90:
		case 122:
		{
			int_5++;
			int num = BitConverter.ToUInt16(array, int_5);
			string text2 = Class1268.smethod_0(num, worksheetCollection_0, int_0, hashtable_0);
			stringBuilder_1.Append(text2);
			stringBuilder_1.Append('!');
			if (text2[0] != '#')
			{
				int_5 += 2;
				stringBuilder_1.Append(GetCell(array, int_5));
				int_5 += 4;
			}
			else
			{
				int_5 += 6;
			}
			break;
		}
		case 59:
		case 91:
		case 123:
		{
			int_5++;
			int num = BitConverter.ToUInt16(array, int_5);
			string text = Class1268.smethod_0(num, worksheetCollection_0, int_0, hashtable_0);
			stringBuilder_1.Append(text);
			stringBuilder_1.Append('!');
			if (text[0] != '#')
			{
				int_5 += 2;
				stringBuilder_1.Append(GetCellArea(array, int_5));
				int_5 += 8;
			}
			else
			{
				int_5 += 10;
			}
			break;
		}
		case 60:
		case 61:
		case 92:
		case 93:
		case 124:
		case 125:
			stringBuilder_1.Append("#REF!");
			break;
		}
	}

	internal string method_5(int int_3, int int_4, byte[] byte_0, int int_5, int int_6, bool bool_0)
	{
		int num = byte_0.Length;
		if (int_4 != -1)
		{
			int_1 = int_4;
			int_2 = int_3 + int_4 + 4;
			num = int_3 + int_4;
		}
		else if (int_3 == -1)
		{
			int_3 = 4;
			int_1 = BitConverter.ToInt32(byte_0, 0);
			int_2 = 4 + int_1 + 4;
			num = 4 + int_1;
		}
		else
		{
			int_1 = 0;
			int_2 = 0;
			num = byte_0.Length;
		}
		stringBuilder_0 = new StringBuilder(256);
		ArrayList arrayList = new ArrayList();
		while (int_3 < num)
		{
			switch (byte_0[int_3])
			{
			case 3:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '+');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 4:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '-');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 5:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '*');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 6:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '/');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 7:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '^');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 8:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '&');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 9:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '<');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 10:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "<=");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 11:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '=');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 12:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ">=");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 13:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '>');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 14:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "<>");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 15:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, " ");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 16:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ",");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 17:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ":");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_3++;
				break;
			}
			case 18:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "+");
				int_3++;
				break;
			}
			case 19:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "-");
				int_3++;
				break;
			}
			case 20:
				stringBuilder_0.Append("%");
				int_3++;
				break;
			case 21:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "(");
				stringBuilder_0.Append(")");
				int_3++;
				break;
			}
			case 22:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				break;
			case 23:
				try
				{
					int_3++;
					int num8 = BitConverter.ToUInt16(byte_0, int_3);
					arrayList.Add(stringBuilder_0.Length);
					stringBuilder_0.Append("\"");
					if (num8 > 0)
					{
						string @string = Encoding.Unicode.GetString(byte_0, int_3 + 2, 2 * num8);
						@string = @string.Replace("\"", "\"\"");
						if (int_0 == 1)
						{
							stringBuilder_0.Append(Class1618.smethod_4(@string));
						}
						else
						{
							stringBuilder_0.Append(@string);
						}
					}
					stringBuilder_0.Append("\"");
					int_3 += 2 * num8 + 2;
				}
				catch
				{
					throw new CellsException(ExceptionType.Formula, "Invalid formula.");
				}
				break;
			case 24:
			{
				string value = method_6(byte_0, ref int_3, int_5, int_6);
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append(value);
				break;
			}
			case 25:
				int_3++;
				int_3 = method_8(byte_0, int_3, arrayList);
				break;
			case 28:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				stringBuilder_0.Append(Class1673.smethod_6(byte_0[int_3]));
				int_3++;
				break;
			case 29:
				int_3++;
				arrayList.Add(stringBuilder_0.Length);
				if (byte_0[int_3] == 0)
				{
					stringBuilder_0.Append("FALSE");
				}
				else
				{
					stringBuilder_0.Append("TRUE");
				}
				int_3++;
				break;
			case 30:
			{
				ushort num4 = BitConverter.ToUInt16(byte_0, int_3 + 1);
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append(num4.ToString(CultureInfo.InvariantCulture));
				int_3 += 3;
				break;
			}
			case 31:
			{
				double num3 = BitConverter.ToDouble(byte_0, int_3 + 1);
				arrayList.Add(stringBuilder_0.Length);
				if (!(num3 >= 1E+21) && Math.Abs(num3) > 1E-21)
				{
					stringBuilder_0.Append(Class1025.smethod_3(num3));
				}
				else
				{
					stringBuilder_0.Append(num3.ToString());
				}
				int_3 += 9;
				break;
			}
			case 32:
			case 64:
			case 96:
				method_7(byte_0, arrayList);
				int_3 += 15;
				break;
			case 33:
			case 65:
			case 97:
				int_3++;
				method_14(byte_0, int_3, arrayList);
				int_3 += 2;
				break;
			case 34:
			case 66:
			case 98:
				int_3++;
				method_13(byte_0, int_3, arrayList);
				int_3 += 3;
				break;
			case 35:
			case 67:
			case 99:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				method_2(stringBuilder_0, byte_0, int_3);
				int_3 += 4;
				break;
			case 36:
			case 68:
			case 100:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				stringBuilder_0.Append(GetCell(byte_0, int_3));
				int_3 += 6;
				break;
			case 37:
			case 69:
			case 101:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				stringBuilder_0.Append(GetCellArea(byte_0, int_3));
				int_3 += 12;
				break;
			case 38:
			case 70:
			case 102:
				int_3 += 7;
				break;
			case 39:
			case 71:
			case 103:
				int_3 += 7;
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
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append("#REF!");
				int_3 += 7;
				break;
			case 43:
			case 75:
			case 107:
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append("#REF!");
				int_3 += 13;
				break;
			case 44:
			case 76:
			case 108:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				stringBuilder_0.Append(method_10(byte_0, int_3, int_5, int_6));
				int_3 += 6;
				break;
			case 45:
			case 77:
			case 109:
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				stringBuilder_0.Append(method_9(byte_0, int_3, int_5, int_6));
				int_3 += 12;
				break;
			case 57:
			case 89:
			case 121:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				int num2 = BitConverter.ToUInt16(byte_0, int_3);
				int num5 = worksheetCollection_0.method_32().method_12(num2);
				Class1718 @class = null;
				if (worksheetCollection_0.method_39() != null && num5 < worksheetCollection_0.method_39().Count)
				{
					@class = worksheetCollection_0.method_39()[num5];
					if (@class.method_12())
					{
						@class = null;
					}
				}
				int_3 += 2;
				int num6 = BitConverter.ToUInt16(byte_0, int_3);
				if (@class == null)
				{
					Name name = worksheetCollection_0.Names[num6 - 1];
					if (name.SheetIndex == 0)
					{
						if (int_0 == 1)
						{
							stringBuilder_0.Append("[0]!");
						}
						else if (worksheetCollection_0.Workbook.FileName != null)
						{
							string text2 = Class1185.smethod_1(worksheetCollection_0.Workbook.FileName);
							if (Class1677.smethod_22(text2))
							{
								stringBuilder_0.Append('\'');
								stringBuilder_0.Append(text2);
								stringBuilder_0.Append('\'');
							}
							else
							{
								stringBuilder_0.Append(text2);
							}
							stringBuilder_0.Append('!');
						}
						stringBuilder_0.Append(name.Text);
					}
					else
					{
						string text3 = worksheetCollection_0[name.SheetIndex - 1].Name;
						if (text3.IndexOf(" ") != -1 || text3.IndexOf("-") != -1 || text3.IndexOf("&") != -1 || Class1677.smethod_19(text3) || Class1267.smethod_1(text3))
						{
							text3 = "'" + text3 + "'";
						}
						stringBuilder_0.Append(text3 + "!" + name.Text);
					}
				}
				else if (@class.method_14())
				{
					Class1653 class2 = (Class1653)@class.method_0()[num6 - 1];
					if (int_0 == 1 && Class1663.smethod_2(class2.Name))
					{
						stringBuilder_0.Append("_XLL.");
					}
					stringBuilder_0.Append(class2.Name.ToUpper());
				}
				else if (@class.Type != 0 && @class.Type != Enum194.const_4)
				{
					if (@class.Type != Enum194.const_3)
					{
						return null;
					}
					if (int_0 == 1)
					{
						stringBuilder_0.Append('[');
						stringBuilder_0.Append(hashtable_0[num5]);
						stringBuilder_0.Append(']');
					}
					else
					{
						@class.method_20(out var progId, out var fileName);
						stringBuilder_0.Append(progId);
						stringBuilder_0.Append("|");
						stringBuilder_0.Append(fileName);
					}
					stringBuilder_0.Append("!");
					Class1653 class3 = (Class1653)@class.method_0()[num6 - 1];
					stringBuilder_0.Append('\'');
					stringBuilder_0.Append(class3.Name.ToUpper());
					stringBuilder_0.Append('\'');
				}
				else
				{
					string text4 = null;
					if (@class.method_4() != null)
					{
						int num7 = worksheetCollection_0.method_32().method_13(num2);
						if (num7 >= 0 && num7 < @class.method_4().Length)
						{
							text4 = @class.method_4()[num7];
						}
					}
					if (int_0 == 1)
					{
						bool flag;
						if (flag = text4 != null && Class1677.smethod_21(text4))
						{
							stringBuilder_0.Append('\'');
						}
						stringBuilder_0.Append('[');
						stringBuilder_0.Append(hashtable_0[num5]);
						stringBuilder_0.Append(']');
						if (text4 != null)
						{
							stringBuilder_0.Append(text4);
						}
						if (flag)
						{
							stringBuilder_0.Append('\'');
						}
					}
					else
					{
						stringBuilder_0.Append('\'');
						if (text4 != null)
						{
							stringBuilder_0.Append('[');
						}
						stringBuilder_0.Append(@class.method_25());
						if (text4 != null)
						{
							stringBuilder_0.Append(']');
							stringBuilder_0.Append(text4);
						}
						stringBuilder_0.Append('\'');
					}
					stringBuilder_0.Append("!");
					Class1653 class4 = (Class1653)@class.method_0()[num6 - 1];
					bool flag2;
					if (flag2 = class4.Name != null && Class1677.smethod_22(class4.Name))
					{
						stringBuilder_0.Append('\'');
					}
					stringBuilder_0.Append(class4.Name);
					if (flag2)
					{
						stringBuilder_0.Append('\'');
					}
				}
				int_3 += 4;
				break;
			}
			case 58:
			case 90:
			case 122:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				int num2 = BitConverter.ToUInt16(byte_0, int_3);
				string text = Class1268.smethod_0(num2, worksheetCollection_0, int_0, hashtable_0);
				stringBuilder_0.Append(text);
				stringBuilder_0.Append('!');
				if (text.Length != 0 && text[0] == '#')
				{
					int_3 += 8;
					break;
				}
				int_3 += 2;
				if (bool_0)
				{
					stringBuilder_0.Append(method_10(byte_0, int_3, int_5, int_6));
				}
				else
				{
					stringBuilder_0.Append(GetCell(byte_0, int_3));
				}
				int_3 += 6;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				int num2 = BitConverter.ToUInt16(byte_0, int_3);
				string text = Class1268.smethod_0(num2, worksheetCollection_0, int_0, hashtable_0);
				stringBuilder_0.Append(text);
				stringBuilder_0.Append('!');
				if (text.Length != 0 && text[0] == '#')
				{
					int_3 += 14;
					break;
				}
				int_3 += 2;
				stringBuilder_0.Append(GetCellArea(byte_0, int_3));
				int_3 += 12;
				break;
			}
			case 60:
			case 92:
			case 124:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				int num2 = BitConverter.ToUInt16(byte_0, int_3);
				string text = Class1268.smethod_0(num2, worksheetCollection_0, int_0, hashtable_0);
				stringBuilder_0.Append(text);
				if (text[0] != '#')
				{
					stringBuilder_0.Append("!#REF!");
				}
				else
				{
					stringBuilder_0.Append('!');
				}
				int_3 += 8;
				break;
			}
			case 61:
			case 93:
			case 125:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_3++;
				int num2 = BitConverter.ToUInt16(byte_0, int_3);
				string text = Class1268.smethod_0(num2, worksheetCollection_0, int_0, hashtable_0);
				stringBuilder_0.Append(text);
				if (text[0] != '#')
				{
					stringBuilder_0.Append("!#REF!");
				}
				else
				{
					stringBuilder_0.Append('!');
				}
				int_3 += 14;
				break;
			}
			case 1:
			case 2:
				return null;
			default:
				return null;
			}
		}
		stringBuilder_0.Insert(0, '=');
		arrayList = null;
		return stringBuilder_0.ToString();
	}

	private string method_6(byte[] byte_0, ref int int_3, int int_4, int int_5)
	{
		switch (byte_0[int_3 + 1])
		{
		default:
			int_3++;
			return "#REF!";
		case 29:
		{
			int int_6 = BitConverter.ToInt32(byte_0, int_3 + 2);
			int_3 += 6;
			if (worksheetCollection_0.method_2() != null)
			{
				if (worksheetCollection_0.method_2() is Class1148)
				{
					Class1148 @class = (Class1148)worksheetCollection_0.method_2();
					return @class.method_2(int_6, int_0);
				}
				if (worksheetCollection_0.method_2() is Class1141)
				{
					Class1141 class2 = (Class1141)worksheetCollection_0.method_2();
					return class2.method_4(int_6);
				}
			}
			return "#REF!";
		}
		case 25:
		{
			string result = Class1689.ToString(worksheetCollection_0, cell_0, byte_0, int_3, int_4, int_5);
			int_3 += 14;
			return result;
		}
		}
	}

	private void method_7(byte[] byte_0, ArrayList arrayList_0)
	{
		arrayList_0.Add(stringBuilder_0.Length);
		stringBuilder_0.Append('{');
		int num = BitConverter.ToInt32(byte_0, int_2);
		int_2 += 4;
		int num2 = BitConverter.ToInt32(byte_0, int_2);
		int_2 += 4;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				switch (byte_0[int_2])
				{
				case 0:
					int_2++;
					stringBuilder_0.Append(BitConverter.ToDouble(byte_0, int_2));
					int_2 += 8;
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					break;
				case 1:
				{
					int_2++;
					int num3 = BitConverter.ToUInt16(byte_0, int_2);
					stringBuilder_0.Append("\"");
					if (num3 != 0)
					{
						string text = Encoding.Unicode.GetString(byte_0, int_2 + 2, num3 * 2);
						int_2 += 2 + num3 * 2;
						if (text != null && text != "")
						{
							text = text.Replace("\"", "\"\"");
						}
						stringBuilder_0.Append(text);
					}
					else
					{
						int_2 += 2;
					}
					stringBuilder_0.Append("\"");
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					break;
				}
				case 2:
					stringBuilder_0.Append((byte_0[int_2 + 1] == 1) ? "TRUE" : "FALSE");
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					int_2 += 2;
					break;
				case 4:
					stringBuilder_0.Append(Class1673.smethod_6(byte_0[int_2 + 1]));
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					int_2 += 5;
					break;
				}
			}
			if (i != num2 - 1)
			{
				stringBuilder_0.Append(';');
			}
		}
		stringBuilder_0.Append('}');
	}

	private int method_8(byte[] byte_0, int int_3, ArrayList arrayList_0)
	{
		switch (byte_0[int_3])
		{
		case 16:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SUM(");
			stringBuilder_0.Append(")");
			int_3 += 3;
			break;
		}
		default:
			int_3 += 3;
			break;
		case 4:
		{
			int_3 += 3;
			int num = BitConverter.ToUInt16(byte_0, int_3);
			int_3 += num;
			break;
		}
		}
		return int_3;
	}

	private string GetCellArea(byte[] byte_0, int int_3)
	{
		int num = BitConverter.ToInt32(byte_0, int_3);
		int num2 = BitConverter.ToInt32(byte_0, int_3 + 4);
		int num3 = Class1268.smethod_1(byte_0, int_3 + 8);
		int num4 = Class1268.smethod_1(byte_0, int_3 + 10);
		byte b = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (num == 0 && num2 == 1048575)
		{
			b = byte_0[int_3 + 9];
			if ((b & 0x40) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
			stringBuilder.Append(":");
			b = byte_0[int_3 + 11];
			if ((b & 0x40) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
			return stringBuilder.ToString();
		}
		if (num3 == 0 && num4 == 16383)
		{
			b = byte_0[int_3 + 9];
			if ((b & 0x80) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num + 1);
			stringBuilder.Append(":");
			b = byte_0[int_3 + 11];
			if ((b & 0x80) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num2 + 1);
			return stringBuilder.ToString();
		}
		b = byte_0[int_3 + 9];
		if ((b & 0x40) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
		if ((b & 0x80) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(num + 1);
		stringBuilder.Append(":");
		b = byte_0[int_3 + 11];
		if ((b & 0x40) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
		if ((b & 0x80) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(num2 + 1);
		return stringBuilder.ToString();
	}

	private string method_9(byte[] byte_0, int int_3, int int_4, int int_5)
	{
		byte byte_ = byte_0[int_3 + 9];
		byte byte_2 = byte_0[int_3 + 11];
		int num = Class1268.smethod_2(byte_0, int_3, int_4, byte_);
		int num2 = Class1268.smethod_2(byte_0, int_3 + 4, int_4, byte_2);
		int num3 = Class1268.smethod_6(byte_0, int_3 + 8, int_5, byte_);
		int num4 = Class1268.smethod_6(byte_0, int_3 + 10, int_5, byte_2);
		byte b = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (num == 0 && num2 == 1048575)
		{
			b = byte_0[int_3 + 9];
			if ((b & 0x40) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
			stringBuilder.Append(":");
			b = byte_0[int_3 + 11];
			if ((b & 0x40) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
			return stringBuilder.ToString();
		}
		if (num3 == 0 && num4 == 16383)
		{
			b = byte_0[int_3 + 9];
			if ((b & 0x80) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num + 1);
			stringBuilder.Append(":");
			b = byte_0[int_3 + 11];
			if ((b & 0x80) == 0)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num2 + 1);
			return stringBuilder.ToString();
		}
		b = byte_0[int_3 + 9];
		if ((b & 0x40) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
		if ((b & 0x80) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(num + 1);
		stringBuilder.Append(":");
		b = byte_0[int_3 + 11];
		if ((b & 0x40) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
		if ((b & 0x80) == 0)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(num2 + 1);
		return stringBuilder.ToString();
	}

	private string method_10(byte[] byte_0, int int_3, int int_4, int int_5)
	{
		byte b = byte_0[int_3 + 5];
		int num = Class1268.smethod_2(byte_0, int_3, int_4, b);
		int column = Class1268.smethod_6(byte_0, int_3 + 4, int_5, b);
		StringBuilder stringBuilder = new StringBuilder();
		if ((b & 0x40) == 0)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(column));
		if ((b & 0x80) == 0)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(num + 1);
		return stringBuilder.ToString();
	}

	private string GetCell(byte[] byte_0, int int_3)
	{
		int num = BitConverter.ToInt32(byte_0, int_3);
		int column = Class1268.smethod_1(byte_0, int_3 + 4);
		bool flag = true;
		bool flag2 = true;
		byte b = byte_0[int_3 + 5];
		if ((b & 0x40u) != 0)
		{
			flag2 = false;
		}
		if ((b & 0x80u) != 0)
		{
			flag = false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (flag2)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(column));
		if (flag)
		{
			stringBuilder.Append("$");
		}
		stringBuilder.Append(num + 1);
		return stringBuilder.ToString();
	}

	private void method_11(byte[] byte_0, int int_3, ArrayList arrayList_0)
	{
		int num = byte_0[int_3] - 1;
		int index;
		for (int i = 1; i < num; i++)
		{
			index = (int)arrayList_0[arrayList_0.Count - i];
			stringBuilder_0.Insert(index, ',');
		}
		int num2 = arrayList_0.Count - num;
		index = ((num2 >= arrayList_0.Count) ? stringBuilder_0.Length : ((int)arrayList_0[num2]));
		stringBuilder_0.Insert(index, "(");
		if (byte_0[int_3] - 1 > 0)
		{
			arrayList_0.RemoveRange(arrayList_0.Count - byte_0[int_3] + 1, byte_0[int_3] - 1);
		}
		stringBuilder_0.Append(")");
	}

	private void method_12(string string_0, int int_3, ArrayList arrayList_0)
	{
		int num = 0;
		for (int i = 1; i < int_3; i++)
		{
			num = (int)arrayList_0[arrayList_0.Count - i];
			stringBuilder_0.Insert(num, ',');
		}
		int num2 = arrayList_0.Count - int_3;
		if (num2 < arrayList_0.Count)
		{
			num = (int)arrayList_0[num2];
		}
		else
		{
			num = stringBuilder_0.Length;
			arrayList_0.Add(num);
		}
		stringBuilder_0.Insert(num, string_0 + "(");
		if (int_3 - 1 > 0)
		{
			arrayList_0.RemoveRange(arrayList_0.Count - int_3 + 1, int_3 - 1);
		}
	}

	private void method_13(byte[] byte_0, int int_3, ArrayList arrayList_0)
	{
		ushort num = BitConverter.ToUInt16(byte_0, int_3 + 1);
		if (num == 255)
		{
			method_11(byte_0, int_3, arrayList_0);
			return;
		}
		int index;
		for (int i = 1; i < byte_0[int_3]; i++)
		{
			index = (int)arrayList_0[arrayList_0.Count - i];
			stringBuilder_0.Insert(index, ',');
		}
		int num2 = arrayList_0.Count - byte_0[int_3];
		if (num2 < arrayList_0.Count)
		{
			index = (int)arrayList_0[num2];
		}
		else
		{
			index = stringBuilder_0.Length;
			arrayList_0.Add(index);
		}
		switch (num)
		{
		case 36:
			stringBuilder_0.Insert(index, "AND(");
			break;
		case 37:
			stringBuilder_0.Insert(index, "OR(");
			break;
		case 28:
			stringBuilder_0.Insert(index, "LOOKUP(");
			break;
		case 29:
			stringBuilder_0.Insert(index, "INDEX(");
			break;
		case 0:
			stringBuilder_0.Insert(index, "COUNT(");
			break;
		case 1:
			stringBuilder_0.Insert(index, "IF(");
			break;
		case 4:
			stringBuilder_0.Insert(index, "SUM(");
			break;
		case 5:
			stringBuilder_0.Insert(index, "AVERAGE(");
			break;
		case 6:
			stringBuilder_0.Insert(index, "MIN(");
			break;
		case 7:
			stringBuilder_0.Insert(index, "MAX(");
			break;
		case 8:
			stringBuilder_0.Insert(index, "ROW(");
			break;
		case 9:
			stringBuilder_0.Insert(index, "COLUMN(");
			break;
		case 11:
			stringBuilder_0.Insert(index, "NPV(");
			break;
		case 12:
			stringBuilder_0.Insert(index, "STDEV(");
			break;
		case 13:
			stringBuilder_0.Insert(index, "DOLLAR(");
			break;
		case 14:
			stringBuilder_0.Insert(index, "FIXED(");
			break;
		case 78:
			stringBuilder_0.Insert(index, "OFFSET(");
			break;
		case 70:
			stringBuilder_0.Insert(index, "WEEKDAY(");
			break;
		case 46:
			stringBuilder_0.Insert(index, "VAR(");
			break;
		case 49:
			stringBuilder_0.Insert(index, "LINEST(");
			break;
		case 50:
			stringBuilder_0.Insert(index, "TREND(");
			break;
		case 51:
			stringBuilder_0.Insert(index, "LOGEST(");
			break;
		case 52:
			stringBuilder_0.Insert(index, "GROWTH(");
			break;
		case 56:
			stringBuilder_0.Insert(index, "PV(");
			break;
		case 57:
			stringBuilder_0.Insert(index, "FV(");
			break;
		case 58:
			stringBuilder_0.Insert(index, "NPER(");
			break;
		case 59:
			stringBuilder_0.Insert(index, "PMT(");
			break;
		case 62:
			stringBuilder_0.Insert(index, "IRR(");
			break;
		case 64:
			stringBuilder_0.Insert(index, "MATCH(");
			break;
		case 109:
			stringBuilder_0.Insert(index, "LOG(");
			break;
		case 100:
			stringBuilder_0.Insert(index, "CHOOSE(");
			break;
		case 101:
			stringBuilder_0.Insert(index, "HLOOKUP(");
			break;
		case 102:
			stringBuilder_0.Insert(index, "VLOOKUP(");
			break;
		case 82:
			stringBuilder_0.Insert(index, "SEARCH(");
			break;
		case 124:
			stringBuilder_0.Insert(index, "FIND(");
			break;
		case 125:
			stringBuilder_0.Insert(index, "CELL(");
			break;
		case 120:
			stringBuilder_0.Insert(index, "SUBSTITUTE(");
			break;
		case 115:
			stringBuilder_0.Insert(index, "LEFT(");
			break;
		case 116:
			stringBuilder_0.Insert(index, "RIGHT(");
			break;
		case 167:
			stringBuilder_0.Insert(index, "IPMT(");
			break;
		case 168:
			stringBuilder_0.Insert(index, "PPMT(");
			break;
		case 169:
			stringBuilder_0.Insert(index, "COUNTA(");
			break;
		case 148:
			stringBuilder_0.Insert(index, "INDIRECT(");
			break;
		case 144:
			stringBuilder_0.Insert(index, "DDB(");
			break;
		case 204:
			stringBuilder_0.Insert(index, "DOLLAR(");
			break;
		case 193:
			stringBuilder_0.Insert(index, "STDEVP(");
			break;
		case 194:
			stringBuilder_0.Insert(index, "VARP(");
			break;
		case 197:
			stringBuilder_0.Insert(index, "TRUNC(");
			break;
		case 183:
			stringBuilder_0.Insert(index, "PRODUCT(");
			break;
		case 269:
			stringBuilder_0.Insert(index, "AVEDEV(");
			break;
		case 270:
			stringBuilder_0.Insert(index, "BETADIST(");
			break;
		case 272:
			stringBuilder_0.Insert(index, "BETAINV(");
			break;
		case 227:
			stringBuilder_0.Insert(index, "MEDIAN(");
			break;
		case 228:
			stringBuilder_0.Insert(index, "SUMPRODUCT(");
			break;
		case 216:
			stringBuilder_0.Insert(index, "RANK(");
			break;
		case 219:
			stringBuilder_0.Insert(index, "ADDRESS(");
			break;
		case 220:
			stringBuilder_0.Insert(index, "DAYS360(");
			break;
		case 354:
			stringBuilder_0.Insert(index, "ROMAN(");
			break;
		case 358:
			stringBuilder_0.Insert(index, "GETPIVOTDATA(");
			break;
		case 359:
			stringBuilder_0.Insert(index, "HYPERLINK(");
			break;
		case 361:
			stringBuilder_0.Insert(index, "AVERAGEA(");
			break;
		case 363:
			stringBuilder_0.Insert(index, "MINA(");
			break;
		case 364:
			stringBuilder_0.Insert(index, "STDEVPA(");
			break;
		case 366:
			stringBuilder_0.Insert(index, "STDEVA(");
			break;
		case 367:
			stringBuilder_0.Insert(index, "VARA(");
			break;
		case 344:
			stringBuilder_0.Insert(index, "SUBTOTAL(");
			break;
		case 345:
			stringBuilder_0.Insert(index, "SUMIF(");
			break;
		case 317:
			stringBuilder_0.Insert(index, "PROB(");
			break;
		case 318:
			stringBuilder_0.Insert(index, "DEVSQ(");
			break;
		case 319:
			stringBuilder_0.Insert(index, "GEOMEAN(");
			break;
		case 320:
			stringBuilder_0.Insert(index, "HARMEAN(");
			break;
		case 321:
			stringBuilder_0.Insert(index, "SUMSQ(");
			break;
		case 322:
			stringBuilder_0.Insert(index, "KURT(");
			break;
		case 323:
			stringBuilder_0.Insert(index, "SKEW(");
			break;
		case 324:
			stringBuilder_0.Insert(index, "ZTEST(");
			break;
		case 329:
			stringBuilder_0.Insert(index, "PERCENTRANK(");
			break;
		case 330:
			stringBuilder_0.Insert(index, "MODE(");
			break;
		default:
		{
			Class1663 @class = Class1663.smethod_3(num);
			if (@class != null)
			{
				stringBuilder_0.Insert(index, @class.string_0 + "(");
				break;
			}
			return;
		}
		case 336:
			stringBuilder_0.Insert(index, "CONCATENATE(");
			break;
		}
		if (byte_0[int_3] - 1 > 0)
		{
			arrayList_0.RemoveRange(arrayList_0.Count - byte_0[int_3] + 1, byte_0[int_3] - 1);
		}
		stringBuilder_0.Append(")");
	}

	private void method_14(byte[] byte_0, int int_3, ArrayList arrayList_0)
	{
		ushort num = BitConverter.ToUInt16(byte_0, int_3);
		switch (num)
		{
		case 97:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "ATAN2(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 98:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ASIN(");
			break;
		}
		case 99:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ACOS(");
			break;
		}
		case 105:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISREF(");
			break;
		}
		case 111:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "CHAR(");
			break;
		}
		case 112:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "LOWER(");
			break;
		}
		case 113:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "UPPER(");
			break;
		}
		case 114:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "PROPER(");
			break;
		}
		case 117:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "EXACT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 118:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "TRIM(");
			break;
		}
		case 119:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num29 = 1; num29 < 4; num29++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num29];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "REPLACE(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 121:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "CODE(");
			break;
		}
		case 126:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISERR(");
			break;
		}
		case 127:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISTEXT(");
			break;
		}
		case 128:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISNUMBER(");
			break;
		}
		case 129:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISBLANK(");
			break;
		}
		case 130:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "T(");
			break;
		}
		case 131:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "N(");
			break;
		}
		case 2:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISNA(");
			break;
		}
		case 3:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISERROR(");
			break;
		}
		case 10:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("NA(");
			break;
		case 15:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SIN(");
			break;
		}
		case 16:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "COS(");
			break;
		}
		case 17:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "TAN(");
			break;
		}
		case 18:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ATAN(");
			break;
		}
		case 19:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("PI(");
			break;
		case 20:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SQRT(");
			break;
		}
		case 21:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "EXP(");
			break;
		}
		case 22:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "LN(");
			break;
		}
		case 23:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "LOG10(");
			break;
		}
		case 24:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ABS(");
			break;
		}
		case 25:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "INT(");
			break;
		}
		case 26:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SIGN(");
			break;
		}
		case 27:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "ROUND(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 30:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "REPT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 31:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int n = 1; n < 3; n++)
			{
				index = (int)arrayList_0[arrayList_0.Count - n];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "MID(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 32:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "LEN(");
			break;
		}
		case 33:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "VALUE(");
			break;
		}
		case 34:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("TRUE(");
			break;
		case 35:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("FALSE(");
			break;
		case 38:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "NOT(");
			break;
		}
		case 39:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "MOD(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 40:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num26 = 1; num26 < 3; num26++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num26];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DCOUNT(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 41:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num22 = 1; num22 < 3; num22++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num22];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DSUM(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 42:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num18 = 1; num18 < 3; num18++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num18];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DAVERAGE(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 43:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num14 = 1; num14 < 3; num14++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num14];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DMIN(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 44:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num9 = 1; num9 < 3; num9++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num9];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DMAX(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			else
			{
				arrayList_0.Add(index);
			}
			break;
		}
		case 45:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num6 = 1; num6 < 3; num6++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num6];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DSTDEV(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 47:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num4 = 1; num4 < 3; num4++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num4];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DVAR(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 48:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "TEXT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 63:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("RAND(");
			break;
		case 65:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int m = 1; m < 3; m++)
			{
				index = (int)arrayList_0[arrayList_0.Count - m];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DATE(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			else
			{
				arrayList_0.Add(index);
			}
			break;
		}
		case 66:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int k = 1; k < 3; k++)
			{
				index = (int)arrayList_0[arrayList_0.Count - k];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "TIME(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 67:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "DAY(");
			break;
		}
		case 68:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "MONTH(");
			break;
		}
		case 69:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "YEAR(");
			break;
		}
		case 71:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "HOUR(");
			break;
		}
		case 72:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "MINUTE(");
			break;
		}
		case 73:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SECOND(");
			break;
		}
		case 74:
			arrayList_0.Add(stringBuilder_0.Length);
			stringBuilder_0.Append("NOW(");
			break;
		case 75:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "AREAS(");
			break;
		}
		case 76:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ROWS(");
			break;
		}
		case 77:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "COLUMNS(");
			break;
		}
		case 83:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "TRANSPOSE(");
			break;
		}
		case 163:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "MDETERM(");
			break;
		}
		case 164:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "MINVERSE(");
			break;
		}
		case 165:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "MMULT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 140:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "DATEVALUE(");
			break;
		}
		case 141:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "TIMEVALUE(");
			break;
		}
		case 142:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num27 = 1; num27 < 3; num27++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num27];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "SLN(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 143:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num24 = 1; num24 < 4; num24++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num24];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "SYD(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 189:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num20 = 1; num20 < 3; num20++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num20];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DPRODUCT(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 190:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISNONTEXT(");
			break;
		}
		case 195:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num16 = 1; num16 < 3; num16++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num16];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DSTDEVP(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 196:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num13 = 1; num13 < 3; num13++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num13];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DVARP(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 198:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ISLOGICAL(");
			break;
		}
		case 199:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num11 = 1; num11 < 3; num11++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num11];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DCOUNTA(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 184:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "FACT(");
			break;
		}
		case 342:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "RADIANS(");
			break;
		}
		case 343:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "DEGREES(");
			break;
		}
		case 346:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "COUNTIF(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 347:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "COUNTBLANK(");
			break;
		}
		case 351:
			method_12("DATEDIF", 3, arrayList_0);
			break;
		case 352:
			method_12("DATESTRING", 1, arrayList_0);
			break;
		case 212:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "ROUNDUP(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 213:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "ROUNDDOWN(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 214:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ASC(");
			break;
		}
		case 215:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "WIDECHAR(");
			break;
		}
		case 221:
		{
			int index = stringBuilder_0.Length;
			stringBuilder_0.Append("TODAY(");
			arrayList_0.Add(index);
			break;
		}
		case 229:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SINH(");
			break;
		}
		case 230:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "COSH(");
			break;
		}
		case 231:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "TANH(");
			break;
		}
		case 232:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ASINH(");
			break;
		}
		case 233:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ACOSH(");
			break;
		}
		case 234:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ATANH(");
			break;
		}
		case 235:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num5 = 1; num5 < 3; num5++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num5];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "DGET(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 252:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "FREQUENCY(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 273:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num3 = 1; num3 < 4; num3++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num3];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "BINOMDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 274:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "CHIDIST(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 275:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "CHIINV(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 276:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "COMBIN(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 277:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int l = 1; l < 3; l++)
			{
				index = (int)arrayList_0[arrayList_0.Count - l];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "CONFIDENCE(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 278:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int i = 1; i < 3; i++)
			{
				index = (int)arrayList_0[arrayList_0.Count - i];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "CRITBINOM(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 279:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "EVEN(");
			break;
		}
		case 280:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num34 = 1; num34 < 3; num34++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num34];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "EXPONDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 281:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num33 = 1; num33 < 3; num33++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num33];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "FDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 282:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num32 = 1; num32 < 3; num32++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num32];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "FINV(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 283:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "FISHER(");
			break;
		}
		case 284:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "FISHERINV(");
			break;
		}
		case 285:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "FLOOR(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 286:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num31 = 1; num31 < 4; num31++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num31];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "GAMMADIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			break;
		}
		case 287:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num30 = 1; num30 < 3; num30++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num30];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "GAMMAINV(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 288:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "CEILING(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 289:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num28 = 1; num28 < 4; num28++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num28];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "HYPGEOMDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			break;
		}
		case 290:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num25 = 1; num25 < 3; num25++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num25];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "LOGNORMDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 291:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num23 = 1; num23 < 3; num23++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num23];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "LOGINV(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 292:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num21 = 1; num21 < 3; num21++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num21];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "NEGBINOMDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			break;
		}
		case 293:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num19 = 1; num19 < 4; num19++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num19];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "NORMDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			break;
		}
		case 294:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "NORMSDIST(");
			break;
		}
		case 295:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num17 = 1; num17 < 3; num17++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num17];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "NORMINV(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 296:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "NORMSINV(");
			break;
		}
		case 297:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num15 = 1; num15 < 3; num15++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num15];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "STANDARDIZE(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 298:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "ODD(");
			break;
		}
		case 299:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "PERMUT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 300:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num12 = 1; num12 < 3; num12++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num12];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "POISSON(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 301:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num10 = 1; num10 < 3; num10++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num10];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "TDIST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 302:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num8 = 1; num8 < 4; num8++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num8];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "WEIBULL(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 303:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "SUMXMY2(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 304:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "SUMX2MY2(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 305:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "SUMX2PY2(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 306:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "CHITEST(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 307:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "CORREL(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 308:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "COVAR(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 309:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num7 = 1; num7 < 3; num7++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num7];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 3];
			stringBuilder_0.Insert(index, "FORECAST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 2, 2);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 310:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "FTEST(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 311:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "INTERCEPT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 312:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "PEARSON(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 313:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "RSQ(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 314:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "STEYX(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 315:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "SLOPE(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 316:
		{
			if (arrayList_0.Count < 4)
			{
				return;
			}
			int index;
			for (int num2 = 1; num2 < 4; num2++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num2];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - 4];
			stringBuilder_0.Insert(index, "TTEST(");
			arrayList_0.RemoveRange(arrayList_0.Count - 3, 3);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 325:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "LARGE(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 326:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "SMALL(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 327:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "QUARTILE(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 328:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "PERCENTILE(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 331:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "TRIMMEAN(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 332:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "TINV(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		default:
		{
			Class1663 @class = Class1663.smethod_3(num);
			if (@class == null || arrayList_0.Count < @class.byte_1)
			{
				return;
			}
			int index;
			for (int j = 1; j < @class.byte_1; j++)
			{
				index = (int)arrayList_0[arrayList_0.Count - j];
				stringBuilder_0.Insert(index, ',');
			}
			index = (int)arrayList_0[arrayList_0.Count - @class.byte_1];
			stringBuilder_0.Insert(index, @class.string_0 + "(");
			if (@class.byte_1 > 1)
			{
				arrayList_0.RemoveRange(arrayList_0.Count - @class.byte_1 + 1, @class.byte_1 - 1);
			}
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
			break;
		}
		case 337:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ',');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "POWER(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		}
		stringBuilder_0.Append(")");
	}
}
