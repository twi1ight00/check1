using ns33;

namespace ns56;

internal class Class2475
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "color", "auto", "grayScale", "lightGrayScale", "inverseGray", "grayOutline", "highContrast", "black", "white", "hide", "undrawn", "blackTextAndLines");

	internal static Enum308 smethod_0(string xmlValue)
	{
		return (Enum308)class1151_0[xmlValue];
	}

	internal static string smethod_1(Enum308 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
