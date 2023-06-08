using System;
using Aspose.Slides;
using ns16;
using ns56;

namespace ns18;

internal class Class939
{
	public static void smethod_0(IEffectFormat effectFormat, Class2605 effectElementData, Class1341 deserializationContext)
	{
		if (effectElementData == null)
		{
			return;
		}
		switch (effectElementData.Name)
		{
		case "effectLst":
		{
			Class1833 @class = (Class1833)effectElementData.Object;
			Class1811 blur = @class.Blur;
			if (blur != null)
			{
				effectFormat.SetBlurEffect(blur.Rad, blur.Grow);
			}
			if (@class.FillOverlay != null)
			{
				effectFormat.EnableFillOverlayEffect();
				Class940.smethod_0(effectFormat.FillOverlayEffect, @class.FillOverlay, deserializationContext);
			}
			if (@class.Glow != null)
			{
				effectFormat.EnableGlowEffect();
				Class941.smethod_0(effectFormat.GlowEffect, @class.Glow);
			}
			if (@class.InnerShdw != null)
			{
				effectFormat.EnableInnerShadowEffect();
				Class943.smethod_0(effectFormat.InnerShadowEffect, @class.InnerShdw);
			}
			if (@class.OuterShdw != null)
			{
				effectFormat.EnableOuterShadowEffect();
				Class944.smethod_0(effectFormat.OuterShadowEffect, @class.OuterShdw);
			}
			if (@class.PrstShdw != null)
			{
				effectFormat.EnablePresetShadowEffect();
				Class945.smethod_0(effectFormat.PresetShadowEffect, @class.PrstShdw);
			}
			if (@class.Reflection != null)
			{
				effectFormat.EnableReflectionEffect();
				Class946.smethod_0(effectFormat.ReflectionEffect, @class.Reflection);
			}
			if (@class.SoftEdge != null)
			{
				effectFormat.EnableSoftEdgeEffect();
				Class947.smethod_0(effectFormat.SoftEdgeEffect, @class.SoftEdge);
			}
			break;
		}
		default:
			throw new Exception("Unknown element \"" + effectElementData.Name + "\"");
		case "effectDag":
			break;
		}
	}

	public static void smethod_1(IEffectFormat effectFormat, Class2605.Delegate2773 addEffectProperties, Class1346 serializationContext)
	{
		Class1833 effectListElementData = (Class1833)addEffectProperties("effectLst").Object;
		if (effectFormat != null && !effectFormat.IsNoEffects)
		{
			smethod_2(effectFormat, effectListElementData, serializationContext);
		}
	}

	public static void smethod_2(IEffectFormat effectFormat, Class1833 effectListElementData, Class1346 serializationContext)
	{
		if (effectFormat != null && !effectFormat.IsNoEffects)
		{
			if (effectFormat.BlurEffect != null)
			{
				Class1811 @class = effectListElementData.delegate1312_0();
				@class.Rad = effectFormat.BlurEffect.Radius;
				@class.Grow = effectFormat.BlurEffect.Grow;
			}
			Class940.smethod_1(effectFormat.FillOverlayEffect, effectListElementData.delegate1402_0, serializationContext);
			Class941.smethod_1(effectFormat.GlowEffect, effectListElementData.delegate1435_0);
			Class943.smethod_1(effectFormat.InnerShadowEffect, effectListElementData.delegate1477_0);
			Class944.smethod_1(effectFormat.OuterShadowEffect, effectListElementData.delegate1537_0);
			Class945.smethod_1(effectFormat.PresetShadowEffect, effectListElementData.delegate1597_0);
			Class946.smethod_1(effectFormat.ReflectionEffect, effectListElementData.delegate1606_0);
			Class947.smethod_1(effectFormat.SoftEdgeEffect, effectListElementData.delegate1636_0);
		}
	}
}
