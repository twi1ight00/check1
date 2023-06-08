using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[Guid("847b0403-c75c-4d83-9133-4533dd4d439c")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class GrayScale : ImageTransformOperation, IImageTransformOperation, IGrayScale, IEffect
{
	IImageTransformOperation IGrayScale.AsIImageTransformOperation => this;

	internal GrayScale(IPresentationComponent parent)
		: base(parent)
	{
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
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

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return GrayScaleEffectiveData.grayScaleEffectiveData_0;
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return Class37.class37_0;
	}
}
