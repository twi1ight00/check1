using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2570
{
	private static readonly Class1151 class1151_0 = new Class1151("noStrike", "sngStrike", "dblStrike");

	public static TextStrikethroughType smethod_0(string xmlValue)
	{
		return (TextStrikethroughType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextStrikethroughType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
