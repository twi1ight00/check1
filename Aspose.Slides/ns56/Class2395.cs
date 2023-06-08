using ns33;

namespace ns56;

internal class Class2395
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "noControl", "left", "center", "distributed");

	public static Enum228 smethod_0(string xmlValue)
	{
		return (Enum228)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum228 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
