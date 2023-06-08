using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2577
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "x", "y", "xy");

	public static TileFlip smethod_0(string xmlValue)
	{
		return (TileFlip)class1151_0[xmlValue];
	}

	public static string smethod_1(TileFlip domValue)
	{
		return class1151_0[(int)domValue];
	}
}
