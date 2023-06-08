using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns33;

internal class Class831 : IDisposable, Interface16
{
	private Class830 class830_0;

	private Class821 class821_0;

	private Class822 class822_0;

	private Class840 class840_0;

	private Class841 class841_0;

	private Class832 class832_0;

	private double double_0;

	private object object_0;

	private double double_1;

	private object object_1;

	private double double_2;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private Enum1 enum1_0 = Enum1.const_6;

	private Enum1 enum1_1 = Enum1.const_6;

	internal float float_0;

	private float float_1;

	private bool bool_8 = true;

	private bool bool_9;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private bool bool_10;

	public Interface8 Area => class822_0;

	public Interface25 Border => class840_0;

	public Interface26 Marker => class841_0;

	public Interface17 DataLabels => class832_0;

	public double XValue
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

	public double YValue
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public float Explosion
	{
		get
		{
			if (bool_8)
			{
				return class830_0.method_0().Explosion;
			}
			return float_1;
		}
		set
		{
			float_1 = value;
			bool_8 = false;
		}
	}

	internal Class821 Chart => class821_0;

	internal int Index => method_1().method_2().IndexOf(this);

	[SpecialName]
	public bool imethod_0()
	{
		return bool_6;
	}

	[SpecialName]
	public void imethod_1(bool bool_11)
	{
		bool_6 = bool_11;
	}

	[SpecialName]
	public bool imethod_2()
	{
		return bool_5;
	}

	[SpecialName]
	public void imethod_3(bool bool_11)
	{
		bool_5 = bool_11;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_7;
	}

	[SpecialName]
	public void imethod_4(bool bool_11)
	{
		bool_7 = bool_11;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_3;
	}

	[SpecialName]
	public void imethod_5(bool bool_11)
	{
		bool_3 = bool_11;
	}

	[SpecialName]
	public bool imethod_6()
	{
		return bool_4;
	}

	[SpecialName]
	public void imethod_7(bool bool_11)
	{
		bool_4 = bool_11;
	}

	internal Class831(Class821 class821_1)
	{
		class821_0 = class821_1;
		class822_0 = new Class822(class821_1, this, Enum52.const_7);
		class840_0 = new Class840(class821_1, Enum57.const_9);
		class841_0 = new Class841(class821_1, this);
		class832_0 = new Class832(class821_1, this, Enum52.const_12);
	}

	internal void method_0()
	{
		if (class830_0 != null && class830_0.method_0() != null)
		{
			switch (class830_0.method_0().Type)
			{
			case ChartType_Chart.Scatter:
				class840_0.Formatting = Enum71.const_0;
				break;
			case ChartType_Chart.Line:
			case ChartType_Chart.LineStacked:
			case ChartType_Chart.Line100PercentStacked:
			case ChartType_Chart.Radar:
			case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
			case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
				method_5().MarkerStyle = Enum65.const_5;
				method_4().method_0().Width = 3.0;
				break;
			}
			switch (class830_0.method_0().Type)
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
				method_4().method_0().Width = 3.0;
				break;
			}
		}
	}

	internal Class831(Class821 class821_1, double double_3)
		: this(class821_1)
	{
		double_1 = double_3;
	}

	[SpecialName]
	internal Class830 method_1()
	{
		return class830_0;
	}

	[SpecialName]
	internal void method_2(Class830 class830_1)
	{
		class830_0 = class830_1;
	}

	[SpecialName]
	internal Class822 method_3()
	{
		return class822_0;
	}

	[SpecialName]
	internal Class840 method_4()
	{
		return class840_0;
	}

	[SpecialName]
	internal Class841 method_5()
	{
		return class841_0;
	}

	[SpecialName]
	internal Class832 method_6()
	{
		return class832_0;
	}

	[SpecialName]
	public Enum1 vmethod_2()
	{
		return enum1_0;
	}

	[SpecialName]
	public void imethod_8(Enum1 enum1_2)
	{
		enum1_0 = enum1_2;
	}

	[SpecialName]
	public object vmethod_3()
	{
		if (object_0 == null)
		{
			return XValue;
		}
		return object_0;
	}

	[SpecialName]
	public void imethod_9(object object_2)
	{
		object_0 = object_2;
	}

	[SpecialName]
	public string imethod_10()
	{
		return string_0;
	}

	[SpecialName]
	public void imethod_11(string string_3)
	{
		string_0 = string_3;
	}

	[SpecialName]
	public bool imethod_12()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_13(bool bool_11)
	{
		bool_0 = bool_11;
	}

	[SpecialName]
	public Enum1 vmethod_4()
	{
		return enum1_1;
	}

	[SpecialName]
	public void imethod_14(Enum1 enum1_2)
	{
		enum1_1 = enum1_2;
	}

	[SpecialName]
	public object vmethod_5()
	{
		return object_1;
	}

	[SpecialName]
	public void imethod_15(object object_2)
	{
		object_1 = object_2;
	}

	[SpecialName]
	public string vmethod_6()
	{
		return string_1;
	}

	[SpecialName]
	public void imethod_16(string string_3)
	{
		string_1 = string_3;
	}

	[SpecialName]
	public bool vmethod_7()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_17(bool bool_11)
	{
		bool_1 = bool_11;
	}

	[SpecialName]
	public double vmethod_8()
	{
		return double_2;
	}

	[SpecialName]
	public void imethod_18(double double_3)
	{
		double_2 = double_3;
	}

	[SpecialName]
	public string vmethod_9()
	{
		return string_2;
	}

	[SpecialName]
	public void imethod_19(string string_3)
	{
		string_2 = string_3;
	}

	[SpecialName]
	public bool vmethod_10()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_20(bool bool_11)
	{
		bool_2 = bool_11;
	}

	[SpecialName]
	internal bool method_7()
	{
		if (YValue < 0.0)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public void imethod_21(bool bool_11)
	{
		bool_9 = bool_11;
	}

	[SpecialName]
	internal RectangleF method_8()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal void method_9(RectangleF rectangleF_1)
	{
		rectangleF_0 = rectangleF_1;
	}

	~Class831()
	{
		Dispose(bool_11: false);
	}

	public void Dispose()
	{
		Dispose(bool_11: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_11)
	{
		if (bool_10)
		{
			return;
		}
		if (bool_11)
		{
			if (class832_0 != null)
			{
				class832_0.Dispose();
			}
			if (class822_0 != null)
			{
				class822_0.Dispose();
			}
		}
		bool_10 = true;
	}
}
