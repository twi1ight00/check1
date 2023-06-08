using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class244
{
	public static void smethod_0(ILeftRightDirectionTransition leftRightDirectionTransition, Class1360 leftRightDirectionTransitionElementData)
	{
		if (leftRightDirectionTransitionElementData != null)
		{
			leftRightDirectionTransition.Direction = leftRightDirectionTransitionElementData.Dir;
		}
	}

	public static void smethod_1(ILeftRightDirectionTransition leftRightDirectionTransition, Class1360 leftRightDirectionTransitionElementData)
	{
		leftRightDirectionTransitionElementData.Dir = leftRightDirectionTransition.Direction;
	}
}
