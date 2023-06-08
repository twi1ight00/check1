using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("76ae7dc6-eb92-4f70-b348-355f20c69147")]
public interface IDataLabelFormat : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer
{
	bool IsNumberFormatLinkedToSource { get; set; }

	string NumberFormat { get; set; }

	IFormat Format { get; }

	LegendDataLabelPosition Position { get; set; }

	bool ShowLegendKey { get; set; }

	bool ShowValue { get; set; }

	bool ShowCategoryName { get; set; }

	bool ShowSeriesName { get; set; }

	bool ShowPercentage { get; set; }

	bool ShowBubbleSize { get; set; }

	bool ShowLeaderLines { get; set; }

	string Separator { get; set; }

	IChartComponent AsIChartComponent { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }
}
