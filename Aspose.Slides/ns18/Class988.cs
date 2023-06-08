using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class988
{
	public static void smethod_0(IOptionalBlackTransition optionalBlackTransition, Class2244 optionalBlackTransitionElementData)
	{
		if (optionalBlackTransitionElementData != null)
		{
			optionalBlackTransition.FromBlack = optionalBlackTransitionElementData.ThruBlk;
		}
	}

	public static void smethod_1(IOptionalBlackTransition optionalBlackTransition, Class2244 optionalBlackTransitionElementData)
	{
		optionalBlackTransitionElementData.ThruBlk = optionalBlackTransition.FromBlack;
	}
}
