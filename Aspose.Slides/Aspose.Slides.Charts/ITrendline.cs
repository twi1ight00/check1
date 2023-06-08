using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("97c2f9fa-3c6b-425d-8721-cba4e68c3d76")]
[ComVisible(true)]
public interface ITrendline : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText
{
	string TrendlineName { get; set; }

	TrendlineType TrendlineType { get; set; }

	IFormat Format { get; set; }

	double Backward { get; set; }

	double Forward { get; set; }

	double Intercept { get; set; }

	bool DisplayEquation { get; set; }

	byte Order { get; set; }

	byte Period { get; set; }

	bool DisplayRSquaredValue { get; set; }

	IChartComponent AsIChartComponent { get; }

	IOverridableText AsIOverridableText { get; }
}
