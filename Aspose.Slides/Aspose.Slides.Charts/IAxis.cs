using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("11d375ad-c686-48a1-a377-264c96bfacc0")]
public interface IAxis : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer
{
	bool AxisBetweenCategories { get; set; }

	float CrossAt { get; set; }

	DisplayUnitType DisplayUnit { get; set; }

	bool IsAutomaticMaxValue { get; set; }

	double MaxValue { get; set; }

	double MinorUnit { get; set; }

	bool IsAutomaticMinorUnit { get; set; }

	double MajorUnit { get; set; }

	bool IsAutomaticMajorUnit { get; set; }

	bool IsAutomaticMinValue { get; set; }

	double MinValue { get; set; }

	bool IsLogarithmic { get; set; }

	double LogBase { get; set; }

	bool IsPlotOrderReversed { get; set; }

	bool IsVisible { get; set; }

	TickMarkType MajorTickMark { get; set; }

	TickMarkType MinorTickMark { get; set; }

	TickLabelPositionType TickLabelPosition { get; set; }

	TimeUnitType MajorUnitScale { get; set; }

	TimeUnitType MinorUnitScale { get; set; }

	TimeUnitType BaseUnitScale { get; set; }

	IChartLinesFormat MinorGridLinesFormat { get; }

	IChartLinesFormat MajorGridLinesFormat { get; }

	bool ShowMinorGridLines { get; }

	bool ShowMajorGridLines { get; }

	IAxisFormat Format { get; }

	IChartTitle Title { get; }

	CrossesType CrossType { get; set; }

	AxisPositionType Position { get; set; }

	bool HasTitle { get; set; }

	string NumberFormat { get; set; }

	bool IsNumberFormatLinkedToSource { get; set; }

	float TickLabelRotationAngle { get; set; }

	uint TickLabelSpacing { get; set; }

	bool IsAutomaticTickLabelSpacing { get; set; }

	IChartComponent AsIChartComponent { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }
}
