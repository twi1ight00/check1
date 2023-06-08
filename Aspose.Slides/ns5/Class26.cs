using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;

namespace ns5;

internal class Class26 : EffectEffectiveDataPVITemp, IAlphaInverseEffectiveData
{
	private Class18 class18_0;

	internal Color Color => class18_0.Color;

	internal Class26(Class21.Delegate2 colorResolver)
	{
		class18_0 = new Class18(colorResolver);
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
		return base.vmethod_1() + Color;
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
	}
}
