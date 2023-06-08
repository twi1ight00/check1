using ns33;

namespace ns56;

internal class Class2393
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "prompt", "value", "cell");

	public static Enum226 smethod_0(string xmlValue)
	{
		return (Enum226)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum226 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
