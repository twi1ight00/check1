using ns33;

namespace ns56;

internal class Class2446
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "edge", "factor");

	public static Enum318 smethod_0(string xmlValue)
	{
		return (Enum318)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum318 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
