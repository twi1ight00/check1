using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("2b1d0348-78e2-4e4b-aa40-1d0bbc1d7436")]
[ComVisible(true)]
public interface IChartTitle : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer, IOverridableText, ILayoutable
{
	bool Overlay { get; set; }

	IFormat Format { get; }

	ILayoutable AsILayoutable { get; }

	IOverridableText AsIOverridableText { get; }
}
