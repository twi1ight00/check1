namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents PivotTable Filter type.
///       </summary>
public enum PivotFilterType
{
	/// <summary>
	///       Indicates the "begins with" filter for field captions.
	///       </summary>
	CaptionBeginsWith,
	/// <summary>
	///       Indicates the "is between" filter for field captions.
	///       </summary>
	CaptionBetween,
	/// <summary>
	///       Indicates the "contains" filter for field captions.
	///       </summary>
	CaptionContains,
	/// <summary>
	///       Indicates the "ends with" filter for field captions.
	///       </summary>
	CaptionEndsWith,
	/// <summary>
	///       Indicates the "equal" filter for field captions.
	///       </summary>
	CaptionEqual,
	/// <summary>
	///       Indicates the "is greater than" filter for field captions.
	///       </summary>
	CaptionGreaterThan,
	/// <summary>
	///       Indicates the "is greater than or equal to" filter for field captions.
	///       </summary>
	CaptionGreaterThanOrEqual,
	/// <summary>
	///       Indicates the "is less than" filter for field captions.
	///       </summary>
	CaptionLessThan,
	/// <summary>
	///       Indicates the "is less than or equal to" filter for field captions.
	///       </summary>
	CaptionLessThanOrEqual,
	/// <summary>
	///       Indicates the "does not begin with" filter for field captions.
	///       </summary>
	CaptionNotBeginsWith,
	/// <summary>
	///       Indicates the "is not between" filter for field captions.
	///       </summary>
	CaptionNotBetween,
	/// <summary>
	///       Indicates the "does not contain" filter for field captions.
	///       </summary>
	CaptionNotContains,
	/// <summary>
	///       Indicates the "does not end with" filter for field captions.
	///       </summary>
	CaptionNotEndsWith,
	/// <summary>
	///       Indicates the "not equal" filter for field captions.
	///       </summary>
	CaptionNotEqual,
	/// <summary>
	///       Indicates the "count" filter.
	///       </summary>
	Count,
	/// <summary>
	///       Indicates the "between" filter for date values.
	///       </summary>
	DateBetween,
	/// <summary>
	///       Indicates the "equals" filter for date values.
	///       </summary>
	DateEqual,
	/// <summary>
	///       Indicates the "newer than" filter for date values.
	///       </summary>
	DateNewerThan,
	/// <summary>
	///       Indicates the "newer than or equal to" filter for date values.
	///       </summary>
	DateNewerThanOrEqual,
	/// <summary>
	///       Indicates the "not between" filter for date values.
	///       </summary>
	DateNotBetween,
	/// <summary>
	///       Indicates the "does not equal" filter for date values.
	///       </summary>
	DateNotEqual,
	/// <summary>
	///       Indicates the "older than" filter for date values.
	///       </summary>
	DateOlderThan,
	/// <summary>
	///       Indicates the "older than or equal to" filter for date values.
	///       </summary>
	DateOlderThanOrEqual,
	/// <summary>
	///       Indicates the "last month" filter for date values.
	///       </summary>
	LastMonth,
	/// <summary>
	///       Indicates the "last quarter" filter for date values.
	///       </summary>
	LastQuarter,
	/// <summary>
	///       Indicates the "last week" filter for date values.
	///       </summary>
	LastWeek,
	/// <summary>
	///       Indicates the "last year" filter for date values.
	///       </summary>
	LastYear,
	/// <summary>
	///       Indicates the "January" filter for date values.
	///       </summary>
	M1,
	/// <summary>
	///       Indicates the "February" filter for date values.
	///       </summary>
	M2,
	/// <summary>
	///       Indicates the "March" filter for date values.
	///       </summary>
	M3,
	/// <summary>
	///       Indicates the "April" filter for date values.
	///       </summary>
	M4,
	/// <summary>
	///       Indicates the "May" filter for date values.
	///       </summary>
	M5,
	/// <summary>
	///       Indicates the "June" filter for date values.
	///       </summary>
	M6,
	/// <summary>
	///       Indicates the "July" filter for date values.
	///       </summary>
	M7,
	/// <summary>
	///       Indicates the "August" filter for date values.
	///       </summary>
	M8,
	/// <summary>
	///       Indicates the "September" filter for date values.
	///       </summary>
	M9,
	/// <summary>
	///       Indicates the "October" filter for date values.
	///       </summary>
	M10,
	/// <summary>
	///       Indicates the "November" filter for date values.
	///       </summary>
	M11,
	/// <summary>
	///       Indicates the "December" filter for date values.
	///       </summary>
	M12,
	/// <summary>
	///       Indicates the "next month" filter for date values.
	///       </summary>
	NextMonth,
	/// <summary>
	///       Indicates the "next quarter" for date values.
	///       </summary>
	NextQuarter,
	/// <summary>
	///       Indicates the "next week" for date values.
	///       </summary>
	NextWeek,
	/// <summary>
	///       Indicates the "next year" filter for date values.
	///       </summary>
	NextYear,
	/// <summary>
	///       Indicates the "percent" filter for numeric values.
	///       </summary>
	Percent,
	/// <summary>
	///       Indicates the "first quarter" filter for date values.
	///       </summary>
	Q1,
	/// <summary>
	///       Indicates the "second quarter" filter for date values.
	///       </summary>
	Q2,
	/// <summary>
	///       Indicates the "third quarter" filter for date values.
	///       </summary>
	Q3,
	/// <summary>
	///       Indicates the "fourth quarter" filter for date values.
	///       </summary>
	Q4,
	/// <summary>
	///       Indicates the "sum" filter for numeric values.
	///       </summary>
	Sum,
	/// <summary>
	///       Indicates the "this month" filter for date values.
	///       </summary>
	ThisMonth,
	/// <summary>
	///       Indicates the "this quarter" filter for date values.
	///       </summary>
	ThisQuarter,
	/// <summary>
	///       Indicates the "this week" filter for date values.
	///       </summary>
	ThisWeek,
	/// <summary>
	///       Indicate the "this year" filter for date values.
	///       </summary>
	ThisYear,
	/// <summary>
	///       Indicates the "today" filter for date values.
	///       </summary>
	Today,
	/// <summary>
	///       Indicates the "tomorrow" filter for date values.
	///       </summary>
	Tomorrow,
	/// <summary>
	///       Indicates the PivotTable filter is unknown to the application.
	///       </summary>
	Unknown,
	/// <summary>
	///       Indicates the "Value between" filter for text and numeric values.
	///       </summary>
	ValueBetween,
	/// <summary>
	///       Indicates the "value equal" filter for text and numeric values.
	///       </summary>
	ValueEqual,
	/// <summary>
	///       Indicates the "value greater than" filter for text and numeric values.
	///       </summary>
	ValueGreaterThan,
	/// <summary>
	///       Indicates the "value greater than or equal to" filter for text and numeric values.
	///       </summary>
	ValueGreaterThanOrEqual,
	/// <summary>
	///       Indicates the "value less than" filter for text and numeric values.
	///       </summary>
	ValueLessThan,
	/// <summary>
	///       Indicates the "value less than or equal to" filter for text and numeric values.
	///       </summary>
	ValueLessThanOrEqual,
	/// <summary>
	///       Indicates the "value not between" filter for text and numeric values.
	///       </summary>
	ValueNotBetween,
	/// <summary>
	///       Indicates the "value not equal" filter for text and numeric values.
	///       </summary>
	ValueNotEqual,
	/// <summary>
	///       Indicates the "year-to-date" filter for date values.
	///       </summary>
	YearToDate,
	/// <summary>
	///       Indicates the "yesterday" filter for date values.
	///       </summary>
	Yesterday
}
