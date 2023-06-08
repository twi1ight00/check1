using ns33;

namespace ns56;

internal class Class2479
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "XY", "ZX", "YZ");

	public static Enum343 smethod_0(string xmlValue)
	{
		return (Enum343)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum343 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
