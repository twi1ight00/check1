using ns5;

namespace Aspose.Slides.Effects;

public class FillOverlayEffectiveData : EffectEffectiveData, IFillOverlayEffectiveData
{
	internal FillFormatEffectiveData fillFormatEffectiveData_0;

	private FillBlendMode fillBlendMode_0 = FillBlendMode.Lighten;

	public FillBlendMode Blend => fillBlendMode_0;

	public IFillFormatEffectiveData FillFormat => fillFormatEffectiveData_0;

	internal FillOverlayEffectiveData(FillOverlay source, BaseSlide slide, FloatColor styleColor)
	{
		fillFormatEffectiveData_0 = new FillFormatEffectiveData(source.fillFormat_0, slide, styleColor);
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		return img;
	}

	internal override string vmethod_1()
	{
		return base.vmethod_1() + fillBlendMode_0;
	}
}
