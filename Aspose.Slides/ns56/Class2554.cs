using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2554
{
	private static readonly Class1151 class1151_0 = new Class1151("box", "cone", "coneToMax", "cylinder", "pyramid", "pyramidToMax");

	public static ChartShapeType smethod_0(string xmlValue)
	{
		return (ChartShapeType)class1151_0[xmlValue];
	}

	public static string smethod_1(ChartShapeType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
