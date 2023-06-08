using System.Drawing;

namespace Aspose.Slides.Theme;

public class FormatSchemeEffectiveData : IFormatSchemeEffectiveData, IEffectiveData
{
	private IFormatScheme iformatScheme_0;

	private BaseSlide baseSlide_0;

	private FillFormatCollectionEffectiveData fillFormatCollectionEffectiveData_0 = new FillFormatCollectionEffectiveData();

	private LineFormatCollectionEffectiveData lineFormatCollectionEffectiveData_0 = new LineFormatCollectionEffectiveData();

	private EffectStyleCollectionEffectiveData effectStyleCollectionEffectiveData_0 = new EffectStyleCollectionEffectiveData();

	private FillFormatCollectionEffectiveData fillFormatCollectionEffectiveData_1 = new FillFormatCollectionEffectiveData();

	internal FormatSchemeEffectiveData(IFormatScheme sourceFormatScheme, IBaseSlide slide)
	{
		baseSlide_0 = (BaseSlide)slide;
		iformatScheme_0 = sourceFormatScheme;
	}

	public IFillFormatCollectionEffectiveData GetFillStyles(Color styleColor)
	{
		fillFormatCollectionEffectiveData_0.method_0(iformatScheme_0.FillStyles, baseSlide_0, new FloatColor(styleColor));
		return fillFormatCollectionEffectiveData_0;
	}

	public ILineFormatCollectionEffectiveData GetLineStyles(Color styleColor)
	{
		lineFormatCollectionEffectiveData_0.method_0(iformatScheme_0.LineStyles, baseSlide_0, new FloatColor(styleColor));
		return lineFormatCollectionEffectiveData_0;
	}

	public IEffectStyleCollectionEffectiveData GetEffectStyles(Color styleColor)
	{
		effectStyleCollectionEffectiveData_0.method_0(iformatScheme_0.EffectStyles, baseSlide_0, new FloatColor(styleColor));
		return effectStyleCollectionEffectiveData_0;
	}

	public IFillFormatCollectionEffectiveData GetBackgroundFillStyles(Color styleColor)
	{
		fillFormatCollectionEffectiveData_1.method_0(iformatScheme_0.BackgroundFillStyles, baseSlide_0, new FloatColor(styleColor));
		return fillFormatCollectionEffectiveData_1;
	}
}
