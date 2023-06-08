using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class987
{
	public static void smethod_0(IInOutTransition inOutTransition, Class2240 inOutTransitionElementData)
	{
		if (inOutTransitionElementData != null)
		{
			inOutTransition.Direction = inOutTransitionElementData.Dir;
		}
	}

	public static void smethod_1(IInOutTransition inOutTransition, Class2240 inOutTransitionElementData)
	{
		inOutTransitionElementData.Dir = inOutTransition.Direction;
	}
}
