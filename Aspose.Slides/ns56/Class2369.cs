using ns33;

namespace ns56;

internal class Class2369
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "null", "aboveAverage", "belowAverage", "tomorrow", "today", "yesterday", "nextWeek", "thisWeek", "lastWeek", "nextMonth", "thisMonth", "lastMonth", "nextQuarter", "thisQuarter", "lastQuarter", "nextYear", "thisYear", "lastYear", "yearToDate", "Q1", "Q2", "Q3", "Q4", "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8", "M9", "M10", "M11", "M12");

	public static Enum202 smethod_0(string xmlValue)
	{
		return (Enum202)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum202 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
