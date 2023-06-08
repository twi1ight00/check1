using ns33;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaModulateFixedEffectiveData : EffectEffectiveData, IAlphaModulateFixedEffectiveData
{
	private float float_0;

	public float Amount => float_0;

	internal AlphaModulateFixedEffectiveData(float amount)
	{
		float_0 = Class1165.smethod_5(amount, 0f, float.PositiveInfinity);
	}

	internal override Class190 vmethod_0(Class190 img)
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

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0;
	}
}
