using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("c4cc7398-1211-47b5-aad3-59fca7658a07")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class AlphaFloor : ImageTransformOperation, IImageTransformOperation, IAlphaFloor, IEffect
{
	IImageTransformOperation IAlphaFloor.AsIImageTransformOperation => this;

	internal AlphaFloor(IPresentationComponent parent)
		: base(parent)
	{
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		for (int i = 0; i < img.Bits.Length; i++)
		{
			int num = img.Bits[i];
			int num2 = (num >> 24) & 0xFF;
			img.Bits[i] = ((num2 >= 255) ? (img.Bits[i] | -16777216) : (img.Bits[i] & 0xFFFFFF));
		}
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return AlphaFloorEffectiveData.alphaFloorEffectiveData_0;
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return Class25.class25_0;
	}
}
