using ns33;

namespace ns56;

internal class Class2501
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "ignore", "atMost", "atLeast");

	public static Enum365 smethod_0(string xmlValue)
	{
		return (Enum365)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum365 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
