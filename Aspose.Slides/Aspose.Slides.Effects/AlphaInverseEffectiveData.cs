using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class AlphaInverseEffectiveData : EffectEffectiveData, IAlphaInverseEffectiveData
{
	private Color color_0;

	internal Color Color => color_0;

	internal AlphaInverseEffectiveData(Color color)
	{
		color_0 = color;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			num2 = 255 - num2;
			img.Bits[i] = (num2 << 24) | (img.Bits[i] & 0xFFFFFF);
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + color_0;
	}
}
