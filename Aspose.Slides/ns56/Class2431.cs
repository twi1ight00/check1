using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2431
{
	private static readonly Class1151 class1151_0 = new Class1151("diamond", "hexagon");

	public static TransitionPattern smethod_0(string xmlValue)
	{
		return (TransitionPattern)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionPattern domValue)
	{
		return class1151_0[(int)domValue];
	}
}
