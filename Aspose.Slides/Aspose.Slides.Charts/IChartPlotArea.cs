using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("133fe589-bb5a-4920-a231-fc6e28d76e36")]
public interface IChartPlotArea : IPresentationComponent, ISlideComponent, IChartComponent, ILayoutable
{
	IFormat Format { get; }

	ILayoutable AsILayoutable { get; }
}
