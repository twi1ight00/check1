using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class243
{
	public static void smethod_0(IRippleTransition rippleTransition, Class1364 rippleTransitionElementData)
	{
		if (rippleTransitionElementData != null)
		{
			rippleTransition.Direction = rippleTransitionElementData.Dir;
		}
	}

	public static void smethod_1(IRippleTransition rippleTransition, Class1364 rippleTransitionElementData)
	{
		rippleTransitionElementData.Dir = rippleTransition.Direction;
	}
}
