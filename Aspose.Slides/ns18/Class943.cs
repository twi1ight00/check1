using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class943
{
	public static void smethod_0(IInnerShadow innerShadow, Class1866 innerShadowEffectElementData)
	{
		if (innerShadowEffectElementData != null)
		{
			innerShadow.BlurRadius = innerShadowEffectElementData.BlurRad;
			innerShadow.Direction = innerShadowEffectElementData.Dir;
			innerShadow.Distance = innerShadowEffectElementData.Dist;
			Class930.smethod_1(innerShadow.ShadowColor, innerShadowEffectElementData.Color);
		}
	}

	public static void smethod_1(IInnerShadow innerShadow, Class1866.Delegate1477 addInnerShdw)
	{
		if (innerShadow != null)
		{
			Class1866 @class = addInnerShdw();
			@class.BlurRad = innerShadow.BlurRadius;
			@class.Dir = innerShadow.Direction;
			@class.Dist = innerShadow.Distance;
			Class930.smethod_4(innerShadow.ShadowColor, @class.delegate2773_0);
		}
	}
}
