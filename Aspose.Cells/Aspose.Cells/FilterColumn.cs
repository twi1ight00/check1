using System.Runtime.CompilerServices;

namespace Aspose.Cells;

/// <summary>
///       Represents a filter for a single column. The Filter object is a member of the Filters collection
///       </summary>
public class FilterColumn
{
	private FilterType filterType_0 = FilterType.None;

	private object object_0;

	private bool bool_0;

	private bool bool_1 = true;

	private int int_0;

	private FilterColumnCollection filterColumnCollection_0;

	/// <summary>
	///       Indicates whether the AutoFilter button for this column is visible. 
	///       </summary>
	public bool Visibledropdown
	{
		get
		{
			if (!bool_0)
			{
				return bool_1;
			}
			return false;
		}
		set
		{
			bool_0 = !value;
			bool_1 = value;
		}
	}

	/// <summary>
	/// </summary>
	public object Filter
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	/// <summary>
	/// </summary>
	public FilterType FilterType
	{
		get
		{
			return filterType_0;
		}
		set
		{
			filterType_0 = value;
		}
	}

	/// <summary>
	/// </summary>
	public int FieldIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_1(bool bool_2)
	{
		bool_0 = bool_2;
	}

	[SpecialName]
	internal bool method_2()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_3(bool bool_2)
	{
		bool_1 = bool_2;
	}

	[SpecialName]
	internal FilterColumnCollection method_4()
	{
		return filterColumnCollection_0;
	}

	internal FilterColumn(FilterColumnCollection filterColumnCollection_1, int int_1)
	{
		int_0 = int_1;
		filterColumnCollection_0 = filterColumnCollection_1;
	}

	internal FilterColumn(FilterColumnCollection filterColumnCollection_1, int int_1, bool bool_2, bool bool_3)
	{
		int_0 = int_1;
		filterColumnCollection_0 = filterColumnCollection_1;
		bool_0 = bool_2;
		bool_1 = bool_3;
	}

	internal void Copy(FilterColumn filterColumn_0)
	{
		filterType_0 = filterColumn_0.filterType_0;
		bool_0 = filterColumn_0.bool_0;
		bool_1 = filterColumn_0.bool_1;
		switch (filterType_0)
		{
		case FilterType.ColorFilter:
		{
			ColorFilter colorFilter_ = (ColorFilter)filterColumn_0.object_0;
			((ColorFilter)(object_0 = new ColorFilter(this))).Copy(colorFilter_, bool_1: true);
			break;
		}
		case FilterType.CustomFilters:
		{
			CustomFilterCollection customFilterCollection_ = (CustomFilterCollection)filterColumn_0.object_0;
			((CustomFilterCollection)(object_0 = new CustomFilterCollection())).Copy(customFilterCollection_);
			break;
		}
		case FilterType.DynamicFilter:
		{
			DynamicFilter dynamicFilter_ = (DynamicFilter)filterColumn_0.object_0;
			((DynamicFilter)(object_0 = new DynamicFilter())).Copy(dynamicFilter_);
			break;
		}
		case FilterType.MultipleFilters:
		{
			MultipleFilterCollection multipleFilterCollection_ = (MultipleFilterCollection)filterColumn_0.object_0;
			((MultipleFilterCollection)(object_0 = new MultipleFilterCollection())).Copy(multipleFilterCollection_);
			break;
		}
		case FilterType.IconFilter:
		{
			IconFilter iconFilter_ = (IconFilter)filterColumn_0.object_0;
			((IconFilter)(object_0 = new IconFilter(this))).Copy(iconFilter_);
			break;
		}
		case FilterType.Top10:
		{
			Top10Filter top10Filter_ = (Top10Filter)filterColumn_0.object_0;
			((Top10Filter)(object_0 = new Top10Filter())).Copy(top10Filter_);
			break;
		}
		}
	}

	private static bool smethod_0(string string_0)
	{
		if (string_0.IndexOf('?') == -1 && string_0.IndexOf('*') == -1)
		{
			return true;
		}
		return false;
	}

	internal void RemoveFilter(string string_0)
	{
		if (filterType_0 == FilterType.MultipleFilters)
		{
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
			if (string_0 == null)
			{
				multipleFilterCollection.MatchBlank = true;
			}
			else
			{
				multipleFilterCollection.RemoveFilter(string_0);
			}
		}
	}

	internal void RemoveDateFilter(int int_1, DateTimeGroupingType dateTimeGroupingType_0, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
	{
		if (filterType_0 == FilterType.MultipleFilters)
		{
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
			multipleFilterCollection.RemoveDateFilter(dateTimeGroupingType_0, int_2, int_3, int_4, int_5, int_6, int_7);
		}
	}

	internal void AddDateFilter(int int_1, DateTimeGroupingType dateTimeGroupingType_0, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
	{
		if (filterType_0 != FilterType.MultipleFilters)
		{
			filterType_0 = FilterType.MultipleFilters;
			object_0 = new MultipleFilterCollection();
		}
		MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
		DateTimeGroupItem dateTimeGroupItem_ = new DateTimeGroupItem(dateTimeGroupingType_0, int_2, int_3, int_4, int_5, int_6, int_7);
		multipleFilterCollection.Add(dateTimeGroupItem_);
	}

	internal void AddIconFilter(IconSetType iconSetType_0, int int_1)
	{
		IconFilter iconFilter = new IconFilter(this);
		iconFilter.IconSetType = iconSetType_0;
		iconFilter.IconId = int_1;
		object_0 = iconFilter;
		filterType_0 = FilterType.IconFilter;
	}

	internal void method_5(CellsColor cellsColor_0)
	{
		AutoFilter autoFilter = filterColumnCollection_0.AutoFilter;
		Worksheet worksheet = autoFilter.method_0();
		ColorFilter colorFilter = (ColorFilter)(object_0 = new ColorFilter(this));
		filterType_0 = FilterType.ColorFilter;
		colorFilter.FilterByFillColor = false;
		Style style = new Style(worksheet.method_2());
		style.Pattern = BackgroundType.Solid;
		style.ForeInternalColor = cellsColor_0.internalColor_0;
		if (!cellsColor_0.internalColor_0.method_2())
		{
			style.method_36(StyleModifyFlag.ForegroundColor);
		}
		colorFilter.method_2(worksheet.method_2().method_56().Add(style));
	}

	internal void method_6(BackgroundType backgroundType_0, CellsColor cellsColor_0, CellsColor cellsColor_1)
	{
		ColorFilter colorFilter = new ColorFilter(this);
		colorFilter.FilterByFillColor = true;
		object_0 = colorFilter;
		filterType_0 = FilterType.ColorFilter;
		AutoFilter autoFilter = filterColumnCollection_0.AutoFilter;
		Worksheet worksheet = autoFilter.method_0();
		Style style = new Style(worksheet.method_2());
		switch (backgroundType_0)
		{
		case BackgroundType.None:
			style.Pattern = backgroundType_0;
			style.ForeInternalColor.SetColor(ColorType.AutomaticIndex, 100);
			style.BackgroundInternalColor.SetColor(ColorType.AutomaticIndex, 101);
			break;
		case BackgroundType.Solid:
			style.Pattern = backgroundType_0;
			style.ForeInternalColor = cellsColor_0.internalColor_0;
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.BackgroundInternalColor.SetColor(ColorType.RGB, 0);
			break;
		default:
			style.Pattern = backgroundType_0;
			style.ForeInternalColor = cellsColor_0.internalColor_0;
			style.method_36(StyleModifyFlag.ForegroundColor);
			style.BackgroundInternalColor = cellsColor_1.internalColor_0;
			style.method_36(StyleModifyFlag.BackgroundColor);
			break;
		}
		colorFilter.method_2(worksheet.method_2().method_56().Add(style));
	}

	internal void AddFilter(string string_0)
	{
		if (filterType_0 != FilterType.MultipleFilters)
		{
			filterType_0 = FilterType.MultipleFilters;
			object_0 = new MultipleFilterCollection();
		}
		MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
		if (string_0 == null)
		{
			multipleFilterCollection.MatchBlank = true;
		}
		else
		{
			multipleFilterCollection.Add(string_0);
		}
	}

	internal void method_7(string string_0)
	{
		if (smethod_0(string_0))
		{
			filterType_0 = FilterType.MultipleFilters;
			object_0 = new MultipleFilterCollection();
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
			multipleFilterCollection.Add(string_0);
		}
		else
		{
			Custom(FilterOperatorType.Equal, string_0, bool_2: false, FilterOperatorType.None, null);
		}
	}

	internal void MatchBlanks()
	{
		if (filterType_0 != FilterType.MultipleFilters)
		{
			filterType_0 = FilterType.MultipleFilters;
			object_0 = new MultipleFilterCollection();
		}
		MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)object_0;
		multipleFilterCollection.MatchBlank = true;
	}

	internal void MatchNonBlanks()
	{
		filterType_0 = FilterType.CustomFilters;
		CustomFilterCollection customFilterCollection = new CustomFilterCollection();
		customFilterCollection.And = false;
		object_0 = customFilterCollection;
		CustomFilter customFilter = new CustomFilter();
		customFilter.FilterOperatorType = FilterOperatorType.NotEqual;
		customFilter.Criteria = null;
		customFilterCollection.Add(customFilter);
	}

	internal void Custom(FilterOperatorType filterOperatorType_0, object object_1, bool bool_2, FilterOperatorType filterOperatorType_1, object object_2)
	{
		filterType_0 = FilterType.CustomFilters;
		CustomFilterCollection customFilterCollection = new CustomFilterCollection();
		customFilterCollection.And = bool_2;
		object_0 = customFilterCollection;
		CustomFilter customFilter = new CustomFilter();
		customFilter.FilterOperatorType = filterOperatorType_0;
		customFilter.Criteria = object_1;
		customFilterCollection.Add(customFilter);
		if (filterOperatorType_1 != FilterOperatorType.None)
		{
			CustomFilter customFilter2 = new CustomFilter();
			customFilter2.FilterOperatorType = filterOperatorType_1;
			customFilter2.Criteria = object_2;
			customFilterCollection.Add(customFilter2);
		}
	}

	internal void DynamicFilter(DynamicFilterType dynamicFilterType_0)
	{
		DynamicFilter dynamicFilter = new DynamicFilter();
		dynamicFilter.DynamicFilterType = dynamicFilterType_0;
		filterType_0 = FilterType.DynamicFilter;
		object_0 = dynamicFilter;
	}

	internal void FilterTop10(bool bool_2, bool bool_3, int int_1)
	{
		Top10Filter top10Filter = new Top10Filter(bool_2, bool_3, int_1);
		object_0 = top10Filter;
		filterType_0 = FilterType.Top10;
	}

	internal bool method_8(object object_1)
	{
		switch (FilterType)
		{
		case FilterType.CustomFilters:
			return ((CustomFilterCollection)object_0).method_0(object_1, filterColumnCollection_0.AutoFilter.method_0().method_2().Workbook.Settings.Date1904);
		case FilterType.ColorFilter:
		case FilterType.DynamicFilter:
			return ((DynamicFilter)object_0).method_1(object_1, filterColumnCollection_0.AutoFilter.method_0().method_2().Workbook.Settings.Date1904);
		case FilterType.MultipleFilters:
			return ((MultipleFilterCollection)object_0).method_1(object_1);
		default:
			return true;
		case FilterType.Top10:
			return true;
		}
	}

	internal bool method_9(Cell cell_0, int int_1, int int_2)
	{
		return FilterType switch
		{
			FilterType.ColorFilter => ((ColorFilter)object_0).method_0(cell_0, int_1, int_2), 
			FilterType.CustomFilters => ((CustomFilterCollection)object_0).method_2(cell_0, filterColumnCollection_0.AutoFilter.method_0().method_2().Workbook.Settings.Date1904), 
			FilterType.DynamicFilter => ((DynamicFilter)object_0).method_2(cell_0, filterColumnCollection_0.AutoFilter.method_0().method_2().Workbook.Settings.Date1904), 
			FilterType.MultipleFilters => ((MultipleFilterCollection)object_0).method_0(cell_0), 
			FilterType.IconFilter => ((IconFilter)object_0).method_0(cell_0), 
			FilterType.Top10 => true, 
			_ => true, 
		};
	}
}
