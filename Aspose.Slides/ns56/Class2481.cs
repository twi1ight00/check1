using ns33;

namespace ns56;

internal class Class2481
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "perspective", "parallel");

	public static Enum345 smethod_0(string xmlValue)
	{
		return (Enum345)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum345 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
