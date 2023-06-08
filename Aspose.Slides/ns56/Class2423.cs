using ns33;

namespace ns56;

internal class Class2423
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "visible", "hidden", "veryHidden");

	public static Enum256 smethod_0(string xmlValue)
	{
		return (Enum256)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum256 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
