using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class242
{
	public static void smethod_0(ISlideShowTransition slideShowTransition, Class1362 rippleTransitionElementData)
	{
		if (rippleTransitionElementData != null)
		{
			if (!rippleTransitionElementData.IsContent && !rippleTransitionElementData.IsInverted)
			{
				slideShowTransition.Type = TransitionType.Cube;
			}
			else if (!rippleTransitionElementData.IsContent && rippleTransitionElementData.IsInverted)
			{
				slideShowTransition.Type = TransitionType.Box;
			}
			else if (rippleTransitionElementData.IsContent && !rippleTransitionElementData.IsInverted)
			{
				slideShowTransition.Type = TransitionType.Rotate;
			}
			else if (rippleTransitionElementData.IsContent && rippleTransitionElementData.IsInverted)
			{
				slideShowTransition.Type = TransitionType.Orbit;
			}
			((SideDirectionTransition)slideShowTransition.Value).Direction = rippleTransitionElementData.Dir;
		}
	}

	public static void smethod_1(ISlideShowTransition slideShowTransition, Class1362 rippleTransitionElementData)
	{
		switch (slideShowTransition.Type)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case TransitionType.Cube:
			rippleTransitionElementData.IsContent = false;
			rippleTransitionElementData.IsInverted = false;
			break;
		case TransitionType.Box:
			rippleTransitionElementData.IsContent = false;
			rippleTransitionElementData.IsInverted = true;
			break;
		case TransitionType.Rotate:
			rippleTransitionElementData.IsContent = true;
			rippleTransitionElementData.IsInverted = false;
			break;
		case TransitionType.Orbit:
			rippleTransitionElementData.IsContent = true;
			rippleTransitionElementData.IsInverted = true;
			break;
		}
		rippleTransitionElementData.Dir = ((SideDirectionTransition)slideShowTransition.Value).Direction;
	}
}
