using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2552
{
	public static readonly Class1151 class1151_0 = new Class1151("tl", "t", "tr", "l", "ctr", "r", "bl", "b", "br");

	public static RectangleAlignment smethod_0(string xmlValue)
	{
		return (RectangleAlignment)class1151_0[xmlValue];
	}

	public static string smethod_1(RectangleAlignment domValue)
	{
		return class1151_0[(int)domValue];
	}
}
