using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2604
{
	private static readonly Class1151 class1151_0 = new Class1151("l", "u", "d", "r");

	public static TransitionSideDirectionType smethod_0(string xmlValue)
	{
		return (TransitionSideDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionSideDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
