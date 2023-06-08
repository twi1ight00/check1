using ns33;

namespace ns56;

internal class Class2502
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "single", "double", "emboss", "perspective");

	public static Enum366 smethod_0(string xmlValue)
	{
		return (Enum366)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum366 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
