using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2601
{
	private static readonly Class1151 class1151_0 = new Class1151("ld", "lu", "rd", "ru");

	public static TransitionCornerDirectionType smethod_0(string xmlValue)
	{
		return (TransitionCornerDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionCornerDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
