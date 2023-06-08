using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2515
{
	private static readonly Class1151 class1151_0 = new Class1151("b", "l", "r", "t");

	public static AxisPositionType smethod_0(string xmlValue)
	{
		return (AxisPositionType)class1151_0[xmlValue];
	}

	public static string smethod_1(AxisPositionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
