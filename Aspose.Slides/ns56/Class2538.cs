using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2538
{
	private static readonly Class1151 class1151_0 = new Class1151("sm", "med", "lg");

	public static LineArrowheadWidth smethod_0(string xmlValue)
	{
		return (LineArrowheadWidth)class1151_0[xmlValue];
	}

	public static string smethod_1(LineArrowheadWidth domValue)
	{
		return class1151_0[(int)domValue];
	}
}
