using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns1;
using ns16;
using ns2;
using ns29;
using ns59;

namespace Aspose.Cells;

/// <summary>
///        Encapsulates a collection of <see cref="T:Aspose.Cells.Cell" /> objects.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        Workbook excel = new Workbook();
///       	Cells cells = excel.Worksheets[0].Cells;
///
///       	//Set default row height
///       	cells.StandardHeight = 20;
///       	//Set row height
///       	cells.SetRowHeight(2, 20.5);
///
///       	//Set default colum width
///       	cells.StandardWidth = 15;
///       	//Set column width
///       	cells.SetColumnWidth(3, 12.57);
///
///       	//Merge cells
///       	cells.Merge(5, 4, 2, 2);
///
///       	//Import data
///       	DataTable dt = new DataTable("Products");
///        dt.Columns.Add("Product_ID",typeof(Int32));
///        dt.Columns.Add("Product_Name",typeof(string));
///        dt.Columns.Add("Units_In_Stock",typeof(Int32));
///        DataRow dr = dt.NewRow();
///        dr[0] = 1;
///        dr[1] = "Aniseed Syrup";
///        dr[2] = 15;
///        dt.Rows.Add(dr);
///        dr = dt.NewRow();
///        dr[0] = 2;
///        dr[1] = "Boston Crab Meat";
///        dr[2] = 123;
///        dt.Rows.Add(dr);
///        cells.ImportDataTable(dt, true, 12, 12, 10, 10);
///
///        //Export data
///        DataTable outDataTable = cells.ExportDataTable(12, 12, 10, 10);
///
///        [Visual Basic]
///
///        Dim excel as Workbook = new Workbook()
///       	Dim cells as Cells = excel.Worksheets(0).Cells
///
///       	'Set default row height
///       	cells.StandardHeight = 20
///       	'Set row height
///       	cells.SetRowHeight(2, 20.5)
///
///       	'Set default colum width
///       	cells.StandardWidth = 15
///       	'Set column width
///       	cells.SetColumnWidth(3, 12.57)
///
///       	'Merge cells
///       	cells.Merge(5, 4, 2, 2)
///
///       	'Import data
///       	Dim dt as DataTable = new DataTable("Employee")
///       	dt.Columns.Add("Employee_ID",typeof(Int32))
///        dt.Columns.Add("Employee_Name",typeof(string))
///        dt.Columns.Add("Gender",typeof(string))
///        Dim dr as DataRow = dt.NewRow()
///        dr(0) = 1
///        dr(1) = "John Smith"
///        dr(2) = "Male"
///        dt.Rows.Add(dr)
///        dr = dt.NewRow()
///        dr(0) = 2
///        dr(1) = "Mary Miller"
///        dr(2) = "Female"
///        dt.Rows.Add(dr)
///        cells.ImportDataTable(dt, true, 12, 12, 10, 10)
///
///        'Export data
///        Dim outDataTable as DataTable = cells.ExportDataTable(12, 12, 10, 10)
///        </code>
/// </example>
public class Cells : IEnumerable
{
	internal double double_0;

	private bool bool_0;

	private HorizontalPageBreakCollection horizontalPageBreakCollection_0;

	private VerticalPageBreakCollection verticalPageBreakCollection_0;

	private Class1133 class1133_0;

	private Class1301 class1301_0;

	private RowCollection rowCollection_0;

	private Worksheet worksheet_0;

	private PageSetup pageSetup_0;

	private HyperlinkCollection hyperlinkCollection_0;

	private bool bool_1;

	private short short_0 = -1;

	private byte byte_0;

	private ColumnCollection columnCollection_0;

	private byte byte_1;

	private byte byte_2;

	private RangeCollection rangeCollection_0;

	/// <summary>
	///       Gets the number of cells.
	///       </summary>
	public int Count => rowCollection_0.int_0;

	/// <summary>
	///       Gets the collection of <see cref="T:Aspose.Cells.Row" /> objects that represents the individual rows in this worksheet.
	///       </summary>
	public RowCollection Rows => rowCollection_0;

	/// <summary>
	///       Gets the collection of merged cells.
	///       </summary>
	/// <remarks>In this collection, each item is a <see cref="T:Aspose.Cells.CellArea" /> structure which represents an area of merged cells.</remarks>
	public ArrayList MergedCells => class1133_0.method_2();

	/// <summary>
	///        Gets <see cref="T:Aspose.Cells.Cell" /> item within the worksheet
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <value>The element at the specified index.</value>
	/// <remarks>
	///        This is the indexer for the Cells class.
	///        Gets the cell element at the specified index. 
	///       </remarks>
	public Cell this[int index] => rowCollection_0.GetCellByIndex(index);

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Cell" /> element at the specified cell row index and column index.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="column">Column index.</param>
	/// <returns>The <see cref="T:Aspose.Cells.Cell" /> object.</returns>
	/// <example>
	///   <code> 
	///       [C#]
	///
	///       Cells cells = excel.Worksheets[0].Cells;
	///       Cell cell = cells[0, 0];	//Gets the cell at "A1"
	///
	///       [Visual Basic]
	///
	///       Dim cells As Cells =  excel.Worksheets(0).Cells 
	///       Dim cell As Cell =  cells(0,0)  'Gets the cell at "A1"
	///       </code>
	/// </example>
	public Cell this[int row, int column]
	{
		get
		{
			Class1677.CheckCell(row, column);
			return rowCollection_0.GetCell(row, column, bool_0: false, bool_1: true, bool_2: true);
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Cell" /> element at the specified cell name.
	///       </summary>
	/// <param name="cellName">Cell name,including its column letter and row number, for example A5.</param>
	/// <returns>A <see cref="T:Aspose.Cells.Cell" /> object</returns>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       Cells cells = excel.Worksheets[0].Cells;
	///       Cell cell = cells["A1"];	//Gets the cell at "A1"
	///
	///       [Visual Basic]
	///
	///       Dim cells As Cells =  excel.Worksheets(0).Cells 
	///       Dim cell As Cell =  cells("A1")  'Gets the cell at "A1"
	///       </code>
	/// </example>
	public Cell this[string cellName]
	{
		get
		{
			int row = 0;
			int column = 0;
			CellsHelper.CellNameToIndex(cellName, out row, out column);
			return rowCollection_0.GetCell(row, column, bool_0: false, bool_1: true, bool_2: true);
		}
	}

	/// <summary>
	///        Gets or sets the default column width in the worksheet,in unit of inches.
	///       </summary>
	public double StandardWidthInch
	{
		get
		{
			return (float)StandardWidthPixels * 1f / (float)method_19().method_75();
		}
		set
		{
			StandardWidthPixels = (int)(value * (double)method_19().method_75() + 0.5);
		}
	}

	/// <summary>
	///        Gets or sets the default column width in the worksheet,in unit of pixels.
	///       </summary>
	public int StandardWidthPixels
	{
		get
		{
			double width = Columns.Width;
			return Class1677.smethod_1(width, method_19());
		}
		set
		{
			method_8(Class1677.smethod_0(value, method_19()));
		}
	}

	/// <summary>
	///       Gets or sets the default column width in the worksheet,in unit of characters.
	///       </summary>
	public double StandardWidth
	{
		get
		{
			return Columns.Width;
		}
		set
		{
			if (value >= 0.0 && value < 256.0)
			{
				double num = value;
				int num2 = method_19().method_72();
				int num3 = (int)((double)method_19().method_71() / 256.0 * (double)num2 + 0.5);
				if (num >= 1.0)
				{
					int num4 = (int)((num + 1.0) * (double)num2 + (double)num3 + 0.5);
					num = (double)(int)((double)(num4 - num3 - num2) * 100.0 / (double)num2 + 0.5) / 100.0;
				}
				else
				{
					int num4 = (int)(num * (double)(num2 + num3) + 0.5);
					num = (double)(int)((double)num4 * 100.0 / (double)(num2 + num3) + 0.5) / 100.0;
				}
				method_8(num);
			}
		}
	}

	/// <summary>
	///       Gets or sets the default row height in this worksheet,in unit of points.
	///       </summary>
	public double StandardHeight
	{
		get
		{
			if (((uint)byte_0 & (true ? 1u : 0u)) != 0)
			{
				return double_0 / 20.0;
			}
			return Math.Ceiling(double_0 / 20.0 * (double)method_19().method_75() / 72.0) * 72.0 / (double)method_19().method_75();
		}
		set
		{
			if (value <= 409.5 && value >= 0.0)
			{
				double_0 = (int)(value * 20.0 + 0.5);
				rowCollection_0.method_0(double_0, bool_0: false);
				byte_0 |= 1;
			}
		}
	}

	/// <summary>
	///       Gets or sets the default row height in this worksheet,in unit of pixels.
	///       </summary>
	public int StandardHeightPixels
	{
		get
		{
			return (int)(StandardHeight * (double)method_19().method_76() / 72.0 + 0.5);
		}
		set
		{
			StandardHeight = (float)value * 72f / (float)method_19().method_76();
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether all worksheet values are preserved as strings. 
	///       Default is false.
	///       </summary>
	public bool PreserveString
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       Minimum row index of cell which contains data or style.
	///       </summary>
	public int MinRow
	{
		get
		{
			int num = 0;
			Row rowByIndex;
			while (true)
			{
				if (num < rowCollection_0.Count)
				{
					rowByIndex = rowCollection_0.GetRowByIndex(num);
					if (rowByIndex.method_1())
					{
						break;
					}
					num++;
					continue;
				}
				return 0;
			}
			return rowByIndex.int_0;
		}
	}

	public int MinDataRow => rowCollection_0.MinDataRow;

	public int MinDataColumn => rowCollection_0.MinDataColumn;

	/// <summary>
	///       Minimum column index of cell which contains data or style.
	///       </summary>
	public int MinColumn
	{
		get
		{
			int num = -1;
			for (int i = 0; i < rowCollection_0.Count; i++)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(i);
				if (rowByIndex.method_1())
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(0);
					if (cellByIndex.Column < num || num < 0)
					{
						num = cellByIndex.Column;
					}
				}
			}
			if (num >= 0)
			{
				return num;
			}
			return 0;
		}
	}

	/// <summary>
	///       Maximum row index of cell which contains data.
	///       </summary>
	/// <remarks>
	///       Return -1 if there is no cell which contains data.
	///       </remarks>
	public int MaxDataRow => rowCollection_0.MaxDataRow;

	/// <summary>
	///       Maximum row index of cell which contains data or style.
	///       </summary>
	/// <remarks>
	///       Return -1 if there is no cell whiche contains data or style in the worksheet.
	///       </remarks>
	public int MaxRow => method_20(-1);

	/// <summary>
	///       Maximum column index of cell which contains data.
	///       </summary>
	/// <remarks>
	///       Return -1 if there is not cell which contains data.
	///       Don't call this property repeatedly. This property will iterate all cells in a worksheet.</remarks>
	public int MaxDataColumn => rowCollection_0.MaxDataColumn;

	/// <summary>
	///       Maximum column index of cell which contains data or style.
	///       </summary>
	/// <remarks>
	///       Return -1 if ther is not cell.
	///       </remarks>
	public int MaxColumn => short_0;

	/// <summary>
	///       Indicates that row height and default font height matches
	///       </summary>
	public bool IsDefaultRowHeightMatched
	{
		get
		{
			return (byte_0 & 1) == 0;
		}
		set
		{
			if (!value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 &= 254;
			}
		}
	}

	/// <summary>
	///       Gets the collection of <see cref="T:Aspose.Cells.Column" /> objects that represents the individual columns in this worksheet.
	///       </summary>
	public ColumnCollection Columns => columnCollection_0;

	/// <summary>
	///       Gets the collection of <see cref="T:Aspose.Cells.Range" /> objects created at run time.
	///       </summary>
	public RangeCollection Ranges => rangeCollection_0;

	/// <summary>
	///       Gets the last cell in this worksheet.
	///       </summary>
	public Cell End => LastCell;

	/// <summary>
	///       Gets the last cell in this worksheet.
	///       </summary>
	public Cell LastCell
	{
		get
		{
			for (int num = rowCollection_0.Count - 1; num >= 0; num--)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				int num2 = rowByIndex.method_0() - 1;
				while (num2 >= 0)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
					if (cellByIndex.method_20() == Enum199.const_7)
					{
						num2--;
						continue;
					}
					return cellByIndex;
				}
			}
			return null;
		}
	}

	public Range MaxDisplayRange
	{
		get
		{
			int num = MaxRow;
			int num2 = MaxColumn;
			for (int i = 0; i < class1133_0.Count; i++)
			{
				CellArea cellArea = class1133_0[i];
				if (cellArea.EndRow > num)
				{
					num = cellArea.EndRow;
				}
				if (cellArea.EndColumn > num2)
				{
					num2 = cellArea.EndColumn;
				}
			}
			for (int j = 0; j < worksheet_0.Shapes.Count; j++)
			{
				Shape shape = worksheet_0.Shapes[j];
				int lowerRightRow = shape.LowerRightRow;
				int lowerRightColumn = shape.LowerRightColumn;
				if (lowerRightRow > num)
				{
					num = lowerRightRow;
				}
				if (lowerRightColumn > num2)
				{
					num2 = lowerRightColumn;
				}
			}
			if (num >= 0 && num2 >= 0)
			{
				return CreateRange(0, 0, num + 1, num2 + 1);
			}
			return CreateRange(0, 0, 1, 1);
		}
	}

	/// <summary>
	///       Gets the first cell in this worksheet.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.FirstCell property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Cells.FirstCell property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cell Start => FirstCell;

	/// <summary>
	///       Gets the first cell in this worksheet.
	///       </summary>
	public Cell FirstCell
	{
		get
		{
			for (int i = 0; i < rowCollection_0.Count; i++)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(i);
				for (int j = 0; j < rowByIndex.method_0(); j++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(j);
					if (cellByIndex.method_20() != Enum199.const_7)
					{
						return cellByIndex;
					}
				}
			}
			return null;
		}
	}

	internal HorizontalPageBreakCollection HPageBreaks => horizontalPageBreakCollection_0;

	internal VerticalPageBreakCollection VPageBreaks => verticalPageBreakCollection_0;

	internal PageSetup PageSetup => pageSetup_0;

	internal HyperlinkCollection Hyperlinks => hyperlinkCollection_0;

	/// <summary>
	///       Gets the cells enumerator
	///       </summary>
	/// <returns>The cells enumertor</returns>
	public IEnumerator GetEnumerator()
	{
		return new Class1384(rowCollection_0);
	}

	/// <summary>
	///       Gets the rows enumerator
	///       </summary>
	/// <returns>The rows enuerator.</returns>
	public IEnumerator GetRowEnumerator()
	{
		return new Class1722(rowCollection_0);
	}

	[SpecialName]
	internal double method_0()
	{
		return double_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return (ushort)double_0;
	}

	[SpecialName]
	internal Class1301 method_2()
	{
		return class1301_0;
	}

	internal Cells(Class1301 class1301_1, Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
		class1301_0 = class1301_1;
		method_4();
	}

	[SpecialName]
	internal Worksheet method_3()
	{
		return worksheet_0;
	}

	private void method_4()
	{
		method_19().Workbook.method_4();
		rangeCollection_0 = new RangeCollection();
		horizontalPageBreakCollection_0 = new HorizontalPageBreakCollection();
		verticalPageBreakCollection_0 = new VerticalPageBreakCollection();
		class1133_0 = new Class1133();
		int num = method_19().method_72() * 8 + method_19().method_73();
		int num2 = (num / 8 + 1) * 8;
		double double_ = 8.0 + (double)(num2 - num) * 1.0 / (double)method_19().method_72();
		double_0 = 255.0;
		bool_0 = false;
		if (method_19().method_75() != 96)
		{
			double_0 = 264.0;
		}
		rowCollection_0 = new RowCollection(this, double_0, 16);
		hyperlinkCollection_0 = new HyperlinkCollection(worksheet_0);
		pageSetup_0 = new PageSetup(worksheet_0);
		columnCollection_0 = new ColumnCollection(worksheet_0, double_);
	}

	internal void method_5()
	{
		if (class1133_0 == null || class1133_0.Count < 1)
		{
			return;
		}
		for (int i = 0; i < class1133_0.Count - 1; i++)
		{
			CellArea cellArea_ = class1133_0[i];
			for (int num = class1133_0.Count - 1; num > i; num--)
			{
				CellArea cellArea_2 = class1133_0[num];
				if (Class1678.Intersect(cellArea_, cellArea_2) != null)
				{
					if (!method_19().Workbook.method_24() && !Class1678.smethod_1(cellArea_, cellArea_2))
					{
						cellArea_ = Class1678.smethod_3(cellArea_, cellArea_2);
						class1133_0.RemoveAt(num);
						num = class1133_0.Count;
					}
					else
					{
						class1133_0.RemoveAt(num);
					}
				}
			}
			class1133_0.method_0(i, cellArea_);
		}
	}

	internal void method_6()
	{
		method_19().Workbook.method_3();
		Column column = null;
		for (int num = columnCollection_0.Count - 1; num >= 0; num--)
		{
			column = columnCollection_0.GetColumnByIndex(num);
			if (column.Index <= 255)
			{
				break;
			}
			columnCollection_0.RemoveAt(num);
		}
		rowCollection_0.method_21();
		if (short_0 >= 256)
		{
			short_0 = 255;
		}
		if (class1133_0 != null)
		{
			class1133_0.method_3();
		}
		if (horizontalPageBreakCollection_0 != null && horizontalPageBreakCollection_0.Count > 0)
		{
			for (int num2 = horizontalPageBreakCollection_0.Count - 1; num2 >= 0; num2--)
			{
				HorizontalPageBreak horizontalPageBreak = horizontalPageBreakCollection_0[num2];
				if (horizontalPageBreak.Row <= 65535 && horizontalPageBreak.StartColumn <= 255)
				{
					if (horizontalPageBreak.EndColumn > 255)
					{
						horizontalPageBreak.method_1(255);
					}
				}
				else
				{
					horizontalPageBreakCollection_0.RemoveAt(num2);
				}
			}
		}
		if (verticalPageBreakCollection_0 != null && verticalPageBreakCollection_0.Count > 0)
		{
			for (int num3 = verticalPageBreakCollection_0.Count - 1; num3 >= 0; num3--)
			{
				VerticalPageBreak verticalPageBreak = verticalPageBreakCollection_0[num3];
				if (verticalPageBreak.Column <= 255 && verticalPageBreak.StartRow <= 65535)
				{
					if (verticalPageBreak.EndRow > 65535)
					{
						verticalPageBreak.method_1(65535);
					}
				}
				else
				{
					verticalPageBreakCollection_0.RemoveAt(num3);
				}
			}
		}
		if (hyperlinkCollection_0 != null && hyperlinkCollection_0.Count > 0)
		{
			for (int num4 = hyperlinkCollection_0.Count - 1; num4 >= 0; num4--)
			{
				CellArea area = hyperlinkCollection_0[num4].Area;
				if (area.StartRow <= 65535 && area.StartColumn <= 255)
				{
					if (area.EndRow > 65535)
					{
						area.EndRow = 65535;
						if (area.EndColumn > 255)
						{
							area.EndColumn = 255;
						}
						hyperlinkCollection_0[num4].method_4(area);
					}
					else if (area.EndColumn > 255)
					{
						area.EndColumn = 255;
						hyperlinkCollection_0[num4].method_4(area);
					}
				}
				else
				{
					hyperlinkCollection_0.RemoveAt(num4);
				}
			}
		}
		if (worksheet_0.ListObjects.Count == 0)
		{
			return;
		}
		ListObjectCollection listObjects = worksheet_0.ListObjects;
		for (int i = 0; i < listObjects.Count; i++)
		{
			ListObject listObject = listObjects[i];
			if (listObject.StartRow <= 65535 && listObject.StartColumn <= 255 && listObject.EndRow <= 65535 && listObject.EndColumn <= 255)
			{
				for (int j = listObject.StartRow; j <= listObject.EndRow; j++)
				{
					Row row = CheckRow(j);
					if (row == null)
					{
						continue;
					}
					for (int k = listObject.StartColumn; k <= listObject.EndColumn; k++)
					{
						Cell cellOrNull = row.GetCellOrNull(k);
						if (cellOrNull != null && cellOrNull.IsFormula)
						{
							byte[] array = cellOrNull.method_41();
							array = Class1674.smethod_6(array, -1, -1, worksheet_0);
							cellOrNull.method_42(array);
						}
					}
				}
			}
			else
			{
				listObjects.RemoveAt(i--);
			}
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Cell" /> element or null at the specified cell row index and column index.
	///       </summary>
	/// <param name="row">Row index</param>
	/// <param name="column">Column index</param>
	/// <returns>Return Cell object if a Cell object exists.
	///       Return null if the cell does not exist.
	///       </returns>
	public Cell GetCell(int row, int column)
	{
		return rowCollection_0.GetCell(row, column, bool_0: true, bool_1: false, bool_2: false);
	}

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Row" /> element or at the specified cell row index.
	///       </summary>
	/// <param name="row">Row index</param>
	/// <returns>
	///       If the row object does exist return Row object,otherwise return null.
	///       </returns>
	public Row GetRow(int row)
	{
		return Rows.GetRow(row, bool_0: true, bool_1: false);
	}

	public Cell CheckCell(int row, int column)
	{
		return rowCollection_0.GetCell(row, column, bool_0: true, bool_1: false, bool_2: false);
	}

	public Row CheckRow(int row)
	{
		return Rows.GetRow(row, bool_0: true, bool_1: false);
	}

	public Column CheckColumn(int columnIndex)
	{
		return Columns.method_5(columnIndex);
	}

	public bool IsRowHidden(int rowIndex)
	{
		return Rows.GetRow(rowIndex, bool_0: true, bool_1: false)?.IsHidden ?? false;
	}

	public bool IsColumnHidden(int columnIndex)
	{
		return Columns.method_5(columnIndex)?.IsHidden ?? Columns.method_2(columnIndex);
	}

	/// <summary>
	///       Adds a range object reference to cells
	///       </summary>
	/// <param name="rangeObject">The range object will be contained in the cells</param>
	public void AddRange(Range rangeObject)
	{
		rangeCollection_0.Add(rangeObject);
	}

	/// <summary>
	///       Creates a <see cref="T:Aspose.Cells.Range" /> object from a range of cells.
	///       </summary>
	/// <param name="upperLeftCell">Upper left cell name.</param>
	/// <param name="lowerRightCell">Lower right cell name.</param>
	/// <returns>A <see cref="T:Aspose.Cells.Range" /> object</returns>
	public Range CreateRange(string upperLeftCell, string lowerRightCell)
	{
		CellsHelper.CellNameToIndex(upperLeftCell, out var row, out var column);
		CellsHelper.CellNameToIndex(lowerRightCell, out var row2, out var column2);
		if (row > row2 || column > column2)
		{
			throw new ArgumentException("The row and column index of upper left cell should be no more than lower right cell.");
		}
		return CreateRange(row, column, row2 - row + 1, column2 - column + 1);
	}

	/// <summary>
	///       Creates a <see cref="T:Aspose.Cells.Range" /> object from a range of cells.
	///       </summary>
	/// <param name="firstRow">First row of this range</param>
	/// <param name="firstColumn">First column of this range</param>
	/// <param name="totalRows">Number of rows</param>
	/// <param name="totalColumns">Number of columns</param>
	/// <returns>A <see cref="T:Aspose.Cells.Range" /> object</returns>
	public Range CreateRange(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		if (totalRows == 0 || totalColumns == 0)
		{
			throw new ArgumentException("Row number or column number cannot be zero");
		}
		Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
		return new Range(firstRow, firstColumn, totalRows, totalColumns, this);
	}

	/// <summary>
	///        Creates a <see cref="T:Aspose.Cells.Range" /> object from an address of the range.
	///       </summary>
	/// <param name="address">The address of the range.</param>
	/// <returns>A <see cref="T:Aspose.Cells.Range" /> object</returns>
	public Range CreateRange(string address)
	{
		int num = address.LastIndexOf('!');
		if (num != -1)
		{
			address = address.Substring(num + 1);
		}
		num = address.IndexOf(':');
		if (num != -1)
		{
			string text = address.Substring(0, num).Replace("$", "");
			string text2 = address.Substring(num + 1).Replace("$", "");
			if (char.IsDigit(text[0]))
			{
				int num2 = int.Parse(text) - 1;
				int num3 = int.Parse(text2) - 1;
				return CreateRange(num2, num3 - num2 + 1, isVertical: false);
			}
			if (char.IsDigit(text[text.Length - 1]))
			{
				return CreateRange(text, text2);
			}
			int num4 = CellsHelper.ColumnNameToIndex(text);
			int num5 = CellsHelper.ColumnNameToIndex(text2);
			return CreateRange(num4, num5 - num4 + 1, isVertical: true);
		}
		address = address.Replace("$", "");
		CellsHelper.CellNameToIndex(address, out var row, out var column);
		return CreateRange(row, column, 1, 1);
	}

	/// <summary>
	///       Creates a <see cref="T:Aspose.Cells.Range" /> object from rows of cells or columns of cells.
	///       </summary>
	/// <param name="firstIndex">First row index or first column index, zero based.</param>
	/// <param name="number">Total number of rows or columns, one based.</param>
	/// <param name="isVertical">True - Range created from columns of cells. False - Range created from rows of cells. </param>
	/// <returns>A <see cref="T:Aspose.Cells.Range" /> object.</returns>
	public Range CreateRange(int firstIndex, int number, bool isVertical)
	{
		if (firstIndex >= 0 && number > 0)
		{
			if (isVertical)
			{
				Class1677.smethod_25(firstIndex + number - 1);
				return new Range(0, firstIndex, 1048576, number, this);
			}
			Class1677.smethod_24(firstIndex + number - 1);
			return new Range(firstIndex, 0, number, 16384, this);
		}
		throw new ArgumentException();
	}

	internal Cell GetCellByIndex(int int_0)
	{
		return rowCollection_0.GetCellByIndex(int_0);
	}

	internal Cell method_7(string string_0)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(string_0, out row, out column);
		return rowCollection_0.GetCell(row, column, bool_0: false, bool_1: true, bool_2: true);
	}

	internal Cell GetCell(int int_0, int int_1, bool bool_2)
	{
		return rowCollection_0.GetCell(int_0, int_1, bool_2, bool_1: true, bool_2: true);
	}

	/// <summary>
	///       Clear all cell objects.
	///       </summary>
	public void Clear()
	{
		rowCollection_0.Clear();
	}

	internal void method_8(double double_1)
	{
		bool_1 = true;
		columnCollection_0.Width = double_1;
	}

	[SpecialName]
	internal bool method_9()
	{
		return bool_1;
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be exported.</param>
	/// <param name="totalColumns">Number of columns to be exported.</param>
	/// <param name="defaultValues">Default values for each data column.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	/// <remarks>
	///       If you use this method to export a block of data, please be sure that the data in a column 
	///       should be the same data type. And the type of data column will be same as the default value.
	///       </remarks>
	public DataTable ExportDataTable(int firstRow, int firstColumn, int totalRows, int totalColumns, object[] defaultValues)
	{
		DataTable dataTable = new DataTable();
		method_10(dataTable, firstRow, firstColumn, totalRows, totalColumns, defaultValues);
		for (int i = firstRow; i < firstRow + totalRows; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataTable.Rows.Add(dataRow);
			Row row = Rows.GetRow(i, bool_0: true, bool_1: false);
			if (row == null)
			{
				continue;
			}
			for (int j = firstColumn; j < firstColumn + totalColumns; j++)
			{
				Cell cellOrNull = row.GetCellOrNull(j);
				if (cellOrNull == null)
				{
					continue;
				}
				switch (cellOrNull.Type)
				{
				case CellValueType.IsBool:
					dataRow[j - firstColumn] = cellOrNull.BoolValue;
					break;
				case CellValueType.IsDateTime:
					if (dataTable.Columns[j - firstColumn].DataType == typeof(DateTime))
					{
						dataRow[j - firstColumn] = cellOrNull.DateTimeValue;
					}
					else
					{
						dataRow[j - firstColumn] = cellOrNull.StringValue;
					}
					break;
				case CellValueType.IsNumeric:
					switch (Type.GetTypeCode(dataTable.Columns[j - firstColumn].DataType))
					{
					case TypeCode.Double:
						dataRow[j - firstColumn] = cellOrNull.DoubleValue;
						break;
					case TypeCode.DateTime:
						dataRow[j - firstColumn] = cellOrNull.DateTimeValue;
						break;
					case TypeCode.String:
					{
						string stringValue2 = cellOrNull.StringValue;
						if (stringValue2 == null)
						{
							dataRow[j - firstColumn] = cellOrNull.DoubleValue.ToString();
						}
						else
						{
							dataRow[j - firstColumn] = stringValue2;
						}
						break;
					}
					case TypeCode.Int32:
						dataRow[j - firstColumn] = cellOrNull.IntValue;
						break;
					}
					break;
				case CellValueType.IsError:
				case CellValueType.IsString:
				case CellValueType.IsUnknown:
				{
					string stringValue = cellOrNull.StringValue;
					if (stringValue != null && stringValue != "")
					{
						dataRow[j - firstColumn] = stringValue;
					}
					break;
				}
				}
			}
		}
		return dataTable;
	}

	private void method_10(DataTable dataTable_0, int int_0, int int_1, int int_2, int int_3, object[] object_0)
	{
		for (int i = 0; i < int_3; i++)
		{
			DataColumn dataColumn = new DataColumn();
			if (object_0.Length > i && object_0[i] != null)
			{
				dataColumn.DataType = object_0[i].GetType();
				dataColumn.DefaultValue = object_0[i];
			}
			else
			{
				dataColumn.DataType = typeof(string);
			}
			dataTable_0.Columns.Add(dataColumn);
		}
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///
	///       string designerFile = MapPath("Designer") + "\\List.xls";
	///       Workbook excel = new Workbook(designerFile);
	///       Worksheet sheet = excel.Worksheets[0];
	///       DataTable dt = sheet.Cells.ExportDataTable(6, 1, 69, 4);
	///       this.DataGrid1.DataSource = dt;
	///       this.DataGrid1.DataBind();
	///
	///       [Visual Basic]
	///
	///
	///       Dim designerFile As String = MapPath("Designer") + "\List.xls"
	///       Dim excel As excel = New excel(designerFile)
	///       Dim sheet As Worksheet = excel.Worksheets(0)
	///       Dim dt As DataTable = sheet.Cells.ExportDataTable(6, 1, 69, 4)
	///       Me.DataGrid1.DataSource = dt
	///       Me.DataGrid1.DataBind()
	///       </code>
	/// </example>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	/// <remarks>
	///       If you use this method to export a block of data, please be sure that the data in a column 
	///       should be the same data type. Otherwise, use the <see cref="M:Aspose.Cells.Cells.ExportDataTableAsString(System.Int32,System.Int32,System.Int32,System.Int32)" /> method instead.
	///       </remarks>
	public DataTable ExportDataTable(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			DataTable dataTable = new DataTable();
			Row row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
			if (row != null)
			{
				for (int i = firstColumn; i < firstColumn + totalColumns; i++)
				{
					dataTable.Columns.Add();
					Cell cellOrNull = row.GetCellOrNull(i);
					if (cellOrNull != null)
					{
						method_11(dataTable, i - firstColumn, cellOrNull);
					}
				}
			}
			else
			{
				for (int j = 0; j < totalColumns; j++)
				{
					dataTable.Columns.Add();
					dataTable.Columns[j].DataType = typeof(string);
				}
			}
			for (int k = firstRow; k < firstRow + totalRows; k++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataTable.Rows.Add(dataRow);
				row = Rows.GetRow(k, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int l = firstColumn; l < firstColumn + totalColumns; l++)
				{
					Cell cellOrNull2 = row.GetCellOrNull(l);
					if (cellOrNull2 == null)
					{
						continue;
					}
					switch (cellOrNull2.Type)
					{
					case CellValueType.IsBool:
						dataRow[l - firstColumn] = cellOrNull2.BoolValue;
						break;
					case CellValueType.IsDateTime:
						if (dataTable.Columns[l - firstColumn].DataType == typeof(DateTime))
						{
							dataRow[l - firstColumn] = cellOrNull2.DateTimeValue;
						}
						else
						{
							dataRow[l - firstColumn] = cellOrNull2.StringValue;
						}
						break;
					case CellValueType.IsNumeric:
						if (dataTable.Columns[l - firstColumn].DataType == typeof(double))
						{
							dataRow[l - firstColumn] = cellOrNull2.DoubleValue;
						}
						else if (dataTable.Columns[l - firstColumn].DataType == typeof(int))
						{
							dataRow[l - firstColumn] = cellOrNull2.IntValue;
						}
						else if (dataTable.Columns[l - firstColumn].DataType == typeof(string))
						{
							dataRow[l - firstColumn] = cellOrNull2.DoubleValue.ToString();
						}
						else
						{
							dataRow[l - firstColumn] = cellOrNull2.DateTimeValue;
						}
						break;
					case CellValueType.IsError:
					case CellValueType.IsString:
					case CellValueType.IsUnknown:
					{
						string stringValue = cellOrNull2.StringValue;
						if (stringValue != null && stringValue != "")
						{
							dataRow[l - firstColumn] = stringValue;
						}
						break;
					}
					}
				}
			}
			return dataTable;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be exported.</param>
	/// <param name="totalColumns">Number of columns to be exported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	/// <param name="isVertical">True if a row in Workbook file represents a row in DataTable. False if a column in Workbook file represents a row in DataTable.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	public DataTable ExportDataTable(int firstRow, int firstColumn, int totalRows, int totalColumns, bool exportColumnName, bool isVertical)
	{
		if (isVertical)
		{
			return ExportDataTable(firstRow, firstColumn, totalRows, totalColumns, exportColumnName);
		}
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			DataTable dataTable = new DataTable();
			if (exportColumnName)
			{
				if (firstColumn == 16383)
				{
					dataTable = new DataTable();
					for (int i = firstRow; i < firstRow + totalRows; i++)
					{
						DataColumn dataColumn = dataTable.Columns.Add();
						Cell cell = GetCell(i, firstColumn, bool_2: false);
						dataColumn.ColumnName = cell.StringValue;
					}
				}
				else
				{
					method_13(dataTable, firstRow, firstColumn + 1, totalRows, totalColumns - 1, isVertical);
					int num = 0;
					for (int j = firstRow; j < firstRow + totalRows; j++)
					{
						DataColumn dataColumn2 = dataTable.Columns[num];
						Cell cell2 = GetCell(j, firstColumn, bool_2: false);
						dataColumn2.ColumnName = cell2.StringValue;
						num++;
					}
				}
				return dataTable;
			}
			dataTable = new DataTable();
			method_13(dataTable, firstRow, firstColumn, totalRows, totalColumns, isVertical);
			return dataTable;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	private void method_11(DataTable dataTable_0, int int_0, Cell cell_0)
	{
		Style style = cell_0.method_32();
		switch (cell_0.Type)
		{
		case CellValueType.IsBool:
			dataTable_0.Columns[int_0].DataType = typeof(bool);
			break;
		case CellValueType.IsDateTime:
			dataTable_0.Columns[int_0].DataType = typeof(DateTime);
			break;
		case CellValueType.IsNull:
			if (style.IsDateTime)
			{
				dataTable_0.Columns[int_0].DataType = typeof(DateTime);
			}
			break;
		case CellValueType.IsNumeric:
			if (cell_0.Value is double)
			{
				dataTable_0.Columns[int_0].DataType = typeof(double);
			}
			else
			{
				dataTable_0.Columns[int_0].DataType = typeof(int);
			}
			break;
		case CellValueType.IsError:
			break;
		case CellValueType.IsString:
			dataTable_0.Columns[int_0].DataType = typeof(string);
			break;
		}
	}

	private void method_12(DataTable dataTable_0, DataRow dataRow_0, int int_0, Cell cell_0)
	{
		switch (cell_0.Type)
		{
		case CellValueType.IsBool:
			dataRow_0[int_0] = cell_0.BoolValue;
			break;
		case CellValueType.IsDateTime:
			if (dataTable_0.Columns[int_0].DataType == typeof(DateTime))
			{
				dataRow_0[int_0] = cell_0.DateTimeValue;
			}
			else
			{
				dataRow_0[int_0] = cell_0.StringValue;
			}
			break;
		case CellValueType.IsNumeric:
			if (dataTable_0.Columns[int_0].DataType == typeof(double))
			{
				dataRow_0[int_0] = cell_0.DoubleValue;
			}
			else if (dataTable_0.Columns[int_0].DataType == typeof(int))
			{
				dataRow_0[int_0] = cell_0.IntValue;
			}
			else if (dataTable_0.Columns[int_0].DataType == typeof(string))
			{
				dataRow_0[int_0] = cell_0.DoubleValue.ToString();
			}
			else
			{
				dataRow_0[int_0] = cell_0.DateTimeValue;
			}
			break;
		case CellValueType.IsError:
		case CellValueType.IsString:
		case CellValueType.IsUnknown:
		{
			string stringValue = cell_0.StringValue;
			if (stringValue != null && stringValue != "")
			{
				dataRow_0[int_0] = stringValue;
			}
			break;
		}
		case CellValueType.IsNull:
			break;
		}
	}

	private void method_13(DataTable dataTable_0, int int_0, int int_1, int int_2, int int_3, bool bool_2)
	{
		if (bool_2)
		{
			Row row = Rows.GetRow(int_0, bool_0: true, bool_1: false);
			for (int i = int_1; i < int_1 + int_3; i++)
			{
				dataTable_0.Columns.Add();
				if (row != null)
				{
					Cell cellOrNull = row.GetCellOrNull(int_1);
					if (cellOrNull != null)
					{
						method_11(dataTable_0, i - int_1, cellOrNull);
					}
				}
			}
			return;
		}
		for (int j = int_0; j < int_0 + int_2; j++)
		{
			dataTable_0.Columns.Add();
			Row row2 = Rows.GetRow(j, bool_0: true, bool_1: false);
			if (row2 != null)
			{
				Cell cellOrNull2 = row2.GetCellOrNull(j);
				if (cellOrNull2 != null)
				{
					method_11(dataTable_0, j - int_0, cellOrNull2);
				}
			}
		}
		for (int k = int_1; k < int_1 + int_3; k++)
		{
			DataRow dataRow = dataTable_0.NewRow();
			for (int l = int_0; l < int_0 + int_2; l++)
			{
				Cell cell = rowCollection_0.GetCell(l, k, bool_0: true, bool_1: false, bool_2: false);
				if (cell != null)
				{
					method_12(dataTable_0, dataRow, l - int_0, cell);
				}
			}
			dataTable_0.Rows.Add(dataRow);
		}
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="dataTable">Data table</param>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	public void ExportDataTable(DataTable dataTable, int firstRow, int firstColumn, int totalRows, bool exportColumnName)
	{
		int count = dataTable.Columns.Count;
		if (totalRows != 0 && count != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + count - 1);
			if (exportColumnName)
			{
				for (int i = 0; i < count; i++)
				{
					DataColumn dataColumn = dataTable.Columns[i];
					Cell cell = GetCell(firstRow, i + firstColumn, bool_2: false);
					dataColumn.ColumnName = cell.StringValue;
				}
				firstRow++;
			}
			Row row = null;
			for (int j = firstRow; j < firstRow + totalRows; j++)
			{
				DataRow dataRow = dataTable.NewRow();
				row = Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = firstColumn; k < firstColumn + count; k++)
				{
					Cell cellOrNull = row.GetCellOrNull(k);
					if (cellOrNull == null)
					{
						continue;
					}
					if (cellOrNull.Type == CellValueType.IsNull)
					{
						if (!dataTable.Columns[k - firstColumn].AllowDBNull && Type.GetTypeCode(dataTable.Columns[k - firstColumn].DataType) != TypeCode.DBNull)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull.Name + " should not be null");
						}
						continue;
					}
					switch (Type.GetTypeCode(dataTable.Columns[k - firstColumn].DataType))
					{
					case TypeCode.Boolean:
						if (cellOrNull.Type == CellValueType.IsBool)
						{
							dataRow[k - firstColumn] = cellOrNull.BoolValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Boolean.");
					case TypeCode.Char:
						if (cellOrNull.Type == CellValueType.IsString)
						{
							string stringValue = cellOrNull.StringValue;
							if (stringValue.Length == 1)
							{
								dataRow[k - firstColumn] = stringValue[0];
							}
						}
						break;
					case TypeCode.Int16:
					{
						CellValueType type2 = cellOrNull.Type;
						if (type2 == CellValueType.IsDateTime || type2 == CellValueType.IsNumeric)
						{
							double doubleValue = cellOrNull.DoubleValue;
							if (doubleValue <= 32767.0 && doubleValue >= -32768.0 && doubleValue == (double)(short)doubleValue)
							{
								dataRow[k - firstColumn] = (short)doubleValue;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Short.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Short.");
					}
					case TypeCode.Int32:
					{
						CellValueType type3 = cellOrNull.Type;
						if (type3 == CellValueType.IsDateTime || type3 == CellValueType.IsNumeric)
						{
							double doubleValue2 = cellOrNull.DoubleValue;
							if (doubleValue2 <= 2147483647.0 && doubleValue2 >= -2147483648.0 && doubleValue2 == (double)(int)doubleValue2)
							{
								dataRow[k - firstColumn] = (int)doubleValue2;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Int.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Int.");
					}
					case TypeCode.Int64:
					{
						CellValueType type4 = cellOrNull.Type;
						if (type4 == CellValueType.IsDateTime || type4 == CellValueType.IsNumeric)
						{
							double doubleValue3 = cellOrNull.DoubleValue;
							if (doubleValue3 <= 9.223372036854776E+18 && doubleValue3 >= -9.223372036854776E+18 && doubleValue3 == (double)(long)doubleValue3)
							{
								dataRow[k - firstColumn] = (long)doubleValue3;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Long.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Long.");
					}
					case TypeCode.Double:
					{
						CellValueType type6 = cellOrNull.Type;
						if (type6 == CellValueType.IsDateTime || type6 == CellValueType.IsNumeric)
						{
							dataRow[k - firstColumn] = cellOrNull.DoubleValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Double.");
					}
					case TypeCode.Decimal:
					{
						CellValueType type5 = cellOrNull.Type;
						if (type5 == CellValueType.IsDateTime || type5 == CellValueType.IsNumeric)
						{
							double doubleValue4 = cellOrNull.DoubleValue;
							if (doubleValue4 <= 7.922816251426434E+28 && doubleValue4 >= -7.922816251426434E+28)
							{
								dataRow[k - firstColumn] = (decimal)doubleValue4;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data should be less than decimal.MaxValue and greater than decimal.MinValue.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Double.");
					}
					case TypeCode.DateTime:
					{
						CellValueType type = cellOrNull.Type;
						if (type == CellValueType.IsDateTime || type == CellValueType.IsNumeric)
						{
							dataRow[k - firstColumn] = cellOrNull.DateTimeValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull.Name + ",the data type should be Double.");
					}
					case TypeCode.String:
						dataRow[k - firstColumn] = cellOrNull.StringValue;
						break;
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	public DataTable ExportDataTable(int firstRow, int firstColumn, int totalRows, int totalColumns, bool exportColumnName)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			Row row = null;
			if (exportColumnName)
			{
				DataTable dataTable;
				if (firstRow != 1048575 && totalRows != 1)
				{
					dataTable = ExportDataTable(firstRow + 1, firstColumn, totalRows - 1, totalColumns);
					int num = 0;
					row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
					for (int i = firstColumn; i < firstColumn + totalColumns; i++)
					{
						DataColumn dataColumn = dataTable.Columns[num];
						if (row != null)
						{
							Cell cellOrNull = row.GetCellOrNull(i);
							if (cellOrNull != null)
							{
								dataColumn.ColumnName = cellOrNull.StringValue;
							}
							num++;
						}
					}
				}
				else
				{
					dataTable = new DataTable();
					row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
					for (int j = firstColumn; j < firstColumn + totalColumns; j++)
					{
						DataColumn dataColumn2 = dataTable.Columns.Add();
						if (row != null)
						{
							Cell cellOrNull2 = row.GetCellOrNull(j);
							if (cellOrNull2 != null)
							{
								dataColumn2.ColumnName = cellOrNull2.StringValue;
							}
						}
					}
				}
				return dataTable;
			}
			return ExportDataTable(firstRow, firstColumn, totalRows, totalColumns);
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="dataTable">Data table</param>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="columnIndexes">The indexes of columns which to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	public void ExportDataTable(DataTable dataTable, int firstRow, int[] columnIndexes, int totalRows, bool exportColumnName)
	{
		if (totalRows != 0 && dataTable.Columns.Count != 0)
		{
			Row row = null;
			if (exportColumnName)
			{
				row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
				if (row != null)
				{
					for (int i = 0; i < columnIndexes.Length; i++)
					{
						DataColumn dataColumn = dataTable.Columns[i];
						Cell cellOrNull = row.GetCellOrNull(columnIndexes[i]);
						if (cellOrNull != null)
						{
							dataColumn.ColumnName = cellOrNull.StringValue;
						}
					}
				}
				firstRow++;
			}
			int num = 0;
			for (int j = firstRow; j < firstRow + totalRows; j++)
			{
				DataRow dataRow = dataTable.NewRow();
				row = Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = 0; k < columnIndexes.Length; k++)
				{
					num = columnIndexes[k];
					Cell cellOrNull2 = row.GetCellOrNull(num);
					if (cellOrNull2 == null)
					{
						continue;
					}
					if (cellOrNull2.Type == CellValueType.IsNull)
					{
						if (!dataTable.Columns[k].AllowDBNull && Type.GetTypeCode(dataTable.Columns[k].DataType) != TypeCode.DBNull)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull2.Name + " should not be null");
						}
						continue;
					}
					switch (Type.GetTypeCode(dataTable.Columns[k].DataType))
					{
					case TypeCode.Boolean:
						if (cellOrNull2.Type == CellValueType.IsBool)
						{
							dataRow[k] = cellOrNull2.BoolValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Boolean.");
					case TypeCode.Char:
						if (cellOrNull2.Type == CellValueType.IsString)
						{
							string stringValue = cellOrNull2.StringValue;
							if (stringValue.Length == 1)
							{
								dataRow[k] = stringValue[0];
							}
						}
						break;
					case TypeCode.Int16:
					{
						CellValueType type2 = cellOrNull2.Type;
						if (type2 == CellValueType.IsDateTime || type2 == CellValueType.IsNumeric)
						{
							double doubleValue = cellOrNull2.DoubleValue;
							if (doubleValue <= 32767.0 && doubleValue >= -32768.0 && doubleValue == (double)(short)doubleValue)
							{
								dataRow[k] = (short)doubleValue;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
					}
					case TypeCode.Int32:
					{
						CellValueType type3 = cellOrNull2.Type;
						if (type3 == CellValueType.IsDateTime || type3 == CellValueType.IsNumeric)
						{
							double doubleValue2 = cellOrNull2.DoubleValue;
							if (doubleValue2 <= 2147483647.0 && doubleValue2 >= -2147483648.0 && doubleValue2 == (double)(int)doubleValue2)
							{
								dataRow[k] = (int)doubleValue2;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
					}
					case TypeCode.Int64:
					{
						CellValueType type4 = cellOrNull2.Type;
						if (type4 == CellValueType.IsDateTime || type4 == CellValueType.IsNumeric)
						{
							double doubleValue3 = cellOrNull2.DoubleValue;
							if (doubleValue3 <= 9.223372036854776E+18 && doubleValue3 >= -9.223372036854776E+18 && doubleValue3 == (double)(long)doubleValue3)
							{
								dataRow[k] = (long)doubleValue3;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
					}
					case TypeCode.Double:
					{
						CellValueType type6 = cellOrNull2.Type;
						if (type6 == CellValueType.IsDateTime || type6 == CellValueType.IsNumeric)
						{
							dataRow[k] = cellOrNull2.DoubleValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
					}
					case TypeCode.Decimal:
					{
						CellValueType type5 = cellOrNull2.Type;
						if (type5 == CellValueType.IsDateTime || type5 == CellValueType.IsNumeric)
						{
							double doubleValue4 = cellOrNull2.DoubleValue;
							if (doubleValue4 <= 7.922816251426434E+28 && doubleValue4 >= -7.922816251426434E+28)
							{
								dataRow[k] = (decimal)doubleValue4;
								break;
							}
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data should be less than decimal.MaxValue and greater than decimal.MinValue.");
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
					}
					case TypeCode.DateTime:
					{
						CellValueType type = cellOrNull2.Type;
						if (type == CellValueType.IsDateTime || type == CellValueType.IsNumeric)
						{
							dataRow[k] = cellOrNull2.DateTimeValue;
							break;
						}
						throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
					}
					case TypeCode.String:
						dataRow[k] = cellOrNull2.StringValue;
						break;
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="dataTable">Data table</param>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	/// <param name="skipErrorValue">Indicates whether skip invalid value for the column.
	///       For example,if the column type is decimal ,the value is greater than decimal.MaxValue 
	///       and this property is true,we will not throw exception again. </param>
	public void ExportDataTable(DataTable dataTable, int firstRow, int firstColumn, int totalRows, bool exportColumnName, bool skipErrorValue)
	{
		int count = dataTable.Columns.Count;
		if (totalRows != 0 && count != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + count - 1);
			bool flag = !skipErrorValue;
			Row row = null;
			if (exportColumnName)
			{
				row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
				if (row != null)
				{
					for (int i = 0; i < count; i++)
					{
						DataColumn dataColumn = dataTable.Columns[i];
						Cell cellOrNull = row.GetCellOrNull(i + firstColumn);
						if (cellOrNull != null)
						{
							dataColumn.ColumnName = cellOrNull.StringValue;
						}
					}
				}
				firstRow++;
			}
			for (int j = firstRow; j < firstRow + totalRows; j++)
			{
				DataRow dataRow = dataTable.NewRow();
				row = Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = firstColumn; k < firstColumn + count; k++)
				{
					Cell cellOrNull2 = row.GetCellOrNull(k);
					if (cellOrNull2 == null)
					{
						continue;
					}
					if (cellOrNull2.Type == CellValueType.IsNull)
					{
						if (!dataTable.Columns[k - firstColumn].AllowDBNull && Type.GetTypeCode(dataTable.Columns[k - firstColumn].DataType) != TypeCode.DBNull && flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull2.Name + " should not be null");
						}
						continue;
					}
					switch (Type.GetTypeCode(dataTable.Columns[k - firstColumn].DataType))
					{
					case TypeCode.Boolean:
						if (cellOrNull2.Type == CellValueType.IsBool)
						{
							dataRow[k - firstColumn] = cellOrNull2.BoolValue;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Boolean.");
						}
						break;
					case TypeCode.Char:
						if (cellOrNull2.Type == CellValueType.IsString)
						{
							string stringValue = cellOrNull2.StringValue;
							if (stringValue.Length == 1)
							{
								dataRow[k - firstColumn] = stringValue[0];
							}
						}
						break;
					case TypeCode.Int16:
					{
						CellValueType type3 = cellOrNull2.Type;
						if (type3 != CellValueType.IsDateTime && type3 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
							}
							break;
						}
						double doubleValue2 = cellOrNull2.DoubleValue;
						if (doubleValue2 <= 32767.0 && doubleValue2 >= -32768.0 && doubleValue2 == (double)(short)doubleValue2)
						{
							dataRow[k - firstColumn] = (short)doubleValue2;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
						}
						break;
					}
					case TypeCode.Int32:
					{
						CellValueType type2 = cellOrNull2.Type;
						if (type2 != CellValueType.IsDateTime && type2 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
							}
							break;
						}
						double doubleValue = cellOrNull2.DoubleValue;
						if (doubleValue <= 2147483647.0 && doubleValue >= -2147483648.0 && doubleValue == (double)(int)doubleValue)
						{
							dataRow[k - firstColumn] = (int)doubleValue;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
						}
						break;
					}
					case TypeCode.Int64:
					{
						CellValueType type5 = cellOrNull2.Type;
						if (type5 != CellValueType.IsDateTime && type5 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
							}
							break;
						}
						double doubleValue4 = cellOrNull2.DoubleValue;
						if (doubleValue4 <= 9.223372036854776E+18 && doubleValue4 >= -9.223372036854776E+18 && doubleValue4 == (double)(long)doubleValue4)
						{
							dataRow[k - firstColumn] = (long)doubleValue4;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
						}
						break;
					}
					case TypeCode.Double:
					{
						CellValueType type6 = cellOrNull2.Type;
						if (type6 != CellValueType.IsDateTime && type6 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
						}
						else
						{
							dataRow[k - firstColumn] = cellOrNull2.DoubleValue;
						}
						break;
					}
					case TypeCode.Decimal:
					{
						CellValueType type4 = cellOrNull2.Type;
						if (type4 != CellValueType.IsDateTime && type4 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
							break;
						}
						double doubleValue3 = cellOrNull2.DoubleValue;
						if (doubleValue3 <= 7.922816251426434E+28 && doubleValue3 >= -7.922816251426434E+28)
						{
							dataRow[k - firstColumn] = (decimal)doubleValue3;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data should be less than decimal.MaxValue and greater than decimal.MinValue.");
						}
						break;
					}
					case TypeCode.DateTime:
					{
						CellValueType type = cellOrNull2.Type;
						if (type != CellValueType.IsDateTime && type != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
						}
						else
						{
							dataRow[k - firstColumn] = cellOrNull2.DateTimeValue;
						}
						break;
					}
					case TypeCode.String:
						dataRow[k - firstColumn] = cellOrNull2.StringValue;
						break;
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="dataTable">Data table</param>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="columnIndexes">The indexes of columns which to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	/// <param name="skipErrorValue">Indicates whether skip invalid value for the column.
	///       For example,if the column type is decimal ,the value is greater than decimal.MaxValue 
	///       and this property is true,we will not throw exception again. </param>
	public void ExportDataTable(DataTable dataTable, int firstRow, int[] columnIndexes, int totalRows, bool exportColumnName, bool skipErrorValue)
	{
		bool flag = !skipErrorValue;
		if (totalRows != 0 && dataTable.Columns.Count != 0)
		{
			Row row = null;
			if (exportColumnName)
			{
				row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
				if (row != null)
				{
					for (int i = 0; i < columnIndexes.Length; i++)
					{
						DataColumn dataColumn = dataTable.Columns[i];
						Cell cellOrNull = row.GetCellOrNull(columnIndexes[i]);
						if (cellOrNull != null)
						{
							dataColumn.ColumnName = cellOrNull.StringValue;
						}
					}
				}
				firstRow++;
			}
			int num = 0;
			for (int j = firstRow; j < firstRow + totalRows; j++)
			{
				DataRow dataRow = dataTable.NewRow();
				row = Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = 0; k < columnIndexes.Length; k++)
				{
					num = columnIndexes[k];
					Cell cellOrNull2 = row.GetCellOrNull(num);
					if (cellOrNull2 == null)
					{
						continue;
					}
					if (cellOrNull2.Type == CellValueType.IsNull)
					{
						if (!dataTable.Columns[k].AllowDBNull && Type.GetTypeCode(dataTable.Columns[k].DataType) != TypeCode.DBNull && flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull2.Name + " should not be null");
						}
						continue;
					}
					switch (Type.GetTypeCode(dataTable.Columns[k].DataType))
					{
					case TypeCode.Boolean:
						if (cellOrNull2.Type == CellValueType.IsBool)
						{
							dataRow[k] = cellOrNull2.BoolValue;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Boolean.");
						}
						break;
					case TypeCode.Char:
						if (cellOrNull2.Type == CellValueType.IsString)
						{
							string stringValue = cellOrNull2.StringValue;
							if (stringValue.Length == 1)
							{
								dataRow[k] = stringValue[0];
							}
						}
						break;
					case TypeCode.Int16:
					{
						CellValueType type3 = cellOrNull2.Type;
						if (type3 != CellValueType.IsDateTime && type3 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
							}
							break;
						}
						double doubleValue2 = cellOrNull2.DoubleValue;
						if (doubleValue2 <= 32767.0 && doubleValue2 >= -32768.0 && doubleValue2 == (double)(short)doubleValue2)
						{
							dataRow[k] = (short)doubleValue2;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Short.");
						}
						break;
					}
					case TypeCode.Int32:
					{
						CellValueType type2 = cellOrNull2.Type;
						if (type2 != CellValueType.IsDateTime && type2 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
							}
							break;
						}
						double doubleValue = cellOrNull2.DoubleValue;
						if (doubleValue <= 2147483647.0 && doubleValue >= -2147483648.0 && doubleValue == (double)(int)doubleValue)
						{
							dataRow[k] = (int)doubleValue;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Int.");
						}
						break;
					}
					case TypeCode.Int64:
					{
						CellValueType type5 = cellOrNull2.Type;
						if (type5 != CellValueType.IsDateTime && type5 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
							}
							break;
						}
						double doubleValue4 = cellOrNull2.DoubleValue;
						if (doubleValue4 <= 9.223372036854776E+18 && doubleValue4 >= -9.223372036854776E+18 && doubleValue4 == (double)(long)doubleValue4)
						{
							dataRow[k] = (long)doubleValue4;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Long.");
						}
						break;
					}
					case TypeCode.Double:
					{
						CellValueType type6 = cellOrNull2.Type;
						if (type6 != CellValueType.IsDateTime && type6 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
						}
						else
						{
							dataRow[k] = cellOrNull2.DoubleValue;
						}
						break;
					}
					case TypeCode.Decimal:
					{
						CellValueType type4 = cellOrNull2.Type;
						if (type4 != CellValueType.IsDateTime && type4 != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
							break;
						}
						double doubleValue3 = cellOrNull2.DoubleValue;
						if (doubleValue3 <= 7.922816251426434E+28 && doubleValue3 >= -7.922816251426434E+28)
						{
							dataRow[k] = (decimal)doubleValue3;
						}
						else if (flag)
						{
							throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data should be less than decimal.MaxValue and greater than decimal.MinValue.");
						}
						break;
					}
					case TypeCode.DateTime:
					{
						CellValueType type = cellOrNull2.Type;
						if (type != CellValueType.IsDateTime && type != CellValueType.IsNumeric)
						{
							if (flag)
							{
								throw new CellsException(ExceptionType.InvalidData, "Invalid data of " + cellOrNull2.Name + ",the data type should be Double.");
							}
						}
						else
						{
							dataRow[k] = cellOrNull2.DateTimeValue;
						}
						break;
					}
					case TypeCode.String:
						dataRow[k] = cellOrNull2.StringValue;
						break;
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			return;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	/// <remarks>All data in the <see cref="T:Aspose.Cells.Cells" /> collection are converted to strings.</remarks>
	public DataTable ExportDataTableAsString(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			DataTable dataTable = new DataTable();
			for (int i = firstColumn; i < firstColumn + totalColumns; i++)
			{
				dataTable.Columns.Add();
				dataTable.Columns[i - firstColumn].DataType = typeof(string);
			}
			Row row = null;
			for (int j = firstRow; j < firstRow + totalRows; j++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataTable.Rows.Add(dataRow);
				row = Rows.GetRow(j, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int k = firstColumn; k < firstColumn + totalColumns; k++)
				{
					Cell cellOrNull = row.GetCellOrNull(k);
					if (cellOrNull != null)
					{
						dataRow[k - firstColumn] = cellOrNull.DisplayStringValue;
					}
				}
			}
			return dataTable;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="exportColumnName">Indicates whether the data in the first row are exported to the column name of the DataTable.</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	/// <remarks>All data in the <see cref="T:Aspose.Cells.Cells" /> collection are converted to strings.</remarks>
	public DataTable ExportDataTableAsString(int firstRow, int firstColumn, int totalRows, int totalColumns, bool exportColumnName)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			if (exportColumnName)
			{
				DataTable dataTable;
				if (firstRow == 1048575)
				{
					dataTable = new DataTable();
					for (int i = firstColumn; i < firstColumn + totalColumns; i++)
					{
						DataColumn dataColumn = dataTable.Columns.Add();
						Cell cell = GetCell(firstRow, i, bool_2: false);
						if (cell.method_20() == Enum199.const_6)
						{
							dataColumn.ColumnName = cell.StringValue;
						}
					}
				}
				else
				{
					if (totalRows > 1)
					{
						dataTable = ExportDataTableAsString(firstRow + 1, firstColumn, totalRows - 1, totalColumns);
					}
					else
					{
						dataTable = new DataTable();
						for (int j = firstColumn; j < firstColumn + totalColumns; j++)
						{
							dataTable.Columns.Add();
							dataTable.Columns[j - firstColumn].DataType = typeof(string);
						}
					}
					int num = 0;
					for (int k = firstColumn; k < firstColumn + totalColumns; k++)
					{
						DataColumn dataColumn2 = dataTable.Columns[num];
						Cell cell2 = GetCell(firstRow, k, bool_2: false);
						if (cell2.method_20() == Enum199.const_6)
						{
							dataColumn2.ColumnName = cell2.StringValue;
						}
						num++;
					}
				}
				return dataTable;
			}
			return ExportDataTableAsString(firstRow, firstColumn, totalRows, totalColumns);
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a <see cref="T:System.Data.DataTable" /> object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="options">All export table ooptions</param>
	/// <returns>Exported <see cref="T:System.Data.DataTable" /> object.</returns>
	public DataTable ExportDataTable(int firstRow, int firstColumn, int totalRows, int totalColumns, ExportTableOptions options)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			Row row = null;
			DataTable dataTable = new DataTable();
			if (options.ExportColumnName)
			{
				row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
				for (int i = firstColumn; i < firstColumn + totalColumns; i++)
				{
					DataColumn dataColumn = dataTable.Columns.Add();
					if (row != null)
					{
						Cell cellOrNull = row.GetCellOrNull(i);
						if (cellOrNull != null)
						{
							dataColumn.ColumnName = cellOrNull.StringValue;
						}
					}
				}
				firstRow++;
				totalRows--;
			}
			if (totalRows <= 0)
			{
				return dataTable;
			}
			row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
			if (row != null)
			{
				for (int j = 0; j < totalColumns; j++)
				{
					Cell cellOrNull2 = row.GetCellOrNull(j + firstColumn);
					if (cellOrNull2 != null)
					{
						method_11(dataTable, j, cellOrNull2);
					}
					else
					{
						dataTable.Columns[j].DataType = typeof(string);
					}
				}
			}
			else
			{
				for (int k = 0; k < totalColumns; k++)
				{
					dataTable.Columns[k].DataType = typeof(string);
				}
			}
			for (int l = firstRow; l < firstRow + totalRows; l++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataTable.Rows.Add(dataRow);
				row = Rows.GetRow(l, bool_0: true, bool_1: false);
				if (row == null)
				{
					continue;
				}
				for (int m = firstColumn; m < firstColumn + totalColumns; m++)
				{
					Cell cellOrNull3 = row.GetCellOrNull(m);
					if (cellOrNull3 == null)
					{
						continue;
					}
					switch (cellOrNull3.Type)
					{
					case CellValueType.IsBool:
						if (dataTable.Columns[m - firstColumn].DataType == typeof(bool))
						{
							dataRow[m - firstColumn] = cellOrNull3.BoolValue;
						}
						else if (!options.SkipErrorValue)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull3.Name + " should not be a boolean value.");
						}
						break;
					case CellValueType.IsDateTime:
						if (dataTable.Columns[m - firstColumn].DataType == typeof(DateTime))
						{
							dataRow[m - firstColumn] = cellOrNull3.DateTimeValue;
						}
						else if (dataTable.Columns[m - firstColumn].DataType == typeof(string))
						{
							dataRow[m - firstColumn] = cellOrNull3.StringValue;
						}
						else if (!options.SkipErrorValue)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull3.Name + " should not be a datetime value.");
						}
						break;
					case CellValueType.IsNumeric:
						if (dataTable.Columns[m - firstColumn].DataType == typeof(double))
						{
							dataRow[m - firstColumn] = cellOrNull3.DoubleValue;
						}
						else if (dataTable.Columns[m - firstColumn].DataType == typeof(int))
						{
							dataRow[m - firstColumn] = cellOrNull3.IntValue;
						}
						else if (dataTable.Columns[m - firstColumn].DataType == typeof(string))
						{
							dataRow[m - firstColumn] = cellOrNull3.DoubleValue.ToString();
						}
						else if (dataTable.Columns[m - firstColumn].DataType == typeof(DateTime))
						{
							dataRow[m - firstColumn] = cellOrNull3.DateTimeValue;
						}
						else if (!options.SkipErrorValue)
						{
							throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull3.Name + " should not be a numberic value.");
						}
						break;
					case CellValueType.IsError:
					case CellValueType.IsString:
					case CellValueType.IsUnknown:
					{
						string stringValue = cellOrNull3.StringValue;
						if (stringValue != null && stringValue != "")
						{
							if (dataTable.Columns[m - firstColumn].DataType == typeof(string))
							{
								dataRow[m - firstColumn] = stringValue;
							}
							else if (!options.SkipErrorValue)
							{
								throw new CellsException(ExceptionType.InvalidData, "The value of the cell " + cellOrNull3.Name + " should not be a string value.");
							}
						}
						break;
					}
					}
				}
			}
			return dataTable;
		}
		throw new ArgumentException("Row number or column number cannot be zero");
	}

	public int ImportData(ICellsDataTable table, int firstRow, int firstColumn, ImportTableOptions options)
	{
		return Class774.ImportData(table, this, firstRow, firstColumn, options);
	}

	public int ImportData(DataTable table, int firstRow, int firstColumn, ImportTableOptions options)
	{
		ICellsDataTable icellsDataTable_ = new Class783(table);
		return Class774.ImportData(icellsDataTable_, this, firstRow, firstColumn, options);
	}

	public int ImportData(DataView dataView, int firstRow, int firstColumn, ImportTableOptions options)
	{
		ICellsDataTable icellsDataTable_ = new Class784(dataView);
		return Class774.ImportData(icellsDataTable_, this, firstRow, firstColumn, options);
	}

	public int Import(IDataReader dataReader, int firstRow, int firstColumn, ImportTableOptions options)
	{
		ICellsDataTable icellsDataTable_ = new Class782(dataReader, -1);
		return Class774.ImportData(icellsDataTable_, this, firstRow, firstColumn, options);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> object into a worksheet.		
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.</param>
	/// <param name="startCell">The name of start cell to insert the DataTable, such as "A2".</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, string startCell)
	{
		CellsHelper.CellNameToIndex(startCell, out var row, out var column);
		return ImportDataTable(dataTable, isFieldNameShown, row, column);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> object into a worksheet.		
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.</param>
	/// <param name="firstRow">The row number of the first cell to import.</param>
	/// <param name="firstColumn">The column number of the first cell to import.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, bool convertStringToNumber)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, dataTable.Rows.Count, dataTable.Columns.Count, insertRows, null, convertStringToNumber);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> object into a worksheet.		
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.</param>
	/// <param name="firstRow">The row number of the first cell to import.</param>
	/// <param name="firstColumn">The column number of the first cell to import.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, dataTable.Rows.Count, dataTable.Columns.Count, insertRows: true);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> object into a worksheet.		
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.</param>
	/// <param name="firstRow">The row number of the first cell to import.</param>
	/// <param name="firstColumn">The column number of the first cell to import.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, dataTable.Rows.Count, dataTable.Columns.Count, insertRows);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///       DataTable dt = new DataTable("Employee");
	///       dt.Columns.Add("Employee_ID",typeof(Int32));
	///       dt.Columns.Add("Employee_Name",typeof(string));
	///       dt.Columns.Add("Gender",typeof(string));
	///       DataRow dr = dt.NewRow();
	///       dr[0] = 1;
	///       dr[1] = "John Smith";
	///       dr[2] = "Male";
	///       dt.Rows.Add(dr);
	///       dr = dt.NewRow();
	///       dr[0] = 2;
	///       dr[1] = "Mary Miller";
	///       dr[2] = "Female";
	///       dt.Rows.Add(dr);
	///       cells.ImportDataTable(dt, true, 12, 12, 10, 10);
	///
	///       [Visual Basic]
	///
	///       Dim dt As DataTable =  New DataTable("Employee") 
	///       dt.Columns.Add("Employee_ID",Type.GetType(Int32))
	///       dt.Columns.Add("Employee_Name",Type.GetType(String))
	///       dt.Columns.Add("Gender",Type.GetType(String))
	///       Dim dr As DataRow =  dt.NewRow() 
	///       dr(0) = 1
	///       dr(1) = "John Smith"
	///       dr(2) = "Male"
	///       dt.Rows.Add(dr)
	///       dr = dt.NewRow()
	///       dr(0) = 2
	///       dr(1) = "Mary Miller"
	///       dr(2) = "Female"
	///       dt.Rows.Add(dr)
	///       cells.ImportDataTable(dt, True, 12, 12, 10, 10)
	///       </code>
	/// </example>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, totalRows, totalColumns, insertRows: true);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.ImportDataReader(SqlDataReader,int,int,bool) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Cells.ImportDataReader(SqlDataReader,int,int,bool) method. instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportFromDataReader(SqlDataReader reader, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportFromDataReader(reader, isFieldNameShown: false, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(SqlDataReader reader, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader(reader, isFieldNameShown: false, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.ImportDataReader(SqlDataReader,bool,int,int,bool) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Cells.ImportDataReader(SqlDataReader,bool,int,int,bool) method. instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportFromDataReader(SqlDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader(reader, isFieldNameShown, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(SqlDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader(reader, isFieldNameShown, firstRow, firstColumn, insertRows, null, convertStringToNumber: false);
	}

	/// <summary>
	///        Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///        </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///        Indicates whether the field name of the data reader will be imported to the first row.
	///        </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///        please use Cells.ImportDataReader(SqlDataReader, bool,int,int,bool,string,bool) method. 
	///        This property will be removed 12 months later since June 2010. 
	///        Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Cells.ImportDataReader(SqlDataReader,bool,int,int,bool,string,bool) method. instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportFromDataReader(SqlDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		return ImportDataReader(reader, isFieldNameShown, firstRow, firstColumn, insertRows, dateFormatString, convertStringToNumber);
	}

	/// <summary>
	///        Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///        </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///        Indicates whether the field name of the data reader will be imported to the first row.
	///        </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(SqlDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		return ImportDataReader((IDataReader)reader, isFieldNameShown, firstRow, firstColumn, insertRows, dateFormatString, convertStringToNumber);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.ImportDataReader(OleDbDataReader, bool,int,int,bool,string,bool) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Cells.ImportDataReader(OleDbDataReader,bool,int,int,bool,string,bool) method. instead.")]
	public int ImportFromDataReader(OleDbDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		return ImportDataReader(reader, isFieldNameShown, firstRow, firstColumn, insertRows, dateFormatString, convertStringToNumber);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(OleDbDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		return ImportDataReader((IDataReader)reader, isFieldNameShown, firstRow, firstColumn, insertRows, dateFormatString, convertStringToNumber);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.ImportDataReader(OleDbDataReader, bool,int,int,bool) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use Cells.ImportDataReader(OleDbDataReader,bool,int,int,bool) method. instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportFromDataReader(OleDbDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader(reader, isFieldNameShown, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data reader will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(OleDbDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader((IDataReader)reader, isFieldNameShown, firstRow, firstColumn, insertRows, (string)null, convertStringToNumber: false);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.ImportDataReader(OleDbDataReader,int,int,bool) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Cells.ImportDataReader(OleDbDataReader,int,int,bool) method. instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportFromDataReader(OleDbDataReader reader, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportFromDataReader(reader, isFieldNameShown: false, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///       Imports data from a <see cref="T:System.Data.OleDb.OleDbDataReader" /> object.
	///       </summary>
	/// <param name="reader">The <see cref="T:System.Data.OleDb.OleDbDataReader" /> object which contains data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(OleDbDataReader reader, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataReader(reader, isFieldNameShown: false, firstRow, firstColumn, insertRows);
	}

	/// <summary>
	///        Imports data from a <see cref="T:System.Data.SqlClient.SqlDataReader" /> object.
	///        </summary>
	/// <param name="reader">The <see cref="T:System.Data.SqlClient.SqlDataReader" /> object which contains data.</param>
	/// <param name="isFieldNameShown">
	///        Indicates whether the field name of the data reader will be imported to the first row.
	///        </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataReader(IDataReader reader, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(firstRow, firstColumn);
		if (firstRow >= method_20(0))
		{
			insertRows = false;
		}
		int num = firstRow;
		RowCollection rowCollection = null;
		if (insertRows)
		{
			rowCollection = new RowCollection(this, double_0, 16);
		}
		Row row = null;
		if (isFieldNameShown)
		{
			if (insertRows)
			{
				row = rowCollection.method_1(num, reader.FieldCount);
				for (int i = 0; i < reader.FieldCount; i++)
				{
					Cell cell = row.method_5(firstColumn + i);
					cell.PutValue(reader.GetName(i));
				}
				rowCollection.int_0 += row.method_0();
			}
			else
			{
				for (int j = 0; j < reader.FieldCount; j++)
				{
					GetCell(num, firstColumn + j, bool_2: false).PutValue(reader.GetName(j));
				}
			}
			num++;
		}
		while (reader.Read() && num <= 1048575)
		{
			if (insertRows)
			{
				row = rowCollection.method_1(num, reader.FieldCount);
				for (int k = 0; k < reader.FieldCount; k++)
				{
					object obj = reader[k];
					if (obj != null)
					{
						Cell cell_ = row.method_5(firstColumn + k);
						Class1677.smethod_4(cell_, obj, Type.GetTypeCode(reader.GetFieldType(k)) == TypeCode.DateTime, dateFormatString, convertStringToNumber);
					}
				}
				rowCollection.int_0 += row.method_0();
			}
			else
			{
				for (int l = 0; l < reader.FieldCount; l++)
				{
					object obj2 = reader[l];
					if (obj2 != null)
					{
						Class1677.smethod_4(GetCell(num, firstColumn + l, bool_2: false), obj2, Type.GetTypeCode(reader.GetFieldType(l)) == TypeCode.DateTime, dateFormatString, convertStringToNumber);
					}
				}
			}
			num++;
		}
		if (insertRows && rowCollection.Count > 0)
		{
			Rows.method_16(-1, -1, 0, rowCollection);
		}
		return num - firstRow;
	}

	/// <summary>
	///       Imports a column of a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data view will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="importColumnIndex">The index of the imported DataColumn in a <see cref="T:System.Data.DataTable" />.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	[Obsolete("Use Cells.ImportData(DataView,int,int,ImportTableOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportDataColumn(DataView dataView, bool isFieldNameShown, int firstRow, int firstColumn, int importColumnIndex, bool insertRows)
	{
		ImportTableOptions importTableOptions = new ImportTableOptions();
		importTableOptions.IsFieldNameShown = isFieldNameShown;
		importTableOptions.ColumnIndexes = new int[1] { importColumnIndex };
		importTableOptions.InsertRows = insertRows;
		return ImportData(dataView, firstRow, firstColumn, importTableOptions);
	}

	/// <summary>
	///       Imports a column of a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="importColumnName">The name of the imported DataColumn in a <see cref="T:System.Data.DataTable" />.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	[Browsable(false)]
	[Obsolete("Use Cells.ImportData(DataTable,int,int,ImportTableOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int ImportDataColumn(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, string importColumnName, bool insertRows)
	{
		method_19().Workbook.method_3();
		int num = dataTable.Columns.IndexOf(importColumnName);
		if (num == -1)
		{
			throw new CellsException(ExceptionType.InvalidData, "The specified column name(" + importColumnName + ") does not exist in this data table");
		}
		ImportTableOptions importTableOptions = new ImportTableOptions();
		importTableOptions.IsFieldNameShown = isFieldNameShown;
		importTableOptions.ColumnIndexes = new int[1] { num };
		importTableOptions.InsertRows = insertRows;
		return ImportData(dataTable, firstRow, firstColumn, importTableOptions);
	}

	/// <summary>
	///       Imports a column of a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="importColumnIndex">The index of the imported DataColumn in a <see cref="T:System.Data.DataTable" />.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.ImportData(DataTable,int,int,ImportTableOptions) method instead.")]
	public int ImportDataColumn(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int importColumnIndex, bool insertRows)
	{
		ImportTableOptions importTableOptions = new ImportTableOptions();
		importTableOptions.IsFieldNameShown = isFieldNameShown;
		importTableOptions.ColumnIndexes = new int[1] { importColumnIndex };
		importTableOptions.InsertRows = insertRows;
		return ImportData(dataTable, firstRow, firstColumn, importTableOptions);
	}

	/// <summary>
	///       Imports a column of a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="importColumnIndex">The index of the imported DataColumn in a <see cref="T:System.Data.DataTable" />.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="defaultValue">Default value for this data column.</param>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.ImportData(DataTable,int,int,ImportTableOptions) method instead.")]
	[Browsable(false)]
	public int ImportDataColumn(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int importColumnIndex, bool insertRows, object defaultValue)
	{
		ImportTableOptions importTableOptions = new ImportTableOptions();
		importTableOptions.IsFieldNameShown = isFieldNameShown;
		importTableOptions.ColumnIndexes = new int[1] { importColumnIndex };
		importTableOptions.InsertRows = insertRows;
		if (defaultValue != null)
		{
			importTableOptions.DefaultValues = new object[1] { defaultValue };
		}
		return ImportData(dataTable, firstRow, firstColumn, importTableOptions);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="rowNumber">Number of rows to be imported.</param>
	/// <param name="columnNumber">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>This method automatically format date time values. 
	///       However, if the DateTable is very huge, this method may slow down the program.
	///       In this case, you'd better format the cell manually.</remarks>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int rowNumber, int columnNumber, bool insertRows, string dateFormatString)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, rowNumber, columnNumber, insertRows, dateFormatString, convertStringToNumber: false);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="rowNumber">Number of rows to be imported.</param>
	/// <param name="columnNumber">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>This method automatically format date time values. 
	///       However, if the DateTable is very huge, this method may slow down the program.
	///       In this case, you'd better format the cell manually.</remarks>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int rowNumber, int columnNumber, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(firstRow, firstColumn);
		if (columnNumber >= 0 && rowNumber >= 0)
		{
			if (dataTable.Columns.Count != 0 && columnNumber != 0)
			{
				if (dataTable.Rows.Count != 0 && rowNumber != 0)
				{
					if (dataTable.Columns.Count < columnNumber)
					{
						columnNumber = dataTable.Columns.Count;
					}
					if (dataTable.Rows.Count < rowNumber)
					{
						rowNumber = dataTable.Rows.Count;
					}
					if (isFieldNameShown)
					{
						rowNumber++;
					}
					if (firstRow + rowNumber > 1048575)
					{
						rowNumber = 1048575 - firstRow + 1;
					}
					if (firstColumn + columnNumber > 16383)
					{
						columnNumber = 16383 - firstColumn + 1;
					}
					if (insertRows && firstRow < 1048575)
					{
						InsertRows(firstRow + 1, rowNumber);
						int num = firstRow + rowNumber;
						if (num <= 1048575)
						{
							CopyRow(this, firstRow, num);
						}
						ClearContents(firstRow, 0, firstRow, 16383);
					}
					if (isFieldNameShown)
					{
						method_14(dataTable, firstRow, firstColumn, columnNumber);
						firstRow++;
						rowNumber--;
					}
					int num2 = -1;
					RowCollection rowCollection = new RowCollection(this, double_0, rowNumber);
					int num3 = firstRow;
					Row row = null;
					int num4 = 0;
					int num5 = rowCollection_0.method_14(num3, num3 + rowNumber - 1);
					num2 = num5;
					for (int i = 0; i < rowNumber; i++)
					{
						DataRow dataRow = dataTable.Rows[i];
						num3 = firstRow + i;
						if (num5 != -1 && num5 < rowCollection_0.Count)
						{
							row = rowCollection_0.GetRowByIndex(num5);
							if (row.int_0 == num3)
							{
								num4 += row.method_0();
								num5++;
								row = rowCollection.method_2(row);
							}
							else
							{
								row = rowCollection.method_1(num3, columnNumber);
							}
						}
						else
						{
							row = rowCollection.method_1(num3, columnNumber);
						}
						for (int j = 0; j < columnNumber; j++)
						{
							DataColumn dataColumn = dataTable.Columns[j];
							Cell cell = row.GetCell(firstColumn + j, bool_1: false, bool_2: false);
							if (!dataRow.IsNull(dataColumn))
							{
								if (convertStringToNumber)
								{
									if (dataRow[j] is string)
									{
										cell.PutValue((string)dataRow[j], isConverted: true);
									}
									else
									{
										cell.PutValue(dataRow[j]);
									}
								}
								else
								{
									cell.PutValue(dataRow[j]);
								}
							}
							else
							{
								cell.PutValue(null);
							}
							if (dateFormatString != null && dateFormatString != "" && Type.GetTypeCode(dataColumn.DataType) == TypeCode.DateTime)
							{
								Style style = cell.method_28();
								style.Custom = dateFormatString;
								cell.method_30(style);
							}
						}
					}
					if (isFieldNameShown)
					{
						rowNumber++;
					}
					if (rowCollection.Count > 0)
					{
						rowCollection_0.method_16(num2, num5 - 1, num4, rowCollection);
					}
					return rowNumber;
				}
				if (isFieldNameShown)
				{
					method_14(dataTable, firstRow, firstColumn, columnNumber);
					return 1;
				}
				return 0;
			}
			return 0;
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid row/column number.");
	}

	/// <summary>
	///       Imports a DataRow into the Excel file.
	///       </summary>
	/// <param name="dataRow">DataRow object.</param>
	/// <param name="row">Row index.</param>
	/// <param name="firstColumn">First column index.</param>
	public void ImportDataRow(DataRow dataRow, int row, int firstColumn)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(row, firstColumn);
		object[] itemArray = dataRow.ItemArray;
		int num = itemArray.Length;
		if (firstColumn + num > 16383)
		{
			num = 16383 - firstColumn + 1;
		}
		for (int i = 0; i < num; i++)
		{
			GetCell(row, firstColumn + i, bool_2: false).PutValue(dataRow[i]);
		}
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataTable" /> into a worksheet.
	///       </summary>
	/// <param name="dataTable">The <see cref="T:System.Data.DataTable" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the datatable will be imported to the first row.
	///       Default is true.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="rowNumber">Number of rows to be imported.</param>
	/// <param name="columnNumber">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported.</returns>
	public int ImportDataTable(DataTable dataTable, bool isFieldNameShown, int firstRow, int firstColumn, int rowNumber, int columnNumber, bool insertRows)
	{
		return ImportDataTable(dataTable, isFieldNameShown, firstRow, firstColumn, rowNumber, columnNumber, insertRows, null);
	}

	/// <summary>
	///       Imports a two-dimension array of data into a worksheet.
	///       </summary>
	/// <param name="objArray">Two-dimension data array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportTwoDimensionArray(object[,] objArray, int firstRow, int firstColumn)
	{
		ImportTwoDimensionArray(objArray, firstRow, firstColumn, convertStringToNumber: false);
	}

	/// <summary>
	///       Imports a two-dimension array of data into a worksheet.
	///       </summary>
	/// <param name="objArray">Two-dimension data array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	public void ImportTwoDimensionArray(object[,] objArray, int firstRow, int firstColumn, bool convertStringToNumber)
	{
		ImportTwoDimensionArray(objArray, null, firstRow, firstColumn, convertStringToNumber);
	}

	public void ImportTwoDimensionArray(object[,] objArray, object[,] styles, int firstRow, int firstColumn, bool convertStringToNumber)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = objArray.GetUpperBound(0);
				int num2 = objArray.GetUpperBound(1);
				if (num + firstRow > 1048575)
				{
					num = 1048575 - firstRow;
				}
				if (num2 + firstColumn > 16383)
				{
					num2 = 16383 - firstColumn;
				}
				for (int i = 0; i <= num; i++)
				{
					Row row = Rows.GetRow(i + firstRow, bool_0: false, bool_1: false);
					for (int j = 0; j <= num2; j++)
					{
						Cell cell = row.GetCell(firstColumn + j, bool_1: false, bool_2: true);
						if (objArray[i, j] is string)
						{
							string text = (string)objArray[i, j];
							if (text.StartsWith("="))
							{
								cell.Formula = text;
							}
							else
							{
								cell.PutValue(text, convertStringToNumber);
							}
						}
						else
						{
							cell.PutValue(objArray[i, j]);
						}
						if (styles != null && styles[i, j] != null)
						{
							cell.SetStyle((Style)styles[i, j]);
						}
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports an array of data into a worksheet.
	///       </summary>
	/// <param name="objArray">Data array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportObjectArray(object[] objArray, int firstRow, int firstColumn, bool isVertical)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = objArray.Length;
				if (isVertical)
				{
					if (firstRow + num > 1048575)
					{
						num = 1048575 - firstRow + 1;
					}
					for (int i = 0; i < num; i++)
					{
						GetCell(firstRow + i, firstColumn, bool_2: false).PutValue(objArray[i]);
					}
				}
				else
				{
					if (firstColumn + num > 16383)
					{
						num = 16383 - firstColumn + 1;
					}
					for (int j = 0; j < num; j++)
					{
						GetCell(firstRow, firstColumn + j, bool_2: false).PutValue(objArray[j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports an arraylist of data into a worksheet.
	///       </summary>
	/// <param name="arrayList">Data arraylist.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportArrayList(ArrayList arrayList, int firstRow, int firstColumn, bool isVertical)
	{
		Class1677.CheckCell(firstRow, firstColumn);
		method_19().Workbook.method_3();
		int num = arrayList.Count;
		if (isVertical)
		{
			if (firstRow + num > 1048575)
			{
				num = 1048575 - firstRow + 1;
			}
			for (int i = 0; i < num; i++)
			{
				GetCell(firstRow + i, firstColumn, bool_2: false).PutValue(arrayList[i]);
			}
		}
		else
		{
			if (firstColumn + num > 16383)
			{
				num = 16383 - firstColumn + 1;
			}
			for (int j = 0; j < num; j++)
			{
				GetCell(firstRow, firstColumn + j, bool_2: false).PutValue(arrayList[j]);
			}
		}
	}

	/// <summary>
	///       Imports an array of data into a worksheet.
	///       </summary>
	/// <param name="objArray">Data array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	/// <param name="skip">Skipped number of rows or columns.</param>
	public void ImportObjectArray(object[] objArray, int firstRow, int firstColumn, bool isVertical, int skip)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && skip >= 0)
		{
			int num = objArray.Length;
			if (isVertical)
			{
				for (int i = 0; i < num; i++)
				{
					int num2 = firstRow + i * (skip + 1);
					if (num2 <= 1048575)
					{
						GetCell(num2, firstColumn, bool_2: false).PutValue(objArray[i]);
						continue;
					}
					break;
				}
				return;
			}
			for (int j = 0; j < num; j++)
			{
				int num3 = firstColumn + j * (skip + 1);
				if (num3 <= 16383)
				{
					GetCell(firstRow, num3, bool_2: false).PutValue(objArray[j]);
					continue;
				}
				break;
			}
			return;
		}
		throw new ArgumentException();
	}

	/// <summary>
	///       Imports a two-dimension array of string into a worksheet.
	///       </summary>
	/// <param name="stringArray">Two-dimension string array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportArray(string[,] stringArray, int firstRow, int firstColumn)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = stringArray.GetUpperBound(0);
				int num2 = stringArray.GetUpperBound(1);
				if (num + firstRow > 1048575)
				{
					num = 1048575 - firstRow;
				}
				if (num2 + firstColumn > 16383)
				{
					num2 = 16383 - firstColumn;
				}
				for (int i = 0; i <= num; i++)
				{
					for (int j = 0; j <= num2; j++)
					{
						GetCell(firstRow + i, firstColumn + j, bool_2: false).PutValue(stringArray[i, j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports an array of formula into a worksheet.
	///       </summary>
	/// <param name="stringArray">Formula array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportFormulaArray(string[] stringArray, int firstRow, int firstColumn, bool isVertical)
	{
		method_19().Workbook.method_3();
		int num = stringArray.Length;
		if (isVertical)
		{
			if (firstRow + num > 1048575)
			{
				num = 1048575 - firstRow + 1;
			}
			for (int i = 0; i < num; i++)
			{
				GetCell(firstRow + i, firstColumn, bool_2: false).Formula = stringArray[i];
			}
		}
		else
		{
			if (firstColumn + num > 16383)
			{
				num = 16383 - firstColumn + 1;
			}
			for (int j = 0; j < num; j++)
			{
				GetCell(firstRow, firstColumn + j, bool_2: false).Formula = stringArray[j];
			}
		}
	}

	/// <summary>
	///       Imports an array of string into a worksheet.
	///       </summary>
	/// <param name="stringArray">String array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportArray(string[] stringArray, int firstRow, int firstColumn, bool isVertical)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = stringArray.Length;
				if (isVertical)
				{
					if (firstRow + num > 1048575)
					{
						num = 1048575 - firstRow + 1;
					}
					for (int i = 0; i < num; i++)
					{
						GetCell(firstRow + i, firstColumn, bool_2: false).PutValue(stringArray[i]);
					}
				}
				else
				{
					if (firstColumn + num > 16383)
					{
						num = 16383 - firstColumn + 1;
					}
					for (int j = 0; j < num; j++)
					{
						GetCell(firstRow, firstColumn + j, bool_2: false).PutValue(stringArray[j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports a two-dimension array of integer into a worksheet.
	///       </summary>
	/// <param name="intArray">Two-dimension integer array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportArray(int[,] intArray, int firstRow, int firstColumn)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = intArray.GetUpperBound(0);
				int num2 = intArray.GetUpperBound(1);
				if (num + firstRow > 1048575)
				{
					num = 1048575 - firstRow;
				}
				if (num2 + firstColumn > 16383)
				{
					num2 = 16383 - firstColumn;
				}
				for (int i = 0; i <= num; i++)
				{
					for (int j = 0; j <= num2; j++)
					{
						GetCell(firstRow + i, firstColumn + j, bool_2: false).PutValue(intArray[i, j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports an array of integer into a worksheet.
	///       </summary>
	/// <param name="intArray">Integer array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportArray(int[] intArray, int firstRow, int firstColumn, bool isVertical)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = intArray.Length;
				if (isVertical)
				{
					if (firstRow + num > 1048575)
					{
						num = 1048575 - firstRow + 1;
					}
					for (int i = 0; i < num; i++)
					{
						GetCell(firstRow + i, firstColumn, bool_2: false).PutValue(intArray[i]);
					}
				}
				else
				{
					if (firstColumn + num > 16383)
					{
						num = 16383 - firstColumn + 1;
					}
					for (int j = 0; j < num; j++)
					{
						GetCell(firstRow, firstColumn + j, bool_2: false).PutValue(intArray[j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports a two-dimension array of double into a worksheet.
	///       </summary>
	/// <param name="doubleArray">Two-dimension double array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportArray(double[,] doubleArray, int firstRow, int firstColumn)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = doubleArray.GetUpperBound(0);
				int num2 = doubleArray.GetUpperBound(1);
				if (num + firstRow > 1048575)
				{
					num = 1048575 - firstRow;
				}
				if (num2 + firstColumn > 16383)
				{
					num2 = 16383 - firstColumn;
				}
				for (int i = 0; i <= num; i++)
				{
					for (int j = 0; j <= num2; j++)
					{
						GetCell(firstRow + i, firstColumn + j, bool_2: false).PutValue(doubleArray[i, j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	/// <summary>
	///       Imports an array of double into a worksheet.
	///       </summary>
	/// <param name="doubleArray">Double array.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="isVertical">Specifies to import data vertically or horizontally.</param>
	public void ImportArray(double[] doubleArray, int firstRow, int firstColumn, bool isVertical)
	{
		method_19().Workbook.method_3();
		if (firstRow >= 0 && firstRow <= 1048575)
		{
			if (firstColumn >= 0 && firstColumn <= 16383)
			{
				int num = doubleArray.Length;
				if (isVertical)
				{
					if (firstRow + num > 1048575)
					{
						num = 1048575 - firstRow + 1;
					}
					for (int i = 0; i < num; i++)
					{
						GetCell(firstRow + i, firstColumn, bool_2: false).PutValue(doubleArray[i]);
					}
				}
				else
				{
					if (firstColumn + num > 16383)
					{
						num = 16383 - firstColumn + 1;
					}
					for (int j = 0; j < num; j++)
					{
						GetCell(firstRow, firstColumn + j, bool_2: false).PutValue(doubleArray[j]);
					}
				}
				return;
			}
			throw new ArgumentException("First column index is out of range.");
		}
		throw new ArgumentException("First row index is out of range.");
	}

	private void method_14(DataTable dataTable_0, int int_0, int int_1, int int_2)
	{
		method_19().Workbook.method_3();
		if (dataTable_0.Columns.Count < int_2)
		{
			int_2 = dataTable_0.Columns.Count;
		}
		for (int i = 0; i < int_2; i++)
		{
			string caption = dataTable_0.Columns[i].Caption;
			Cell cell = GetCell(int_0, (short)(int_1 + i), bool_2: false);
			cell.PutValue(caption);
		}
	}

	/// <summary>
	///       Import a CSV file to the cells.
	///       </summary>
	/// <param name="fileName">The CSV file name.</param>
	/// <param name="spliter">The spliter</param>
	/// <param name="convertNumericData"> Whether the string in text file is converted to numeric data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportCSV(string fileName, string spliter, bool convertNumericData, int firstRow, int firstColumn)
	{
		TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
		txtLoadOptions.SeparatorString = spliter;
		txtLoadOptions.ConvertNumericData = convertNumericData;
		txtLoadOptions.ConvertDateTimeData = convertNumericData;
		if (!method_19().Workbook.Settings.bool_12)
		{
			txtLoadOptions.Encoding = method_19().Workbook.Settings.Encoding;
		}
		Class1731.Read(fileName, this, firstRow, firstColumn, txtLoadOptions);
	}

	/// <summary>
	///       Import a CSV file to the cells.
	///       </summary>
	/// <param name="stream">The CSV file stream.</param>
	/// <param name="spliter">The spliter</param>
	/// <param name="convertNumericData"> Whether the string in text file is converted to numeric data.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportCSV(Stream stream, string spliter, bool convertNumericData, int firstRow, int firstColumn)
	{
		TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
		txtLoadOptions.SeparatorString = spliter;
		txtLoadOptions.ConvertNumericData = convertNumericData;
		txtLoadOptions.ConvertDateTimeData = convertNumericData;
		StreamReader streamReader_;
		if (method_19().Workbook.Settings.bool_12)
		{
			streamReader_ = new StreamReader(stream);
		}
		else
		{
			streamReader_ = new StreamReader(stream, method_19().Workbook.Settings.Encoding);
			txtLoadOptions.Encoding = method_19().Workbook.Settings.Encoding;
		}
		Class1731.Read(streamReader_, this, firstRow, firstColumn, txtLoadOptions);
	}

	/// <summary>
	///       Import a CSV file to the cells.
	///       </summary>
	/// <param name="fileName">The CSV file name.</param>
	/// <param name="options">The load options for reading text file</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportCSV(string fileName, TxtLoadOptions options, int firstRow, int firstColumn)
	{
		Class1731.Read(fileName, this, firstRow, firstColumn, options);
	}

	/// <summary>
	///       Import a CSV file to the cells.
	///       </summary>
	/// <param name="stream">The CSV file stream.</param>
	/// <param name="options">The load options for reading text file</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	public void ImportCSV(Stream stream, TxtLoadOptions options, int firstRow, int firstColumn)
	{
		StreamReader streamReader_ = ((!options.bool_8) ? new StreamReader(stream, options.Encoding) : new StreamReader(stream));
		Class1731.Read(streamReader_, this, firstRow, firstColumn, options);
	}

	/// <summary>
	///       Merges a specified range of cells into a single cell. 		
	///       </summary>
	/// <param name="firstRow">First row of this range(zero based)</param>
	/// <param name="firstColumn">First column of this range(zero based)</param>
	/// <param name="totalRows">Number of rows(one based)</param>
	/// <param name="totalColumns">Number of columns(one based)</param>
	/// <remarks>
	///       Reference the merged cell via the address of the upper-left cell in the range. 
	///       </remarks>
	public void Merge(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		class1133_0.Merge(this, firstRow, firstColumn, totalRows, totalColumns);
	}

	/// <summary>
	///       Merges a specified range of cells into a single cell. 		
	///       </summary>
	/// <param name="firstRow">First row of this range(zero based)</param>
	/// <param name="firstColumn">First column of this range(zero based)</param>
	/// <param name="totalRows">Number of rows(one based)</param>
	/// <param name="totalColumns">Number of columns(one based)</param>
	/// <param name="mergeConflict">Merge conflict merged ranges.</param>
	/// <remarks>
	///       Reference the merged cell via the address of the upper-left cell in the range. 
	///       If mergeConflict is true and the merged range conflicts with other merged cells,
	///       other merged cells will be  automatically removed.
	///       </remarks>
	public void Merge(int firstRow, int firstColumn, int totalRows, int totalColumns, bool mergeConflict)
	{
		class1133_0.Merge(this, firstRow, firstColumn, totalRows, totalColumns, bool_0: true, mergeConflict);
	}

	/// <summary>
	///       Merges a specified range of cells into a single cell. 		
	///       </summary>
	/// <param name="firstRow">First row of this range(zero based)</param>
	/// <param name="firstColumn">First column of this range(zero based)</param>
	/// <param name="totalRows">Number of rows(one based)</param>
	/// <param name="totalColumns">Number of columns(one based)</param>
	/// <param name="checkConflict">Indicates whether check the merged cells intersects other merged cells</param>
	/// <param name="mergeConflict">Merge conflict merged ranges.</param>
	/// <remarks>
	///       Reference the merged cell via the address of the upper-left cell in the range. 
	///       If mergeConflict is true and the merged range conflicts with other merged cells,
	///       other merged cells will be  automatically removed.
	///       </remarks>
	public void Merge(int firstRow, int firstColumn, int totalRows, int totalColumns, bool checkConflict, bool mergeConflict)
	{
		class1133_0.Merge(this, firstRow, firstColumn, totalRows, totalColumns, checkConflict, mergeConflict);
	}

	/// <summary>
	///       Unmerges a specified range of merged cells. 		
	///       </summary>
	/// <param name="firstRow">First row of this range(zero based)</param>
	/// <param name="firstColumn">First column of this range(zero based)</param>
	/// <param name="totalRows">Number of rows(one based)</param>
	/// <param name="totalColumns">Number of columns(one based)</param>
	public void UnMerge(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		class1133_0.UnMerge(firstRow, firstColumn, totalRows, totalColumns);
	}

	/// <summary>
	///       Hides a row.
	///       </summary>
	/// <param name="row">Row index.</param>
	public void HideRow(int row)
	{
		SetRowHeight(row, 0.0);
	}

	/// <summary>
	///       Unhides a row.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="height">Row height.</param>
	public void UnhideRow(int row, double height)
	{
		SetRowHeight(row, height);
	}

	/// <summary>
	///       Hides multiple rows.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="totalRows">The row number.</param>
	public void HideRows(int row, int totalRows)
	{
		for (int i = 0; i < totalRows; i++)
		{
			Rows.GetRow(row + i, bool_0: false, bool_1: false).IsHidden = true;
		}
	}

	/// <summary>
	///       Unhides the hidden rows.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="totalRows">The row number.</param>
	/// <param name="height">Row height.</param>
	/// <remarks>
	///       Only applies row height to the hidden rows. 
	///       </remarks>
	public void UnhideRows(int row, int totalRows, double height)
	{
		for (int i = 0; i < totalRows; i++)
		{
			Row row2 = Rows.GetRow(row + i, bool_0: true, bool_1: false);
			if (row2 != null)
			{
				row2.IsHidden = false;
				row2.Height = height;
			}
		}
	}

	/// <summary>
	///       Sets row height in unit of pixels.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="pixels">Number of pixels.</param>
	public void SetRowHeightPixel(int row, int pixels)
	{
		double height = (float)pixels * 72f / (float)method_19().method_75();
		SetRowHeight(row, height);
	}

	/// <summary>
	///       Sets row height in unit of inches.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="inches">Number of inches.It should be between 0 and 409.5/72.</param>
	public void SetRowHeightInch(int row, double inches)
	{
		SetRowHeight(row, inches * 72.0);
	}

	/// <summary>
	///       Sets the height of the specified row.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="height">Height of row.In unit of point It should be between 0 and 409.5.</param>
	/// <remarks>To hide a row, sets row height to zero.</remarks>
	public void SetRowHeight(int row, double height)
	{
		if (!(height < 0.0) && height <= 409.5)
		{
			int num = (int)(height * 20.0 + 0.5);
			ushort ushort_ = (ushort)num;
			Row row2 = rowCollection_0.GetRow(row, bool_0: false, bool_1: true);
			row2.method_14(ushort_);
			if (height != 0.0)
			{
				row2.IsHeightMatched = false;
			}
			else
			{
				row2.IsHeightMatched = true;
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Row height must be between 0 and 409.");
	}

	/// <summary>
	///       Gets the height of a specified row.
	///       </summary>
	/// <param name="row">Row index</param>
	/// <returns>Height of row</returns>
	public double GetRowHeight(int row)
	{
		Class1677.smethod_24(row);
		int num = rowCollection_0.method_5(row);
		if (num != -1)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(num);
			if (rowByIndex.IsHidden)
			{
				return 0.0;
			}
			return (double)(int)rowByIndex.method_13() / 20.0;
		}
		if (method_25())
		{
			return 0.0;
		}
		return StandardHeight;
	}

	internal int method_15(int int_0)
	{
		if (int_0 >= 0 && int_0 <= 1048575)
		{
			int num = rowCollection_0.method_5(int_0);
			if (num != -1)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				return (int)((double)(int)rowByIndex.method_13() / 20.0 * (double)method_19().method_76() / 72.0 + 0.5);
			}
			return (int)(StandardHeight * (double)method_19().method_76() / 72.0 + 0.5);
		}
		return (int)(StandardHeight * (double)method_19().method_76() / 72.0 + 0.5);
	}

	/// <summary>
	///       Hides a column.
	///       </summary>
	/// <param name="column">Column index.</param>
	public void HideColumn(int column)
	{
		SetColumnWidth(column, 0.0);
	}

	/// <summary>
	///       Unhides a column
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="width">Column width.</param>
	public void UnhideColumn(int column, double width)
	{
		Class1677.smethod_25(column);
		SetColumnWidth(column, width);
	}

	/// <summary>
	///       Hide mutiple columns.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="totalColumns">Column number.</param>
	public void HideColumns(int column, int totalColumns)
	{
		for (int i = 0; i < totalColumns; i++)
		{
			Columns[i + column].IsHidden = true;
		}
	}

	/// <summary>
	///       Unhide mutiple columns.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="totlaColumns">Column number</param>
	/// <param name="width">Column width.</param>
	/// <remarks>
	///       Only applies the column width to the hidden columns.
	///       </remarks>
	public void UnhideColumns(int column, int totlaColumns, double width)
	{
		int num = method_19().method_72();
		int num2 = (int)((double)method_19().method_71() / 256.0 * (double)num + 0.5);
		if (width >= 1.0)
		{
			int num3 = (int)((width + 1.0) * (double)num + (double)num2 + 0.5);
			width = (double)(int)((double)(num3 - num2 - num) * 100.0 / (double)num + 0.5) / 100.0;
		}
		else
		{
			int num3 = (int)(width * (double)(num + num2) + 0.5);
			width = (double)(int)((double)num3 * 100.0 / (double)(num + num2) + 0.5) / 100.0;
		}
		for (int i = 0; i < totlaColumns; i++)
		{
			if (columnCollection_0.method_2(column + i))
			{
				Column column2 = columnCollection_0[column + i];
				column2.IsHidden = false;
				column2.Width = width;
				continue;
			}
			Column column3 = columnCollection_0.method_5(column + i);
			if (column3 != null && column3.IsHidden)
			{
				column3.IsHidden = false;
				column3.Width = width;
			}
		}
	}

	/// <summary>
	///       Gets the height of a specified row in unit of pixel.
	///       </summary>
	/// <param name="row">Row index</param>
	/// <returns>Height of row</returns>
	public int GetRowHeightPixel(int row)
	{
		double rowHeight = GetRowHeight(row);
		return (int)(rowHeight * (double)method_19().method_75() / 72.0);
	}

	/// <summary>
	///       Gets the height of a specified row in unit of inches.
	///       </summary>
	/// <param name="row">Row index</param>
	/// <returns>Height of row</returns>
	public double GetRowHeightInch(int row)
	{
		double rowHeight = GetRowHeight(row);
		return rowHeight / 72.0;
	}

	/// <summary>
	///       Sets column width in unit of pixels.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="pixel">Number of pixels.</param>
	public void SetColumnWidthPixel(int column, int pixel)
	{
		int num = method_19().method_72();
		int num2 = method_19().method_71();
		int num3 = method_19().method_73();
		if (pixel < num + num3)
		{
			double width = 1.0 * (double)pixel / (double)(num + num3);
			SetColumnWidth(column, width);
		}
		else
		{
			double width2 = (double)(int)((double)(pixel - (int)((double)(num * num2) / 256.0 + 0.5)) * 100.0 / (double)num + 0.5) / 100.0;
			SetColumnWidth(column, width2);
		}
	}

	internal void method_16(int int_0, int int_1)
	{
		int num = method_19().method_72();
		int num2 = method_19().method_71();
		int num3 = method_19().method_73();
		if (int_1 < num + num3)
		{
			double num4 = 1.0 * (double)int_1 / (double)(num + num3);
			if (num4 > 255.0)
			{
				num4 = 255.0;
			}
			SetColumnWidth(int_0, num4);
		}
		else
		{
			double num5 = (double)(int)((double)(int_1 - (int)((double)(num * num2) / 256.0 + 0.5)) * 100.0 / (double)num + 0.5) / 100.0;
			if (num5 > 255.0)
			{
				num5 = 255.0;
			}
			SetColumnWidth(int_0, num5);
		}
	}

	/// <summary>
	///       Sets column width in unit of inches.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="inches">Number of inches.</param>
	public void SetColumnWidthInch(int column, double inches)
	{
		SetColumnWidthPixel(column, (int)((double)method_19().method_75() * inches + 0.5));
	}

	/// <summary>
	///       Sets the width of the specified column.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <param name="width">Width of column.Column width must be between 0 and 255.</param>
	/// <remarks>To hide a column, sets column width to zero.</remarks>
	public void SetColumnWidth(int column, double width)
	{
		if (!(width > 255.0) && width >= 0.0)
		{
			int num = method_19().method_72();
			int num2 = (int)((double)method_19().method_71() / 256.0 * (double)num + 0.5);
			if (width >= 1.0)
			{
				int num3 = (int)((width + 1.0) * (double)num + (double)num2 + 0.5);
				width = (double)(int)((double)(num3 - num2 - num) * 100.0 / (double)num + 0.5) / 100.0;
			}
			else
			{
				int num3 = (int)(width * (double)(num + num2) + 0.5);
				width = (double)(int)((double)num3 * 100.0 / (double)(num + num2) + 0.5) / 100.0;
			}
			Column column2 = columnCollection_0[column];
			column2.Width = width;
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Column width must be between 0 and 255");
	}

	internal int method_17(int int_0)
	{
		Class1677.smethod_25(int_0);
		double num = Columns.method_3(int_0, bool_0: true);
		int num2 = columnCollection_0.method_7(int_0);
		if (num2 != -1)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(num2);
			num = columnByIndex.Width;
		}
		if (num > 1.0)
		{
			int num3 = (int)(num * (double)method_19().method_72() + 0.5);
			int num4 = (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5);
			return num3 + num4;
		}
		return (int)(num * (double)(method_19().method_72() + (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5)) + 0.5);
	}

	public int GetViewColumnWidthPixel(int column)
	{
		Class1677.smethod_25(column);
		double columnWidth = GetColumnWidth(column);
		double num = ((worksheet_0.ViewType == ViewType.PageLayoutView) ? 1.05 : 1.0);
		int num2;
		if (columnWidth > 1.0)
		{
			num2 = (int)(columnWidth * (double)method_19().method_72() + 0.5);
			int num3 = (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5);
			return (int)((double)(num2 + num3) * num + 0.5);
		}
		num2 = (int)(columnWidth * (double)(method_19().method_72() + (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5)) + 0.5);
		return (int)((double)num2 * num + 0.5);
	}

	/// <summary>
	///       Gets the width of the specified column, in units of pixel.
	///       </summary>
	/// <param name="column">Column index</param>
	/// <returns>Width of column</returns>
	public int GetColumnWidthPixel(int column)
	{
		Class1677.smethod_25(column);
		double columnWidth = GetColumnWidth(column);
		if (columnWidth > 1.0)
		{
			int num = (int)(columnWidth * (double)method_19().method_72() + 0.5);
			int num2 = (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5);
			return num + num2;
		}
		return (int)(columnWidth * (double)(method_19().method_72() + (int)((double)(method_19().method_72() * method_19().method_71()) / 256.0 + 0.5)) + 0.5);
	}

	/// <summary>
	///       Gets the width of the specified column, in units of inches.
	///       </summary>
	/// <param name="column">Column index</param>
	/// <returns>Width of column</returns>
	public double GetColumnWidthInch(int column)
	{
		return (double)GetColumnWidthPixel(column) / (double)method_19().method_75();
	}

	/// <summary>
	///       Gets the width of the specified column
	///       </summary>
	/// <param name="column">Column index</param>
	/// <returns>Width of column</returns>
	public double GetColumnWidth(int column)
	{
		Class1677.smethod_25(column);
		int num = columnCollection_0.method_7(column);
		if (num != -1)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
			if (columnByIndex.IsHidden)
			{
				return 0.0;
			}
			return columnByIndex.Width;
		}
		return Columns.method_3(column, bool_0: false);
	}

	[SpecialName]
	internal Class1133 method_18()
	{
		return class1133_0;
	}

	[SpecialName]
	internal WorksheetCollection method_19()
	{
		return worksheet_0.method_2();
	}

	/// <summary>
	///       Gets the maximum row index of cell which contains data in the specified column.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <returns>Maximum row index.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Cells.GetLastDataRow(int) method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Cells.GetLastDataRow(int) method instead.")]
	public int MaxDataRowInColumn(int column)
	{
		return GetLastDataRow(column);
	}

	/// <summary>
	///       Gets the last row index of cell which contains data in the specified column.
	///       </summary>
	/// <param name="column">Column index.</param>
	/// <returns>last row index.</returns>
	public int GetLastDataRow(int column)
	{
		int num = Rows.Count - 1;
		Row rowByIndex;
		while (true)
		{
			if (num >= 0)
			{
				rowByIndex = Rows.GetRowByIndex(num);
				Cell cellOrNull = rowByIndex.GetCellOrNull(column);
				if (cellOrNull != null && cellOrNull.method_20() != Enum199.const_7)
				{
					break;
				}
				num--;
				continue;
			}
			return 0;
		}
		return rowByIndex.int_0;
	}

	internal int method_20(int int_0)
	{
		return rowCollection_0.method_22(int_0);
	}

	internal void method_21(short short_1)
	{
		short_0 = short_1;
	}

	internal int method_22(short short_1)
	{
		if (short_0 < 0)
		{
			return short_1;
		}
		return short_0;
	}

	[SpecialName]
	internal byte method_23()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_24(byte byte_3)
	{
		byte_0 = byte_3;
	}

	[SpecialName]
	internal bool method_25()
	{
		if ((byte_0 & 2u) != 0)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal void method_26(bool bool_2)
	{
		if (bool_2)
		{
			byte_0 |= 2;
		}
		else
		{
			byte_0 &= 254;
		}
	}

	[SpecialName]
	internal byte method_27()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_28(byte byte_3)
	{
		byte_1 = byte_3;
	}

	[SpecialName]
	internal byte method_29()
	{
		return byte_2;
	}

	[SpecialName]
	internal void method_30(byte byte_3)
	{
		byte_2 = byte_3;
	}

	/// <summary>
	///       Applies formattings for a whole column.
	///       </summary>
	/// <param name="column">The column index.</param>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	public void ApplyColumnStyle(int column, Style style, StyleFlag flag)
	{
		Columns[column].ApplyStyle(style, flag);
	}

	/// <summary>
	///       Applies formattings for a whole row.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	public void ApplyRowStyle(int row, Style style, StyleFlag flag)
	{
		Class1677.smethod_24(row);
		Rows.GetRow(row, bool_0: false, bool_1: true).ApplyStyle(style, flag);
	}

	/// <summary>
	///       Applies formattings for a whole worksheet.
	///       </summary>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	public void ApplyStyle(Style style, StyleFlag flag)
	{
		Column column = null;
		if (columnCollection_0.column_0 == null)
		{
			column = (columnCollection_0.column_0 = new Column(0, worksheet_0, columnCollection_0.Width));
		}
		else
		{
			column = columnCollection_0.column_0;
			int index = columnCollection_0.column_0.Index;
			if (columnCollection_0.Count != 0)
			{
				for (int i = 0; i <= index; i++)
				{
					_ = columnCollection_0[i];
				}
			}
		}
		if (flag.All)
		{
			int num = method_19().method_59(style);
			column.method_6(num);
			for (int j = 0; j < columnCollection_0.Count; j++)
			{
				columnCollection_0.GetColumnByIndex(j).method_6(num);
			}
			Row row = null;
			Cell cell = null;
			for (int k = 0; k < rowCollection_0.Count; k++)
			{
				row = rowCollection_0.GetRowByIndex(k);
				row.method_11(num);
				ArrayList cells = row.Cells;
				for (int l = 0; l < cells.Count; l++)
				{
					cell = (Cell)cells[l];
					cell.method_37(num);
					if (cell.IsRichText())
					{
						cell.PutValue(cell.StringValue);
					}
				}
			}
			return;
		}
		Hashtable hashtable = new Hashtable();
		int num2 = 0;
		Style style2 = column.Style;
		Class1677.ApplyStyle(style, style2, flag);
		num2 = column.method_5();
		column.method_6(method_19().method_59(style2));
		hashtable.Add(num2, column.method_5());
		for (int m = 0; m < columnCollection_0.Count; m++)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(m);
			if (hashtable[columnByIndex.method_5()] != null)
			{
				columnByIndex.method_6((int)hashtable[columnByIndex.method_5()]);
				continue;
			}
			Style style3 = columnByIndex.Style;
			Class1677.ApplyStyle(style, style3, flag);
			num2 = columnByIndex.method_5();
			columnByIndex.method_6(method_19().method_59(style3));
			hashtable.Add(num2, columnByIndex.method_5());
		}
		for (int n = 0; n < rowCollection_0.Count; n++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(n);
			if (rowByIndex.method_27())
			{
				if (hashtable[rowByIndex.method_10()] != null)
				{
					rowByIndex.method_11((int)hashtable[rowByIndex.method_10()]);
				}
				else
				{
					Style style4 = rowByIndex.Style;
					Class1677.ApplyStyle(style, style4, flag);
					num2 = rowByIndex.method_10();
					rowByIndex.method_11(method_19().method_59(style4));
					hashtable.Add(num2, rowByIndex.method_10());
				}
			}
			else if (hashtable[15] != null)
			{
				rowByIndex.method_11((int)hashtable[rowByIndex.method_10()]);
			}
			else
			{
				Style style5 = rowByIndex.Style;
				Class1677.ApplyStyle(style, style5, flag);
				num2 = 15;
				rowByIndex.method_11(method_19().method_59(style5));
				hashtable.Add(15, rowByIndex.method_10());
			}
			for (int num3 = 0; num3 < rowByIndex.method_0(); num3++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(num3);
				if (cellByIndex.IsRichText())
				{
					cellByIndex.method_58().ApplyStyle(cellByIndex, style, flag);
				}
				if (hashtable[cellByIndex.method_36()] != null)
				{
					cellByIndex.method_37((int)hashtable[cellByIndex.method_36()]);
					continue;
				}
				Style style_ = cellByIndex.method_28();
				Class1677.ApplyStyle(style, style_, flag);
				num2 = cellByIndex.method_36();
				cellByIndex.method_37(method_19().method_59(style_));
				hashtable.Add(num2, cellByIndex.method_36());
			}
		}
	}

	/// <summary>
	///       Copies data and formattings of a whole column.
	///       </summary>
	/// <param name="sourceCells">Source Cells object contains data and formattings to copy.</param>
	/// <param name="sourceColumnIndex">Source column index.</param>
	/// <param name="destinationColumnIndex">Destination column index.</param>
	public void CopyColumn(Cells sourceCells, int sourceColumnIndex, int destinationColumnIndex)
	{
		CopyColumns(sourceCells, sourceColumnIndex, destinationColumnIndex, 1);
	}

	/// <summary>
	///       Copies data and formattings of a whole column.
	///       </summary>
	/// <param name="sourceCells">Source Cells object contains data and formattings to copy.</param>
	/// <param name="sourceColumnIndex">Source column index.</param>
	/// <param name="destinationColumnIndex">Destination column index.</param>
	/// <param name="columnNumber">The copied column number.</param>
	public void CopyColumns(Cells sourceCells, int sourceColumnIndex, int destinationColumnIndex, int columnNumber)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_25(sourceColumnIndex);
		Class1677.smethod_25(destinationColumnIndex);
		if (sourceCells == this && sourceColumnIndex == destinationColumnIndex)
		{
			return;
		}
		for (int i = 0; i < sourceCells.columnCollection_0.Count; i++)
		{
			Column columnByIndex = sourceCells.columnCollection_0.GetColumnByIndex(i);
			if (columnByIndex.Index >= sourceColumnIndex)
			{
				if (columnByIndex.Index >= sourceColumnIndex + columnNumber)
				{
					break;
				}
				Column column = columnCollection_0[destinationColumnIndex + columnByIndex.Index - sourceColumnIndex];
				column.CopyData(columnByIndex);
			}
		}
		rowCollection_0.CopyColumns(sourceCells.rowCollection_0, sourceColumnIndex, destinationColumnIndex, columnNumber);
		class1133_0.CopyColumns(sourceCells.class1133_0, sourceColumnIndex, destinationColumnIndex, columnNumber);
		hyperlinkCollection_0.CopyColumns(sourceCells.hyperlinkCollection_0, sourceColumnIndex, destinationColumnIndex, columnNumber);
		if (sourceCells.worksheet_0.Validations.Count != 0)
		{
			worksheet_0.Validations.method_3(sourceCells.worksheet_0.Validations, sourceColumnIndex, destinationColumnIndex, columnNumber, null);
		}
		if (sourceCells.worksheet_0.Shapes.Count != 0)
		{
			worksheet_0.Shapes.method_10(sourceCells.worksheet_0.Shapes, sourceColumnIndex, destinationColumnIndex, columnNumber);
		}
	}

	/// <summary>
	///       Copies data and formattings of a whole row.
	///       </summary>
	/// <param name="sourceCells">Source Cells object contains data and formattings to copy.</param>
	/// <param name="sourceRowIndex">Source row index.</param>
	/// <param name="destinationRowIndex">Destination row index.</param>
	public void CopyRow(Cells sourceCells, int sourceRowIndex, int destinationRowIndex)
	{
		CopyRows(sourceCells, sourceRowIndex, destinationRowIndex, 1);
	}

	/// <summary>
	///       Copies data and formattings of some whole rows.
	///       </summary>
	/// <param name="sourceCells">Source Cells object contains data and formattings to copy.</param>
	/// <param name="sourceRowIndex">Source row index.</param>
	/// <param name="destinationRowIndex">Destination row index.</param>
	/// <param name="rowNumber">The copied row number.</param>
	public void CopyRows(Cells sourceCells, int sourceRowIndex, int destinationRowIndex, int rowNumber)
	{
		method_19().Workbook.method_3();
		if (sourceRowIndex >= 0 && sourceRowIndex <= 1048575 && destinationRowIndex >= 0 && destinationRowIndex <= 1048575)
		{
			if (sourceCells == this && sourceRowIndex == destinationRowIndex)
			{
				return;
			}
			rowCollection_0.CopyRows(sourceCells.Rows, sourceRowIndex, destinationRowIndex, rowNumber);
			class1133_0.CopyRows(sourceCells.class1133_0, sourceRowIndex, destinationRowIndex, rowNumber);
			int count = sourceCells.hyperlinkCollection_0.Count;
			for (int i = 0; i < count; i++)
			{
				Hyperlink hyperlink = sourceCells.hyperlinkCollection_0[i];
				CellArea area = hyperlink.Area;
				if (area.StartRow >= sourceRowIndex && area.EndRow < sourceRowIndex + rowNumber)
				{
					CellArea cellArea_ = default(CellArea);
					int num = area.StartRow - sourceRowIndex;
					int num2 = area.EndRow - area.StartRow;
					cellArea_.StartRow = destinationRowIndex + num;
					cellArea_.EndRow = cellArea_.StartRow + num2;
					cellArea_.StartColumn = area.StartColumn;
					cellArea_.EndColumn = area.EndColumn;
					Hyperlink hyperlink2 = new Hyperlink(hyperlinkCollection_0, cellArea_);
					hyperlink2.CopyData(hyperlink);
					hyperlinkCollection_0.Add(hyperlink2);
				}
			}
			if (sourceCells.worksheet_0.ConditionalFormattings.Count != 0)
			{
				worksheet_0.ConditionalFormattings.CopyRows(sourceCells.worksheet_0.ConditionalFormattings, sourceRowIndex, destinationRowIndex, rowNumber);
			}
			if (sourceCells.worksheet_0.Validations.Count != 0)
			{
				worksheet_0.Validations.method_2(sourceCells.worksheet_0.Validations, sourceRowIndex, destinationRowIndex, rowNumber, null);
			}
			if (sourceCells.worksheet_0.method_36() != null && sourceCells.worksheet_0.method_36().Count != 0)
			{
				worksheet_0.Shapes.method_11(sourceCells.worksheet_0.method_36(), sourceRowIndex, destinationRowIndex, rowNumber);
			}
			return;
		}
		throw new ArgumentException("Row index is out of range.");
	}

	internal void Copy(Cells cells_0, CopyOptions copyOptions_0)
	{
		method_19().Workbook.method_3();
		byte_1 = cells_0.byte_1;
		byte_2 = cells_0.byte_2;
		double_0 = cells_0.double_0;
		byte_0 = cells_0.byte_0;
		int int_ = ((cells_0.Rows.Count > 32) ? cells_0.Rows.Count : 32);
		rowCollection_0 = new RowCollection(this, double_0, int_);
		if (copyOptions_0 != null)
		{
			bool flag = false;
			if (copyOptions_0.bool_0)
			{
				flag = true;
			}
			else if (method_19() == cells_0.method_19())
			{
				flag = true;
			}
			else if (method_19().DefaultFont.method_18(cells_0.method_19().DefaultFont))
			{
				flag = true;
			}
			copyOptions_0.bool_1 = flag;
		}
		rowCollection_0.Copy(cells_0.rowCollection_0, copyOptions_0);
		columnCollection_0.Copy(cells_0.columnCollection_0, copyOptions_0);
		if (cells_0.hyperlinkCollection_0.Count > 0)
		{
			hyperlinkCollection_0.Copy(cells_0.hyperlinkCollection_0);
		}
		if (cells_0.horizontalPageBreakCollection_0.Count > 0)
		{
			horizontalPageBreakCollection_0.Copy(cells_0.horizontalPageBreakCollection_0);
		}
		bool_1 = cells_0.bool_1;
		bool_0 = cells_0.bool_0;
		if (cells_0.class1133_0.Count > 0)
		{
			class1133_0.Copy(cells_0.class1133_0);
		}
		pageSetup_0.Copy(cells_0.pageSetup_0, copyOptions_0);
		if (cells_0.rangeCollection_0.Count > 0)
		{
			for (int i = 0; i < cells_0.rangeCollection_0.Count; i++)
			{
				Range range = cells_0.rangeCollection_0[i];
				Range range2 = new Range(range.FirstRow, range.FirstColumn, range.RowCount, range.ColumnCount, this);
				range2.method_3(range);
			}
		}
		if (cells_0.verticalPageBreakCollection_0.Count > 0)
		{
			verticalPageBreakCollection_0.Copy(cells_0.verticalPageBreakCollection_0);
		}
	}

	/// <summary>
	///       Gets the outline level(zero-based) of the row.
	///       </summary>
	/// <param name="rowIndex">The row index.</param>
	/// <returns>The outline level(zero-based) of the row.</returns>
	/// <remarks>If the row is not grouped, returns zero.</remarks>
	public int GetGroupedRowOutlineLevel(int rowIndex)
	{
		return rowCollection_0.GetRow(rowIndex, bool_0: true, bool_1: false)?.method_24() ?? 0;
	}

	/// <summary>
	///       Gets the outline level(zero-based) of the column.
	///       </summary>
	/// <param name="columnIndex">The column index</param>
	/// <returns>The outline level of the column</returns>
	/// <remarks>If the column is not grouped, returns zero.</remarks>
	public int GetGroupedColumnOutlineLevel(int columnIndex)
	{
		int num = columnCollection_0.method_7(columnIndex);
		if (num == -1)
		{
			return 0;
		}
		Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
		return columnByIndex.method_3();
	}

	/// <summary>
	///       Gets the max grouped column outline level(zero-based).
	///       </summary>
	/// <returns> The max grouped column outline level(zero-based)</returns>
	public int GetMaxGroupedColumnOutlineLevel()
	{
		return byte_1;
	}

	/// <summary>
	///       Gets the max grouped row outline level(zero-based).
	///       </summary>
	/// <returns> The max grouped row outline level(zero-based)</returns>
	public int GetMaxGroupedRowOutlineLevel()
	{
		return byte_2;
	}

	/// <summary>
	///       Uncollapses the grouped rows/columns. 
	///       </summary>
	/// <param name="isVertical">True, uncollapse the grouped rows.</param>
	/// <param name="index">The row/column index</param>
	public void ShowGroupDetail(bool isVertical, int index)
	{
		int arrIndex = -1;
		if (isVertical)
		{
			if (!rowCollection_0.method_15(index, out arrIndex))
			{
				return;
			}
			Row rowByIndex = rowCollection_0.GetRowByIndex(arrIndex);
			if (rowByIndex.method_24() == 0)
			{
				return;
			}
			Row row = null;
			for (int i = arrIndex; i < rowCollection_0.Count; i++)
			{
				row = rowCollection_0.GetRowByIndex(i);
				if (row.int_0 != index + i - arrIndex || rowByIndex.method_24() > row.method_24())
				{
					break;
				}
				row.IsHidden = false;
			}
			int num = arrIndex - 1;
			while (num >= 0)
			{
				row = rowCollection_0.GetRowByIndex(num);
				if (row.int_0 == index - (arrIndex - num) && rowByIndex.method_24() <= row.method_24())
				{
					row.IsHidden = false;
					num--;
					continue;
				}
				break;
			}
			return;
		}
		arrIndex = columnCollection_0.method_7(index);
		if (arrIndex == -1)
		{
			return;
		}
		Column columnByIndex = columnCollection_0.GetColumnByIndex(arrIndex);
		if (columnByIndex.method_3() == 0)
		{
			return;
		}
		Column column = null;
		for (int j = arrIndex; j < columnCollection_0.Count; j++)
		{
			column = columnCollection_0.GetColumnByIndex(j);
			if (column.Index != columnByIndex.Index + j - arrIndex || columnByIndex.method_3() > column.method_3())
			{
				break;
			}
			column.IsHidden = false;
		}
		int num2 = arrIndex - 1;
		while (num2 >= 0)
		{
			column = columnCollection_0.GetColumnByIndex(num2);
			if (column.Index == columnByIndex.Index - (arrIndex - num2) && columnByIndex.method_3() <= column.method_3())
			{
				column.IsHidden = false;
				num2--;
				continue;
			}
			break;
		}
	}

	/// <summary>
	///       Collapses the grouped rows/columns. 
	///       </summary>
	/// <param name="isVertical">True, collapse the grouped rows.</param>
	/// <param name="index">The row/column index</param>
	public void HideGroupDetail(bool isVertical, int index)
	{
		int arrIndex = -1;
		if (isVertical)
		{
			if (!rowCollection_0.method_15(index, out arrIndex))
			{
				return;
			}
			Row rowByIndex = rowCollection_0.GetRowByIndex(arrIndex);
			if (rowByIndex.method_24() == 0)
			{
				return;
			}
			int num = arrIndex;
			int num2 = arrIndex;
			Row row = null;
			for (int i = arrIndex + 1; i < rowCollection_0.Count; i++)
			{
				row = rowCollection_0.GetRowByIndex(i);
				if (row.int_0 != rowByIndex.int_0 + i - arrIndex || rowByIndex.method_24() > row.method_24())
				{
					break;
				}
				num2 = i;
			}
			for (int num3 = arrIndex - 1; num3 >= 0; num3--)
			{
				row = rowCollection_0.GetRowByIndex(num3);
				if (row.int_0 != rowByIndex.int_0 + num3 - arrIndex || rowByIndex.method_24() > row.method_24())
				{
					break;
				}
				num = num3;
			}
			for (int j = num; j <= num2; j++)
			{
				rowCollection_0.GetRowByIndex(j).IsHidden = true;
			}
			return;
		}
		arrIndex = columnCollection_0.method_7(index);
		if (arrIndex == -1)
		{
			return;
		}
		Column columnByIndex = columnCollection_0.GetColumnByIndex(arrIndex);
		if (columnByIndex.method_3() == 0)
		{
			return;
		}
		Column column = null;
		int num4 = arrIndex;
		int num5 = arrIndex;
		for (int k = arrIndex + 1; k < columnCollection_0.Count; k++)
		{
			column = columnCollection_0.GetColumnByIndex(k);
			if (column.Index != columnByIndex.Index + k - arrIndex || columnByIndex.method_3() > column.method_3())
			{
				break;
			}
			num5 = k;
		}
		for (int num6 = arrIndex - 1; num6 >= 0; num6--)
		{
			column = columnCollection_0.GetColumnByIndex(num6);
			if (column.Index != columnByIndex.Index + num6 - arrIndex || columnByIndex.method_3() > column.method_3())
			{
				break;
			}
			num4 = num6;
		}
		for (int l = num4; l <= num5; l++)
		{
			columnCollection_0.GetColumnByIndex(l).IsHidden = true;
		}
	}

	/// <summary>
	///       Ungroups columns.
	///       </summary>
	/// <param name="firstIndex">The first column index to be ungrouped.</param>
	/// <param name="lastIndex">The last column index to be ungrouped.</param>
	public void UngroupColumns(int firstIndex, int lastIndex)
	{
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			int num = columnCollection_0.method_7(i);
			if (num != -1)
			{
				Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
				columnByIndex.method_4(0);
			}
		}
		int num2 = 0;
		for (int j = 0; j < columnCollection_0.Count; j++)
		{
			Column columnByIndex2 = columnCollection_0.GetColumnByIndex(j);
			if (columnByIndex2.method_3() > num2)
			{
				num2 = columnByIndex2.method_3();
			}
		}
		byte_1 = (byte)num2;
	}

	/// <summary>
	///       Groups columns.
	///       </summary>
	/// <param name="firstIndex">The first column index to be grouped.</param>
	/// <param name="lastIndex">The last column index to be grouped.</param>
	public void GroupColumns(int firstIndex, int lastIndex)
	{
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			int num = columnCollection_0.method_7(i);
			if (num == -1)
			{
				Column column = columnCollection_0[i];
				column.method_6(15);
				column.method_4(1);
				if (column.method_3() > byte_1)
				{
					byte_1 = column.method_3();
				}
				continue;
			}
			Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
			if (columnByIndex.method_3() < 7)
			{
				columnByIndex.method_4((byte)(columnByIndex.method_3() + 1));
			}
			if (columnByIndex.method_3() > byte_1)
			{
				byte_1 = columnByIndex.method_3();
			}
		}
	}

	/// <summary>
	///       Groups columns.
	///       </summary>
	/// <param name="firstIndex">The first column index to be grouped.</param>
	/// <param name="lastIndex">The last column index to be grouped.</param>
	/// <param name="isHidden">Specifies if the grouped columns are hidden.</param>
	public void GroupColumns(int firstIndex, int lastIndex, bool isHidden)
	{
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			int num = columnCollection_0.method_7(i);
			Column column;
			if (num == -1)
			{
				column = columnCollection_0[i];
				column.method_6(15);
				column.method_4(1);
				column.IsHidden = isHidden;
				if (column.method_3() > byte_1)
				{
					byte_1 = column.method_3();
				}
			}
			else
			{
				column = columnCollection_0.GetColumnByIndex(num);
				if (column.method_3() < 7)
				{
					column.method_4((byte)(column.method_3() + 1));
				}
				column.IsHidden = isHidden;
				if (column.method_3() > byte_1)
				{
					byte_1 = column.method_3();
				}
			}
			if (!isHidden)
			{
				continue;
			}
			if (i == lastIndex && worksheet_0.Outline.SummaryColumnRight)
			{
				column.method_15(bool_0: true);
				if (i < 16383)
				{
					num = columnCollection_0.method_7(i + 1);
					if (num != -1)
					{
						column = columnCollection_0.GetColumnByIndex(num);
					}
					else
					{
						column = columnCollection_0[i + 1];
						column.method_6(15);
					}
					column.method_15(bool_0: true);
				}
			}
			else
			{
				if (i != firstIndex || worksheet_0.Outline.SummaryColumnRight)
				{
					continue;
				}
				column.method_15(bool_0: true);
				if (i > 0)
				{
					num = columnCollection_0.method_7(i - 1);
					if (num != -1)
					{
						column = columnCollection_0.GetColumnByIndex(num);
					}
					else
					{
						column = columnCollection_0[i - 1];
						column.method_6(15);
					}
					column.method_15(bool_0: true);
				}
			}
		}
	}

	/// <summary>
	///       Ungroups rows.
	///       </summary>
	/// <param name="firstIndex">The first row index to be ungrouped.</param>
	/// <param name="lastIndex">The last row index to be ungrouped.</param>
	/// <param name="isAll">True, removes all grouped info.Otherwise, remove the outter group info.</param>
	public void UngroupRows(int firstIndex, int lastIndex, bool isAll)
	{
		Class1677.smethod_27(firstIndex, lastIndex);
		if (isAll)
		{
			for (int i = firstIndex; i <= lastIndex; i++)
			{
				int num = rowCollection_0.method_5(i);
				if (num != -1)
				{
					Row rowByIndex = rowCollection_0.GetRowByIndex(num);
					rowByIndex.method_25(0);
					rowByIndex.method_19(bool_1: false);
				}
			}
		}
		else
		{
			for (int j = firstIndex; j <= lastIndex; j++)
			{
				int num2 = rowCollection_0.method_5(j);
				if (num2 != -1)
				{
					Row rowByIndex2 = rowCollection_0.GetRowByIndex(num2);
					if (rowByIndex2.method_24() > 0)
					{
						rowByIndex2.method_25((byte)(rowByIndex2.method_24() - 1));
					}
					if (rowByIndex2.method_24() == 0)
					{
						rowByIndex2.method_19(bool_1: false);
					}
				}
			}
		}
		int num3 = byte_2;
		int num4 = 0;
		int num5 = 0;
		while (true)
		{
			if (num5 < rowCollection_0.Count)
			{
				Row rowByIndex3 = rowCollection_0.GetRowByIndex(num5);
				num4 = byte_2 - rowByIndex3.method_24();
				if (num4 != 0)
				{
					if (num4 < num3)
					{
						num3 = num4;
					}
					num5++;
					continue;
				}
				break;
			}
			byte_2 = (byte)(byte_2 - num3);
			break;
		}
	}

	/// <summary>
	///       Ungroups rows.
	///       </summary>
	/// <param name="firstIndex">The first row index to be ungrouped.</param>
	/// <param name="lastIndex">The last row index to be ungrouped.</param>
	/// <remarks>
	///       Only removes outter group info.
	///       </remarks>
	public void UngroupRows(int firstIndex, int lastIndex)
	{
		UngroupRows(firstIndex, lastIndex, isAll: false);
	}

	/// <summary>
	///       Groups rows.
	///       </summary>
	/// <param name="firstIndex">The first row index to be grouped.</param>
	/// <param name="lastIndex">The last row index to be grouped.</param>
	/// <param name="isHidden">Specifies if the grouped columns are hidden.</param>
	public void GroupRows(int firstIndex, int lastIndex, bool isHidden)
	{
		Class1677.smethod_27(firstIndex, lastIndex);
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			Row row = rowCollection_0.GetRow(i, bool_0: false, bool_1: true);
			if (row.method_24() < 7)
			{
				row.method_25((byte)(row.method_24() + 1));
			}
			row.IsHidden = isHidden;
			if (row.method_24() > byte_2)
			{
				byte_2 = row.method_24();
			}
			if (!isHidden)
			{
				continue;
			}
			if (i == lastIndex && worksheet_0.Outline.SummaryRowBelow)
			{
				row.method_19(bool_1: true);
				if (i < 1048575)
				{
					row = rowCollection_0.GetRow(i + 1, bool_0: false, bool_1: true);
					row.method_19(bool_1: true);
				}
			}
			else if (i == firstIndex && !worksheet_0.Outline.SummaryRowBelow)
			{
				row.method_19(bool_1: true);
				if (i > 0)
				{
					row = rowCollection_0.GetRow(i - 1, bool_0: false, bool_1: true);
					row.method_19(bool_1: true);
				}
			}
		}
	}

	/// <summary>
	///       Groups rows.
	///       </summary>
	/// <param name="firstIndex">The first row index to be grouped.</param>
	/// <param name="lastIndex">The last row index to be grouped.</param>
	public void GroupRows(int firstIndex, int lastIndex)
	{
		Class1677.smethod_27(firstIndex, lastIndex);
		for (int i = firstIndex; i <= lastIndex; i++)
		{
			Row row = rowCollection_0.GetRow(i, bool_0: false, bool_1: true);
			if (row.method_24() < 7)
			{
				row.method_25((byte)(row.method_24() + 1));
			}
			if (row.method_24() > byte_2)
			{
				byte_2 = row.method_24();
			}
		}
	}

	/// <summary>
	///       Deletes a column.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="updateReference">Indicates if update references in other worksheets.</param>
	public void DeleteColumn(int columnIndex, bool updateReference)
	{
		method_19().Workbook.method_3();
		DeleteColumn(columnIndex);
		if (!updateReference)
		{
			return;
		}
		method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
		for (int i = 0; i < method_19().Count; i++)
		{
			if (i == worksheet_0.SheetIndex)
			{
				continue;
			}
			Worksheet worksheet = method_19()[i];
			Cells cells = worksheet.Cells;
			for (int j = 0; j < cells.rowCollection_0.Count; j++)
			{
				Row rowByIndex = cells.rowCollection_0.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						cellByIndex.InsertColumns(columnIndex, -1, worksheet_0, bool_0: false);
					}
				}
			}
			if (worksheet.Charts.Count > 0)
			{
				worksheet.Charts.InsertColumns(columnIndex, -1, worksheet_0, bool_0: false);
			}
		}
	}

	/// <summary>
	///       Deletes a column.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	public void DeleteColumn(int columnIndex)
	{
		DeleteColumns(columnIndex, 1, updateReference: false);
	}

	/// <summary>
	///       Deletes several columns.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="totalColumns">Number of columns to be deleted.</param>
	/// <param name="updateReference">Indicates if update references in other worksheets.</param>
	public void DeleteColumns(int columnIndex, int totalColumns, bool updateReference)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_25(columnIndex);
		columnCollection_0.method_10(columnIndex, totalColumns);
		if (short_0 >= columnIndex)
		{
			short_0 -= (short)totalColumns;
		}
		rowCollection_0.DeleteColumns(columnIndex, totalColumns);
		if (updateReference)
		{
			method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
			for (int i = 0; i < method_19().Count; i++)
			{
				if (i == worksheet_0.SheetIndex)
				{
					continue;
				}
				Worksheet worksheet = method_19()[i];
				Cells cells = worksheet.Cells;
				for (int j = 0; j < cells.rowCollection_0.Count; j++)
				{
					Row rowByIndex = cells.rowCollection_0.GetRowByIndex(j);
					for (int k = 0; k < rowByIndex.method_0(); k++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(k);
						if (cellByIndex.IsFormula)
						{
							cellByIndex.InsertColumns(columnIndex, -totalColumns, worksheet_0, bool_0: false);
						}
					}
				}
				if (worksheet.Charts.Count > 0)
				{
					worksheet.Charts.InsertColumns(columnIndex, -totalColumns, worksheet_0, bool_0: false);
				}
			}
		}
		class1133_0.InsertColumns(columnIndex, -totalColumns);
		if (worksheet_0.method_36() != null)
		{
			worksheet_0.Shapes.method_21(columnIndex, -totalColumns, worksheet_0, bool_0: true);
		}
		hyperlinkCollection_0.InsertColumns(columnIndex, -totalColumns);
		foreach (Range item in rangeCollection_0)
		{
			item.InsertColumns(columnIndex, -totalColumns);
		}
		method_19().Names.InsertColumns(worksheet_0.SheetIndex, columnIndex, -totalColumns);
		worksheet_0.Validations.InsertColumns(columnIndex, -totalColumns);
		if (worksheet_0.conditionalFormattingCollection_0 != null)
		{
			worksheet_0.conditionalFormattingCollection_0.InsertColumns(columnIndex, -totalColumns);
		}
		if (worksheet_0.method_13())
		{
			worksheet_0.method_1().InsertColumns(columnIndex, -totalColumns);
		}
		worksheet_0.PageSetup.InsertColumns(columnIndex, -totalColumns);
		if (worksheet_0.method_24() != 0)
		{
			worksheet_0.AutoFilter.InsertColumn(columnIndex, -totalColumns);
		}
		if (worksheet_0.SparklineGroupCollection.Count != 0)
		{
			worksheet_0.SparklineGroupCollection.InsertColumns(this, columnIndex, -totalColumns, bool_0: true);
		}
		if (worksheet_0.ListObjects.Count != 0)
		{
			worksheet_0.ListObjects.InsertColumns(columnIndex, -totalColumns);
		}
	}

	/// <summary>
	///       Check whether the range could be deleted.
	///       </summary>
	/// <param name="startRow">The start row index of the range.</param>
	/// <param name="startColumn">The start column idnex of the range.</param>
	/// <param name="totalRows">The number of the rows in the range.</param>
	/// <param name="totalColumns">The number of the columns in the range.</param>
	/// <returns>
	/// </returns>
	public bool IsDeletingRangeEnabled(int startRow, int startColumn, int totalRows, int totalColumns)
	{
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = startRow;
		cellArea_.EndRow = startRow + totalRows - 1;
		cellArea_.StartColumn = startColumn;
		cellArea_.EndColumn = startColumn + totalColumns - 1;
		if (worksheet_0.ListObjects.Count != 0 && !worksheet_0.ListObjects.method_2(startRow, startColumn, totalRows, totalColumns))
		{
			return false;
		}
		for (int i = 0; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_4 && cellByIndex.IsInArray)
				{
					CellArea arrayRange = cellByIndex.GetArrayRange();
					if (!Class1678.smethod_2(cellArea_, arrayRange))
					{
						return false;
					}
				}
			}
		}
		if (worksheet_0.pivotTableCollection_0 != null)
		{
			for (int k = 0; k < worksheet_0.pivotTableCollection_0.Count; k++)
			{
				PivotTable pivotTable = worksheet_0.pivotTableCollection_0[k];
				CellArea tableRange = pivotTable.TableRange2;
				if (!Class1678.smethod_2(cellArea_, tableRange))
				{
					return false;
				}
			}
		}
		return true;
	}

	/// <summary>
	///       Deletes several rows.
	///       </summary>
	/// <param name="rowIndex">The first row index to be deleted.</param>
	/// <param name="totalRows">Number of rows to be deleted.</param>
	/// <remarks>
	///       If the deleted range contains the top part(not whole) of the table(ListObject),
	///       the ranged could not be deleted and nothing will be done.It works as MS Excel.
	///       </remarks>
	public bool DeleteRows(int rowIndex, int totalRows)
	{
		if (totalRows <= 0)
		{
			return false;
		}
		method_19().Workbook.method_3();
		Class1677.smethod_24(rowIndex);
		if (rowIndex + totalRows > 1048576)
		{
			totalRows = 1048576 - rowIndex;
		}
		rowCollection_0.DeleteRows(rowIndex, totalRows);
		method_19().Names.InsertRows(worksheet_0.SheetIndex, rowIndex, -totalRows);
		if (worksheet_0.method_36() != null)
		{
			worksheet_0.Shapes.method_20(rowIndex, -totalRows, worksheet_0, bool_0: true);
		}
		if (worksheet_0.class1557_0 != null)
		{
			worksheet_0.class1557_0.InsertRows(rowIndex, -totalRows);
		}
		class1133_0.InsertRows(rowIndex, -totalRows);
		foreach (Range item in rangeCollection_0)
		{
			item.InsertRows(rowIndex, -totalRows);
		}
		if (worksheet_0.method_24() != 0)
		{
			worksheet_0.AutoFilter.InsertRow(rowIndex, -totalRows);
		}
		hyperlinkCollection_0.InsertRows(rowIndex, -totalRows);
		worksheet_0.Validations.InsertRows(rowIndex, -totalRows);
		if (worksheet_0.conditionalFormattingCollection_0 != null)
		{
			worksheet_0.ConditionalFormattings.InsertRows(rowIndex, -totalRows);
		}
		if (worksheet_0.method_13())
		{
			worksheet_0.method_1().InsertRows(rowIndex, -totalRows);
		}
		worksheet_0.PageSetup.InsertRows(rowIndex, -totalRows);
		if (worksheet_0.HorizontalPageBreaks.Count != 0)
		{
			worksheet_0.HorizontalPageBreaks.InsertRows(rowIndex, -totalRows);
		}
		if (worksheet_0.ListObjects.Count != 0)
		{
			worksheet_0.ListObjects.InsertRows(rowIndex, -totalRows);
		}
		if (worksheet_0.SparklineGroupCollection.Count != 0)
		{
			worksheet_0.SparklineGroupCollection.InsertRows(this, rowIndex, -totalRows, bool_0: true);
		}
		if (worksheet_0.pivotTableCollection_0 != null && worksheet_0.pivotTableCollection_0.Count != 0)
		{
			worksheet_0.pivotTableCollection_0.InsertRows(rowIndex, -totalRows);
		}
		if (method_19().method_89() != null && method_19().method_89().Count != 0)
		{
			method_19().method_89().InsertRows(rowIndex, -totalRows, worksheet_0);
		}
		return true;
	}

	/// <summary>
	///       Deletes a row.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	public void DeleteRow(int rowIndex)
	{
		Class1677.smethod_24(rowIndex);
		DeleteRows(rowIndex, 1);
	}

	/// <summary>
	///       Deletes multiple rows in the worksheet.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <param name="totalRows">Number of rows to be deleted.</param>
	/// <param name="updateReference">Indicates if update references in other worksheets.</param>
	public void DeleteRows(int rowIndex, int totalRows, bool updateReference)
	{
		DeleteRows(rowIndex, totalRows);
		if (!updateReference)
		{
			return;
		}
		method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
		for (int i = 0; i < method_19().Count; i++)
		{
			if (i == worksheet_0.SheetIndex)
			{
				continue;
			}
			Worksheet worksheet = method_19()[i];
			Cells cells = worksheet.Cells;
			for (int j = 0; j < cells.rowCollection_0.Count; j++)
			{
				Row rowByIndex = cells.rowCollection_0.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						cellByIndex.InsertRows(rowIndex, -totalRows, worksheet_0, bool_0: false);
					}
				}
			}
			if (worksheet.Charts.Count > 0)
			{
				worksheet.Charts.InsertRows(rowIndex, -totalRows, worksheet_0, bool_0: false);
			}
		}
	}

	/// <summary>
	///       Delete all blank columns which do not contain any data.
	///       </summary>
	public void DeleteBlankColumns()
	{
		method_19().Workbook.method_3();
		if (Count == 0)
		{
			rowCollection_0.Clear();
			columnCollection_0.Clear();
		}
		if (columnCollection_0.Count > 0 && short_0 < columnCollection_0.GetColumnByIndex(columnCollection_0.Count - 1).Index)
		{
			int num = columnCollection_0.Count - 1;
			while (num >= 0 && columnCollection_0.GetColumnByIndex(num).Index > short_0)
			{
				columnCollection_0.RemoveAt(num);
				num--;
			}
		}
		for (int num2 = short_0; num2 >= 0; num2--)
		{
			if (IsBlankColumn(num2))
			{
				DeleteColumn(num2);
			}
		}
	}

	public bool IsBlankColumn(int columnIndex)
	{
		method_19().Workbook.method_3();
		Cell cell = null;
		int num = 0;
		while (true)
		{
			if (num < rowCollection_0.Count)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				cell = rowByIndex.GetCellOrNull(columnIndex);
				if (cell != null && !cell.IsBlank)
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	///       Delete all blank rows which do not contain any data.
	///       </summary>
	public void DeleteBlankRows()
	{
		method_19().Workbook.method_3();
		if (Count == 0)
		{
			rowCollection_0.Clear();
			columnCollection_0.Clear();
		}
		int num = -1;
		for (int num2 = rowCollection_0.Count - 1; num2 >= 0; num2--)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(num2);
			if (!rowByIndex.IsBlank)
			{
				if (num == -1)
				{
					num = rowByIndex.int_0;
				}
				else if (num != rowByIndex.int_0)
				{
					if (num - rowByIndex.int_0 > 1)
					{
						DeleteRows(rowByIndex.int_0 + 1, num - rowByIndex.int_0 - 1);
					}
					num = rowByIndex.int_0;
				}
			}
			else if (num == -1)
			{
				num = rowByIndex.int_0 + 1;
			}
		}
		if (num >= 0)
		{
			DeleteRows(0, num);
			return;
		}
		rowCollection_0.Clear();
		columnCollection_0.Clear();
	}

	/// <summary>
	///       Inserts some columns into the worksheet.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="totalColumns">The number of columns.</param>
	public void InsertColumns(int columnIndex, int totalColumns)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_25(columnIndex);
		rowCollection_0.InsertColumns(columnIndex, totalColumns);
		if (columnIndex <= short_0)
		{
			short_0 += (short)totalColumns;
			if (short_0 > 16383)
			{
				short_0 = 16383;
			}
		}
		columnCollection_0.InsertColumns(columnIndex, totalColumns);
		if (worksheet_0.method_36() != null)
		{
			worksheet_0.Shapes.method_21(columnIndex, totalColumns, worksheet_0, bool_0: true);
		}
		worksheet_0.Validations.InsertColumns(columnIndex, totalColumns);
		if (worksheet_0.conditionalFormattingCollection_0 != null)
		{
			worksheet_0.conditionalFormattingCollection_0.InsertColumns(columnIndex, totalColumns);
		}
		hyperlinkCollection_0.InsertColumns(columnIndex, totalColumns);
		class1133_0.InsertColumns(columnIndex, totalColumns);
		method_32(columnIndex, totalColumns);
		foreach (Range item in rangeCollection_0)
		{
			item.InsertColumns(columnIndex, totalColumns);
		}
		method_19().Names.InsertColumns(worksheet_0.SheetIndex, columnIndex, totalColumns);
		if (worksheet_0.class1557_0 != null)
		{
			worksheet_0.class1557_0.InsertColumns(columnIndex, totalColumns);
		}
		if (worksheet_0.method_13())
		{
			worksheet_0.method_1().InsertColumns(columnIndex, totalColumns);
		}
		worksheet_0.PageSetup.InsertColumns(columnIndex, totalColumns);
		if (worksheet_0.method_24() != 0)
		{
			worksheet_0.AutoFilter.InsertColumn(columnIndex, totalColumns);
		}
		if (worksheet_0.SparklineGroupCollection.Count != 0)
		{
			worksheet_0.SparklineGroupCollection.InsertColumns(this, columnIndex, totalColumns, bool_0: true);
		}
		if (worksheet_0.ListObjects.Count != 0)
		{
			worksheet_0.ListObjects.InsertColumns(columnIndex, totalColumns);
		}
	}

	/// <summary>
	///       Inserts some columns into the worksheet.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="totalColumns">The number of columns.</param>
	/// <param name="updateReference">Indicates if references in other worksheets will be updated.</param>
	public void InsertColumns(int columnIndex, int totalColumns, bool updateReference)
	{
		method_19().Workbook.method_3();
		InsertColumns(columnIndex, totalColumns);
		if (!updateReference)
		{
			return;
		}
		method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
		for (int i = 0; i < method_19().Count; i++)
		{
			if (i == worksheet_0.SheetIndex)
			{
				continue;
			}
			Worksheet worksheet = method_19()[i];
			Cells cells = worksheet.Cells;
			for (int j = 0; j < cells.Rows.Count; j++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						if (cellByIndex.method_45())
						{
							cellByIndex.method_72();
						}
						cellByIndex.InsertColumns(columnIndex, totalColumns, worksheet_0, bool_0: false);
					}
				}
			}
			if (worksheet.Charts.Count > 0)
			{
				worksheet.Charts.InsertColumns(columnIndex, totalColumns, worksheet_0, bool_0: false);
			}
		}
	}

	/// <summary>
	///       Inserts a new column into the worksheet.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="updateReference">Indicates if references in other worksheets will be updated.</param>
	public void InsertColumn(int columnIndex, bool updateReference)
	{
		InsertColumns(columnIndex, 1, updateReference);
	}

	/// <summary>
	///       Inserts a new column into the worksheet.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	public void InsertColumn(int columnIndex)
	{
		InsertColumns(columnIndex, 1);
	}

	/// <summary>
	///       Inserts multiple rows into the worksheet.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <param name="totalRows">Number of rows to be inserted.</param>
	/// <param name="updateReference">Indicates if references in other worksheets will be updated.</param>
	public void InsertRows(int rowIndex, int totalRows, bool updateReference)
	{
		InsertRows(rowIndex, totalRows);
		if (!updateReference)
		{
			return;
		}
		method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
		for (int i = 0; i < method_19().Count; i++)
		{
			if (i == worksheet_0.SheetIndex)
			{
				continue;
			}
			Worksheet worksheet = method_19()[i];
			Cells cells = worksheet.Cells;
			for (int j = 0; j < cells.Rows.Count; j++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						if (cellByIndex.method_45())
						{
							cellByIndex.method_72();
						}
						cellByIndex.InsertRows(rowIndex, totalRows, worksheet_0, bool_0: false);
					}
				}
			}
			if (worksheet.Charts.Count != 0)
			{
				worksheet.Charts.InsertRows(rowIndex, totalRows, worksheet_0, bool_0: false);
			}
		}
	}

	/// <summary>
	///       Inserts multiple rows into the worksheet.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <param name="totalRows">Number of rows to be inserted.</param>
	public void InsertRows(int rowIndex, int totalRows)
	{
		method_31(rowIndex, totalRows, null);
	}

	internal void method_31(int int_0, int int_1, Class739 class739_0)
	{
		if (class739_0 == null)
		{
			class739_0 = new Class739();
		}
		method_19().Workbook.method_3();
		Class1677.smethod_24(int_0);
		if (int_0 + int_1 > 1048575)
		{
			int_1 = 1048575 - int_0 + 1;
		}
		if (int_1 == 0)
		{
			return;
		}
		rowCollection_0.InsertRows(int_0, int_1, class739_0);
		method_19().Names.InsertRows(worksheet_0.SheetIndex, int_0, int_1);
		if (worksheet_0.class1557_0 != null)
		{
			worksheet_0.class1557_0.InsertRows(int_0, int_1);
		}
		if (worksheet_0.method_36() != null && worksheet_0.method_36().Count != 0)
		{
			worksheet_0.Shapes.method_20(int_0, int_1, worksheet_0, bool_0: true);
		}
		hyperlinkCollection_0.InsertRows(int_0, int_1);
		class1133_0.InsertRows(int_0, int_1);
		foreach (Range item in rangeCollection_0)
		{
			item.InsertRows(int_0, int_1);
		}
		if (worksheet_0.method_24() != 0)
		{
			worksheet_0.AutoFilter.InsertRow(int_0, int_1);
		}
		worksheet_0.Validations.InsertRows(int_0, int_1);
		worksheet_0.ConditionalFormattings.InsertRows(int_0, int_1);
		if (worksheet_0.method_13())
		{
			worksheet_0.method_1().InsertRows(int_0, int_1);
		}
		worksheet_0.PageSetup.InsertRows(int_0, int_1);
		if (worksheet_0.HorizontalPageBreaks.Count != 0)
		{
			worksheet_0.HorizontalPageBreaks.InsertRows(int_0, int_1);
		}
		if (worksheet_0.ListObjects.Count != 0)
		{
			worksheet_0.ListObjects.InsertRows(int_0, int_1);
		}
		if (worksheet_0.SparklineGroupCollection.Count != 0)
		{
			worksheet_0.SparklineGroupCollection.InsertRows(this, int_0, int_1, bool_0: true);
		}
		if (worksheet_0.pivotTableCollection_0 != null && worksheet_0.pivotTableCollection_0.Count != 0)
		{
			worksheet_0.pivotTableCollection_0.InsertRows(int_0, int_1);
		}
		if (method_19().method_89() != null && method_19().method_89().Count != 0)
		{
			method_19().method_89().InsertRows(int_0, int_1, worksheet_0);
		}
	}

	/// <summary>
	///       Inserts a new row into the worksheet.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	public void InsertRow(int rowIndex)
	{
		InsertRows(rowIndex, 1);
	}

	private void method_32(int int_0, int int_1)
	{
		if (int_0 <= 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < Rows.Count; i++)
		{
			Row rowByIndex = Rows.GetRowByIndex(i);
			Cell cellOrNull = rowByIndex.GetCellOrNull(int_0 - 1);
			if (cellOrNull != null)
			{
				hashtable.Add(cellOrNull.Row, cellOrNull);
			}
		}
		if (hashtable.Count == 0)
		{
			return;
		}
		for (int j = 0; j < int_1; j++)
		{
			foreach (int key in hashtable.Keys)
			{
				Cell cell = (Cell)hashtable[key];
				GetCell(key, int_0 + j, bool_2: false).method_37(cell.method_36());
			}
		}
	}

	private void method_33(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 <= 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		int num = columnCollection_0.method_7(int_0 - 1);
		int num2 = -1;
		if (num != -1)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
			if (columnByIndex.method_10())
			{
				num2 = columnByIndex.method_5();
			}
		}
		for (int i = 0; i < Rows.Count; i++)
		{
			Row rowByIndex = Rows.GetRowByIndex(i);
			if (rowByIndex.int_0 >= int_2)
			{
				if (rowByIndex.int_0 > int_3)
				{
					break;
				}
				Cell cellOrNull = rowByIndex.GetCellOrNull(int_0 - 1);
				if (cellOrNull != null)
				{
					hashtable.Add(cellOrNull.Row, cellOrNull.method_35());
				}
			}
		}
		if (num2 != -1)
		{
			for (int j = int_2; j <= int_3; j++)
			{
				if (hashtable[j] == null)
				{
					hashtable.Add(j, num2);
				}
			}
		}
		else
		{
			for (int k = 0; k < int_1; k++)
			{
				num = columnCollection_0.method_7(int_0 + k);
				if (num == -1)
				{
					continue;
				}
				Column columnByIndex2 = columnCollection_0.GetColumnByIndex(num);
				if (!columnByIndex2.method_10())
				{
					continue;
				}
				for (int l = int_2; l <= int_3; l++)
				{
					if (hashtable[l] == null)
					{
						Row row = Rows.GetRow(l, bool_0: true, bool_1: false);
						if (row != null && !row.method_27())
						{
							hashtable.Add(l, 15);
						}
					}
				}
			}
		}
		if (hashtable.Count == 0)
		{
			return;
		}
		for (int m = 0; m < int_1; m++)
		{
			foreach (int key in hashtable.Keys)
			{
				GetCell(key, int_0 + m, bool_2: false).method_37((int)hashtable[key]);
			}
		}
	}

	private void method_34(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 <= 0)
		{
			return;
		}
		Cell[] array = new Cell[int_3 - int_2 + 1];
		Row row = Rows.GetRow(int_0 - 1, bool_0: true, bool_1: false);
		bool flag = false;
		if (row != null)
		{
			flag = row.method_27();
			for (int i = 0; i < row.method_0(); i++)
			{
				Cell cellByIndex = row.GetCellByIndex(i);
				if (cellByIndex.Column >= int_2 && cellByIndex.Column <= int_3)
				{
					array[cellByIndex.Column - int_2] = cellByIndex;
				}
			}
		}
		for (int j = 0; j < int_1; j++)
		{
			Row row2 = null;
			bool flag2 = false;
			row2 = Rows.GetRow(int_0 + j, bool_0: true, bool_1: false);
			if (row2 != null)
			{
				flag2 = row2.method_27();
			}
			for (int k = 0; k < array.Length; k++)
			{
				int int_4 = int_2 + k;
				Cell cell = array[k];
				Cell cell2 = null;
				if (cell == null)
				{
					if (flag || flag2)
					{
						cell2 = GetCell(int_0 + j, int_4, bool_2: false);
						if (flag)
						{
							cell2.method_37(row.method_10());
						}
						else
						{
							cell2.method_37(15);
						}
					}
				}
				else if (cell.method_36() != -1 && cell.method_36() != 15)
				{
					cell2 = GetCell(int_0 + j, int_4, bool_2: false);
					cell2.method_37(cell.method_36());
				}
				else if (flag || flag2)
				{
					cell2 = GetCell(int_0 + j, int_4, bool_2: false);
					if (flag)
					{
						cell2.method_37(row.method_10());
					}
					else
					{
						cell2.method_37(15);
					}
				}
			}
		}
	}

	public void ClearRange(CellArea range)
	{
		ClearRange(range.StartRow, range.StartColumn, range.EndRow, range.EndColumn);
	}

	/// <summary>
	///       Clears contents and formatting of a range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="endColumn">End column index.</param>
	public void ClearRange(int startRow, int startColumn, int endRow, int endColumn)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		Rows.method_10(startRow, startColumn, endRow, endColumn);
	}

	public void ClearContents(CellArea range)
	{
		ClearContents(range.StartRow, range.StartColumn, range.EndRow, range.EndColumn);
	}

	/// <summary>
	///       Clears contents of a range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="endColumn">End column index.</param>
	public void ClearContents(int startRow, int startColumn, int endRow, int endColumn)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		int arrIndex = -1;
		Rows.method_15(startRow, out arrIndex);
		for (int i = arrIndex; i < Rows.Count; i++)
		{
			Row rowByIndex = Rows.GetRowByIndex(i);
			if (rowByIndex.int_0 > endRow)
			{
				break;
			}
			if (rowByIndex.int_0 < startRow)
			{
				continue;
			}
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.Column >= startColumn && cellByIndex.Column <= endColumn)
				{
					cellByIndex.PutValue(null);
				}
			}
		}
		ListObjectCollection listObjects = worksheet_0.ListObjects;
		if (listObjects.Count != 0)
		{
			for (int k = 0; k < listObjects.Count; k++)
			{
				ListObject listObject = listObjects[k];
				if (listObject.StartRow >= startRow && listObject.EndRow <= endRow && listObject.StartColumn >= startColumn && listObject.EndColumn <= endColumn)
				{
					listObjects.RemoveAt(k--);
				}
			}
		}
		if (worksheet_0.Hyperlinks == null)
		{
			return;
		}
		for (int l = 0; l < worksheet_0.Hyperlinks.Count; l++)
		{
			Hyperlink hyperlink = worksheet_0.Hyperlinks[l];
			if (hyperlink.Area.StartRow >= startRow && hyperlink.Area.StartColumn >= startColumn && hyperlink.Area.EndRow <= endRow && hyperlink.Area.EndColumn <= endColumn)
			{
				worksheet_0.Hyperlinks.method_2(l--);
			}
		}
	}

	public void ClearFormats(CellArea range)
	{
		ClearFormats(range.StartRow, range.StartColumn, range.EndRow, range.EndColumn);
	}

	/// <summary>
	///       Clears formatting of a range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="endColumn">End column index.</param>
	public void ClearFormats(int startRow, int startColumn, int endRow, int endColumn)
	{
		method_19().Workbook.method_3();
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		int i = rowCollection_0.method_14(startRow, endRow);
		if (i == -1)
		{
			return;
		}
		rowCollection_0.method_7();
		for (; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			if (rowByIndex.int_0 > endRow)
			{
				break;
			}
			for (int j = startColumn; j <= endColumn; j++)
			{
				Cell cellOrNull = rowByIndex.GetCellOrNull(j);
				if (cellOrNull != null)
				{
					cellOrNull.method_37(15);
					continue;
				}
				if (rowByIndex.method_27())
				{
					rowByIndex.GetCell(j).method_37(15);
					continue;
				}
				int num = columnCollection_0.method_7(j);
				if (num != -1)
				{
					Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
					if (columnByIndex.method_5() != 15 && columnByIndex.method_5() != -1)
					{
						rowByIndex.GetCell(j).method_37(15);
					}
				}
			}
		}
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, int firstRow, int firstColumn)
	{
		return ImportDataView(dataView, firstRow, firstColumn, 65535, 255);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataView(dataView, firstRow, firstColumn, 1048575, 255, insertRows);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		return ImportDataView(dataView, firstRow, firstColumn, totalRows, totalColumns, insertRows: true);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, int firstRow, int firstColumn, int totalRows, int totalColumns, bool insertRows)
	{
		return ImportDataView(dataView, isFieldNameShown: false, firstRow, firstColumn, totalRows, totalColumns, insertRows);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data view will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, bool isFieldNameShown, int firstRow, int firstColumn, int totalRows, int totalColumns, bool insertRows)
	{
		return ImportDataView(dataView, isFieldNameShown, firstRow, firstColumn, totalRows, totalColumns, insertRows, null);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data view will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="rowNumber">Number of rows to be imported.</param>
	/// <param name="columnNumber">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="numberFormatString">Number format string for cells.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, bool isFieldNameShown, int firstRow, int firstColumn, int rowNumber, int columnNumber, bool insertRows, string numberFormatString)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(firstRow, firstColumn);
		if (dataView.Table.Columns.Count != 0 && columnNumber != 0)
		{
			if (dataView.Count < rowNumber)
			{
				rowNumber = dataView.Count;
			}
			if (isFieldNameShown)
			{
				rowNumber++;
			}
			if (dataView.Table.Columns.Count < columnNumber)
			{
				columnNumber = dataView.Table.Columns.Count;
			}
			if (firstRow + rowNumber > 1048575)
			{
				rowNumber = 1048575 - firstRow + 1;
			}
			if (firstColumn + columnNumber > 16383)
			{
				columnNumber = 16383 - firstColumn + 1;
			}
			if (insertRows && firstRow < 1048575)
			{
				InsertRows(firstRow + 1, rowNumber);
				Row row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
				int int_ = firstRow + rowNumber;
				if (row != null)
				{
					for (int i = 0; i < row.method_0(); i++)
					{
						Cell cellByIndex = row.GetCellByIndex(i);
						GetCell(int_, cellByIndex.Column, bool_2: false).PutValue(cellByIndex.Value);
					}
				}
			}
			if (isFieldNameShown)
			{
				method_14(dataView.Table, firstRow, firstColumn, columnNumber);
				firstRow++;
				rowNumber--;
			}
			for (int j = 0; j < rowNumber; j++)
			{
				DataRowView dataRowView = dataView[j];
				for (int k = 0; k < columnNumber; k++)
				{
					Cell cell = GetCell(firstRow + j, firstColumn + k, bool_2: false);
					cell.PutValue(dataRowView[k]);
					if (numberFormatString != null && numberFormatString != "")
					{
						Style style = cell.method_28();
						style.Custom = numberFormatString;
						cell.method_30(style);
					}
				}
			}
			if (isFieldNameShown)
			{
				rowNumber++;
			}
			return rowNumber;
		}
		return 0;
	}

	/// <summary>
	///       Imports a <see cref="T:System.Data.DataView" /> into a worksheet.
	///       </summary>
	/// <param name="dataView">The <see cref="T:System.Data.DataView" /> object to be imported.</param>
	/// <param name="isFieldNameShown">
	///       Indicates whether the field name of the data view will be imported to the first row.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataView(DataView dataView, bool isFieldNameShown, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataView(dataView, isFieldNameShown, firstRow, firstColumn, dataView.Count, dataView.Table.Columns.Count, insertRows);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Web.UI.WebControls.DataGrid" /> into a worksheet. This method doesn't try to convert text into numeric values.
	///       </summary>
	/// <param name="dataGrid">The <see cref="T:System.Web.UI.WebControls.DataGrid" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataGridAsString(DataGrid dataGrid, int firstRow, int firstColumn, bool insertRows)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(firstRow, firstColumn);
		int num = dataGrid.Items.Count;
		if (firstRow + num > 1048576)
		{
			num = 1048575 - firstRow + 1;
		}
		if (insertRows)
		{
			InsertRows(firstRow + 1, num);
			Row row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
			if (row != null)
			{
				for (int i = 0; i < row.method_0(); i++)
				{
					Cell cellByIndex = row.GetCellByIndex(i);
					int int_ = cellByIndex.Row + num;
					GetCell(int_, cellByIndex.Column, bool_2: false).PutValue(cellByIndex.Value);
				}
			}
		}
		for (int j = 0; j < num; j++)
		{
			DataGridItem dataGridItem = dataGrid.Items[j];
			for (int k = 0; k < dataGridItem.Cells.Count; k++)
			{
				string text = dataGridItem.Cells[k].Text;
				switch (text)
				{
				case "&nbsp;":
					GetCell(firstRow + j, firstColumn + k, bool_2: false).PutValue(null);
					break;
				default:
					GetCell(firstRow + j, firstColumn + k, bool_2: false).PutValue(text);
					break;
				case null:
				case "":
					break;
				}
			}
		}
		return num;
	}

	/// <summary>
	///       Imports a grid view to this cells.
	///       </summary>
	/// <param name="gridView">The grid view object.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="convertStringToNumber">Indicates whether convert string value to number.</param>
	/// <param name="convertStyle">Indicates whether apply the style of the grid view to cells.</param>
	/// <returns>The row number.</returns>
	public int ImportGridView(GridView gridView, int firstRow, int firstColumn, bool insertRows, bool convertStringToNumber, bool convertStyle)
	{
		method_19().Workbook.method_3();
		if (gridView.Rows.Count == 0)
		{
			return 0;
		}
		int count = gridView.Rows.Count;
		if (insertRows)
		{
			InsertRows(firstRow, count);
		}
		int num = firstRow;
		int num2 = firstColumn;
		Style style_ = null;
		int int_ = method_19().method_75();
		if (convertStyle)
		{
			style_ = Class1676.smethod_0(this, gridView, int_);
		}
		Class1676.smethod_1(0.0, gridView.Height, int_);
		Class1676.smethod_1(0.0, gridView.Width, int_);
		int num3 = 0;
		while (num3 < count)
		{
			GridViewRow gridViewRow = gridView.Rows[num3];
			TableCellCollection cells = gridViewRow.Cells;
			num2 = firstColumn;
			if (!gridViewRow.Visible)
			{
				Rows.GetRow(num, bool_0: false, bool_1: true).IsHidden = true;
			}
			int num4 = 0;
			while (num4 < cells.Count)
			{
				TableCell tableCell = cells[num4];
				for (int i = 0; i < method_18().Count; i++)
				{
					CellArea cellArea = method_18()[i];
					if (cellArea.StartRow <= num && cellArea.EndRow >= num && cellArea.StartColumn <= num2 && cellArea.EndColumn >= num2)
					{
						num2 = cellArea.EndColumn + 1;
						break;
					}
				}
				Cell cell = GetCell(num, num2, bool_2: false);
				cell.PutValue(cells[num4].Text, convertStringToNumber);
				cell.method_30(style_);
				if (tableCell.ColumnSpan > 1)
				{
					Merge(num, num2, tableCell.RowSpan, tableCell.ColumnSpan);
					num2 += tableCell.ColumnSpan - 1;
				}
				else if (tableCell.RowSpan > 1)
				{
					Merge(num, num2, tableCell.RowSpan, tableCell.ColumnSpan);
				}
				num4++;
				num2++;
			}
			num3++;
			num++;
		}
		return count;
	}

	/// <summary>
	///       Imports a <see cref="T:System.Web.UI.WebControls.DataGrid" /> into a worksheet.
	///       </summary>
	/// <param name="dataGrid">The <see cref="T:System.Web.UI.WebControls.DataGrid" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataGrid(DataGrid dataGrid, int firstRow, int firstColumn, bool insertRows)
	{
		return ImportDataGrid(dataGrid, firstRow, firstColumn, dataGrid.Items.Count, dataGrid.Columns.Count, insertRows);
	}

	private void method_35(string string_0, Cell cell_0)
	{
		try
		{
			DateTime dateTime = DateTime.Parse(string_0);
			cell_0.PutValue(dateTime);
		}
		catch
		{
			cell_0.PutValue(string_0);
		}
	}

	/// <summary>
	///       Imports a <see cref="T:System.Web.UI.WebControls.DataGrid" /> into a worksheet.
	///       </summary>
	/// <param name="dataGrid">The <see cref="T:System.Web.UI.WebControls.DataGrid" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataGrid(DataGrid dataGrid, int firstRow, int firstColumn, int totalRows, int totalColumns, bool insertRows)
	{
		return ImportDataGrid(dataGrid, firstRow, firstColumn, totalRows, totalColumns, insertRows, importStyle: false);
	}

	/// <summary>
	///       Imports a <see cref="T:System.Web.UI.WebControls.DataGrid" /> into a worksheet.
	///       </summary>
	/// <param name="dataGrid">The <see cref="T:System.Web.UI.WebControls.DataGrid" /> object to be imported.</param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="totalRows">Number of rows to be imported.</param>
	/// <param name="totalColumns">Number of columns to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="importStyle">Indicates whether importing the cell style.</param>
	/// <returns>Total number of rows imported</returns>
	public int ImportDataGrid(DataGrid dataGrid, int firstRow, int firstColumn, int totalRows, int totalColumns, bool insertRows, bool importStyle)
	{
		method_19().Workbook.method_3();
		Class1677.CheckCell(firstRow, firstColumn);
		if (firstRow + totalRows > 1048576)
		{
			totalRows = 1048575 - firstRow + 1;
		}
		if (firstColumn + totalColumns > 16384)
		{
			totalColumns = (ushort)(16383 - firstColumn + 1);
		}
		if (dataGrid.Items.Count < totalRows)
		{
			totalRows = dataGrid.Items.Count;
		}
		if (insertRows)
		{
			InsertRows(firstRow + 1, totalRows);
			Row row = Rows.GetRow(firstRow, bool_0: true, bool_1: false);
			if (row != null)
			{
				for (int i = 0; i < row.method_0(); i++)
				{
					Cell cellByIndex = row.GetCellByIndex(i);
					int int_ = cellByIndex.Row + totalRows;
					GetCell(int_, cellByIndex.Column, bool_2: false).PutValue(cellByIndex.Value);
				}
			}
		}
		for (int j = 0; j < totalRows; j++)
		{
			DataGridItem dataGridItem = dataGrid.Items[j];
			Cell cell = null;
			for (int k = 0; k < dataGridItem.Cells.Count; k++)
			{
				TableCell tableCell = dataGridItem.Cells[k];
				string text = tableCell.Text;
				Style style_ = method_36(tableCell);
				if (text == null || text == "")
				{
					continue;
				}
				cell = GetCell(firstRow + j, firstColumn + k, bool_2: false);
				if (text == "&nbsp;")
				{
					cell.PutValue(null);
					cell.method_30(style_);
					continue;
				}
				cell.method_30(style_);
				if (Class1677.smethod_19(text))
				{
					try
					{
						double doubleValue = double.Parse(text);
						cell.PutValue(doubleValue);
					}
					catch
					{
						cell.PutValue(text);
					}
				}
				else if (text[0] >= '0' && text[0] <= '9')
				{
					method_35(text, cell);
				}
				else if (text.Length > 3)
				{
					string key;
					if ((key = text.Substring(0, 3).ToUpper()) != null)
					{
						if (Class1742.dictionary_104 == null)
						{
							Class1742.dictionary_104 = new Dictionary<string, int>(12)
							{
								{ "JAN", 0 },
								{ "FEB", 1 },
								{ "MAR", 2 },
								{ "APR", 3 },
								{ "MAY", 4 },
								{ "JUN", 5 },
								{ "JUL", 6 },
								{ "AUG", 7 },
								{ "SEP", 8 },
								{ "OCT", 9 },
								{ "NOV", 10 },
								{ "DEC", 11 }
							};
						}
						if (Class1742.dictionary_104.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
							case 11:
								method_35(text, cell);
								continue;
							}
						}
					}
					cell.PutValue(text);
				}
				else
				{
					cell.PutValue(text);
				}
			}
		}
		return totalRows;
	}

	private Style method_36(TableCell tableCell_0)
	{
		Style style = new Style(method_19());
		style.Font.method_13(tableCell_0.Font.Name);
		style.Font.IsBold = tableCell_0.Font.Bold;
		style.Font.IsItalic = tableCell_0.Font.Italic;
		style.Font.IsStrikeout = tableCell_0.Font.Strikeout;
		if (tableCell_0.Font.Underline)
		{
			style.Font.Underline = FontUnderlineType.Single;
		}
		if (!tableCell_0.Font.Size.Unit.IsEmpty)
		{
			style.Font.DoubleSize = method_37(tableCell_0.Font.Size.Unit, 10.0);
		}
		style.Font.Color = tableCell_0.ForeColor;
		if (!tableCell_0.BackColor.IsEmpty)
		{
			style.Pattern = BackgroundType.Solid;
			style.ForegroundColor = tableCell_0.BackColor;
		}
		switch (tableCell_0.BorderStyle)
		{
		case BorderStyle.Dotted:
			style.Borders.method_6(CellBorderType.Dotted, tableCell_0.BorderColor);
			break;
		case BorderStyle.Dashed:
			style.Borders.method_6(CellBorderType.Dashed, tableCell_0.BorderColor);
			break;
		case BorderStyle.Solid:
		{
			double num = method_37(tableCell_0.BorderWidth, 1.0);
			CellBorderType cellBorderType_ = CellBorderType.Thin;
			if (num < 0.5)
			{
				cellBorderType_ = CellBorderType.Hair;
			}
			else if (num > 2.0)
			{
				cellBorderType_ = CellBorderType.Thick;
			}
			style.Borders.method_6(cellBorderType_, tableCell_0.BorderColor);
			break;
		}
		case BorderStyle.Double:
			style.Borders.method_6(CellBorderType.Double, tableCell_0.BorderColor);
			break;
		}
		switch (tableCell_0.HorizontalAlign)
		{
		case HorizontalAlign.Left:
			style.HorizontalAlignment = TextAlignmentType.Left;
			break;
		case HorizontalAlign.Center:
			style.HorizontalAlignment = TextAlignmentType.Center;
			break;
		case HorizontalAlign.Right:
			style.HorizontalAlignment = TextAlignmentType.Right;
			break;
		case HorizontalAlign.Justify:
			style.HorizontalAlignment = TextAlignmentType.Justify;
			break;
		}
		switch (tableCell_0.VerticalAlign)
		{
		case VerticalAlign.Top:
			style.VerticalAlignment = TextAlignmentType.Top;
			break;
		case VerticalAlign.Middle:
			style.VerticalAlignment = TextAlignmentType.Center;
			break;
		case VerticalAlign.Bottom:
			style.VerticalAlignment = TextAlignmentType.Bottom;
			break;
		}
		if (tableCell_0.Wrap)
		{
			style.IsTextWrapped = tableCell_0.Wrap;
		}
		return style;
	}

	private double method_37(Unit unit_0, double double_1)
	{
		switch (unit_0.Type)
		{
		case UnitType.Pixel:
			return unit_0.Value * 72.0 / (double)method_19().method_75();
		case UnitType.Point:
			return unit_0.Value;
		case UnitType.Inch:
			return unit_0.Value * 72.0;
		case UnitType.Mm:
			return unit_0.Value * 72.0 / 25.4;
		case UnitType.Cm:
			return unit_0.Value * 72.0 / 2.54;
		case UnitType.Pica:
		case UnitType.Percentage:
			return unit_0.Value * 12.0;
		default:
			return double_1;
		}
	}

	/// <summary>
	///       Finds the cell with the input string.
	///       </summary>
	/// <param name="formula">The formula to search for.</param>
	/// <param name="previousCell">Previous cell with the same formula. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>This method is supported in Standard and above versions of Aspose.Cells.</remarks>
	public Cell FindFormula(string formula, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.IsFormula && cellByIndex.Formula == formula)
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with formla which contains the input string.
	///       </summary>
	/// <param name="formula">The formula to search for.</param>
	/// <param name="previousCell">Previous cell with the same formula. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>This method is supported in Standard and above versions of Aspose.Cells.</remarks>
	public Cell FindFormulaContains(string formula, Cell previousCell)
	{
		formula = formula.ToUpper();
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.IsFormula)
				{
					string formula2 = cellByIndex.Formula;
					if (formula2 != null && formula2.ToUpper().IndexOf(formula) != -1)
					{
						return cellByIndex;
					}
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cell FindString(string inputString, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		bool flag = inputString.IndexOfAny(new char[2] { '?', '*' }) != -1;
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() != Enum199.const_6)
				{
					continue;
				}
				string stringValue = cellByIndex.StringValue;
				if (flag)
				{
					if (Class1679.smethod_4(inputString, stringValue, bool_0: false) == 0)
					{
						return cellByIndex;
					}
				}
				else if (cellByIndex.StringValue == inputString)
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input string in the specified area.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="area">Searched area.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cell FindString(string inputString, Cell previousCell, CellArea area)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		int num = arrRowIndex;
		while (true)
		{
			if (num < rowCollection_0.Count)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				if (rowByIndex.int_0 > area.EndRow)
				{
					break;
				}
				if (rowByIndex.int_0 >= area.StartRow)
				{
					for (int i = ((num == arrRowIndex) ? (arrColumnIndex + 1) : 0); i < rowByIndex.method_0(); i++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(i);
						if (cellByIndex.Column >= area.StartColumn && cellByIndex.Column <= area.EndColumn && cellByIndex.method_20() == Enum199.const_6 && cellByIndex.StringValue == inputString)
						{
							return cellByIndex;
						}
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input string in the specified area.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="area">Searched area.</param>
	/// <param name="upDown">Search order. True: Up. False: Down.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[Browsable(false)]
	public Cell FindString(string inputString, Cell previousCell, CellArea area, bool upDown)
	{
		if (!upDown)
		{
			return FindString(inputString, previousCell, area);
		}
		if (previousCell == null)
		{
			int num = rowCollection_0.Count - 1;
			while (num >= 0)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				if (rowByIndex.int_0 >= area.StartRow)
				{
					if (rowByIndex.int_0 <= area.EndRow)
					{
						int num2 = rowByIndex.method_0() - 1;
						while (num2 >= 0)
						{
							Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
							if (cellByIndex.Column < area.StartColumn || cellByIndex.Column > area.EndColumn || cellByIndex.method_20() != Enum199.const_6 || !(cellByIndex.StringValue == inputString))
							{
								num2--;
								continue;
							}
							return cellByIndex;
						}
					}
					num--;
					continue;
				}
				return null;
			}
		}
		else
		{
			int arrRowIndex = 0;
			int arrColumnIndex = -1;
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
			int num3 = arrRowIndex;
			while (num3 >= 0)
			{
				Row rowByIndex2 = rowCollection_0.GetRowByIndex(num3);
				if (rowByIndex2.int_0 >= area.StartRow)
				{
					if (rowByIndex2.int_0 <= area.EndRow)
					{
						int num4 = ((num3 == arrRowIndex) ? (arrColumnIndex - 1) : (rowByIndex2.method_0() - 1));
						while (num4 >= 0)
						{
							Cell cellByIndex2 = rowByIndex2.GetCellByIndex(num4);
							if (cellByIndex2.Column < area.StartColumn || cellByIndex2.Column > area.EndColumn || cellByIndex2.method_20() != Enum199.const_6 || !(cellByIndex2.StringValue == inputString))
							{
								num4--;
								continue;
							}
							return cellByIndex2;
						}
					}
					num3--;
					continue;
				}
				return null;
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="upDown">Search order. True: Up. False: Down.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	public Cell FindString(string inputString, Cell previousCell, bool upDown)
	{
		if (!upDown)
		{
			return FindString(inputString, previousCell);
		}
		if (previousCell == null)
		{
			for (int num = rowCollection_0.Count - 1; num >= 0; num--)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				int num2 = rowByIndex.method_0() - 1;
				while (num2 >= 0)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
					if (cellByIndex.method_20() != Enum199.const_6 || !(cellByIndex.StringValue == inputString))
					{
						num2--;
						continue;
					}
					return cellByIndex;
				}
			}
		}
		else
		{
			int arrRowIndex = 0;
			int arrColumnIndex = -1;
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
			for (int num3 = arrRowIndex; num3 >= 0; num3--)
			{
				Row rowByIndex2 = rowCollection_0.GetRowByIndex(num3);
				int num4 = ((num3 == arrRowIndex) ? (arrColumnIndex - 1) : (rowByIndex2.method_0() - 1));
				while (num4 >= 0)
				{
					Cell cellByIndex2 = rowByIndex2.GetCellByIndex(num4);
					if (cellByIndex2.method_20() != Enum199.const_6 || !(cellByIndex2.StringValue == inputString))
					{
						num4--;
						continue;
					}
					return cellByIndex2;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="findOptions">Sets the find options.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Browsable(false)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cell FindString(string inputString, Cell previousCell, FindOptions findOptions)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (!findOptions.CaseSensitive)
		{
			inputString = inputString.ToUpper();
		}
		bool flag = inputString.IndexOfAny(new char[2] { '?', '*' }) != -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() != Enum199.const_6)
				{
					continue;
				}
				if (flag)
				{
					if (Class1679.smethod_4(inputString, cellByIndex.StringValue, !findOptions.CaseSensitive) == 0)
					{
						return cellByIndex;
					}
				}
				else if (findOptions.CaseSensitive)
				{
					if (cellByIndex.StringValue == inputString)
					{
						return cellByIndex;
					}
				}
				else if (cellByIndex.StringValue.ToUpper() == inputString)
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell starting with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	public Cell FindStringStartsWith(string inputString, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.StringValue.StartsWith(inputString))
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell ending with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Cell FindStringEndsWith(string inputString, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.StringValue.EndsWith(inputString))
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell containing with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	public Cell FindStringContains(string inputString, Cell previousCell)
	{
		return FindStringContains(inputString, previousCell, isCaseSensitive: false);
	}

	/// <summary>
	///       Finds the cell containing with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="isCaseSensitive">Indicates if the searched string is case sensitive.</param>
	/// <param name="area">Searched area.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Cell FindStringContains(string inputString, Cell previousCell, bool isCaseSensitive, CellArea area)
	{
		if (!isCaseSensitive)
		{
			inputString = inputString.ToUpper();
		}
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		int num = arrRowIndex;
		while (true)
		{
			if (num < rowCollection_0.Count)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				if (rowByIndex.int_0 > area.EndRow)
				{
					break;
				}
				if (rowByIndex.int_0 >= area.StartRow)
				{
					for (int i = ((num == arrRowIndex) ? (arrColumnIndex + 1) : 0); i < rowByIndex.method_0(); i++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(i);
						if (cellByIndex.Column < area.StartColumn || cellByIndex.Column > area.EndColumn)
						{
							continue;
						}
						if (isCaseSensitive)
						{
							if (cellByIndex.StringValue.IndexOf(inputString) != -1)
							{
								return cellByIndex;
							}
						}
						else if (cellByIndex.StringValue.ToUpper().IndexOf(inputString) != -1)
						{
							return cellByIndex;
						}
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return null;
	}

	/// <summary>
	///       Finds the cell containing with the input string.
	///       </summary>
	/// <param name="inputString">The string to search for.</param>
	/// <param name="previousCell">Previous cell with the same string. This parameter can be set to null if seaching from the start.</param>
	/// <param name="isCaseSensitive">Indicates if the searched string is case sensitive.</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Cell FindStringContains(string inputString, Cell previousCell, bool isCaseSensitive)
	{
		if (!isCaseSensitive)
		{
			inputString = inputString.ToUpper();
		}
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (isCaseSensitive)
				{
					if (cellByIndex.StringValue.IndexOf(inputString) != -1)
					{
						return cellByIndex;
					}
				}
				else if (cellByIndex.StringValue.ToUpper().IndexOf(inputString) != -1)
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input integer.
	///       </summary>
	/// <param name="inputNumber">The integer to search for.</param>
	/// <param name="previousCell">Previous cell with the same integer. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	public Cell FindNumber(int inputNumber, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_3)
				{
					if (Math.Abs(cellByIndex.DoubleValue - (double)inputNumber) <= double.Epsilon)
					{
						return cellByIndex;
					}
				}
				else if (cellByIndex.method_20() == Enum199.const_2 && !((double)Math.Abs(cellByIndex.IntValue - inputNumber) > double.Epsilon))
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell with the input double.
	///       </summary>
	/// <param name="inputNumber">The double to search for.</param>
	/// <param name="previousCell">Previous cell with the same double. This parameter can be set to null if seaching from the start.</param>
	/// <returns>Cell object.</returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Cells.Find(object,Cell,FindOptions) method instead.")]
	[Browsable(false)]
	public Cell FindNumber(double inputNumber, Cell previousCell)
	{
		int arrRowIndex = 0;
		int arrColumnIndex = -1;
		if (previousCell != null)
		{
			rowCollection_0.method_13(previousCell.Row, previousCell.Column, out arrRowIndex, out arrColumnIndex);
		}
		for (int i = arrRowIndex; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			for (int j = ((i == arrRowIndex) ? (arrColumnIndex + 1) : 0); j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_3)
				{
					if (Math.Abs(cellByIndex.DoubleValue - inputNumber) <= double.Epsilon)
					{
						return cellByIndex;
					}
				}
				else if (cellByIndex.method_20() == Enum199.const_2 && !(Math.Abs((double)cellByIndex.IntValue - inputNumber) > double.Epsilon))
				{
					return cellByIndex;
				}
			}
		}
		return null;
	}

	/// <summary>
	///       Finds the cell containing with the input object.
	///       </summary>
	/// <param name="what">The object to search for.
	///       The type should be int,double,DateTime,string,bool.
	///       </param>
	/// <param name="previousCell">Previous cell with the same object. 
	///       This parameter can be set to null if seaching from the start.</param>
	/// <param name="findOptions">Find options</param>
	/// <returns>Cell object.</returns>
	/// <remarks>Returns null(Nothing) if no cell is found.</remarks>
	public Cell Find(object what, Cell previousCell, FindOptions findOptions)
	{
		try
		{
			Class1338 @class = new Class1338(this, findOptions);
			return @class.Find(what, previousCell);
		}
		catch
		{
			throw new CellsException(ExceptionType.InvalidOperator, "Fails to find the next cell.");
		}
	}

	/// <summary>
	///       Gets the last cell in this row.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <returns>Cell object.</returns>
	public Cell EndCellInRow(int rowIndex)
	{
		Class1677.smethod_24(rowIndex);
		Row row = rowCollection_0.GetRow(rowIndex, bool_0: true, bool_1: false);
		if (row == null)
		{
			return null;
		}
		int num = row.method_0() - 1;
		Cell cellByIndex;
		while (true)
		{
			if (num >= 0)
			{
				cellByIndex = row.GetCellByIndex(num);
				if (cellByIndex.method_20() != Enum199.const_7)
				{
					break;
				}
				num--;
				continue;
			}
			return null;
		}
		return cellByIndex;
	}

	/// <summary>
	///       Gets the last cell in this column.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <returns>Cell object.</returns>
	public Cell EndCellInColumn(short columnIndex)
	{
		int num = rowCollection_0.Count - 1;
		Cell cellOrNull;
		while (true)
		{
			if (num >= 0)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				cellOrNull = rowByIndex.GetCellOrNull(columnIndex);
				if (cellOrNull != null && cellOrNull.method_20() != Enum199.const_7)
				{
					break;
				}
				num--;
				continue;
			}
			return null;
		}
		return cellOrNull;
	}

	/// <summary>
	///       Gets the last cell with maximum column index in this range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endColumn">End column index.</param>
	/// <returns>Cell object.</returns>
	public Cell EndCellInColumn(int startRow, int endRow, short startColumn, short endColumn)
	{
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		Cell cell = null;
		int num = rowCollection_0.Count - 1;
		while (true)
		{
			if (num >= 0)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				if (rowByIndex.int_0 <= endRow)
				{
					if (rowByIndex.int_0 < startRow)
					{
						break;
					}
					int num2 = rowByIndex.method_0() - 1;
					while (num2 >= 0)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
						if (cellByIndex.Column < startColumn || cellByIndex.Column > endColumn || cellByIndex.method_20() == Enum199.const_7)
						{
							num2--;
							continue;
						}
						if (cellByIndex.Column != endColumn)
						{
							if (cell == null)
							{
								cell = cellByIndex;
							}
							else if (cell.Column < cellByIndex.Column)
							{
								cell = cellByIndex;
							}
							break;
						}
						return cellByIndex;
					}
				}
				num--;
				continue;
			}
			return cell;
		}
		return null;
	}

	/// <summary>
	///       Gets the last cell with maximum row index in this range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endColumn">End column index.</param>
	/// <returns>Cell object.</returns>
	public Cell EndCellInRow(int startRow, int endRow, int startColumn, int endColumn)
	{
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		int num = rowCollection_0.Count - 1;
		while (true)
		{
			if (num >= 0)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(num);
				if (rowByIndex.int_0 <= endRow)
				{
					if (rowByIndex.int_0 < startRow)
					{
						break;
					}
					int num2 = rowByIndex.method_0() - 1;
					while (num2 >= 0)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(num2);
						if (cellByIndex.Column < startColumn || cellByIndex.Column > endColumn || cellByIndex.method_20() == Enum199.const_7)
						{
							num2--;
							continue;
						}
						return cellByIndex;
					}
				}
				num--;
				continue;
			}
			return null;
		}
		return null;
	}

	/// <summary>
	///       Moves the range to dest postion.
	///       </summary>
	/// <param name="sourceArea">The range which should be moved.</param>
	/// <param name="destRow">The dest row.</param>
	/// <param name="destColumn">The dest column.</param>
	public void MoveRange(CellArea sourceArea, int destRow, int destColumn)
	{
		method_19().Workbook.method_3();
		Range range = new Range(sourceArea.StartRow, sourceArea.StartColumn, sourceArea.EndRow - sourceArea.StartRow + 1, sourceArea.EndColumn - sourceArea.StartColumn + 1, this);
		range.MoveTo(destRow, destColumn);
	}

	/// <summary>
	///       Inserts a range of cells and shift cells according to the shift option.
	///       </summary>
	/// <param name="area">Shift area.</param>
	/// <param name="shiftNumber">Number of rows or columns to be inserted.</param>
	/// <param name="shiftType">Shift cells option.</param>
	/// <param name="updateReference">Indicates if update references in other worksheets.</param>
	public void InsertRange(CellArea area, int shiftNumber, ShiftType shiftType, bool updateReference)
	{
		method_19().Workbook.method_3();
		InsertRange(area, shiftNumber, shiftType);
		if (!updateReference)
		{
			return;
		}
		method_19().method_32().method_8(method_19().method_36(), worksheet_0.SheetIndex);
		for (int i = 0; i < method_19().Count; i++)
		{
			if (i == worksheet_0.SheetIndex)
			{
				continue;
			}
			Cells cells = method_19()[i].Cells;
			for (int j = 0; j < cells.rowCollection_0.Count; j++)
			{
				Row rowByIndex = cells.rowCollection_0.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						byte[] array = cellByIndex.method_41();
						Class1674.smethod_19(area, shiftNumber, shiftType, worksheet_0, bool_0: false, array, -1, -1, cellByIndex.Row, cellByIndex.Column, cellByIndex.Row, cellByIndex.Column);
						cellByIndex.method_17().string_0 = null;
					}
				}
			}
		}
	}

	/// <summary>
	///       Inserts a range of cells and shift cells according to the shift option.
	///       </summary>
	/// <param name="area">Shift area.</param>
	/// <param name="shiftType">Shift cells option.</param>
	public void InsertRange(CellArea area, ShiftType shiftType)
	{
		method_19().Workbook.method_3();
		if (shiftType == ShiftType.Right)
		{
			InsertRange(area, area.EndColumn - area.StartColumn + 1, shiftType);
		}
		else
		{
			InsertRange(area, area.EndRow - area.StartRow + 1, shiftType);
		}
	}

	/// <summary>
	///       Inserts a range of cells and shift cells according to the shift option.
	///       </summary>
	/// <param name="area">Shift area.</param>
	/// <param name="shiftNumber">Number of rows or columns to be inserted.</param>
	/// <param name="shiftType">Shift cells option.</param>
	public void InsertRange(CellArea area, int shiftNumber, ShiftType shiftType)
	{
		method_19().Workbook.method_3();
		if (shiftType == ShiftType.Left || shiftType == ShiftType.Up || shiftType == ShiftType.None)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid shift option.");
		}
		rowCollection_0.InsertRange(area, shiftNumber, shiftType, worksheet_0, bool_0: true);
		method_38(area, shiftNumber, shiftType);
	}

	private void method_38(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			method_34(cellArea_0.StartRow, int_0, cellArea_0.StartColumn, cellArea_0.EndColumn);
			class1133_0.method_7(cellArea_0, int_0);
			break;
		case ShiftType.Left:
			class1133_0.method_4(cellArea_0, int_0);
			break;
		case ShiftType.Right:
			method_33(cellArea_0.StartColumn, int_0, cellArea_0.StartRow, cellArea_0.EndRow);
			class1133_0.method_6(cellArea_0, int_0);
			break;
		case ShiftType.Up:
			class1133_0.method_5(cellArea_0, int_0);
			break;
		}
		if (worksheet_0.method_36() != null)
		{
			worksheet_0.Shapes.InsertRange(cellArea_0, int_0, shiftType_0, worksheet_0, bool_0: true);
		}
		if (worksheet_0.conditionalFormattingCollection_0 != null)
		{
			worksheet_0.ConditionalFormattings.method_3(cellArea_0, int_0, shiftType_0, worksheet_0, bool_0: true);
		}
		worksheet_0.Validations.method_4(cellArea_0, int_0, shiftType_0, worksheet_0, bool_0: true);
		method_19().Names.method_15(worksheet_0, cellArea_0, int_0, shiftType_0);
		hyperlinkCollection_0.method_3(cellArea_0, int_0, shiftType_0);
		worksheet_0.ListObjects.InsertRange(cellArea_0, int_0, shiftType_0);
		worksheet_0.PivotTables.InsertRange(cellArea_0, int_0, shiftType_0);
	}

	/// <summary>
	///       Deletes a range of cells and shift cells according to the shift option.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="endColumn">End column index.</param>
	/// <param name="shiftType">Shift cells option.</param>
	public void DeleteRange(int startRow, int startColumn, int endRow, int endColumn, ShiftType shiftType)
	{
		method_19().Workbook.method_3();
		if (shiftType != ShiftType.Right && shiftType != 0)
		{
			Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
			CellArea cellArea_ = default(CellArea);
			cellArea_.StartRow = startRow;
			cellArea_.StartColumn = startColumn;
			cellArea_.EndRow = endRow;
			cellArea_.EndColumn = endColumn;
			int num = rowCollection_0.DeleteRange(startRow, startColumn, endRow, endColumn, shiftType, worksheet_0, bool_0: true);
			if (shiftType != ShiftType.None)
			{
				for (int i = 0; i < method_19().Count; i++)
				{
					Worksheet worksheet = method_19()[i];
					if (worksheet_0 == worksheet)
					{
						continue;
					}
					RowCollection rows = worksheet.Cells.Rows;
					for (int j = 0; j < rows.Count; j++)
					{
						Row rowByIndex = rows.GetRowByIndex(j);
						for (int k = 0; k < rowByIndex.method_0(); k++)
						{
							Cell cellByIndex = rowByIndex.GetCellByIndex(k);
							cellByIndex.method_15(shiftType, cellArea_, num, worksheet_0, bool_0: false, 0, 0);
						}
					}
				}
			}
			method_38(cellArea_, num, shiftType);
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid shift option.");
	}

	/// <summary>
	///       Exports data in the <see cref="T:Aspose.Cells.Cells" /> collection to a two-dimension array object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be exported</param>
	/// <param name="totalColumns">Number of columns to be exported</param>
	/// <returns>Exported cell value array object.</returns>
	public object[,] ExportArray(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			object[,] array = new object[totalRows, totalColumns];
			for (int i = 0; i < totalRows; i++)
			{
				Row row = rowCollection_0.GetRow(firstRow + i, bool_0: true, bool_1: false);
				if (row == null || row.method_0() == 0)
				{
					continue;
				}
				for (int j = 0; j < totalColumns; j++)
				{
					Cell cellOrNull = row.GetCellOrNull(firstColumn + j);
					if (cellOrNull != null)
					{
						CellValueType type = cellOrNull.Type;
						if (type == CellValueType.IsDateTime)
						{
							array[i, j] = cellOrNull.DateTimeValue;
						}
						else
						{
							array[i, j] = cellOrNull.Value;
						}
					}
				}
			}
			return array;
		}
		return null;
	}

	/// <summary>
	///       Exports cell value type in the <see cref="T:Aspose.Cells.Cells" /> collection to a two-dimension array object.
	///       </summary>
	/// <param name="firstRow">The row number of the first cell to export out.</param>
	/// <param name="firstColumn">The column number of the first cell to export out.</param>
	/// <param name="totalRows">Number of rows to be exported.</param>
	/// <param name="totalColumns">Number of columns to be exported.</param>
	/// <returns>Exported CellValuetype array object.</returns>
	public CellValueType[,] ExportTypeArray(int firstRow, int firstColumn, int totalRows, int totalColumns)
	{
		if (totalRows != 0 && totalColumns != 0)
		{
			Class1677.smethod_26(firstRow, firstColumn, firstRow + totalRows - 1, firstColumn + totalColumns - 1);
			CellValueType[,] array = new CellValueType[totalRows, totalColumns];
			for (int i = 0; i < totalRows; i++)
			{
				Row row = rowCollection_0.GetRow(firstRow + i, bool_0: true, bool_1: false);
				if (row != null && row.method_0() != 0)
				{
					for (int j = 0; j < totalColumns; j++)
					{
						Cell cellOrNull = row.GetCellOrNull(j + firstColumn);
						if (cellOrNull != null)
						{
							array[i, j] = cellOrNull.Type;
						}
						else
						{
							array[i, j] = CellValueType.IsNull;
						}
					}
				}
				else
				{
					for (int k = 0; k < totalColumns; k++)
					{
						array[i, k] = CellValueType.IsNull;
					}
				}
			}
			return array;
		}
		return null;
	}

	/// <summary>
	///       Imports custom objects.
	///       </summary>
	/// <param name="list">The custom object</param>
	/// <param name="propertyNames">The property names.If it is null,we will import all properties of the object.</param>
	/// <param name="isPropertyNameShown">
	///       Indicates whether the property name will be imported to the first row.
	///       </param>
	/// <param name="firstRow">The row number of the first cell to import in.</param>
	/// <param name="firstColumn">The column number of the first cell to import in.</param>
	/// <param name="rowNumber">Number of rows to be imported.</param>
	/// <param name="insertRows">Indicates whether extra rows are added to fit data.</param>
	/// <param name="dateFormatString">Date format string for cells.</param>
	/// <param name="convertStringToNumber">Indicates if this method will try to convert string to number.</param>
	/// <returns>Total number of rows imported.</returns>
	/// <remarks>The custom objects should be the same type.</remarks>
	public int ImportCustomObjects(ICollection list, string[] propertyNames, bool isPropertyNameShown, int firstRow, int firstColumn, int rowNumber, bool insertRows, string dateFormatString, bool convertStringToNumber)
	{
		ImportTableOptions importTableOptions = new ImportTableOptions();
		importTableOptions.IsFieldNameShown = isPropertyNameShown;
		importTableOptions.TotalRows = rowNumber;
		importTableOptions.InsertRows = insertRows;
		importTableOptions.DateFormat = dateFormatString;
		importTableOptions.ConvertNumericData = convertStringToNumber;
		ICellsDataTable cellsDataTable = Class992.smethod_5(list);
		if (cellsDataTable == null)
		{
			if (isPropertyNameShown && propertyNames != null)
			{
				for (int i = 0; i < propertyNames.Length; i++)
				{
					this[firstRow, firstColumn + i].PutValue(propertyNames[i]);
				}
				return 1;
			}
			return 0;
		}
		if (propertyNames != null)
		{
			importTableOptions.ColumnIndexes = new int[propertyNames.Length];
			string[] columns = cellsDataTable.Columns;
			for (int j = 0; j < propertyNames.Length; j++)
			{
				for (int k = 0; k < columns.Length; k++)
				{
					if (string.Compare(propertyNames[j], columns[k]) == 0)
					{
						importTableOptions.ColumnIndexes[j] = k;
						break;
					}
				}
			}
		}
		return ImportData(cellsDataTable, firstRow, firstColumn, importTableOptions);
	}

	public int ImportCustomObjects(ICollection list, int firstRow, int firstColumn, ImportTableOptions options)
	{
		ICellsDataTable cellsDataTable = Class992.smethod_5(list);
		if (cellsDataTable == null)
		{
			return 0;
		}
		return ImportData(cellsDataTable, firstRow, firstColumn, options);
	}

	/// <summary>
	///       Creates subtotals for the range.
	///       </summary>
	/// <param name="ca">The range</param>
	/// <param name="groupBy">The field to group by, as a zero-based integer offset</param>
	/// <param name="function">The subtotal function.</param>
	/// <param name="totalList">An array of zero-based field offsets, indicating the fields to which the subtotals are added.</param>
	public void Subtotal(CellArea ca, int groupBy, ConsolidationFunction function, int[] totalList)
	{
		Subtotal(ca, groupBy, function, totalList, replace: true, pageBreaks: false, summaryBelowData: true);
	}

	/// <summary>
	///       Creates subtotals for the range.
	///       </summary>
	/// <param name="ca">The range</param>
	/// <param name="groupBy">The field to group by, as a zero-based integer offset</param>
	/// <param name="function">The subtotal function.</param>
	/// <param name="totalList">An array of zero-based field offsets, indicating the fields to which the subtotals are added.</param>
	/// <param name="replace">Indicates whether replace the current subtotals</param>
	/// <param name="pageBreaks">Indicates whether add page break between groups</param>
	/// <param name="summaryBelowData">Indicates whether add summarry below data.</param>
	public void Subtotal(CellArea ca, int groupBy, ConsolidationFunction function, int[] totalList, bool replace, bool pageBreaks, bool summaryBelowData)
	{
		if (totalList != null)
		{
			if (method_19().Workbook.method_24())
			{
				Class1281 @class = new Class1281(this);
				@class.Subtotal(ca, groupBy, function, totalList, replace, pageBreaks, summaryBelowData);
			}
			else
			{
				Class1680 class2 = new Class1680(this);
				class2.Subtotal(ca, groupBy, function, totalList, replace, pageBreaks, summaryBelowData);
			}
		}
	}

	/// <summary>
	///       Removes all formula and replaces with the value of the formula.
	///       </summary>
	public void RemoveFormulas()
	{
		for (int i = 0; i < Rows.Count; i++)
		{
			Row rowByIndex = Rows.GetRowByIndex(i);
			int num = rowByIndex.method_0();
			for (int j = 0; j < num; j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.IsFormula)
				{
					cellByIndex.PutValue(cellByIndex.Value);
				}
			}
		}
	}

	/// <summary>
	///       Remove duplicate values in the range.
	///       </summary>
	/// <param name="startRow">The start row.</param>
	/// <param name="startColumn">The start column</param>
	/// <param name="endRow">The end row index.</param>
	/// <param name="endColumn">The end column index.</param>
	public void RemoveDuplicates(int startRow, int startColumn, int endRow, int endColumn)
	{
		if (endRow > method_20(0))
		{
			endRow = method_20(0);
		}
		if (endRow == -1)
		{
			return;
		}
		bool[] array = new bool[endRow - startRow + 1];
		for (int i = startRow; i <= endRow; i++)
		{
			if (array[i - startRow])
			{
				continue;
			}
			Row row = CheckRow(i);
			for (int j = i + 1; j <= endRow; j++)
			{
				if (array[j - startRow])
				{
					continue;
				}
				bool flag = true;
				Row row2 = CheckRow(j);
				if (row == null && row2 == null)
				{
					array[j - startRow] = true;
					continue;
				}
				for (int k = startColumn; k <= endColumn; k++)
				{
					Cell cell = row?.GetCellOrNull(k);
					Cell cell2 = row2?.GetCellOrNull(k);
					if (cell != null && cell.Type != CellValueType.IsNull)
					{
						if (cell2 != null)
						{
							CellValueType type = cell.Type;
							if (type == cell2.Type)
							{
								if (cell.Value == cell2.Value)
								{
									continue;
								}
								switch (type)
								{
								case CellValueType.IsBool:
									if (cell.BoolValue == cell2.BoolValue)
									{
										continue;
									}
									break;
								case CellValueType.IsDateTime:
									if (cell.DateTimeValue == cell2.DateTimeValue)
									{
										continue;
									}
									break;
								case CellValueType.IsError:
									if (cell.StringValue == cell2.StringValue)
									{
										continue;
									}
									break;
								case CellValueType.IsNumeric:
									if (cell.DoubleValue == cell2.DoubleValue)
									{
										continue;
									}
									break;
								case CellValueType.IsString:
									if (cell.StringValue == cell2.StringValue)
									{
										continue;
									}
									break;
								case CellValueType.IsNull:
									continue;
								}
							}
							flag = false;
						}
						else
						{
							flag = false;
						}
						break;
					}
					if (cell2 != null && cell2.Type != CellValueType.IsNull)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					array[j - startRow] = true;
				}
			}
		}
		int num = 0;
		for (int l = 0; l < array.Length; l++)
		{
			if (!array[l])
			{
				continue;
			}
			int num2 = 1;
			int num3 = l;
			for (l++; l < array.Length; l++)
			{
				if (array[l])
				{
					num2++;
					continue;
				}
				l--;
				break;
			}
			int num4 = startRow + num3 - num;
			int endRow2 = num4 + num2 - 1;
			DeleteRange(num4, startColumn, endRow2, endColumn, ShiftType.Up);
			num += num2;
		}
	}

	/// <summary>
	///       Converts string data in cells to numeric value if possible.
	///       </summary>
	public void ConvertStringToNumericValue()
	{
		for (int i = 0; i < Rows.Count; i++)
		{
			Row rowByIndex = Rows.GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_6)
				{
					string stringValue = cellByIndex.StringValue;
					if (stringValue != null && !(stringValue == ""))
					{
						cellByIndex.PutValue(stringValue, isConverted: true);
					}
				}
			}
		}
	}

	public Cell[] GetDependents(bool isAll, int row, int column)
	{
		int int_ = method_19().method_32().method_10(method_19().method_36(), worksheet_0.Index, worksheet_0.Index);
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < method_19().Names.Count; i++)
		{
			Name name = method_19().Names[i];
			if (name.method_2() != null)
			{
				Range range = name.GetRange();
				if (range != null && range.Worksheet.Index == worksheet_0.Index && range.FirstRow <= row && range.FirstRow + range.RowCount - 1 >= row && range.FirstColumn <= column && range.FirstColumn + range.ColumnCount - 1 >= column)
				{
					hashtable[i] = true;
				}
				else if (Class1674.GetDependents(0, 0, name.method_2(), -1, -1, row, column, int_, this, bool_0: false, hashtable))
				{
					hashtable[i] = true;
				}
			}
		}
		ArrayList arrayList = new ArrayList();
		Cell cell = null;
		for (int j = 0; j < method_19().Count; j++)
		{
			Cells cells = method_19()[j].Cells;
			bool flag;
			if (!(flag = cells == this) && !isAll)
			{
				continue;
			}
			for (int k = 0; k < cells.Rows.Count; k++)
			{
				Row row2 = cells.Rows.method_4(k);
				ArrayList cells2 = row2.Cells;
				for (int l = 0; l < cells2.Count; l++)
				{
					cell = (Cell)cells2[l];
					if (cell.IsFormula && Class1674.GetDependents(cell.Row, cell.Column, cell.method_41(), -1, -1, row, column, int_, cells, flag, hashtable))
					{
						arrayList.Add(cell);
					}
				}
			}
		}
		Cell[] array = new Cell[arrayList.Count];
		for (int m = 0; m < arrayList.Count; m++)
		{
			array[m] = (Cell)arrayList[m];
		}
		arrayList.Clear();
		arrayList = null;
		return array;
	}

	private void method_39(Style style_0, int int_0, int int_1)
	{
		if ((style_0.method_4() == null || style_0.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None) && !IsRowHidden(int_0 - 1))
		{
			Cell cell = CheckCell(int_0 - 1, int_1);
			if (cell != null)
			{
				Style style = cell.method_28();
				if (style.method_4() != null && style.Borders[BorderType.BottomBorder].LineStyle != 0)
				{
					style_0.Borders[BorderType.TopBorder].LineStyle = style.Borders[BorderType.BottomBorder].LineStyle;
					style_0.Borders[BorderType.TopBorder].InternalColor.method_19(style.Borders[BorderType.BottomBorder].InternalColor);
				}
			}
		}
		if ((style_0.method_4() == null || style_0.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None) && !IsRowHidden(int_0 + 1))
		{
			Cell cell2 = CheckCell(int_0 + 1, int_1);
			if (cell2 != null)
			{
				Style style2 = cell2.method_28();
				if (style2.method_4() != null && style2.Borders[BorderType.TopBorder].LineStyle != 0)
				{
					style_0.Borders[BorderType.BottomBorder].LineStyle = style2.Borders[BorderType.TopBorder].LineStyle;
					style_0.Borders[BorderType.BottomBorder].InternalColor.method_19(style2.Borders[BorderType.TopBorder].InternalColor);
				}
			}
		}
		if (style_0.method_4() == null || style_0.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None)
		{
			Cell cell3 = CheckCell(int_0, int_1 - 1);
			if (cell3 != null)
			{
				Style style3 = cell3.method_28();
				if (style3.method_4() != null && style3.Borders[BorderType.RightBorder].LineStyle != 0)
				{
					style_0.Borders[BorderType.LeftBorder].LineStyle = style3.Borders[BorderType.RightBorder].LineStyle;
					style_0.Borders[BorderType.LeftBorder].InternalColor.method_19(style3.Borders[BorderType.RightBorder].InternalColor);
				}
			}
		}
		if (style_0.method_4() != null && style_0.Borders[BorderType.RightBorder].LineStyle != 0)
		{
			return;
		}
		Cell cell4 = CheckCell(int_0, int_1 + 1);
		if (cell4 != null)
		{
			Style style4 = cell4.method_28();
			if (style4.method_4() != null && style4.Borders[BorderType.LeftBorder].LineStyle != 0)
			{
				style_0.Borders[BorderType.RightBorder].LineStyle = style4.Borders[BorderType.LeftBorder].LineStyle;
				style_0.Borders[BorderType.RightBorder].InternalColor.method_19(style4.Borders[BorderType.LeftBorder].InternalColor);
			}
		}
	}

	public Style GetCellStyle(int row, int column)
	{
		int num = method_40(row, column);
		if (num == -1)
		{
			num = 15;
		}
		Style style = new Style(method_19());
		style.GetStyle(method_19(), num);
		method_39(style, row, column);
		return style;
	}

	internal int method_40(int int_0, int int_1)
	{
		Cell cell = rowCollection_0.GetCell(int_0, int_1, bool_0: true, bool_1: false, bool_2: false);
		return method_41(cell, int_0, int_1);
	}

	internal int method_41(Cell cell_0, int int_0, int int_1)
	{
		if (cell_0 != null && cell_0.int_1 != -1)
		{
			return cell_0.int_1;
		}
		Row row = rowCollection_0.GetRow(int_0, bool_0: true, bool_1: false);
		if (row != null && row.method_27())
		{
			return row.method_10();
		}
		int num = columnCollection_0.method_7(int_1);
		if (num != -1)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(num);
			if (columnByIndex.method_10())
			{
				return columnByIndex.method_5();
			}
			return -1;
		}
		return columnCollection_0.method_1(int_1);
	}

	internal ArrayList method_42()
	{
		ArrayList arrayList = new ArrayList();
		if (worksheet_0.class1557_0 != null)
		{
			Hashtable hashtable_ = worksheet_0.class1557_0.hashtable_0;
			if (hashtable_ != null && hashtable_.Count > 0)
			{
				IDictionaryEnumerator enumerator = hashtable_.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class1554 @class = (Class1554)enumerator.Value;
					if (@class != null)
					{
						CellArea cellArea = Class1618.smethod_17(@class.string_1);
						arrayList.Add(cellArea);
					}
				}
			}
		}
		if (worksheet_0.pivotTableCollection_0 != null)
		{
			ArrayList ranges = worksheet_0.pivotTableCollection_0.GetRanges();
			arrayList.AddRange(ranges);
		}
		if (arrayList.Count == 0)
		{
			return null;
		}
		return arrayList;
	}
}
