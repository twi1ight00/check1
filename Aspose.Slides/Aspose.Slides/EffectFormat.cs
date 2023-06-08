using System;
using Aspose.Slides.Effects;

namespace Aspose.Slides;

public class EffectFormat : IEffectFormat
{
	private Blur blur_0;

	private FillOverlay fillOverlay_0;

	private Glow glow_0;

	private InnerShadow innerShadow_0;

	private OuterShadow outerShadow_0;

	private PresetShadow presetShadow_0;

	private Reflection reflection_0;

	private SoftEdge softEdge_0;

	private readonly IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public bool IsNoEffects
	{
		get
		{
			if (blur_0 == null && fillOverlay_0 == null && glow_0 == null && innerShadow_0 == null && outerShadow_0 == null && presetShadow_0 == null && reflection_0 == null)
			{
				return softEdge_0 == null;
			}
			return false;
		}
	}

	public IBlur BlurEffect
	{
		get
		{
			return blur_0;
		}
		set
		{
			if (value == null && blur_0 != null)
			{
				uint_0 += blur_0.Version;
			}
			blur_0 = (Blur)value;
			if (blur_0 != null)
			{
				if (blur_0.Parent != null)
				{
					blur_0 = (Blur)blur_0.Clone();
				}
				blur_0.vmethod_2(Parent);
			}
			method_2();
		}
	}

	public IFillOverlay FillOverlayEffect
	{
		get
		{
			return fillOverlay_0;
		}
		set
		{
			if (value == null && fillOverlay_0 != null)
			{
				uint_0 += fillOverlay_0.Version;
			}
			fillOverlay_0 = (FillOverlay)value;
			if (fillOverlay_0 != null)
			{
				if (fillOverlay_0.Parent != null)
				{
					fillOverlay_0 = (FillOverlay)fillOverlay_0.Clone();
				}
				fillOverlay_0.vmethod_2(Parent);
			}
			method_2();
		}
	}

	public IGlow GlowEffect
	{
		get
		{
			return glow_0;
		}
		set
		{
			if (value == null && glow_0 != null)
			{
				uint_0 += glow_0.Version;
			}
			glow_0 = (Glow)value;
			if (glow_0 != null)
			{
				if (glow_0.Parent != null)
				{
					glow_0 = glow_0.Clone();
				}
				glow_0.method_6(Parent);
			}
			method_2();
		}
	}

	public IInnerShadow InnerShadowEffect
	{
		get
		{
			return innerShadow_0;
		}
		set
		{
			if (value == null && innerShadow_0 != null)
			{
				uint_0 += innerShadow_0.Version;
			}
			innerShadow_0 = (InnerShadow)value;
			if (innerShadow_0 != null)
			{
				if (innerShadow_0.Parent != null)
				{
					innerShadow_0 = innerShadow_0.Clone();
				}
				innerShadow_0.method_0(Parent);
			}
			method_2();
		}
	}

	public IOuterShadow OuterShadowEffect
	{
		get
		{
			return outerShadow_0;
		}
		set
		{
			if (value == null && outerShadow_0 != null)
			{
				uint_0 += outerShadow_0.Version;
			}
			outerShadow_0 = (OuterShadow)value;
			if (outerShadow_0 != null)
			{
				if (outerShadow_0.Parent != null)
				{
					outerShadow_0 = outerShadow_0.Clone();
				}
				outerShadow_0.method_1(Parent);
			}
			method_2();
		}
	}

	public IPresetShadow PresetShadowEffect
	{
		get
		{
			return presetShadow_0;
		}
		set
		{
			if (value == null && presetShadow_0 != null)
			{
				uint_0 += presetShadow_0.Version;
			}
			presetShadow_0 = (PresetShadow)value;
			if (presetShadow_0 != null)
			{
				if (presetShadow_0.Parent != null)
				{
					presetShadow_0 = presetShadow_0.Clone();
				}
				presetShadow_0.method_0(Parent);
			}
			method_2();
		}
	}

	public IReflection ReflectionEffect
	{
		get
		{
			return reflection_0;
		}
		set
		{
			if (value == null && reflection_0 != null)
			{
				uint_0 += reflection_0.Version;
			}
			reflection_0 = (Reflection)value;
			if (reflection_0 != null)
			{
				if (reflection_0.Parent != null)
				{
					reflection_0 = reflection_0.Clone();
				}
				reflection_0.method_2(Parent);
			}
			method_2();
		}
	}

	public ISoftEdge SoftEdgeEffect
	{
		get
		{
			return softEdge_0;
		}
		set
		{
			if (value == null && softEdge_0 != null)
			{
				uint_0 += softEdge_0.Version;
			}
			softEdge_0 = (SoftEdge)value;
			if (softEdge_0 != null)
			{
				if (softEdge_0.Parent != null)
				{
					softEdge_0 = softEdge_0.Clone();
				}
				softEdge_0.method_0(Parent);
			}
			method_2();
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal IBaseSlide Slide
	{
		get
		{
			if (!(ipresentationComponent_0 is ISlideComponent slideComponent))
			{
				return null;
			}
			return slideComponent.Slide;
		}
	}

	internal uint Version => uint_0 + ((blur_0 != null) ? blur_0.Version : 0) + ((fillOverlay_0 != null) ? fillOverlay_0.Version : 0) + ((glow_0 != null) ? glow_0.Version : 0) + ((innerShadow_0 != null) ? innerShadow_0.Version : 0) + ((outerShadow_0 != null) ? outerShadow_0.Version : 0) + ((presetShadow_0 != null) ? presetShadow_0.Version : 0) + ((reflection_0 != null) ? reflection_0.Version : 0) + ((softEdge_0 != null) ? softEdge_0.Version : 0);

	internal EffectFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
	}

	public void SetBlurEffect(double radius, bool grow)
	{
		if (blur_0 == null)
		{
			blur_0 = new Blur(radius, grow, Parent);
			method_2();
		}
		else
		{
			blur_0.Radius = radius;
			blur_0.Grow = grow;
		}
	}

	public void EnableFillOverlayEffect()
	{
		if (fillOverlay_0 == null)
		{
			fillOverlay_0 = new FillOverlay(Parent);
			method_2();
		}
	}

	public void EnableGlowEffect()
	{
		if (glow_0 == null)
		{
			glow_0 = new Glow(Parent);
			method_2();
		}
	}

	public void EnableInnerShadowEffect()
	{
		if (innerShadow_0 == null)
		{
			innerShadow_0 = new InnerShadow(Parent);
			method_2();
		}
	}

	public void EnableOuterShadowEffect()
	{
		if (outerShadow_0 == null)
		{
			outerShadow_0 = new OuterShadow(Parent);
			method_2();
		}
	}

	public void EnablePresetShadowEffect()
	{
		if (presetShadow_0 == null)
		{
			presetShadow_0 = new PresetShadow(Parent);
			method_2();
		}
	}

	public void EnableReflectionEffect()
	{
		if (reflection_0 == null)
		{
			reflection_0 = new Reflection(Parent);
			method_2();
		}
	}

	public void EnableSoftEdgeEffect()
	{
		if (softEdge_0 == null)
		{
			softEdge_0 = new SoftEdge(Parent);
			method_2();
		}
	}

	public void DisableBlurEffect()
	{
		BlurEffect = null;
	}

	public void DisableFillOverlayEffect()
	{
		FillOverlayEffect = null;
	}

	public void DisableGlowEffect()
	{
		GlowEffect = null;
	}

	public void DisableInnerShadowEffect()
	{
		InnerShadowEffect = null;
	}

	public void DisableOuterShadowEffect()
	{
		OuterShadowEffect = null;
	}

	public void DisablePresetShadowEffect()
	{
		PresetShadowEffect = null;
	}

	public void DisableReflectionEffect()
	{
		ReflectionEffect = null;
	}

	public void DisableSoftEdgeEffect()
	{
		SoftEdgeEffect = null;
	}

	internal void method_0(EffectFormat source)
	{
		uint_0 = Version;
		method_2();
		if (source.blur_0 != null)
		{
			blur_0 = new Blur(source.blur_0.Radius, source.blur_0.Grow, Parent);
		}
		else
		{
			blur_0 = null;
		}
		if (source.fillOverlay_0 != null)
		{
			fillOverlay_0 = new FillOverlay(Parent);
			fillOverlay_0.Blend = source.fillOverlay_0.Blend;
			((FillFormat)fillOverlay_0.FillFormat).method_0((FillFormat)source.fillOverlay_0.FillFormat);
		}
		else
		{
			fillOverlay_0 = null;
		}
		if (source.glow_0 != null)
		{
			glow_0 = new Glow(Parent);
			glow_0.Radius = source.GlowEffect.Radius;
			((ColorFormat)glow_0.Color).method_0((ColorFormat)source.GlowEffect.Color);
		}
		else
		{
			glow_0 = null;
		}
		if (source.innerShadow_0 != null)
		{
			innerShadow_0 = new InnerShadow(Parent);
			innerShadow_0.BlurRadius = source.innerShadow_0.BlurRadius;
			innerShadow_0.Direction = source.innerShadow_0.Direction;
			innerShadow_0.Distance = source.innerShadow_0.Distance;
			((ColorFormat)innerShadow_0.ShadowColor).method_0((ColorFormat)source.innerShadow_0.ShadowColor);
		}
		else
		{
			innerShadow_0 = null;
		}
		if (source.outerShadow_0 != null)
		{
			outerShadow_0 = new OuterShadow(Parent);
			outerShadow_0.BlurRadius = source.outerShadow_0.BlurRadius;
			outerShadow_0.Direction = source.outerShadow_0.Direction;
			outerShadow_0.Distance = source.outerShadow_0.Distance;
			outerShadow_0.RectangleAlign = source.outerShadow_0.RectangleAlign;
			outerShadow_0.RotateShadowWithShape = source.outerShadow_0.RotateShadowWithShape;
			outerShadow_0.ScaleHorizontal = source.outerShadow_0.ScaleHorizontal;
			outerShadow_0.ScaleVertical = source.outerShadow_0.ScaleVertical;
			((ColorFormat)outerShadow_0.ShadowColor).method_0((ColorFormat)source.outerShadow_0.ShadowColor);
			outerShadow_0.SkewHorizontal = source.outerShadow_0.SkewHorizontal;
			outerShadow_0.SkewVertical = source.outerShadow_0.SkewVertical;
		}
		else
		{
			outerShadow_0 = null;
		}
		if (source.presetShadow_0 != null)
		{
			presetShadow_0 = new PresetShadow(Parent);
			presetShadow_0.Direction = source.PresetShadowEffect.Direction;
			presetShadow_0.Distance = source.PresetShadowEffect.Distance;
			presetShadow_0.Preset = source.PresetShadowEffect.Preset;
			((ColorFormat)presetShadow_0.ShadowColor).method_0((ColorFormat)source.PresetShadowEffect.ShadowColor);
		}
		else
		{
			presetShadow_0 = null;
		}
		if (source.reflection_0 != null)
		{
			reflection_0 = new Reflection(Parent);
			reflection_0.BlurRadius = source.reflection_0.BlurRadius;
			reflection_0.Direction = source.reflection_0.Direction;
			reflection_0.Distance = source.reflection_0.Distance;
			reflection_0.EndPosAlpha = source.reflection_0.EndPosAlpha;
			reflection_0.EndReflectionOpacity = source.reflection_0.EndReflectionOpacity;
			reflection_0.FadeDirection = source.reflection_0.FadeDirection;
			reflection_0.RectangleAlign = source.reflection_0.RectangleAlign;
			reflection_0.RotateShadowWithShape = source.reflection_0.RotateShadowWithShape;
			reflection_0.ScaleHorizontal = source.reflection_0.ScaleHorizontal;
			reflection_0.ScaleVertical = source.reflection_0.ScaleVertical;
			reflection_0.SkewHorizontal = source.reflection_0.SkewHorizontal;
			reflection_0.SkewVertical = source.reflection_0.SkewVertical;
			reflection_0.StartPosAlpha = source.reflection_0.StartPosAlpha;
			reflection_0.StartReflectionOpacity = source.reflection_0.StartReflectionOpacity;
		}
		else
		{
			reflection_0 = null;
		}
		if (source.softEdge_0 != null)
		{
			softEdge_0 = new SoftEdge(Parent);
			softEdge_0.Radius = source.softEdge_0.Radius;
		}
		else
		{
			softEdge_0 = null;
		}
	}

	internal void method_1(EffectFormatEffectiveData source)
	{
		if (source.blurEffectiveData_0 != null)
		{
			blur_0 = new Blur(source.blurEffectiveData_0.Radius, source.blurEffectiveData_0.Grow, Parent);
		}
		else
		{
			blur_0 = null;
		}
		if (source.fillOverlayEffectiveData_0 != null)
		{
			fillOverlay_0 = new FillOverlay(Parent);
			fillOverlay_0.Blend = source.fillOverlayEffectiveData_0.Blend;
			((FillFormat)fillOverlay_0.FillFormat).method_1(source.fillOverlayEffectiveData_0.fillFormatEffectiveData_0);
		}
		else
		{
			fillOverlay_0 = null;
		}
		if (source.glowEffectiveData_0 != null)
		{
			glow_0 = new Glow(Parent);
			glow_0.Radius = source.GlowEffect.Radius;
			((ColorFormat)glow_0.Color).method_1(source.GlowEffect.Color);
		}
		else
		{
			glow_0 = null;
		}
		if (source.innerShadowEffectiveData_0 != null)
		{
			innerShadow_0 = new InnerShadow(Parent);
			innerShadow_0.BlurRadius = source.innerShadowEffectiveData_0.BlurRadius;
			innerShadow_0.Direction = source.innerShadowEffectiveData_0.Direction;
			innerShadow_0.Distance = source.innerShadowEffectiveData_0.Distance;
			((ColorFormat)innerShadow_0.ShadowColor).method_1(source.innerShadowEffectiveData_0.ShadowColor);
		}
		else
		{
			innerShadow_0 = null;
		}
		if (source.outerShadowEffectiveData_0 != null)
		{
			outerShadow_0 = new OuterShadow(Parent);
			outerShadow_0.BlurRadius = source.outerShadowEffectiveData_0.BlurRadius;
			outerShadow_0.Direction = source.outerShadowEffectiveData_0.Direction;
			outerShadow_0.Distance = source.outerShadowEffectiveData_0.Distance;
			outerShadow_0.RectangleAlign = source.outerShadowEffectiveData_0.RectangleAlign;
			outerShadow_0.RotateShadowWithShape = source.outerShadowEffectiveData_0.RotateShadowWithShape;
			outerShadow_0.ScaleHorizontal = source.outerShadowEffectiveData_0.ScaleHorizontal;
			outerShadow_0.ScaleVertical = source.outerShadowEffectiveData_0.ScaleVertical;
			((ColorFormat)outerShadow_0.ShadowColor).method_1(source.outerShadowEffectiveData_0.ShadowColor);
			outerShadow_0.SkewHorizontal = source.outerShadowEffectiveData_0.SkewHorizontal;
			outerShadow_0.SkewVertical = source.outerShadowEffectiveData_0.SkewVertical;
		}
		else
		{
			outerShadow_0 = null;
		}
		if (source.presetShadowEffectiveData_0 != null)
		{
			presetShadow_0 = new PresetShadow(Parent);
			presetShadow_0.Direction = source.PresetShadowEffect.Direction;
			presetShadow_0.Distance = source.PresetShadowEffect.Distance;
			presetShadow_0.Preset = source.PresetShadowEffect.Preset;
			((ColorFormat)presetShadow_0.ShadowColor).method_1(source.PresetShadowEffect.ShadowColor);
		}
		else
		{
			presetShadow_0 = null;
		}
		if (source.reflectionEffectiveData_0 != null)
		{
			reflection_0 = new Reflection(Parent);
			reflection_0.BlurRadius = source.reflectionEffectiveData_0.BlurRadius;
			reflection_0.Direction = source.reflectionEffectiveData_0.Direction;
			reflection_0.Distance = source.reflectionEffectiveData_0.Distance;
			reflection_0.EndPosAlpha = source.reflectionEffectiveData_0.EndPosAlpha;
			reflection_0.EndReflectionOpacity = source.reflectionEffectiveData_0.EndReflectionOpacity;
			reflection_0.FadeDirection = source.reflectionEffectiveData_0.FadeDirection;
			reflection_0.RectangleAlign = source.reflectionEffectiveData_0.RectangleAlign;
			reflection_0.RotateShadowWithShape = source.reflectionEffectiveData_0.RotateShadowWithShape;
			reflection_0.ScaleHorizontal = source.reflectionEffectiveData_0.ScaleHorizontal;
			reflection_0.ScaleVertical = source.reflectionEffectiveData_0.ScaleVertical;
			reflection_0.SkewHorizontal = source.reflectionEffectiveData_0.SkewHorizontal;
			reflection_0.SkewVertical = source.reflectionEffectiveData_0.SkewVertical;
			reflection_0.StartPosAlpha = source.reflectionEffectiveData_0.StartPosAlpha;
			reflection_0.StartReflectionOpacity = source.reflectionEffectiveData_0.StartReflectionOpacity;
		}
		else
		{
			reflection_0 = null;
		}
		if (source.softEdgeEffectiveData_0 != null)
		{
			softEdge_0 = new SoftEdge(Parent);
			softEdge_0.Radius = source.softEdgeEffectiveData_0.Radius;
		}
		else
		{
			softEdge_0 = null;
		}
		method_2();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is EffectFormat effectFormat))
		{
			return base.Equals(obj);
		}
		if (((blur_0 == null && effectFormat.blur_0 == null) || (blur_0 != null && blur_0.Equals(effectFormat.blur_0))) && ((fillOverlay_0 == null && effectFormat.fillOverlay_0 == null) || (fillOverlay_0 != null && fillOverlay_0.Equals(effectFormat.fillOverlay_0))) && ((glow_0 == null && effectFormat.glow_0 == null) || (glow_0 != null && glow_0.Equals(effectFormat.glow_0))) && ((innerShadow_0 == null && effectFormat.innerShadow_0 == null) || (innerShadow_0 != null && innerShadow_0.Equals(effectFormat.innerShadow_0))) && ((outerShadow_0 == null && effectFormat.outerShadow_0 == null) || (outerShadow_0 != null && outerShadow_0.Equals(effectFormat.outerShadow_0))) && ((presetShadow_0 == null && effectFormat.presetShadow_0 == null) || (presetShadow_0 != null && presetShadow_0.Equals(effectFormat.presetShadow_0))) && ((reflection_0 == null && effectFormat.reflection_0 == null) || (reflection_0 != null && reflection_0.Equals(effectFormat.reflection_0))))
		{
			if (softEdge_0 == null && effectFormat.softEdge_0 == null)
			{
				return true;
			}
			if (softEdge_0 != null)
			{
				return softEdge_0.Equals(effectFormat.softEdge_0);
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void method_2()
	{
		uint_0++;
	}
}
