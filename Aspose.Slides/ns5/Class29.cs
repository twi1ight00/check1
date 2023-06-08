using System;
using Aspose.Slides.Effects;
using ns33;

namespace ns5;

internal class Class29 : EffectEffectiveDataPVITemp, IAlphaReplaceEffectiveData
{
	private readonly float float_0;

	public float Alpha => float_0;

	internal Class29(float alpha)
	{
		float_0 = alpha;
	}

	internal override Class190 vmethod_0(Class190 img)
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

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0;
	}
}
