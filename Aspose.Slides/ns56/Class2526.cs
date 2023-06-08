using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2526
{
	internal static readonly Class1151 class1151_0 = new Class1151("horz", "vert");

	public static Orientation smethod_0(string xmlValue)
	{
		return (Orientation)class1151_0[xmlValue];
	}

	public static string smethod_1(Orientation domValue)
	{
		return class1151_0[(int)domValue];
	}
}
