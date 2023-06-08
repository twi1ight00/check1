using ns33;

namespace ns56;

internal class Class2447
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "inner", "outer");

	public static Enum319 smethod_0(string xmlValue)
	{
		return (Enum319)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum319 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
