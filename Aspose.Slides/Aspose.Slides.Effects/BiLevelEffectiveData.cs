using ns5;

namespace Aspose.Slides.Effects;

public class BiLevelEffectiveData : EffectEffectiveData, IBiLevelEffectiveData
{
	private readonly float float_0;

	public float Threshold => float_0;

	internal BiLevelEffectiveData(float threshold)
	{
		float_0 = threshold;
	}

	internal override Class190 vmethod_0(Class190 img)
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

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0;
	}
}
