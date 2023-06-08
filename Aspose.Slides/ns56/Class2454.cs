using ns33;

namespace ns56;

internal class Class2454
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "lvl", "ctr");

	public static Enum324 smethod_0(string xmlValue)
	{
		return (Enum324)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum324 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
