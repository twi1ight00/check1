using ns33;

namespace ns56;

internal class Class2419
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "single", "double", "singleAccounting", "doubleAccounting", "none");

	public static Enum252 smethod_0(string xmlValue)
	{
		return (Enum252)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum252 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
