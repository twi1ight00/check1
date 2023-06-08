using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2564
{
	internal static readonly Class1151 class1151_0 = new Class1151("t", "ctr", "b", "just", "dist");

	public static TextAnchorType smethod_0(string xmlValue)
	{
		return (TextAnchorType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextAnchorType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
