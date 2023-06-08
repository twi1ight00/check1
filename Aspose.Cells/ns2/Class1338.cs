using System;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns29;

namespace ns2;

internal class Class1338
{
	private Cells cells_0;

	private FindOptions findOptions_0;

	private object object_0;

	private bool bool_0;

	private bool bool_1;

	private double double_0;

	private string string_0;

	private Regex regex_0;

	private bool bool_2;

	private Cell cell_0;

	internal Class1338(Cells cells_1, FindOptions findOptions_1)
	{
		cells_0 = cells_1;
		findOptions_0 = findOptions_1;
	}

	internal Cell Find(object object_1, Cell cell_1)
	{
		object_0 = object_1;
		cell_0 = cell_1;
		if (findOptions_0.RegexKey)
		{
			string text = object_1.ToString();
			if (regex_0 == null || !text.Equals(string_0))
			{
				string_0 = text;
				regex_0 = new Regex(string_0, findOptions_0.CaseSensitive ? RegexOptions.Compiled : (RegexOptions.IgnoreCase | RegexOptions.Compiled));
			}
		}
		else
		{
			string_0 = object_1.ToString();
			bool_2 = string_0.IndexOfAny(new char[2] { '?', '*' }) != -1;
			if (!findOptions_0.CaseSensitive && object_1 != null)
			{
				string_0 = string_0.ToUpper();
			}
		}
		switch (Type.GetTypeCode(object_1.GetType()))
		{
		case TypeCode.Double:
			bool_0 = true;
			double_0 = (double)object_1;
			break;
		case TypeCode.DateTime:
			bool_1 = true;
			double_0 = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, cells_0.method_19().Workbook.Settings.Date1904);
			break;
		case TypeCode.Int32:
			bool_0 = true;
			double_0 = (int)object_1;
			break;
		}
		if (findOptions_0.LookInType == LookInType.Comments)
		{
			CommentCollection comments = cells_0.method_3().Comments;
			for (int i = 0; i < comments.Count; i++)
			{
				Comment comment = comments[i];
				cells_0.GetCell(comment.Row, comment.Column, bool_2: false);
			}
		}
		if (findOptions_0.SeachOrderByRows)
		{
			if (findOptions_0.method_0())
			{
				return method_1(findOptions_0.GetRange());
			}
			return method_0();
		}
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartColumn = cells_0.MinColumn;
		cellArea_.EndColumn = cells_0.method_22(0);
		cellArea_.StartRow = cells_0.MinRow;
		cellArea_.EndRow = cells_0.method_20(0);
		if (findOptions_0.method_0())
		{
			CellArea range = findOptions_0.GetRange();
			if (cellArea_.StartColumn < range.StartColumn)
			{
				cellArea_.StartColumn = range.StartColumn;
			}
			if (cellArea_.EndColumn > range.EndColumn)
			{
				cellArea_.EndColumn = range.EndColumn;
			}
			if (cellArea_.StartColumn > cellArea_.EndColumn)
			{
				return null;
			}
			if (cellArea_.StartRow < range.StartRow)
			{
				cellArea_.StartRow = range.StartRow;
			}
			if (cellArea_.EndRow > range.EndRow)
			{
				cellArea_.EndRow = range.EndRow;
			}
			if (cellArea_.StartRow > cellArea_.EndRow)
			{
				return null;
			}
		}
		return method_2(cellArea_);
	}

	private Cell method_0()
	{
		if (findOptions_0.SearchNext)
		{
			if (cell_0 == null)
			{
				for (int i = 0; i < cells_0.Rows.Count; i++)
				{
					Row rowByIndex = cells_0.Rows.GetRowByIndex(i);
					for (int j = 0; j < rowByIndex.method_0(); j++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(j);
						if (Compare(cellByIndex))
						{
							return cellByIndex;
						}
					}
				}
			}
			else
			{
				int arrRowIndex = -1;
				int arrColumnIndex = -1;
				cells_0.Rows.method_13(cell_0.Row, cell_0.Column, out arrRowIndex, out arrColumnIndex);
				for (int k = arrRowIndex; k < cells_0.Rows.Count; k++)
				{
					Row rowByIndex2 = cells_0.Rows.GetRowByIndex(k);
					for (int l = ((k == arrRowIndex) ? (arrColumnIndex + 1) : 0); l < rowByIndex2.method_0(); l++)
					{
						Cell cellByIndex2 = rowByIndex2.GetCellByIndex(l);
						if (Compare(cellByIndex2))
						{
							return cellByIndex2;
						}
					}
				}
			}
		}
		else if (cell_0 == null)
		{
			for (int num = cells_0.Rows.Count - 1; num >= 0; num--)
			{
				Row rowByIndex3 = cells_0.Rows.GetRowByIndex(num);
				int num2 = rowByIndex3.method_0() - 1;
				while (num2 >= 0)
				{
					Cell cellByIndex3 = rowByIndex3.GetCellByIndex(num2);
					if (!Compare(cellByIndex3))
					{
						num2--;
						continue;
					}
					return cellByIndex3;
				}
			}
		}
		else
		{
			int arrRowIndex2 = -1;
			int arrColumnIndex2 = -1;
			cells_0.Rows.method_13(cell_0.Row, cell_0.Column, out arrRowIndex2, out arrColumnIndex2);
			for (int num3 = arrRowIndex2; num3 >= 0; num3--)
			{
				Row rowByIndex4 = cells_0.Rows.GetRowByIndex(num3);
				int num4 = ((num3 == arrRowIndex2) ? (arrColumnIndex2 - 1) : (rowByIndex4.method_0() - 1));
				while (num4 >= 0)
				{
					Cell cellByIndex4 = rowByIndex4.GetCellByIndex(num4);
					if (!Compare(cellByIndex4))
					{
						num4--;
						continue;
					}
					return cellByIndex4;
				}
			}
		}
		return null;
	}

	private Cell method_1(CellArea cellArea_0)
	{
		if (findOptions_0.SearchNext)
		{
			if (cell_0 == null)
			{
				for (int i = 0; i < cells_0.Rows.Count; i++)
				{
					Row rowByIndex = cells_0.Rows.GetRowByIndex(i);
					if (rowByIndex.int_0 < cellArea_0.StartRow)
					{
						continue;
					}
					if (rowByIndex.int_0 > cellArea_0.EndRow)
					{
						break;
					}
					for (int j = 0; j < rowByIndex.method_0(); j++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(j);
						if (cellByIndex.Column >= cellArea_0.StartColumn)
						{
							if (cellByIndex.Column > cellArea_0.EndColumn)
							{
								break;
							}
							if (Compare(cellByIndex))
							{
								return cellByIndex;
							}
						}
					}
				}
			}
			else
			{
				int arrRowIndex = -1;
				int arrColumnIndex = -1;
				cells_0.Rows.method_13(cell_0.Row, cell_0.Column, out arrRowIndex, out arrColumnIndex);
				for (int k = arrRowIndex; k < cells_0.Rows.Count; k++)
				{
					Row rowByIndex2 = cells_0.Rows.GetRowByIndex(k);
					if (rowByIndex2.int_0 < cellArea_0.StartRow)
					{
						continue;
					}
					if (rowByIndex2.int_0 > cellArea_0.EndRow)
					{
						break;
					}
					for (int l = ((k == arrRowIndex) ? (arrColumnIndex + 1) : 0); l < rowByIndex2.method_0(); l++)
					{
						Cell cellByIndex2 = rowByIndex2.GetCellByIndex(l);
						if (cellByIndex2.Column >= cellArea_0.StartColumn)
						{
							if (cellByIndex2.Column > cellArea_0.EndColumn)
							{
								break;
							}
							if (Compare(cellByIndex2))
							{
								return cellByIndex2;
							}
						}
					}
				}
			}
		}
		else if (cell_0 == null)
		{
			for (int num = cells_0.Rows.Count - 1; num >= 0; num--)
			{
				Row rowByIndex3 = cells_0.Rows.GetRowByIndex(num);
				if (rowByIndex3.int_0 <= cellArea_0.EndRow)
				{
					if (rowByIndex3.int_0 < cellArea_0.StartRow)
					{
						break;
					}
					for (int num2 = rowByIndex3.method_0() - 1; num2 >= 0; num2--)
					{
						Cell cellByIndex3 = rowByIndex3.GetCellByIndex(num2);
						if (cellByIndex3.Column <= cellArea_0.EndColumn)
						{
							if (cellByIndex3.Column < cellArea_0.StartColumn)
							{
								break;
							}
							if (Compare(cellByIndex3))
							{
								return cellByIndex3;
							}
						}
					}
				}
			}
		}
		else
		{
			int arrRowIndex2 = -1;
			int arrColumnIndex2 = -1;
			cells_0.Rows.method_13(cell_0.Row, cell_0.Column, out arrRowIndex2, out arrColumnIndex2);
			for (int num3 = arrRowIndex2; num3 >= 0; num3--)
			{
				Row rowByIndex4 = cells_0.Rows.GetRowByIndex(num3);
				if (rowByIndex4.int_0 <= cellArea_0.EndRow)
				{
					if (rowByIndex4.int_0 < cellArea_0.StartRow)
					{
						break;
					}
					for (int num4 = ((num3 == arrRowIndex2) ? (arrColumnIndex2 - 1) : (rowByIndex4.method_0() - 1)); num4 >= 0; num4--)
					{
						Cell cellByIndex4 = rowByIndex4.GetCellByIndex(num4);
						if (cellByIndex4.Column <= cellArea_0.EndColumn)
						{
							if (cellByIndex4.Column < cellArea_0.StartColumn)
							{
								break;
							}
							if (Compare(cellByIndex4))
							{
								return cellByIndex4;
							}
						}
					}
				}
			}
		}
		return null;
	}

	private Cell method_2(CellArea cellArea_0)
	{
		Cell cell = null;
		if (findOptions_0.SearchNext)
		{
			if (cell_0 != null)
			{
				int row = cell_0.Row;
				int column = cell_0.Column;
				if (column > cellArea_0.EndColumn)
				{
					return null;
				}
				int i = cellArea_0.StartColumn;
				if (column > cellArea_0.StartColumn)
				{
					i = column;
				}
				for (; i <= cellArea_0.EndColumn; i++)
				{
					int j = cellArea_0.StartRow;
					if (i == column && row >= cellArea_0.StartRow)
					{
						j = row + 1;
					}
					for (; j <= cellArea_0.EndRow; j++)
					{
						cell = cells_0.CheckCell(j, i);
						if (cell != null && Compare(cell))
						{
							return cell;
						}
					}
				}
			}
			else
			{
				for (int k = cellArea_0.StartColumn; k <= cellArea_0.EndColumn; k++)
				{
					for (int l = cellArea_0.StartRow; l <= cellArea_0.EndRow; l++)
					{
						cell = cells_0.CheckCell(l, k);
						if (cell != null && Compare(cell))
						{
							return cell;
						}
					}
				}
			}
		}
		else if (cell_0 != null)
		{
			int row2 = cell_0.Row;
			int column2 = cell_0.Column;
			if (column2 < cellArea_0.StartColumn)
			{
				return null;
			}
			int num = cellArea_0.EndColumn;
			if (column2 < cellArea_0.EndColumn)
			{
				num = column2;
			}
			while (num >= cellArea_0.StartColumn)
			{
				int num2 = cellArea_0.EndRow;
				if (num == column2 && row2 <= cellArea_0.EndRow)
				{
					num2 = row2 - 1;
				}
				while (num2 >= cellArea_0.StartRow)
				{
					cell = cells_0.CheckCell(num2, num);
					if (cell == null || !Compare(cell))
					{
						num2--;
						continue;
					}
					return cell;
				}
				num--;
			}
		}
		else
		{
			for (int num3 = cellArea_0.EndColumn; num3 >= cellArea_0.StartColumn; num3--)
			{
				int num4 = cellArea_0.EndRow;
				while (num4 >= cellArea_0.StartRow)
				{
					cell = cells_0.CheckCell(num4, num3);
					if (cell == null || !Compare(cell))
					{
						num4--;
						continue;
					}
					return cell;
				}
			}
		}
		return null;
	}

	private bool Compare(Cell cell_1)
	{
		switch (findOptions_0.LookInType)
		{
		default:
			return false;
		case LookInType.Formulas:
			if (cell_1.IsBlank)
			{
				return false;
			}
			if (cell_1.IsFormula)
			{
				return method_3(cell_1.Formula, bool_3: false);
			}
			return method_4(cell_1);
		case LookInType.Values:
			if (cell_1.IsBlank)
			{
				return false;
			}
			return method_4(cell_1);
		case LookInType.ValuesExcludeFormulaCell:
			if (!cell_1.IsFormula && !cell_1.IsBlank)
			{
				return method_4(cell_1);
			}
			return false;
		case LookInType.Comments:
		{
			Comment comment = cell_1.Comment;
			if (comment == null)
			{
				return false;
			}
			return method_3(comment.Note, bool_3: true);
		}
		case LookInType.OnlyFormulas:
			if (cell_1.IsFormula)
			{
				return method_3(cell_1.Formula, bool_3: false);
			}
			return false;
		}
	}

	private bool method_3(string string_1, bool bool_3)
	{
		if (!findOptions_0.CaseSensitive)
		{
			string_1 = string_1.ToUpper();
		}
		switch (findOptions_0.LookAtType)
		{
		default:
			return false;
		case LookAtType.Contains:
			return string_1.IndexOf(string_0) != -1;
		case LookAtType.StartWith:
			return string_1.StartsWith(string_0);
		case LookAtType.EndWith:
			return string_1.EndsWith(string_0);
		case LookAtType.EntireContent:
			if (findOptions_0.RegexKey)
			{
				return regex_0.IsMatch(string_1);
			}
			if (bool_2)
			{
				return Class1679.smethod_4(string_0, string_1, !findOptions_0.CaseSensitive) == 0;
			}
			return string_1 == string_0;
		}
	}

	private bool method_4(Cell cell_1)
	{
		switch (cell_1.Type)
		{
		case CellValueType.IsNumeric:
			if (bool_0)
			{
				if (findOptions_0.LookAtType == LookAtType.EntireContent)
				{
					return Math.Abs(cell_1.DoubleValue - double_0) <= double.Epsilon;
				}
				return method_3(cell_1.DoubleValue.ToString(), bool_3: true);
			}
			return method_3(cell_1.StringValue, bool_3: true);
		default:
			return method_3(cell_1.StringValue, bool_3: true);
		case CellValueType.IsDateTime:
			if (bool_1)
			{
				return Math.Abs(cell_1.DoubleValue - double_0) <= double.Epsilon;
			}
			return method_3(cell_1.StringValue, bool_3: true);
		}
	}
}
