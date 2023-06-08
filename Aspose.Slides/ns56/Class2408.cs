using ns33;

namespace ns56;

internal class Class2408
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "all", "none", "noIndicator");

	public static Enum241 smethod_0(string xmlValue)
	{
		return (Enum241)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum241 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
