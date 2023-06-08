using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class39 : EffectEffectiveDataPVITemp, IInnerShadowEffectiveData
{
	internal double double_0;

	internal float float_0;

	internal double double_1;

	internal Class18 class18_0;

	public double BlurRadius => double_0;

	public float Direction => float_0;

	public double Distance => double_1;

	public Color ShadowColor => class18_0.Color;

	internal Class39(double blurRadius, float direction, double distance, Class21.Delegate2 shadowColorResolver)
	{
		double_0 = blurRadius;
		float_0 = direction;
		double_1 = distance;
		class18_0 = new Class18(shadowColorResolver);
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
	}
}
