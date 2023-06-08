using ns33;

namespace ns56;

internal class Class2466
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "l", "r", "hang", "std", "init");

	public static Enum335 smethod_0(string xmlValue)
	{
		return (Enum335)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum335 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
