using ns33;

namespace ns56;

internal class Class2509
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "single", "thick", "double", "hairline", "dot", "dash", "dotDash", "dashDotDot", "triple", "thinThickSmall", "thickThinSmall", "thickBetweenThinSmall", "thinThick", "thickThin", "thickBetweenThin", "thinThickLarge", "thickThinLarge", "thickBetweenThinLarge", "wave", "doubleWave", "dashedSmall", "dashDotStroked", "threeDEmboss", "threeDEngrave", "HTMLOutset", "HTMLInset");

	public static Enum373 smethod_0(string xmlValue)
	{
		return (Enum373)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum373 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
