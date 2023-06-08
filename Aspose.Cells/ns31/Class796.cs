using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;

namespace ns31;

internal class Class796 : IDisposable, Interface16
{
	private Class795 class795_0;

	private Class787 class787_0;

	private Class788 class788_0;

	private Class806 class806_0;

	private Class807 class807_0;

	private Class798 class798_0;

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

	private double double_3;

	private Enum1 enum1_1 = Enum1.const_6;

	private double double_4;

	internal float float_0;

	private float float_1;

	private bool bool_8 = true;

	private bool bool_9;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private bool bool_10;

	public Interface8 Area => class788_0;

	public Interface25 Border => class806_0;

	public Interface26 Marker => class807_0;

	public Interface17 DataLabels => class798_0;

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
				return class795_0.method_0().Explosion;
			}
			return float_1;
		}
		set
		{
			float_1 = value;
			bool_8 = false;
		}
	}

	internal Class787 Chart => class787_0;

	internal int Index => method_1().method_2().IndexOf(this);

	[SpecialName]
	public bool imethod_0()
	{
		return bool_5;
	}

	[SpecialName]
	public void imethod_1(bool bool_11)
	{
		bool_5 = bool_11;
	}

	[SpecialName]
	public bool imethod_2()
	{
		return bool_6;
	}

	[SpecialName]
	public void imethod_3(bool bool_11)
	{
		bool_6 = bool_11;
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

	internal Class796(Class787 class787_1)
	{
		class787_0 = class787_1;
		class788_0 = new Class788(class787_1);
		class806_0 = new Class806(class787_1);
		class807_0 = new Class807(class787_1, this);
		class798_0 = new Class798(class787_1, this, Enum52.const_12);
	}

	internal void method_0()
	{
		if (class795_0 != null && class795_0.method_0() != null)
		{
			ChartType_Chart type = class795_0.method_0().Type;
			if (type == ChartType_Chart.Scatter)
			{
				class806_0.Formatting = Enum71.const_0;
			}
		}
	}

	internal Class796(Class787 class787_1, double double_5)
		: this(class787_1)
	{
		double_1 = double_5;
	}

	[SpecialName]
	internal Class795 method_1()
	{
		return class795_0;
	}

	[SpecialName]
	internal void method_2(Class795 class795_1)
	{
		class795_0 = class795_1;
	}

	[SpecialName]
	internal Class788 method_3()
	{
		return class788_0;
	}

	[SpecialName]
	internal Class806 method_4()
	{
		return class806_0;
	}

	[SpecialName]
	internal Class807 method_5()
	{
		return class807_0;
	}

	[SpecialName]
	internal Class798 method_6()
	{
		return class798_0;
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
	internal void method_7(double double_5)
	{
		double_3 = double_5;
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
	internal double method_8()
	{
		return double_4;
	}

	[SpecialName]
	internal void method_9(double double_5)
	{
		double_4 = double_5;
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
	public void imethod_18(double double_5)
	{
		double_2 = double_5;
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
	public bool vmethod_11()
	{
		return bool_9;
	}

	[SpecialName]
	public void imethod_21(bool bool_11)
	{
		bool_9 = bool_11;
	}

	[SpecialName]
	internal bool method_10()
	{
		if (imethod_6() && vmethod_5() != null && vmethod_5().ToString() == "#N/A")
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal RectangleF method_11()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal void method_12(RectangleF rectangleF_1)
	{
		rectangleF_0 = rectangleF_1;
	}

	~Class796()
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
			if (class798_0 != null)
			{
				class798_0.Dispose();
			}
			if (class788_0 != null)
			{
				class788_0.Dispose();
			}
			if (class807_0 != null)
			{
				class807_0.Dispose();
			}
		}
		bool_10 = true;
	}
}
