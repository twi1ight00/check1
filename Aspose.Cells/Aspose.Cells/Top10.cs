namespace Aspose.Cells;

/// <summary>
///       Describe the Top10 conditional formatting rule. 
///       This conditional formatting rule highlights cells whose
///       values fall in the top N or bottom N bracket, as specified.
///       </summary>
public class Top10
{
	private bool bool_0;

	private bool bool_1;

	private int int_0 = 10;

	/// <summary>
	///       Get or set the flag indicating whether a "top/bottom n" rule is a "top/bottom n percent" rule.
	///       Default value is false.
	///       </summary>
	public bool IsPercent
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
	///       Get or set the flag indicating whether a "top/bottom n" rule is a "bottom n" rule. '1' indicates 'bottom'.
	///       Default value is false.
	///       </summary>
	public bool IsBottom
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
	///       Get or set the value of "n" in a "top/bottom n" conditional formatting rule.
	///       If IsPercent is true, the value must between 0 and 100.
	///       Otherwise it must between 0 and 1000.
	///       Default value is 10.
	///       </summary>
	public int Rank
	{
		get
		{
			return int_0;
		}
		set
		{
			if (bool_0)
			{
				if (value < 0 || value > 100)
				{
					return;
				}
			}
			else if (value <= 0 || value > 1000)
			{
				return;
			}
			int_0 = value;
		}
	}

	internal void Copy(Top10 top10_0)
	{
		bool_0 = top10_0.bool_0;
		bool_1 = top10_0.bool_1;
		int_0 = top10_0.int_0;
	}
}
