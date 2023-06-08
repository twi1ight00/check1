using System.Runtime.InteropServices;
using ns5;

namespace Aspose.Slides.Effects;

[ClassInterface(ClassInterfaceType.None)]
[Guid("4a792264-0307-4294-89b5-d511d1a34ede")]
[ComVisible(true)]
public class FillOverlay : ImageTransformOperation, IImageTransformOperation, IFillOverlay, IEffect
{
	internal FillFormat fillFormat_0;

	internal FillBlendMode fillBlendMode_0 = FillBlendMode.Lighten;

	public IFillFormat FillFormat => fillFormat_0;

	public FillBlendMode Blend
	{
		get
		{
			return fillBlendMode_0;
		}
		set
		{
			fillBlendMode_0 = value;
			method_0();
		}
	}

	internal override uint Version => base.Version + fillFormat_0.Version;

	IImageTransformOperation IFillOverlay.AsIImageTransformOperation => this;

	internal FillOverlay(IPresentationComponent parent)
		: base(parent)
	{
		fillFormat_0 = new FillFormat(base.Parent);
		fillFormat_0.FillType = FillType.Solid;
		fillFormat_0.SolidFillColor.SchemeColor = SchemeColor.Accent1;
	}

	internal override Class190 vmethod_0(Class190 img, IBaseSlide slide, FloatColor styleColor)
	{
		return img;
	}

	internal override ImageTransformOperation Clone()
	{
		FillOverlay fillOverlay = new FillOverlay(null);
		fillOverlay.fillFormat_0 = new FillFormat(null);
		fillOverlay.fillFormat_0.method_0(fillFormat_0);
		return fillOverlay;
	}

	internal override void vmethod_2(IPresentationComponent parent)
	{
		base.vmethod_2(parent);
		FillFormat source = fillFormat_0;
		fillFormat_0 = new FillFormat(base.Parent);
		fillFormat_0.method_0(source);
		method_0();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new FillOverlayEffectiveData(this, slide, styleColor);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class35(this);
	}
}
