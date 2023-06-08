using System.Drawing;
using ns33;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaModulateFixed : ImageTransformOperation, IImageTransformOperation, IAlphaModulateFixed, IEffect
{
	private float float_0;

	public float Amount
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

	IImageTransformOperation IAlphaModulateFixed.AsIImageTransformOperation => this;

	internal AlphaModulateFixed(float amount, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = Class1165.smethod_5(amount, 0f, float.PositiveInfinity);
	}

	private Color method_1(Color c)
	{
		return Color.FromArgb(Class1165.smethod_4((int)((float)(int)c.A * float_0 / 100f), 0, 255), c);
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		float num = float_0 / 100f;
		img.method_3();
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			int num3 = (num2 >> 24) & 0xFF;
			num3 = Class1165.smethod_4((int)((float)num3 * num), 0, 255);
			img.Bits[i] = (num3 << 24) | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new AlphaModulateFixedEffectiveData(float_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class28(float_0);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0;
	}
}
