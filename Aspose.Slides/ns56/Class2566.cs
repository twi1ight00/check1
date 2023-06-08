using Aspose.Slides;
using ns33;

namespace ns56;

internal class Class2566
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "small", "all");

	public static TextCapType smethod_0(string xmlValue)
	{
		return (TextCapType)class1151_0[xmlValue];
	}

	public static string smethod_1(TextCapType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
