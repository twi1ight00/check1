using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class240
{
	public static void smethod_0(IFlyThroughTransition flyThroughTransition, Class1358 flyThroughTransitionElementData)
	{
		if (flyThroughTransitionElementData != null)
		{
			flyThroughTransition.Direction = flyThroughTransitionElementData.Dir;
			flyThroughTransition.HasBounce = flyThroughTransitionElementData.HasBounce;
		}
	}

	public static void smethod_1(IFlyThroughTransition flyThroughTransition, Class1358 flyThroughTransitionElementData)
	{
		flyThroughTransitionElementData.Dir = flyThroughTransition.Direction;
		flyThroughTransitionElementData.HasBounce = flyThroughTransition.HasBounce;
	}
}
