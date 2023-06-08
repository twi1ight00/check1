using System;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;

namespace ns3;

internal interface Interface28 : IDisposable
{
	Interface17 DataLabels { get; }

	Interface19 YErrorBar { get; }

	Interface19 XErrorBar { get; }

	Interface25 Line { get; }

	Interface8 Area { get; }

	Interface26 Marker { get; }

	string Name { get; set; }

	bool PlotOnSecondAxis { get; set; }

	Interface15 Points { get; }

	bool Smooth { set; }

	ChartType_Chart Type { get; set; }

	Enum62 BarShape { set; }

	bool IsColorVaried { set; }

	int GapWidth { set; }

	int Overlap { set; }

	bool HasDropLines { set; }

	bool HasUpDownBars { set; }

	Interface25 DropLines { get; }

	bool HasLeaderLines { set; }

	Interface25 LeaderLines { get; }

	Interface14 UpBars { get; }

	Interface14 DownBars { get; }

	int DoughnutHoleSize { set; }

	bool HasSeriesLines { set; }

	Interface25 SeriesLines { get; }

	int BubbleScale { set; }

	bool ShowNegativeBubbles { set; }

	Enum63 SizeRepresents { set; }

	float Explosion { set; }

	Enum2 SplitType { set; }

	double SplitValue { set; }

	[SpecialName]
	void imethod_0(int int_0);

	[SpecialName]
	void imethod_1(int int_0);

	[SpecialName]
	Interface16 imethod_2();

	[SpecialName]
	Interface31 imethod_3();

	[SpecialName]
	void imethod_4(bool bool_0);

	[SpecialName]
	Interface25 imethod_5();

	[SpecialName]
	void imethod_6(int int_0);

	[SpecialName]
	void imethod_7(int int_0);

	[SpecialName]
	void imethod_8(int int_0);

	[SpecialName]
	void imethod_9(bool bool_0);

	[SpecialName]
	void imethod_10(bool bool_0);
}
