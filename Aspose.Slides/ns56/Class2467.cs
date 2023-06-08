using ns33;

namespace ns56;

internal class Class2467
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "cw", "ccw");

	public static Enum336 smethod_0(string xmlValue)
	{
		return (Enum336)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum336 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
