using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns16;
using ns2;
using ns29;
using ns58;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents a list object on a worksheet.
///       The ListObject object is a member of the ListObjects collection. 
///       The ListObjects collection contains all the list objects on a worksheet. 
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///
///       Workbook workbook = new Workbook();
///       Cells cells = workbook.Worksheets[0].Cells;
///       for (int i = 0; i  &lt;5; i++)
///       {
///       cells[0,i].PutValue(CellsHelper.ColumnIndexToName(i));
///        }
///       for (int row = 1; row  &lt;10; row++)
///       {
///        for (int column = 0; column  &lt;5; column++)
///       {
///       cells[row, column].PutValue(row * column);
///        }
///        }
///       ListObjectCollection tables = workbook.Worksheets[0].ListObjects;
///       int index = tables.Add(0, 0, 9, 4, true);
///       ListObject table = tables[0];
///       table.ShowTotals = true;
///       table.ListColumns[4].TotalsCalculation = Aspose.Cells.TotalsCalculation.Sum;
///       workbook.Save(@"C:\Book1.xlsx");
///
///
///       [Visual Basic]
///
///       Dim workbook As Workbook = New Workbook()
///       Dim cells As Cells = workbook.Worksheets(0).Cells
///       For i As Int32 = 0 To 4
///        cells(0, i).PutValue(CellsHelper.ColumnIndexToName(i))
///       Next
///       For row As Int32 = 1 To 9
///        For column As Int32 = 0 To 4
///         cells(row, column).PutValue(row * column)
///       Next
///       Next
///       Dim tables As ListObjectCollection = workbook.Worksheets(0).ListObjects
///       Dim index As Int32 = tables.Add(0, 0, 9, 4, True)
///       Dim table As ListObject = tables(0)
///       table.ShowTotals = True
///       table.ListColumns(4).TotalsCalculation = Aspose.Cells.TotalsCalculation.Sum
///       workbook.Save("C:\Book1.xlsx")
///       </code>
/// </example>
public class ListObject
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private string string_0;

	private ListColumnCollection listColumnCollection_0;

	private ListObjectCollection listObjectCollection_0;

	internal DataSorter dataSorter_0;

	internal Hashtable hashtable_0;

	internal byte[] byte_0;

	private Enum234 enum234_0;

	private uint uint_0;

	private string string_1;

	private string string_2;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9 = -1;

	private byte[] byte_1;

	private AutoFilter autoFilter_0;

	private string string_3;

	private string string_4;

	private byte byte_2 = 4;

	private Style[][] style_0;

	private Hashtable[] hashtable_1;

	private object object_0;

	internal Style style_1;

	internal Style style_2;

	internal Style style_3;

	internal int[] int_10 = new int[6] { -1, -1, -1, -1, -1, -1 };

	private int int_11 = 1;

	private int int_12;

	/// <summary>
	///       Gets the start row of the range.
	///       </summary>
	public int StartRow => int_1;

	/// <summary>
	///       Gets the start column of the range.
	///       </summary>
	public int StartColumn => int_3;

	/// <summary>
	///       Gets the end  row of the range.
	///       </summary>
	public int EndRow => int_2;

	/// <summary>
	///       Gets the end column of the range.
	///       </summary>
	public int EndColumn => int_4;

	/// <summary>
	///       Gets ListColumns of the ListObject.
	///       </summary>
	public ListColumnCollection ListColumns => listColumnCollection_0;

	/// <summary>
	///       Gets and sets whether this ListObject show header row.
	///       </summary>
	public bool ShowHeaderRow
	{
		get
		{
			return method_48() == 1;
		}
		set
		{
			if (method_48() == 1 == value)
			{
				return;
			}
			if (value)
			{
				method_7();
				Cells cells = method_12().method_4().Cells;
				Cell cell = cells.GetCell(StartRow, StartColumn, bool_2: false);
				Style style = cell.method_28();
				style.Font.IsBold = true;
				cell.method_30(style);
				for (int i = 1; i < ListColumns.Count; i++)
				{
					cell = cells.GetCell(StartRow, StartColumn + i, bool_2: false);
					cell.method_37(cell.method_36());
				}
				if (method_48() == 0)
				{
					method_49(1);
				}
			}
			else
			{
				if (method_48() == 1)
				{
					method_8();
				}
				method_49(0);
			}
		}
	}

	/// <summary>
	///       Gets and sets whether this ListObject show total row.
	///       </summary>
	public bool ShowTotals
	{
		get
		{
			return method_19();
		}
		set
		{
			if (method_19() == value)
			{
				return;
			}
			method_20(value);
			if (value)
			{
				method_9();
				Cells cells = method_12().method_4().Cells;
				Cell cell = cells.GetCell(EndRow, StartColumn, bool_2: false);
				cell.PutValue("Total");
				Style style = cell.method_28();
				style.Font.IsBold = true;
				cell.method_30(style);
				for (int i = 1; i < ListColumns.Count; i++)
				{
					cell = cells.GetCell(EndRow, StartColumn + i, bool_2: false);
					cell.method_37(cell.method_36());
					if (ListColumns[i].method_16() != null)
					{
						cell.PutValue(ListColumns[i].method_16());
					}
				}
				ListColumn listColumn = ListColumns[ListColumns.Count - 1];
				if (listColumn.method_16() == null && listColumn.TotalsCalculation == TotalsCalculation.None)
				{
					ListColumns[ListColumns.Count - 1].TotalsCalculation = TotalsCalculation.Sum;
				}
				if (method_51() == 0)
				{
					method_52(1);
				}
			}
			else
			{
				if (ListColumns.method_1())
				{
					method_10();
				}
				method_52(0);
			}
		}
	}

	/// <summary>
	///       Gets the data range of the ListObject.
	///       </summary>
	public Range DataRange
	{
		get
		{
			int num = EndRow - StartRow;
			int num2 = StartRow + 1;
			if (!ShowHeaderRow)
			{
				num++;
				num2 = StartRow;
			}
			if (ShowTotals)
			{
				num--;
			}
			return new Range((ushort)num2, (byte)StartColumn, num, (short)ListColumns.Count, method_12().method_4().Cells);
		}
	}

	/// <summary>
	///       Gets auto filter.
	///       </summary>
	public AutoFilter AutoFilter
	{
		get
		{
			if (autoFilter_0 == null)
			{
				autoFilter_0 = new AutoFilter(listObjectCollection_0.method_4(), this);
			}
			return autoFilter_0;
		}
	}

	/// <summary>
	///       Gets and sets the display name.
	///       </summary>
	public string DisplayName
	{
		get
		{
			if (string_3 == null)
			{
				return string_0;
			}
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	/// <summary>
	///       Inidicates whether the first column in the table should have the style applied.
	///       </summary>
	public bool ShowTableStyleFirstColumn
	{
		get
		{
			return (byte_2 & 1) != 0;
		}
		set
		{
			if (value)
			{
				byte_2 |= 1;
			}
			else
			{
				byte_2 &= 254;
			}
		}
	}

	/// <summary>
	///       Indicates whether the last column in the table should have the style applied.
	///       </summary>
	public bool ShowTableStyleLastColumn
	{
		get
		{
			return (byte_2 & 2) != 0;
		}
		set
		{
			if (value)
			{
				byte_2 |= 2;
			}
			else
			{
				byte_2 &= 253;
			}
		}
	}

	/// <summary>
	///       Indicates whether row stripe formatting is applied.
	///       </summary>
	public bool ShowTableStyleRowStripes
	{
		get
		{
			return (byte_2 & 4) != 0;
		}
		set
		{
			if (value)
			{
				byte_2 |= 4;
			}
			else
			{
				byte_2 &= 251;
			}
		}
	}

	/// <summary>
	///       Indicates whether column stripe formatting is applied.
	///       </summary>
	public bool ShowTableStyleColumnStripes
	{
		get
		{
			return (byte_2 & 8) != 0;
		}
		set
		{
			if (value)
			{
				byte_2 |= 8;
			}
			else
			{
				byte_2 &= 247;
			}
		}
	}

	/// <summary>
	///       Gets and the built-in table style.
	///       </summary>
	public TableStyleType TableStyleType
	{
		get
		{
			if (object_0 == null)
			{
				return TableStyleType.None;
			}
			if (object_0 is string)
			{
				return TableStyleType.Custom;
			}
			return (TableStyleType)object_0;
		}
		set
		{
			object_0 = value;
			style_0 = null;
		}
	}

	/// <summary>
	///       Gets and sets the table style name.
	///       </summary>
	public string TableStyleName
	{
		get
		{
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is string)
			{
				return (string)object_0;
			}
			return Class1736.smethod_0((TableStyleType)object_0);
		}
		set
		{
			TableStyleType tableStyleType = Class1736.smethod_1(value);
			if (tableStyleType != TableStyleType.Custom)
			{
				object_0 = tableStyleType;
			}
			else
			{
				object_0 = value;
			}
			style_0 = null;
		}
	}

	internal string Name => string_0;

	internal string Comment
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	internal ListObject(ListObjectCollection listObjectCollection_1, string string_5, int int_13)
	{
		listObjectCollection_0 = listObjectCollection_1;
		string_0 = string_5;
		string_3 = string_5;
		int_0 = int_13;
		autoFilter_0 = new AutoFilter(method_12().method_4(), this);
		if (method_12().method_4().method_2().method_91() == null)
		{
			object_0 = TableStyleType.TableStyleMedium9;
		}
	}

	internal ListObject(ListObjectCollection listObjectCollection_1)
	{
		listObjectCollection_0 = listObjectCollection_1;
		autoFilter_0 = new AutoFilter(method_12().method_4(), this);
		listColumnCollection_0 = new ListColumnCollection(this);
	}

	internal void Copy(ListObject listObject_0)
	{
		int_0 = listObject_0.int_0;
		string_0 = listObject_0.string_0;
		string_3 = listObject_0.string_3;
		if (listObject_0.byte_0 != null)
		{
			byte_0 = new byte[listObject_0.byte_0.Length];
			Array.Copy(listObject_0.byte_0, byte_0, byte_0.Length);
		}
		hashtable_0 = listObject_0.hashtable_0;
		int_1 = listObject_0.int_1;
		int_2 = listObject_0.int_2;
		int_3 = listObject_0.int_3;
		int_4 = listObject_0.int_4;
		if (listObject_0.autoFilter_0 != null)
		{
			autoFilter_0 = new AutoFilter(method_12().method_4(), this);
			autoFilter_0.Copy(listObject_0.autoFilter_0);
		}
		int_6 = listObject_0.int_6;
		int_7 = listObject_0.int_7;
		string_4 = listObject_0.string_4;
		int_9 = listObject_0.int_9;
		string_1 = listObject_0.string_1;
		enum234_0 = listObject_0.enum234_0;
		string_2 = listObject_0.string_2;
		byte_1 = listObject_0.byte_1;
		int_11 = listObject_0.int_11;
		int_8 = listObject_0.int_8;
		uint_0 = listObject_0.uint_0;
		int_5 = listObject_0.int_5;
		byte_2 = listObject_0.byte_2;
		object_0 = listObject_0.object_0;
		if (method_12().method_4().method_2() != listObject_0.method_12().method_4().method_2() && listObject_0.object_0 != null && listObject_0.object_0 is string)
		{
			string name = (string)listObject_0.object_0;
			WorksheetCollection worksheetCollection = method_12().method_4().method_2();
			TableStyleCollection tableStyles = worksheetCollection.TableStyles;
			TableStyle tableStyle = tableStyles[name];
			if (tableStyle == null)
			{
				int index = tableStyles.AddTableStyle(name);
				tableStyle = tableStyles[index];
				WorksheetCollection worksheetCollection2 = listObject_0.method_12().method_4().method_2();
				TableStyleCollection tableStyles2 = worksheetCollection2.TableStyles;
				TableStyle tableStyle2 = tableStyles2[name];
				if (tableStyle2 != null)
				{
					tableStyle.Copy(tableStyle2);
				}
			}
		}
		int_12 = listObject_0.int_12;
		listColumnCollection_0 = new ListColumnCollection(this);
		listColumnCollection_0.Copy(listObject_0.ListColumns);
		for (int i = 0; i < listObject_0.int_10.Length; i++)
		{
			int_10[i] = listObject_0.int_10[i];
			if (listObject_0.int_10[i] != -1 && method_1() != listObject_0.method_1())
			{
				int_10[i] = method_1().method_56().Add(listObject_0.method_1().method_56()[i]);
			}
		}
	}

	[SpecialName]
	private WorksheetCollection method_1()
	{
		return method_12().method_4().method_2();
	}

	internal void method_2(int int_13)
	{
		int_1 = int_13;
	}

	internal void method_3(int int_13)
	{
		int_3 = int_13;
	}

	internal void method_4(int int_13)
	{
		int_2 = int_13;
	}

	internal void method_5(int int_13)
	{
		int_4 = int_13;
	}

	internal void method_6(ListColumnCollection listColumnCollection_1)
	{
		listColumnCollection_0 = listColumnCollection_1;
	}

	public void Resize(int startRow, int startColumn, int endRow, int endColumn, bool hasHeaders)
	{
		int_1 = startRow;
		int_3 = startColumn;
		int_2 = endRow + ((!hasHeaders) ? 1 : 0);
		int_4 = endColumn;
		AutoFilter.SetRange(startRow, startColumn, endColumn);
		listColumnCollection_0 = new ListColumnCollection(this);
		Cells cells = listObjectCollection_0.method_4().Cells;
		if (!hasHeaders)
		{
			CellArea area = default(CellArea);
			area.StartRow = startRow;
			area.StartColumn = startColumn;
			area.EndRow = endRow;
			area.EndColumn = endColumn;
			cells.InsertRange(area, 1, ShiftType.Down);
		}
		for (int i = 1; i <= int_4 - int_3 + 1; i++)
		{
			string text = null;
			if (hasHeaders)
			{
				Cell cell = cells.GetCell(int_1, i + int_3 - 1, bool_2: false);
				if (cell != null && !(cell.StringValue == ""))
				{
					text = cell.StringValue;
					cell.PutValue(text);
				}
				else
				{
					text = "Column" + i;
					cell.PutValue(text);
				}
			}
			else
			{
				Cell cell2 = cells.GetCell(int_1, i + int_3 - 1, bool_2: false);
				text = "Column" + i;
				cell2.PutValue(text);
			}
			ListColumn listColumn_ = new ListColumn(listColumnCollection_0, text, i - 1);
			listColumnCollection_0.Add(listColumn_);
		}
		for (int j = 0; j < ListColumns.Count; j++)
		{
			Cell cell3 = cells.GetCell(StartRow, StartColumn + j, bool_2: false);
			Style style = cell3.method_28();
			style.Font.IsBold = true;
			cell3.method_30(style);
		}
	}

	internal void method_7()
	{
		Cells cells = method_12().method_4().Cells;
		int_1--;
		Row row = cells.Rows.GetRow(int_1, bool_0: false, bool_1: true);
		for (int i = 0; i < ListColumns.Count; i++)
		{
			row[int_3 + i].PutValue(ListColumns[i].Name);
		}
		int num = EndRow;
		if (ListColumns.method_1())
		{
			num--;
		}
		AutoFilter.Range = CellsHelper.CellIndexToName(StartRow, StartColumn) + ":" + CellsHelper.CellIndexToName(num, EndColumn);
	}

	internal void method_8()
	{
		Cells cells = method_12().method_4().Cells;
		cells.Rows.RemoveAt(0);
		int_1++;
		AutoFilter.Range = null;
	}

	internal void method_9()
	{
		Cells cells = method_12().method_4().Cells;
		int_2++;
		CellArea area = default(CellArea);
		area.StartColumn = StartColumn;
		area.EndColumn = EndColumn;
		area.StartRow = EndRow;
		area.EndRow = EndRow;
		cells.InsertRange(area, ShiftType.Down);
	}

	internal void method_10()
	{
		Cells cells = method_12().method_4().Cells;
		cells.DeleteRange(EndRow, (byte)StartColumn, EndRow, (byte)EndColumn, ShiftType.Up);
		int_2--;
	}

	/// <summary>
	///       Updates all list columns' name from the worksheet.
	///       </summary>
	/// <remarks>
	///       The value of the cells in the header row of the table must be same as the name of the ListColumn;
	///       Cell.PutValue do not auto modify the name of the ListColumn for performance. 
	///       </remarks>
	public void UpdateColumnName()
	{
		if (!ShowHeaderRow)
		{
			return;
		}
		Cells cells = method_12().method_4().Cells;
		Row row = cells.CheckRow(int_1);
		if (row == null)
		{
			return;
		}
		for (int i = 0; i < listColumnCollection_0.Count; i++)
		{
			ListColumn listColumn = listColumnCollection_0[i];
			Cell cell = row.GetCell(listColumn.method_5());
			switch (cell.Type)
			{
			default:
				cell.PutValue(cell.StringValue);
				listColumn.method_2(cell.StringValue.Replace("\r", ""));
				break;
			case CellValueType.IsString:
				listColumn.method_2(cell.StringValue.Replace("\r", ""));
				break;
			case CellValueType.IsNull:
				break;
			}
		}
	}

	internal bool InsertColumns(int int_13, int int_14)
	{
		if (int_14 == 0)
		{
			return false;
		}
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartColumn = int_3;
		cellArea_.EndColumn = int_4;
		cellArea_.StartRow = int_1;
		cellArea_.EndRow = int_2;
		bool bool_ = false;
		cellArea_ = Class1678.InsertColumns(cellArea_, int_13, int_14, ref bool_);
		if (bool_)
		{
			return true;
		}
		if (int_14 < 0)
		{
			int num = int_13 - int_14 - 1;
			if (num >= int_3)
			{
				if (int_13 < int_3)
				{
					int num2 = num - int_3 + 1;
					for (int i = 0; i < num2; i++)
					{
						listColumnCollection_0.RemoveAt(0);
					}
					for (int j = 0; j < listColumnCollection_0.Count; j++)
					{
						ListColumn listColumn = listColumnCollection_0[j];
						listColumn.method_4(listColumn.Index - num2);
					}
				}
				else if (int_13 <= int_4)
				{
					int num3 = int_13 - int_3;
					if (num < int_4)
					{
						for (int k = 0; k < -int_14; k++)
						{
							listColumnCollection_0.RemoveAt(num3);
						}
						for (int l = num3; l < listColumnCollection_0.Count; l++)
						{
							ListColumn listColumn2 = listColumnCollection_0[l];
							listColumn2.method_4(listColumn2.Index + int_14);
						}
					}
					else
					{
						int num4 = int_4 - int_13 + 1;
						for (int m = 0; m < num4; m++)
						{
							listColumnCollection_0.RemoveAt(num3);
						}
					}
				}
			}
		}
		else if (int_13 > int_3 && int_13 <= int_4)
		{
			int num5 = int_13 - int_3;
			int count = ListColumns.Count;
			for (int n = 0; n < int_14; n++)
			{
				ListColumn listColumn3 = new ListColumn(ListColumns);
				listColumn3.method_4(n + num5);
				listColumn3.Name = "Column" + (n + count + 1);
				listColumnCollection_0.Insert(num5 + n, listColumn3);
			}
			for (num5 += int_14; num5 < listColumnCollection_0.Count; num5++)
			{
				ListColumn listColumn4 = listColumnCollection_0[num5];
				listColumn4.method_4(listColumn4.Index + int_14);
			}
		}
		int_1 = cellArea_.StartRow;
		int_3 = cellArea_.StartColumn;
		int_2 = cellArea_.EndRow;
		int_4 = cellArea_.EndColumn;
		if (autoFilter_0 != null)
		{
			autoFilter_0.InsertColumn(int_13, int_14);
		}
		return false;
	}

	internal bool method_11(int int_13, int int_14, int int_15, int int_16)
	{
		if (int_14 <= int_4 && int_14 + int_16 - 1 >= int_3)
		{
			int num = int_13 + int_15 - 1;
			if (num >= int_1 && int_13 <= int_1)
			{
				return num >= int_2;
			}
			return true;
		}
		return true;
	}

	internal bool InsertRows(int int_13, int int_14)
	{
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartColumn = int_3;
		cellArea_.EndColumn = int_4;
		cellArea_.StartRow = int_1;
		cellArea_.EndRow = int_2;
		bool bool_ = false;
		cellArea_ = Class1678.InsertRows(cellArea_, int_13, int_14, ref bool_);
		if (bool_)
		{
			return true;
		}
		if (int_14 < 0 && cellArea_.StartRow == cellArea_.EndRow)
		{
			cellArea_.EndRow++;
		}
		int_1 = cellArea_.StartRow;
		int_3 = cellArea_.StartColumn;
		int_2 = cellArea_.EndRow;
		int_4 = cellArea_.EndColumn;
		for (int i = 0; i < listColumnCollection_0.Count; i++)
		{
			ListColumn listColumn = listColumnCollection_0[i];
			listColumn.InsertRows(int_13, int_14);
		}
		return false;
	}

	internal bool InsertRange(CellArea cellArea_0, int int_13, ShiftType shiftType_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			if (cellArea_0.StartColumn <= StartColumn && cellArea_0.EndColumn >= EndColumn)
			{
				return InsertRows(cellArea_0.StartRow, int_13);
			}
			break;
		case ShiftType.Left:
			if (cellArea_0.StartRow <= StartRow && cellArea_0.EndRow >= EndRow)
			{
				return InsertColumns(cellArea_0.StartColumn, -int_13);
			}
			break;
		case ShiftType.Right:
			if (cellArea_0.StartRow <= StartRow && cellArea_0.EndRow >= EndRow)
			{
				return InsertColumns(cellArea_0.StartColumn, int_13);
			}
			break;
		case ShiftType.Up:
			if (cellArea_0.StartColumn <= StartColumn && cellArea_0.EndColumn >= EndColumn)
			{
				return InsertRows(cellArea_0.StartRow, -int_13);
			}
			break;
		}
		return false;
	}

	[SpecialName]
	internal ListObjectCollection method_12()
	{
		return listObjectCollection_0;
	}

	[SpecialName]
	internal Enum234 method_13()
	{
		return enum234_0;
	}

	[SpecialName]
	internal void method_14(Enum234 enum234_1)
	{
		enum234_0 = enum234_1;
	}

	[SpecialName]
	internal uint method_15()
	{
		return uint_0;
	}

	[SpecialName]
	internal void method_16(uint uint_1)
	{
		uint_0 = uint_1;
	}

	[SpecialName]
	internal bool method_17()
	{
		return (uint_0 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_18(bool bool_0)
	{
		if (bool_0)
		{
			uint_0 |= 16u;
		}
		else
		{
			uint_0 &= 4294967279u;
		}
	}

	[SpecialName]
	internal bool method_19()
	{
		return (uint_0 & 0x40) != 0;
	}

	[SpecialName]
	internal void method_20(bool bool_0)
	{
		if (bool_0)
		{
			uint_0 |= 64u;
		}
		else
		{
			uint_0 &= 4294967231u;
		}
	}

	[SpecialName]
	internal bool method_21()
	{
		return (uint_0 & 0x200) != 0;
	}

	[SpecialName]
	internal void method_22(bool bool_0)
	{
		if (bool_0)
		{
			uint_0 |= 512u;
		}
		else
		{
			uint_0 &= 4294966783u;
		}
	}

	[SpecialName]
	internal bool method_23()
	{
		return (uint_0 & 0x4000) != 0;
	}

	[SpecialName]
	internal bool method_24()
	{
		return (uint_0 & 0x100000) != 0;
	}

	[SpecialName]
	internal bool method_25()
	{
		return (uint_0 & 0x1000000) != 0;
	}

	[SpecialName]
	internal void method_26(bool bool_0)
	{
		if (bool_0)
		{
			uint_0 |= 16777216u;
		}
		else
		{
			uint_0 &= 4278190079u;
		}
	}

	[SpecialName]
	internal void method_27(string string_5)
	{
		string_1 = string_5;
	}

	[SpecialName]
	internal void method_28(string string_5)
	{
		string_2 = string_5;
	}

	[SpecialName]
	internal void method_29(int int_13)
	{
		int_5 = int_13;
	}

	[SpecialName]
	internal void method_30(int int_13)
	{
		int_6 = int_13;
	}

	[SpecialName]
	internal void method_31(int int_13)
	{
		int_7 = int_13;
	}

	[SpecialName]
	internal void method_32(int int_13)
	{
		int_8 = int_13;
	}

	[SpecialName]
	internal int method_33()
	{
		return int_9;
	}

	[SpecialName]
	internal void method_34(int int_13)
	{
		int_9 = int_13;
	}

	[SpecialName]
	internal byte[] method_35()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_36(byte[] byte_3)
	{
		byte_1 = byte_3;
	}

	internal AutoFilter method_37()
	{
		return autoFilter_0;
	}

	[SpecialName]
	internal byte method_38()
	{
		return byte_2;
	}

	public void ApplyStyleToRange()
	{
		Style defaultStyle = method_1().DefaultStyle;
		for (int i = StartRow; i <= EndRow; i++)
		{
			Row row = method_12().method_4().Cells.Rows[i];
			for (int j = StartColumn; j <= EndColumn; j++)
			{
				Style cellStyle = GetCellStyle(i, j);
				Cell cell = row.GetCell(j, bool_1: false, bool_2: true);
				Style style = cell.GetStyle();
				Class1627.smethod_4(style, cellStyle, defaultStyle);
				cell.SetStyle(style);
			}
		}
	}

	public void ConvertToRange()
	{
		ApplyStyleToRange();
		method_12().Remove(this);
	}

	internal Style GetCellStyle(int int_13, int int_14)
	{
		Style[][] array = method_39(int_13, int_14);
		int num = int_13 - int_1;
		int num2 = int_14 - int_3;
		return array[num][num2];
	}

	internal Style[][] method_39(int int_13, int int_14)
	{
		int num = int_2 - int_1 + 1;
		int num2 = int_4 - int_3 + 1;
		int i = 0;
		if (style_0 == null)
		{
			style_0 = new Style[num][];
			hashtable_1 = new Hashtable[num2];
			int num3 = int_2;
			int num4 = method_12().method_4().Cells.MaxRow + 1;
			if (int_2 > num4)
			{
				num3 = num4;
			}
			if (num3 < int_1)
			{
				num3 = int_1;
			}
			num = num3 - int_1 + 1;
		}
		else
		{
			int num5 = int_13 - int_1;
			if (style_0[num5] == null)
			{
				for (; i < num && style_0[i] != null; i++)
				{
				}
				if (int_13 != int_2)
				{
					num = num5 + 2;
				}
			}
			else
			{
				if (num5 + 1 >= num || style_0[num5] != null)
				{
					return style_0;
				}
				i = num5 + 1;
				num = num5 + 2;
			}
		}
		Style[][] array = style_0;
		Hashtable[] array2 = new Hashtable[num2];
		TableStyle tableStyle = method_41();
		for (; i < num; i++)
		{
			array[i] = new Style[num2];
			for (int j = 0; j < num2; j++)
			{
				array[i][j] = GetCellStyle(tableStyle, i + int_1, j + int_3, out var bordersElementType);
				array2[j] = bordersElementType;
				if (i > 0)
				{
					if (array[i][j].IsModified(StyleModifyFlag.TopBorder) && (int)array2[j][BorderType.TopBorder] > (int)hashtable_1[j][BorderType.BottomBorder])
					{
						array[i - 1][j].Borders[BorderType.BottomBorder].Copy(array[i][j].Borders[BorderType.TopBorder]);
						array[i - 1][j].method_36(StyleModifyFlag.BottomBorder);
					}
					if (array[i - 1][j].IsModified(StyleModifyFlag.BottomBorder) && (int)hashtable_1[j][BorderType.BottomBorder] > (int)array2[j][BorderType.TopBorder])
					{
						array[i][j].Borders[BorderType.TopBorder].Copy(array[i - 1][j].Borders[BorderType.BottomBorder]);
						array[i][j].method_36(StyleModifyFlag.TopBorder);
					}
				}
				if (j > 0)
				{
					if (array[i][j].IsModified(StyleModifyFlag.LeftBorder) && (int)array2[j][BorderType.LeftBorder] > (int)array2[j - 1][BorderType.RightBorder])
					{
						array[i][j - 1].Borders[BorderType.RightBorder].Copy(array[i][j].Borders[BorderType.LeftBorder]);
						array[i][j - 1].method_36(StyleModifyFlag.RightBorder);
					}
					if (array[i][j - 1].IsModified(StyleModifyFlag.RightBorder) && (int)array2[j - 1][BorderType.RightBorder] > (int)array2[j][BorderType.LeftBorder])
					{
						array[i][j].Borders[BorderType.LeftBorder].Copy(array[i][j - 1].Borders[BorderType.RightBorder]);
						array[i][j].method_36(StyleModifyFlag.LeftBorder);
					}
				}
			}
			hashtable_1 = array2;
		}
		return style_0;
	}

	internal Style GetCellStyle(TableStyle tableStyle, int row, int column, out Hashtable bordersElementType)
	{
		bordersElementType = new Hashtable();
		bordersElementType.Add(BorderType.TopBorder, -1);
		bordersElementType.Add(BorderType.BottomBorder, -1);
		bordersElementType.Add(BorderType.LeftBorder, -1);
		bordersElementType.Add(BorderType.RightBorder, -1);
		if (row >= int_1 && row <= int_2 && column >= int_3 && column <= int_4)
		{
			Style style = new Style(method_1());
			if (tableStyle == null)
			{
				return style;
			}
			bool flag = false;
			int num = int_1;
			if (method_48() > 0 && ShowTotals)
			{
				flag = row > int_1 && row < int_2;
				num++;
			}
			else if (method_48() == 0 && ShowTotals)
			{
				flag = row >= int_1 && row < int_2;
			}
			else if (method_48() > 0 && !ShowTotals)
			{
				flag = row > int_1 && row <= int_2;
				num++;
			}
			else
			{
				flag = row >= int_1 && row <= int_2;
			}
			style = SetStyle(style, tableStyle, TableStyleElementType.WholeTable, row, column, -1, -1, bordersElementType);
			if (ShowTableStyleColumnStripes)
			{
				TableStyleElement tableStyleElement = tableStyle.TableStyleElements[TableStyleElementType.FirstColumnStripe];
				TableStyleElement tableStyleElement2 = tableStyle.TableStyleElements[TableStyleElementType.SecondColumnStripe];
				int num2 = 1;
				if (tableStyleElement != null)
				{
					num2 = tableStyleElement.Size;
				}
				int num3 = 1;
				if (tableStyleElement2 != null)
				{
					num3 = tableStyleElement2.Size;
				}
				int num4 = num2 + num3;
				int num5 = (column - int_3) % num4;
				if (flag && num5 >= 0 && num5 < num2)
				{
					style = SetStyle(style, tableStyle, TableStyleElementType.FirstColumnStripe, row, column, num5, num2, bordersElementType);
				}
				int num6 = num5 - num2;
				if (flag && num6 >= 0 && num6 < num3)
				{
					style = SetStyle(style, tableStyle, TableStyleElementType.SecondColumnStripe, row, column, num6, num3, bordersElementType);
				}
			}
			if (ShowTableStyleRowStripes)
			{
				TableStyleElement tableStyleElement3 = tableStyle.TableStyleElements[TableStyleElementType.FirstRowStripe];
				TableStyleElement tableStyleElement4 = tableStyle.TableStyleElements[TableStyleElementType.SecondRowStripe];
				int num7 = 1;
				if (tableStyleElement3 != null)
				{
					num7 = tableStyleElement3.Size;
				}
				int num8 = 1;
				if (tableStyleElement4 != null)
				{
					num8 = tableStyleElement4.Size;
				}
				int num9 = num7 + num8;
				int num10 = (row - num) % num9;
				if (flag && num10 >= 0 && num10 < num7)
				{
					style = SetStyle(style, tableStyle, TableStyleElementType.FirstRowStripe, row, column, num10, num7, bordersElementType);
				}
				int num11 = num10 - num7;
				if (flag && num11 >= 0 && num11 < num8)
				{
					style = SetStyle(style, tableStyle, TableStyleElementType.SecondRowStripe, row, column, num11, num8, bordersElementType);
				}
			}
			if (ShowTableStyleLastColumn && column == int_4)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.LastColumn, row, column, -1, -1, bordersElementType);
			}
			if (ShowTableStyleFirstColumn && column == int_3)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.FirstColumn, row, column, -1, -1, bordersElementType);
			}
			if (method_48() > 0 && row == int_1)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.HeaderRow, row, column, -1, -1, bordersElementType);
			}
			if (ShowTotals && row == int_2)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.TotalRow, row, column, -1, -1, bordersElementType);
			}
			if (method_48() > 0 && row == int_1 && column == int_3)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.FirstHeaderCell, row, column, -1, -1, bordersElementType);
			}
			if (method_48() > 0 && row == int_1 && column == int_4)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.LastHeaderCell, row, column, -1, -1, bordersElementType);
			}
			if (ShowTotals && row == int_2 && column == int_3)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.FirstTotalCell, row, column, -1, -1, bordersElementType);
			}
			if (ShowTotals && row == int_2 && column == int_4)
			{
				style = SetStyle(style, tableStyle, TableStyleElementType.LastTotalCell, row, column, -1, -1, bordersElementType);
			}
			return style;
		}
		return null;
	}

	private Style SetStyle(Style style_4, TableStyle tableStyle_0, TableStyleElementType tableStyleElementType_0, int int_13, int int_14, int int_15, int int_16, Hashtable hashtable_2)
	{
		TableStyleElement tableStyleElement = tableStyle_0.TableStyleElements[tableStyleElementType_0];
		Class1686 class1686_ = method_40(tableStyleElementType_0, int_13, int_14, int_15, int_16);
		if (tableStyleElement != null && tableStyleElement.method_1() != null)
		{
			Class1627.smethod_5(style_4, tableStyleElement.method_1(), class1686_, tableStyleElementType_0, hashtable_2);
		}
		return style_4;
	}

	private Class1686 method_40(TableStyleElementType tableStyleElementType_0, int int_13, int int_14, int int_15, int int_16)
	{
		Class1686 @class = new Class1686();
		int num = int_13 - 1;
		int num2 = int_13 + 1;
		int num3 = int_14 - 1;
		int num4 = int_14 + 1;
		int num5 = int_15 - 1;
		int num6 = int_15 + 1;
		switch (tableStyleElementType_0)
		{
		default:
			if (int_13 == int_1)
			{
				@class.bool_0 = true;
				if (int_13 == int_2)
				{
					@class.bool_1 = true;
				}
				else if (num2 <= int_2)
				{
					@class.bool_5 = true;
				}
			}
			else if (int_13 == int_2)
			{
				@class.bool_1 = true;
				if (int_13 == int_1)
				{
					@class.bool_0 = true;
				}
				else if (num >= int_1)
				{
					@class.bool_4 = true;
				}
			}
			else if (int_13 > int_1 && int_13 < int_2)
			{
				@class.bool_4 = true;
				@class.bool_5 = true;
			}
			if (int_14 == int_3)
			{
				@class.bool_2 = true;
				if (int_14 == int_4)
				{
					@class.bool_3 = true;
				}
				else if (num4 <= int_4)
				{
					@class.bool_7 = true;
				}
			}
			else if (int_14 == int_4)
			{
				@class.bool_3 = true;
				if (int_14 == int_3)
				{
					@class.bool_2 = true;
				}
				else if (num3 >= int_3)
				{
					@class.bool_6 = true;
				}
			}
			else if (int_14 > int_3 && int_14 < int_4)
			{
				@class.bool_6 = true;
				@class.bool_7 = true;
			}
			break;
		case TableStyleElementType.FirstColumnStripe:
		case TableStyleElementType.SecondColumnStripe:
			if (int_15 == 0)
			{
				@class.bool_2 = true;
				if (int_15 == int_16 - 1)
				{
					@class.bool_3 = true;
				}
				else if (num6 <= int_16 - 1)
				{
					@class.bool_7 = true;
				}
			}
			else if (int_15 == int_16 - 1)
			{
				@class.bool_3 = true;
				if (int_15 == 0)
				{
					@class.bool_2 = true;
				}
				else if (num5 >= 0)
				{
					@class.bool_6 = true;
				}
			}
			else if (int_15 > 0 && int_15 < int_16 - 1)
			{
				@class.bool_6 = true;
				@class.bool_7 = true;
			}
			if (int_13 == int_1)
			{
				@class.bool_0 = true;
				if (int_13 == int_2)
				{
					@class.bool_1 = true;
				}
				else if (num2 <= int_2)
				{
					@class.bool_5 = true;
				}
			}
			else if (int_13 == int_2)
			{
				@class.bool_1 = true;
				if (int_13 == int_1)
				{
					@class.bool_0 = true;
				}
				else if (num >= int_1)
				{
					@class.bool_4 = true;
				}
			}
			else if (int_13 > int_1 && int_13 < int_2)
			{
				@class.bool_4 = true;
				@class.bool_5 = true;
			}
			break;
		case TableStyleElementType.FirstRowStripe:
		case TableStyleElementType.SecondRowStripe:
			if (int_15 == 0)
			{
				@class.bool_0 = true;
				if (int_15 == int_16 - 1)
				{
					@class.bool_1 = true;
				}
				else if (num6 <= int_16 - 1)
				{
					@class.bool_5 = true;
				}
			}
			else if (int_15 == int_16 - 1)
			{
				@class.bool_1 = true;
				if (int_15 == 0)
				{
					@class.bool_0 = true;
				}
				else if (num5 >= 0)
				{
					@class.bool_4 = true;
				}
			}
			else if (int_15 > 0 && int_15 < int_16 - 1)
			{
				@class.bool_4 = true;
				@class.bool_5 = true;
			}
			if (int_14 == int_3)
			{
				@class.bool_2 = true;
				if (int_14 == int_4)
				{
					@class.bool_3 = true;
				}
				else if (num4 <= int_4)
				{
					@class.bool_7 = true;
				}
			}
			else if (int_14 == int_4)
			{
				@class.bool_3 = true;
				if (int_14 == int_3)
				{
					@class.bool_2 = true;
				}
				else if (num3 >= int_3)
				{
					@class.bool_6 = true;
				}
			}
			else if (int_14 > int_3 && int_14 < int_4)
			{
				@class.bool_6 = true;
				@class.bool_7 = true;
			}
			break;
		case TableStyleElementType.LastColumn:
		case TableStyleElementType.FirstColumn:
			@class.bool_3 = true;
			@class.bool_2 = true;
			if (int_13 == int_1)
			{
				@class.bool_0 = true;
				if (int_13 == int_2)
				{
					@class.bool_1 = true;
				}
				else if (num2 <= int_2)
				{
					@class.bool_5 = true;
				}
			}
			else if (int_13 == int_2)
			{
				@class.bool_1 = true;
				if (int_13 == int_1)
				{
					@class.bool_0 = true;
				}
				else if (num >= int_1)
				{
					@class.bool_4 = true;
				}
			}
			else if (int_13 > int_1 && int_13 < int_2)
			{
				@class.bool_4 = true;
				@class.bool_5 = true;
			}
			break;
		case TableStyleElementType.HeaderRow:
		case TableStyleElementType.TotalRow:
			@class.bool_1 = true;
			@class.bool_0 = true;
			if (int_14 == int_3)
			{
				@class.bool_2 = true;
				if (int_14 == int_4)
				{
					@class.bool_3 = true;
				}
				else if (num4 <= int_4)
				{
					@class.bool_7 = true;
				}
			}
			else if (int_14 == int_4)
			{
				@class.bool_3 = true;
				if (int_14 == int_3)
				{
					@class.bool_2 = true;
				}
				else if (num3 >= int_3)
				{
					@class.bool_6 = true;
				}
			}
			else if (int_14 > int_3 && int_14 < int_4)
			{
				@class.bool_6 = true;
				@class.bool_7 = true;
			}
			break;
		case TableStyleElementType.FirstHeaderCell:
		case TableStyleElementType.LastHeaderCell:
		case TableStyleElementType.FirstTotalCell:
		case TableStyleElementType.LastTotalCell:
			@class.bool_3 = true;
			@class.bool_2 = true;
			@class.bool_1 = true;
			@class.bool_0 = true;
			break;
		}
		return @class;
	}

	[SpecialName]
	internal TableStyle method_41()
	{
		if (object_0 == null)
		{
			return listObjectCollection_0.method_4().method_2().TableStyles.GetBuiltinTableStyle(TableStyleType.TableStyleMedium9);
		}
		if (object_0 is string)
		{
			return listObjectCollection_0.method_4().method_2().TableStyles[(string)object_0];
		}
		if (object_0 is TableStyleType)
		{
			return listObjectCollection_0.method_4().method_2().TableStyles.GetBuiltinTableStyle((TableStyleType)object_0);
		}
		return listObjectCollection_0.method_4().method_2().TableStyles.GetBuiltinTableStyle(TableStyleType.TableStyleMedium9);
	}

	[SpecialName]
	internal Style method_42()
	{
		if (style_1 == null)
		{
			style_1 = new Style(method_1());
			style_1.method_16(0);
		}
		return style_1;
	}

	internal Class1685 method_43(Style style_4)
	{
		if (style_4 != null)
		{
			Class1685 @class = new Class1685();
			@class.method_1(style_4);
			if (@class.Count < 1)
			{
				@class = null;
			}
			return @class;
		}
		return null;
	}

	[SpecialName]
	internal Style method_44()
	{
		if (style_2 == null)
		{
			style_2 = new Style(method_1());
			style_2.method_16(0);
		}
		return style_2;
	}

	[SpecialName]
	internal Style method_45()
	{
		if (style_3 == null)
		{
			style_3 = new Style(method_1());
			style_3.method_16(0);
		}
		return style_3;
	}

	internal void method_46(int int_13)
	{
		int_0 = int_13;
		if (int_13 > method_12().method_4().method_2().int_11)
		{
			method_12().method_4().method_2().int_11 = int_13;
		}
	}

	internal void method_47(string string_5)
	{
		string_0 = string_5;
	}

	[SpecialName]
	internal int method_48()
	{
		return int_11;
	}

	[SpecialName]
	internal void method_49(int int_13)
	{
		int_11 = int_13;
	}

	internal string method_50()
	{
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = StartRow;
		cellArea_.StartColumn = StartColumn;
		cellArea_.EndRow = EndRow;
		if (EndRow - StartRow == 0)
		{
			cellArea_.EndRow++;
		}
		cellArea_.EndColumn = EndColumn;
		return Class1618.smethod_15(cellArea_);
	}

	[SpecialName]
	internal int method_51()
	{
		return int_12;
	}

	[SpecialName]
	internal void method_52(int int_13)
	{
		int_12 = int_13;
	}

	[SpecialName]
	internal bool method_53()
	{
		if (autoFilter_0 != null)
		{
			return autoFilter_0.Range != null;
		}
		return false;
	}

	internal void method_54()
	{
		if (!method_19())
		{
			return;
		}
		Cells cells = method_12().method_4().Cells;
		for (int i = 0; i < ListColumns.Count; i++)
		{
			ListColumn listColumn = ListColumns[i];
			if (listColumn.method_16() != null && listColumn.TotalsCalculation == TotalsCalculation.None)
			{
				Cell cell = cells.GetCell(int_2, int_3 + i, bool_2: false);
				if (cell.IsBlank)
				{
					cell.PutValue(listColumn.method_16());
				}
			}
		}
	}
}
