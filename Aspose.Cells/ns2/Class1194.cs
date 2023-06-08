using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1194
{
	internal int int_0;

	internal ushort ushort_0;

	internal FilterOperatorType filterOperatorType_0 = FilterOperatorType.None;

	internal FilterOperatorType filterOperatorType_1 = FilterOperatorType.None;

	internal object object_0;

	internal object object_1;

	internal Class1194(int int_1)
	{
		int_0 = int_1;
	}

	internal void method_0(out bool isTop, out bool isPercent, out int items)
	{
		isTop = (ushort_0 & 0x20) != 0;
		isPercent = (ushort_0 & 0x40) != 0;
		items = (ushort_0 & 0xFF80) >> 7;
	}

	[SpecialName]
	internal bool method_1()
	{
		return (ushort_0 & 1) == 0;
	}

	[SpecialName]
	internal bool method_2()
	{
		return (ushort_0 & 4) != 0;
	}

	[SpecialName]
	internal bool method_3()
	{
		return (ushort_0 & 8) != 0;
	}

	internal FilterColumn method_4(FilterColumnCollection filterColumnCollection_0)
	{
		FilterColumn filterColumn = new FilterColumn(filterColumnCollection_0, int_0);
		if (method_5())
		{
			method_0(out var isTop, out var isPercent, out var items);
			Top10Filter top10Filter = new Top10Filter(isTop, isPercent, items);
			filterColumn.FilterType = FilterType.Top10;
			filterColumn.Filter = top10Filter;
			top10Filter.Criteria = object_1;
			return filterColumn;
		}
		if (object_1 == null)
		{
			switch (filterOperatorType_0)
			{
			case FilterOperatorType.Equal:
				filterColumn.MatchBlanks();
				break;
			case FilterOperatorType.NotEqual:
				filterColumn.MatchNonBlanks();
				break;
			}
			return filterColumn;
		}
		if (filterOperatorType_1 == FilterOperatorType.None)
		{
			if (method_2())
			{
				filterColumn.AddFilter(object_1.ToString());
			}
			else
			{
				filterColumn.Custom(filterOperatorType_0, object_1, bool_2: false, FilterOperatorType.None, null);
			}
		}
		else if (method_2() && method_3())
		{
			filterColumn.AddFilter(object_1.ToString());
			if (object_0 != null)
			{
				filterColumn.AddFilter(object_0.ToString());
			}
		}
		else
		{
			filterColumn.Custom(filterOperatorType_0, object_1, method_1(), filterOperatorType_1, object_0);
		}
		return filterColumn;
	}

	internal Class1194(FilterColumn filterColumn_0)
	{
		int_0 = filterColumn_0.FieldIndex;
		switch (filterColumn_0.FilterType)
		{
		case FilterType.CustomFilters:
		{
			CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn_0.Filter;
			if (!customFilterCollection.And)
			{
				ushort_0 |= 1;
			}
			if (customFilterCollection.Count > 0)
			{
				CustomFilter customFilter = customFilterCollection[0];
				filterOperatorType_0 = customFilter.FilterOperatorType;
				object_1 = customFilter.Criteria;
			}
			if (customFilterCollection.Count > 1)
			{
				CustomFilter customFilter2 = customFilterCollection[1];
				filterOperatorType_1 = customFilter2.FilterOperatorType;
				object_0 = customFilter2.Criteria;
			}
			break;
		}
		case FilterType.MultipleFilters:
		{
			MultipleFilterCollection multipleFilterCollection = (MultipleFilterCollection)filterColumn_0.Filter;
			if (multipleFilterCollection.MatchBlank)
			{
				filterOperatorType_0 = FilterOperatorType.Equal;
				break;
			}
			if (multipleFilterCollection.Count > 0)
			{
				object obj = multipleFilterCollection[0];
				if (obj is DateTimeGroupItem)
				{
					DateTimeGroupItem dateTimeGroupItem = (DateTimeGroupItem)obj;
					filterOperatorType_0 = FilterOperatorType.GreaterOrEqual;
					object_1 = CellsHelper.GetDoubleFromDateTime(dateTimeGroupItem.MinValue, filterColumn_0.method_4().AutoFilter.method_0().method_2().Workbook.Settings.Date1904);
				}
				else
				{
					filterOperatorType_0 = FilterOperatorType.Equal;
					object_1 = obj;
					if (obj is string)
					{
						ushort_0 |= 4;
					}
				}
			}
			if (multipleFilterCollection.Count <= 1)
			{
				break;
			}
			ushort_0 |= 1;
			object obj2 = multipleFilterCollection[1];
			if (obj2 is DateTimeGroupItem)
			{
				DateTimeGroupItem dateTimeGroupItem2 = (DateTimeGroupItem)obj2;
				filterOperatorType_1 = FilterOperatorType.GreaterOrEqual;
				object_0 = CellsHelper.GetDoubleFromDateTime(dateTimeGroupItem2.MinValue, filterColumn_0.method_4().AutoFilter.method_0().method_2().Workbook.Settings.Date1904);
				break;
			}
			filterOperatorType_1 = FilterOperatorType.Equal;
			object_0 = obj2;
			if (obj2 is string)
			{
				ushort_0 |= 8;
			}
			break;
		}
		case FilterType.DynamicFilter:
		case FilterType.IconFilter:
			break;
		case FilterType.Top10:
		{
			Top10Filter top10Filter = (Top10Filter)filterColumn_0.Filter;
			ushort_0 = 16;
			if (top10Filter.IsTop)
			{
				ushort_0 |= 32;
				filterOperatorType_0 = FilterOperatorType.GreaterOrEqual;
			}
			else
			{
				filterOperatorType_0 = FilterOperatorType.LessOrEqual;
			}
			if (top10Filter.IsPercent)
			{
				ushort_0 |= 64;
			}
			ushort_0 |= (ushort)(top10Filter.Items << 7);
			object_1 = top10Filter.Criteria;
			break;
		}
		}
	}

	[SpecialName]
	internal bool method_5()
	{
		return (ushort_0 & 0x10) != 0;
	}
}
