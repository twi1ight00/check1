using System;
using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class PresetShadowEffectiveData : EffectEffectiveData, IPresetShadowEffectiveData
{
	internal float float_0;

	internal double double_0;

	internal Color color_0;

	internal PresetShadowType presetShadowType_0;

	public float Direction => float_0;

	public double Distance => double_0;

	public Color ShadowColor => color_0;

	public PresetShadowType Preset => presetShadowType_0;

	internal PresetShadowEffectiveData(float direction, double distance, PresetShadowType preset, Color clr)
	{
		float_0 = direction;
		double_0 = distance;
		presetShadowType_0 = preset;
		color_0 = clr;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}
}
