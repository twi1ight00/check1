using ns33;

namespace ns56;

internal class Class2410
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "stroke", "pinYin", "none");

	public static Enum243 smethod_0(string xmlValue)
	{
		return (Enum243)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum243 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
