using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2567
{
	internal static readonly Class1151 class1151_0 = new Class1151("auto", "t", "ctr", "b", "base");

	public static FontAlignment smethod_0(string xmlValue)
	{
		return (FontAlignment)class1151_0[xmlValue];
	}

	public static string smethod_1(FontAlignment domValue)
	{
		return class1151_0[(int)domValue];
	}
}
