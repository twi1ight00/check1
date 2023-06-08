using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2542
{
	private static readonly Class1151 class1151_0 = new Class1151("ctr", "in");

	public static LineAlignment smethod_0(string xmlValue)
	{
		return (LineAlignment)class1151_0[xmlValue];
	}

	public static string smethod_1(LineAlignment domValue)
	{
		return class1151_0[(int)domValue];
	}
}
