using ns33;

namespace ns56;

internal class Class2451
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "line", "lineMarker", "marker", "smooth", "smoothMarker");

	public static Enum323 smethod_0(string xmlValue)
	{
		return (Enum323)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum323 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
