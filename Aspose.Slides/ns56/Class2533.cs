using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2533
{
	private static readonly Class1151 class1151_0 = new Class1151("tl", "t", "tr", "r", "br", "b", "bl", "l");

	public static LightingDirection smethod_0(string xmlValue)
	{
		return (LightingDirection)class1151_0[xmlValue];
	}

	public static string smethod_1(LightingDirection domValue)
	{
		return class1151_0[(int)domValue];
	}
}
