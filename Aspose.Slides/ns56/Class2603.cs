using Aspose.Slides.SlideShow;
using ns33;

namespace ns56;

internal class Class2603
{
	private static readonly Class1151 class1151_0 = new Class1151("in", "out");

	public static TransitionInOutDirectionType smethod_0(string xmlValue)
	{
		return (TransitionInOutDirectionType)class1151_0[xmlValue];
	}

	public static string smethod_1(TransitionInOutDirectionType domValue)
	{
		return class1151_0[(int)domValue];
	}
}
