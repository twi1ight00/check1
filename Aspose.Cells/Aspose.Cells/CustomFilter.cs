namespace Aspose.Cells;

/// <summary>
///       Represents the custom filter.
///       </summary>
public class CustomFilter
{
	private FilterOperatorType filterOperatorType_0 = FilterOperatorType.None;

	private object object_0;

	/// <summary>
	///       Gets and sets the filter operator type.
	///       </summary>
	public FilterOperatorType FilterOperatorType
	{
		get
		{
			return filterOperatorType_0;
		}
		set
		{
			filterOperatorType_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the criteria.
	///       </summary>
	public object Criteria
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

	internal void Copy(CustomFilter customFilter_0)
	{
		filterOperatorType_0 = customFilter_0.filterOperatorType_0;
		object_0 = customFilter_0.object_0;
	}
}
