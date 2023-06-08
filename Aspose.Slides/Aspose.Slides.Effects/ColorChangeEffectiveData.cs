using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class ColorChangeEffectiveData : EffectEffectiveData, IColorChangeEffectiveData
{
	private Color color_0;

	private Color color_1;

	private bool bool_0;

	public Color FromColor => color_0;

	public Color ToColor => color_1;

	public bool UseAlpha => bool_0;

	internal ColorChangeEffectiveData(Color colorFrom, Color colorTo, bool useAlpha)
	{
		color_0 = colorFrom;
		color_1 = colorTo;
		bool_0 = useAlpha;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color color = color_0;
		Color color2 = color_1;
		int num = color.R - 17;
		int num2 = color.R + 17;
		int num3 = color.G - 17;
		int num4 = color.G + 17;
		int num5 = color.B - 17;
		int num6 = color.B + 17;
		int num7 = (color2.R << 16) + (color2.G << 8) + color2.B;
		if (bool_0)
		{
			num7 += color2.A << 24;
			int num8 = color.A - 17;
			int num9 = color.A + 17;
			for (int i = 0; i < img.Bits.Length; i++)
			{
				int num10 = img.Bits[i];
				int num11 = (num10 >> 24) & 0xFF;
				int num12 = (num10 >> 16) & 0xFF;
				int num13 = (num10 >> 8) & 0xFF;
				int num14 = num10 & 0xFF;
				if (num8 < num11 && num11 < num9 && num < num12 && num12 < num2 && num3 < num13 && num13 < num4 && num5 < num14 && num14 < num6)
				{
					img.Bits[i] = num7;
				}
			}
		}
		else
		{
			for (int j = 0; j < img.Bits.Length; j++)
			{
				int num15 = img.Bits[j];
				int num16 = (num15 >> 24) & 0xFF;
				int num17 = (num15 >> 16) & 0xFF;
				int num18 = (num15 >> 8) & 0xFF;
				int num19 = num15 & 0xFF;
				if (num < num17 && num17 < num2 && num3 < num18 && num18 < num4 && num5 < num19 && num19 < num6)
				{
					img.Bits[j] = (num16 << 24) | num7;
				}
			}
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return string.Concat(base.vmethod_1(), color_0, " ", color_1, ' ', bool_0);
	}
}
