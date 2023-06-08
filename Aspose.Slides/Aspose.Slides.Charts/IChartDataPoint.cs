using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("b8ccb139-bd58-4fb4-9233-5dada7e9c38e")]
public interface IChartDataPoint
{
	IStringOrDoubleChartValue XValue { get; }

	IDoubleChartValue YValue { get; }

	IDoubleChartValue BubbleSize { get; }

	IDoubleChartValue Value { get; }

	IErrorBarsCustomValues ErrorBarsCustomValues { get; }

	IDataLabel Label { get; }

	bool IsBubble3D { get; set; }

	int Explosion { get; set; }

	IFormat Format { get; set; }

	IMarker Marker { get; }

	void Remove();
}
