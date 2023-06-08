using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells.Tables;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a range of cells within a spreadsheet.
///       </summary>
public class Range
{
	private Cells cells_0;

	private string string_0;

	private CellArea cellArea_0;

	/// <summary>
	///       Gets the count of rows in the range.
	///       </summary>
	public int RowCount => cellArea_0.EndRow - cellArea_0.StartRow + 1;

	/// <summary>
	///       Gets the count of columns in the range.
	///       </summary>
	public int ColumnCount => cellArea_0.EndColumn - cellArea_0.StartColumn + 1;

	/// <summary>
	///       Gets or sets the name of the range.
	///       </summary>
	/// <remarks>Named range is supported. For example,
	///       <p>range.Name = "Sheet1!MyRange";</p></remarks>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string text = value.Trim();
			if (text.Length > 255)
			{
				text = text.Substring(0, 255);
			}
			string_0 = text;
			int index = cells_0.method_19().Names.Add(string_0);
			Name name = cells_0.method_19().Names[index];
			name.SetRange(cells_0.method_3().Index, cellArea_0);
		}
	}

	/// <summary>
	///       Gets the range's refers to.
	///       </summary>
	public string RefersTo
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("=");
			string text = cells_0.method_3().Name;
			if (Class1677.smethod_21(text))
			{
				text = "'" + text + "'";
			}
			stringBuilder.Append(text);
			stringBuilder.Append("!");
			stringBuilder.Append("$");
			stringBuilder.Append(CellsHelper.ColumnIndexToName(Area.StartColumn));
			stringBuilder.Append("$");
			stringBuilder.Append(Area.StartRow + 1);
			if (Area.StartRow != Area.EndRow || Area.StartColumn != Area.EndColumn)
			{
				stringBuilder.Append(":");
				stringBuilder.Append("$");
				stringBuilder.Append(CellsHelper.ColumnIndexToName(Area.EndColumn));
				stringBuilder.Append("$");
				stringBuilder.Append(Area.EndRow + 1);
			}
			return stringBuilder.ToString();
		}
	}

	/// <summary>
	///       Gets the index of the first row of the range.
	///       </summary>
	public int FirstRow => cellArea_0.StartRow;

	/// <summary>
	///       Gets the index of the first column of the range.
	///       </summary>
	public int FirstColumn => cellArea_0.StartColumn;

	/// <summary>
	///       Gets and sets the value of the range.
	///       </summary>
	/// <remarks>
	///       If the range contains multiple cells, return a two-dimension <see cref="T:System.Array" /> object.
	///       If applies object array to the range, it should be a two-dimension <see cref="T:System.Array" /> object.
	///       </remarks>
	public object Value
	{
		get
		{
			if (Area.StartRow == Area.EndRow && Area.StartColumn == Area.EndColumn)
			{
				return cells_0.CheckCell(Area.StartRow, Area.StartColumn)?.Value;
			}
			return cells_0.ExportArray(Area.StartRow, Area.StartColumn, Area.EndRow - Area.StartRow + 1, Area.EndColumn - Area.StartColumn + 1);
		}
		set
		{
			CellArea cellArea = cellArea_0;
			if (value != null && value is Array)
			{
				Array array = (Array)value;
				if (array.Length == 0)
				{
					return;
				}
				int num = 1;
				switch (array.Rank)
				{
				case 1:
				{
					object value2 = array.GetValue(0);
					if (value2 is Array)
					{
						int length3 = ((Array)value2).Length;
						for (int k = 0; k < array.Length; k++)
						{
							Array array2 = (Array)array.GetValue(k);
							for (int l = 0; l < length3; l++)
							{
								Cell cell2 = cells_0.GetCell(k + cellArea.StartRow, l + cellArea.StartColumn, bool_2: false);
								cell2.PutValue(array2.GetValue(l));
							}
						}
					}
					else
					{
						for (int m = 0; m < array.Length; m++)
						{
							Cell cell3 = cells_0.GetCell(cellArea.StartRow, m + cellArea.StartColumn, bool_2: false);
							cell3.PutValue(array.GetValue(m));
						}
					}
					break;
				}
				case 2:
				{
					int length = array.GetLength(0);
					int length2 = array.GetLength(1);
					for (int i = 0; i < length; i++)
					{
						for (int j = 0; j < length2; j++)
						{
							Cell cell = cells_0.GetCell(i + cellArea.StartRow, j + cellArea.StartColumn, bool_2: false);
							cell.PutValue(array.GetValue(i, j));
						}
					}
					break;
				}
				}
				return;
			}
			for (int n = cellArea.StartRow; n <= cellArea.EndRow; n++)
			{
				for (int num2 = cellArea.StartColumn; num2 <= cellArea.EndColumn; num2++)
				{
					Cell cell4 = cells_0.GetCell(n, num2, bool_2: false);
					cell4.PutValue(value);
				}
			}
		}
	}

	/// <summary>
	///        Sets or gets the column width of this range
	///       </summary>
	public double ColumnWidth
	{
		get
		{
			return cells_0.GetColumnWidth(FirstColumn);
		}
		set
		{
			if (ColumnCount < 16384)
			{
				CellArea cellArea = cellArea_0;
				for (int i = cellArea.StartColumn; i <= cellArea.EndColumn; i++)
				{
					cells_0.SetColumnWidth(i, value);
				}
			}
			else
			{
				cells_0.method_8(value);
			}
		}
	}

	/// <summary>
	///       Sets or gets the height of rows in this range
	///       </summary>
	public double RowHeight
	{
		get
		{
			return cells_0.GetRowHeight(FirstRow);
		}
		set
		{
			if (!(value < 0.0) && value <= 409.0)
			{
				if (RowCount < 1048576)
				{
					CellArea cellArea = cellArea_0;
					for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
					{
						cells_0.SetRowHeight(i, value);
					}
				}
				else
				{
					cells_0.StandardHeight = value;
				}
				return;
			}
			throw new ArgumentOutOfRangeException();
		}
	}

	/// <summary>
	///       Gets <see cref="T:Aspose.Cells.Cell" /> object in this range.
	///       </summary>
	/// <param name="rowIndex">Row index in this range, zero based.</param>
	/// <param name="columnIndex">Column index in this range, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Cell" /> object.</returns>
	public Cell this[int rowIndex, int columnIndex]
	{
		get
		{
			if (rowIndex < 0 || rowIndex >= RowCount || columnIndex < 0 || columnIndex >= ColumnCount)
			{
				throw new CellsException(ExceptionType.InvalidData, "Row or column is out of the range.");
			}
			return cells_0.GetCell(FirstRow + rowIndex, FirstColumn + columnIndex, bool_2: false);
		}
	}

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Range.Worksheet" />object which contains this range.
	///       </summary>
	public Worksheet Worksheet => cells_0.method_3();

	internal CellArea Area => cellArea_0;

	/// <summary>
	///       Gets the cells enumerator
	///       </summary>
	/// <returns>The cells enumertor</returns>
	public IEnumerator GetEnumerator()
	{
		return new Class12(cells_0, cellArea_0);
	}

	/// <summary>
	///       Indicates whether the range is intersect.
	///       </summary>
	/// <param name="range">The range.</param>
	/// <returns> Whether the range is intersect.</returns>
	/// <remarks>If the two rangs area not in the same worksheet ,return false.</remarks>
	public bool IsIntersect(Range range)
	{
		if (cells_0 != range.cells_0)
		{
			return false;
		}
		int num = ((cellArea_0.StartRow < range.cellArea_0.StartRow) ? range.cellArea_0.StartRow : cellArea_0.StartRow);
		int num2 = ((cellArea_0.EndRow > range.cellArea_0.EndRow) ? range.cellArea_0.EndRow : cellArea_0.EndRow);
		if (num > num2)
		{
			return false;
		}
		num = ((cellArea_0.StartColumn < range.cellArea_0.StartColumn) ? range.cellArea_0.StartColumn : cellArea_0.StartColumn);
		num2 = ((cellArea_0.EndColumn > range.cellArea_0.EndColumn) ? range.cellArea_0.EndColumn : cellArea_0.EndColumn);
		if (num > num2)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	///       Returns a Range object that represents the rectangular intersection of two ranges.
	///       </summary>
	/// <param name="range">The intersecting range.</param>
	/// <returns>a Range object</returns>
	/// <remarks>If the two ranges are not intersected ,returns null.</remarks>
	public Range Intersect(Range range)
	{
		if (cells_0 != range.cells_0)
		{
			return null;
		}
		int num = ((cellArea_0.StartRow < range.cellArea_0.StartRow) ? range.cellArea_0.StartRow : cellArea_0.StartRow);
		int num2 = ((cellArea_0.EndRow > range.cellArea_0.EndRow) ? range.cellArea_0.EndRow : cellArea_0.EndRow);
		if (num > num2)
		{
			return null;
		}
		int num3 = ((cellArea_0.StartColumn < range.cellArea_0.StartColumn) ? range.cellArea_0.StartColumn : cellArea_0.StartColumn);
		int num4 = ((cellArea_0.EndColumn > range.cellArea_0.EndColumn) ? range.cellArea_0.EndColumn : cellArea_0.EndColumn);
		if (num3 > num4)
		{
			return null;
		}
		if (num == cellArea_0.StartRow && num3 == cellArea_0.StartColumn && num2 == cellArea_0.EndRow && num4 == cellArea_0.EndColumn)
		{
			return this;
		}
		if (num == range.cellArea_0.StartRow && num3 == range.cellArea_0.StartColumn && num2 == range.cellArea_0.EndRow && num4 == range.cellArea_0.EndColumn)
		{
			return range;
		}
		return new Range(num, num3, num2 - num + 1, num4 - num3 + 1, cells_0);
	}

	/// <summary>
	///       Returns the union of two ranges.
	///       </summary>
	/// <param name="range">The range</param>
	/// <returns>The union of two ranges.
	///       </returns>
	public ArrayList Union(Range range)
	{
		ArrayList arrayList = new ArrayList();
		if (cells_0 != range.cells_0)
		{
			arrayList.Add(this);
			arrayList.Add(range);
			return arrayList;
		}
		int num = ((cellArea_0.StartRow < range.cellArea_0.StartRow) ? range.cellArea_0.StartRow : cellArea_0.StartRow);
		int num2 = ((cellArea_0.EndRow > range.cellArea_0.EndRow) ? range.cellArea_0.EndRow : cellArea_0.EndRow);
		if (num > num2)
		{
			if (num2 + 1 == num && cellArea_0.StartColumn == range.cellArea_0.StartColumn && cellArea_0.EndColumn == range.cellArea_0.EndColumn)
			{
				int num3 = ((cellArea_0.StartRow > range.cellArea_0.StartRow) ? range.cellArea_0.StartRow : cellArea_0.StartRow);
				int num4 = ((cellArea_0.EndRow < range.cellArea_0.EndRow) ? range.cellArea_0.EndRow : cellArea_0.EndRow);
				Range value = new Range(num3, cellArea_0.StartColumn, num4 - num3 + 1, cellArea_0.EndColumn - cellArea_0.StartColumn + 1, cells_0);
				arrayList.Add(value);
				return arrayList;
			}
			arrayList.Add(this);
			arrayList.Add(range);
			return arrayList;
		}
		int num5 = ((cellArea_0.StartColumn < range.cellArea_0.StartColumn) ? range.cellArea_0.StartColumn : cellArea_0.StartColumn);
		int num6 = ((cellArea_0.EndColumn > range.cellArea_0.EndColumn) ? range.cellArea_0.EndColumn : cellArea_0.EndColumn);
		if (num5 > num6)
		{
			if (num6 + 1 == num5 && cellArea_0.StartRow == range.cellArea_0.StartRow && cellArea_0.EndRow == range.cellArea_0.EndRow)
			{
				int num7 = ((cellArea_0.StartColumn > range.cellArea_0.StartColumn) ? range.cellArea_0.StartColumn : cellArea_0.StartColumn);
				int num8 = ((cellArea_0.EndColumn < range.cellArea_0.EndColumn) ? range.cellArea_0.EndColumn : cellArea_0.EndColumn);
				Range value2 = new Range(cellArea_0.StartRow, num7, cellArea_0.EndRow - cellArea_0.StartRow + 1, num8 - num7 + 1, cells_0);
				arrayList.Add(value2);
				return arrayList;
			}
			arrayList.Add(this);
			arrayList.Add(range);
			return arrayList;
		}
		if (num == cellArea_0.StartRow && num2 == cellArea_0.EndRow && num5 == cellArea_0.StartColumn && num6 == cellArea_0.EndColumn)
		{
			arrayList.Add(range);
			return arrayList;
		}
		if (num == range.cellArea_0.StartRow && num2 == range.cellArea_0.EndRow && num5 == range.cellArea_0.StartColumn && num6 == range.cellArea_0.EndColumn)
		{
			arrayList.Add(this);
			return arrayList;
		}
		if (cellArea_0.StartRow == range.cellArea_0.StartRow && cellArea_0.EndRow == range.cellArea_0.EndRow)
		{
			int num9 = ((cellArea_0.StartColumn > range.cellArea_0.StartColumn) ? range.cellArea_0.StartColumn : cellArea_0.StartColumn);
			int num10 = ((cellArea_0.EndColumn < range.cellArea_0.EndColumn) ? range.cellArea_0.EndColumn : cellArea_0.EndColumn);
			Range value3 = new Range(cellArea_0.StartRow, num9, cellArea_0.EndRow - cellArea_0.StartRow + 1, num10 - num9 + 1, cells_0);
			arrayList.Add(value3);
			return arrayList;
		}
		if (cellArea_0.StartColumn == range.cellArea_0.StartColumn && cellArea_0.EndColumn == range.cellArea_0.EndColumn)
		{
			int num11 = ((cellArea_0.StartRow > range.cellArea_0.StartRow) ? range.cellArea_0.StartRow : cellArea_0.StartRow);
			int num12 = ((cellArea_0.EndRow < range.cellArea_0.EndRow) ? range.cellArea_0.EndRow : cellArea_0.EndRow);
			Range value4 = new Range(num11, cellArea_0.StartColumn, num12 - num11 + 1, cellArea_0.EndColumn - cellArea_0.StartColumn + 1, cells_0);
			arrayList.Add(value4);
			return arrayList;
		}
		CellArea cellArea = cellArea_0;
		CellArea cellArea2 = range.cellArea_0;
		if (cellArea.StartRow > cellArea2.StartRow)
		{
			CellArea cellArea3 = cellArea;
			cellArea = cellArea2;
			cellArea2 = cellArea3;
		}
		Range range2 = null;
		if (cellArea.StartRow < cellArea2.StartRow)
		{
			range2 = new Range(cellArea.StartRow, cellArea.StartColumn, cellArea2.StartRow - cellArea.StartRow, cellArea.EndColumn - cellArea.StartColumn + 1, cells_0);
			arrayList.Add(range2);
		}
		int num13 = ((cellArea_0.StartColumn < range.cellArea_0.StartColumn) ? cellArea_0.StartColumn : range.cellArea_0.StartColumn);
		int num14 = ((cellArea_0.EndColumn > range.cellArea_0.EndColumn) ? cellArea_0.EndColumn : range.cellArea_0.EndColumn);
		Range range3;
		if (range2 != null && range2.cellArea_0.StartColumn == num13 && range2.cellArea_0.EndColumn == num14)
		{
			range2.cellArea_0.EndRow = num2;
			range3 = range2;
		}
		else
		{
			range3 = new Range(num, num13, num2 - num + 1, num14 - num13 + 1, cells_0);
			arrayList.Add(range3);
		}
		if (cellArea.EndRow != cellArea2.EndRow)
		{
			CellArea cellArea4 = default(CellArea);
			if (cellArea.EndRow > cellArea2.EndRow)
			{
				cellArea4.StartRow = cellArea2.EndRow + 1;
				cellArea4.EndRow = cellArea.EndRow;
				cellArea4.StartColumn = cellArea.StartColumn;
				cellArea4.EndColumn = cellArea.EndColumn;
			}
			else
			{
				cellArea4.StartRow = cellArea.EndRow + 1;
				cellArea4.EndRow = cellArea2.EndRow;
				cellArea4.StartColumn = cellArea2.StartColumn;
				cellArea4.EndColumn = cellArea2.EndColumn;
			}
			if (range3 != null && range3.cellArea_0.StartColumn == cellArea4.StartColumn && range3.cellArea_0.EndColumn == cellArea4.EndColumn)
			{
				range3.cellArea_0.EndRow = cellArea4.EndRow;
			}
			else
			{
				Range value5 = new Range(cellArea4.StartRow, cellArea4.StartColumn, cellArea4.EndRow - cellArea4.StartRow + 1, cellArea4.EndColumn - cellArea4.StartColumn + 1, cells_0);
				arrayList.Add(value5);
			}
		}
		return arrayList;
	}

	internal Range(int int_0, int int_1, int int_2, int int_3, Cells cells_1)
	{
		if (int_2 == 0 || int_3 == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Number of rows or columns cannot be zero.");
		}
		cells_0 = cells_1;
		int endRow = int_0 + int_2 - 1;
		ushort endColumn = (ushort)(int_1 + int_3 - 1);
		cellArea_0.StartRow = int_0;
		cellArea_0.StartColumn = int_1;
		cellArea_0.EndRow = endRow;
		cellArea_0.EndColumn = endColumn;
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		bool bool_ = false;
		cellArea_0 = Class1678.InsertColumns(cellArea_0, int_0, int_1, ref bool_);
	}

	internal void InsertRows(int int_0, int int_1)
	{
		if (cellArea_0.StartRow >= int_0)
		{
			int num = cellArea_0.StartRow + int_1;
			if (num < 0)
			{
				num = 0;
			}
			else if (num > 1048575)
			{
				cellArea_0.StartRow = 1048575;
			}
			else
			{
				cellArea_0.StartRow = num;
			}
			int num2 = cellArea_0.EndRow + int_1;
			if (num2 > 1048575)
			{
				cellArea_0.EndRow = 1048575;
			}
			else
			{
				cellArea_0.EndRow = num2;
			}
		}
		else if (cellArea_0.EndRow >= int_0)
		{
			int num3 = cellArea_0.EndRow + int_1;
			if (num3 < 0)
			{
				num3 = 0;
			}
			else if (num3 > 1048575)
			{
				cellArea_0.EndRow = 1048575;
			}
			else
			{
				cellArea_0.EndRow = num3;
			}
		}
	}

	internal void method_0(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	internal string method_1()
	{
		if (Area.StartRow == Area.EndRow && Area.StartColumn == Area.EndColumn)
		{
			return CellsHelper.CellIndexToName(Area.StartRow, Area.StartColumn);
		}
		return CellsHelper.CellIndexToName(Area.StartRow, Area.StartColumn) + ":" + CellsHelper.CellIndexToName(Area.EndRow, Area.EndColumn);
	}

	/// <summary>
	///        Combines a range of cells into a single cell. 		
	///        </summary>
	/// <remarks>
	///        Reference the merged cell via the address of the upper-left cell in the range.
	///       </remarks>
	public void Merge()
	{
		cells_0.Merge(FirstRow, FirstColumn, RowCount, ColumnCount);
	}

	/// <summary>
	///       Unmerges merged cells of this range.
	///       </summary>
	public void UnMerge()
	{
		cells_0.UnMerge(FirstRow, FirstColumn, RowCount, ColumnCount);
	}

	public void PutValue(string stringValue, bool isConverted, bool setStyle)
	{
		CellArea cellArea = cellArea_0;
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cell = cells_0.GetCell(i, j, bool_2: false);
				cell.PutValue(stringValue, isConverted, setStyle);
			}
		}
	}

	/// <summary>
	///       Applies formattings for a whole range.
	///       </summary>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	/// <remarks>Each cell in this range will contains a <see cref="T:Aspose.Cells.Style" /> object. 
	///       So this is a memory-consuming method. Please use it carefully.</remarks>
	public void ApplyStyle(Style style, StyleFlag flag)
	{
		if (style.method_5() == null)
		{
			style.method_6(cells_0.method_19());
		}
		CellArea cellArea = cellArea_0;
		RowCollection rows = cells_0.Rows;
		rows.method_7();
		if (flag.All)
		{
			int int_ = -1;
			if (style != null)
			{
				int_ = Worksheet.method_2().method_59(style);
			}
			for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
			{
				Row row = rows.GetRow(i, bool_0: false, bool_1: true);
				for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
				{
					Cell cell = row.GetCell(j);
					cell.method_37(int_);
				}
			}
			return;
		}
		Hashtable hashtable = new Hashtable();
		int num = 0;
		for (int k = cellArea.StartRow; k <= cellArea.EndRow; k++)
		{
			Row row2 = rows.GetRow(k, bool_0: false, bool_1: true);
			for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
			{
				Cell cell2 = row2.GetCell(l);
				num = cell2.method_35();
				if (hashtable[num] != null)
				{
					cell2.method_37((int)hashtable[num]);
					continue;
				}
				Style style2 = cell2.method_28();
				Class1677.ApplyStyle(style, style2, flag);
				cell2.method_30(style2);
				hashtable.Add(num, cell2.method_36());
			}
		}
	}

	/// <summary>
	///       Sets the style of the range.
	///       </summary>
	/// <param name="style">The Style object.</param>
	public void SetStyle(Style style)
	{
		int int_ = -1;
		if (style != null)
		{
			int_ = cells_0.method_19().method_59(style);
		}
		method_2(int_);
	}

	internal void method_2(int int_0)
	{
		CellArea cellArea = cellArea_0;
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cell = cells_0.GetCell(i, j, bool_2: false);
				cell.method_37(int_0);
			}
		}
	}

	/// <summary>
	///       Sets the outline borders around a range of cells with same border style and color.
	///       </summary>
	/// <param name="borderStyle">Border style.</param>
	/// <param name="borderColor">Border color.</param>
	public void SetOutlineBorders(CellBorderType borderStyle, Color borderColor)
	{
		Style style = null;
		Cell cell = null;
		int startRow = cellArea_0.StartRow;
		int startColumn = cellArea_0.StartColumn;
		if (cellArea_0.StartRow == cellArea_0.EndRow)
		{
			if (cellArea_0.StartColumn == cellArea_0.EndColumn)
			{
				cell = cells_0.GetCell(startRow, cellArea_0.StartColumn, bool_2: false);
				style = cell.method_28();
				style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
				style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
				style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
				style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
				cell.method_30(style);
				return;
			}
			cell = cells_0.GetCell(startRow, cellArea_0.StartColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
			cell.method_30(style);
			Hashtable hashtable = new Hashtable();
			for (startColumn = cellArea_0.StartColumn + 1; startColumn < cellArea_0.EndColumn; startColumn++)
			{
				cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
				int num = cell.method_35();
				if (hashtable[num] != null)
				{
					cell.method_37((int)hashtable[num]);
					continue;
				}
				style = cell.method_28();
				style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
				style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
				cell.method_30(style);
				hashtable.Add(num, cell.method_36());
			}
			cell = cells_0.GetCell(cellArea_0.StartRow, cellArea_0.EndColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
			cell.method_30(style);
			return;
		}
		if (cellArea_0.StartColumn == cellArea_0.EndColumn)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
			cell.method_30(style);
			Hashtable hashtable2 = new Hashtable();
			for (startRow = cellArea_0.StartRow + 1; startRow < cellArea_0.EndRow; startRow++)
			{
				cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
				int num2 = cell.method_35();
				if (hashtable2[num2] != null)
				{
					cell.method_37((int)hashtable2[num2]);
					continue;
				}
				style = cell.method_28();
				style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
				style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
				cell.method_30(style);
				hashtable2.Add(num2, cell.method_36());
			}
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
			style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
			cell.method_30(style);
			return;
		}
		Hashtable hashtable3 = null;
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
		style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
		cell.method_30(style);
		hashtable3 = new Hashtable();
		for (startColumn++; startColumn < cellArea_0.EndColumn; startColumn++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num3 = cell.method_35();
			if (hashtable3[num3] != null)
			{
				cell.method_37((int)hashtable3[num3]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
			cell.method_30(style);
			hashtable3.Add(num3, cell.method_36());
		}
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
		style.SetBorder(BorderType.TopBorder, borderStyle, borderColor);
		cell.method_30(style);
		startRow = cellArea_0.EndRow;
		startColumn = cellArea_0.StartColumn;
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
		style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
		cell.method_30(style);
		hashtable3 = new Hashtable();
		for (startColumn++; startColumn < cellArea_0.EndColumn; startColumn++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num4 = cell.method_35();
			if (hashtable3[num4] != null)
			{
				cell.method_37((int)hashtable3[num4]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
			cell.method_30(style);
			hashtable3.Add(num4, cell.method_36());
		}
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
		style.SetBorder(BorderType.BottomBorder, borderStyle, borderColor);
		cell.method_30(style);
		startRow = cellArea_0.StartRow + 1;
		startColumn = cellArea_0.StartColumn;
		hashtable3 = new Hashtable();
		for (; startRow < cellArea_0.EndRow; startRow++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num5 = cell.method_35();
			if (hashtable3[num5] != null)
			{
				cell.method_37((int)hashtable3[num5]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyle, borderColor);
			cell.method_30(style);
			hashtable3.Add(num5, cell.method_36());
		}
		startRow = cellArea_0.StartRow + 1;
		startColumn = cellArea_0.EndColumn;
		hashtable3 = new Hashtable();
		for (; startRow < cellArea_0.EndRow; startRow++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num6 = cell.method_35();
			if (hashtable3[num6] != null)
			{
				cell.method_37((int)hashtable3[num6]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.RightBorder, borderStyle, borderColor);
			cell.method_30(style);
			hashtable3.Add(num6, cell.method_36());
		}
	}

	/// <summary>
	///       Sets out line borders around a range of cells.
	///       </summary>
	/// <param name="borderStyles">Border styles.</param>
	/// <param name="borderColors">Border colors.</param>
	/// <remarks>
	///       Both the length of borderStyles and borderStyles must be 4.
	///       The order of of borderStyles and borderStyles must be top,bottom,left,right
	///       </remarks>
	public void SetOutlineBorders(CellBorderType[] borderStyles, Color[] borderColors)
	{
		Style style = null;
		Cell cell = null;
		int startRow = cellArea_0.StartRow;
		int startColumn = cellArea_0.StartColumn;
		if (cellArea_0.StartRow == cellArea_0.EndRow)
		{
			if (cellArea_0.StartColumn == cellArea_0.EndColumn)
			{
				cell = cells_0.GetCell(startRow, cellArea_0.StartColumn, bool_2: false);
				style = cell.method_28();
				style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
				style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
				style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
				style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
				cell.method_30(style);
				return;
			}
			cell = cells_0.GetCell(startRow, cellArea_0.StartColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
			style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
			style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
			cell.method_30(style);
			Hashtable hashtable = new Hashtable();
			for (startColumn = cellArea_0.StartColumn + 1; startColumn < cellArea_0.EndColumn; startColumn++)
			{
				cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
				int num = cell.method_35();
				if (hashtable[num] != null)
				{
					cell.method_37((int)hashtable[num]);
					continue;
				}
				style = cell.method_28();
				style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
				style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
				cell.method_30(style);
				hashtable.Add(num, cell.method_36());
			}
			cell = cells_0.GetCell(cellArea_0.StartRow, cellArea_0.EndColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
			style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
			style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
			cell.method_30(style);
			return;
		}
		if (cellArea_0.StartColumn == cellArea_0.EndColumn)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
			style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
			style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
			cell.method_30(style);
			Hashtable hashtable2 = new Hashtable();
			for (startRow = cellArea_0.StartRow + 1; startRow < cellArea_0.EndRow; startRow++)
			{
				cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
				int num2 = cell.method_35();
				if (hashtable2[num2] != null)
				{
					cell.method_37((int)hashtable2[num2]);
					continue;
				}
				style = cell.method_28();
				style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
				style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
				cell.method_30(style);
				hashtable2.Add(num2, cell.method_36());
			}
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
			style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
			style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
			cell.method_30(style);
			return;
		}
		Hashtable hashtable3 = null;
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
		style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
		cell.method_30(style);
		hashtable3 = new Hashtable();
		for (startColumn++; startColumn < cellArea_0.EndColumn; startColumn++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num3 = cell.method_35();
			if (hashtable3[num3] != null)
			{
				cell.method_37((int)hashtable3[num3]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
			cell.method_30(style);
			hashtable3.Add(num3, cell.method_36());
		}
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
		style.SetBorder(BorderType.TopBorder, borderStyles[0], borderColors[0]);
		cell.method_30(style);
		startRow = cellArea_0.EndRow;
		startColumn = cellArea_0.StartColumn;
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
		style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
		cell.method_30(style);
		hashtable3 = new Hashtable();
		for (startColumn++; startColumn < cellArea_0.EndColumn; startColumn++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num4 = cell.method_35();
			if (hashtable3[num4] != null)
			{
				cell.method_37((int)hashtable3[num4]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
			cell.method_30(style);
			hashtable3.Add(num4, cell.method_36());
		}
		cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
		style = cell.method_28();
		style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
		style.SetBorder(BorderType.BottomBorder, borderStyles[1], borderColors[1]);
		cell.method_30(style);
		startRow = cellArea_0.StartRow + 1;
		startColumn = cellArea_0.StartColumn;
		hashtable3 = new Hashtable();
		for (; startRow < cellArea_0.EndRow; startRow++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num5 = cell.method_35();
			if (hashtable3[num5] != null)
			{
				cell.method_37((int)hashtable3[num5]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.LeftBorder, borderStyles[2], borderColors[2]);
			cell.method_30(style);
			hashtable3.Add(num5, cell.method_36());
		}
		startRow = cellArea_0.StartRow + 1;
		startColumn = cellArea_0.EndColumn;
		hashtable3 = new Hashtable();
		for (; startRow < cellArea_0.EndRow; startRow++)
		{
			cell = cells_0.GetCell(startRow, startColumn, bool_2: false);
			int num6 = cell.method_35();
			if (hashtable3[num6] != null)
			{
				cell.method_37((int)hashtable3[num6]);
				continue;
			}
			style = cell.method_28();
			style.SetBorder(BorderType.RightBorder, borderStyles[3], borderColors[3]);
			cell.method_30(style);
			hashtable3.Add(num6, cell.method_36());
		}
	}

	/// <summary>
	///       Sets outline border around a range of cells.
	///       </summary>
	/// <param name="borderEdge">Border edge.</param>
	/// <param name="borderStyle">Border style.</param>
	/// <param name="borderColor">Border color.</param>
	public void SetOutlineBorder(BorderType borderEdge, CellBorderType borderStyle, Color borderColor)
	{
		Style style = null;
		CellArea cellArea = cellArea_0;
		Hashtable hashtable = new Hashtable();
		switch (borderEdge)
		{
		case BorderType.BottomBorder:
		{
			for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
			{
				Cell cell4 = cells_0.GetCell(cellArea.EndRow, l, bool_2: false);
				int num4 = cell4.method_35();
				if (hashtable[num4] != null)
				{
					cell4.method_37((int)hashtable[num4]);
					continue;
				}
				style = cell4.method_28();
				Border border = style.Borders[BorderType.BottomBorder];
				border.LineStyle = borderStyle;
				border.Color = borderColor;
				cell4.method_30(style);
				hashtable.Add(num4, cell4.method_36());
			}
			break;
		}
		case BorderType.LeftBorder:
		{
			for (int j = cellArea.StartRow; j <= cellArea.EndRow; j++)
			{
				Cell cell2 = cells_0.GetCell(j, cellArea.StartColumn, bool_2: false);
				int num2 = cell2.method_35();
				if (hashtable[num2] != null)
				{
					cell2.method_37((int)hashtable[num2]);
					continue;
				}
				style = cell2.method_28();
				Border border = style.Borders[BorderType.LeftBorder];
				border.LineStyle = borderStyle;
				border.Color = borderColor;
				cell2.method_30(style);
				hashtable.Add(num2, cell2.method_36());
			}
			break;
		}
		case BorderType.RightBorder:
		{
			for (int k = cellArea.StartRow; k <= cellArea.EndRow; k++)
			{
				Cell cell3 = cells_0.GetCell(k, cellArea.EndColumn, bool_2: false);
				int num3 = cell3.method_35();
				if (hashtable[num3] != null)
				{
					cell3.method_37((int)hashtable[num3]);
					continue;
				}
				style = cell3.method_28();
				Border border = style.Borders[BorderType.RightBorder];
				border.LineStyle = borderStyle;
				border.Color = borderColor;
				cell3.method_30(style);
				hashtable.Add(num3, cell3.method_36());
			}
			break;
		}
		case BorderType.TopBorder:
		{
			for (int i = cellArea.StartColumn; i <= cellArea.EndColumn; i++)
			{
				Cell cell = cells_0.GetCell(cellArea.StartRow, i, bool_2: false);
				int num = cell.method_35();
				if (hashtable[num] != null)
				{
					cell.method_37((int)hashtable[num]);
					continue;
				}
				style = cell.method_28();
				Border border = style.Borders[BorderType.TopBorder];
				border.LineStyle = borderStyle;
				border.Color = borderColor;
				cell.method_30(style);
				hashtable.Add(num, cell.method_36());
			}
			break;
		}
		}
	}

	internal void method_3(Range range_0)
	{
		cellArea_0 = range_0.cellArea_0;
		string_0 = range_0.string_0;
	}

	private void method_4(int int_0, int int_1)
	{
		int num = cells_0.Columns.method_7(int_0);
		if (num != -1)
		{
			Column columnByIndex = cells_0.Columns.GetColumnByIndex(num);
			cells_0.Columns.RemoveAt(num);
			Column column = cells_0.Columns[int_1];
			column.CopyData(columnByIndex);
		}
		else
		{
			num = cells_0.Columns.method_7(int_1);
			if (num != -1)
			{
				cells_0.Columns.RemoveAt(num);
			}
		}
	}

	private void method_5(int int_0, int int_1)
	{
		int num = cells_0.Rows.method_5(int_0);
		if (num != -1)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(num);
			cells_0.Rows.RemoveAt(num);
			Row row = cells_0.Rows.GetRow(int_1, bool_0: false, bool_1: true);
			row.CopyData(rowByIndex);
		}
		else
		{
			num = cells_0.Rows.method_5(int_1);
			if (num != -1)
			{
				cells_0.Rows.RemoveAt(num);
			}
		}
	}

	private void method_6(int int_0, int int_1, int int_2, int int_3)
	{
		Cell cell = cells_0.CheckCell(cellArea_0.StartRow + int_0, cellArea_0.StartColumn + int_1);
		if (cell != null)
		{
			cell.method_48();
			cells_0.Rows.method_12(cell.Row, cell.Column);
			Cell cell2 = cells_0.GetCell(int_2 + int_0, (short)(int_3 + int_1), bool_2: false);
			cell2.method_54(cell);
			if (cell2.IsFormula)
			{
				byte[] byte_ = cell2.method_41();
				Class1674.MoveRange(cellArea_0, int_2, int_3, cells_0.method_3(), bool_0: true, byte_, -1, -1);
				cell2.method_42(byte_);
			}
		}
		else
		{
			cells_0.Rows.method_12(int_2 + int_0, int_3 + int_1);
		}
	}

	/// <summary>
	///       Move the current range to the dest range.
	///       </summary>
	/// <param name="destRow">The start row of the dest range.</param>
	/// <param name="destColumn">The start column of the dest range.</param>
	public void MoveTo(int destRow, int destColumn)
	{
		if (destRow == cellArea_0.StartRow && destColumn == cellArea_0.StartColumn)
		{
			return;
		}
		cells_0.method_19().Workbook.method_3();
		Range range = new Range(destRow, destColumn, RowCount, ColumnCount, cells_0);
		bool flag = false;
		int rowCount = RowCount;
		int columnCount = ColumnCount;
		if (RowCount == 65536)
		{
			if (cellArea_0.StartColumn < destColumn)
			{
				for (int num = columnCount - 1; num >= 0; num--)
				{
					method_4(cellArea_0.StartColumn + num, destColumn + num);
				}
			}
			else
			{
				for (int i = 0; i < columnCount; i++)
				{
					method_4(cellArea_0.StartColumn + i, destColumn + i);
				}
			}
		}
		if (ColumnCount == 256)
		{
			if (cellArea_0.StartRow < destRow)
			{
				for (int num2 = rowCount - 1; num2 >= 0; num2--)
				{
					method_5(cellArea_0.StartRow + num2, destRow + num2);
				}
			}
			else
			{
				for (int j = 0; j < rowCount; j++)
				{
					method_5(cellArea_0.StartRow + j, destRow + j);
				}
			}
		}
		if ((destRow > cellArea_0.StartRow && destRow <= cellArea_0.EndRow && destColumn >= cellArea_0.StartColumn && destColumn <= cellArea_0.EndColumn) || (destRow >= cellArea_0.StartRow && destRow <= cellArea_0.EndRow && destColumn > cellArea_0.StartColumn && destColumn <= cellArea_0.EndColumn))
		{
			flag = true;
			for (int num3 = rowCount - 1; num3 >= 0; num3--)
			{
				for (int num4 = columnCount - 1; num4 >= 0; num4--)
				{
					method_6(num3, num4, destRow, destColumn);
				}
			}
		}
		if (!flag)
		{
			for (int k = 0; k < rowCount; k++)
			{
				for (int l = 0; l < columnCount; l++)
				{
					method_6(k, l, destRow, destColumn);
				}
			}
		}
		for (int m = 0; m < cells_0.Rows.Count; m++)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(m);
			for (int n = 0; n < rowByIndex.method_0(); n++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(n);
				if (cellByIndex.IsFormula && (cellByIndex.Row < destRow || cellByIndex.Row > range.cellArea_0.EndRow || cellByIndex.Column < destColumn || cellByIndex.Column > range.cellArea_0.EndColumn))
				{
					if (cellByIndex.method_45())
					{
						cellByIndex.method_72();
					}
					if (!cellByIndex.IsInArray)
					{
						byte[] byte_ = cellByIndex.method_41();
						Class1674.MoveRange(cellArea_0, destRow, destColumn, cells_0.method_3(), bool_0: true, byte_, -1, -1);
						cellByIndex.method_42(byte_);
					}
				}
			}
		}
		Worksheet worksheet = cells_0.method_3();
		NameCollection names = worksheet.method_2().Names;
		for (int num5 = 0; num5 < names.Count; num5++)
		{
			Name name = names[num5];
			byte[] array = name.method_2();
			if (array != null)
			{
				Class1674.MoveRange(cellArea_0, destRow, destColumn, cells_0.method_3(), bool_0: true, array, -1, -1);
				name.method_3(array);
			}
		}
		for (int num6 = 0; num6 < worksheet.Comments.Count; num6++)
		{
			Comment comment = worksheet.Comments[num6];
			if (comment.Row >= Area.StartRow && comment.Row <= Area.EndRow && comment.Column >= Area.StartColumn && comment.Column <= Area.EndColumn)
			{
				int num7 = comment.Row - Area.StartRow;
				int num8 = comment.Column - Area.StartColumn;
				int row = comment.Row;
				int column = comment.Column;
				comment.method_4(destRow + num7);
				comment.method_5(destColumn + num8);
				num7 = comment.CommentShape.UpperLeftRow - row;
				num8 = comment.CommentShape.UpperLeftColumn - column;
				comment.CommentShape.UpperLeftRow = comment.Row + num7;
				comment.CommentShape.UpperLeftColumn = comment.Column + num8;
			}
		}
		cells_0.method_18().method_8(cellArea_0, rowCount, columnCount, destRow, destColumn);
		cellArea_0 = default(CellArea);
		cellArea_0.StartRow = destRow;
		cellArea_0.StartColumn = destColumn;
		cellArea_0.EndRow = destRow + rowCount - 1;
		cellArea_0.EndColumn = destColumn + columnCount - 1;
		if (string_0 != null)
		{
			Name = string_0;
		}
	}

	/// <summary>
	///       Copies cell data (including formulas) from a source range.
	///       </summary>
	/// <param name="range">Source <see cref="T:Aspose.Cells.Range" /> object.</param>
	public void CopyData(Range range)
	{
		Worksheet.Workbook.method_3();
		if (range.cells_0.method_3().Hyperlinks.Count != 0)
		{
			cells_0.method_3().Hyperlinks.method_6(range.cells_0.method_3().Hyperlinks, range.Area, Area);
		}
		CellArea cellArea = range.cellArea_0;
		CellArea cellArea_ = cellArea_0;
		int num = cellArea.EndRow - cellArea.StartRow + 1;
		int num2 = cellArea.EndColumn - cellArea.StartColumn + 1;
		int num3 = cellArea_.EndRow - cellArea_.StartRow + 1;
		int num4 = cellArea_.EndColumn - cellArea_.StartColumn + 1;
		if (num > num3)
		{
			num = num3;
		}
		if (num2 > num4)
		{
			num2 = num4;
		}
		bool flag = false;
		if (range.cells_0 == cells_0 && cellArea_.StartRow > cellArea.StartRow && cellArea_.StartRow <= cellArea.StartRow + num && cellArea_.StartColumn >= cellArea.StartColumn && cellArea_.StartColumn <= cellArea.StartColumn + num2)
		{
			flag = true;
			for (int num5 = num - 1; num5 >= 0; num5--)
			{
				for (int num6 = num2 - 1; num6 >= 0; num6--)
				{
					Cell cell = range.cells_0.CheckCell(cellArea.StartRow + num5, cellArea.StartColumn + num6);
					if (cell == null)
					{
						cells_0.CheckCell(cellArea_.StartRow + num5, cellArea_.StartColumn + num6)?.method_6();
					}
					else
					{
						cells_0.GetCell(cellArea_.StartRow + num5, cellArea_.StartColumn + num6, bool_2: false).CopyData(cell);
					}
				}
			}
		}
		if (flag)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				Cell cell2 = range.cells_0.CheckCell(cellArea.StartRow + i, cellArea.StartColumn + j);
				if (cell2 == null)
				{
					cells_0.CheckCell(cellArea_.StartRow + i, cellArea_.StartColumn + j)?.method_6();
				}
				else
				{
					cells_0.GetCell(cellArea_.StartRow + i, cellArea_.StartColumn + j, bool_2: false).CopyData(cell2);
				}
			}
		}
		method_7(cellArea_);
	}

	/// <summary>
	///       Copies cell value from a source range.
	///       </summary>
	/// <param name="range">Source <see cref="T:Aspose.Cells.Range" /> object.</param>
	public void CopyValue(Range range)
	{
		CellArea cellArea = range.cellArea_0;
		CellArea cellArea_ = cellArea_0;
		int num = cellArea.EndRow - cellArea.StartRow + 1;
		int num2 = cellArea.EndColumn - cellArea.StartColumn + 1;
		int num3 = cellArea_.EndRow - cellArea_.StartRow + 1;
		int num4 = cellArea_.EndColumn - cellArea_.StartColumn + 1;
		if (num > num3)
		{
			num = num3;
		}
		if (num2 > num4)
		{
			num2 = num4;
		}
		bool flag = false;
		if (range.cells_0 == cells_0 && cellArea_.StartRow > cellArea.StartRow && cellArea_.StartRow <= cellArea.StartRow + num && cellArea_.StartColumn >= cellArea.StartColumn && cellArea_.StartColumn <= cellArea.StartColumn + num2)
		{
			flag = true;
			for (int num5 = num - 1; num5 >= 0; num5--)
			{
				for (int num6 = num2 - 1; num6 >= 0; num6--)
				{
					Cell cell = range.cells_0.CheckCell(cellArea.StartRow + num5, cellArea.StartColumn + num6);
					if (cell == null)
					{
						cells_0.CheckCell(cellArea_.StartRow + num5, cellArea_.StartColumn + num6)?.method_6();
					}
					else if (cell.Type == CellValueType.IsString)
					{
						cells_0.GetCell(cellArea_.StartRow + num5, cellArea_.StartColumn + num6, bool_2: false).PutValue(cell.StringValue);
					}
					else
					{
						cells_0.GetCell(cellArea_.StartRow + num5, cellArea_.StartColumn + num6, bool_2: false).PutValue(cell.method_57());
					}
				}
			}
		}
		if (flag)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				Cell cell2 = range.cells_0.CheckCell(cellArea.StartRow + i, cellArea.StartColumn + j);
				if (cell2 == null)
				{
					cells_0.CheckCell(cellArea_.StartRow + i, cellArea_.StartColumn + j)?.method_6();
				}
				else if (cell2.Type == CellValueType.IsString)
				{
					cells_0.GetCell(cellArea_.StartRow + i, cellArea_.StartColumn + j, bool_2: false).PutValue(cell2.StringValue);
				}
				else
				{
					cells_0.GetCell(cellArea_.StartRow + i, cellArea_.StartColumn + j, bool_2: false).PutValue(cell2.method_57());
				}
			}
		}
		method_7(cellArea_);
	}

	internal void method_7(CellArea cellArea_1)
	{
		foreach (ListObject listObject in Worksheet.ListObjects)
		{
			if (listObject.ShowHeaderRow && listObject.StartRow >= cellArea_1.StartRow && listObject.StartRow <= cellArea_1.EndRow && listObject.StartColumn <= cellArea_1.EndColumn && listObject.EndColumn >= cellArea_1.StartColumn)
			{
				listObject.UpdateColumnName();
			}
		}
	}

	/// <summary>
	///       Copies style settings from a source range.
	///       </summary>
	/// <param name="range">Source <see cref="T:Aspose.Cells.Range" /> object.</param>
	public void CopyStyle(Range range)
	{
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false, Enum173.const_4);
		CellArea cellArea = range.cellArea_0;
		CellArea cellArea2 = cellArea_0;
		int num = cellArea.EndRow - cellArea.StartRow + 1;
		int num2 = cellArea.EndColumn - cellArea.StartColumn + 1;
		int num3 = cellArea2.EndRow - cellArea2.StartRow + 1;
		int num4 = cellArea2.EndColumn - cellArea2.StartColumn + 1;
		if (num > num3)
		{
			num = num3;
		}
		if (num2 > num4)
		{
			num2 = num4;
		}
		if (num == 65536)
		{
			for (int i = cellArea2.StartColumn; i < cellArea2.StartColumn + num2; i++)
			{
				int num5 = cells_0.Columns.method_7(i);
				if (num5 != -1)
				{
					cells_0.Columns.RemoveAt(num5);
				}
			}
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				int num6 = range.cells_0.Columns.method_7(j);
				if (num6 != -1)
				{
					Column columnByIndex = range.cells_0.Columns.GetColumnByIndex(num6);
					Column column = cells_0.Columns[columnByIndex.Index + cellArea2.StartColumn - cellArea.StartColumn];
					column.CopyData(columnByIndex);
				}
			}
		}
		if (num2 == 256)
		{
			for (int k = cellArea2.StartRow; k < cellArea2.StartRow + num; k++)
			{
				int num7 = cells_0.Rows.method_5(k);
				if (num7 != -1)
				{
					cells_0.Rows.RemoveAt(num7);
				}
			}
			for (int l = cellArea.StartRow; l <= cellArea.EndRow; l++)
			{
				int num8 = range.cells_0.Rows.method_5(l);
				if (num8 != -1)
				{
					Row rowByIndex = range.cells_0.Rows.GetRowByIndex(num8);
					Row row = cells_0.Rows.GetRow(rowByIndex.int_0 + cellArea2.StartRow - cellArea.StartRow, bool_0: false, bool_1: true);
					row.CopyData(rowByIndex);
				}
			}
		}
		bool flag = cells_0.method_19() == range.cells_0.method_19();
		for (int m = 0; m < num; m++)
		{
			for (int n = 0; n < num2; n++)
			{
				int num9 = range.method_8(cellArea.StartRow + m, cellArea.StartColumn + n);
				int num10 = cells_0.method_40(cellArea2.StartRow + m, cellArea2.StartColumn + n);
				if ((num9 != num10 || !flag) && ((num9 != -1 && num9 != 15) || (num10 != -1 && num10 != 15)))
				{
					Cell cell = cells_0.GetCell(cellArea2.StartRow + m, cellArea2.StartColumn + n, bool_2: false);
					if (!flag && num9 != -1 && num9 != 15)
					{
						cell.method_30(range.cells_0.method_19().method_45(num9));
					}
					else
					{
						cell.method_37(num9);
					}
				}
			}
		}
		method_9(range, bool_0: false);
		if (range.cells_0.method_3().ConditionalFormattings.Count != 0)
		{
			cells_0.method_3().ConditionalFormattings.CopyInRange(range.cells_0.method_3().ConditionalFormattings, range.cellArea_0, cellArea_0, copyOptions_, bool_0: false);
		}
	}

	private int method_8(int int_0, int int_1)
	{
		WorksheetCollection worksheetCollection = cells_0.method_19();
		int num = cells_0.method_40(int_0, int_1);
		Style style = worksheetCollection.DefaultStyle;
		Style style2 = null;
		if (num != -1 && num != 15)
		{
			style = worksheetCollection.method_58()[num];
		}
		Cell cell = null;
		if (int_0 == cellArea_0.StartRow && int_0 != 0 && style.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None)
		{
			cell = cells_0.CheckCell(int_0 - 1, int_1);
			if (cell != null && cell.method_34())
			{
				Style style3 = cell.method_28();
				if (style3.Borders[BorderType.BottomBorder].LineStyle != 0)
				{
					if (style2 == null)
					{
						style2 = new Style(worksheetCollection);
						style2.Copy(style);
					}
					Border border = style2.Borders[BorderType.TopBorder];
					border.LineStyle = style3.Borders[BorderType.BottomBorder].LineStyle;
					border.InternalColor.method_19(style3.Borders[BorderType.BottomBorder].InternalColor);
				}
			}
		}
		if (style2 != null)
		{
			num = worksheetCollection.method_58().method_3(style2);
		}
		return num;
	}

	private void method_9(Range range_0, bool bool_0)
	{
		CellArea area = Area;
		CellArea area2 = range_0.Area;
		for (int i = 0; i < cells_0.method_18().Count; i++)
		{
			CellArea cellArea = cells_0.method_18()[i];
			if (cellArea.StartRow >= area.StartRow && cellArea.EndRow <= area.EndRow && cellArea.StartColumn >= area.StartColumn && cellArea.EndColumn <= area.EndColumn)
			{
				cells_0.method_18().RemoveAt(i);
				i--;
			}
		}
		int count = range_0.cells_0.method_18().Count;
		for (int j = 0; j < count; j++)
		{
			CellArea cellArea2 = range_0.cells_0.method_18()[j];
			if (cellArea2.StartRow >= area2.StartRow && cellArea2.EndRow <= area2.EndRow && cellArea2.StartColumn >= area2.StartColumn && cellArea2.EndColumn <= area2.EndColumn)
			{
				int num = cellArea2.StartRow - area2.StartRow;
				int num2 = cellArea2.StartColumn - area2.StartColumn;
				int num3 = cellArea2.EndRow - cellArea2.StartRow + 1;
				int num4 = cellArea2.EndColumn - cellArea2.StartColumn + 1;
				if (bool_0)
				{
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = area.StartRow + num2;
					cellArea3.EndRow = cellArea3.StartRow + num4 - 1;
					cellArea3.StartColumn = area.StartColumn + num;
					cellArea3.EndColumn = cellArea3.StartColumn + num3 - 1;
					cells_0.method_18().Add(cellArea3);
				}
				else
				{
					CellArea cellArea4 = default(CellArea);
					cellArea4.StartRow = area.StartRow + num;
					cellArea4.EndRow = cellArea4.StartRow + num3 - 1;
					cellArea4.StartColumn = area.StartColumn + num2;
					cellArea4.EndColumn = cellArea4.StartColumn + num4 - 1;
					cells_0.method_18().Add(cellArea4);
				}
			}
		}
	}

	/// <summary>
	///       Copying the range with paste special options.
	///       </summary>
	/// <param name="range">The soure range.</param>
	/// <param name="options">The paste special options.</param>
	public void Copy(Range range, PasteOptions options)
	{
		if (ColumnCount != 1 && range.ColumnCount == 1)
		{
			int firstColumn = FirstColumn;
			int columnCount = ColumnCount;
			for (int i = 0; i < columnCount; i++)
			{
				cellArea_0.StartColumn = (cellArea_0.EndColumn = i + firstColumn);
				method_10(range, options);
			}
			cellArea_0.StartColumn = firstColumn;
			cellArea_0.EndColumn = firstColumn + columnCount - 1;
		}
		else
		{
			method_10(range, options);
		}
	}

	private void method_10(Range range_0, PasteOptions pasteOptions_0)
	{
		Cells cells = range_0.cells_0;
		if (pasteOptions_0.PasteType == PasteType.ColumnWidths)
		{
			for (int i = range_0.Area.StartColumn; i <= range_0.Area.EndColumn; i++)
			{
				int num = i - range_0.Area.StartColumn;
				double columnWidth = cells.GetColumnWidth(i);
				double columnWidth2 = cells_0.GetColumnWidth(Area.StartColumn + num);
				if (Math.Abs(columnWidth - columnWidth2) > double.Epsilon)
				{
					cells_0.SetColumnWidth(Area.StartColumn + num, columnWidth);
				}
			}
			return;
		}
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false);
		if (pasteOptions_0.Transpose)
		{
			switch (pasteOptions_0.PasteType)
			{
			case PasteType.All:
			case PasteType.AllExceptBorders:
			case PasteType.Formulas:
			case PasteType.FormulasAndNumberFormats:
			case PasteType.Values:
			case PasteType.ValuesAndNumberFormats:
			{
				int num2 = range_0.Area.EndRow - range_0.Area.StartRow + 1;
				int num3 = range_0.Area.EndColumn - range_0.Area.StartColumn + 1;
				for (int j = 0; j < num2; j++)
				{
					Row row = range_0.cells_0.CheckRow(j + range_0.Area.StartRow);
					if (row == null)
					{
						if (!pasteOptions_0.SkipBlanks)
						{
							for (int k = 0; k < num3; k++)
							{
								cells_0.CheckCell(k + Area.StartRow, j + Area.StartColumn)?.Copy(null, pasteOptions_0.PasteType);
							}
						}
						continue;
					}
					for (int l = 0; l < num3; l++)
					{
						Cell cellOrNull = row.GetCellOrNull(l + range_0.Area.StartColumn);
						if (cellOrNull == null && pasteOptions_0.SkipBlanks)
						{
							continue;
						}
						if (cellOrNull == null)
						{
							if (!pasteOptions_0.SkipBlanks)
							{
								cells_0.CheckCell(l + Area.StartRow, j + Area.StartColumn)?.Copy(cellOrNull, pasteOptions_0.PasteType);
							}
						}
						else
						{
							Cell cell = cells_0.GetCell(l + Area.StartRow, j + Area.StartColumn, bool_2: false);
							cell.Copy(cellOrNull, pasteOptions_0.PasteType);
						}
					}
				}
				break;
			}
			}
		}
		else
		{
			switch (pasteOptions_0.PasteType)
			{
			case PasteType.All:
			case PasteType.AllExceptBorders:
			case PasteType.Formats:
			case PasteType.Formulas:
			case PasteType.FormulasAndNumberFormats:
			case PasteType.Values:
			case PasteType.ValuesAndNumberFormats:
			{
				int num4 = range_0.Area.EndRow - range_0.Area.StartRow + 1;
				int num5 = range_0.Area.EndColumn - range_0.Area.StartColumn + 1;
				if (cells_0 == cells)
				{
					object obj = Class1678.Intersect(range_0.Area, Area);
					if (obj != null)
					{
						CellArea cellArea = (CellArea)obj;
						Cell[][] array = new Cell[num4][];
						for (int m = 0; m < num4; m++)
						{
							Row row2 = range_0.cells_0.CheckRow(m + range_0.Area.StartRow);
							if (row2 == null)
							{
								continue;
							}
							array[m] = new Cell[num5];
							for (int n = 0; n < num5; n++)
							{
								Cell cellOrNull2 = row2.GetCellOrNull(n + range_0.Area.StartColumn);
								if (cellOrNull2 != null)
								{
									if (cellOrNull2.Row >= cellArea.StartRow && cellOrNull2.Row <= cellArea.EndRow && cellOrNull2.Column >= cellArea.StartColumn && cellOrNull2.Column <= cellArea.EndColumn)
									{
										Cell cell2 = new Cell(cellOrNull2.Row, (short)cellOrNull2.Column, range_0.cells_0);
										cell2.method_54(cellOrNull2);
										array[m][n] = cell2;
									}
									else
									{
										array[m][n] = cellOrNull2;
									}
								}
							}
						}
						for (int num6 = 0; num6 < num4; num6++)
						{
							if (array[num6] == null)
							{
								if (pasteOptions_0.SkipBlanks)
								{
									continue;
								}
								Row row3 = cells_0.CheckRow(num6 + Area.StartRow);
								if (row3 != null)
								{
									for (int num7 = 0; num7 < num5; num7++)
									{
										row3.GetCellOrNull(num7 + Area.StartColumn)?.Copy(null, pasteOptions_0.PasteType);
									}
								}
								continue;
							}
							for (int num8 = 0; num8 < num5; num8++)
							{
								if (array[num6][num8] == null)
								{
									if (!pasteOptions_0.SkipBlanks)
									{
										cells_0.CheckCell(num6 + Area.StartRow, num8 + Area.StartColumn)?.Copy(null, pasteOptions_0.PasteType);
									}
								}
								else
								{
									Cell cell3 = cells_0.GetCell(num6 + Area.StartRow, num8 + Area.StartColumn, bool_2: false);
									cell3.Copy(array[num6][num8], pasteOptions_0.PasteType);
								}
							}
						}
						break;
					}
				}
				for (int num9 = 0; num9 < num4; num9++)
				{
					Row row4 = range_0.cells_0.CheckRow(num9 + range_0.Area.StartRow);
					if (row4 == null)
					{
						if (pasteOptions_0.SkipBlanks)
						{
							continue;
						}
						Row row5 = cells_0.CheckRow(num9 + Area.StartRow);
						if (row5 != null)
						{
							for (int num10 = 0; num10 < num5; num10++)
							{
								row5.GetCellOrNull(num10 + Area.StartColumn)?.Copy(null, pasteOptions_0.PasteType);
							}
						}
						continue;
					}
					for (int num11 = 0; num11 < num5; num11++)
					{
						Cell cellOrNull3 = row4.GetCellOrNull(num11 + range_0.Area.StartColumn);
						if (cellOrNull3 == null)
						{
							if (!pasteOptions_0.SkipBlanks)
							{
								cells_0.CheckCell(num9 + Area.StartRow, num11 + Area.StartColumn)?.Copy(cellOrNull3, pasteOptions_0.PasteType);
							}
						}
						else
						{
							Cell cell4 = cells_0.GetCell(num9 + Area.StartRow, num11 + Area.StartColumn, bool_2: false);
							cell4.Copy(cellOrNull3, pasteOptions_0.PasteType);
						}
					}
				}
				break;
			}
			}
		}
		switch (pasteOptions_0.PasteType)
		{
		case PasteType.All:
		case PasteType.AllExceptBorders:
		case PasteType.Formats:
			method_9(range_0, pasteOptions_0.Transpose);
			cells_0.method_3().ConditionalFormattings.CopyInRange(range_0.cells_0.method_3().ConditionalFormattings, range_0.Area, Area, copyOptions_, pasteOptions_0.Transpose);
			break;
		}
		switch (pasteOptions_0.PasteType)
		{
		case PasteType.All:
		case PasteType.AllExceptBorders:
		case PasteType.Comments:
			cells_0.method_3().Comments.method_2(range_0, this, pasteOptions_0.Transpose);
			break;
		}
		switch (pasteOptions_0.PasteType)
		{
		case PasteType.All:
		case PasteType.AllExceptBorders:
		case PasteType.Validation:
			cells_0.method_3().Validations.CopyInRange(range_0.cells_0.method_3().Validations, range_0.Area, Area, copyOptions_, pasteOptions_0.Transpose);
			break;
		}
		switch (pasteOptions_0.PasteType)
		{
		case PasteType.All:
		case PasteType.AllExceptBorders:
			if (range_0.cells_0.method_3().Shapes.Count != 0 && !pasteOptions_0.Transpose)
			{
				cells_0.method_3().Shapes.CopyInRange(range_0.cells_0.method_3().Shapes, range_0.cellArea_0, cellArea_0, copyOptions_);
			}
			break;
		}
	}

	/// <summary>
	///       Copies data (including formulas), formatting, drawing objects etc. from a source range.
	///       </summary>
	/// <param name="range">Source <see cref="T:Aspose.Cells.Range" /> object.</param>
	public void Copy(Range range)
	{
		Worksheet.Workbook.method_3();
		if (cells_0 == range.cells_0 && range.FirstRow == FirstRow && range.FirstColumn == FirstColumn && range.RowCount <= RowCount && range.ColumnCount <= ColumnCount)
		{
			return;
		}
		CopyOptions copyOptions_ = new CopyOptions(bool_6: false, Enum173.const_4);
		CellArea cellArea = range.cellArea_0;
		CellArea cellArea_ = cellArea_0;
		int num = cellArea.EndRow - cellArea.StartRow + 1;
		int num2 = cellArea.EndColumn - cellArea.StartColumn + 1;
		int num3 = cellArea_.EndRow - cellArea_.StartRow + 1;
		int num4 = cellArea_.EndColumn - cellArea_.StartColumn + 1;
		if (num > num3)
		{
			num = num3;
		}
		if (num2 > num4)
		{
			num2 = num4;
		}
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			Row row = range.cells_0.CheckRow(i);
			if (row == null)
			{
				continue;
			}
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cellOrNull = row.GetCellOrNull(j);
				if (cellOrNull != null && cellOrNull.IsFormula && cellOrNull.method_46())
				{
					cellOrNull.method_48();
				}
			}
		}
		if (num == 65536)
		{
			for (int k = cellArea_.StartColumn; k < cellArea_.StartColumn + num2; k++)
			{
				int num5 = cells_0.Columns.method_7(k);
				if (num5 != -1)
				{
					cells_0.Columns.RemoveAt(num5);
				}
			}
			for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
			{
				int num6 = range.cells_0.Columns.method_7(l);
				if (num6 != -1)
				{
					Column columnByIndex = range.cells_0.Columns.GetColumnByIndex(num6);
					Column column = cells_0.Columns[columnByIndex.Index + cellArea_.StartColumn - cellArea.StartColumn];
					column.CopyData(columnByIndex);
				}
			}
		}
		if (num2 == 256)
		{
			for (int m = cellArea_.StartRow; m < cellArea_.StartRow + num; m++)
			{
				int num7 = cells_0.Rows.method_5(m);
				if (num7 != -1)
				{
					cells_0.Rows.RemoveAt(num7);
				}
			}
			for (int n = cellArea.StartRow; n <= cellArea.EndRow; n++)
			{
				int num8 = range.cells_0.Rows.method_5(n);
				if (num8 != -1)
				{
					Row rowByIndex = range.cells_0.Rows.GetRowByIndex(num8);
					Row row2 = cells_0.Rows.GetRow(rowByIndex.int_0 + cellArea_.StartRow - cellArea.StartRow, bool_0: false, bool_1: true);
					row2.CopyData(rowByIndex);
				}
			}
		}
		bool flag = false;
		if (range.cells_0 == cells_0 && cellArea_.StartRow > cellArea.StartRow && cellArea_.StartRow <= cellArea.StartRow + num && cellArea_.StartColumn >= cellArea.StartColumn && cellArea_.StartColumn <= cellArea.StartColumn + num2)
		{
			flag = true;
			for (int num9 = num - 1; num9 >= 0; num9--)
			{
				for (int num10 = num2 - 1; num10 >= 0; num10--)
				{
					Cell cell = range.cells_0.CheckCell(cellArea.StartRow + num9, cellArea.StartColumn + num10);
					if (cell != null)
					{
						Cell cell2 = cells_0.GetCell(cellArea_.StartRow + num9, cellArea_.StartColumn + num10, bool_2: false);
						cell2.Copy(cell);
					}
					else
					{
						cells_0.CheckCell(cellArea_.StartRow + num9, cellArea_.StartColumn + num10)?.method_6();
					}
				}
			}
		}
		if (!flag)
		{
			for (int num11 = 0; num11 < num; num11++)
			{
				Row row3 = range.cells_0.CheckRow(cellArea.StartRow + num11);
				if (row3 == null)
				{
					Row row4 = cells_0.CheckRow(cellArea_.StartRow + num11);
					if (row4 != null)
					{
						for (int num12 = 0; num12 < num2; num12++)
						{
							row4.GetCellOrNull(cellArea_.StartColumn + num12)?.method_6();
						}
					}
					continue;
				}
				Row row5 = cells_0.Rows.GetRow(cellArea_.StartRow + num11, bool_0: false, bool_1: true);
				for (int num13 = 0; num13 < num2; num13++)
				{
					Cell cellOrNull2 = row3.GetCellOrNull(cellArea.StartColumn + num13);
					if (cellOrNull2 != null)
					{
						Cell cell3 = row5.GetCell(cellArea_.StartColumn + num13);
						cell3.Copy(cellOrNull2);
					}
					else
					{
						row5.GetCellOrNull(cellArea_.StartColumn + num13)?.method_6();
					}
				}
			}
			method_7(cellArea_);
		}
		cells_0.method_3().Comments.method_2(range, this, bool_0: false);
		string_0 = range.string_0;
		method_9(range, bool_0: false);
		if (range.cells_0.method_3().Hyperlinks.Count != 0)
		{
			cells_0.method_3().Hyperlinks.method_6(range.cells_0.method_3().Hyperlinks, range.Area, Area);
		}
		if (range.cells_0.method_3().Shapes.Count != 0)
		{
			cells_0.method_3().Shapes.CopyInRange(range.cells_0.method_3().Shapes, range.cellArea_0, cellArea_0, copyOptions_);
		}
		if (range.cells_0.method_3().Validations.Count != 0)
		{
			cells_0.method_3().Validations.CopyInRange(range.cells_0.method_3().Validations, range.cellArea_0, cellArea_0, copyOptions_, bool_0: false);
		}
		if (range.cells_0.method_3().ConditionalFormattings.Count != 0)
		{
			cells_0.method_3().ConditionalFormattings.CopyInRange(range.cells_0.method_3().ConditionalFormattings, range.cellArea_0, cellArea_0, copyOptions_, bool_0: false);
		}
	}

	/// <summary>
	///       Gets <see cref="T:Aspose.Cells.Cell" /> object or null in this range.
	///       </summary>
	/// <param name="rowIndex">Row index in this range, zero based.</param>
	/// <param name="columnIndex">Column index in this range, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Cell" /> object.</returns>
	public Cell GetCellOrNull(int rowIndex, int columnIndex)
	{
		if (rowIndex < 0 || rowIndex >= RowCount || columnIndex < 0 || columnIndex >= ColumnCount)
		{
			throw new CellsException(ExceptionType.InvalidData, "Row or column is out of the range.");
		}
		return cells_0.CheckCell(FirstRow + rowIndex, FirstColumn + columnIndex);
	}

	/// <summary>
	///       Returns a string represents the current Range object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		if (string_0 != null)
		{
			return string.Format("Aspose.Cells.Range [ {0} : {1} ]", string_0, cells_0.method_3().Name + "!" + method_1());
		}
		return string.Format("Aspose.Cells.Range [ {0} ]", cells_0.method_3().Name + "!" + method_1());
	}

	/// <summary>
	///       Exports data in this range to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	public DataTable ExportDataTable()
	{
		return cells_0.ExportDataTable(FirstRow, FirstColumn, RowCount, ColumnCount);
	}

	/// <summary>
	///       Exports data in this range to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	/// <remarks>All data in the <see cref="T:Aspose.Cells.Cells" /> collection are converted to strings.</remarks>
	public DataTable ExportDataTableAsString()
	{
		return cells_0.ExportDataTableAsString(FirstRow, FirstColumn, RowCount, ColumnCount);
	}
}
