using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class946
{
	public static void smethod_0(IReflection reflection, Class1913 reflectionEffectElementData)
	{
		if (reflectionEffectElementData != null)
		{
			reflection.BlurRadius = reflectionEffectElementData.BlurRad;
			reflection.Direction = reflectionEffectElementData.Dir;
			reflection.Distance = reflectionEffectElementData.Dist;
			reflection.RectangleAlign = reflectionEffectElementData.Algn;
			reflection.StartReflectionOpacity = reflectionEffectElementData.StA;
			reflection.EndReflectionOpacity = reflectionEffectElementData.EndA;
			reflection.StartPosAlpha = reflectionEffectElementData.StPos;
			reflection.EndPosAlpha = reflectionEffectElementData.EndPos;
			reflection.FadeDirection = reflectionEffectElementData.FadeDir;
			reflection.SkewHorizontal = reflectionEffectElementData.Kx;
			reflection.SkewVertical = reflectionEffectElementData.Ky;
			reflection.RotateShadowWithShape = reflectionEffectElementData.RotWithShape;
			reflection.ScaleHorizontal = reflectionEffectElementData.Sx;
			reflection.ScaleVertical = reflectionEffectElementData.Sy;
		}
	}

	public static void smethod_1(IReflection reflection, Class1913.Delegate1606 addReflection)
	{
		if (reflection != null)
		{
			Class1913 @class = addReflection();
			@class.BlurRad = reflection.BlurRadius;
			@class.Dir = reflection.Direction;
			@class.Dist = reflection.Distance;
			@class.Algn = reflection.RectangleAlign;
			@class.StA = reflection.StartReflectionOpacity;
			@class.EndA = reflection.EndReflectionOpacity;
			@class.StPos = reflection.StartPosAlpha;
			@class.EndPos = reflection.EndPosAlpha;
			@class.FadeDir = reflection.FadeDirection;
			@class.Kx = (float)reflection.SkewHorizontal;
			@class.Ky = (float)reflection.SkewVertical;
			@class.RotWithShape = reflection.RotateShadowWithShape;
			@class.Sx = (float)reflection.ScaleHorizontal;
			@class.Sy = (float)reflection.ScaleVertical;
		}
	}
}
