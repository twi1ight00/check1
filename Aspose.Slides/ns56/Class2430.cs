using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2430
{
	private static readonly Class1151 class1151_0 = new Class1151("l", "r");

	public static TransitionLeftRightDirectionType smethod_0(string xmlValue)
	{
		return (TransitionLeftRightDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionLeftRightDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
