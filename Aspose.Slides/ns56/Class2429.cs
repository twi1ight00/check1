using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2429
{
	private static readonly Class1151 class1151_0 = new Class1151("ld", "lu", "rd", "ru", "center");

	public static TransitionCornerAndCenterDirectionType smethod_0(string xmlValue)
	{
		return (TransitionCornerAndCenterDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionCornerAndCenterDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
