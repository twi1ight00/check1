using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2432
{
	private static readonly Class1151 class1151_0 = new Class1151("strip", "rectangle");

	public static TransitionShredPattern smethod_0(string xmlValue)
	{
		return (TransitionShredPattern)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionShredPattern domValue)
	{
		return class1151_0[(int)domValue];
	}
}
