using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("bc3d4f67-d2ef-4a56-9dc0-7096e26bce7c")]
[ComVisible(true)]
public interface ILegendEntryProperties : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer
{
	bool Hide { get; set; }

	IChartComponent AsIChartComponent { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }
}
