using System.Drawing;
using ns5;

namespace Aspose.Slides.Effects;

public class ColorReplaceEffectiveData : EffectEffectiveData, IColorReplaceEffectiveData
{
	private Color color_0;

	public Color Color => color_0;

	internal ColorReplaceEffectiveData(Color c)
	{
		color_0 = c;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		Color color = color_0;
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
		return base.vmethod_1() + color_0;
	}
}
