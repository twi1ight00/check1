using ns33;

namespace ns56;

internal class Class2499
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "linear", "sigma", "any", "linear sigma");

	public static Enum363 smethod_0(string xmlValue)
	{
		return (Enum363)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum363 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
