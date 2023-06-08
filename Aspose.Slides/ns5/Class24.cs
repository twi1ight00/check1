using Aspose.Slides.Effects;

namespace ns5;

internal class Class24 : EffectEffectiveDataPVITemp, IAlphaCeilingEffectiveData
{
	internal static Class24 class24_0 = new Class24();

	private Class24()
	{
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			img.Bits[i] = ((num2 > 0) ? (img.Bits[i] | -16777216) : (img.Bits[i] & 0xFFFFFF));
		}
		return img;
	}
}
