using System;
using ns33;
using ns5;

namespace Aspose.Slides.Effects;

public class Luminance : ImageTransformOperation, IImageTransformOperation, ILuminance, IEffect
{
	private float float_0;

	private float float_1;

	internal float Brightness
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

	internal float Contrast
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_0();
		}
	}

	IImageTransformOperation ILuminance.AsIImageTransformOperation => this;

	internal Luminance(float brightness, float contrast, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = brightness;
		float_1 = contrast;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		float num = (float_0 / 100f / 2f - 0.5f) * 255f;
		float num2 = num + 255f;
		float num3 = (float)Math.Tan((double)(float_1 / 100f + 1f) * Math.PI / 4.0);
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num4 = img.Bits[i];
			int num5 = (num4 >> 24) & 0xFF;
			int num6 = (num4 >> 16) & 0xFF;
			int num7 = (num4 >> 8) & 0xFF;
			int num8 = num4 & 0xFF;
			num6 = (int)Math.Round(((float)num6 + num) * num3 + num2);
			num7 = (int)Math.Round(((float)num7 + num) * num3 + num2);
			num8 = (int)Math.Round(((float)num8 + num) * num3 + num2);
			img.Bits[i] = (num5 << 24) + (Class1165.smethod_4(num6, 0, 255) << 16) + (Class1165.smethod_4(num7, 0, 255) << 8) + Class1165.smethod_4(num8, 0, 255);
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new LuminanceEffectiveData(float_0, float_1);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class40(float_0, float_1);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0 + ' ' + float_1;
	}
}
