using ns33;

namespace ns56;

internal class Class2372
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "mac", "win", "dos");

	public static Enum205 smethod_0(string xmlValue)
	{
		return (Enum205)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum205 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
