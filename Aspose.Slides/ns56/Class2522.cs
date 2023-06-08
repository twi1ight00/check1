using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2522
{
	private static readonly Class1151 class1151_0 = new Class1151("sng", "dbl", "thickThin", "thinThick", "tri");

	public static LineStyle smethod_0(string xmlValue)
	{
		return (LineStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(LineStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
