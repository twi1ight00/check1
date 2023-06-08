using ns33;

namespace ns56;

internal class Class2508
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "t", "true", "f", "false");

	public static Enum372 smethod_0(string xmlValue)
	{
		return (Enum372)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum372 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
