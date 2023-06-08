using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2518
{
	private static readonly Class1151 class1151_0 = new Class1151("darken", "lighten", "mult", "over", "screen");

	public static FillBlendMode smethod_0(string xmlValue)
	{
		return (FillBlendMode)class1151_0[xmlValue];
	}

	public static string smethod_1(FillBlendMode domValue)
	{
		return class1151_0[(int)domValue];
	}
}
