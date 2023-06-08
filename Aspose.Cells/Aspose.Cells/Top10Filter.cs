namespace Aspose.Cells;

/// <summary>
///       Represents the top 10 filter.
///       </summary>
public class Top10Filter
{
	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private object object_0;

	/// <summary>
	///       Indicates whether it's top filter.
	///       </summary>
	public bool IsTop
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
	///       Indicates whether the items is percent.
	///       </summary>
	public bool IsPercent
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
	///       Gets and sets the items of the filter.
	///       </summary>
	public int Items
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

	/// <summary>
	/// </summary>
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

	internal void Copy(Top10Filter top10Filter_0)
	{
		bool_0 = top10Filter_0.bool_0;
		bool_1 = top10Filter_0.bool_1;
		int_0 = top10Filter_0.int_0;
		object_0 = top10Filter_0.int_0;
	}

	internal Top10Filter()
	{
	}

	internal Top10Filter(bool bool_2, bool bool_3, int int_1)
	{
		bool_0 = bool_2;
		bool_1 = bool_3;
		int_0 = int_1;
	}
}
