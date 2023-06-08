using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("df2de752-3b5e-4684-aca2-5f74d107a5ab")]
public class AlphaModulate : ImageTransformOperation, IImageTransformOperation, IAlphaModulate, IEffect
{
	IImageTransformOperation IAlphaModulate.AsIImageTransformOperation => this;

	internal AlphaModulate(IPresentationComponent parent)
		: base(parent)
	{
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		return img;
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return AlphaModulateEffectiveData.alphaModulateEffectiveData_0;
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return Class27.class27_0;
	}
}
