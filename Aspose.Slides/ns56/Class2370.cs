using ns33;

namespace ns56;

internal class Class2370
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "general", "text", "MDY", "DMY", "YMD", "MYD", "DYM", "YDM", "skip", "EMD");

	public static Enum203 smethod_0(string xmlValue)
	{
		return (Enum203)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum203 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
