using ns33;

namespace ns56;

internal class Class2496
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "slow", "med", "fast");

	public static Enum360 smethod_0(string xmlValue)
	{
		return (Enum360)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum360 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
