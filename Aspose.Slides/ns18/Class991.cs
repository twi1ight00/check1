using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class991
{
	public static void smethod_0(ISplitTransition splitTransition, Class2261 splitElementData)
	{
		if (splitElementData != null)
		{
			splitTransition.Direction = splitElementData.Dir;
			splitTransition.Orientation = splitElementData.Orient;
		}
	}

	public static void smethod_1(ISplitTransition splitTransition, Class2261 splitElementData)
	{
		splitElementData.Dir = splitTransition.Direction;
		splitElementData.Orient = splitTransition.Orientation;
	}
}
