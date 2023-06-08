using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns12;

namespace ns29;

internal class Class1678
{
	internal static void smethod_0(ArrayList arrayList_0, CellArea cellArea_0)
	{
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			object obj = Intersect(cellArea, cellArea_0);
			if (obj == null)
			{
				if (cellArea.StartRow == cellArea_0.StartRow && cellArea.EndRow == cellArea_0.EndRow)
				{
					if (cellArea_0.StartColumn == cellArea.EndColumn + 1)
					{
						cellArea.EndColumn = cellArea_0.EndColumn;
						arrayList_0[i] = cellArea;
						flag = true;
						break;
					}
					if (cellArea_0.EndColumn == cellArea.StartColumn + 1)
					{
						cellArea.StartColumn = cellArea_0.StartColumn;
						arrayList_0[i] = cellArea;
						flag = true;
						break;
					}
				}
				else if (cellArea.StartColumn == cellArea_0.StartColumn && cellArea.EndColumn == cellArea_0.StartColumn)
				{
					if (cellArea_0.StartRow == cellArea.EndRow + 1)
					{
						cellArea.EndRow = cellArea_0.EndRow;
						arrayList_0[i] = cellArea;
						flag = true;
						break;
					}
					if (cellArea_0.EndRow == cellArea.StartRow + 1)
					{
						cellArea.StartRow = cellArea_0.StartRow;
						arrayList_0[i] = cellArea;
						flag = true;
						break;
					}
				}
				continue;
			}
			CellArea cellArea_ = (CellArea)obj;
			if (smethod_1(cellArea_, cellArea_0))
			{
				arrayList_0[i] = cellArea;
			}
			else if (smethod_1(cellArea_, cellArea))
			{
				arrayList_0[i] = cellArea_0;
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			arrayList_0.Add(cellArea_0);
		}
	}

	internal static CellArea InsertRows(CellArea cellArea_0, int int_0, int int_1, ref bool bool_0)
	{
		if (int_1 == 0)
		{
			return cellArea_0;
		}
		if (int_1 < 0 && cellArea_0.StartRow >= int_0 && int_0 - int_1 - 1 >= cellArea_0.EndRow)
		{
			bool_0 = true;
			return cellArea_0;
		}
		if (cellArea_0.StartRow >= int_0)
		{
			cellArea_0.StartRow += int_1;
			if (cellArea_0.StartRow < int_0)
			{
				cellArea_0.StartRow = int_0;
			}
			if (cellArea_0.StartRow > 1048575)
			{
				bool_0 = true;
				return cellArea_0;
			}
		}
		if (cellArea_0.EndRow >= int_0)
		{
			cellArea_0.EndRow += int_1;
			if (cellArea_0.EndRow > 1048575)
			{
				cellArea_0.EndRow = 1048575;
			}
			else if (cellArea_0.EndRow < int_0)
			{
				cellArea_0.EndRow = int_0 - 1;
			}
		}
		bool_0 = false;
		return cellArea_0;
	}

	internal static CellArea InsertColumns(CellArea cellArea_0, int int_0, int int_1, ref bool bool_0)
	{
		if (int_1 == 0)
		{
			return cellArea_0;
		}
		if (int_1 < 0 && cellArea_0.StartColumn >= int_0 && int_0 - int_1 - 1 >= cellArea_0.EndColumn)
		{
			bool_0 = true;
			return cellArea_0;
		}
		if (cellArea_0.StartColumn >= int_0)
		{
			cellArea_0.StartColumn += int_1;
			if (cellArea_0.StartColumn < int_0)
			{
				cellArea_0.StartColumn = int_0;
			}
			if (cellArea_0.StartColumn > 16383)
			{
				bool_0 = true;
				return cellArea_0;
			}
		}
		if (cellArea_0.EndColumn > int_0 - 1)
		{
			cellArea_0.EndColumn += int_1;
			if (cellArea_0.EndColumn > 16383)
			{
				cellArea_0.EndColumn = 16383;
			}
			else if (cellArea_0.EndColumn < int_0)
			{
				cellArea_0.EndColumn = int_0 - 1;
			}
		}
		bool_0 = false;
		return cellArea_0;
	}

	internal static bool smethod_1(CellArea cellArea_0, CellArea cellArea_1)
	{
		if (cellArea_0.StartRow == cellArea_1.StartRow && cellArea_0.StartColumn == cellArea_1.StartColumn && cellArea_0.EndRow == cellArea_1.EndRow)
		{
			return cellArea_0.EndColumn == cellArea_1.EndColumn;
		}
		return false;
	}

	internal static bool smethod_2(CellArea cellArea_0, CellArea cellArea_1)
	{
		object obj = Intersect(cellArea_0, cellArea_1);
		if (obj != null)
		{
			if (cellArea_0.StartRow <= cellArea_1.StartRow && cellArea_0.EndRow >= cellArea_1.EndRow && cellArea_0.StartColumn <= cellArea_1.StartColumn)
			{
				return cellArea_0.StartColumn >= cellArea_1.EndColumn;
			}
			return false;
		}
		return true;
	}

	internal static CellArea smethod_3(CellArea cellArea_0, CellArea cellArea_1)
	{
		int startRow = ((cellArea_0.StartRow < cellArea_1.StartRow) ? cellArea_0.StartRow : cellArea_1.StartRow);
		int startColumn = ((cellArea_0.StartColumn < cellArea_1.StartColumn) ? cellArea_0.StartColumn : cellArea_1.StartColumn);
		int endRow = ((cellArea_0.EndRow > cellArea_1.EndRow) ? cellArea_0.EndRow : cellArea_1.EndRow);
		int endColumn = ((cellArea_0.EndColumn > cellArea_1.EndColumn) ? cellArea_0.EndColumn : cellArea_1.EndColumn);
		CellArea result = default(CellArea);
		result.StartRow = startRow;
		result.StartColumn = startColumn;
		result.EndRow = endRow;
		result.EndColumn = endColumn;
		return result;
	}

	internal static object Intersect(CellArea cellArea_0, CellArea cellArea_1)
	{
		int num = ((cellArea_0.StartRow < cellArea_1.StartRow) ? cellArea_1.StartRow : cellArea_0.StartRow);
		int num2 = ((cellArea_0.EndRow > cellArea_1.EndRow) ? cellArea_1.EndRow : cellArea_0.EndRow);
		if (num > num2)
		{
			return null;
		}
		int num3 = ((cellArea_0.StartColumn < cellArea_1.StartColumn) ? cellArea_1.StartColumn : cellArea_0.StartColumn);
		int num4 = ((cellArea_0.EndColumn > cellArea_1.EndColumn) ? cellArea_1.EndColumn : cellArea_0.EndColumn);
		if (num3 > num4)
		{
			return null;
		}
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = num;
		cellArea.EndRow = num2;
		cellArea.StartColumn = num3;
		cellArea.EndColumn = num4;
		return cellArea;
	}

	internal static object smethod_4(CellArea cellArea_0, int int_0, int int_1)
	{
		int num = int_0 + int_1 - 1;
		CellArea cellArea = default(CellArea);
		cellArea.StartColumn = cellArea_0.StartColumn;
		cellArea.EndColumn = cellArea_0.EndColumn;
		if (int_0 < cellArea_0.StartRow)
		{
			if (num < cellArea_0.StartRow)
			{
				return null;
			}
			if (num <= cellArea_0.EndRow)
			{
				cellArea.StartRow = cellArea_0.StartRow;
				cellArea.EndRow = num;
			}
			else
			{
				cellArea.StartRow = cellArea_0.StartRow;
				cellArea.EndRow = cellArea_0.EndRow;
			}
		}
		else if (int_0 >= cellArea_0.StartRow)
		{
			if (int_0 > cellArea_0.EndRow)
			{
				return null;
			}
			if (num <= cellArea_0.EndRow)
			{
				cellArea.StartRow = int_0;
				cellArea.EndRow = num;
			}
			else
			{
				cellArea.StartRow = int_0;
				cellArea.EndRow = cellArea_0.EndRow;
			}
		}
		return cellArea;
	}

	internal static object smethod_5(CellArea cellArea_0, int int_0, int int_1)
	{
		int num = int_0 + int_1 - 1;
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = cellArea_0.StartRow;
		cellArea.EndRow = cellArea_0.EndRow;
		if (int_0 < cellArea_0.EndColumn)
		{
			if (num < cellArea_0.StartColumn)
			{
				return null;
			}
			if (num <= cellArea_0.EndColumn)
			{
				cellArea.StartColumn = cellArea_0.StartColumn;
				cellArea.EndColumn = num;
			}
			else
			{
				cellArea.StartColumn = cellArea_0.StartColumn;
				cellArea.EndColumn = cellArea_0.EndColumn;
			}
		}
		else if (int_0 >= cellArea_0.EndColumn)
		{
			if (int_0 > cellArea_0.EndColumn)
			{
				return null;
			}
			if (num <= cellArea_0.EndColumn)
			{
				cellArea.StartColumn = int_0;
				cellArea.EndColumn = num;
			}
			else
			{
				cellArea.StartColumn = int_0;
				cellArea.EndColumn = cellArea_0.EndColumn;
			}
		}
		return cellArea;
	}

	internal static ArrayList smethod_6(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		if (string_0.IndexOf(',') != -1)
		{
			string[] array = Class1660.smethod_17(string_0);
			if (array == null)
			{
				arrayList.Add(smethod_8(string_0));
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					arrayList.Add(smethod_8(array[i]));
				}
			}
		}
		else
		{
			arrayList.Add(smethod_8(string_0));
		}
		return arrayList;
	}

	internal static string smethod_7(ArrayList arrayList_0, bool bool_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (cellArea.StartColumn != -1 && cellArea.EndColumn != -1)
			{
				if (cellArea.StartRow != -1 && cellArea.EndRow != -1)
				{
					if (bool_0)
					{
						stringBuilder.Append('$');
						stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.StartColumn));
						stringBuilder.Append('$');
						stringBuilder.Append(cellArea.StartRow + 1);
						stringBuilder.Append(':');
						stringBuilder.Append('$');
						stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.EndColumn));
						stringBuilder.Append('$');
						stringBuilder.Append(cellArea.EndRow + 1);
					}
					else
					{
						stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn));
						stringBuilder.Append(':');
						stringBuilder.Append(CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn));
					}
				}
				else
				{
					stringBuilder.Append('$');
					stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.StartColumn));
					stringBuilder.Append(':');
					stringBuilder.Append('$');
					stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.EndColumn));
				}
			}
			else
			{
				stringBuilder.Append('$');
				stringBuilder.Append(cellArea.StartRow + 1);
				stringBuilder.Append(':');
				stringBuilder.Append('$');
				stringBuilder.Append(cellArea.EndRow + 1);
			}
			if (i != arrayList_0.Count - 1)
			{
				stringBuilder.Append(',');
			}
		}
		return stringBuilder.ToString();
	}

	internal static CellArea smethod_8(string string_0)
	{
		string_0 = string_0.Replace("$", "");
		Regex regex = new Regex(":");
		Match match = regex.Match(string_0);
		CellArea result = default(CellArea);
		int row;
		int column;
		if (match.Success)
		{
			string text = string_0.Substring(0, match.Index).Trim();
			string text2 = string_0.Substring(match.Index + 1).Trim();
			if (char.IsDigit(text[0]))
			{
				result.StartRow = int.Parse(text) - 1;
				result.EndColumn = -1;
				result.StartColumn = -1;
				result.EndRow = int.Parse(text2) - 1;
			}
			else if (char.IsLetter(text[text.Length - 1]))
			{
				result.EndRow = -1;
				result.StartRow = -1;
				result.StartColumn = CellsHelper.ColumnNameToIndex(text);
				result.EndColumn = CellsHelper.ColumnNameToIndex(text2);
			}
			else
			{
				CellsHelper.CellNameToIndex(text, out row, out column);
				result.StartRow = row;
				result.StartColumn = column;
				CellsHelper.CellNameToIndex(text2, out row, out column);
				result.EndRow = row;
				result.EndColumn = column;
			}
		}
		else
		{
			CellsHelper.CellNameToIndex(string_0, out row, out column);
			result.StartRow = (result.EndRow = row);
			result.StartColumn = (result.EndColumn = column);
		}
		return result;
	}

	internal static string smethod_9(ArrayList arrayList_0, bool bool_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (bool_0)
			{
				stringBuilder.Append('$');
				stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.StartColumn));
				stringBuilder.Append(':');
				stringBuilder.Append('$');
				stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.EndColumn));
			}
			else
			{
				stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.StartColumn));
				stringBuilder.Append(':');
				stringBuilder.Append(CellsHelper.ColumnIndexToName(cellArea.EndColumn));
			}
			if (i != arrayList_0.Count - 1)
			{
				stringBuilder.Append(',');
			}
		}
		return stringBuilder.ToString();
	}

	internal static ArrayList smethod_10(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		string_0 = string_0.Replace("$", "");
		string[] array = string_0.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				CellArea cellArea = default(CellArea);
				cellArea.StartRow = 0;
				cellArea.EndRow = 16383;
				if (array[i].IndexOf(':') == -1)
				{
					cellArea.StartColumn = (cellArea.EndColumn = CellsHelper.ColumnNameToIndex(array[i]));
				}
				else
				{
					string[] array2 = array[i].Split(':');
					cellArea.StartColumn = CellsHelper.ColumnNameToIndex(array2[0]);
					cellArea.EndColumn = CellsHelper.ColumnNameToIndex(array2[1]);
				}
				arrayList.Add(cellArea);
			}
		}
		return arrayList;
	}

	internal static string smethod_11(ArrayList arrayList_0, bool bool_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (bool_0)
			{
				stringBuilder.Append('$');
				stringBuilder.Append(cellArea.StartRow + 1);
				stringBuilder.Append(':');
				stringBuilder.Append('$');
				stringBuilder.Append(cellArea.EndRow + 1);
			}
			else
			{
				stringBuilder.Append(cellArea.StartRow + 1);
				stringBuilder.Append(':');
				stringBuilder.Append(cellArea.EndRow + 1);
			}
			if (i != arrayList_0.Count - 1)
			{
				stringBuilder.Append(',');
			}
		}
		return stringBuilder.ToString();
	}

	internal static ArrayList smethod_12(string string_0)
	{
		ArrayList arrayList = new ArrayList();
		string_0 = string_0.Replace("$", "");
		string[] array = string_0.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				CellArea cellArea = default(CellArea);
				cellArea.StartColumn = 0;
				cellArea.EndColumn = 1048575;
				if (array[i].IndexOf(':') == -1)
				{
					cellArea.StartRow = (cellArea.EndRow = int.Parse(array[i]) - 1);
				}
				else
				{
					string[] array2 = array[i].Split(':');
					cellArea.StartRow = int.Parse(array2[0]) - 1;
					cellArea.EndRow = int.Parse(array2[1]) - 1;
				}
				arrayList.Add(cellArea);
			}
		}
		return arrayList;
	}

	internal static ArrayList smethod_13(bool is2007, CellArea shiftArea, int shiftNumber, CellArea ca, out bool flag)
	{
		ArrayList arrayList = new ArrayList();
		if (shiftArea.StartColumn <= ca.EndColumn && shiftArea.EndColumn >= ca.StartColumn && shiftArea.StartRow <= ca.EndRow)
		{
			if (!is2007)
			{
				if (ca.StartRow == 0 && ca.EndRow >= 65535)
				{
					flag = false;
					return arrayList;
				}
				if (shiftArea.StartColumn <= ca.StartColumn)
				{
					if (shiftArea.EndColumn >= ca.EndColumn)
					{
						if (shiftArea.StartRow <= ca.StartRow)
						{
							ca.StartRow += shiftNumber;
							ca.EndRow += shiftNumber;
							if (ca.EndRow > 65535)
							{
								ca.EndRow = 65535;
							}
							arrayList.Add(ca);
							flag = true;
							return arrayList;
						}
						ca.EndRow += shiftNumber;
						arrayList.Add(ca);
						flag = true;
						return arrayList;
					}
					if (shiftArea.StartRow <= ca.EndRow)
					{
						CellArea cellArea = default(CellArea);
						cellArea.StartColumn = ca.StartColumn;
						cellArea.EndColumn = shiftArea.EndColumn;
						cellArea.StartRow = ca.StartRow + shiftNumber;
						cellArea.EndRow = ca.EndRow + shiftNumber;
						arrayList.Add(cellArea);
					}
					else
					{
						CellArea cellArea2 = default(CellArea);
						cellArea2.StartColumn = ca.StartColumn;
						cellArea2.EndColumn = shiftArea.EndColumn;
						cellArea2.StartRow = ca.StartRow;
						cellArea2.EndRow = ca.EndRow + shiftNumber;
						arrayList.Add(cellArea2);
					}
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = ca.StartRow;
					cellArea3.EndRow = ca.EndRow;
					cellArea3.StartColumn = shiftArea.EndColumn + 1;
					cellArea3.EndColumn = ca.EndColumn;
					arrayList.Add(cellArea3);
					flag = true;
					return arrayList;
				}
				CellArea cellArea4 = default(CellArea);
				cellArea4.StartRow = ca.StartRow;
				cellArea4.EndRow = ca.EndRow;
				cellArea4.StartColumn = ca.StartColumn;
				cellArea4.EndColumn = shiftArea.StartColumn - 1;
				arrayList.Add(cellArea4);
				if (shiftArea.EndColumn >= ca.EndColumn)
				{
					if (shiftArea.StartRow <= ca.StartRow)
					{
						CellArea cellArea5 = default(CellArea);
						cellArea5.StartColumn = shiftArea.StartColumn;
						cellArea5.EndColumn = ca.EndColumn;
						cellArea5.StartRow = ca.StartRow + shiftNumber;
						cellArea5.EndRow = ca.EndRow + shiftNumber;
						arrayList.Add(cellArea5);
					}
					else
					{
						CellArea cellArea6 = default(CellArea);
						cellArea6.StartColumn = shiftArea.StartColumn;
						cellArea6.EndColumn = ca.EndColumn;
						cellArea6.StartRow = ca.StartRow;
						cellArea6.EndRow = ca.EndRow + shiftNumber;
						arrayList.Add(cellArea6);
					}
					flag = true;
					return arrayList;
				}
				if (shiftArea.StartRow <= ca.StartRow)
				{
					CellArea cellArea7 = default(CellArea);
					cellArea7.StartColumn = shiftArea.StartColumn;
					cellArea7.EndColumn = shiftArea.EndColumn;
					cellArea7.StartRow = ca.StartRow + shiftNumber;
					cellArea7.EndRow = ca.EndRow + shiftNumber;
					if (cellArea7.EndRow > 65535)
					{
						cellArea7.EndRow = 65535;
					}
					arrayList.Add(cellArea7);
				}
				else
				{
					CellArea cellArea8 = default(CellArea);
					cellArea8.StartColumn = shiftArea.StartColumn;
					cellArea8.EndColumn = shiftArea.EndColumn;
					cellArea8.StartRow = ca.StartRow;
					cellArea8.EndRow = ca.EndRow + shiftNumber;
					arrayList.Add(cellArea8);
				}
				CellArea cellArea9 = default(CellArea);
				cellArea9.StartRow = ca.StartRow;
				cellArea9.EndRow = ca.EndRow;
				cellArea9.StartColumn = shiftArea.EndColumn + 1;
				cellArea9.EndColumn = ca.EndColumn;
				arrayList.Add(cellArea9);
				flag = true;
				return arrayList;
			}
			if (ca.StartRow == 0 && ca.EndRow >= 1048575)
			{
				flag = false;
				return arrayList;
			}
			if (shiftArea.StartColumn <= ca.StartColumn)
			{
				if (shiftArea.EndColumn >= ca.EndColumn)
				{
					if (shiftArea.StartRow <= ca.StartRow)
					{
						ca.StartRow += shiftNumber;
						ca.EndRow += shiftNumber;
						if (ca.EndRow > 1048575)
						{
							ca.EndRow = 1048575;
						}
						arrayList.Add(ca);
						flag = true;
						return arrayList;
					}
					ca.EndRow += shiftNumber;
					arrayList.Add(ca);
					flag = true;
					return arrayList;
				}
				if (shiftArea.StartRow <= ca.EndRow)
				{
					CellArea cellArea10 = default(CellArea);
					cellArea10.StartColumn = ca.StartColumn;
					cellArea10.EndColumn = shiftArea.EndColumn;
					cellArea10.StartRow = ca.StartRow + shiftNumber;
					cellArea10.EndRow = ca.EndRow + shiftNumber;
					arrayList.Add(cellArea10);
				}
				else
				{
					CellArea cellArea11 = default(CellArea);
					cellArea11.StartColumn = ca.StartColumn;
					cellArea11.EndColumn = shiftArea.EndColumn;
					cellArea11.StartRow = ca.StartRow;
					cellArea11.EndRow = ca.EndRow + shiftNumber;
					arrayList.Add(cellArea11);
				}
				CellArea cellArea12 = default(CellArea);
				cellArea12.StartRow = ca.StartRow;
				cellArea12.EndRow = ca.EndRow;
				cellArea12.StartColumn = shiftArea.EndColumn + 1;
				cellArea12.EndColumn = ca.EndColumn;
				arrayList.Add(cellArea12);
				flag = true;
				return arrayList;
			}
			CellArea cellArea13 = default(CellArea);
			cellArea13.StartRow = ca.StartRow;
			cellArea13.EndRow = ca.EndRow;
			cellArea13.StartColumn = ca.StartColumn;
			cellArea13.EndColumn = shiftArea.StartColumn - 1;
			arrayList.Add(cellArea13);
			if (shiftArea.EndColumn >= ca.EndColumn)
			{
				if (shiftArea.StartRow <= ca.StartRow)
				{
					CellArea cellArea14 = default(CellArea);
					cellArea14.StartColumn = shiftArea.StartColumn;
					cellArea14.EndColumn = ca.EndColumn;
					cellArea14.StartRow = ca.StartRow + shiftNumber;
					cellArea14.EndRow = ca.EndRow + shiftNumber;
					arrayList.Add(cellArea14);
				}
				else
				{
					CellArea cellArea15 = default(CellArea);
					cellArea15.StartColumn = shiftArea.StartColumn;
					cellArea15.EndColumn = ca.EndColumn;
					cellArea15.StartRow = ca.StartRow;
					cellArea15.EndRow = ca.EndRow + shiftNumber;
					arrayList.Add(cellArea15);
				}
				flag = true;
				return arrayList;
			}
			if (shiftArea.StartRow <= ca.StartRow)
			{
				CellArea cellArea16 = default(CellArea);
				cellArea16.StartColumn = shiftArea.StartColumn;
				cellArea16.EndColumn = shiftArea.EndColumn;
				cellArea16.StartRow = ca.StartRow + shiftNumber;
				cellArea16.EndRow = ca.EndRow + shiftNumber;
				arrayList.Add(cellArea16);
			}
			else
			{
				CellArea cellArea17 = default(CellArea);
				cellArea17.StartColumn = shiftArea.StartColumn;
				cellArea17.EndColumn = shiftArea.EndColumn;
				cellArea17.StartRow = ca.StartRow;
				cellArea17.EndRow = ca.EndRow + shiftNumber;
				arrayList.Add(cellArea17);
			}
			CellArea cellArea18 = default(CellArea);
			cellArea18.StartRow = ca.StartRow;
			cellArea18.EndRow = ca.EndRow;
			cellArea18.StartColumn = shiftArea.EndColumn + 1;
			cellArea18.EndColumn = ca.EndColumn;
			arrayList.Add(cellArea18);
			flag = true;
			return arrayList;
		}
		flag = false;
		return arrayList;
	}

	internal static void smethod_14(ArrayList arrayList_0, bool bool_0, CellArea cellArea_0, int int_0, ArrayList arrayList_1, ArrayList arrayList_2)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			smethod_16(bool_0, cellArea_0, int_0, (CellArea)arrayList_0[i], arrayList_1, arrayList_2);
		}
	}

	internal static void smethod_15(ArrayList arrayList_0, bool bool_0, CellArea cellArea_0, int int_0, ArrayList arrayList_1, ArrayList arrayList_2)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			smethod_17(bool_0, cellArea_0, int_0, (CellArea)arrayList_0[i], arrayList_1, arrayList_2);
		}
	}

	internal static void smethod_16(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartColumn <= cellArea_1.EndColumn && cellArea_0.EndColumn >= cellArea_1.StartColumn && cellArea_0.StartRow <= cellArea_1.EndRow)
		{
			if (!bool_0)
			{
				if (cellArea_1.StartRow == 0 && cellArea_1.EndRow >= 65535)
				{
					arrayList_0.Add(cellArea_1);
					return;
				}
			}
			else if (cellArea_1.StartRow == 0 && cellArea_1.EndRow >= 1048575)
			{
				arrayList_0.Add(cellArea_1);
				return;
			}
			if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
			{
				if (cellArea_0.EndColumn >= cellArea_1.EndColumn)
				{
					if (cellArea_0.StartRow <= cellArea_1.StartRow)
					{
						cellArea_1.StartRow += int_0;
						cellArea_1.EndRow += int_0;
						arrayList_1.Add(cellArea_1);
					}
					else
					{
						cellArea_1.EndRow += int_0;
						arrayList_0.Add(cellArea_1);
					}
					return;
				}
				if (cellArea_0.StartRow <= cellArea_1.EndRow)
				{
					CellArea cellArea = default(CellArea);
					cellArea.StartColumn = cellArea_1.StartColumn;
					cellArea.EndColumn = cellArea_0.EndColumn;
					cellArea.StartRow = cellArea_1.StartRow + int_0;
					cellArea.EndRow = cellArea_1.EndRow + int_0;
					arrayList_1.Add(cellArea);
				}
				else
				{
					CellArea cellArea2 = default(CellArea);
					cellArea2.StartColumn = cellArea_1.StartColumn;
					cellArea2.EndColumn = cellArea_0.EndColumn;
					cellArea2.StartRow = cellArea_1.StartRow;
					cellArea2.EndRow = cellArea_1.EndRow + int_0;
					arrayList_0.Add(cellArea2);
				}
				CellArea cellArea3 = default(CellArea);
				cellArea3.StartRow = cellArea_1.StartRow;
				cellArea3.EndRow = cellArea_1.EndRow;
				cellArea3.StartColumn = cellArea_0.EndColumn + 1;
				cellArea3.EndColumn = cellArea_1.EndColumn;
				arrayList_0.Add(cellArea3);
				return;
			}
			CellArea cellArea4 = default(CellArea);
			cellArea4.StartRow = cellArea_1.StartRow;
			cellArea4.EndRow = cellArea_1.EndRow;
			cellArea4.StartColumn = cellArea_1.StartColumn;
			cellArea4.EndColumn = cellArea_0.StartColumn - 1;
			arrayList_0.Add(cellArea4);
			if (cellArea_0.EndColumn >= cellArea_1.EndColumn)
			{
				if (cellArea_0.StartRow <= cellArea_1.StartRow)
				{
					CellArea cellArea5 = default(CellArea);
					cellArea5.StartColumn = cellArea_0.StartColumn;
					cellArea5.EndColumn = cellArea_1.EndColumn;
					cellArea5.StartRow = cellArea_1.StartRow + int_0;
					cellArea5.EndRow = cellArea_1.EndRow + int_0;
					arrayList_1.Add(cellArea5);
				}
				else
				{
					CellArea cellArea6 = default(CellArea);
					cellArea6.StartColumn = cellArea_0.StartColumn;
					cellArea6.EndColumn = cellArea_1.EndColumn;
					cellArea6.StartRow = cellArea_1.StartRow;
					cellArea6.EndRow = cellArea_1.EndRow + int_0;
					arrayList_0.Add(cellArea6);
				}
				return;
			}
			if (cellArea_0.StartRow <= cellArea_1.StartRow)
			{
				CellArea cellArea7 = default(CellArea);
				cellArea7.StartColumn = cellArea_0.StartColumn;
				cellArea7.EndColumn = cellArea_0.EndColumn;
				cellArea7.StartRow = cellArea_1.StartRow + int_0;
				cellArea7.EndRow = cellArea_1.EndRow + int_0;
				arrayList_1.Add(cellArea7);
			}
			else
			{
				CellArea cellArea8 = default(CellArea);
				cellArea8.StartColumn = cellArea_0.StartColumn;
				cellArea8.EndColumn = cellArea_0.EndColumn;
				cellArea8.StartRow = cellArea_1.StartRow;
				cellArea8.EndRow = cellArea_1.EndRow + int_0;
				arrayList_0.Add(cellArea8);
			}
			CellArea cellArea9 = default(CellArea);
			cellArea9.StartRow = cellArea_1.StartRow;
			cellArea9.EndRow = cellArea_1.EndRow;
			cellArea9.StartColumn = cellArea_0.EndColumn + 1;
			cellArea9.EndColumn = cellArea_1.EndColumn;
			arrayList_0.Add(cellArea9);
		}
		else
		{
			arrayList_0.Add(cellArea_1);
		}
	}

	internal static void DeleteRows(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartRow <= cellArea_1.StartRow)
		{
			if (cellArea_0.EndRow < cellArea_1.StartRow)
			{
				cellArea_1.StartRow -= int_0;
				cellArea_1.EndRow -= int_0;
				arrayList_1.Add(cellArea_1);
			}
			else if (cellArea_0.EndRow < cellArea_1.EndRow)
			{
				CellArea cellArea = CellArea.CreateCellArea(cellArea_0.EndRow + 1, cellArea_1.StartColumn, cellArea_1.EndRow, cellArea_1.EndColumn);
				cellArea.StartRow -= int_0;
				cellArea.EndRow -= int_0;
				arrayList_1.Add(cellArea);
			}
		}
		else if (cellArea_0.EndColumn < cellArea_1.EndColumn)
		{
			cellArea_1.EndColumn -= int_0;
			arrayList_1.Add(cellArea_1);
		}
		else
		{
			cellArea_1.EndColumn = cellArea_0.StartColumn - 1;
			arrayList_1.Add(cellArea_1);
		}
	}

	internal static void smethod_17(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartColumn <= cellArea_1.EndColumn && cellArea_0.EndColumn >= cellArea_1.StartColumn && cellArea_0.StartRow <= cellArea_1.EndRow)
		{
			if (!bool_0)
			{
				if (cellArea_1.StartRow == 0 && cellArea_1.EndRow >= 65535)
				{
					arrayList_0.Add(cellArea_1);
					return;
				}
			}
			else if (cellArea_1.StartRow == 0 && cellArea_1.EndRow >= 1048575)
			{
				arrayList_0.Add(cellArea_1);
				return;
			}
			if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
			{
				if (cellArea_0.EndColumn >= cellArea_1.EndColumn)
				{
					DeleteRows(bool_0, cellArea_0, int_0, cellArea_1, arrayList_0, arrayList_1);
					return;
				}
				CellArea cellArea_2 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_1.StartColumn, cellArea_1.EndRow, cellArea_0.EndColumn);
				DeleteRows(bool_0, cellArea_0, int_0, cellArea_2, arrayList_0, arrayList_1);
				CellArea cellArea = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_0.EndColumn + 1, cellArea_1.EndRow, cellArea_1.EndColumn);
				arrayList_0.Add(cellArea);
				return;
			}
			CellArea cellArea2 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_1.StartColumn, cellArea_1.EndRow, cellArea_0.StartColumn - 1);
			arrayList_0.Add(cellArea2);
			CellArea cellArea3 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_0.StartColumn, cellArea_1.EndRow, cellArea_1.EndColumn);
			if (cellArea_0.EndColumn >= cellArea_1.EndColumn)
			{
				DeleteRows(bool_0, cellArea_0, int_0, cellArea3, arrayList_0, arrayList_1);
				return;
			}
			CellArea cellArea_3 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_0.StartColumn, cellArea_1.EndRow, cellArea_0.EndColumn);
			DeleteRows(bool_0, cellArea_0, int_0, cellArea_3, arrayList_0, arrayList_1);
			cellArea3.StartColumn = cellArea_0.EndColumn + 1;
			arrayList_0.Add(cellArea3);
		}
		else
		{
			arrayList_0.Add(cellArea_1);
		}
	}

	internal static ArrayList smethod_18(CellArea shiftArea, CellArea ca, out bool flag)
	{
		ArrayList arrayList = new ArrayList();
		if (shiftArea.StartColumn <= ca.EndColumn && shiftArea.EndColumn >= ca.StartColumn && shiftArea.StartRow <= ca.EndRow)
		{
			if (shiftArea.StartColumn <= ca.StartColumn)
			{
				if (shiftArea.EndColumn >= ca.EndColumn)
				{
					flag = true;
					return arrayList;
				}
				CellArea cellArea = default(CellArea);
				cellArea.StartColumn = ca.StartColumn;
				cellArea.EndColumn = shiftArea.EndColumn;
				cellArea.StartRow = ca.StartRow;
				cellArea.EndRow = ca.EndRow;
				arrayList.Add(cellArea);
				CellArea cellArea2 = default(CellArea);
				cellArea2.StartRow = ca.StartRow;
				cellArea2.EndRow = ca.EndRow;
				cellArea2.StartColumn = shiftArea.EndColumn + 1;
				cellArea2.EndColumn = ca.EndColumn;
				arrayList.Add(cellArea2);
				flag = true;
				return arrayList;
			}
			CellArea cellArea3 = default(CellArea);
			cellArea3.StartRow = ca.StartRow;
			cellArea3.EndRow = ca.EndRow;
			cellArea3.StartColumn = ca.StartColumn;
			cellArea3.EndColumn = shiftArea.StartColumn - 1;
			arrayList.Add(cellArea3);
			if (shiftArea.EndColumn >= ca.EndColumn)
			{
				CellArea cellArea4 = default(CellArea);
				cellArea4.StartColumn = shiftArea.StartColumn;
				cellArea4.EndColumn = ca.EndColumn;
				cellArea4.StartRow = ca.StartRow;
				cellArea4.EndRow = ca.EndRow;
				arrayList.Add(cellArea4);
				flag = true;
				return arrayList;
			}
			CellArea cellArea5 = default(CellArea);
			cellArea5.StartColumn = shiftArea.StartColumn;
			cellArea5.EndColumn = shiftArea.EndColumn;
			cellArea5.StartRow = ca.StartRow;
			cellArea5.EndRow = ca.EndRow;
			arrayList.Add(cellArea5);
			CellArea cellArea6 = default(CellArea);
			cellArea6.StartRow = ca.StartRow;
			cellArea6.EndRow = ca.EndRow;
			cellArea6.StartColumn = shiftArea.EndColumn + 1;
			cellArea6.EndColumn = ca.EndColumn;
			arrayList.Add(cellArea6);
			flag = true;
			return arrayList;
		}
		flag = false;
		return arrayList;
	}

	internal static void smethod_19(ArrayList arrayList_0, bool bool_0, CellArea cellArea_0, int int_0, ArrayList arrayList_1, ArrayList arrayList_2)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			smethod_22(bool_0, cellArea_0, int_0, (CellArea)arrayList_0[i], arrayList_1, arrayList_2);
		}
	}

	internal static void smethod_20(ArrayList arrayList_0, bool bool_0, CellArea cellArea_0, int int_0, ArrayList arrayList_1, ArrayList arrayList_2)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			smethod_21(bool_0, cellArea_0, int_0, (CellArea)arrayList_0[i], arrayList_1, arrayList_2);
		}
	}

	internal static void smethod_21(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartRow <= cellArea_1.EndRow && cellArea_0.EndRow >= cellArea_1.StartRow && cellArea_0.StartColumn <= cellArea_1.EndColumn)
		{
			if (bool_0)
			{
				if (cellArea_1.StartColumn == 0 && cellArea_1.EndColumn == 16383)
				{
					arrayList_0.Add(cellArea_1);
					return;
				}
			}
			else if (cellArea_1.StartColumn == 0 && cellArea_1.EndColumn == 255)
			{
				arrayList_0.Add(cellArea_1);
				return;
			}
			if (cellArea_0.StartRow <= cellArea_1.StartRow)
			{
				if (cellArea_0.EndRow >= cellArea_1.EndRow)
				{
					if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
					{
						cellArea_1.StartColumn += int_0;
						cellArea_1.EndColumn += int_0;
						arrayList_1.Add(cellArea_1);
					}
					else
					{
						cellArea_1.EndColumn += int_0;
						arrayList_0.Add(cellArea_1);
					}
				}
				else if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
				{
					CellArea cellArea = default(CellArea);
					cellArea.StartRow = cellArea_1.StartRow;
					cellArea.EndRow = cellArea_0.EndRow;
					cellArea.StartColumn = cellArea_1.StartColumn + int_0;
					cellArea.EndColumn = cellArea_1.EndColumn + int_0;
					arrayList_1.Add(cellArea);
					CellArea cellArea2 = default(CellArea);
					cellArea2.StartRow = cellArea_0.EndRow + 1;
					cellArea2.EndRow = cellArea_1.EndRow;
					cellArea2.StartColumn = cellArea_1.StartColumn;
					cellArea2.EndColumn = cellArea_1.EndColumn;
					arrayList_0.Add(cellArea2);
				}
				else
				{
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = cellArea_1.StartRow;
					cellArea3.EndRow = cellArea_0.EndRow;
					cellArea3.StartColumn = cellArea_1.StartColumn;
					cellArea3.EndColumn = cellArea_1.EndColumn + int_0;
					arrayList_0.Add(cellArea3);
					CellArea cellArea4 = default(CellArea);
					cellArea4.StartRow = cellArea_0.EndRow + 1;
					cellArea4.EndRow = cellArea_1.EndRow;
					cellArea4.StartColumn = cellArea_1.StartColumn;
					cellArea4.EndColumn = cellArea_1.EndColumn;
					arrayList_0.Add(cellArea4);
				}
				return;
			}
			CellArea cellArea5 = default(CellArea);
			cellArea5.StartColumn = cellArea_1.StartColumn;
			cellArea5.EndColumn = cellArea_1.EndColumn;
			cellArea5.StartRow = cellArea_1.StartRow;
			cellArea5.EndRow = cellArea_0.StartRow - 1;
			arrayList_0.Add(cellArea5);
			if (cellArea_0.EndRow >= cellArea_1.EndRow)
			{
				if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
				{
					CellArea cellArea6 = default(CellArea);
					cellArea6.StartRow = cellArea_0.StartRow;
					cellArea6.EndRow = cellArea_1.EndRow;
					cellArea6.StartColumn = cellArea_1.StartColumn + int_0;
					cellArea6.EndColumn = cellArea_1.EndColumn + int_0;
					arrayList_1.Add(cellArea6);
				}
				else
				{
					CellArea cellArea7 = default(CellArea);
					cellArea7.StartRow = cellArea_0.StartRow;
					cellArea7.EndRow = cellArea_1.EndRow;
					cellArea7.StartColumn = cellArea_1.StartColumn;
					cellArea7.EndColumn = cellArea_1.EndColumn + int_0;
					arrayList_0.Add(cellArea7);
				}
				return;
			}
			if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
			{
				CellArea cellArea8 = default(CellArea);
				cellArea8.StartRow = cellArea_0.StartRow;
				cellArea8.EndRow = cellArea_0.EndRow;
				cellArea8.StartColumn = cellArea_1.StartColumn + int_0;
				cellArea8.EndColumn = cellArea_1.EndColumn + int_0;
				arrayList_1.Add(cellArea8);
			}
			else
			{
				CellArea cellArea9 = default(CellArea);
				cellArea9.StartRow = cellArea_0.StartRow;
				cellArea9.EndRow = cellArea_0.EndRow;
				cellArea9.StartColumn = cellArea_1.StartColumn;
				cellArea9.EndColumn = cellArea_1.EndColumn + int_0;
				arrayList_0.Add(cellArea9);
			}
			CellArea cellArea10 = default(CellArea);
			cellArea10.StartColumn = cellArea_1.StartColumn;
			cellArea10.EndColumn = cellArea_1.EndColumn;
			cellArea10.StartRow = cellArea_0.EndRow + 1;
			cellArea10.EndRow = cellArea_1.EndRow;
			arrayList_0.Add(cellArea10);
		}
		else
		{
			arrayList_0.Add(cellArea_1);
		}
	}

	internal static void DeleteColumns(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartColumn <= cellArea_1.StartColumn)
		{
			if (cellArea_0.EndColumn < cellArea_1.StartColumn)
			{
				cellArea_1.StartColumn -= int_0;
				cellArea_1.EndColumn -= int_0;
				arrayList_1.Add(cellArea_1);
			}
			else if (cellArea_0.EndColumn < cellArea_1.EndColumn)
			{
				CellArea cellArea = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_0.EndColumn + 1, cellArea_1.EndRow, cellArea_1.EndColumn);
				cellArea.StartColumn -= int_0;
				cellArea.EndColumn -= int_0;
				arrayList_1.Add(cellArea);
			}
		}
		else if (cellArea_0.EndColumn < cellArea_1.EndColumn)
		{
			cellArea_1.EndColumn -= int_0;
			arrayList_1.Add(cellArea_1);
		}
		else
		{
			cellArea_1.EndColumn = cellArea_0.StartColumn - 1;
			arrayList_1.Add(cellArea_1);
		}
	}

	internal static void smethod_22(bool bool_0, CellArea cellArea_0, int int_0, CellArea cellArea_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		if (cellArea_0.StartRow <= cellArea_1.EndRow && cellArea_0.EndRow >= cellArea_1.StartRow && cellArea_0.StartColumn <= cellArea_1.EndColumn)
		{
			if (bool_0)
			{
				if (cellArea_1.StartColumn == 0 && cellArea_1.EndColumn == 16383)
				{
					arrayList_0.Add(cellArea_1);
					return;
				}
			}
			else if (cellArea_1.StartColumn == 0 && cellArea_1.EndColumn == 255)
			{
				arrayList_0.Add(cellArea_1);
				return;
			}
			if (cellArea_0.StartRow <= cellArea_1.StartRow)
			{
				if (cellArea_0.EndRow >= cellArea_1.EndRow)
				{
					DeleteColumns(bool_0, cellArea_0, int_0, cellArea_1, arrayList_0, arrayList_1);
					return;
				}
				CellArea cellArea_2 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_1.StartColumn, cellArea_0.EndRow, cellArea_1.EndColumn);
				DeleteColumns(bool_0, cellArea_0, int_0, cellArea_2, arrayList_0, arrayList_1);
				CellArea cellArea = CellArea.CreateCellArea(cellArea_0.EndRow + 1, cellArea_1.StartColumn, cellArea_1.EndRow, cellArea_1.EndColumn);
				arrayList_0.Add(cellArea);
				return;
			}
			CellArea cellArea2 = CellArea.CreateCellArea(cellArea_1.StartRow, cellArea_1.StartColumn, cellArea_0.StartRow - 1, cellArea_1.EndColumn);
			arrayList_0.Add(cellArea2);
			CellArea cellArea3 = CellArea.CreateCellArea(cellArea_0.StartRow, cellArea_1.StartColumn, cellArea_1.EndRow, cellArea_1.EndColumn);
			if (cellArea_0.EndRow >= cellArea_1.EndRow)
			{
				DeleteColumns(bool_0, cellArea_0, int_0, cellArea3, arrayList_0, arrayList_1);
				return;
			}
			CellArea cellArea_3 = CellArea.CreateCellArea(cellArea_0.StartRow, cellArea_1.StartColumn, cellArea_0.EndRow, cellArea_1.EndColumn);
			DeleteColumns(bool_0, cellArea_0, int_0, cellArea_3, arrayList_0, arrayList_1);
			cellArea3.StartRow = cellArea_0.EndRow + 1;
			arrayList_0.Add(cellArea3);
		}
		else
		{
			arrayList_0.Add(cellArea_1);
		}
	}
}
