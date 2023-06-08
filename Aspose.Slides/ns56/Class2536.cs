using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2536
{
	private static readonly Class1151 class1151_0 = new Class1151("sm", "med", "lg");

	public static LineArrowheadLength smethod_0(string xmlValue)
	{
		return (LineArrowheadLength)class1151_0[xmlValue];
	}

	public static string smethod_1(LineArrowheadLength domValue)
	{
		return class1151_0[(int)domValue];
	}
}
