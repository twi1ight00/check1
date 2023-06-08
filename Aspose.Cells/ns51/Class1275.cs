using System;
using System.Collections;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns51;

internal class Class1275
{
	private StringBuilder stringBuilder_0;

	private WorksheetCollection worksheetCollection_0;

	internal bool bool_0 = true;

	private int int_0;

	private int int_1;

	internal Class1275(WorksheetCollection worksheetCollection_1)
	{
		stringBuilder_0 = new StringBuilder();
		worksheetCollection_0 = worksheetCollection_1;
	}

	private void method_0(byte[] byte_0, int int_2)
	{
		int index = BitConverter.ToUInt16(byte_0, int_2) - 1;
		stringBuilder_0.Append(worksheetCollection_0.Names[index].Text);
	}

	internal string method_1(int int_2, int int_3, byte[] byte_0, int int_4, int int_5, bool bool_1)
	{
		int num = byte_0.Length;
		if (int_3 != -1)
		{
			int_0 = int_3;
			int_1 = int_2 + int_3 + 4;
			num = int_2 + int_3;
		}
		else if (int_2 == -1)
		{
			int_2 = 4;
			int_0 = BitConverter.ToInt32(byte_0, 0);
			int_1 = 4 + int_0 + 4;
			num = 4 + int_0;
		}
		else
		{
			int_0 = 0;
			int_1 = 0;
		}
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
		string value = null;
		bool isError = false;
		ArrayList arrayList = new ArrayList();
		while (int_2 < num)
		{
			switch (byte_0[int_2])
			{
			case 3:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '+');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 4:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '-');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 5:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '*');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 6:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '/');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 7:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '^');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 8:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '&');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 9:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '<');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 10:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "<=");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 11:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '=');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 12:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ">=");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 13:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, '>');
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 14:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "<>");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 15:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, " ");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 16:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ";");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 17:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, ":");
				arrayList.RemoveAt(arrayList.Count - 1);
				int_2++;
				break;
			}
			case 18:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "+");
				int_2++;
				break;
			}
			case 19:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "-");
				int_2++;
				break;
			}
			case 20:
				stringBuilder_0.Append("%");
				int_2++;
				break;
			case 21:
			{
				int index = (int)arrayList[arrayList.Count - 1];
				stringBuilder_0.Insert(index, "(");
				stringBuilder_0.Append(")");
				int_2++;
				break;
			}
			case 22:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				break;
			case 23:
			{
				int_2++;
				int num2 = BitConverter.ToUInt16(byte_0, int_2);
				if (num2 != 0)
				{
					value = Encoding.Unicode.GetString(byte_0, int_2 + 2, 2 * num2);
					value = value.Replace("\"", "\"\"");
				}
				int_2 += 2 * num2 + 2;
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append("\"");
				if (num2 != 0)
				{
					stringBuilder_0.Append(value);
				}
				stringBuilder_0.Append("\"");
				break;
			}
			case 25:
				int_2++;
				method_3(byte_0, ref int_2, arrayList);
				break;
			case 28:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				stringBuilder_0.Append(Class1673.smethod_6(byte_0[int_2]));
				int_2++;
				break;
			case 29:
				int_2++;
				arrayList.Add(stringBuilder_0.Length);
				if (byte_0[int_2] == 0)
				{
					stringBuilder_0.Append("FALSE");
				}
				else
				{
					stringBuilder_0.Append("TRUE");
				}
				int_2++;
				break;
			case 30:
			{
				ushort num7 = BitConverter.ToUInt16(byte_0, int_2 + 1);
				arrayList.Add(stringBuilder_0.Length);
				stringBuilder_0.Append(num7.ToString(CultureInfo.InvariantCulture));
				int_2 += 3;
				break;
			}
			case 31:
			{
				double num6 = BitConverter.ToDouble(byte_0, int_2 + 1);
				arrayList.Add(stringBuilder_0.Length);
				if (!(num6 >= 1E+21) && Math.Abs(num6) > 1E-21)
				{
					stringBuilder_0.Append(num6.ToString("0.##################################", CultureInfo.InvariantCulture));
				}
				else
				{
					stringBuilder_0.Append(num6.ToString());
				}
				int_2 += 9;
				break;
			}
			case 32:
			case 64:
			case 96:
				if (int_1 == 0)
				{
					int_1 = int_2 + 4;
				}
				method_2(byte_0, arrayList);
				int_2 += 8;
				break;
			case 33:
			case 65:
			case 97:
				int_2++;
				method_9(byte_0, int_2, arrayList);
				int_2 += 2;
				break;
			case 34:
			case 66:
			case 98:
				int_2++;
				method_8(byte_0, int_2, arrayList);
				int_2 += 3;
				break;
			case 35:
			case 67:
			case 99:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				method_0(byte_0, int_2);
				int_2 += 4;
				break;
			case 36:
			case 68:
			case 100:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append("[." + GetCell(byte_0, int_2) + "]");
				}
				else
				{
					stringBuilder_0.Append(GetCell(byte_0, int_2));
				}
				int_2 += 6;
				break;
			case 37:
			case 69:
			case 101:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append("[." + GetCellArea(byte_0, int_2, int_4, int_5) + "]");
				}
				else
				{
					stringBuilder_0.Append(GetCellArea(byte_0, int_2, int_4, int_5));
				}
				int_2 += 12;
				break;
			case 38:
			case 70:
			case 102:
				int_2 += 7;
				break;
			case 41:
			case 73:
			case 105:
				int_2 += 3;
				break;
			case 42:
			case 74:
			case 106:
				arrayList.Add(stringBuilder_0.Length);
				if (bool_0)
				{
					stringBuilder_0.Append("[.#REF!#REF!]");
				}
				else
				{
					stringBuilder_0.Append(".#REF!#REF!");
				}
				int_2 += 7;
				break;
			case 43:
			case 75:
			case 107:
				arrayList.Add(stringBuilder_0.Length);
				if (bool_0)
				{
					stringBuilder_0.Append("[.#REF!#REF!]");
				}
				else
				{
					stringBuilder_0.Append(".#REF!#REF!");
				}
				int_2 += 13;
				break;
			case 44:
			case 76:
			case 108:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append("[." + method_6(byte_0, int_2, int_4, int_5) + "]");
				}
				else
				{
					stringBuilder_0.Append(method_6(byte_0, int_2, int_4, int_5));
				}
				int_2 += 6;
				break;
			case 45:
			case 77:
			case 109:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append("[." + method_5(byte_0, int_2, int_4, int_5) + "]");
				}
				else
				{
					stringBuilder_0.Append(method_5(byte_0, int_2, int_4, int_5));
				}
				int_2 += 12;
				break;
			case 57:
			case 89:
			case 121:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				int num3 = BitConverter.ToUInt16(byte_0, int_2);
				int num4 = worksheetCollection_0.method_32().method_12(num3);
				Class1718 @class = null;
				if (worksheetCollection_0.method_39() != null && num4 < worksheetCollection_0.method_39().Count)
				{
					@class = worksheetCollection_0.method_39()[num4];
					if (@class.method_12())
					{
						@class = null;
					}
				}
				int_2 += 2;
				int num5 = BitConverter.ToUInt16(byte_0, int_2);
				if (@class == null)
				{
					Name name = worksheetCollection_0.Names[num5 - 1];
					stringBuilder_0.Append(name.Text);
				}
				else
				{
					if (!@class.method_14())
					{
						return null;
					}
					Class1653 class2 = (Class1653)@class.method_0()[num5 - 1];
					stringBuilder_0.Append(class2.Name.ToUpper());
				}
				int_2 += 4;
				break;
			}
			case 58:
			case 90:
			case 122:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append("[");
				}
				string value3 = method_4(byte_0, int_2, out isError);
				if (isError)
				{
					int_2 += 2;
					stringBuilder_0.Append(".#REF!#REF!");
				}
				else
				{
					stringBuilder_0.Append(value3);
					stringBuilder_0.Append('.');
					int_2 += 2;
					stringBuilder_0.Append(GetCell(byte_0, int_2));
				}
				if (bool_0)
				{
					stringBuilder_0.Append(']');
				}
				int_2 += 6;
				break;
			}
			case 59:
			case 91:
			case 123:
			{
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append('[');
				}
				string value2 = method_4(byte_0, int_2, out isError);
				if (isError)
				{
					int_2 += 2;
					stringBuilder_0.Append(".#REF!#REF!");
				}
				else
				{
					stringBuilder_0.Append(value2);
					stringBuilder_0.Append('.');
					int_2 += 2;
					stringBuilder_0.Append(GetCellArea(byte_0, int_2, int_4, int_5));
				}
				if (bool_0)
				{
					stringBuilder_0.Append(']');
				}
				int_2 += 12;
				break;
			}
			case 60:
			case 92:
			case 124:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append('[');
				}
				stringBuilder_0.Append(".#REF!#REF!");
				if (bool_0)
				{
					stringBuilder_0.Append(']');
				}
				int_2 += 8;
				break;
			case 61:
			case 93:
			case 125:
				arrayList.Add(stringBuilder_0.Length);
				int_2++;
				if (bool_0)
				{
					stringBuilder_0.Append('[');
				}
				stringBuilder_0.Append(".#REF!#REF!");
				if (bool_0)
				{
					stringBuilder_0.Append(']');
				}
				int_2 += 14;
				break;
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

	private void method_2(byte[] byte_0, ArrayList arrayList_0)
	{
		arrayList_0.Add(stringBuilder_0.Length);
		stringBuilder_0.Append('{');
		int num = BitConverter.ToInt32(byte_0, int_1);
		int_1 += 4;
		int num2 = BitConverter.ToInt32(byte_0, int_1);
		int_1 += 4;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				switch (byte_0[int_1])
				{
				case 0:
					int_1++;
					stringBuilder_0.Append(BitConverter.ToDouble(byte_0, int_1));
					int_1 += 8;
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					break;
				case 1:
				{
					int_1++;
					int num3 = BitConverter.ToUInt16(byte_0, int_1);
					if (num3 != 0)
					{
						stringBuilder_0.Append("\"");
						string @string = Encoding.Unicode.GetString(byte_0, int_1 + 2, num3 * 2);
						int_1 += 2 + num3 * 2;
						stringBuilder_0.Append(@string);
						stringBuilder_0.Append("\"");
					}
					else
					{
						int_1 += 2;
					}
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					break;
				}
				case 2:
					stringBuilder_0.Append(byte_0[int_1 + 1] == 1);
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					int_1 += 2;
					break;
				case 4:
					stringBuilder_0.Append(Class1673.smethod_6(byte_0[int_1 + 1]));
					if (j != num - 1)
					{
						stringBuilder_0.Append(',');
					}
					int_1 += 5;
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

	private void method_3(byte[] byte_0, ref int int_2, ArrayList arrayList_0)
	{
		switch (byte_0[int_2])
		{
		case 16:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "SUM(");
			stringBuilder_0.Append(")");
			int_2 += 3;
			break;
		}
		default:
			int_2 += 3;
			break;
		case 4:
		{
			int_2 += 3;
			int num = BitConverter.ToUInt16(byte_0, int_2);
			int_2 += num;
			break;
		}
		}
	}

	private string method_4(byte[] data, int pos, out bool isError)
	{
		isError = false;
		int num = BitConverter.ToUInt16(data, pos);
		int num2 = worksheetCollection_0.method_32().method_13(num);
		if (num2 >= 0 && num2 < worksheetCollection_0.Count)
		{
			return Class1268.smethod_0(num, worksheetCollection_0, 0, null);
		}
		isError = true;
		return "#REF!";
	}

	private string method_5(byte[] byte_0, int int_2, int int_3, int int_4)
	{
		int num = BitConverter.ToInt32(byte_0, int_2);
		int num2 = Class1268.smethod_1(byte_0, int_2 + 8);
		int num3 = BitConverter.ToInt32(byte_0, int_2 + 4);
		int num4 = Class1268.smethod_1(byte_0, int_2 + 10);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		if ((byte_0[int_2 + 9] & 0x80u) != 0)
		{
			flag = false;
		}
		if ((byte_0[int_2 + 9] & 0x40u) != 0)
		{
			flag2 = false;
		}
		if ((byte_0[int_2 + 11] & 0x80u) != 0)
		{
			flag3 = false;
		}
		if ((byte_0[int_2 + 11] & 0x40u) != 0)
		{
			flag4 = false;
		}
		if (num == 0 && num3 == 1048575)
		{
			if (flag2)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num2));
			stringBuilder.Append(':');
			stringBuilder.Append('.');
			if (flag4)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
			return stringBuilder.ToString();
		}
		if (num2 == 0 && num4 == 16383)
		{
			if (flag)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num + 1);
			stringBuilder.Append(':');
			stringBuilder.Append('.');
			if (flag3)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num3 + 1);
			return stringBuilder.ToString();
		}
		if (!flag2)
		{
			num2 = ((num2 + int_4 <= 16383) ? (num2 + int_4) : (num2 + int_4 - 16383 - 1));
		}
		else
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num2));
		if (!flag)
		{
			num = ((num + int_3 <= 1048575) ? (num + int_3) : (num + int_3 - 1048575 - 1));
		}
		else
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(num + 1);
		stringBuilder.Append(':');
		stringBuilder.Append('.');
		if (!flag4)
		{
			num4 = ((num4 + int_4 <= 16383) ? (num4 + int_4) : (num4 + int_4 - 16383 - 1));
		}
		else
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
		if (!flag3)
		{
			num3 = ((num3 + int_3 <= 1048575) ? (num3 + int_3) : (num3 + int_3 - 1048575 - 1));
		}
		else
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(num3 + 1);
		return stringBuilder.ToString();
	}

	private string GetCellArea(byte[] byte_0, int int_2, int int_3, int int_4)
	{
		int num = BitConverter.ToInt32(byte_0, int_2);
		int num2 = BitConverter.ToInt32(byte_0, int_2 + 4);
		int num3 = Class1268.smethod_1(byte_0, int_2 + 8);
		int num4 = Class1268.smethod_1(byte_0, int_2 + 10);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		if ((byte_0[int_2 + 9] & 0x80u) != 0)
		{
			flag = false;
		}
		if ((byte_0[int_2 + 9] & 0x40u) != 0)
		{
			flag2 = false;
		}
		if ((byte_0[int_2 + 11] & 0x80u) != 0)
		{
			flag3 = false;
		}
		if ((byte_0[int_2 + 11] & 0x40u) != 0)
		{
			flag4 = false;
		}
		if (num == 0 && num2 == 1048575)
		{
			if (flag2)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
			stringBuilder.Append(':');
			stringBuilder.Append('.');
			if (flag4)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
			return stringBuilder.ToString();
		}
		if (num3 == 0 && num4 == 16383)
		{
			if (flag)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num + 1);
			stringBuilder.Append(':');
			stringBuilder.Append('.');
			if (flag3)
			{
				stringBuilder.Append("$");
			}
			stringBuilder.Append(num2 + 1);
			return stringBuilder.ToString();
		}
		if (flag2)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num3));
		if (flag)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(num + 1);
		stringBuilder.Append(':');
		stringBuilder.Append('.');
		if (flag4)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(CellsHelper.ColumnIndexToName(num4));
		if (flag3)
		{
			stringBuilder.Append('$');
		}
		stringBuilder.Append(num2 + 1);
		return stringBuilder.ToString();
	}

	private string method_6(byte[] byte_0, int int_2, int int_3, int int_4)
	{
		int row = Class1268.smethod_2(byte_0, int_2, int_3, byte_0[int_2 + 5]);
		int column = Class1268.smethod_6(byte_0, int_2 + 4, int_4, byte_0[int_2 + 5]);
		byte b = byte_0[int_2 + 5];
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
		stringBuilder.Append(CellsHelper.RowIndexToName(row));
		return stringBuilder.ToString();
	}

	private string GetCell(byte[] byte_0, int int_2)
	{
		int row = BitConverter.ToInt32(byte_0, int_2);
		int column = Class1268.smethod_1(byte_0, int_2 + 4);
		bool flag = true;
		bool flag2 = true;
		byte b = byte_0[int_2 + 5];
		if ((b & 0x40u) != 0)
		{
			flag2 = false;
		}
		if ((b & 0x80u) != 0)
		{
			flag = false;
		}
		string text = CellsHelper.CellIndexToName(row, column);
		if (!flag && !flag2)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder(text);
		if (flag2)
		{
			stringBuilder.Insert(0, '$');
		}
		if (flag)
		{
			int num = 1;
			while (true)
			{
				if (num < stringBuilder.Length)
				{
					if (char.IsDigit(stringBuilder[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			stringBuilder.Insert(num, '$');
			return stringBuilder.ToString();
		}
		return stringBuilder.ToString();
	}

	private void method_7(byte[] byte_0, int int_2, ArrayList arrayList_0)
	{
		int num = byte_0[int_2] - 1;
		int index;
		for (int i = 1; i < num; i++)
		{
			index = (int)arrayList_0[arrayList_0.Count - i];
			stringBuilder_0.Insert(index, ',');
		}
		int num2 = arrayList_0.Count - num;
		if (num2 < arrayList_0.Count)
		{
			index = (int)arrayList_0[num2];
		}
		else
		{
			index = stringBuilder_0.Length;
			arrayList_0.Add(index);
		}
		stringBuilder_0.Insert(index, "(");
		if (byte_0[int_2] - 1 > 0)
		{
			arrayList_0.RemoveRange(arrayList_0.Count - byte_0[int_2] + 1, byte_0[int_2] - 1);
		}
		stringBuilder_0.Append(")");
	}

	private void method_8(byte[] byte_0, int int_2, ArrayList arrayList_0)
	{
		ushort num = BitConverter.ToUInt16(byte_0, int_2 + 1);
		if (num == 255)
		{
			method_7(byte_0, int_2, arrayList_0);
			return;
		}
		int index;
		for (int i = 1; i < byte_0[int_2]; i++)
		{
			index = (int)arrayList_0[arrayList_0.Count - i];
			stringBuilder_0.Insert(index, ';');
		}
		int num2 = arrayList_0.Count - byte_0[int_2];
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
		if (byte_0[int_2] - 1 > 0)
		{
			arrayList_0.RemoveRange(arrayList_0.Count - byte_0[int_2] + 1, byte_0[int_2] - 1);
		}
		stringBuilder_0.Append(")");
	}

	private void method_9(byte[] byte_0, int int_2, ArrayList arrayList_0)
	{
		ushort num = BitConverter.ToUInt16(byte_0, int_2);
		switch (num)
		{
		case 97:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num32 = 1; num32 < 3; num32++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num32];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num17 = 1; num17 < 3; num17++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num17];
				stringBuilder_0.Insert(index, ';');
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
			for (int num14 = 1; num14 < 3; num14++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num14];
				stringBuilder_0.Insert(index, ';');
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
			for (int num5 = 1; num5 < 3; num5++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num5];
				stringBuilder_0.Insert(index, ';');
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
			for (int l = 1; l < 3; l++)
			{
				index = (int)arrayList_0[arrayList_0.Count - l];
				stringBuilder_0.Insert(index, ';');
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
			for (int num30 = 1; num30 < 3; num30++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num30];
				stringBuilder_0.Insert(index, ';');
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
			for (int num24 = 1; num24 < 3; num24++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num24];
				stringBuilder_0.Insert(index, ';');
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
			for (int num20 = 1; num20 < 3; num20++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num20];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num15 = 1; num15 < 3; num15++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num15];
				stringBuilder_0.Insert(index, ';');
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
			for (int num12 = 1; num12 < 3; num12++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num12];
				stringBuilder_0.Insert(index, ';');
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
			for (int num2 = 1; num2 < 3; num2++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num2];
				stringBuilder_0.Insert(index, ';');
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
			for (int k = 1; k < 4; k++)
			{
				index = (int)arrayList_0[arrayList_0.Count - k];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num28 = 1; num28 < 4; num28++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num28];
				stringBuilder_0.Insert(index, ';');
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
		case 184:
		{
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, "FACT(");
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
			stringBuilder_0.Insert(index, ';');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "MMULT(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			if (arrayList_0.Count > 0)
			{
				arrayList_0[arrayList_0.Count - 1] = index;
			}
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
			stringBuilder_0.Insert(index, ';');
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
		case 212:
		{
			if (arrayList_0.Count < 2)
			{
				return;
			}
			int index = (int)arrayList_0[arrayList_0.Count - 1];
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num19 = 1; num19 < 3; num19++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num19];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num16 = 1; num16 < 4; num16++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num16];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num11 = 1; num11 < 3; num11++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num11];
				stringBuilder_0.Insert(index, ';');
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
			for (int num10 = 1; num10 < 3; num10++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num10];
				stringBuilder_0.Insert(index, ';');
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
			for (int num9 = 1; num9 < 3; num9++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num9];
				stringBuilder_0.Insert(index, ';');
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
			for (int num7 = 1; num7 < 3; num7++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num7];
				stringBuilder_0.Insert(index, ';');
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
			for (int num4 = 1; num4 < 3; num4++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num4];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int n = 1; n < 4; n++)
			{
				index = (int)arrayList_0[arrayList_0.Count - n];
				stringBuilder_0.Insert(index, ';');
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
			for (int j = 1; j < 3; j++)
			{
				index = (int)arrayList_0[arrayList_0.Count - j];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num34 = 1; num34 < 4; num34++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num34];
				stringBuilder_0.Insert(index, ';');
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
			for (int num33 = 1; num33 < 3; num33++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num33];
				stringBuilder_0.Insert(index, ';');
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
			for (int num31 = 1; num31 < 3; num31++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num31];
				stringBuilder_0.Insert(index, ';');
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
			for (int num29 = 1; num29 < 3; num29++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num29];
				stringBuilder_0.Insert(index, ';');
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
			for (int num27 = 1; num27 < 4; num27++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num27];
				stringBuilder_0.Insert(index, ';');
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
			for (int num26 = 1; num26 < 3; num26++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num26];
				stringBuilder_0.Insert(index, ';');
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
			for (int num25 = 1; num25 < 3; num25++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num25];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num23 = 1; num23 < 3; num23++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num23];
				stringBuilder_0.Insert(index, ';');
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
			for (int num22 = 1; num22 < 3; num22++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num22];
				stringBuilder_0.Insert(index, ';');
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
			for (int num21 = 1; num21 < 4; num21++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num21];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num18 = 1; num18 < 3; num18++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num18];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			for (int num13 = 1; num13 < 4; num13++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num13];
				stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
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
			stringBuilder_0.Insert(index, ';');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "TINV(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
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
			stringBuilder_0.Insert(index, ';');
			index = (int)arrayList_0[arrayList_0.Count - 2];
			stringBuilder_0.Insert(index, "POWER(");
			arrayList_0.RemoveAt(arrayList_0.Count - 1);
			break;
		}
		case 189:
		{
			if (arrayList_0.Count < 3)
			{
				return;
			}
			int index;
			for (int num8 = 1; num8 < 3; num8++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num8];
				stringBuilder_0.Insert(index, ';');
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
			for (int num6 = 1; num6 < 3; num6++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num6];
				stringBuilder_0.Insert(index, ';');
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
			for (int num3 = 1; num3 < 3; num3++)
			{
				index = (int)arrayList_0[arrayList_0.Count - num3];
				stringBuilder_0.Insert(index, ';');
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
		default:
		{
			Class1663 @class = Class1663.smethod_3(num);
			if (@class == null || arrayList_0.Count < @class.byte_1)
			{
				return;
			}
			int index;
			for (int m = 1; m < @class.byte_1; m++)
			{
				index = (int)arrayList_0[arrayList_0.Count - m];
				stringBuilder_0.Insert(index, ';');
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
			for (int i = 1; i < 3; i++)
			{
				index = (int)arrayList_0[arrayList_0.Count - i];
				stringBuilder_0.Insert(index, ';');
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
		}
		stringBuilder_0.Append(")");
	}
}
