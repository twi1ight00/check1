using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class989
{
	public static void smethod_0(IOrientationTransition orientationTransition, Class2245 orientationTransitionElementData)
	{
		if (orientationTransitionElementData != null)
		{
			orientationTransition.Direction = orientationTransitionElementData.Dir;
		}
	}

	public static void smethod_1(IOrientationTransition orientationTransition, Class2245 orientationTransitionElementData)
	{
		orientationTransitionElementData.Dir = orientationTransition.Direction;
	}
}
