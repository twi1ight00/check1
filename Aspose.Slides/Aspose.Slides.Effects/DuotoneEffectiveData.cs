using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class DuotoneEffectiveData : EffectEffectiveData, IDuotoneEffectiveData
{
	private Color color_0;

	private Color color_1;

	public Color Color1 => color_0;

	public Color Color2 => color_1;

	internal DuotoneEffectiveData(Color c1, Color c2)
	{
		color_0 = c1;
		color_1 = c2;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color color = color_0;
		Color color2 = color_1;
		int r = color.R;
		int num = color2.R - r;
		int g = color.G;
		int num2 = color2.G - g;
		int b = color.B;
		int num3 = color2.B - b;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num4 = img.Bits[i];
			int num5 = (num4 >> 24) & 0xFF;
			int num6 = (num4 >> 16) & 0xFF;
			int num7 = (num4 >> 8) & 0xFF;
			int num8 = num4 & 0xFF;
			float num9 = ((float)num6 * 0.2126f + (float)num7 * 0.7151f + (float)num8 * 0.0722f) / 255f;
			img.Bits[i] = (num5 << 24) + ((int)((float)r + (float)num * num9) << 16) + ((int)((float)g + (float)num2 * num9) << 8) + (int)((float)b + (float)num3 * num9);
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return string.Concat(base.vmethod_1(), color_0, ' ', color_1);
	}
}
