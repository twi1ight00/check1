using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class33 : EffectEffectiveDataPVITemp, IColorReplaceEffectiveData
{
	private Class18 class18_0;

	public Color Color => class18_0.Color;

	internal Class33(Class21.Delegate2 colorResolver)
	{
		class18_0 = new Class18(colorResolver);
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color color = Color;
		int num = (color.R << 16) | (color.G << 8) | color.B;
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num2 = img.Bits[i];
			img.Bits[i] = num | (num2 & -16777216);
		}
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + Color;
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
	}
}
