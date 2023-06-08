using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides.Charts;

[Guid("4cb337f8-3286-42e4-b2b2-ede6786d141e")]
[ComVisible(true)]
public interface IChart : IPresentationComponent, ISlideComponent, IChartComponent, IHyperlinkContainer, IShape, IGraphicalObject, IFormattedTextContainer, IThemeable, IOverrideThemeable
{
	bool PlotVisibleCellsOnly { get; set; }

	DisplayBlanksAsType DisplayBlanksAs { get; set; }

	IChartData ChartData { get; }

	bool HasTitle { get; set; }

	IChartTitle ChartTitle { get; }

	bool HasDataTable { get; set; }

	bool HasLegend { get; set; }

	ILegend Legend { get; }

	IDataTable ChartDataTable { get; }

	StyleType Style { get; set; }

	ChartType Type { get; set; }

	IChartPlotArea PlotArea { get; }

	IRotation3D Rotation3D { get; }

	IChartWall BackWall { get; }

	IChartWall SideWall { get; }

	IChartWall Floor { get; }

	IGroupShape UserShapes { get; }

	IAxesManager Axes { get; }

	IGraphicalObject AsIGraphicalObject { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }

	IOverrideThemeable AsIOverrideThemeable { get; }
}
