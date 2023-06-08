using ns33;

namespace ns56;

internal class Class2396
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "halfwidthKatakana", "fullwidthKatakana", "Hiragana", "noConversion");

	public static Enum229 smethod_0(string xmlValue)
	{
		return (Enum229)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum229 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
