using ns33;

namespace ns56;

internal class Class2360
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "integrated", "none", "stored", "prompt");

	public static Enum193 smethod_0(string xmlValue)
	{
		return (Enum193)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum193 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
