using System;
using Aspose.Slides.Effects;
using ns33;

namespace ns5;

internal class Class40 : EffectEffectiveDataPVITemp, ILuminanceEffectiveData
{
	private float float_0;

	private float float_1;

	public float Brightness => float_0;

	public float Contrast => float_1;

	internal Class40(float brightness, float contrast)
	{
		float_0 = brightness;
		float_1 = contrast;
	}

	internal override Class190 vmethod_0(Class190 img)
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

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0 + ' ' + float_1;
	}
}
