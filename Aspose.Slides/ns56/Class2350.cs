using ns33;

namespace ns56;

internal class Class2350
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "thin", "medium", "dashed", "dotted", "thick", "double", "hair", "mediumDashed", "dashDot", "mediumDashDot", "dashDotDot", "mediumDashDotDot", "slantDashDot");

	public static Enum184 smethod_0(string xmlValue)
	{
		return (Enum184)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum184 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
