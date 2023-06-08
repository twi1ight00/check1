using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2524
{
	private static readonly Class1151 class1151_0 = new Class1151("autoZero", "max", "min");

	public static CrossesType smethod_0(string xmlValue)
	{
		return (CrossesType)class1151_0[xmlValue];
	}

	public static string smethod_1(CrossesType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
