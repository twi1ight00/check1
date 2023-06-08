using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2602
{
	private static readonly Class1151 class1151_0 = new Class1151("ld", "lu", "rd", "ru", "l", "u", "d", "r");

	public static TransitionEightDirectionType smethod_0(string xmlValue)
	{
		return (TransitionEightDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionEightDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
