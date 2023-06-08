using ns33;

namespace ns56;

internal class Class2478
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "rect", "segments", "custom");

	public static Enum342 smethod_0(string xmlValue)
	{
		return (Enum342)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum342 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
