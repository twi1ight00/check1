using ns33;

namespace ns56;

internal class Class2381
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "rtf", "all");

	public static Enum214 smethod_0(string xmlValue)
	{
		return (Enum214)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum214 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
