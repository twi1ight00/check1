using System;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaBiLevel : ImageTransformOperation, IImageTransformOperation, IAlphaBiLevel, IEffect
{
	private float float_0;

	public float Threshold
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_0();
		}
	}

	IImageTransformOperation IAlphaBiLevel.AsIImageTransformOperation => this;

	internal AlphaBiLevel(float threshold, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = threshold;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		int num = (int)Math.Round(2.55 * (double)float_0);
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			int num3 = (num2 >> 24) & 0xFF;
			num3 = ((num3 >= num) ? 255 : 0);
			img.Bits[i] = (num3 << 24) | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new AlphaBiLevelEffectiveData(float_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class23(float_0);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0;
	}
}
