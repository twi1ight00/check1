using ns215;

namespace ns216;

internal class Class5873 : Class5782
{
	public bool ExcludeAllCaps => (bool)method_5("excludeAllCaps").Value;

	public bool ExcludeInitialCap => (bool)method_5("excludeInitialCap").Value;

	public bool Hyphenate => (bool)method_5("hyphenate").Value;

	public int PushCharacterCount => (int)method_5("pushCharacterCount").Value;

	public int WordCharacterCount => (int)method_5("wordCharacterCount").Value;

	public int RemainCharacterCount => (int)method_5("remainCharacterCount").Value;

	internal static string Tag => "hyphenation";

	public Class5873()
	{
		Class5906.smethod_3(this, "excludeAllCaps", @default: false);
		Class5906.smethod_3(this, "excludeInitialCap", @default: false);
		Class5906.smethod_3(this, "hyphenate", @default: false);
		Class5906.smethod_2(this, "pushCharacterCount", 3);
		Class5906.smethod_2(this, "wordCharacterCount", 7);
		Class5906.smethod_2(this, "remainCharacterCount", 3);
		Class5906.smethod_4(this, "use", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_87(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5873();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
