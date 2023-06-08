using System;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaBiLevelEffectiveData : EffectEffectiveData, IAlphaBiLevelEffectiveData
{
	private readonly float float_0;

	public float Threshold => float_0;

	internal AlphaBiLevelEffectiveData(float threshold)
	{
		float_0 = threshold;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		int num = (int)Math.Round(2.55 * (double)float_0);
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			int num3 = (num2 >> 24) & 0xFF;
			num3 = ((num3 >= num) ? 255 : 0);
			img.Bits[i] = (num3 << 24) | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + float_0;
	}
}
