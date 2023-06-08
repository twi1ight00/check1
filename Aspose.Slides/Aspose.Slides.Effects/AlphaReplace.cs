using System;
using ns33;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaReplace : ImageTransformOperation, IImageTransformOperation, IAlphaReplace, IEffect
{
	private float float_0;

	internal float Alpha
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

	IImageTransformOperation IAlphaReplace.AsIImageTransformOperation => this;

	internal AlphaReplace(float alpha, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = alpha;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		if (float_0 < 100f)
		{
			img.method_1();
		}
		else
		{
			img.method_2();
		}
		int num = Class1165.smethod_4((int)Math.Round(float_0 * 255f / 100f), 0, 255) << 24;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			img.Bits[i] = num | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new AlphaReplaceEffectiveData(float_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class29(float_0);
	}
}
