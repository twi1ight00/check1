using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2452
{
	private static readonly Class1151 class1151_0 = new Class1151("exp", "linear", "log", "movingAvg", "poly", "power");

	public static TrendlineType smethod_0(string xmlValue)
	{
		return (TrendlineType)class1151_0[xmlValue];
	}

	public static string smethod_1(TrendlineType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
