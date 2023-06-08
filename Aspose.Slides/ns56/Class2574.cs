using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2574
{
	private static readonly Class1151 class1151_0 = new Class1151("overflow", "ellipsis", "clip");

	public static TextVerticalOverflowType smethod_0(string xmlValue)
	{
		return (TextVerticalOverflowType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextVerticalOverflowType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
