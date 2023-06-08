using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class789 : IDisposable, Interface9
{
	private Class787 class787_0;

	private Enum61 enum61_0;

	private bool bool_0;

	private Class806 class806_0;

	private Enum87 enum87_0;

	private bool bool_1 = true;

	private Enum64 enum64_0;

	private double double_0;

	private Enum66 enum66_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private Class806 class806_1;

	private Class806 class806_2;

	private Enum84 enum84_0;

	private double double_1;

	private Enum87 enum87_1;

	private double double_2;

	private Enum84 enum84_1;

	private double double_3;

	private Enum87 enum87_2;

	private double double_4;

	private Enum83 enum83_0;

	private Class811 class811_0;

	private int int_0;

	private bool bool_5;

	private int int_1;

	private Class812 class812_0;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private Class799 class799_0;

	internal ArrayList arrayList_0 = new ArrayList();

	internal double double_5;

	internal double double_6;

	internal double double_7;

	internal double double_8;

	private int int_2;

	private int int_3;

	internal float float_0;

	internal float float_1;

	internal float float_2;

	internal float float_3;

	internal float float_4;

	internal float float_5;

	internal ArrayList arrayList_1;

	internal int int_4;

	internal bool bool_10 = true;

	internal bool bool_11;

	private Enum54 enum54_0;

	private Enum0 enum0_0 = Enum0.const_3;

	internal bool bool_12;

	internal bool bool_13;

	private double double_9 = 10.0;

	private string string_0 = "";

	private PointF pointF_0 = PointF.Empty;

	private PointF pointF_1 = PointF.Empty;

	private bool bool_14;

	public bool AxisBetweenCategories
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

	public Interface25 AxisLine => class806_0;

	public Enum87 BaseUnitScale
	{
		get
		{
			return enum87_0;
		}
		set
		{
			enum87_0 = value;
			imethod_1(bool_15: false);
		}
	}

	public Enum64 CategoryType
	{
		get
		{
			return enum64_0;
		}
		set
		{
			enum64_0 = value;
		}
	}

	public double CrossAt
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			enum66_0 = Enum66.const_2;
		}
	}

	public Enum66 CrossType
	{
		get
		{
			return enum66_0;
		}
		set
		{
			enum66_0 = value;
			if (value == Enum66.const_1)
			{
				bool_11 = true;
			}
		}
	}

	public bool IsLogarithmic
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

	public double LogBase
	{
		set
		{
			double_9 = value;
		}
	}

	public bool IsPlotOrderReversed
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool IsVisible
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

	public Interface25 MajorGridLines => class806_1;

	public Interface25 MinorGridLines => class806_2;

	public Enum84 MajorTickMark
	{
		get
		{
			return enum84_0;
		}
		set
		{
			enum84_0 = value;
		}
	}

	public double MajorUnit
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value > 0.0)
			{
				double_1 = value;
				bool_8 = false;
			}
		}
	}

	public Enum87 MajorUnitScale
	{
		get
		{
			return enum87_1;
		}
		set
		{
			enum87_1 = value;
		}
	}

	public double MaxValue
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			bool_7 = false;
		}
	}

	public Enum84 MinorTickMark
	{
		get
		{
			return enum84_1;
		}
		set
		{
			enum84_1 = value;
		}
	}

	public double MinorUnit
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
			imethod_10(bool_15: false);
		}
	}

	public Enum87 MinorUnitScale
	{
		get
		{
			return enum87_2;
		}
		set
		{
			enum87_2 = value;
		}
	}

	public double MinValue
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
			imethod_4(bool_15: false);
		}
	}

	public Enum83 TickLabelPosition
	{
		get
		{
			return enum83_0;
		}
		set
		{
			enum83_0 = value;
		}
	}

	public Interface29 TickLabels => class811_0;

	public int TickLabelSpacing
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value > 0)
			{
				int_0 = value;
			}
		}
	}

	public int TickMarkSpacing
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value > 0)
			{
				int_1 = value;
			}
		}
	}

	public Interface30 Title => class812_0;

	public Interface18 DisplayUnit => class799_0;

	internal Class787 Chart => class787_0;

	[SpecialName]
	internal Enum54 method_0()
	{
		return enum54_0;
	}

	[SpecialName]
	internal void method_1(Enum54 enum54_1)
	{
		enum54_0 = enum54_1;
	}

	[SpecialName]
	internal bool method_2()
	{
		if (method_3() != 0 && method_3() != Enum61.const_2)
		{
			return false;
		}
		return true;
	}

	internal Class789(Class787 class787_1, Enum61 enum61_1)
	{
		class787_0 = class787_1;
		enum61_0 = enum61_1;
		bool_0 = true;
		class806_0 = new Class806(class787_1);
		enum87_0 = Enum87.const_0;
		enum64_0 = Enum64.const_1;
		enum66_0 = Enum66.const_0;
		class806_1 = new Class806(class787_1);
		class806_2 = new Class806(class787_1);
		class806_2.Formatting = Enum71.const_0;
		switch (enum61_1)
		{
		case Enum61.const_0:
			class806_1.Formatting = Enum71.const_0;
			break;
		case Enum61.const_2:
			class806_1.Formatting = Enum71.const_0;
			break;
		case Enum61.const_3:
			class806_1.Formatting = Enum71.const_0;
			break;
		case Enum61.const_4:
			class806_1.Formatting = Enum71.const_0;
			break;
		}
		class812_0 = new Class812(class787_1, this, Enum52.const_9);
		bool_2 = false;
		bool_3 = false;
		bool_4 = true;
		enum84_0 = Enum84.const_3;
		double_1 = 0.0;
		enum87_1 = Enum87.const_0;
		double_2 = 0.0;
		enum84_1 = Enum84.const_2;
		double_3 = 0.0;
		enum87_2 = Enum87.const_0;
		double_4 = 0.0;
		enum83_0 = Enum83.const_2;
		class811_0 = new Class811(this);
		int_0 = 1;
		bool_5 = true;
		int_1 = 1;
		bool_6 = true;
		bool_7 = true;
		bool_8 = true;
		bool_9 = true;
		arrayList_1 = new ArrayList();
		int_2 = 4;
		int_3 = 3;
		class799_0 = new Class799(class787_1, this, Enum52.const_13);
	}

	[SpecialName]
	internal Enum61 method_3()
	{
		return enum61_0;
	}

	[SpecialName]
	internal Enum0 method_4()
	{
		return enum0_0;
	}

	[SpecialName]
	internal void method_5(Enum0 enum0_1)
	{
		enum0_0 = enum0_1;
	}

	[SpecialName]
	public Class806 method_6()
	{
		return class806_0;
	}

	[SpecialName]
	public bool imethod_0()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_1(bool bool_15)
	{
		bool_1 = bool_15;
	}

	[SpecialName]
	internal Class806 method_7()
	{
		return class806_1;
	}

	[SpecialName]
	internal Class806 method_8()
	{
		return class806_2;
	}

	[SpecialName]
	internal Class811 method_9()
	{
		return class811_0;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_5;
	}

	[SpecialName]
	public void imethod_2(bool bool_15)
	{
		bool_5 = bool_15;
	}

	[SpecialName]
	internal Class812 method_10()
	{
		return class812_0;
	}

	[SpecialName]
	public bool imethod_3()
	{
		return bool_6;
	}

	[SpecialName]
	public void imethod_4(bool bool_15)
	{
		bool_6 = bool_15;
	}

	[SpecialName]
	public bool imethod_5()
	{
		return bool_7;
	}

	[SpecialName]
	public void imethod_6(bool bool_15)
	{
		bool_7 = bool_15;
	}

	[SpecialName]
	public bool imethod_7()
	{
		return bool_8;
	}

	[SpecialName]
	public void imethod_8(bool bool_15)
	{
		bool_8 = bool_15;
	}

	[SpecialName]
	public bool imethod_9()
	{
		return bool_9;
	}

	[SpecialName]
	public void imethod_10(bool bool_15)
	{
		bool_9 = bool_15;
	}

	[SpecialName]
	internal Class799 method_11()
	{
		return class799_0;
	}

	[SpecialName]
	public void imethod_11(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	internal double method_12()
	{
		if (IsLogarithmic)
		{
			return Struct40.smethod_7(MaxValue);
		}
		return MaxValue;
	}

	[SpecialName]
	internal double method_13()
	{
		if (IsLogarithmic)
		{
			return Struct40.smethod_7(MinValue);
		}
		return MinValue;
	}

	[SpecialName]
	internal double method_14()
	{
		if (IsLogarithmic)
		{
			return Struct40.smethod_7(CrossAt);
		}
		return CrossAt;
	}

	[SpecialName]
	internal double method_15()
	{
		if (IsLogarithmic)
		{
			return Struct40.smethod_7(MajorUnit);
		}
		return MajorUnit;
	}

	[SpecialName]
	internal double method_16()
	{
		if (IsLogarithmic)
		{
			return Struct40.smethod_7(MinorUnit);
		}
		return MinorUnit;
	}

	internal double method_17(double double_10)
	{
		if (double_10 > method_12())
		{
			double_10 = method_12();
		}
		if (double_10 < method_13())
		{
			double_10 = method_13();
		}
		return double_10;
	}

	[SpecialName]
	internal int method_18()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_19(int int_5)
	{
		int_2 = int_5;
	}

	[SpecialName]
	internal int method_20()
	{
		return int_3;
	}

	[SpecialName]
	internal void method_21(int int_5)
	{
		int_3 = int_5;
	}

	[SpecialName]
	internal void method_22(PointF pointF_2)
	{
		pointF_0 = pointF_2;
	}

	[SpecialName]
	internal void method_23(PointF pointF_2)
	{
		pointF_1 = pointF_2;
	}

	~Class789()
	{
		Dispose(bool_15: false);
	}

	public void Dispose()
	{
		Dispose(bool_15: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_15)
	{
		if (bool_14)
		{
			return;
		}
		if (bool_15)
		{
			if (class811_0 != null)
			{
				class811_0.Dispose();
			}
			if (class812_0 != null)
			{
				class812_0.Dispose();
			}
			if (class799_0 != null)
			{
				class799_0.Dispose();
			}
		}
		bool_14 = true;
	}
}
