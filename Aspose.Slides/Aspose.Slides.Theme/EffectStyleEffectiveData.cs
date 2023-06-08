namespace Aspose.Slides.Theme;

public class EffectStyleEffectiveData : IEffectStyleEffectiveData, IEffectiveData
{
	private EffectFormatEffectiveData effectFormatEffectiveData_0 = new EffectFormatEffectiveData();

	private ThreeDFormatEffectiveData threeDFormatEffectiveData_0 = new ThreeDFormatEffectiveData();

	public IEffectFormatEffectiveData EffectFormat => effectFormatEffectiveData_0;

	public IThreeDFormatEffectiveData ThreeDFormat => threeDFormatEffectiveData_0;

	internal EffectStyleEffectiveData()
	{
	}

	internal void method_0(IEffectStyle source, BaseSlide slide, FloatColor styleColor)
	{
		effectFormatEffectiveData_0.method_0((EffectFormat)source.EffectFormat, slide, styleColor);
		threeDFormatEffectiveData_0.method_0((ThreeDFormat)source.ThreeDFormat, slide, styleColor);
	}
}
