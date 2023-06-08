using Aspose.Slides.Charts;

namespace ns36;

internal interface Interface21
{
	int SeriesIndex { get; set; }

	int ID { get; set; }

	Interface12 VirtualPoint { get; }

	Interface13 DataLabels { get; }

	Interface15 YErrorBar { get; }

	Interface15 XErrorBar { get; }

	Interface18 Line { get; }

	Interface6 Area { get; }

	Interface19 Marker { get; }

	string Name { get; set; }

	bool PlotOnSecondAxis { get; set; }

	Interface11 Points { get; }

	bool Smooth { get; set; }

	Interface22 Trendlines { get; }

	ChartType Type { get; set; }

	ChartShapeType BarShape { get; set; }

	bool IsColorVaried { get; set; }

	int GapWidth { get; set; }

	int Overlap { get; set; }

	bool HasDropLines { get; set; }

	bool HasHighLowLines { get; set; }

	bool HasUpDownBars { get; set; }

	Interface18 DropLines { get; }

	Interface18 HighLowLines { get; }

	bool HasLeaderLines { get; set; }

	Interface18 LeaderLines { get; }

	Interface10 UpBars { get; }

	Interface10 DownBars { get; }

	int AngleOfFirstSlice { get; set; }

	int DoughnutHoleSize { get; set; }

	bool HasSeriesLines { get; set; }

	Interface18 SeriesLines { get; }

	int BubbleScale { get; set; }

	bool ShowNegativeBubbles { get; set; }

	Enum149 SizeRepresents { get; set; }

	int DisplayOrder { get; set; }

	bool UseExcel4Palette { get; set; }

	void imethod_0(params double[] yValues);

	void imethod_1(params double[] xValues);

	void imethod_2(params double[] sizes);
}
