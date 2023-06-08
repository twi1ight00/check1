using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class34 : EffectEffectiveDataPVITemp, IDuotoneEffectiveData
{
	private Class18 class18_0;

	private Class18 class18_1;

	public Color Color1 => class18_0.Color;

	public Color Color2 => class18_1.Color;

	internal Class34(Class21.Delegate2 color1Resolver, Class21.Delegate2 color2Resolver)
	{
		class18_0 = new Class18(color1Resolver);
		class18_1 = new Class18(color2Resolver);
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color color = Color1;
		Color color2 = Color2;
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
		return string.Concat(base.vmethod_1(), Color1, ' ', Color2);
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
		class18_1.method_0(slide, styleColor);
	}
}
