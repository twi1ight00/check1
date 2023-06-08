using Aspose.Slides;
using Aspose.Slides.Effects;

namespace ns5;

internal class Class45 : EffectEffectiveDataPVITemp, ITintEffectiveData
{
	private readonly float float_0;

	private readonly float float_1;

	public float Hue => float_0;

	public float Amount => float_1;

	internal Class45(float hue, float amount)
	{
		float_0 = hue;
		float_1 = amount;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		float num = float_1 / 100f;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			int num3 = (num2 >> 24) & 0xFF;
			int num4 = (num2 >> 16) & 0xFF;
			int num5 = (num2 >> 8) & 0xFF;
			int num6 = num2 & 0xFF;
			ColorFormat.smethod_4((float)num4 / 255f, (float)num5 / 255f, (float)num6 / 255f, out var hue, out var saturation, out var luminance);
			float num7 = float_0 - hue;
			num7 %= 360f;
			if (num7 < -180f)
			{
				num7 += 360f;
			}
			else if (num7 > 180f)
			{
				num7 -= 360f;
			}
			hue += num7 * num;
			hue %= 360f;
			FloatColor floatColor = ColorFormat.smethod_3(hue, saturation, luminance);
			img.Bits[i] = (num3 << 24) + ((int)(floatColor.float_1 * 255f) << 16) + ((int)(floatColor.float_2 * 255f) << 8) + (int)(floatColor.float_3 * 255f);
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0 + ' ' + float_1;
	}
}
