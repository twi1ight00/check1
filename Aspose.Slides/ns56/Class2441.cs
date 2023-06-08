using ns33;

namespace ns56;

internal class Class2441
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "l", "ctr", "r", "just", "justLow", "dist", "thaiDist");

	public static Enum313 smethod_0(string xmlValue)
	{
		return (Enum313)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum313 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
