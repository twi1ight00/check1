using ns33;

namespace ns56;

internal class Class2503
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "short", "medium", "long");

	public static Enum367 smethod_0(string xmlValue)
	{
		return (Enum367)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum367 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
