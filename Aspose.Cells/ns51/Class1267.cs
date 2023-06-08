using System;
using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns51;

internal class Class1267
{
	internal static bool smethod_0(byte[] byte_0, int int_0)
	{
		int num = byte_0.Length;
		if (int_0 == -1)
		{
			num = BitConverter.ToInt32(byte_0, 0);
			int_0 = 4;
		}
		if (byte_0[int_0] != 23)
		{
			return false;
		}
		int num2 = BitConverter.ToUInt16(byte_0, int_0 + 1);
		return num == num2 * 2 + 3;
	}

	private static bool ColumnNameToIndex(string columnName, out int column)
	{
		column = 0;
		if (columnName != null && columnName.Length <= 3)
		{
			int num = 0;
			while (true)
			{
				if (num < columnName.Length)
				{
					if (!char.IsLetter(columnName[num]))
					{
						break;
					}
					column = column * 26 + columnName[num] - 65 + 1;
					num++;
					continue;
				}
				if (column > 0)
				{
					column--;
				}
				if (column <= 16383 && column >= 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	internal static bool CellNameToIndex(string cellName, out int row, out int column, ref bool isRowAbsolute, ref bool isColumnAbsolute, ref bool isRowOnly, ref bool isColumnOnly)
	{
		row = -1;
		column = -1;
		isRowAbsolute = false;
		isColumnAbsolute = false;
		if (cellName == null)
		{
			return false;
		}
		cellName = cellName.ToUpper();
		char[] array = cellName.ToCharArray();
		int num = 0;
		int i = 0;
		while (true)
		{
			if (i < array.Length)
			{
				if (char.IsLetter(array[i]))
				{
					if (column != -1)
					{
						return false;
					}
					num = i;
					if (i != 0 && array[i - 1] == '$')
					{
						isColumnAbsolute = true;
					}
					for (; i < array.Length && char.IsLetter(array[i]); i++)
					{
					}
					if (!ColumnNameToIndex(cellName.Substring(num, i - num), out column))
					{
						return false;
					}
					if (i != array.Length)
					{
						i--;
					}
				}
				else if (char.IsDigit(array[i]))
				{
					if (row != -1)
					{
						return false;
					}
					num = i;
					if (i != 0 && array[i - 1] == '$')
					{
						isRowAbsolute = true;
					}
					for (; i < array.Length && char.IsDigit(array[i]); i++)
					{
					}
					row = int.Parse(cellName.Substring(num, i - num)) - 1;
					if (row > 1048575)
					{
						return false;
					}
					if (i != array.Length)
					{
						return false;
					}
				}
				else
				{
					if (array[i] != '$')
					{
						break;
					}
					if (i == array.Length - 1)
					{
						return false;
					}
					if (i != 0 && array[i - 1] == '$')
					{
						return false;
					}
				}
				i++;
				continue;
			}
			isColumnOnly = row == -1;
			isRowOnly = column == -1;
			return true;
		}
		return false;
	}

	public static bool smethod_1(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string_0 = string_0.ToUpper();
			char[] array = string_0.ToCharArray();
			int num = 0;
			int column = -1;
			int num2 = -1;
			int i = 0;
			while (true)
			{
				if (i < array.Length)
				{
					if (char.IsLetter(array[i]))
					{
						if (column != -1)
						{
							return false;
						}
						num = i;
						for (; i < array.Length && char.IsLetter(array[i]); i++)
						{
						}
						if (!ColumnNameToIndex(string_0.Substring(num, i - num), out column))
						{
							return false;
						}
						if (i == array.Length)
						{
							return false;
						}
						i--;
					}
					else if (char.IsDigit(array[i]))
					{
						if (num2 != -1)
						{
							return false;
						}
						num = i;
						for (; i < array.Length && char.IsDigit(array[i]); i++)
						{
						}
						num2 = int.Parse(string_0.Substring(num, i - num)) - 1;
						if (num2 > 1048575)
						{
							return false;
						}
						if (i != array.Length)
						{
							return false;
						}
					}
					else
					{
						if (array[i] != '$')
						{
							break;
						}
						if (i == array.Length - 1)
						{
							return false;
						}
						if (i != 0 && array[i - 1] == '$')
						{
							return false;
						}
					}
					i++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	internal static byte[] smethod_2(WorksheetCollection sheets, int sheetIndex, string values, bool hasParen, bool validName, out bool isValid)
	{
		isValid = true;
		string[] array = values.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
		}
		if (array.Length > 0 && array[0][0] == '=')
		{
			array[0] = array[0].Substring(1);
		}
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < array.Length)
			{
				string refString = array[num2];
				byte[] array2 = smethod_3(sheets, sheetIndex, refString, externRef: true, validName, convertName: true, out isValid);
				if (!isValid)
				{
					break;
				}
				arrayList.Add(array2);
				num += array2.Length;
				if (num2 > 0)
				{
					num++;
				}
				num2++;
				continue;
			}
			byte[] array3 = new byte[3 + num + (hasParen ? 1 : 0)];
			array3[0] = 41;
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, array3, 1, 2);
			int num3 = 3;
			for (int j = 0; j < arrayList.Count; j++)
			{
				byte[] array4 = (byte[])arrayList[j];
				Array.Copy(array4, 0, array3, num3, array4.Length);
				num3 += array4.Length;
				if (j > 0)
				{
					array3[num3++] = 16;
				}
			}
			if (hasParen)
			{
				array3[num3] = 21;
			}
			return array3;
		}
		return null;
	}

	internal static byte[] smethod_3(WorksheetCollection sheets, int sheetIndex, string refString, bool externRef, bool validName, bool convertName, out bool isValid)
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		isValid = true;
		if (refString[0] == '=')
		{
			refString = refString.Substring(1);
		}
		Regex regex = new Regex("!");
		Match match = regex.Match(refString);
		bool flag = false;
		if (match.Success)
		{
			flag = true;
			string text = refString.Substring(0, match.Index).Trim();
			if (text[0] == '\'' && text[text.Length - 1] == '\'')
			{
				text = text.Substring(1, text.Length - 2);
				if (text == null || text == "")
				{
					throw new CellsException(ExceptionType.SheetName, "Invalid worksheet name.");
				}
			}
			int[] array = Class1660.smethod_3(sheets, text);
			num2 = array[0];
			num3 = array[1];
			num = array[2];
			if (num2 == -1)
			{
				throw new CellsException(ExceptionType.SheetName, "Invalid worksheet name.");
			}
			sheetIndex = num;
			refString = refString.Substring(match.Index + 1).Trim();
		}
		else
		{
			num3 = sheets.method_36();
			num2 = sheets.method_32().method_8(sheets.method_36(), sheetIndex);
		}
		regex = new Regex(":");
		Match match2 = regex.Match(refString);
		byte[] array2 = null;
		if (match2.Success)
		{
			int row = 0;
			int column = 0;
			bool isRowOnly = false;
			bool isColumnOnly = false;
			bool isRowAbsolute = false;
			bool isColumnAbsolute = false;
			int row2 = 0;
			int column2 = 0;
			bool isRowOnly2 = false;
			bool isColumnOnly2 = false;
			bool isRowAbsolute2 = false;
			bool isColumnAbsolute2 = false;
			string cellName = refString.Substring(0, match2.Index).Trim();
			string cellName2 = refString.Substring(match2.Index + 1).Trim();
			if (!CellNameToIndex(cellName, out row, out column, ref isRowAbsolute, ref isColumnAbsolute, ref isRowOnly, ref isColumnOnly))
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid cell range.");
			}
			if (!CellNameToIndex(cellName2, out row2, out column2, ref isRowAbsolute2, ref isColumnAbsolute2, ref isRowOnly2, ref isColumnOnly2))
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid cell range.");
			}
			if (isRowOnly == isRowOnly2 && isColumnOnly == isColumnOnly2)
			{
				int num4 = 1;
				if (!flag && !externRef)
				{
					array2 = new byte[13]
					{
						37, 0, 0, 0, 0, 0, 0, 0, 0, 0,
						0, 0, 0
					};
				}
				else
				{
					array2 = new byte[15]
					{
						59, 0, 0, 0, 0, 0, 0, 0, 0, 0,
						0, 0, 0, 0, 0
					};
					Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, 1, 2);
					num4 = 3;
				}
				if (isRowOnly)
				{
					Class1268.smethod_3(array2, num4, row, 0, isRowAbsolute, bool_1: false);
					Class1268.smethod_3(array2, num4 + 4, row2, 0, isRowAbsolute2, bool_1: false);
					Class1268.smethod_5(array2, num4 + 10, 16383, 0, isColumnAbsolute2, bool_1: false);
				}
				else if (isColumnOnly)
				{
					Class1268.smethod_3(array2, num4 + 4, 1048575, 0, isRowAbsolute2, bool_1: false);
					Class1268.smethod_5(array2, num4 + 8, column, 0, isColumnAbsolute, bool_1: false);
					Class1268.smethod_5(array2, num4 + 10, column2, 0, isColumnAbsolute2, bool_1: false);
				}
				else
				{
					Class1268.smethod_3(array2, num4, row, 0, isRowAbsolute, bool_1: false);
					Class1268.smethod_3(array2, num4 + 4, row2, 0, isRowAbsolute2, bool_1: false);
					Class1268.smethod_5(array2, num4 + 8, column, 0, isColumnAbsolute, bool_1: false);
					Class1268.smethod_5(array2, num4 + 10, column2, 0, isColumnAbsolute2, bool_1: false);
				}
				return array2;
			}
			throw new CellsException(ExceptionType.InvalidData, "Invalid cell range.");
		}
		int row3 = 0;
		int column3 = 0;
		bool isRowOnly3 = false;
		bool isColumnOnly3 = false;
		bool isRowAbsolute3 = false;
		bool isColumnAbsolute3 = false;
		if (CellNameToIndex(refString, out row3, out column3, ref isRowAbsolute3, ref isColumnAbsolute3, ref isRowOnly3, ref isColumnOnly3) && !isRowOnly3 && !isColumnOnly3)
		{
			if (!flag && !externRef)
			{
				array2 = new byte[7] { 36, 0, 0, 0, 0, 0, 0 };
				Class1268.smethod_3(array2, 1, row3, 0, isRowAbsolute3, bool_1: false);
				Class1268.smethod_5(array2, 5, column3, 0, isColumnAbsolute3, bool_1: false);
			}
			else
			{
				array2 = new byte[9] { 58, 0, 0, 0, 0, 0, 0, 0, 0 };
				Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, 1, 2);
				Class1268.smethod_3(array2, 3, row3, 0, isRowAbsolute3, bool_1: false);
				Class1268.smethod_5(array2, 7, column3, 0, isColumnAbsolute3, bool_1: false);
			}
			return array2;
		}
		if (!validName)
		{
			isValid = false;
			return null;
		}
		if (refString.Length > 0 && refString[0] == '\'')
		{
			refString = refString.Substring(1, refString.Length - 2);
		}
		if (num3 == sheets.method_36())
		{
			sheetIndex = (flag ? sheetIndex : (-1));
			int num5 = sheets.Names.method_9(refString, sheetIndex);
			if (num5 == -1)
			{
				isValid = false;
				return null;
			}
			Name name = sheets.Names[num5];
			Range range = name.CreateRange();
			if (range == null)
			{
				isValid = false;
				return null;
			}
			if (flag)
			{
				array2 = new byte[7] { 57, 0, 0, 0, 0, 0, 0 };
				Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array2, 1, 2);
				Array.Copy(BitConverter.GetBytes((ushort)num5 + 1), 0, array2, 3, 2);
			}
			else if (convertName)
			{
				array2 = name.method_28();
			}
			else
			{
				array2 = new byte[5] { 35, 0, 0, 0, 0 };
				Array.Copy(BitConverter.GetBytes((ushort)num5 + 1), 0, array2, 1, 2);
			}
		}
		else
		{
			array2 = Class1272.smethod_1(sheets, num3, num2, sheetIndex, refString, Enum180.const_1, Enum227.const_0);
		}
		return array2;
	}
}
