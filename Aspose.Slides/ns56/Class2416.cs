using ns33;

namespace ns56;

internal class Class2416
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "today", "yesterday", "tomorrow", "last7Days", "thisMonth", "lastMonth", "nextMonth", "thisWeek", "lastWeek", "nextWeek");

	public static Enum249 smethod_0(string xmlValue)
	{
		return (Enum249)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum249 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
