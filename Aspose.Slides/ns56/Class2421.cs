using ns33;

namespace ns56;

internal class Class2421
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "top", "center", "bottom", "justify", "distributed");

	public static Enum254 smethod_0(string xmlValue)
	{
		return (Enum254)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum254 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
