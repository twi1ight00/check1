using ns33;

namespace ns56;

internal class Class2442
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "square");

	public static Enum314 smethod_0(string xmlValue)
	{
		return (Enum314)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum314 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
