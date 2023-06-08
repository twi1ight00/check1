using ns33;

namespace ns56;

internal class Class2494
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "allAtOnce", "series", "category", "seriesEl", "categoryEl");

	public static Enum358 smethod_0(string xmlValue)
	{
		return (Enum358)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum358 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
