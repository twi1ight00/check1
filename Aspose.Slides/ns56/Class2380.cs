using ns33;

namespace ns56;

internal class Class2380
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "general", "left", "center", "right", "fill", "justify", "centerContinuous", "distributed");

	public static Enum213 smethod_0(string xmlValue)
	{
		return (Enum213)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum213 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
