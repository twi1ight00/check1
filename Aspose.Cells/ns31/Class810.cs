using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns31;

internal class Class810 : IDisposable, Interface28
{
	private Class787 class787_0;

	private Class798 class798_0;

	private Class800 class800_0;

	private Class800 class800_1;

	private Class806 class806_0;

	private Class788 class788_0;

	private Class807 class807_0;

	private string string_0;

	private bool bool_0;

	private Class795 class795_0;

	private bool bool_1;

	private Class813 class813_0;

	private ChartType_Chart chartType_Chart_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private Class806 class806_1;

	private Class806 class806_2;

	private Class806 class806_3;

	private Class794 class794_0;

	private Class794 class794_1;

	private bool bool_6;

	private bool bool_7 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3 = 50;

	private int int_4 = 75;

	private bool bool_8;

	private Class806 class806_4;

	private int int_5 = 100;

	private bool bool_9;

	private Enum63 enum63_0;

	private int int_6;

	private bool bool_10;

	private ChartType_Chart chartType_Chart_1;

	private Enum62 enum62_0;

	private Class808 class808_0;

	private Class796 class796_0;

	private int int_7;

	private int int_8;

	private bool bool_11;

	internal Size size_0 = new Size(0, 0);

	private float float_0;

	private bool bool_12 = true;

	private Enum2 enum2_0 = Enum2.const_1;

	private double double_0;

	private bool bool_13;

	public Interface17 DataLabels => class798_0;

	public Interface19 YErrorBar
	{
		get
		{
			if (class800_0 == null)
			{
				class800_0 = new Class800(class787_0, this);
			}
			return class800_0;
		}
	}

	public Interface19 XErrorBar
	{
		get
		{
			if (class800_1 == null)
			{
				class800_1 = new Class800(class787_0, this);
			}
			class800_1.imethod_0(bool_2: false);
			return class800_1;
		}
	}

	public Interface25 Line => class806_0;

	public Interface8 Area => class788_0;

	public Interface26 Marker => class807_0;

	public string Name
	{
		get
		{
			if (string_0 == null)
			{
				return "Series" + (vmethod_5() + 1);
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool PlotOnSecondAxis
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Interface15 Points => class795_0;

	public bool Smooth
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public ChartType_Chart Type
	{
		get
		{
			return chartType_Chart_0;
		}
		set
		{
			chartType_Chart_0 = value;
		}
	}

	public Enum62 BarShape
	{
		get
		{
			return enum62_0;
		}
		set
		{
			enum62_0 = value;
		}
	}

	public bool IsColorVaried
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
			bool_7 = false;
		}
	}

	public int GapWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 0 && value <= 500)
			{
				int_0 = value;
			}
		}
	}

	public int Overlap
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= -100 && value <= 100)
			{
				int_1 = value;
			}
		}
	}

	public bool HasDropLines
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool HasUpDownBars
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Interface25 DropLines => class806_2;

	public bool HasLeaderLines
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public Interface25 LeaderLines => class806_1;

	public Interface14 UpBars => class794_0;

	public Interface14 DownBars => class794_1;

	public int DoughnutHoleSize
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 10)
			{
				int_3 = 10;
			}
			else if (value > 90)
			{
				int_3 = 90;
			}
			else
			{
				int_3 = value;
			}
		}
	}

	public bool HasSeriesLines
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public Interface25 SeriesLines => class806_4;

	public int BubbleScale
	{
		get
		{
			return int_5;
		}
		set
		{
			if (value > 300)
			{
				int_5 = 300;
			}
			else
			{
				int_5 = value;
			}
		}
	}

	public bool ShowNegativeBubbles
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public Enum63 SizeRepresents
	{
		get
		{
			return enum63_0;
		}
		set
		{
			enum63_0 = value;
		}
	}

	public float Explosion
	{
		get
		{
			if (bool_12)
			{
				switch (chartType_Chart_0)
				{
				case ChartType_Chart.DoughnutExploded:
				case ChartType_Chart.PieExploded:
				case ChartType_Chart.Pie3DExploded:
					return 25f;
				}
			}
			return float_0;
		}
		set
		{
			float_0 = value;
			bool_12 = false;
		}
	}

	public Enum2 SplitType
	{
		get
		{
			return enum2_0;
		}
		set
		{
			enum2_0 = value;
		}
	}

	public double SplitValue
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	internal Class787 Chart => class787_0;

	internal Class808 NSeries => class808_0;

	internal int Index => class808_0.method_15().IndexOf(this);

	[SpecialName]
	internal Class796 method_0()
	{
		return class796_0;
	}

	[SpecialName]
	public Interface16 imethod_2()
	{
		return class796_0;
	}

	public Class810(Class787 class787_1, Class808 class808_1, ChartType_Chart chartType_Chart_2)
	{
		class787_0 = class787_1;
		Type = chartType_Chart_2;
		class808_0 = class808_1;
		class798_0 = new Class798(class787_1, this, Enum52.const_12);
		class806_0 = new Class806(class787_1);
		class788_0 = new Class788(class787_1);
		class807_0 = new Class807(class787_1, this);
		class806_4 = new Class806(class787_1);
		class813_0 = new Class813(class787_1, this);
		class795_0 = new Class795(class787_1, this);
		int_0 = 150;
		class806_1 = new Class806(class787_1);
		class806_2 = new Class806(class787_1);
		class806_3 = new Class806(class787_1);
		class794_0 = new Class794(class787_1, this, Enum52.const_14);
		class794_1 = new Class794(class787_1, this, Enum52.const_15);
		class794_1.method_1().ForegroundColor = Color.Black;
		bool_10 = false;
		method_1();
	}

	private void method_1()
	{
		switch (Type)
		{
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.ColumnStacked:
		case ChartType_Chart.Column100PercentStacked:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.Column3D100PercentStacked:
			Overlap = 100;
			break;
		case ChartType_Chart.Scatter:
			class806_0.Formatting = Enum71.const_0;
			break;
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
			Smooth = true;
			break;
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
			method_8().MarkerStyle = Enum65.const_5;
			Smooth = true;
			break;
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.Radar:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			method_8().MarkerStyle = Enum65.const_5;
			break;
		case ChartType_Chart.PiePie:
		case ChartType_Chart.PieBar:
			class796_0 = new Class796(class787_0);
			class796_0.method_2(class795_0);
			HasSeriesLines = true;
			break;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Class810)
		{
			Class810 @class = (Class810)obj;
			if (this != obj)
			{
				return false;
			}
			if (class808_0 != @class.class808_0)
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return (Index + 1).GetHashCode() + class808_0.GetHashCode();
	}

	[SpecialName]
	internal void method_2(Class787 class787_1)
	{
		class787_0 = class787_1;
	}

	[SpecialName]
	internal Class798 method_3()
	{
		return class798_0;
	}

	[SpecialName]
	internal Class800 method_4()
	{
		if (class800_0 == null)
		{
			class800_0 = new Class800(class787_0, this);
		}
		return class800_0;
	}

	[SpecialName]
	internal Class800 method_5()
	{
		if (class800_1 == null)
		{
			class800_1 = new Class800(class787_0, this);
		}
		class800_1.imethod_0(bool_2: false);
		return class800_1;
	}

	[SpecialName]
	internal Class806 method_6()
	{
		return class806_0;
	}

	[SpecialName]
	internal Class788 method_7()
	{
		return class788_0;
	}

	[SpecialName]
	internal Class807 method_8()
	{
		return class807_0;
	}

	public string method_9()
	{
		if (string_0 == null)
		{
			return "S" + (Index + 1);
		}
		return string_0;
	}

	[SpecialName]
	internal Class795 method_10()
	{
		return class795_0;
	}

	[SpecialName]
	internal Class813 method_11()
	{
		return class813_0;
	}

	[SpecialName]
	public Interface31 imethod_3()
	{
		return class813_0;
	}

	[SpecialName]
	internal bool method_12()
	{
		return bool_7;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_3;
	}

	[SpecialName]
	public void imethod_4(bool bool_14)
	{
		bool_3 = bool_14;
	}

	[SpecialName]
	internal Class806 method_13()
	{
		return class806_2;
	}

	[SpecialName]
	internal Class806 method_14()
	{
		return class806_3;
	}

	[SpecialName]
	public Interface25 imethod_5()
	{
		return class806_3;
	}

	[SpecialName]
	internal Class806 method_15()
	{
		return class806_1;
	}

	[SpecialName]
	internal Class794 method_16()
	{
		return class794_0;
	}

	[SpecialName]
	internal Class794 method_17()
	{
		return class794_1;
	}

	[SpecialName]
	public int vmethod_1()
	{
		return int_2;
	}

	[SpecialName]
	public void imethod_6(int int_9)
	{
		int_2 = int_9 % 360;
	}

	[SpecialName]
	public int vmethod_2()
	{
		return int_4;
	}

	[SpecialName]
	public void imethod_7(int int_9)
	{
		if (int_9 >= 5 && int_9 <= 200)
		{
			int_4 = int_9;
		}
	}

	[SpecialName]
	internal Class806 method_18()
	{
		return class806_4;
	}

	[SpecialName]
	public int vmethod_3()
	{
		return int_6;
	}

	[SpecialName]
	public void imethod_8(int int_9)
	{
		int_6 = int_9;
	}

	[SpecialName]
	public bool vmethod_4()
	{
		return bool_10;
	}

	[SpecialName]
	public void imethod_10(bool bool_14)
	{
		bool_10 = bool_14;
	}

	[SpecialName]
	public bool method_19()
	{
		foreach (Class796 item in class795_0)
		{
			if (item.vmethod_2() != Enum1.const_3)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public bool method_20()
	{
		foreach (Class796 item in class795_0)
		{
			if (item.vmethod_4() != Enum1.const_3)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	internal Enum53 method_21()
	{
		if (PlotOnSecondAxis)
		{
			return Enum53.const_1;
		}
		return Enum53.const_0;
	}

	[SpecialName]
	internal ChartType_Chart method_22()
	{
		return chartType_Chart_1;
	}

	[SpecialName]
	internal void method_23(ChartType_Chart chartType_Chart_2)
	{
		chartType_Chart_1 = chartType_Chart_2;
	}

	internal bool method_24(ChartType_Chart[] chartType_Chart_2)
	{
		int num = 0;
		while (true)
		{
			if (num < chartType_Chart_2.Length)
			{
				ChartType_Chart chartType_Chart = chartType_Chart_2[num];
				if (Type == chartType_Chart)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal bool method_25(ChartType_Chart[] chartType_Chart_2)
	{
		int num = 0;
		while (true)
		{
			if (num < chartType_Chart_2.Length)
			{
				ChartType_Chart chartType_Chart = chartType_Chart_2[num];
				if (chartType_Chart_1 == chartType_Chart)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	[SpecialName]
	internal void method_26(Class808 class808_1)
	{
		class808_0 = class808_1;
	}

	[SpecialName]
	public int vmethod_5()
	{
		return int_7;
	}

	[SpecialName]
	public void imethod_0(int int_9)
	{
		int_7 = int_9;
	}

	[SpecialName]
	internal bool method_27()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.LineWithDataMarkers:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Radar:
		case ChartType_Chart.RadarWithDataMarkers:
		case ChartType_Chart.Scatter:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	[SpecialName]
	internal bool method_28()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.LineWithDataMarkers:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Radar:
		case ChartType_Chart.RadarWithDataMarkers:
		case ChartType_Chart.Scatter:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			if (method_6().IsVisible)
			{
				return true;
			}
			return false;
		}
	}

	[SpecialName]
	public int vmethod_6()
	{
		return int_8;
	}

	[SpecialName]
	public void imethod_1(int int_9)
	{
		int_8 = int_9;
	}

	[SpecialName]
	internal bool method_29()
	{
		if (Type == ChartType_Chart.Column)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_30()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.AreaStacked:
		case ChartType_Chart.Area3DStacked:
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.ColumnStacked:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.ConeStacked:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.CylinderStacked:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.PyramidStacked:
		case ChartType_Chart.PyramidBarStacked:
			return true;
		}
	}

	[SpecialName]
	internal bool method_31()
	{
		ChartType_Chart type = Type;
		if (type != ChartType_Chart.AreaStacked && type != ChartType_Chart.Area3DStacked)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_32()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Area100PercentStacked:
		case ChartType_Chart.Area3D100PercentStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.Column100PercentStacked:
		case ChartType_Chart.Column3D100PercentStacked:
		case ChartType_Chart.Cone100PercentStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.Cylinder100PercentStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Pyramid100PercentStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
			return true;
		}
	}

	[SpecialName]
	internal bool method_33()
	{
		ChartType_Chart type = Type;
		if (type != ChartType_Chart.Area100PercentStacked && type != ChartType_Chart.Area3D100PercentStacked)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_34()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Doughnut:
		case ChartType_Chart.DoughnutExploded:
		case ChartType_Chart.Pie:
		case ChartType_Chart.Pie3D:
		case ChartType_Chart.PiePie:
		case ChartType_Chart.PieExploded:
		case ChartType_Chart.Pie3DExploded:
		case ChartType_Chart.PieBar:
			return true;
		}
	}

	[SpecialName]
	internal bool method_35()
	{
		ChartType_Chart type = Type;
		if (type != ChartType_Chart.Pie3D && type != ChartType_Chart.Pie3DExploded)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_36()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Radar:
		case ChartType_Chart.RadarWithDataMarkers:
		case ChartType_Chart.RadarFilled:
			return true;
		}
	}

	[SpecialName]
	internal bool method_37()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Bubble:
		case ChartType_Chart.Bubble3D:
			return true;
		}
	}

	[SpecialName]
	internal bool method_38()
	{
		switch (Type)
		{
		default:
			return false;
		case ChartType_Chart.Bubble:
		case ChartType_Chart.Bubble3D:
		case ChartType_Chart.Scatter:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	[SpecialName]
	public bool vmethod_7()
	{
		return bool_11;
	}

	[SpecialName]
	public void imethod_9(bool bool_14)
	{
		bool_11 = bool_14;
	}

	[SpecialName]
	internal bool method_39()
	{
		foreach (Class796 item in class795_0)
		{
			if (!item.method_6().method_3())
			{
				return false;
			}
		}
		return true;
	}

	~Class810()
	{
		Dispose(bool_14: false);
	}

	public void Dispose()
	{
		Dispose(bool_14: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_14)
	{
		if (bool_13)
		{
			return;
		}
		if (bool_14)
		{
			if (class807_0 != null)
			{
				class807_0.Dispose();
			}
			if (class788_0 != null)
			{
				class788_0.Dispose();
			}
			if (class798_0 != null)
			{
				class798_0.Dispose();
			}
			if (class794_0 != null)
			{
				class794_0.Dispose();
			}
			if (class794_1 != null)
			{
				class794_1.Dispose();
			}
			if (class795_0 != null)
			{
				for (int i = 0; i < class795_0.Count; i++)
				{
					class795_0.method_1(i)?.Dispose();
				}
			}
			if (class796_0 != null)
			{
				class796_0.Dispose();
			}
			if (class813_0 != null)
			{
				for (int j = 0; j < class813_0.Count; j++)
				{
					class813_0.method_1(j)?.Dispose();
				}
			}
		}
		bool_13 = true;
	}
}
