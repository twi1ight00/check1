using ns33;

namespace ns56;

internal class Class2385
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "v", "g", "s", "t", "w", "m");

	public static Enum218 smethod_0(string xmlValue)
	{
		return (Enum218)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum218 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
