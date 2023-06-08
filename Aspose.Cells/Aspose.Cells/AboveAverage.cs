namespace Aspose.Cells;

/// <summary>
///       Describe the AboveAverage conditional formatting rule. 
///       This conditional formatting rule highlights cells that
///       are above or below the average for all values in the range. 
///       </summary>
public class AboveAverage
{
	private bool bool_0 = true;

	private bool bool_1;

	private int int_0;

	/// <summary>
	///       Get or set the flag indicating whether the rule is an "above average" rule. 
	///       'true' indicates 'above average'.
	///       Default value is true.
	///       </summary>
	public bool IsAboveAverage
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
	///       Get or set the flag indicating whether the 'aboveAverage' and 'belowAverage' criteria 
	///       is inclusive of the average itself, or exclusive of that value. 
	///       'true' indicates to include the average value in the criteria.
	///       Default value is false.
	///       </summary>
	public bool IsEqualAverage
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (value)
			{
				int_0 = 0;
			}
		}
	}

	/// <summary>
	///       Get or set the number of standard deviations to include above or below the average in the
	///       conditional formatting rule. 
	///       The input value must between 0 and 3 (include 0 and 3). 
	///       Setting this value to 0 means stdDev is not set.
	///       The default value is 0.
	///       </summary>
	public int StdDev
	{
		get
		{
			return int_0;
		}
		set
		{
			switch (value)
			{
			case 1:
			case 2:
			case 3:
				if (value <= 3)
				{
					IsEqualAverage = false;
				}
				break;
			default:
				throw new CellsException(ExceptionType.DataValidation, "Please input a integer between 0 and 3");
			case 0:
				break;
			}
			int_0 = value;
		}
	}

	internal void Copy(AboveAverage aboveAverage_0)
	{
		bool_0 = aboveAverage_0.bool_0;
		bool_1 = aboveAverage_0.bool_1;
		int_0 = aboveAverage_0.int_0;
	}
}
