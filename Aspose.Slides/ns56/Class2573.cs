using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2573
{
	internal static readonly Class1151 class1151_0 = new Class1151("horz", "vert", "vert270", "wordArtVert", "eaVert", "mongolianVert", "wordArtVertRtl");

	public static TextVerticalType smethod_0(string xmlValue)
	{
		return (TextVerticalType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextVerticalType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
