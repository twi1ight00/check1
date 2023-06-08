using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2517
{
	private static readonly Class1151 class1151_0 = new Class1151("clr", "auto", "gray", "ltGray", "invGray", "grayWhite", "blackGray", "blackWhite", "black", "white", "hidden");

	public static BlackWhiteMode smethod_0(string xmlValue)
	{
		return (BlackWhiteMode)class1151_0[xmlValue];
	}

	public static string smethod_1(BlackWhiteMode domValue)
	{
		return class1151_0[(int)domValue];
	}
}
