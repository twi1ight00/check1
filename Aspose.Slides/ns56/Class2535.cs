using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2535
{
	private static readonly Class1151 class1151_0 = new Class1151("rnd", "sq", "flat");

	public static LineCapStyle smethod_0(string xmlValue)
	{
		return (LineCapStyle)class1151_0[xmlValue];
	}

	public static string smethod_1(LineCapStyle domValue)
	{
		return class1151_0[(int)domValue];
	}
}
