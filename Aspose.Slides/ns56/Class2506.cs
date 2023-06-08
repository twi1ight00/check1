using ns33;

namespace ns56;

internal class Class2506
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "t", "f", "true", "false", "");

	public static Enum370 smethod_0(string xmlValue)
	{
		return (Enum370)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum370 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
