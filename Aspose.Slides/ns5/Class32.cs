using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class32 : EffectEffectiveDataPVITemp, IColorChangeEffectiveData
{
	private Class18 class18_0;

	private Class18 class18_1;

	private bool bool_0;

	public Color FromColor => class18_0.Color;

	public Color ToColor => class18_1.Color;

	public bool UseAlpha => bool_0;

	internal Class32(Class21.Delegate2 fromColorResolver, Class21.Delegate2 toColorResolver, bool useAlpha)
	{
		class18_0 = new Class18(fromColorResolver);
		class18_1 = new Class18(toColorResolver);
		bool_0 = useAlpha;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color fromColor = FromColor;
		Color toColor = ToColor;
		int num = fromColor.R - 17;
		int num2 = fromColor.R + 17;
		int num3 = fromColor.G - 17;
		int num4 = fromColor.G + 17;
		int num5 = fromColor.B - 17;
		int num6 = fromColor.B + 17;
		int num7 = (toColor.R << 16) + (toColor.G << 8) + toColor.B;
		if (bool_0)
		{
			num7 += toColor.A << 24;
			int num8 = fromColor.A - 17;
			int num9 = fromColor.A + 17;
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
		return string.Concat(base.vmethod_1(), FromColor, " ", ToColor, ' ', bool_0);
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
		class18_1.method_0(slide, styleColor);
	}
}
