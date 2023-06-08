using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class944
{
	public static void smethod_0(IOuterShadow outerShadow, Class1890 outerShadowEffectElementData)
	{
		if (outerShadowEffectElementData != null)
		{
			outerShadow.BlurRadius = outerShadowEffectElementData.BlurRad;
			outerShadow.Direction = outerShadowEffectElementData.Dir;
			outerShadow.Distance = outerShadowEffectElementData.Dist;
			Class930.smethod_1(outerShadow.ShadowColor, outerShadowEffectElementData.Color);
			outerShadow.RectangleAlign = outerShadowEffectElementData.Algn;
			outerShadow.SkewHorizontal = outerShadowEffectElementData.Kx;
			outerShadow.SkewVertical = outerShadowEffectElementData.Ky;
			outerShadow.RotateShadowWithShape = outerShadowEffectElementData.RotWithShape;
			outerShadow.ScaleHorizontal = outerShadowEffectElementData.Sx;
			outerShadow.ScaleVertical = outerShadowEffectElementData.Sy;
		}
	}

	public static void smethod_1(IOuterShadow outerShadow, Class1890.Delegate1537 addOuterShdw)
	{
		if (outerShadow != null)
		{
			Class1890 @class = addOuterShdw();
			@class.BlurRad = outerShadow.BlurRadius;
			@class.Dir = outerShadow.Direction;
			@class.Dist = outerShadow.Distance;
			Class930.smethod_4(outerShadow.ShadowColor, @class.delegate2773_0);
			@class.Algn = outerShadow.RectangleAlign;
			@class.Kx = (float)outerShadow.SkewHorizontal;
			@class.Ky = (float)outerShadow.SkewVertical;
			@class.RotWithShape = outerShadow.RotateShadowWithShape;
			@class.Sx = (float)outerShadow.ScaleHorizontal;
			@class.Sy = (float)outerShadow.ScaleVertical;
		}
	}
}
