using System;
using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class InnerShadowEffectiveData : EffectEffectiveData, IInnerShadowEffectiveData
{
	internal double double_0;

	internal float float_0;

	internal double double_1;

	internal Color color_0;

	public double BlurRadius => double_0;

	public float Direction => float_0;

	public double Distance => double_1;

	public Color ShadowColor => color_0;

	internal InnerShadowEffectiveData(double blurRadius, float direction, double distance, Color color)
	{
		double_0 = blurRadius;
		float_0 = direction;
		double_1 = distance;
		color_0 = color;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}
}
