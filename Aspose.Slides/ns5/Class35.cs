using Aspose.Slides;
using Aspose.Slides.Effects;

namespace ns5;

internal class Class35 : EffectEffectiveDataPVITemp, IFillOverlayEffectiveData
{
	private FillOverlay fillOverlay_0;

	private FillBlendMode fillBlendMode_0 = FillBlendMode.Lighten;

	public FillBlendMode Blend => fillBlendMode_0;

	public IFillFormatEffectiveData FillFormat => fillOverlay_0.fillFormat_0.method_4();

	internal Class35(FillOverlay source)
	{
		fillOverlay_0 = source;
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
