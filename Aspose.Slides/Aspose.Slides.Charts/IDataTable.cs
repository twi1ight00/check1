using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("9d76731e-13de-4c35-a7ec-61b496ee2a91")]
public interface IDataTable : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer
{
	IFormat Format { get; }

	bool HasBorderHorizontal { get; set; }

	bool HasBorderOutline { get; set; }

	bool HasBorderVertical { get; set; }

	bool ShowLegendKey { get; set; }

	IChartComponent AsIChartComponent { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }
}
