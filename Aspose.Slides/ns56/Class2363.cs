using ns33;

namespace ns56;

internal class Class2363
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "noControl", "off", "on", "disabled", "hiragana", "fullKatakana", "halfKatakana", "fullAlpha", "halfAlpha", "fullHangul", "halfHangul");

	public static Enum196 smethod_0(string xmlValue)
	{
		return (Enum196)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum196 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
