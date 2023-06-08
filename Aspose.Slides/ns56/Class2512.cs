using ns33;

namespace ns56;

internal class Class2512
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "both", "left", "right", "largest");

	public static Enum376 smethod_0(string xmlValue)
	{
		return (Enum376)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum376 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
