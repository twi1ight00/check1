using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[Guid("99f0df48-637b-46bb-a329-3ac45824cce7")]
[ClassInterface(ClassInterfaceType.None)]
public class AlphaCeiling : ImageTransformOperation, IImageTransformOperation, IAlphaCeiling, IEffect
{
	IImageTransformOperation IAlphaCeiling.AsIImageTransformOperation => this;

	internal AlphaCeiling(IPresentationComponent parent)
		: base(parent)
	{
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			img.Bits[i] = ((num2 > 0) ? (img.Bits[i] | -16777216) : (img.Bits[i] & 0xFFFFFF));
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return AlphaCeilingEffectiveData.alphaCeilingEffectiveData_0;
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return Class24.class24_0;
	}
}
