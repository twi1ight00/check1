using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns33;

internal class Class844 : IDisposable, Interface28
{
	private Class821 class821_0;

	private Class832 class832_0;

	private Class834 class834_0;

	private Class834 class834_1;

	private Class840 class840_0;

	private Class822 class822_0;

	private Class841 class841_0;

	private string string_0;

	private bool bool_0;

	private Class830 class830_0;

	private bool bool_1;

	private Class849 class849_0;

	private ChartType_Chart chartType_Chart_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5 = true;

	private Class840 class840_1;

	private Class840 class840_2;

	private Class840 class840_3;

	private Class829 class829_0;

	private Class829 class829_1;

	private bool bool_6;

	private bool bool_7 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3 = 50;

	private int int_4 = 75;

	private bool bool_8;

	private Class840 class840_4;

	private int int_5 = 100;

	private bool bool_9;

	private Enum63 enum63_0;

	private int int_6;

	private bool bool_10;

	private ChartType_Chart chartType_Chart_1;

	private Enum62 enum62_0;

	private Class842 class842_0;

	private Class831 class831_0;

	private int int_7;

	private int int_8;

	internal Size size_0 = new Size(0, 0);

	private bool bool_11;

	private float float_0;

	private bool bool_12 = true;

	private Enum2 enum2_0 = Enum2.const_1;

	private double double_0;

	private bool bool_13;

	public Interface17 DataLabels => class832_0;

	public Interface19 YErrorBar
	{
		get
		{
			if (class834_0 == null)
			{
				class834_0 = new Class834(class821_0, this);
			}
			return class834_0;
		}
	}

	public Interface19 XErrorBar
	{
		get
		{
			if (class834_1 == null)
			{
				class834_1 = new Class834(class821_0, this);
			}
			class834_1.imethod_0(bool_2: false);
			return class834_1;
		}
	}

	public Interface25 Line => class840_0;

	public Interface8 Area => class822_0;

	public Interface26 Marker => class841_0;

	public string Name
	{
		get
		{
			if (string_0 == null)
			{
				return "Series" + (Index + 1);
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

	public Interface15 Points => class830_0;

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

	public Interface25 DropLines => class840_2;

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

	public Interface25 LeaderLines => class840_1;

	public Interface14 UpBars => class829_0;

	public Interface14 DownBars => class829_1;

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

	public Interface25 SeriesLines => class840_4;

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

	internal Class821 Chart => class821_0;

	internal Class842 NSeries => class842_0;

	internal int Index => class842_0.method_15().IndexOf(this);

	[SpecialName]
	internal Class831 method_0()
	{
		return class831_0;
	}

	[SpecialName]
	public Interface16 imethod_2()
	{
		return class831_0;
	}

	internal Class844(Class821 class821_1, Class842 class842_1, ChartType_Chart chartType_Chart_2)
	{
		class821_0 = class821_1;
		class842_0 = class842_1;
		Type = chartType_Chart_2;
		class832_0 = new Class832(class821_1, this, Enum52.const_12);
		class840_0 = new Class840(class821_1, Enum57.const_8);
		class822_0 = new Class822(class821_1, this, Enum52.const_6);
		class841_0 = new Class841(class821_1, this);
		class840_4 = new Class840(class821_1, Enum57.const_20);
		class849_0 = new Class849(class821_1, this);
		class830_0 = new Class830(class821_1, this);
		int_0 = 150;
		class840_1 = new Class840(class821_1, Enum57.const_21);
		class840_2 = new Class840(class821_1, Enum57.const_22);
		class840_3 = new Class840(class821_1, Enum57.const_23);
		class829_0 = new Class829(class821_1, this, Enum52.const_14, Enum57.const_16);
		class829_1 = new Class829(class821_1, this, Enum52.const_15, Enum57.const_17);
		class829_1.method_1().ForegroundColor = Color.Black;
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
			class840_0.Formatting = Enum71.const_0;
			break;
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
			Smooth = true;
			break;
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
			method_7().MarkerStyle = Enum65.const_5;
			Smooth = true;
			break;
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.Radar:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			method_7().MarkerStyle = Enum65.const_5;
			break;
		case ChartType_Chart.PiePie:
		case ChartType_Chart.PieBar:
			class831_0 = new Class831(class821_0);
			class831_0.method_2(class830_0);
			HasSeriesLines = true;
			break;
		}
		switch (Type)
		{
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.LineWithDataMarkers:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Radar:
		case ChartType_Chart.RadarWithDataMarkers:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			class840_0.method_0().Width = 3.0;
			break;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Class844)
		{
			Class844 @class = (Class844)obj;
			if (this != obj)
			{
				return false;
			}
			if (class842_0 != @class.class842_0)
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return (Index + 1).GetHashCode() + class842_0.GetHashCode();
	}

	[SpecialName]
	internal Class832 method_2()
	{
		return class832_0;
	}

	[SpecialName]
	internal Class834 method_3()
	{
		if (class834_0 == null)
		{
			class834_0 = new Class834(class821_0, this);
		}
		return class834_0;
	}

	[SpecialName]
	internal Class834 method_4()
	{
		if (class834_1 == null)
		{
			class834_1 = new Class834(class821_0, this);
		}
		class834_1.imethod_0(bool_2: false);
		return class834_1;
	}

	[SpecialName]
	internal Class840 method_5()
	{
		return class840_0;
	}

	[SpecialName]
	internal Class822 method_6()
	{
		return class822_0;
	}

	[SpecialName]
	internal Class841 method_7()
	{
		return class841_0;
	}

	internal string method_8()
	{
		return Name;
	}

	[SpecialName]
	internal Class830 method_9()
	{
		return class830_0;
	}

	[SpecialName]
	internal Class849 method_10()
	{
		return class849_0;
	}

	[SpecialName]
	public Interface31 imethod_3()
	{
		return class849_0;
	}

	[SpecialName]
	internal bool method_11()
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
	internal Class840 method_12()
	{
		return class840_2;
	}

	[SpecialName]
	internal Class840 method_13()
	{
		return class840_3;
	}

	[SpecialName]
	public Interface25 imethod_5()
	{
		return class840_3;
	}

	[SpecialName]
	internal Class840 method_14()
	{
		return class840_1;
	}

	[SpecialName]
	internal Class829 method_15()
	{
		return class829_0;
	}

	[SpecialName]
	internal Class829 method_16()
	{
		return class829_1;
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
	internal Class840 method_17()
	{
		return class840_4;
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
	public void imethod_10(bool bool_14)
	{
		bool_10 = bool_14;
	}

	[SpecialName]
	public bool method_18()
	{
		foreach (Class831 item in class830_0)
		{
			if (item.vmethod_2() != Enum1.const_3)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public bool method_19()
	{
		foreach (Class831 item in class830_0)
		{
			if (item.vmethod_4() != Enum1.const_3)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	internal Enum53 method_20()
	{
		if (PlotOnSecondAxis)
		{
			return Enum53.const_1;
		}
		return Enum53.const_0;
	}

	[SpecialName]
	internal void method_21(Enum53 enum53_0)
	{
		if (enum53_0 == Enum53.const_1)
		{
			PlotOnSecondAxis = true;
		}
		else
		{
			PlotOnSecondAxis = false;
		}
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
	public int vmethod_4()
	{
		return int_7;
	}

	[SpecialName]
	public void imethod_0(int int_9)
	{
		int_7 = int_9;
	}

	[SpecialName]
	internal bool method_26()
	{
		if (Type != ChartType_Chart.Line && Type != ChartType_Chart.LineStacked && Type != ChartType_Chart.Line100PercentStacked && Type != ChartType_Chart.LineWithDataMarkers && Type != ChartType_Chart.LineStackedWithDataMarkers && Type != ChartType_Chart.Line100PercentStackedWithDataMarkers && Type != ChartType_Chart.Radar && Type != ChartType_Chart.RadarWithDataMarkers && Type != ChartType_Chart.Scatter && Type != ChartType_Chart.ScatterConnectedByCurvesWithDataMarker && Type != ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker && Type != ChartType_Chart.ScatterConnectedByLinesWithDataMarker && Type != ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker)
		{
			return false;
		}
		return true;
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
			if (method_5().IsVisible)
			{
				return true;
			}
			return false;
		}
	}

	[SpecialName]
	internal bool method_28()
	{
		if (Type == ChartType_Chart.Column)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_29()
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
	internal bool method_30()
	{
		ChartType_Chart type = Type;
		if (type != ChartType_Chart.AreaStacked && type != ChartType_Chart.Area3DStacked)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_31()
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
	internal bool method_32()
	{
		ChartType_Chart type = Type;
		if (type != ChartType_Chart.Area100PercentStacked && type != ChartType_Chart.Area3D100PercentStacked)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_33()
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
	internal bool method_34()
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
	internal bool method_35()
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
	internal bool method_36()
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
	internal bool method_37()
	{
		foreach (Class831 item in method_9())
		{
			if (item.method_6().method_1())
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public int vmethod_5()
	{
		return int_8;
	}

	[SpecialName]
	public void imethod_1(int int_9)
	{
		int_8 = int_9;
	}

	[SpecialName]
	public void imethod_9(bool bool_14)
	{
		bool_11 = bool_14;
	}

	[SpecialName]
	internal bool method_38()
	{
		foreach (Class831 item in class830_0)
		{
			if (!item.method_6().method_3())
			{
				return false;
			}
		}
		return true;
	}

	~Class844()
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
			if (class832_0 != null)
			{
				class832_0.Dispose();
			}
			if (class822_0 != null)
			{
				class822_0.Dispose();
			}
			if (class829_0 != null)
			{
				class829_0.Dispose();
			}
			if (class829_1 != null)
			{
				class829_1.Dispose();
			}
			if (class830_0 != null)
			{
				for (int i = 0; i < class830_0.Count; i++)
				{
					class830_0.method_1(i)?.Dispose();
				}
			}
			if (class831_0 != null)
			{
				class831_0.Dispose();
			}
			if (class849_0 != null)
			{
				for (int j = 0; j < class849_0.Count; j++)
				{
					class849_0.method_1(j)?.Dispose();
				}
			}
		}
		bool_13 = true;
	}
}
