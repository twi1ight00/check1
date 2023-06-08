using ns33;

namespace ns56;

internal class Class2477
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "straight", "elbow", "curved");

	public static Enum341 smethod_0(string xmlValue)
	{
		return (Enum341)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum341 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
