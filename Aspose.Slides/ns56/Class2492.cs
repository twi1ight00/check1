using ns33;

namespace ns56;

internal class Class2492
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "rsaAES", "rsaFull", "invalid");

	public static Enum356 smethod_0(string xmlValue)
	{
		return (Enum356)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum356 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
