using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2528
{
	private static readonly Class1151 class1151_0 = new Class1151("b", "bestFit", "ctr", "inBase", "inEnd", "l", "outEnd", "r", "t");

	public static LegendDataLabelPosition smethod_0(string xmlValue)
	{
		return (LegendDataLabelPosition)class1151_0[xmlValue];
	}

	public static string smethod_1(LegendDataLabelPosition domValue)
	{
		return class1151_0[(int)domValue];
	}
}
