using ns33;

namespace ns56;

internal class Class2428
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "twoCell", "oneCell", "absolute");

	public static Enum261 smethod_0(string xmlValue)
	{
		return (Enum261)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum261 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
