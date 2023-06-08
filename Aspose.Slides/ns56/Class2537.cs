using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2537
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "triangle", "stealth", "diamond", "oval", "arrow");

	public static LineArrowheadStyle smethod_0(string xmlValue)
	{
		return (LineArrowheadStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(LineArrowheadStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
