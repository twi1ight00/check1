using Aspose.Slides.Effects;
using ns56;

namespace ns18;

internal class Class945
{
	public static void smethod_0(IPresetShadow presetShadow, Class1910 presetShadowEffectElementData)
	{
		if (presetShadowEffectElementData != null)
		{
			presetShadow.Direction = presetShadowEffectElementData.Dir;
			presetShadow.Distance = presetShadowEffectElementData.Dist;
			Class930.smethod_1(presetShadow.ShadowColor, presetShadowEffectElementData.Color);
			presetShadow.Preset = presetShadowEffectElementData.Prst;
		}
	}

	public static void smethod_1(IPresetShadow presetShadow, Class1910.Delegate1597 addPrstShdw)
	{
		if (presetShadow != null)
		{
			Class1910 @class = addPrstShdw();
			@class.Dir = presetShadow.Direction;
			@class.Dist = presetShadow.Distance;
			Class930.smethod_4(presetShadow.ShadowColor, @class.delegate2773_0);
			@class.Prst = presetShadow.Preset;
		}
	}
}
