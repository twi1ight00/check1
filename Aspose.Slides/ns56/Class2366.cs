using ns33;

namespace ns56;

internal class Class2366
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "year", "month", "day", "hour", "minute", "second");

	public static Enum199 smethod_0(string xmlValue)
	{
		return (Enum199)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum199 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
