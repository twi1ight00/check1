using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("ce9203e2-f93d-4934-9d34-e2c57479d3c4")]
[ComVisible(true)]
public interface IFormattedTextContainer : IPresentationComponent, ISlideComponent, IChartComponent
{
	IChartTextFormat TextFormat { get; }
}
