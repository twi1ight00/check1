using Aspose.Slides;
using Aspose.Slides.Effects;
using ns33;

namespace ns5;

internal class Class38 : EffectEffectiveDataPVITemp, IHSLEffectiveData
{
	private float float_0;

	private float float_1;

	private float float_2;

	public float Hue => float_0;

	public float Saturation => float_1;

	public float Luminance => float_2;

	internal Class38(float hue, float saturation, float luminance)
	{
		float_0 = hue;
		float_1 = saturation;
		float_2 = luminance;
	}

	internal override Class190 vmethod_0(Class190 img)
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

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0 + ' ' + float_1 + ' ' + float_2;
	}
}
