using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2521
{
	private static readonly Class1151 class1151_0 = new Class1151("dk1", "lt1", "dk2", "lt2", "accent1", "accent2", "accent3", "accent4", "accent5", "accent6", "hlink", "folHlink");

	public static ColorSchemeIndex smethod_0(string xmlValue)
	{
		return (ColorSchemeIndex)class1151_0[xmlValue];
	}

	public static string smethod_1(ColorSchemeIndex domValue)
	{
		return class1151_0[(int)domValue];
	}
}
