using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2534
{
	private static readonly Class1151 class1151_0 = new Class1151("balanced", "brightRoom", "chilly", "contrasting", "flat", "flood", "freezing", "glow", "harsh", "legacyFlat1", "legacyFlat2", "legacyFlat3", "legacyFlat4", "legacyHarsh1", "legacyHarsh2", "legacyHarsh3", "legacyHarsh4", "legacyNormal1", "legacyNormal2", "legacyNormal3", "legacyNormal4", "morning", "soft", "sunrise", "sunset", "threePt", "twoPt");

	public static LightRigPresetType smethod_0(string xmlValue)
	{
		return (LightRigPresetType)class1151_0[xmlValue];
	}

	public static string smethod_1(LightRigPresetType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
