using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("336cf957-3066-4a8d-a0b3-1905d4d43b71")]
public interface IErrorBarsFormat : IPresentationComponent, ISlideComponent, IChartComponent
{
	ErrorBarType Type { get; set; }

	ErrorBarValueType ValueType { get; set; }

	bool HasEndCap { get; set; }

	float Value { get; set; }

	IFormat Format { get; set; }

	bool IsVisible { get; set; }

	IChartComponent AsIChartComponent { get; }
}
