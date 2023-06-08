using System.Text;
using Aspose.Cells;

namespace ns2;

internal class Class1281
{
	private CellArea cellArea_0;

	private ConsolidationFunction consolidationFunction_0;

	private int[] int_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private int int_1;

	private int int_2;

	private Cells cells_0;

	private RowCollection rowCollection_0;

	private int int_3;

	private string[] string_0;

	private string string_1 = "Total";

	private string string_2 = "Grand Total";

	internal Class1281(Cells cells_1)
	{
		cells_0 = cells_1;
		rowCollection_0 = cells_1.Rows;
		bool_3 = true;
	}

	internal void Subtotal(CellArea cellArea_1, int int_4, ConsolidationFunction consolidationFunction_1, int[] int_5, bool bool_4, bool bool_5, bool bool_6)
	{
		cellArea_0 = cellArea_1;
		int_2 = int_4;
		consolidationFunction_0 = consolidationFunction_1;
		int_0 = int_5;
		bool_0 = bool_4;
		bool_1 = bool_5;
		bool_2 = bool_6;
		string_1 = Class1130.smethod_9(consolidationFunction_1, cells_0.method_19().Workbook.Settings);
		string_2 = "Grand " + string_1;
		int_3 = cellArea_1.StartColumn + int_4;
		bool flag = false;
		for (int num = int_5.Length - 1; num >= 0; num--)
		{
			if (int_5[num] == int_4)
			{
				flag = true;
			}
		}
		if (flag)
		{
			flag = false;
			int num2 = int_4 - 1;
			while (num2 >= 0)
			{
				flag = true;
				int num3 = int_5.Length - 1;
				while (num3 >= 0)
				{
					if (int_5[num3] != num2)
					{
						num3--;
						continue;
					}
					flag = false;
					break;
				}
				if (!flag)
				{
					num2--;
					continue;
				}
				int_3 = cellArea_1.StartColumn + num2;
				break;
			}
			if (!flag)
			{
				int_3 = cellArea_1.StartColumn;
				cells_0.InsertColumn(cellArea_1.StartColumn);
				cellArea_1.StartColumn++;
				cellArea_1.EndColumn++;
			}
		}
		string_0 = new string[int_5.Length];
		for (int i = 0; i < int_5.Length; i++)
		{
			string_0[i] = CellsHelper.ColumnIndexToName(int_5[i] + cellArea_1.StartColumn);
			int_5[i] += cellArea_1.StartColumn;
		}
		int_1 = cellArea_1.StartRow;
		for (int_1 = cellArea_1.StartRow; int_1 <= cellArea_1.EndRow; int_1++)
		{
			int num4 = cells_0.HPageBreaks.method_1(int_1 + 1);
			if (num4 != -1)
			{
				cells_0.HPageBreaks.RemoveAt(num4);
			}
		}
		int_2 = cellArea_1.StartColumn + int_4;
		if (bool_4)
		{
			bool flag2 = false;
			for (int_1 = cellArea_1.StartRow; int_1 <= cellArea_1.EndRow; int_1++)
			{
				Row row = rowCollection_0.GetRow(int_1, bool_0: true, bool_1: false);
				if (row != null)
				{
					if (row.method_24() != 0)
					{
						row.method_25(0);
						flag2 = true;
					}
					for (int j = 0; j < int_5.Length; j++)
					{
						Cell cellOrNull = row.GetCellOrNull(int_5[j]);
						if (cellOrNull != null && cellOrNull.IsFormula && cellOrNull.Formula.StartsWith("=SUBTOTAL("))
						{
							cells_0.DeleteRow(int_1--);
							cellArea_1.EndRow--;
							break;
						}
					}
				}
			}
			if (flag2)
			{
				int num5 = 0;
				for (int k = 0; k < rowCollection_0.Count; k++)
				{
					Row rowByIndex = rowCollection_0.GetRowByIndex(k);
					if (rowByIndex.int_0 >= cellArea_1.StartRow)
					{
						if (rowByIndex.int_0 > cellArea_1.EndRow)
						{
							break;
						}
						if (rowByIndex.method_24() > num5)
						{
							num5 = rowByIndex.method_24();
						}
					}
				}
				cells_0.method_30((byte)num5);
			}
		}
		else
		{
			bool_6 = !method_1(cellArea_1.StartRow);
		}
		if (bool_6)
		{
			method_3();
		}
		else
		{
			method_4();
		}
	}

	private int method_0(Row row_0)
	{
		int num = -1;
		int num2 = cellArea_0.StartColumn;
		while (true)
		{
			if (num2 <= cellArea_0.EndColumn)
			{
				Cell cellOrNull = row_0.GetCellOrNull(num2);
				if (cellOrNull != null && !cellOrNull.IsBlank)
				{
					if (!cellOrNull.IsFormula && num == -1)
					{
						num = num2;
					}
					if (cellOrNull.IsFormula && cellOrNull.Formula.StartsWith("=SUBTOTAL("))
					{
						break;
					}
				}
				num2++;
				continue;
			}
			return -1;
		}
		return num;
	}

	private bool method_1(int int_4)
	{
		Row row = cells_0.Rows.GetRow(int_4, bool_0: true, bool_1: false);
		if (row == null)
		{
			return false;
		}
		int num = cellArea_0.StartColumn;
		while (true)
		{
			if (num <= cellArea_0.EndColumn)
			{
				Cell cellOrNull = row.GetCellOrNull(num);
				if (cellOrNull != null && cellOrNull.IsFormula && cellOrNull.Formula.StartsWith("=SUBTOTAL("))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private bool method_2(Row row_0)
	{
		int num = cellArea_0.StartColumn;
		while (true)
		{
			if (num <= cellArea_0.EndColumn)
			{
				Cell cellOrNull = row_0.GetCellOrNull(num);
				if (cellOrNull != null && cellOrNull.IsFormula && cellOrNull.Formula.StartsWith("=SUBTOTAL("))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_3()
	{
		bool flag = false;
		int num = -1;
		string text = "";
		int num2 = -1;
		int num3 = Class1130.smethod_7(consolidationFunction_0);
		string value = "=SUBTOTAL(" + num3 + ",";
		Cell cell = null;
		Style style = new Style(cells_0.method_19());
		style.Font.IsBold = true;
		style.IsTextWrapped = true;
		int num4 = cells_0.method_19().method_59(style);
		int num5 = -1;
		for (int_1 = cellArea_0.StartRow; int_1 <= cellArea_0.EndRow; int_1++)
		{
			bool flag2 = false;
			Row row = rowCollection_0.GetRow(int_1, bool_0: true, bool_1: false);
			if (row == null)
			{
				continue;
			}
			Cell cellOrNull = row.GetCellOrNull(int_2);
			if (cellOrNull == null || cellOrNull.Type == CellValueType.IsNull)
			{
				if (bool_0)
				{
					continue;
				}
				if (cellArea_0.EndRow == int_1)
				{
					flag = true;
				}
				else
				{
					num5 = method_0(row);
					if (num5 != -1)
					{
						num = int_1;
						flag2 = true;
					}
					if (!flag2)
					{
						continue;
					}
				}
			}
			if (!flag2)
			{
				string stringValue = cellOrNull.StringValue;
				if (num2 == -1)
				{
					text = stringValue;
					num2 = ((int_1 > cellArea_0.StartRow) ? cellArea_0.StartRow : int_1);
					continue;
				}
				if (string.Compare(stringValue, text, ignoreCase: true) == 0 || num2 + 1 > int_1)
				{
					text = stringValue;
					continue;
				}
				if (!bool_0 && method_1(int_1))
				{
					if (num == -1)
					{
						num = int_1 + 1;
					}
					if (int_1 != cellArea_0.EndRow)
					{
						continue;
					}
					flag = true;
				}
			}
			cells_0.InsertRow(int_1);
			cellArea_0.EndRow++;
			for (int i = 0; i < int_0.Length; i++)
			{
				StringBuilder stringBuilder = new StringBuilder(value);
				stringBuilder.Append(string_0[i]);
				stringBuilder.Append(num2 + 1);
				stringBuilder.Append(':');
				stringBuilder.Append(string_0[i]);
				stringBuilder.Append(int_1);
				stringBuilder.Append(')');
				cells_0.GetCell(int_1, int_0[i], bool_2: false).Formula = stringBuilder.ToString();
			}
			cell = cells_0.GetCell(int_1, int_3, bool_2: false);
			cell.PutValue(text + " " + string_1);
			cell.method_37(num4);
			if (bool_3)
			{
				if (num != -1)
				{
					cells_0.GroupRows(num2, num - 1, isHidden: false);
				}
				else
				{
					cells_0.GroupRows(num2, int_1 - 1, isHidden: false);
				}
			}
			if (bool_1 && !flag)
			{
				cells_0.HPageBreaks.Add(int_1 + 1, 0);
			}
			text = cellOrNull.StringValue;
			if (num != -1)
			{
				int_1++;
				num2 = int_1 + 1;
				int_1++;
				while (int_1 < cellArea_0.EndRow)
				{
					row = cells_0.Rows.GetRow(int_1, bool_0: true, bool_1: false);
					if (row != null && method_2(row))
					{
						int_1++;
						continue;
					}
					num2 = int_1;
					break;
				}
				if (int_1 == cellArea_0.EndRow)
				{
					flag = true;
				}
				else
				{
					int_1--;
				}
			}
			else
			{
				int_1++;
				num2 = int_1;
			}
			num = -1;
			if (flag)
			{
				break;
			}
		}
		if (!flag && num2 != -1)
		{
			cells_0.InsertRows(int_1, 1);
			cell = cells_0.GetCell(int_1, int_3, bool_2: false);
			cell.PutValue(text + " " + string_1);
			cell.method_37(num4);
			if (bool_3)
			{
				cells_0.GroupRows(num2, int_1 - 1, isHidden: false);
			}
			for (int j = 0; j < int_0.Length; j++)
			{
				StringBuilder stringBuilder2 = new StringBuilder(value);
				stringBuilder2.Append(string_0[j]);
				stringBuilder2.Append(num2 + 1);
				stringBuilder2.Append(':');
				stringBuilder2.Append(string_0[j]);
				stringBuilder2.Append(int_1);
				stringBuilder2.Append(')');
				cells_0.GetCell(int_1, int_0[j], bool_2: false).Formula = stringBuilder2.ToString();
			}
			int_1++;
			if (bool_0)
			{
				cells_0.InsertRows(int_1, 1);
				cell = cells_0.GetCell(int_1, int_3, bool_2: false);
				cell.PutValue(string_2);
				cell.method_37(num4);
				for (int k = 0; k < int_0.Length; k++)
				{
					StringBuilder stringBuilder3 = new StringBuilder(value);
					stringBuilder3.Append(string_0[k]);
					stringBuilder3.Append(cellArea_0.StartRow + 1);
					stringBuilder3.Append(':');
					stringBuilder3.Append(string_0[k]);
					stringBuilder3.Append(cellArea_0.EndRow + 1);
					stringBuilder3.Append(')');
					cells_0.GetCell(int_1, int_0[k], bool_2: false).Formula = stringBuilder3.ToString();
				}
			}
		}
		if (bool_3 && !flag)
		{
			cells_0.GroupRows(cellArea_0.StartRow, int_1 - 1, isHidden: false);
		}
		cells_0.HPageBreaks.Add(int_1 + 1, 0);
	}

	private void method_4()
	{
		bool flag = false;
		int num = -1;
		string text = "";
		int num2 = -1;
		int num3 = Class1130.smethod_7(consolidationFunction_0);
		string value = "=SUBTOTAL(" + num3 + ",";
		Cell cell = null;
		Style style = new Style(cells_0.method_19());
		style.Font.IsBold = true;
		style.IsTextWrapped = true;
		int num4 = cells_0.method_19().method_59(style);
		for (int_1 = cellArea_0.EndRow; int_1 >= cellArea_0.StartRow; int_1--)
		{
			Cell cell2 = cells_0.Rows.GetCell(int_1, int_2, bool_0: true, bool_1: false, bool_2: false);
			if (cell2 == null || cell2.Type == CellValueType.IsNull)
			{
				continue;
			}
			string stringValue = cell2.StringValue;
			if (num2 == -1)
			{
				text = stringValue;
				num2 = ((int_1 < cellArea_0.EndRow) ? cellArea_0.EndRow : int_1);
			}
			else
			{
				if (stringValue == text)
				{
					continue;
				}
				if (!bool_0)
				{
					Row row = cells_0.Rows.GetRow(int_1, bool_0: true, bool_1: false);
					bool flag2 = false;
					for (int i = 0; i < int_0.Length; i++)
					{
						cell2 = row.GetCellOrNull(int_0[i]);
						if (cell2 != null && cell2.IsFormula && cell2.Formula.StartsWith("=SUBTOTAL("))
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						if (num == -1)
						{
							num = int_1;
						}
						if (bool_2 || int_1 != cellArea_0.StartRow)
						{
							continue;
						}
						flag = true;
					}
				}
				int num5 = int_1 + 1;
				num2++;
				cells_0.InsertRow(num5);
				cellArea_0.EndRow++;
				for (int j = 0; j < int_0.Length; j++)
				{
					StringBuilder stringBuilder = new StringBuilder(value);
					stringBuilder.Append(string_0[j]);
					stringBuilder.Append(num5 + 2);
					stringBuilder.Append(':');
					stringBuilder.Append(string_0[j]);
					stringBuilder.Append(num2 + 1);
					stringBuilder.Append(')');
					cells_0.GetCell(num5, int_0[j], bool_2: false).Formula = stringBuilder.ToString();
				}
				cell = cells_0.GetCell(num5, int_3, bool_2: false);
				cell.PutValue(text + " " + string_1);
				cell.method_37(num4);
				if (bool_3)
				{
					if (num != -1)
					{
						cells_0.GroupRows(num + 2, num2, isHidden: false);
					}
					else
					{
						cells_0.GroupRows(num5 + 1, num2, isHidden: false);
					}
				}
				num = -1;
				if (bool_1 && !flag)
				{
					cells_0.HPageBreaks.Add(num2 + 1, 0);
				}
				text = stringValue;
				num2 = int_1;
				if (flag)
				{
					break;
				}
			}
		}
		int_1++;
		if (!flag)
		{
			num2++;
			cells_0.InsertRows(int_1, 1);
			cellArea_0.EndRow++;
			cell = cells_0.GetCell(int_1, int_3, bool_2: false);
			cell.PutValue(text + " " + string_1);
			cell.method_37(num4);
			if (bool_3)
			{
				cells_0.GroupRows(int_1 + 1, num2, isHidden: false);
			}
			for (int k = 0; k < int_0.Length; k++)
			{
				StringBuilder stringBuilder2 = new StringBuilder(value);
				stringBuilder2.Append(string_0[k]);
				stringBuilder2.Append(int_1 + 2);
				stringBuilder2.Append(':');
				stringBuilder2.Append(string_0[k]);
				stringBuilder2.Append(num2 + 1);
				stringBuilder2.Append(')');
				cells_0.GetCell(int_1, int_0[k], bool_2: false).Formula = stringBuilder2.ToString();
			}
			if (bool_0)
			{
				cells_0.InsertRows(int_1, 1);
				cellArea_0.EndRow++;
				cell = cells_0.GetCell(int_1, int_3, bool_2: false);
				cell.PutValue(string_2);
				cell.method_37(num4);
				for (int l = 0; l < int_0.Length; l++)
				{
					StringBuilder stringBuilder3 = new StringBuilder(value);
					stringBuilder3.Append(string_0[l]);
					stringBuilder3.Append(cellArea_0.StartRow + 2);
					stringBuilder3.Append(':');
					stringBuilder3.Append(string_0[l]);
					stringBuilder3.Append(cellArea_0.EndRow + 1);
					stringBuilder3.Append(')');
					cells_0.GetCell(int_1, int_0[l], bool_2: false).Formula = stringBuilder3.ToString();
				}
			}
		}
		if (bool_3)
		{
			cells_0.GroupRows(cellArea_0.StartRow + 1, cellArea_0.EndRow, isHidden: false);
		}
		cells_0.HPageBreaks.Add(num2 + 1, 0);
	}
}
