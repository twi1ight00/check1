using Aspose.Slides.Effects;

namespace Aspose.Slides;

public class EffectFormatEffectiveData : IEffectFormatEffectiveData, IEffectiveData
{
	internal BlurEffectiveData blurEffectiveData_0;

	internal FillOverlayEffectiveData fillOverlayEffectiveData_0;

	internal GlowEffectiveData glowEffectiveData_0;

	internal InnerShadowEffectiveData innerShadowEffectiveData_0;

	internal OuterShadowEffectiveData outerShadowEffectiveData_0;

	internal PresetShadowEffectiveData presetShadowEffectiveData_0;

	internal ReflectionEffectiveData reflectionEffectiveData_0;

	internal SoftEdgeEffectiveData softEdgeEffectiveData_0;

	public bool IsNoEffects
	{
		get
		{
			if (blurEffectiveData_0 == null && fillOverlayEffectiveData_0 == null && glowEffectiveData_0 == null && innerShadowEffectiveData_0 == null && outerShadowEffectiveData_0 == null && presetShadowEffectiveData_0 == null && reflectionEffectiveData_0 == null)
			{
				return softEdgeEffectiveData_0 == null;
			}
			return false;
		}
	}

	public IBlurEffectiveData BlurEffect => blurEffectiveData_0;

	public IFillOverlayEffectiveData FillOverlayEffect => fillOverlayEffectiveData_0;

	public IGlowEffectiveData GlowEffect => glowEffectiveData_0;

	public IInnerShadowEffectiveData InnerShadowEffect => innerShadowEffectiveData_0;

	public IOuterShadowEffectiveData OuterShadowEffect => outerShadowEffectiveData_0;

	public IPresetShadowEffectiveData PresetShadowEffect => presetShadowEffectiveData_0;

	public IReflectionEffectiveData ReflectionEffect => reflectionEffectiveData_0;

	public ISoftEdgeEffectiveData SoftEdgeEffect => softEdgeEffectiveData_0;

	internal EffectFormatEffectiveData()
	{
	}

	internal EffectFormatEffectiveData(IEffectFormat source, BaseSlide slide, FloatColor styleColor)
	{
		method_0(source, slide, styleColor);
	}

	internal void method_0(IEffectFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			if (source.BlurEffect != null)
			{
				blurEffectiveData_0 = (BlurEffectiveData)((IEffect)source.BlurEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				blurEffectiveData_0 = null;
			}
			if (source.FillOverlayEffect != null)
			{
				fillOverlayEffectiveData_0 = (FillOverlayEffectiveData)((IEffect)source.FillOverlayEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				fillOverlayEffectiveData_0 = null;
			}
			if (source.GlowEffect != null)
			{
				glowEffectiveData_0 = (GlowEffectiveData)((IEffect)source.GlowEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				glowEffectiveData_0 = null;
			}
			if (source.InnerShadowEffect != null)
			{
				innerShadowEffectiveData_0 = (InnerShadowEffectiveData)((IEffect)source.InnerShadowEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				innerShadowEffectiveData_0 = null;
			}
			if (source.OuterShadowEffect != null)
			{
				outerShadowEffectiveData_0 = (OuterShadowEffectiveData)((IEffect)source.OuterShadowEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				outerShadowEffectiveData_0 = null;
			}
			if (source.PresetShadowEffect != null)
			{
				presetShadowEffectiveData_0 = (PresetShadowEffectiveData)((IEffect)source.PresetShadowEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				presetShadowEffectiveData_0 = null;
			}
			if (source.ReflectionEffect != null)
			{
				reflectionEffectiveData_0 = (ReflectionEffectiveData)((IEffect)source.ReflectionEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				reflectionEffectiveData_0 = null;
			}
			if (source.SoftEdgeEffect != null)
			{
				softEdgeEffectiveData_0 = (SoftEdgeEffectiveData)((IEffect)source.SoftEdgeEffect).GetReadonly(slide, styleColor);
			}
			else
			{
				softEdgeEffectiveData_0 = null;
			}
		}
	}

	internal void method_1(IEffectFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			if (source.BlurEffect != null)
			{
				blurEffectiveData_0 = (BlurEffectiveData)((IEffect)source.BlurEffect).GetReadonly(slide, styleColor);
			}
			if (source.FillOverlayEffect != null)
			{
				fillOverlayEffectiveData_0 = (FillOverlayEffectiveData)((IEffect)source.FillOverlayEffect).GetReadonly(slide, styleColor);
			}
			if (source.GlowEffect != null)
			{
				glowEffectiveData_0 = (GlowEffectiveData)((IEffect)source.GlowEffect).GetReadonly(slide, styleColor);
			}
			if (source.InnerShadowEffect != null)
			{
				innerShadowEffectiveData_0 = (InnerShadowEffectiveData)((IEffect)source.InnerShadowEffect).GetReadonly(slide, styleColor);
			}
			if (source.OuterShadowEffect != null)
			{
				outerShadowEffectiveData_0 = (OuterShadowEffectiveData)((IEffect)source.OuterShadowEffect).GetReadonly(slide, styleColor);
			}
			if (source.PresetShadowEffect != null)
			{
				presetShadowEffectiveData_0 = (PresetShadowEffectiveData)((IEffect)source.PresetShadowEffect).GetReadonly(slide, styleColor);
			}
			if (source.ReflectionEffect != null)
			{
				reflectionEffectiveData_0 = (ReflectionEffectiveData)((IEffect)source.ReflectionEffect).GetReadonly(slide, styleColor);
			}
			if (source.SoftEdgeEffect != null)
			{
				softEdgeEffectiveData_0 = (SoftEdgeEffectiveData)((IEffect)source.SoftEdgeEffect).GetReadonly(slide, styleColor);
			}
		}
	}
}
