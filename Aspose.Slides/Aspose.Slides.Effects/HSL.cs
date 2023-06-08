using System.Drawing;
using ns33;
using ns5;

namespace Aspose.Slides.Effects;

public class HSL : ImageTransformOperation, IImageTransformOperation, IHSL, IEffect
{
	private float float_0;

	private float float_1;

	private float float_2;

	internal float Hue
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

	internal float Saturation
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

	internal float Luminance
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			method_0();
		}
	}

	IImageTransformOperation IHSL.AsIImageTransformOperation => this;

	internal HSL(float hue, float saturation, float luminance, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = hue;
		float_1 = saturation;
		float_2 = luminance;
	}

	private Color method_1(Color c)
	{
		ColorFormat.smethod_4((float)(int)c.R / 255f, (float)(int)c.G / 255f, (float)(int)c.B / 255f, out var hue, out var saturation, out var luminance);
		hue += float_0 % 360f;
		if (hue < 0f)
		{
			hue += 360f;
		}
		return Color.FromArgb(c.A, ColorFormat.smethod_3(hue, Class1165.smethod_5(saturation * float_1 / 100f, 0f, 1f), Class1165.smethod_5(luminance * float_2 / 100f, 0f, 1f)).Color);
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		float num = float_1 / 100f;
		float num2 = float_2 / 100f;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num3 = img.Bits[i];
			int num4 = (num3 >> 24) & 0xFF;
			int num5 = (num3 >> 16) & 0xFF;
			int num6 = (num3 >> 8) & 0xFF;
			int num7 = num3 & 0xFF;
			ColorFormat.smethod_4((float)num5 / 255f, (float)num6 / 255f, (float)num7 / 255f, out var hue, out var saturation, out var luminance);
			hue += float_0 % 360f;
			if (hue < 0f)
			{
				hue += 360f;
			}
			FloatColor floatColor = ColorFormat.smethod_3(hue, Class1165.smethod_5(saturation * num, 0f, 1f), Class1165.smethod_5(luminance * num2, 0f, 1f));
			img.Bits[i] = (num4 << 24) + ((int)(floatColor.float_1 * 255f) << 16) + ((int)(floatColor.float_2 * 255f) << 8) + (int)(floatColor.float_3 * 255f);
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new HSLEffectiveData(float_0, float_1, float_2);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class38(float_0, float_1, float_2);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0 + ' ' + float_1 + ' ' + float_2;
	}
}
