using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class947
{
	public static void smethod_0(ISoftEdge softEdge, Class1923 softEdgesEffectElementData)
	{
		if (softEdgesEffectElementData != null)
		{
			softEdge.Radius = softEdgesEffectElementData.Rad;
		}
	}

	public static void smethod_1(ISoftEdge softEdge, Class1923.Delegate1636 addSoftEdge)
	{
		if (softEdge != null)
		{
			Class1923 @class = addSoftEdge();
			@class.Rad = softEdge.Radius;
		}
	}
}
