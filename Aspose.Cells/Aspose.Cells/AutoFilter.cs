using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns16;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Represents autofiltering for the specified worksheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Creating a file stream containing the Excel file to be opened
///       FileStream fstream = new FileStream("C:\\book1.xls", FileMode.Open);
///       //Instantiating a Workbook object and open a stream.
///       Workbook workbook = new Workbook(fstream);
///       //Accessing the first worksheet in the Excel file
///       Worksheet worksheet = workbook.Worksheets[0];
///       //Creating AutoFilter by giving the cells range of the heading row
///       worksheet.AutoFilter.Range = "A1:B1";
///       //Filtering columns with specified values
///       worksheet.AutoFilter.Filter(1, "Bananas");
///       //Saving the modified Excel file.
///       workbook.Save("C:\\output.xls");
///       //Closing the file stream to free all resources
///       fstream.Close();
///
///       [Visual Basic]
///
///       'Creating a file stream containing the Excel file to be opened
///       Dim fstream As FileStream = New FileStream("C:\\book1.xls", FileMode.Open)
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook(fstream)
///       'Accessing the first worksheet in the Excel file
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///       'Creating AutoFilter by giving the cells range of the heading row
///       worksheet.AutoFilter.Range = "A1:B1"
///       'Filtering columns with specified values
///       Worksheet.AutoFilter.Filter(1, "Bananas")
///       'Saving the modified Excel file 
///       workbook.Save("C:\\output.xls")
///       'Closing the file stream to free all resources
///       fstream.Close()
///       </code>
/// </example>
public class AutoFilter
{
	private Worksheet worksheet_0;

	private object object_0;

	internal DataSorter dataSorter_0;

	private CellArea cellArea_0;

	private string string_0;

	internal bool bool_0;

	private FilterColumnCollection filterColumnCollection_0;

	/// <summary>
	///       Gets the data sorter.
	///       </summary>
	public DataSorter Sorter
	{
		get
		{
			if (dataSorter_0 == null)
			{
				dataSorter_0 = new DataSorter(this);
			}
			return dataSorter_0;
		}
	}

	/// <summary>
	///       Represents the range to which the specified AutoFilter applies.
	///       </summary>
	public string Range
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (value != null && value != "")
			{
				method_8();
			}
			else
			{
				filterColumnCollection_0.Clear();
			}
		}
	}

	/// <summary>
	///       Gets the collection of the filer columns.
	///       </summary>
	public FilterColumnCollection FilterColumnCollection
	{
		get
		{
			if (filterColumnCollection_0 == null)
			{
				filterColumnCollection_0 = new FilterColumnCollection(this);
			}
			return filterColumnCollection_0;
		}
	}

	internal int Count
	{
		get
		{
			if (string_0 != null && !(string_0 == ""))
			{
				int num = cellArea_0.EndColumn - cellArea_0.StartColumn + 1;
				int startRow = cellArea_0.StartRow;
				Class1133 @class = worksheet_0.Cells.method_18();
				for (int i = cellArea_0.StartColumn; i <= cellArea_0.EndColumn; i++)
				{
					for (int j = 0; j < @class.Count; j++)
					{
						CellArea cellArea = @class[j];
						if (startRow >= cellArea.StartRow && startRow <= cellArea.EndRow && i >= cellArea.StartColumn && i <= cellArea.EndColumn)
						{
							int endColumn = cellArea.EndColumn;
							if (cellArea.EndColumn > cellArea_0.EndColumn)
							{
								endColumn = cellArea_0.EndColumn;
							}
							int startColumn = cellArea.StartColumn;
							if (cellArea.StartColumn < cellArea_0.StartColumn)
							{
								startColumn = cellArea_0.StartColumn;
							}
							num -= endColumn - startColumn;
							i = cellArea.EndColumn;
							break;
						}
					}
				}
				return num;
			}
			return 0;
		}
	}

	internal ushort Row => (ushort)cellArea_0.StartRow;

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	internal AutoFilter(Worksheet worksheet_1, object object_1)
	{
		worksheet_0 = worksheet_1;
		cellArea_0 = default(CellArea);
		object_0 = object_1;
		filterColumnCollection_0 = new FilterColumnCollection(this);
	}

	[SpecialName]
	internal CellArea method_1()
	{
		CellArea result = default(CellArea);
		result.StartRow = cellArea_0.StartRow + 1;
		result.EndRow = worksheet_0.Cells.MaxRow;
		result.StartColumn = cellArea_0.StartColumn;
		result.EndColumn = cellArea_0.EndColumn;
		if (object_0 != null)
		{
			if (object_0 is ListObject)
			{
				ListObject listObject = (ListObject)object_0;
				result.StartRow = listObject.StartRow + 1;
				result.EndRow = listObject.EndRow;
			}
			else if (object_0 is PivotTable)
			{
				PivotTable pivotTable = (PivotTable)object_0;
				result.StartRow = pivotTable.int_5;
				result.EndRow = pivotTable.int_1;
			}
		}
		return result;
	}

	internal void Copy(AutoFilter autoFilter_0)
	{
		string_0 = autoFilter_0.string_0;
		if (autoFilter_0.string_0 != null)
		{
			cellArea_0 = CellArea.CreateCellArea(autoFilter_0.cellArea_0);
			filterColumnCollection_0.Copy(autoFilter_0.filterColumnCollection_0);
		}
	}

	/// <summary>
	///       Sets the range to which the specified AutoFilter applies.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endColumn">End column Index.</param>
	public void SetRange(int row, int startColumn, int endColumn)
	{
		string_0 = CellsHelper.CellIndexToName(row, startColumn) + ":" + CellsHelper.CellIndexToName(row, endColumn);
		cellArea_0.StartRow = row;
		cellArea_0.EndRow = row;
		cellArea_0.StartColumn = startColumn;
		cellArea_0.EndColumn = endColumn;
	}

	internal void method_2()
	{
		if (string_0 == null || string_0 == "")
		{
			return;
		}
		int startRow = cellArea_0.StartRow;
		Class1133 @class = worksheet_0.Cells.method_18();
		for (int i = cellArea_0.StartColumn; i <= cellArea_0.EndColumn; i++)
		{
			for (int j = 0; j < @class.Count; j++)
			{
				CellArea cellArea = @class[j];
				if (startRow < cellArea.StartRow || startRow > cellArea.EndRow || i < cellArea.StartColumn || i > cellArea.EndColumn)
				{
					continue;
				}
				int endColumn = cellArea.EndColumn;
				if (cellArea.EndColumn > cellArea_0.EndColumn)
				{
					endColumn = cellArea_0.EndColumn;
				}
				int startColumn = cellArea.StartColumn;
				if (cellArea.StartColumn < cellArea_0.StartColumn)
				{
					startColumn = cellArea_0.StartColumn;
				}
				for (int k = startColumn; k < endColumn; k++)
				{
					if (filterColumnCollection_0 == null)
					{
						filterColumnCollection_0 = new FilterColumnCollection(this);
					}
					FilterColumn filterColumn = method_5()[k - cellArea_0.StartColumn];
					filterColumn.method_1(bool_2: true);
					filterColumn.method_3(bool_2: false);
				}
				i = cellArea.EndColumn;
				break;
			}
		}
	}

	internal void method_3(Name name_0)
	{
		Range range = name_0.GetRange();
		if (range != null)
		{
			cellArea_0 = range.Area;
			string_0 = CellsHelper.CellIndexToName(cellArea_0.StartRow, cellArea_0.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea_0.EndRow, cellArea_0.EndColumn);
		}
	}

	/// <summary>
	///       Adds a filter for a filter column.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <param name="criteria">The specified criteria (a string; for example, "101"). 
	///       It only can be null or be one of the cells' value in this column.
	///       </param>
	/// <remarks>
	///       MS Excel 2007 supports multiple selection in a filter column.
	///       </remarks>
	public void AddFilter(int fieldIndex, string criteria)
	{
		if (fieldIndex < 0 || fieldIndex > cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
		}
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.AddFilter(criteria);
		bool_0 = true;
	}

	/// <summary>
	///       Adds a date filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <param name="dateTimeGroupingType">
	///   <see cref="T:Aspose.Cells.DateTimeGroupingType" />
	/// </param>
	/// <param name="year">The year.</param>
	/// <param name="month">The month.</param>
	/// <param name="day">The day.</param>
	/// <param name="hour">The hour.</param>
	/// <param name="minute">The minute.</param>
	/// <param name="second">The second.</param>
	/// <remarks>
	///       If DateTimeGroupingType is Year, only the param year effects.
	///       If DateTiemGroupingType is Month, only the param year and month effect.
	///       </remarks>
	public void AddDateFilter(int fieldIndex, DateTimeGroupingType dateTimeGroupingType, int year, int month, int day, int hour, int minute, int second)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.AddDateFilter(fieldIndex, dateTimeGroupingType, year, month, day, hour, minute, second);
		bool_0 = true;
	}

	/// <summary>
	///       Removes a date filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <param name="dateTimeGroupingType">
	///   <see cref="T:Aspose.Cells.DateTimeGroupingType" />
	/// </param>
	/// <param name="year">The year.</param>
	/// <param name="month">The month.</param>
	/// <param name="day">The day.</param>
	/// <param name="hour">The hour.</param>
	/// <param name="minute">The minute.</param>
	/// <param name="second">The second.</param>
	/// <remarks>
	///       If DateTimeGroupingType is Year, only the param year effects.
	///       If DateTiemGroupingType is Month, only the param year and month effect.
	///       </remarks>
	public void RemoveDateFilter(int fieldIndex, DateTimeGroupingType dateTimeGroupingType, int year, int month, int day, int hour, int minute, int second)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.RemoveDateFilter(fieldIndex, dateTimeGroupingType, year, month, day, hour, minute, second);
		bool_0 = true;
	}

	/// <summary>
	///       Removes a filter for a filter column.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <param name="criteria">The specified criteria (a string; for example, "101"). 
	///       It only can be null or be one of the cells' value in this column.
	///       </param>
	public void RemoveFilter(int fieldIndex, string criteria)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.RemoveFilter(criteria);
		bool_0 = true;
	}

	/// <summary>
	///       Filters a list with specified criteria.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <param name="criteria">The specified criteria (a string; for example, "101"). </param>
	/// <remarks>
	///       Aspose.Cells will remove all other filter setting on this field as Ms Excel 97-2003.
	///       </remarks>
	public void Filter(int fieldIndex, string criteria)
	{
		if (fieldIndex < 0 || fieldIndex > cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
		}
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.method_7(criteria);
		bool_0 = true;
	}

	/// <summary>
	///       Filter the top 10 item in the list
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="isTop">Indicates whether filter from top or bottom</param>
	/// <param name="isPercent">Indicates whether the items is percent or count </param>
	/// <param name="itemCount">The item count</param>
	public void FilterTop10(int fieldIndex, bool isTop, bool isPercent, int itemCount)
	{
		if (fieldIndex < 0 || fieldIndex > cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
		}
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.FilterTop10(isTop, isPercent, itemCount);
		bool_0 = true;
	}

	/// <summary>
	///       Adds a dynamic filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="dynamicFilterType">
	///       Dynamic filter type.
	///       </param>
	public void DynamicFilter(int fieldIndex, DynamicFilterType dynamicFilterType)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.DynamicFilter(dynamicFilterType);
		bool_0 = true;
	}

	/// <summary>
	///       Adds a font color filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="color">The <see cref="T:Aspose.Cells.CellsColor" /> object.
	///       </param>
	public void AddFontColorFilter(int fieldIndex, CellsColor color)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.method_5(color);
		bool_0 = true;
	}

	/// <summary>
	///       Adds a fill color filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="pattern">The background pattern type.</param>
	/// <param name="foregroundColor">The foreground color.</param>
	/// <param name="backgroundColor">The background color.</param>
	public void AddFillColorFilter(int fieldIndex, BackgroundType pattern, CellsColor foregroundColor, CellsColor backgroundColor)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.method_6(pattern, foregroundColor, backgroundColor);
		bool_0 = true;
	}

	/// <summary>
	///       Adds an icon filter.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="iconSetType">The icon set type.</param>
	/// <param name="iconId">The icon id.</param>
	/// <remarks>
	///       Only supports to add the icon filter.
	///       Not supports checking which row is visible if the filter is icon filter.
	///       </remarks>
	public void AddIconFilter(int fieldIndex, IconSetType iconSetType, int iconId)
	{
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.AddIconFilter(iconSetType, iconId);
		bool_0 = true;
	}

	/// <summary>
	///       Match all blank cell in the list.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	public void MatchBlanks(int fieldIndex)
	{
		if (fieldIndex < 0 || fieldIndex > cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
		}
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.MatchBlanks();
		bool_0 = true;
	}

	/// <summary>
	///       Match all not blank cell in the list.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	public void MatchNonBlanks(int fieldIndex)
	{
		if (fieldIndex < 0 || fieldIndex > cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
		}
		FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
		filterColumn.MatchNonBlanks();
		bool_0 = true;
	}

	/// <summary>
	///       Filters a list with a custom criteria.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="operatorType1">The filter operator type</param>
	/// <param name="criteria1">The custom criteria</param>
	public void Custom(int fieldIndex, FilterOperatorType operatorType1, object criteria1)
	{
		if (criteria1 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "The custom criteria of auto filter could not be null");
		}
		Custom(fieldIndex, operatorType1, criteria1, isAnd: false, FilterOperatorType.None, null);
		bool_0 = true;
	}

	/// <summary>
	///       Filters a list with custom criterias.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).</param>
	/// <param name="operatorType1">The filter operator type</param>
	/// <param name="criteria1">The custom criteria</param>
	/// <param name="isAnd">
	/// </param>
	/// <param name="operatorType2">The filter operator type</param>
	/// <param name="criteria2">The custom criteria</param>
	public void Custom(int fieldIndex, FilterOperatorType operatorType1, object criteria1, bool isAnd, FilterOperatorType operatorType2, object criteria2)
	{
		if (fieldIndex >= 0 && fieldIndex <= cellArea_0.EndColumn - cellArea_0.StartColumn)
		{
			if (operatorType2 != FilterOperatorType.None && criteria2 == null)
			{
				throw new CellsException(ExceptionType.InvalidData, "The custom criteria of auto filter could not be null");
			}
			FilterColumn filterColumn = filterColumnCollection_0[fieldIndex];
			filterColumn.Custom(operatorType1, criteria1, isAnd, operatorType2, criteria2);
			bool_0 = true;
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Field index is out of range.");
	}

	/// <summary>
	///       Unhide all rows.
	///       </summary>
	public void ShowAll()
	{
		filterColumnCollection_0.Clear();
		Cells cells = worksheet_0.Cells;
		for (int i = 0; i < cells.Rows.Count; i++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(i);
			if (rowByIndex.IsHidden)
			{
				rowByIndex.IsHidden = false;
			}
		}
	}

	/// <summary>
	///       Remove the specific filter.
	///       </summary>
	/// <param name="fieldIndex">The specific filter index</param>
	public void RemoveFilter(int fieldIndex)
	{
		int num = 0;
		while (true)
		{
			if (num < filterColumnCollection_0.Count)
			{
				FilterColumn byIndex = filterColumnCollection_0.GetByIndex(num);
				if (byIndex.FieldIndex == fieldIndex)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		filterColumnCollection_0.RemoveAt(num);
	}

	internal bool method_4(object object_1)
	{
		int num = 0;
		while (true)
		{
			if (num < filterColumnCollection_0.Count)
			{
				FilterColumn byIndex = filterColumnCollection_0.GetByIndex(num);
				if (!byIndex.method_8(object_1))
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

	/// <summary>
	///       Refresh auto filters to hide or unhide the rows. 
	///       </summary>
	public void Refresh()
	{
		if (filterColumnCollection_0.Count == 0)
		{
			return;
		}
		Cells cells = worksheet_0.Cells;
		int i = cellArea_0.StartRow + 1;
		int num = 0;
		int startColumn = cellArea_0.StartColumn;
		int num2 = cells.MaxDataRow;
		if (num2 == -1)
		{
			num2 = 0;
		}
		int num3 = cellArea_0.EndRow;
		bool flag = cellArea_0.EndRow != cellArea_0.StartRow;
		for (int j = 0; j < cells.Rows.Count; j++)
		{
			Row rowByIndex = cells.Rows.GetRowByIndex(j);
			if (rowByIndex.Index < i)
			{
				continue;
			}
			if (rowByIndex.Index > num2)
			{
				break;
			}
			if (rowByIndex.InnerHeight == 0.0 || rowByIndex.IsHidden)
			{
				cells.UnhideRow(rowByIndex.int_0, cells.StandardHeight);
			}
			if (flag && rowByIndex.Index > num3 && !rowByIndex.IsBlank)
			{
				if (num3 + 1 != rowByIndex.Index)
				{
					num2 = num3;
					break;
				}
				num3 = rowByIndex.Index;
			}
		}
		for (int k = 0; k < filterColumnCollection_0.Count; k++)
		{
			FilterColumn byIndex = filterColumnCollection_0.GetByIndex(k);
			FilterType filterType = byIndex.FilterType;
			if (filterType == FilterType.DynamicFilter)
			{
				((DynamicFilter)byIndex.Filter).method_0(cells, startColumn + byIndex.FieldIndex, i, num2);
			}
			if (byIndex.FilterType != FilterType.Top10)
			{
				continue;
			}
			num = startColumn + byIndex.FieldIndex;
			SortedList sortedList = new SortedList();
			int num4 = 0;
			for (i = cellArea_0.StartRow + 1; i <= num2; i++)
			{
				Cell cell = cells.CheckCell(i, num);
				if (cell == null)
				{
					cells.HideRow(i);
				}
				else if (cell.Type == CellValueType.IsNumeric || cell.Type == CellValueType.IsDateTime)
				{
					num4++;
					double doubleValue = cell.DoubleValue;
					ArrayList arrayList = (ArrayList)sortedList[doubleValue];
					if (arrayList == null)
					{
						arrayList = new ArrayList();
						sortedList[doubleValue] = arrayList;
					}
					arrayList.Add(i);
				}
			}
			Top10Filter top10Filter = (Top10Filter)byIndex.Filter;
			bool isTop = top10Filter.IsTop;
			bool isPercent = top10Filter.IsPercent;
			int num5 = top10Filter.Items;
			if (isPercent)
			{
				num5 = num4 * num5 / 100;
			}
			if (!isTop)
			{
				IList valueList = sortedList.GetValueList();
				int num6 = 0;
				int num7 = 0;
				for (num7 = 0; num7 < sortedList.Count; num7++)
				{
					ArrayList arrayList2 = (ArrayList)valueList[num7];
					num6 += arrayList2.Count;
					if (num6 >= num5)
					{
						num7++;
						top10Filter.Criteria = cells.GetCell((int)arrayList2[0], num, bool_2: false).DoubleValue;
						break;
					}
				}
				for (; num7 < valueList.Count; num7++)
				{
					ArrayList arrayList3 = (ArrayList)valueList[num7];
					foreach (int item in arrayList3)
					{
						cells.HideRow(item);
					}
				}
				continue;
			}
			IList valueList2 = sortedList.GetValueList();
			int num8 = 0;
			int num9 = 0;
			num9 = sortedList.Count - 1;
			while (num9 >= 0)
			{
				ArrayList arrayList4 = (ArrayList)valueList2[num9];
				num8 += arrayList4.Count;
				if (num8 <= num5)
				{
					num9--;
					continue;
				}
				num9--;
				top10Filter.Criteria = cells.GetCell((int)arrayList4[0], num, bool_2: false).DoubleValue;
				break;
			}
			while (num9 >= 0)
			{
				ArrayList arrayList5 = (ArrayList)valueList2[num9];
				foreach (int item2 in arrayList5)
				{
					cells.HideRow(item2);
				}
				num9--;
			}
		}
		for (i = cellArea_0.StartRow + 1; i <= num2; i++)
		{
			int num10 = cells.Rows.method_5(i);
			if (num10 != -1)
			{
				Row rowByIndex2 = cells.Rows.GetRowByIndex(num10);
				if (rowByIndex2.IsHidden || rowByIndex2.InnerHeight == 0.0)
				{
					continue;
				}
			}
			for (int l = 0; l < filterColumnCollection_0.Count; l++)
			{
				FilterColumn byIndex2 = filterColumnCollection_0.GetByIndex(l);
				if (byIndex2.FilterType != FilterType.Top10)
				{
					num = startColumn + byIndex2.FieldIndex;
					Cell cell_ = cells.CheckCell(i, num);
					if (!byIndex2.method_9(cell_, i, num))
					{
						cells.HideRow(i);
						break;
					}
				}
			}
		}
		bool_0 = false;
	}

	[SpecialName]
	internal FilterColumnCollection method_5()
	{
		return filterColumnCollection_0;
	}

	[SpecialName]
	internal bool method_6()
	{
		if (filterColumnCollection_0 != null)
		{
			return filterColumnCollection_0.Count > 0;
		}
		return false;
	}

	[SpecialName]
	internal CellArea method_7()
	{
		return cellArea_0;
	}

	internal void InsertRow(int int_0, int int_1)
	{
		CellArea cellArea = cellArea_0;
		if (int_1 < 0 && cellArea.StartRow >= int_0 && cellArea.StartRow <= int_0 - int_1 - 1)
		{
			string_0 = null;
			ShowAll();
			return;
		}
		bool flag = false;
		cellArea = Class1678.InsertRows(cellArea, int_0, int_1, ref flag);
		if (flag)
		{
			string_0 = null;
			ShowAll();
		}
		else
		{
			cellArea_0 = cellArea;
			string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
		}
	}

	internal void InsertColumn(int int_0, int int_1)
	{
		CellArea cellArea = cellArea_0;
		if (int_1 > 0)
		{
			if (int_0 <= cellArea_0.StartColumn)
			{
				cellArea.StartColumn += int_1;
				cellArea.EndColumn += int_1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
			}
			else
			{
				if (int_0 > cellArea_0.EndColumn)
				{
					return;
				}
				cellArea.EndColumn += int_1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
				int num = int_0 - cellArea.StartColumn;
				for (int i = 0; i < filterColumnCollection_0.Count; i++)
				{
					FilterColumn byIndex = filterColumnCollection_0.GetByIndex(i);
					if (byIndex.FieldIndex >= num)
					{
						byIndex.FieldIndex += int_1;
					}
				}
			}
			return;
		}
		bool flag = false;
		int num2 = int_0 - int_1 - 1;
		if (int_0 <= cellArea_0.StartColumn)
		{
			if (num2 < cellArea_0.StartColumn)
			{
				cellArea.StartColumn += int_1;
				cellArea.EndColumn += int_1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
			}
			else if (num2 <= cellArea_0.EndColumn)
			{
				int num3 = num2 - cellArea.StartColumn;
				cellArea.StartColumn = int_0;
				cellArea.EndColumn += int_1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
				bool_0 = true;
				for (int j = 0; j < filterColumnCollection_0.Count; j++)
				{
					FilterColumn byIndex2 = filterColumnCollection_0.GetByIndex(j);
					if (byIndex2.FieldIndex <= num3)
					{
						filterColumnCollection_0.RemoveAt(j--);
						flag = true;
					}
					else
					{
						byIndex2.FieldIndex += int_1;
					}
				}
			}
			else
			{
				string_0 = null;
			}
		}
		else if (int_0 < cellArea_0.EndColumn)
		{
			if (num2 < cellArea_0.EndColumn)
			{
				int num4 = int_0 - cellArea.StartColumn;
				int num5 = num4 - int_1 - 1;
				cellArea.EndColumn += int_1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
				for (int k = 0; k < filterColumnCollection_0.Count; k++)
				{
					FilterColumn byIndex3 = filterColumnCollection_0.GetByIndex(k);
					if (byIndex3.FieldIndex >= num4)
					{
						if (byIndex3.FieldIndex <= num5)
						{
							filterColumnCollection_0.RemoveAt(k--);
						}
						else
						{
							byIndex3.FieldIndex += int_1;
						}
					}
				}
			}
			else
			{
				int num6 = int_0 - cellArea.StartColumn;
				cellArea.EndColumn += num2 - 1;
				cellArea_0 = cellArea;
				string_0 = CellsHelper.CellIndexToName(cellArea.StartRow, cellArea.StartColumn) + ":" + CellsHelper.CellIndexToName(cellArea.EndRow, cellArea.EndColumn);
				for (int l = 0; l < filterColumnCollection_0.Count; l++)
				{
					FilterColumn byIndex4 = filterColumnCollection_0.GetByIndex(l);
					if (byIndex4.FieldIndex >= num6)
					{
						filterColumnCollection_0.RemoveAt(l--);
					}
				}
			}
		}
		if (flag && filterColumnCollection_0.Count == 0)
		{
			ShowAll();
		}
	}

	private void method_8()
	{
		if (string_0 != null && !(string_0 == ""))
		{
			int row;
			int column;
			if (string_0.IndexOf(':') == -1)
			{
				try
				{
					CellsHelper.CellNameToIndex(string_0.Replace("$", ""), out row, out column);
					cellArea_0.StartColumn = column;
					cellArea_0.EndColumn = column;
					cellArea_0.StartRow = row;
					cellArea_0.EndRow = row;
					return;
				}
				catch (Exception)
				{
					throw new CellsException(ExceptionType.InvalidData, "Range of AutoFilter is not valid.");
				}
			}
			string[] array = string_0.Split(':');
			if (array.Length != 2)
			{
				throw new CellsException(ExceptionType.InvalidData, "Range of AutoFilter is not valid.");
			}
			try
			{
				CellsHelper.CellNameToIndex(array[0].Replace("$", ""), out row, out column);
				cellArea_0.StartColumn = column;
				cellArea_0.StartRow = row;
				CellsHelper.CellNameToIndex(array[1].Replace("$", ""), out row, out column);
				cellArea_0.EndColumn = column;
				cellArea_0.EndRow = row;
			}
			catch (Exception)
			{
				throw new CellsException(ExceptionType.InvalidData, "Range of AutoFilter is not valid.");
			}
			if (cellArea_0.StartRow > cellArea_0.EndRow)
			{
				if (cellArea_0.StartColumn >= cellArea_0.EndColumn)
				{
					row = cellArea_0.StartRow;
					cellArea_0.StartRow = cellArea_0.EndRow;
					cellArea_0.EndRow = row;
					column = cellArea_0.StartColumn;
					cellArea_0.StartColumn = cellArea_0.EndColumn;
					cellArea_0.EndColumn = column;
				}
				else
				{
					row = cellArea_0.StartRow;
					cellArea_0.StartRow = cellArea_0.EndRow;
					cellArea_0.EndRow = row;
				}
			}
			else if (cellArea_0.StartRow == cellArea_0.EndRow)
			{
				if (cellArea_0.StartColumn > cellArea_0.EndColumn)
				{
					column = cellArea_0.StartColumn;
					cellArea_0.StartColumn = cellArea_0.EndColumn;
					cellArea_0.EndColumn = column;
				}
			}
			else if (cellArea_0.StartColumn > cellArea_0.EndColumn)
			{
				column = cellArea_0.StartColumn;
				cellArea_0.StartColumn = cellArea_0.EndColumn;
				cellArea_0.EndColumn = column;
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Range of AutoFilter is not set.");
	}

	internal static string smethod_0(object object_1)
	{
		switch (Type.GetTypeCode(object_1.GetType()))
		{
		case TypeCode.Int32:
			return Class1618.smethod_80((int)object_1);
		case TypeCode.Boolean:
			if ((bool)object_1)
			{
				return "True";
			}
			return "False";
		case TypeCode.String:
			return object_1.ToString();
		default:
			return object_1.ToString();
		case TypeCode.Double:
			return Class1618.smethod_79((double)object_1);
		}
	}
}
