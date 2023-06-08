using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2519
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "hundreds", "thousands", "tenThousands", "hundredThousands", "millions", "tenMillions", "hundredMillions", "billions", "trillions");

	public static DisplayUnitType smethod_0(string xmlValue)
	{
		return (DisplayUnitType)class1151_0[xmlValue];
	}

	public static string smethod_1(DisplayUnitType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
