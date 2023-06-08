using ns5;

namespace Aspose.Slides.Effects;

public abstract class ImageTransformOperation : IImageTransformOperation, IPVIObject
{
	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	uint IPVIObject.Version => Version;

	internal virtual uint Version => uint_0;

	internal ImageTransformOperation(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
	}

	internal ImageTransformOperation()
	{
	}

	internal abstract Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor);

	internal virtual ImageTransformOperation Clone()
	{
		return (ImageTransformOperation)MemberwiseClone();
	}

	internal virtual string vmethod_1(IBaseSlide slide, FloatColor styleColor)
	{
		return GetType().Name;
	}

	internal virtual void vmethod_2(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		method_0();
	}

	internal void method_0()
	{
		uint_0++;
	}
}
