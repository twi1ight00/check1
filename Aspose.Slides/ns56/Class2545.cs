using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2545
{
	internal static readonly Class1151 class1151_0 = new Class1151("title", "body", "ctrTitle", "subTitle", "dt", "sldNum", "ftr", "hdr", "obj", "chart", "tbl", "clipArt", "dgm", "media", "sldImg", "pic");

	public static PlaceholderType smethod_0(string xmlValue)
	{
		return (PlaceholderType)class1151_0[xmlValue];
	}

	public static string smethod_1(PlaceholderType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
