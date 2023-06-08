using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2572
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "words", "sng", "dbl", "heavy", "dotted", "dottedHeavy", "dash", "dashHeavy", "dashLong", "dashLongHeavy", "dotDash", "dotDashHeavy", "dotDotDash", "dotDotDashHeavy", "wavy", "wavyHeavy", "wavyDbl");

	public static TextUnderlineType smethod_0(string xmlValue)
	{
		return (TextUnderlineType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextUnderlineType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
