using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ClassInterface(ClassInterfaceType.None)]
[Guid("12B1A87A-D139-4DFA-9B9F-7EAE94EF1A68")]
[ComVisible(true)]
public class PresetShadow : IPresetShadow, IEffect
{
	private float float_0;

	private double double_0;

	private ColorFormat colorFormat_0;

	private PresetShadowType presetShadowType_0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public float Direction
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_1();
		}
	}

	public double Distance
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_1();
		}
	}

	public IColorFormat ShadowColor => colorFormat_0;

	public PresetShadowType Preset
	{
		get
		{
			return presetShadowType_0;
		}
		set
		{
			presetShadowType_0 = value;
			method_1();
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0 + colorFormat_0.Version;

	internal PresetShadow(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
	}

	internal PresetShadow Clone()
	{
		PresetShadow presetShadow = (PresetShadow)MemberwiseClone();
		presetShadow.colorFormat_0 = new ColorFormat(null);
		presetShadow.colorFormat_0.method_0(colorFormat_0);
		return presetShadow;
	}

	internal void method_0(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0.Parent = parent as ISlideComponent;
		method_1();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new PresetShadowEffectiveData(float_0, double_0, presetShadowType_0, colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class42(float_0, double_0, presetShadowType_0, colorFormat_0.method_5);
	}

	private void method_1()
	{
		uint_0++;
	}
}
