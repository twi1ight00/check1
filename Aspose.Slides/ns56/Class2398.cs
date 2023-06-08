using ns33;

namespace ns56;

internal class Class2398
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "unknown", "count", "percent", "sum", "captionEqual", "captionNotEqual", "captionBeginsWith", "captionNotBeginsWith", "captionEndsWith", "captionNotEndsWith", "captionContains", "captionNotContains", "captionGreaterThan", "captionGreaterThanOrEqual", "captionLessThan", "captionLessThanOrEqual", "captionBetween", "captionNotBetween", "valueEqual", "valueNotEqual", "valueGreaterThan", "valueGreaterThanOrEqual", "valueLessThan", "valueLessThanOrEqual", "valueBetween", "valueNotBetween", "dateEqual", "dateNotEqual", "dateOlderThan", "dateOlderThanOrEqual", "dateNewerThan", "dateNewerThanOrEqual", "dateBetween", "dateNotBetween", "tomorrow", "today", "yesterday", "nextWeek", "thisWeek", "lastWeek", "nextMonth", "thisMonth", "lastMonth", "nextQuarter", "thisQuarter", "lastQuarter", "nextYear", "thisYear", "lastYear", "yearToDate", "Q1", "Q2", "Q3", "Q4", "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8", "M9", "M10", "M11", "M12");

	public static Enum231 smethod_0(string xmlValue)
	{
		return (Enum231)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum231 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
