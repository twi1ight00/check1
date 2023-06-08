using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("e3260d81-77bf-4816-bbec-31407105ed75")]
public interface IChartSeries : IPresentationComponent, ISlideComponent, IChartComponent
{
	int Explosion { get; set; }

	bool Smooth { get; set; }

	IMarker Marker { get; }

	ChartShapeType Bar3DShape { get; set; }

	IStringChartValue Name { get; }

	IChartDataPointCollection DataPoints { get; }

	ChartType Type { get; set; }

	IChartSeriesGroup ParentSeriesGroup { get; }

	IFormat Format { get; }

	int Order { get; set; }

	IDataLabelCollection Labels { get; }

	ITrendlineCollection TrendLines { get; }

	IErrorBarsFormat ErrorBarsXFormat { get; }

	IErrorBarsFormat ErrorBarsYFormat { get; }

	bool PlotOnSecondAxis { get; set; }

	string NumberFormatOfValues { get; set; }

	string NumberFormatOfXValues { get; set; }

	string NumberFormatOfYValues { get; set; }

	string NumberFormatOfBubbleSizes { get; set; }

	bool InvertIfNegative { get; set; }

	bool HasUpDownBars { get; }

	int GapWidth { get; }

	int GapDepth { get; }

	bool IsColorVaried { get; }

	bool HasSeriesLines { get; }

	sbyte Overlap { get; }

	IChartComponent AsIChartComponent { get; }
}
