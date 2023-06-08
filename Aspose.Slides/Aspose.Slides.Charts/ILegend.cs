using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("4e6dfc6e-dbc3-4b29-8daf-d789d3a0f79e")]
public interface ILegend : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, ILayoutable
{
	bool Overlay { get; set; }

	LegendPositionType Position { get; set; }

	IFormat Format { get; }

	ILegendEntryCollection Entries { get; }

	ILayoutable AsILayoutable { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }
}
