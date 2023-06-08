using ns33;

namespace ns56;

internal class Class2352
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "gregorian", "gregorianUs", "japan", "taiwan", "korea", "hijri", "thai", "hebrew", "gregorianMeFrench", "gregorianArabic", "gregorianXlitEnglish", "gregorianXlitFrench");

	public static Enum186 smethod_0(string xmlValue)
	{
		return (Enum186)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum186 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
