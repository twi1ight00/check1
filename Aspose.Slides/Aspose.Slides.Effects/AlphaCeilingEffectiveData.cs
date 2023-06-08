using ns5;

namespace Aspose.Slides.Effects;

public class AlphaCeilingEffectiveData : EffectEffectiveData, IAlphaCeilingEffectiveData
{
	internal static AlphaCeilingEffectiveData alphaCeilingEffectiveData_0 = new AlphaCeilingEffectiveData();

	private AlphaCeilingEffectiveData()
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
