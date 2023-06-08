using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2516
{
	private static readonly Class1151 class1151_0 = new Class1151("angle", "artDeco", "circle", "convex", "coolSlant", "cross", "divot", "hardEdge", "relaxedInset", "riblet", "slope", "softRound");

	public static BevelPresetType smethod_0(string xmlValue)
	{
		return (BevelPresetType)class1151_0[xmlValue];
	}

	public static string smethod_1(BevelPresetType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
