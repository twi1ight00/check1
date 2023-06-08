using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2571
{
	internal static readonly Class1151 class1151_0 = new Class1151("l", "ctr", "r", "dec");

	public static TabAlignment smethod_0(string xmlValue)
	{
		return (TabAlignment)class1151_0[xmlValue];
	}

	public static string smethod_1(TabAlignment domValue)
	{
		return class1151_0[(int)domValue];
	}
}
