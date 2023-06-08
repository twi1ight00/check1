using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns14;
using ns19;

namespace ns3;

internal interface Interface7 : IDisposable, Interface6
{
	int Width { get; }

	int Height { get; }

	int X { set; }

	int Y { set; }

	Interface9 CategoryAxis { get; }

	Interface9 ValueAxis { get; }

	Interface9 SeriesAxis { get; }

	Interface30 Title { get; }

	ChartType_Chart Type { set; }

	Interface33 Walls { get; }

	Interface14 ChartArea { get; }

	Interface13 ChartDataTable { get; }

	Interface23 Legend { get; }

	Interface27 NSeries { get; }

	Interface14 PlotArea { get; }

	Interface20 Floor { get; }

	bool IsInnerMode { set; }

	int Rotation { set; }

	int DepthPercent { set; }

	int GapDepth { set; }

	int GapWidth { set; }

	int Elevation { set; }

	int HeightPercent { set; }

	bool AutoScaling { set; }

	bool RightAngleAxes { set; }

	bool IsDataTableShown { set; }

	bool IsLegendShown { set; }

	bool IsRectangularCornered { set; }

	[SpecialName]
	Interface9 imethod_3();

	[SpecialName]
	Interface9 imethod_4();

	[SpecialName]
	Interface33 imethod_5();

	[SpecialName]
	Interface33 imethod_6();

	[SpecialName]
	int imethod_7();

	[SpecialName]
	void imethod_8(int int_0);

	[SpecialName]
	void imethod_9(bool bool_0);

	[SpecialName]
	Interface12 imethod_10();

	[SpecialName]
	void imethod_11(bool bool_0);

	[SpecialName]
	void imethod_12(string string_0);

	[SpecialName]
	Size imethod_13();

	void ChangePalette(Color[] color_0);

	[SpecialName]
	void imethod_14(Class516 class516_0);
}
