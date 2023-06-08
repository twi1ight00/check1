using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class815 : IDisposable, Interface32
{
	private Class787 class787_0;

	private Class806 class806_0;

	private Class813 class813_0;

	private double double_0;

	private bool bool_0;

	private bool bool_1;

	private double double_1;

	private double double_2;

	private bool bool_2;

	private string string_0;

	private int int_0;

	private int int_1;

	private Enum88 enum88_0;

	private Class798 class798_0;

	private double[] double_3;

	private double double_4;

	private bool bool_3;

	private int int_2;

	internal PointF pointF_0 = PointF.Empty;

	private bool bool_4;

	public Interface25 Border => class806_0;

	public double Backward
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

	public bool DisplayEquation
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

	public bool DisplayRSquared
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

	public double Forward
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

	public double Intercept
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			bool_3 = true;
		}
	}

	public bool IsNameAuto
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

	public string Name
	{
		get
		{
			if (IsNameAuto)
			{
				Class810 @class = class813_0.method_0();
				return Type switch
				{
					Enum88.const_0 => "Expon.(" + @class.Name + ")", 
					Enum88.const_1 => "Linear(" + @class.Name + ")", 
					Enum88.const_2 => "Log.(" + @class.Name + ")", 
					Enum88.const_3 => int_1 + " per. Mov. Avg.(" + @class.Name + ")", 
					Enum88.const_4 => "Poly.(" + @class.Name + ")", 
					Enum88.const_5 => "Power(" + @class.Name + ")", 
					_ => "", 
				};
			}
			return string_0;
		}
		set
		{
			string_0 = value;
			IsNameAuto = false;
		}
	}

	public int Order
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int Period
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Interface17 DataLabels => class798_0;

	public Enum88 Type
	{
		get
		{
			return enum88_0;
		}
		set
		{
			enum88_0 = value;
		}
	}

	internal Class787 Chart => class787_0;

	internal int Index => method_1().method_2().IndexOf(this);

	internal Class815(Class787 class787_1, Class813 class813_1)
	{
		class787_0 = class787_1;
		class806_0 = new Class806(class787_1);
		class806_0.LineStyle.Width = 2.0;
		class813_0 = class813_1;
		double_0 = 0.0;
		bool_0 = false;
		bool_1 = false;
		double_1 = 0.0;
		double_2 = 0.0;
		bool_2 = false;
		string_0 = "";
		int_0 = 2;
		int_1 = 2;
		enum88_0 = Enum88.const_0;
		class798_0 = new Class798(class787_1, this, Enum52.const_16);
	}

	[SpecialName]
	internal Class806 method_0()
	{
		return class806_0;
	}

	[SpecialName]
	internal Class813 method_1()
	{
		return class813_0;
	}

	[SpecialName]
	internal bool method_2()
	{
		return bool_3;
	}

	[SpecialName]
	internal Class798 method_3()
	{
		return class798_0;
	}

	[SpecialName]
	internal double[] method_4()
	{
		return double_3;
	}

	[SpecialName]
	internal void method_5(double[] double_5)
	{
		double_3 = double_5;
	}

	[SpecialName]
	internal double method_6()
	{
		return double_4;
	}

	[SpecialName]
	internal void method_7(double double_5)
	{
		double_4 = double_5;
	}

	[SpecialName]
	public int vmethod_0()
	{
		return int_2;
	}

	[SpecialName]
	public void imethod_0(int int_3)
	{
		int_2 = int_3;
	}

	~Class815()
	{
		Dispose(bool_5: false);
	}

	public void Dispose()
	{
		Dispose(bool_5: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_5)
	{
		if (!bool_4)
		{
			if (bool_5 && class798_0 != null)
			{
				class798_0.Dispose();
			}
			bool_4 = true;
		}
	}
}
