using ns33;

namespace ns56;

internal class Class2490
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "hash", "invalid");

	public static Enum354 smethod_0(string xmlValue)
	{
		return (Enum354)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum354 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
