using System;
using System.Text;
using Aspose.Cells;
using ns2;
using ns58;
using ns7;

namespace ns51;

internal class Class1270
{
	internal static bool smethod_0(byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			return false;
		}
		int num = byte_0.Length;
		if (int_0 == -1)
		{
			num = BitConverter.ToInt32(byte_0, 0);
			int_0 = 4;
		}
		switch (byte_0[int_0])
		{
		default:
			return false;
		case 58:
		case 90:
		case 122:
			return num == 7;
		case 59:
		case 91:
		case 123:
			return num == 15;
		}
	}

	internal static int[] GetRange(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0, bool bool_0, int int_1, int int_2)
	{
		if (byte_0 != null && byte_0.Length > 2)
		{
			int num = byte_0.Length;
			if (int_0 == -1)
			{
				num = BitConverter.ToInt32(byte_0, 0);
				int_0 = 4;
			}
			switch (byte_0[int_0])
			{
			case 24:
				if (byte_0[int_0 + 1] == 25 && num == 14)
				{
					return Class1689.GetRange(worksheetCollection_0, byte_0, int_0, int_1, int_2);
				}
				break;
			case 58:
			case 90:
			case 122:
				if (num == 9)
				{
					int[] array2 = new int[5]
					{
						BitConverter.ToUInt16(byte_0, int_0 + 1),
						0,
						0,
						0,
						0
					};
					if (bool_0)
					{
						array2[1] = Class1268.smethod_2(byte_0, int_0 + 3, int_1, byte_0[int_0 + 8]);
						array2[2] = Class1268.smethod_6(byte_0, int_0 + 7, int_2, byte_0[int_0 + 8]);
					}
					else
					{
						array2[1] = BitConverter.ToInt32(byte_0, int_0 + 3);
						array2[2] = Class1268.smethod_1(byte_0, int_0 + 7);
					}
					array2[3] = array2[1];
					array2[4] = array2[2];
					return array2;
				}
				break;
			case 59:
			case 91:
			case 123:
				if (num == 15)
				{
					int[] array = new int[5];
					array[0] = BitConverter.ToUInt16(byte_0, int_0 + 1);
					array[1] = BitConverter.ToInt32(byte_0, int_0 + 3);
					array[3] = BitConverter.ToInt32(byte_0, int_0 + 7);
					array[2] = Class1268.smethod_1(byte_0, int_0 + 11);
					array[4] = Class1268.smethod_1(byte_0, int_0 + 13);
					return array;
				}
				break;
			}
			return null;
		}
		return null;
	}

	internal static string[] smethod_1(WorksheetCollection sheets, int refIndex, out int supbookIndex)
	{
		supbookIndex = sheets.method_32().method_12(refIndex);
		int num = sheets.method_32().method_13(refIndex);
		string[] array = new string[2];
		if (supbookIndex == sheets.method_36())
		{
			if (num >= 0 && num < sheets.Count)
			{
				array[1] = sheets[num].Name;
			}
			else
			{
				array[1] = "#REF!";
			}
		}
		else
		{
			Class1718 @class = sheets.method_39()[supbookIndex];
			array[0] = @class.method_19(sheets.Workbook);
			if (@class.method_4() != null && num >= 0 && num < @class.method_4().Length)
			{
				array[1] = @class.method_4()[num];
			}
			else
			{
				array[1] = "#REF!";
			}
		}
		return array;
	}

	internal static bool smethod_2(WorksheetCollection worksheetCollection_0, Class1309 class1309_0, byte[] byte_0, int int_0)
	{
		if (byte_0 != null && byte_0.Length > 2)
		{
			int num = byte_0.Length;
			if (int_0 == -1)
			{
				num = BitConverter.ToInt32(byte_0, 0);
				int_0 = 4;
			}
			int num2 = 0;
			string[] array = null;
			int supbookIndex;
			switch (byte_0[int_0])
			{
			case 35:
			case 67:
			case 99:
				if (num == 5)
				{
					Name name2 = worksheetCollection_0.Names[BitConverter.ToUInt16(byte_0, int_0 + 1) - 1];
					return smethod_2(worksheetCollection_0, class1309_0, name2.method_2(), -1);
				}
				break;
			case 57:
			case 89:
			case 121:
				if (num == 7)
				{
					num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
					array = smethod_1(worksheetCollection_0, num2, out supbookIndex);
					class1309_0.string_0 = array[0];
					class1309_0.string_1 = array[1];
					if (array[1] == "#REF!")
					{
						return false;
					}
					int index = BitConverter.ToUInt16(byte_0, int_0 + 3) - 1;
					if (supbookIndex != worksheetCollection_0.method_36())
					{
						return false;
					}
					Name name = worksheetCollection_0.Names[index];
					return smethod_2(worksheetCollection_0, class1309_0, name.method_2(), -1);
				}
				break;
			case 58:
			case 90:
			case 122:
				if (num == 9)
				{
					num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
					array = smethod_1(worksheetCollection_0, num2, out supbookIndex);
					class1309_0.string_0 = array[0];
					class1309_0.string_1 = array[1];
					class1309_0.int_0 = BitConverter.ToInt32(byte_0, int_0 + 3);
					class1309_0.int_1 = Class1268.smethod_1(byte_0, int_0 + 7);
					class1309_0.int_2 = class1309_0.int_0;
					class1309_0.int_3 = class1309_0.int_1;
					class1309_0.bool_0 = (class1309_0.bool_1 = (byte_0[int_0 + 8] & 0x80) == 0);
					class1309_0.bool_2 = (class1309_0.bool_3 = (byte_0[int_0 + 8] & 0x40) == 0);
					return array[1] == "#REF!";
				}
				break;
			case 59:
			case 91:
			case 123:
				if (num == 15)
				{
					num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
					array = smethod_1(worksheetCollection_0, num2, out supbookIndex);
					class1309_0.string_0 = array[0];
					class1309_0.string_1 = array[1];
					class1309_0.int_0 = BitConverter.ToInt32(byte_0, int_0 + 3);
					class1309_0.int_2 = BitConverter.ToInt32(byte_0, int_0 + 7);
					class1309_0.int_1 = Class1268.smethod_1(byte_0, int_0 + 11);
					class1309_0.int_3 = Class1268.smethod_1(byte_0, int_0 + 13);
					class1309_0.bool_0 = (byte_0[int_0 + 12] & 0x80) == 0;
					class1309_0.bool_2 = (byte_0[int_0 + 12] & 0x40) == 0;
					class1309_0.bool_1 = (byte_0[int_0 + 14] & 0x80) == 0;
					class1309_0.bool_3 = (byte_0[int_0 + 14] & 0x40) == 0;
					return array[1] == "#REF!";
				}
				break;
			}
			return false;
		}
		return false;
	}

	internal static CellArea smethod_3(WorksheetCollection sheets, byte[] data, int offset, int row, int column, out bool isArea)
	{
		CellArea result = default(CellArea);
		switch (data[offset])
		{
		default:
			isArea = false;
			break;
		case 36:
		case 68:
		case 100:
			result.StartRow = (result.EndRow = BitConverter.ToInt32(data, offset + 1));
			result.StartColumn = (result.EndColumn = Class1268.smethod_1(data, offset + 5));
			isArea = true;
			break;
		case 37:
		case 69:
		case 101:
			result.StartRow = BitConverter.ToInt32(data, offset + 1);
			result.EndRow = BitConverter.ToInt32(data, offset + 5);
			result.StartColumn = Class1268.smethod_1(data, offset + 9);
			result.EndColumn = Class1268.smethod_1(data, offset + 11);
			isArea = true;
			break;
		case 58:
		case 90:
		case 122:
			result.StartRow = (result.EndRow = BitConverter.ToInt32(data, offset + 3));
			result.StartColumn = (result.EndColumn = Class1268.smethod_1(data, offset + 7));
			isArea = true;
			break;
		case 59:
		case 91:
		case 123:
			result.StartRow = BitConverter.ToInt32(data, offset + 3);
			result.EndRow = BitConverter.ToInt32(data, offset + 7);
			result.StartColumn = Class1268.smethod_1(data, offset + 11);
			result.EndColumn = Class1268.smethod_1(data, offset + 13);
			isArea = true;
			break;
		}
		return result;
	}

	internal static string smethod_4(byte[] formula, ref int pos, out bool onlyRow, out bool onlyColumn)
	{
		string result = null;
		onlyRow = false;
		onlyColumn = false;
		switch (formula[pos])
		{
		case 58:
		case 90:
		case 122:
		{
			int row = BitConverter.ToInt32(formula, pos + 3);
			int column = Class1268.smethod_1(formula, pos + 7);
			result = CellsHelper.CellIndexToName(row, column);
			pos += 9;
			break;
		}
		case 59:
		case 91:
		case 123:
		{
			int num = BitConverter.ToInt32(formula, pos + 3);
			int num2 = BitConverter.ToInt32(formula, pos + 7);
			int num3 = Class1268.smethod_1(formula, pos + 11);
			int num4 = Class1268.smethod_1(formula, pos + 13);
			if (num3 == 0 && num4 == 16383)
			{
				result = "$" + (num + 1) + ":$" + (num2 + 1);
				onlyRow = true;
			}
			else if (num == 0 && num2 == 1048575)
			{
				result = "$" + CellsHelper.ColumnIndexToName(num3) + ":$" + CellsHelper.ColumnIndexToName(num4);
				onlyColumn = true;
			}
			else
			{
				string text = CellsHelper.CellIndexToName(num, num3);
				string text2 = CellsHelper.CellIndexToName(num2, num4);
				result = text + ":" + text2;
			}
			pos += 15;
			break;
		}
		}
		return result;
	}

	internal static void smethod_5(Name name, bool isPrintArea, out string first, out string second)
	{
		first = null;
		second = null;
		byte[] array = name.method_2();
		if (array == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		int pos = 4;
		int num = BitConverter.ToInt32(array, 0);
		bool onlyRow = false;
		bool onlyColumn = false;
		while (pos < num)
		{
			switch (array[pos])
			{
			case 41:
				pos += 3;
				break;
			case 16:
				pos++;
				break;
			case 58:
			case 59:
			case 90:
			case 91:
			case 122:
			case 123:
			{
				string value = smethod_4(array, ref pos, out onlyRow, out onlyColumn);
				StringBuilder stringBuilder3 = stringBuilder;
				bool flag = true;
				if (!isPrintArea)
				{
					if (onlyColumn)
					{
						stringBuilder3 = stringBuilder2;
					}
					else if (!onlyRow)
					{
						flag = false;
					}
				}
				if (flag)
				{
					if (stringBuilder3.Length > 0)
					{
						stringBuilder3.Append(',');
					}
					stringBuilder3.Append(value);
				}
				break;
			}
			default:
				pos++;
				break;
			case 61:
			case 93:
			case 125:
				pos += 15;
				break;
			}
		}
		first = ((stringBuilder.Length == 0) ? null : stringBuilder.ToString());
		second = ((stringBuilder2.Length == 0) ? null : stringBuilder2.ToString());
	}

	internal static byte[] SetRange(WorksheetCollection worksheetCollection_0, int int_0, CellArea cellArea_0)
	{
		byte[] array = null;
		int num = worksheetCollection_0.method_32().method_8(worksheetCollection_0.method_36(), int_0);
		if (cellArea_0.StartRow == cellArea_0.EndRow && cellArea_0.StartColumn == cellArea_0.EndColumn)
		{
			array = new byte[17]
			{
				9, 0, 0, 0, 58, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0
			};
			Class1268.smethod_3(array, 7, cellArea_0.StartRow, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 11, cellArea_0.StartColumn, 0, bool_0: true, bool_1: false);
		}
		else
		{
			array = new byte[23]
			{
				15, 0, 0, 0, 59, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0
			};
			Class1268.smethod_3(array, 7, cellArea_0.StartRow, 0, bool_0: true, bool_1: false);
			Class1268.smethod_3(array, 11, cellArea_0.EndRow, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 15, cellArea_0.StartColumn, 0, bool_0: true, bool_1: false);
			Class1268.smethod_5(array, 17, cellArea_0.EndColumn, 0, bool_0: true, bool_1: false);
		}
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, 5, 2);
		return array;
	}

	internal static byte[] smethod_6(WorksheetCollection worksheetCollection_0, int int_0, string string_0)
	{
		byte[] array = null;
		bool isValid = false;
		array = ((string_0.IndexOf(',') == -1) ? Class1267.smethod_3(worksheetCollection_0, int_0, string_0, externRef: true, validName: true, convertName: true, out isValid) : Class1267.smethod_2(worksheetCollection_0, int_0, string_0, hasParen: false, validName: true, out isValid));
		if (!isValid)
		{
			return null;
		}
		if (array != null)
		{
			byte[] array2 = new byte[array.Length + 8];
			Array.Copy(BitConverter.GetBytes(array.Length), 0, array2, 0, 4);
			Array.Copy(array, 0, array2, 4, array.Length);
			return array2;
		}
		return array;
	}
}
