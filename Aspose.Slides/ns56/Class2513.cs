using ns33;

namespace ns56;

internal class Class2513
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "topAndBottom", "square", "none", "tight", "through");

	public static Enum377 smethod_0(string xmlValue)
	{
		return (Enum377)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum377 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
