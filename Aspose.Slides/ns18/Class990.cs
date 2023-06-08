using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class990
{
	public static void smethod_0(ISideDirectionTransition sideDirectionTransition, Class2250 sideDirectionTransitionElementData)
	{
		if (sideDirectionTransitionElementData != null)
		{
			sideDirectionTransition.Direction = sideDirectionTransitionElementData.Dir;
		}
	}

	public static void smethod_1(ISideDirectionTransition sideDirectionTransition, Class2250 sideDirectionTransitionElementData)
	{
		sideDirectionTransitionElementData.Dir = sideDirectionTransition.Direction;
	}
}
