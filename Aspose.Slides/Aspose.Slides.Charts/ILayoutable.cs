using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("99110408-b10a-4512-be85-7ed0ef157776")]
[ComVisible(true)]
public interface ILayoutable : IPresentationComponent, ISlideComponent, IChartComponent
{
	float X { get; set; }

	float Y { get; set; }

	float Width { get; set; }

	float Height { get; set; }

	float Right { get; }

	float Bottom { get; }

	IChartComponent AsIChartComponent { get; }
}
