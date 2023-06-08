using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class42 : EffectEffectiveDataPVITemp, IPresetShadowEffectiveData
{
	internal float float_0;

	internal double double_0;

	internal Class18 class18_0;

	internal PresetShadowType presetShadowType_0;

	public float Direction => float_0;

	public double Distance => double_0;

	public Color ShadowColor => class18_0.Color;

	public PresetShadowType Preset => presetShadowType_0;

	internal Class42(float direction, double distance, PresetShadowType preset, Class21.Delegate2 shadowColorResolver)
	{
		float_0 = direction;
		double_0 = distance;
		presetShadowType_0 = preset;
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
