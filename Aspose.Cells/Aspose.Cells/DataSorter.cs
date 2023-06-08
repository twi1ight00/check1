using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Summary description for DataSorter.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiate a new Workbook object.
///       Workbook workbook = new Workbook("C:\\Book1.xls");
///       //Get the workbook datasorter object.
///       DataSorter sorter = workbook.DataSorter;
///       //Set the first order for datasorter object.
///       sorter.Order1 = Aspose.Cells.SortOrder.Descending;
///       //Define the first key.
///       sorter.Key1 = 0;
///       //Set the second order for datasorter object.
///       sorter.Order2 = Aspose.Cells.SortOrder.Ascending;
///       //Define the second key.
///       sorter.Key2 = 1;
///       //Create a cells area (range).
///       CellArea ca = new CellArea();
///       //Specify the start row index.
///       ca.StartRow = 0;
///       //Specify the start column index.
///       ca.StartColumn = 0;
///       //Specify the last row index.
///       ca.EndRow = 13;
///       //Specify the last column index.
///       ca.EndColumn = 1;
///       //Sort data in the specified data range (A1:B14)
///       sorter.Sort(workbook.Worksheets[0].Cells, ca);
///       //Save the excel file.
///       workbook.Save("C:\\outBook.xls");
///
///       [Visual Basic]
///
///       'Instantiate a new Workbook object.
///       Dim workbook As Workbook = New Workbook("C:\Book1.xls")
///       'Get the workbook datasorter object.
///       Dim sorter As DataSorter = workbook.DataSorter
///       'Set the first order for datasorter object
///       sorter.Order1 = Aspose.Cells.SortOrder.Descending
///       'Define the first key.
///       sorter.Key1 = 0
///       'Set the second order for datasorter object.
///       sorter.Order2 = Aspose.Cells.SortOrder.Ascending
///       'Define the second key.
///       sorter.Key2 = 1
///       'Create a cells area (range).
///       Dim ca As CellArea = New CellArea
///       'Specify the start row index.
///       ca.StartRow = 0
///       'Specify the start column index.
///       ca.StartColumn = 0
///       'Specify the last row index.
///       ca.EndRow = 13
///       'Specify the last column index.
///       ca.EndColumn = 1
///       'Sort the data in the specified data range (A1:B14)
///       sorter.Sort(workbook.Worksheets(0).Cells, ca)
///       'Save the excel file.
///       workbook.Save("C:\outBook.xls")
///
///       </code>
/// </example>
public class DataSorter
{
	internal Workbook workbook_0;

	private object object_0;

	private Cells cells_0;

	private CellArea cellArea_0;

	private ArrayList arrayList_0;

	internal string string_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	/// <summary>
	///       Represents whether the range has headers.
	///       </summary>
	public bool HasHeaders
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
	///       Represents first sorted column index.
	///       </summary>
	public int Key1
	{
		get
		{
			if (arrayList_0.Count > 0)
			{
				return ((Class1108)arrayList_0[0]).Index;
			}
			return -1;
		}
		set
		{
			if (arrayList_0.Count > 0)
			{
				Class1108 @class = (Class1108)arrayList_0[0];
				@class.Index = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Index = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       Represents sort order of the first key.
	///       </summary>
	public SortOrder Order1
	{
		get
		{
			if (arrayList_0.Count > 0)
			{
				return ((Class1108)arrayList_0[0]).Order;
			}
			return SortOrder.Ascending;
		}
		set
		{
			if (arrayList_0.Count > 0)
			{
				Class1108 @class = (Class1108)arrayList_0[0];
				@class.Order = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Order = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       Represents second sorted column index.
	///       </summary>
	public int Key2
	{
		get
		{
			if (arrayList_0.Count > 1)
			{
				return ((Class1108)arrayList_0[1]).Index;
			}
			return -1;
		}
		set
		{
			if (arrayList_0.Count > 1)
			{
				Class1108 @class = (Class1108)arrayList_0[1];
				@class.Index = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Index = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       Represents sort order of the second key.
	///       </summary>
	public SortOrder Order2
	{
		get
		{
			if (arrayList_0.Count > 1)
			{
				return ((Class1108)arrayList_0[1]).Order;
			}
			return SortOrder.Ascending;
		}
		set
		{
			if (arrayList_0.Count > 1)
			{
				Class1108 @class = (Class1108)arrayList_0[1];
				@class.Order = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Order = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       Represents third sorted column index.
	///       </summary>
	public int Key3
	{
		get
		{
			if (arrayList_0.Count > 2)
			{
				return ((Class1108)arrayList_0[2]).Index;
			}
			return -1;
		}
		set
		{
			if (arrayList_0.Count > 2)
			{
				Class1108 @class = (Class1108)arrayList_0[2];
				@class.Index = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Index = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       Represents sort order of the third key.
	///       </summary>
	public SortOrder Order3
	{
		get
		{
			if (arrayList_0.Count > 2)
			{
				return ((Class1108)arrayList_0[2]).Order;
			}
			return SortOrder.Ascending;
		}
		set
		{
			if (arrayList_0.Count > 2)
			{
				Class1108 @class = (Class1108)arrayList_0[2];
				@class.Order = value;
			}
			else
			{
				Class1108 class2 = new Class1108(this);
				class2.Order = value;
				arrayList_0.Add(class2);
			}
		}
	}

	/// <summary>
	///       True means that sorting orientation is from left to right.
	///       False means that sorting orientation is from top to bottom.
	///       The default value is false.
	///       </summary>
	public bool SortLeftToRight
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	/// <summary>
	///       Gets and sets whether case sensitive when comparing string.
	///       </summary>
	public bool CaseSensitive
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal CellArea Area
	{
		get
		{
			if (object_0 is AutoFilter)
			{
				return ((AutoFilter)object_0).method_1();
			}
			return cellArea_0;
		}
	}

	internal DataSorter(object object_1)
	{
		arrayList_0 = new ArrayList();
		method_3(object_1);
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_1(CellArea cellArea_1)
	{
		cellArea_0 = cellArea_1;
		arrayList_0.Clear();
	}

	[SpecialName]
	internal object method_2()
	{
		return object_0;
	}

	[SpecialName]
	internal void method_3(object object_1)
	{
		object_0 = object_1;
		if (object_1 is Workbook)
		{
			workbook_0 = (Workbook)object_1;
		}
		else if (object_1 is AutoFilter)
		{
			AutoFilter autoFilter = (AutoFilter)object_1;
			cells_0 = autoFilter.method_0().Cells;
			workbook_0 = autoFilter.method_0().Workbook;
		}
	}

	/// <summary>
	///       Clear all settings.
	///       </summary>
	public void Clear()
	{
		bool_2 = false;
		bool_0 = false;
		arrayList_0 = new ArrayList();
	}

	/// <summary>
	///       Adds sorted column index and sort order.
	///       </summary>
	/// <param name="key">The sorted column index.</param>
	/// <param name="order">The sort order</param>
	public void AddKey(int key, SortOrder order)
	{
		Class1108 @class = new Class1108(this);
		@class.Index = key;
		@class.Order = order;
		arrayList_0.Add(@class);
	}

	internal void AddKey(Class1108 class1108_0)
	{
		arrayList_0.Add(class1108_0);
	}

	/// <summary>
	///       Sorts the data of the area.
	///       </summary>
	/// <param name="cells">The cells contains the data area.</param>
	/// <param name="startRow">The start row of the area.</param>
	/// <param name="startColumn">The start column of the area.</param>
	/// <param name="endRow">The end row of the area.</param>
	/// <param name="endColumn">The end column of the area.</param>
	public void Sort(Cells cells, int startRow, int startColumn, int endRow, int endColumn)
	{
		CellArea area = default(CellArea);
		area.StartRow = startRow;
		area.StartColumn = startColumn;
		area.EndRow = endRow;
		area.EndColumn = endColumn;
		Sort(cells, area);
	}

	/// <summary>
	///       Sort the datas of the area.
	///       </summary>
	/// <param name="cells">The cells contains the data area.</param>
	/// <param name="area">The area needed to sort</param>
	public void Sort(Cells cells, CellArea area)
	{
		cells_0 = cells;
		cellArea_0 = area;
		Sort();
		cells_0 = null;
	}

	/// <summary>
	///       Sort the data in the range.
	///       </summary>
	public void Sort()
	{
		if (object_0 is AutoFilter)
		{
			AutoFilter autoFilter = (AutoFilter)object_0;
			cellArea_0 = autoFilter.method_1();
		}
		cells_0.method_19().Workbook.method_5();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1108 @class = (Class1108)arrayList_0[i];
			if (@class.Index < 0)
			{
				arrayList_0.RemoveAt(i--);
			}
		}
		if (arrayList_0.Count == 0)
		{
			return;
		}
		if (bool_1)
		{
			method_13();
			return;
		}
		cells_0.Rows.method_18();
		ArrayList arrayList = new ArrayList();
		int num = (bool_0 ? (cellArea_0.StartRow + 1) : cellArea_0.StartRow);
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		for (int j = num; j <= cellArea_0.EndRow; j++)
		{
			Row row = cells_0.Rows.GetRow(j, bool_0: true, bool_1: false);
			if (row != null && row.method_24() != 0 && (row.int_0 == num || row.int_0 == num + 1))
			{
				num3 = (num4 = row.int_0);
				for (j++; j <= cellArea_0.EndRow; j++)
				{
					row = cells_0.Rows.GetRow(j, bool_0: true, bool_1: false);
					if (row != null && row.method_24() != 0)
					{
						num4 = j;
						continue;
					}
					num2 = row.int_0;
					break;
				}
				if (num4 == cellArea_0.EndRow)
				{
					num3 = (num4 = -1);
					for (j = num; j < cellArea_0.EndRow; j++)
					{
						arrayList.Add(j);
					}
				}
			}
			arrayList.Add(j);
		}
		method_11(0, Key1, Order1, arrayList);
		int num5 = num;
		RowCollection rows = cells_0.Rows;
		rows.method_7();
		HyperlinkCollection hyperlinks = cells_0.method_3().Hyperlinks;
		CellArea[] array = new CellArea[hyperlinks.Count];
		for (int k = 0; k < array.Length; k++)
		{
			ref CellArea reference = ref array[k];
			reference = hyperlinks[k].Area;
		}
		RowCollection rowCollection = new RowCollection(cells_0, cells_0.method_0(), cellArea_0.EndRow - cellArea_0.StartRow + 1);
		Row row2 = null;
		for (int l = num; l <= cellArea_0.EndRow; l++)
		{
			Row row3 = cells_0.Rows.GetRow(l, bool_0: true, bool_1: false);
			if (row3 == null)
			{
				continue;
			}
			row2 = rowCollection.method_1(l, cellArea_0.EndColumn - cellArea_0.StartColumn + 1);
			row2.CopyData(row3);
			if (row3.int_0 >= num3 && row3.int_0 <= num4)
			{
				row3.method_25(0);
			}
			int num6 = -1;
			int num7 = -1;
			for (int m = 0; m < row3.method_0(); m++)
			{
				Cell cellByIndex = row3.GetCellByIndex(m);
				if (cellByIndex.Column >= cellArea_0.StartColumn)
				{
					if (cellByIndex.Column > cellArea_0.EndColumn)
					{
						break;
					}
					if (num6 == -1)
					{
						num6 = m;
					}
					num7 = m;
					row2.method_6(cellByIndex);
				}
			}
			if (num6 != -1)
			{
				row3.RemoveRange(num6, num7 - num6 + 1);
			}
		}
		for (int n = 0; n < arrayList.Count; n++)
		{
			int num8 = (int)arrayList[n];
			if (num8 == num2)
			{
				for (int num9 = num3; num9 <= num4; num9++)
				{
					row2 = rowCollection.GetRow(num9, bool_0: true, bool_1: false);
					method_4(row2, num5, cellArea_0.StartColumn, cellArea_0.EndColumn, bool_3: true, array);
					num5++;
				}
			}
			row2 = rowCollection.GetRow(num8, bool_0: true, bool_1: false);
			method_4(row2, num5, cellArea_0.StartColumn, cellArea_0.EndColumn, bool_3: false, array);
			num5++;
		}
		for (int num10 = 0; num10 < array.Length; num10++)
		{
			hyperlinks[num10].method_4(array[num10]);
		}
	}

	private void method_4(Row row_0, int int_0, int int_1, int int_2, bool bool_3, CellArea[] cellArea_1)
	{
		if (row_0 == null)
		{
			return;
		}
		HyperlinkCollection hyperlinks = cells_0.method_3().Hyperlinks;
		for (int i = 0; i < hyperlinks.Count; i++)
		{
			Hyperlink hyperlink = hyperlinks[i];
			CellArea area = hyperlink.Area;
			if (area.EndRow == area.StartRow && area.StartRow == row_0.Index && area.StartColumn >= int_1 && area.EndColumn <= int_2)
			{
				area.StartRow = (area.EndRow = int_0);
				cellArea_1[i] = area;
			}
		}
		Row row = null;
		if (bool_3)
		{
			row = cells_0.Rows.GetRow(int_0, bool_0: false, bool_1: true);
			row.method_25(row_0.method_24());
		}
		if (!row_0.method_27() && row_0.method_0() == 0)
		{
			return;
		}
		if (row == null)
		{
			row = cells_0.Rows.GetRow(int_0, bool_0: false, bool_1: true);
		}
		if (row_0.method_27())
		{
			for (int j = int_1; j <= int_2; j++)
			{
				Cell cell = row.GetCell(j);
				Cell cellOrNull = row_0.GetCellOrNull(j);
				if (cellOrNull == null)
				{
					cell.method_37(row_0.method_10());
				}
				else
				{
					method_6(cellOrNull, cell);
				}
			}
			return;
		}
		for (int k = int_1; k <= int_2; k++)
		{
			Cell cellOrNull2 = row_0.GetCellOrNull(k);
			if (cellOrNull2 != null)
			{
				Cell cell2 = row.GetCell(k);
				method_6(cellOrNull2, cell2);
			}
		}
	}

	private int method_5(ArrayList arrayList_1, int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				if ((int)arrayList_1[num] == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	private void method_6(Cell cell_0, Cell cell_1)
	{
		cell_1.method_37(cell_0.method_36());
		if (cell_0.IsFormula)
		{
			cell_1.PutValue(null);
			cell_1.method_42(cell_0.method_41());
			if (cell_0.Row != cell_1.Row)
			{
				byte[] byte_ = cell_1.method_41();
				Class1674.smethod_11(cells_0.method_3(), bool_0: true, 0, cell_1.Row - cell_0.Row, 0, 0, -1, -1, byte_);
			}
		}
		else
		{
			cell_1.PutValue(cell_0.Value);
		}
	}

	[SpecialName]
	private int method_7()
	{
		return arrayList_0.Count - 1;
	}

	internal void method_8(int int_0, SortOrder sortOrder_0, ArrayList arrayList_1, SortedList sortedList_0, SortedList sortedList_1, ArrayList arrayList_2, ArrayList arrayList_3, ArrayList arrayList_4)
	{
		Cell cell = null;
		ArrayList arrayList = null;
		foreach (int item in arrayList_1)
		{
			cell = cells_0.CheckCell(item, int_0);
			if (cell == null)
			{
				arrayList_2.Add(item);
				continue;
			}
			switch (cell.Type)
			{
			case CellValueType.IsBool:
				if (cell.BoolValue)
				{
					arrayList_3.Add(item);
				}
				else
				{
					arrayList_4.Add(item);
				}
				continue;
			case CellValueType.IsNull:
				arrayList_2.Add(item);
				continue;
			case CellValueType.IsDateTime:
			case CellValueType.IsNumeric:
			{
				double doubleValue = cell.DoubleValue;
				if (sortedList_1[doubleValue] == null)
				{
					arrayList = new ArrayList();
					arrayList.Add(item);
					sortedList_1[doubleValue] = arrayList;
				}
				else
				{
					arrayList = (ArrayList)sortedList_1[doubleValue];
					arrayList.Add(item);
				}
				continue;
			}
			}
			string text = cell.StringValue;
			if (CaseSensitive)
			{
				text = text.ToUpper();
			}
			if (sortedList_0[text] == null)
			{
				arrayList = new ArrayList();
				arrayList.Add(item);
				sortedList_0[text] = arrayList;
			}
			else
			{
				arrayList = (ArrayList)sortedList_0[text];
				arrayList.Add(item);
			}
		}
	}

	internal int method_9(int int_0)
	{
		return ((Class1108)arrayList_0[int_0]).Index;
	}

	internal SortOrder method_10(int int_0)
	{
		return ((Class1108)arrayList_0[int_0]).Order;
	}

	internal void method_11(int int_0, int int_1, SortOrder sortOrder_0, ArrayList arrayList_1)
	{
		SortedList sortedList_ = new SortedList(new Class1107(sortOrder_0 == SortOrder.Ascending, bool_3: false));
		SortedList sortedList = new SortedList(new Class1107(sortOrder_0 == SortOrder.Ascending, bool_3: true));
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		method_8(int_1, sortOrder_0, arrayList_1, sortedList_, sortedList, arrayList3, arrayList, arrayList2);
		bool flag = false;
		SortOrder sortOrder_ = SortOrder.Ascending;
		if (int_0 < method_7())
		{
			int_0++;
			int_1 = method_9(int_0);
			sortOrder_ = method_10(int_0);
			flag = true;
		}
		else
		{
			int_1 = -1;
		}
		arrayList_1.Clear();
		if (sortOrder_0 == SortOrder.Ascending)
		{
			method_12(sortedList, int_0, int_1, sortOrder_, arrayList_1);
			method_12(sortedList_, int_0, int_1, sortOrder_, arrayList_1);
			if (flag)
			{
				method_11(int_0, int_1, sortOrder_, arrayList2);
				method_11(int_0, int_1, sortOrder_, arrayList);
			}
			arrayList_1.AddRange(arrayList2);
			arrayList_1.AddRange(arrayList);
		}
		else
		{
			if (flag)
			{
				method_11(int_0, int_1, sortOrder_, arrayList2);
				method_11(int_0, int_1, sortOrder_, arrayList);
			}
			arrayList_1.AddRange(arrayList);
			arrayList_1.AddRange(arrayList2);
			method_12(sortedList_, int_0, int_1, sortOrder_, arrayList_1);
			method_12(sortedList, int_0, int_1, sortOrder_, arrayList_1);
		}
		if (flag)
		{
			method_11(int_0, int_1, sortOrder_, arrayList3);
		}
		arrayList_1.AddRange(arrayList3);
	}

	private void method_12(SortedList sortedList_0, int int_0, int int_1, SortOrder sortOrder_0, ArrayList arrayList_1)
	{
		if (int_1 == -1)
		{
			foreach (ArrayList value in sortedList_0.Values)
			{
				arrayList_1.AddRange(value);
			}
			return;
		}
		foreach (ArrayList value2 in sortedList_0.Values)
		{
			if (value2.Count == 1)
			{
				arrayList_1.Add(value2[0]);
				continue;
			}
			method_11(int_0, int_1, sortOrder_0, value2);
			arrayList_1.AddRange(value2);
		}
	}

	private void method_13()
	{
		cells_0.Rows.method_7();
		ArrayList arrayList = new ArrayList();
		int num = (bool_0 ? (cellArea_0.StartColumn + 1) : cellArea_0.StartColumn);
		for (int i = num; i <= cellArea_0.EndColumn; i++)
		{
			arrayList.Add(i);
		}
		method_14(0, Key1, Order1, arrayList);
		int num2 = num;
		int num3 = 0;
		int num4 = 0;
		for (int j = 0; j < arrayList.Count; j++)
		{
			int num5 = (int)arrayList[j];
			if (num5 != -1 && num5 != num + j)
			{
				num2 = num + j;
				ArrayList arrayList2 = new ArrayList();
				num4 = num2;
				num3 = j;
				for (int k = cellArea_0.StartRow; k <= cellArea_0.EndRow; k++)
				{
					Cell cell = cells_0.CheckCell(k, num5);
					if (cell != null)
					{
						arrayList2.Add(cell);
						cells_0.Rows.method_12(k, num5);
					}
				}
				while (num3 != -1)
				{
					arrayList2 = method_17(num4, arrayList2, cellArea_0.StartRow, cellArea_0.EndRow);
					arrayList[num3] = -1;
					num3 = method_5(arrayList, num4);
					num4 = num + num3;
				}
			}
			else
			{
				arrayList[j] = -1;
			}
		}
	}

	internal void method_14(int int_0, int int_1, SortOrder sortOrder_0, ArrayList arrayList_1)
	{
		SortedList sortedList_ = new SortedList(new Class1107(sortOrder_0 == SortOrder.Ascending, bool_3: false));
		SortedList sortedList = new SortedList(new Class1107(sortOrder_0 == SortOrder.Ascending, bool_3: true));
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		method_16(int_1, sortOrder_0, arrayList_1, sortedList_, sortedList, arrayList3, arrayList, arrayList2);
		bool flag = false;
		SortOrder sortOrder_ = SortOrder.Ascending;
		if (int_0 < method_7())
		{
			int_0++;
			int_1 = method_9(int_0);
			sortOrder_ = method_10(int_0);
			flag = true;
		}
		else
		{
			int_1 = -1;
		}
		arrayList_1.Clear();
		if (sortOrder_0 == SortOrder.Ascending)
		{
			method_15(sortedList, int_0, int_1, sortOrder_, arrayList_1);
			method_15(sortedList_, int_0, int_1, sortOrder_, arrayList_1);
			if (flag)
			{
				method_14(int_0, int_1, sortOrder_, arrayList2);
				method_14(int_0, int_1, sortOrder_, arrayList);
			}
			arrayList_1.AddRange(arrayList2);
			arrayList_1.AddRange(arrayList);
		}
		else
		{
			if (flag)
			{
				method_14(int_0, int_1, sortOrder_, arrayList2);
				method_14(int_0, int_1, sortOrder_, arrayList);
			}
			arrayList_1.AddRange(arrayList);
			arrayList_1.AddRange(arrayList2);
			method_15(sortedList_, int_0, int_1, sortOrder_, arrayList_1);
			method_15(sortedList, int_0, int_1, sortOrder_, arrayList_1);
		}
		if (flag)
		{
			method_14(int_0, int_1, sortOrder_, arrayList3);
		}
		arrayList_1.AddRange(arrayList3);
	}

	private void method_15(SortedList sortedList_0, int int_0, int int_1, SortOrder sortOrder_0, ArrayList arrayList_1)
	{
		if (int_1 == -1)
		{
			foreach (ArrayList value in sortedList_0.Values)
			{
				arrayList_1.AddRange(value);
			}
			return;
		}
		foreach (ArrayList value2 in sortedList_0.Values)
		{
			if (value2.Count == 1)
			{
				arrayList_1.Add(value2[0]);
				continue;
			}
			method_14(int_0, int_1, sortOrder_0, value2);
			arrayList_1.AddRange(value2);
		}
	}

	internal void method_16(int int_0, SortOrder sortOrder_0, ArrayList arrayList_1, SortedList sortedList_0, SortedList sortedList_1, ArrayList arrayList_2, ArrayList arrayList_3, ArrayList arrayList_4)
	{
		Cell cell = null;
		ArrayList arrayList = null;
		foreach (int item in arrayList_1)
		{
			cell = cells_0.CheckCell(int_0, item);
			if (cell == null)
			{
				arrayList_2.Add(item);
				continue;
			}
			switch (cell.Type)
			{
			case CellValueType.IsBool:
				if (cell.BoolValue)
				{
					arrayList_3.Add(item);
				}
				else
				{
					arrayList_4.Add(item);
				}
				continue;
			case CellValueType.IsNull:
				arrayList_2.Add(int_0);
				continue;
			case CellValueType.IsDateTime:
			case CellValueType.IsNumeric:
			{
				double doubleValue = cell.DoubleValue;
				if (sortedList_1[doubleValue] == null)
				{
					arrayList = new ArrayList();
					arrayList.Add(item);
					sortedList_1[doubleValue] = arrayList;
				}
				else
				{
					arrayList = (ArrayList)sortedList_1[doubleValue];
					arrayList.Add(item);
				}
				continue;
			}
			}
			string text = cell.StringValue;
			if (CaseSensitive)
			{
				text = text.ToUpper();
			}
			if (sortedList_0[text] == null)
			{
				arrayList = new ArrayList();
				arrayList.Add(item);
				sortedList_0[text] = arrayList;
			}
			else
			{
				arrayList = (ArrayList)sortedList_0[text];
				arrayList.Add(item);
			}
		}
	}

	private ArrayList method_17(int int_0, ArrayList arrayList_1, int int_1, int int_2)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = int_1; i <= int_2; i++)
		{
			Cell cell = cells_0.CheckCell(i, int_0);
			if (cell != null)
			{
				arrayList.Add(cell);
				cells_0.Rows.method_12(i, int_0);
			}
		}
		foreach (Cell item in arrayList_1)
		{
			method_18(item, cells_0.GetCell(item.Row, int_0, bool_2: false));
		}
		return arrayList;
	}

	private void method_18(Cell cell_0, Cell cell_1)
	{
		cell_1.method_37(cell_0.method_36());
		if (cell_0.IsFormula)
		{
			cell_1.PutValue(null);
			cell_1.method_42(cell_0.method_41());
			if (cell_0.Row != cell_1.Row)
			{
				byte[] byte_ = cell_1.method_41();
				Class1674.InsertColumns(cells_0.method_3(), bool_0: true, 0, cell_1.Column - cell_0.Column, 0, 0, -1, -1, byte_);
			}
		}
		else
		{
			cell_1.PutValue(cell_0.Value);
		}
	}
}
