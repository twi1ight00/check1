namespace Aspose.Cells;

/// <summary>
///       Used in a FormatConditionType.TimePeriod conditional formatting rule. 
///       These are dynamic time periods, which change based on
///       the date the conditional formatting is refreshed / applied.
///       </summary>
public enum TimePeriodType
{
	/// <summary>
	///       Today's date.
	///       </summary>
	Today,
	/// <summary>
	///       Yesterday's date.
	///       </summary>
	Yesterday,
	/// <summary>
	///       Tomorrow's date.
	///       </summary>
	Tomorrow,
	/// <summary>
	///       A date in the last seven days.
	///       </summary>
	Last7Days,
	/// <summary>
	///       A date occuring in this calendar month.
	///       </summary>
	ThisMonth,
	/// <summary>
	///       A date occuring in the last calendar month.
	///       </summary>
	LastMonth,
	/// <summary>
	///       A date occuring in the next calendar month.
	///       </summary>
	NextMonth,
	/// <summary>
	///       A date occuring this week.
	///       </summary>
	ThisWeek,
	/// <summary>
	///       A date occuring last week.
	///       </summary>
	LastWeek,
	/// <summary>
	///       A date occuring next week.
	///       </summary>
	NextWeek
}
