using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2558
{
	private static readonly Class1151 class1151_0 = new Class1151("screen4x3", "letter", "A4", "35mm", "overhead", "banner", "custom", "ledger", "A3", "B4ISO", "B5ISO", "B4JIS", "B5JIS", "hagakiCard", "screen16x9", "screen16x10");

	public static SlideSizeType smethod_0(string xmlValue)
	{
		return (SlideSizeType)class1151_0[xmlValue];
	}

	public static string smethod_1(SlideSizeType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
