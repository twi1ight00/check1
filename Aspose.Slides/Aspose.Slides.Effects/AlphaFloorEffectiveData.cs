using ns5;

namespace Aspose.Slides.Effects;

public class AlphaFloorEffectiveData : EffectEffectiveData, IAlphaFloorEffectiveData
{
	internal static AlphaFloorEffectiveData alphaFloorEffectiveData_0 = new AlphaFloorEffectiveData();

	private AlphaFloorEffectiveData()
	{
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			img.Bits[i] = ((num2 >= 255) ? (img.Bits[i] | -16777216) : (img.Bits[i] & 0xFFFFFF));
		}
		return img;
	}
}
