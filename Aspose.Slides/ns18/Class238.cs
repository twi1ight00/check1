using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class238
{
	public static void smethod_0(IRevealTransition revealTransition, Class1363 revealElementData)
	{
		if (revealElementData != null)
		{
			revealTransition.Direction = revealElementData.Dir;
			revealTransition.ThroughBlack = revealElementData.ThruBlk;
		}
	}

	public static void smethod_1(IRevealTransition revealTransition, Class1363 revealElementData)
	{
		revealElementData.Dir = revealTransition.Direction;
		revealElementData.ThruBlk = revealTransition.ThroughBlack;
	}
}
