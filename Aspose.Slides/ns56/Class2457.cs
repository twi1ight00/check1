using ns33;

namespace ns56;

internal class Class2457
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "b", "t");

	public static Enum327 smethod_0(string xmlValue)
	{
		return (Enum327)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum327 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
