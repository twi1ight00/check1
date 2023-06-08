using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2549
{
	private static readonly Class1151 class1151_0 = new Class1151("clear", "dkEdge", "flat", "legacyMatte", "legacyMetal", "legacyPlastic", "legacyWireframe", "matte", "metal", "plastic", "powder", "softEdge", "softmetal", "translucentPowder", "warmMatte");

	public static MaterialPresetType smethod_0(string xmlValue)
	{
		return (MaterialPresetType)class1151_0[xmlValue];
	}

	public static string smethod_1(MaterialPresetType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
