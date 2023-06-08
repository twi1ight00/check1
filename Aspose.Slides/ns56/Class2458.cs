using ns33;

namespace ns56;

internal class Class2458
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "span", "cycle", "repeat");

	public static Enum328 smethod_0(string xmlValue)
	{
		return (Enum328)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum328 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
