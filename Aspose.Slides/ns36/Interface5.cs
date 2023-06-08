using System.Drawing;
using Aspose.Slides.Charts;
using ns221;
using ns35;

namespace ns36;

internal interface Interface5 : Interface4
{
	[Attribute7(true)]
	int Width { get; set; }

	[Attribute7(true)]
	int Height { get; set; }

	int X { get; set; }

	int Y { get; set; }

	ChartType Type { get; set; }

	Interface24 Walls { get; }

	Interface10 ChartArea { get; }

	Interface20 NSeries { get; }

	Interface10 PlotArea { get; }

	Interface16 Floor { get; }

	Interface24 SideWalls { get; }

	Interface24 BackWalls { get; }

	int StyleIndex { get; set; }

	bool IsInnerMode { get; set; }

	int Rotation { get; set; }

	int DepthPercent { get; set; }

	int GapDepth { get; set; }

	int GapWidth { get; set; }

	int Elevation { get; set; }

	int HeightPercent { get; set; }

	bool AutoScaling { get; set; }

	bool RightAngleAxes { get; set; }

	bool IsLegendShown { get; set; }

	bool IsRectangularCornered { get; set; }

	bool IsDrawEvaluation { get; set; }

	Interface9 SubCharts { get; }

	bool IsDate1904 { get; set; }

	string ProductName { get; set; }

	[Attribute7(true)]
	Size ActualChartSize { get; }

	void imethod_1(Color[] colors);
}
