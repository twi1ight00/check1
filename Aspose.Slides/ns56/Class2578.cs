using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2578
{
	private static readonly Class1151 class1151_0 = new Class1151("days", "months", "years");

	public static TimeUnitType smethod_0(string xmlValue)
	{
		return (TimeUnitType)class1151_0[xmlValue];
	}

	public static string smethod_1(TimeUnitType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
