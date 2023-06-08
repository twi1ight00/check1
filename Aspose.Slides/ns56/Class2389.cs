using ns33;

namespace ns56;

internal class Class2389
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "default", "portrait", "landscape");

	public static Enum222 smethod_0(string xmlValue)
	{
		return (Enum222)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum222 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
