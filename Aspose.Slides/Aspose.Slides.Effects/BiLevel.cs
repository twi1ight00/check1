using ns5;

namespace Aspose.Slides.Effects;

public class BiLevel : ImageTransformOperation, IImageTransformOperation, IBiLevel, IEffect
{
	private float float_0;

	internal float Threshold
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

	IImageTransformOperation IBiLevel.AsIImageTransformOperation => this;

	internal BiLevel(float threshold, IPresentationComponent parent)
		: base(parent)
	{
		float_0 = threshold;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		float num = 255f * float_0 / 100f;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			int num3 = (num2 >> 24) & 0xFF;
			int num4 = (num2 >> 16) & 0xFF;
			int num5 = (num2 >> 8) & 0xFF;
			int num6 = num2 & 0xFF;
			img.Bits[i] = (num3 << 24) + (((double)num4 * 0.2126 + (double)num5 * 0.7151 + (double)num6 * 0.0722 > (double)num) ? 16777215 : 0);
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new BiLevelEffectiveData(float_0);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class30(float_0);
	}

	internal override string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return base.vmethod_1(slide, styleColor) + float_0;
	}
}
