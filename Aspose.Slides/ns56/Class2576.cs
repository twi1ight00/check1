using Aspose.Slides.Charts;
using ns33;

namespace ns56;

internal class Class2576
{
	private static readonly Class1151 class1151_0 = new Class1151("cross", "in", "none", "out");

	public static TickMarkType smethod_0(string xmlValue)
	{
		return (TickMarkType)class1151_0[xmlValue];
	}

	public static string smethod_1(TickMarkType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
