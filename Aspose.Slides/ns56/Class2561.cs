using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2561
{
	private static Class1151 class1151_0 = new Class1151("round", "bevel", "miter");

	public static LineJoinStyle smethod_0(string xmlValue)
	{
		return (LineJoinStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(LineJoinStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
