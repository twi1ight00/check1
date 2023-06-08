using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface13
{
	Interface10 ChartFrame { get; }

	bool IsCategoryNameShown { get; set; }

	bool IsLegendKeyShown { get; set; }

	bool IsPercentageShown { get; set; }

	bool IsValueShown { get; set; }

	bool IsSeriesNameShown { get; set; }

	bool IsBubbleSizeShown { get; set; }

	LegendDataLabelPosition LabelPosition { get; set; }

	Enum153 Separator { get; set; }

	int Rotation { get; set; }

	Enum157 TextHorizontalAlignment { get; set; }

	Enum157 TextVerticalAlignment { get; set; }

	string Format { get; set; }

	bool LinkedSource { get; set; }

	bool IsCulture { get; set; }

	string Text { get; set; }

	Interface29 RichCharactersList { get; }
}
