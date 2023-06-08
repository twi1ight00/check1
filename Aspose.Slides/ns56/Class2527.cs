using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2527
{
	private static readonly Class1151 class1151_0 = new Class1151("gap", "span", "zero");

	public static DisplayBlanksAsType smethod_0(string xmlValue)
	{
		return (DisplayBlanksAsType)class1151_0[xmlValue];
	}

	public static string smethod_1(DisplayBlanksAsType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
