using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2553
{
	internal static readonly Class1151 class1151_0 = new Class1151("bg1", "tx1", "bg2", "tx2", "accent1", "accent2", "accent3", "accent4", "accent5", "accent6", "hlink", "folHlink", "phClr", "dk1", "lt1", "dk2", "lt2");

	public static SchemeColor smethod_0(string xmlValue)
	{
		return (SchemeColor)class1151_0[xmlValue];
	}

	public static string smethod_1(SchemeColor domValue)
	{
		return class1151_0[(int)domValue];
	}
}
