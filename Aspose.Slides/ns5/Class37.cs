using Aspose.Slides.Effects;

namespace ns5;

internal class Class37 : EffectEffectiveDataPVITemp, IGrayScaleEffectiveData
{
	internal static Class37 class37_0 = new Class37();

	private Class37()
	{
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			int num3 = (num >> 16) & 0xFF;
			int num4 = (num >> 8) & 0xFF;
			int num5 = num & 0xFF;
			int num6 = (int)((double)num3 * 0.2126 + (double)num4 * 0.7151 + (double)num5 * 0.0722);
			img.Bits[i] = (num2 << 24) + (num6 << 16) + (num6 << 8) + num6;
		}
		return img;
	}
}
