using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2532
{
	private static readonly Class1151 class1151_0 = new Class1151("b", "l", "r", "t", "tr");

	public static LegendPositionType smethod_0(string xmlValue)
	{
		return (LegendPositionType)class1151_0[xmlValue];
	}

	public static string smethod_1(LegendPositionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
