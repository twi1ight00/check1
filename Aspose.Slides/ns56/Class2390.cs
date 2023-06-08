using ns33;

namespace ns56;

internal class Class2390
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "downThenOver", "overThenDown");

	public static Enum223 smethod_0(string xmlValue)
	{
		return (Enum223)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum223 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
