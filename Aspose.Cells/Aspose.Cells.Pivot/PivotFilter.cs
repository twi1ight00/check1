using ns16;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Summary description for PivotFilter.
///       </summary>
public class PivotFilter
{
	internal int int_0;

	internal PivotFilterType pivotFilterType_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal AutoFilter autoFilter_0;

	internal string string_0;

	internal string string_1;

	internal int int_4;

	internal string string_2;

	/// <summary>
	///       Gets the autofilter of the pivot filter.
	///       </summary>
	public AutoFilter AutoFilter => autoFilter_0;

	/// <summary>
	///       Gets the autofilter type of the pivot filter.
	///       </summary>
	public PivotFilterType FilterType => pivotFilterType_0;

	/// <summary>
	///       Gets the field index of the pivot filter.
	///       </summary>
	public int FieldIndex => int_0;

	/// <summary>
	///       Gets the string value1 of the label pivot filter.
	///       </summary>
	public string Value1
	{
		get
		{
			AutoFilter autoFilter = AutoFilter;
			if (autoFilter != null)
			{
				FilterColumnCollection filterColumnCollection = autoFilter.method_5();
				FilterColumn filterColumn = filterColumnCollection[0];
				switch (filterColumn.FilterType)
				{
				case Aspose.Cells.FilterType.Top10:
				{
					Top10Filter top10Filter = (Top10Filter)filterColumn.Filter;
					return Class1618.smethod_80(top10Filter.Items);
				}
				default:
					return string_0;
				case Aspose.Cells.FilterType.CustomFilters:
				{
					CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn.Filter;
					CustomFilter customFilter = customFilterCollection[0];
					return customFilter.Criteria.ToString();
				}
				}
			}
			return string_0;
		}
		set
		{
			AutoFilter autoFilter = AutoFilter;
			if (autoFilter != null)
			{
				FilterColumnCollection filterColumnCollection = autoFilter.method_5();
				FilterColumn filterColumn = filterColumnCollection[0];
				switch (filterColumn.FilterType)
				{
				case Aspose.Cells.FilterType.Top10:
				{
					Top10Filter top10Filter = (Top10Filter)filterColumn.Filter;
					top10Filter.Items = Class1618.smethod_87(value);
					break;
				}
				default:
					string_0 = value;
					break;
				case Aspose.Cells.FilterType.CustomFilters:
				{
					CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn.Filter;
					CustomFilter customFilter = customFilterCollection[0];
					customFilter.Criteria = value;
					break;
				}
				}
			}
			string_0 = value;
		}
	}

	/// <summary>
	///       Gets the string value2 of the label pivot filter.
	///       </summary>
	public string Value2
	{
		get
		{
			AutoFilter autoFilter = AutoFilter;
			if (autoFilter != null)
			{
				FilterColumnCollection filterColumnCollection = autoFilter.method_5();
				FilterColumn filterColumn = filterColumnCollection[0];
				FilterType filterType = filterColumn.FilterType;
				if (filterType == Aspose.Cells.FilterType.CustomFilters)
				{
					CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn.Filter;
					if (customFilterCollection.Count > 1)
					{
						CustomFilter customFilter = customFilterCollection[1];
						return customFilter.Criteria.ToString();
					}
					return string_1;
				}
				return string_1;
			}
			return string_1;
		}
		set
		{
			AutoFilter autoFilter = AutoFilter;
			if (autoFilter != null)
			{
				FilterColumnCollection filterColumnCollection = autoFilter.method_5();
				FilterColumn filterColumn = filterColumnCollection[0];
				switch (filterColumn.FilterType)
				{
				case Aspose.Cells.FilterType.Top10:
				{
					Top10Filter top10Filter = (Top10Filter)filterColumn.Filter;
					top10Filter.Items = Class1618.smethod_87(value);
					break;
				}
				default:
					string_1 = value;
					break;
				case Aspose.Cells.FilterType.CustomFilters:
				{
					CustomFilterCollection customFilterCollection = (CustomFilterCollection)filterColumn.Filter;
					if (customFilterCollection.Count > 1)
					{
						CustomFilter customFilter = customFilterCollection[1];
						customFilter.Criteria = value;
					}
					else
					{
						string_1 = value;
					}
					break;
				}
				}
			}
			string_1 = value;
		}
	}

	/// <summary>
	///       Gets the measure field index of the pivot filter.
	///       </summary>
	public int MeasureFldIndex
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	/// <summary>
	///       Gets the member property field index of the pivot filter.
	///       </summary>
	public int MemberPropertyFieldIndex
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	/// <summary>
	///       Gets the name of the pivot filter.
	///       </summary>
	public string Name
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	/// <summary>
	///       Gets the Evaluation Order of the pivot filter.
	///       </summary>
	public int EvaluationOrder
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	internal PivotFilter(Worksheet worksheet_0)
	{
		int_3 = -1;
		int_4 = -1;
		autoFilter_0 = new AutoFilter(worksheet_0, this);
		autoFilter_0.Range = "A1";
	}
}
