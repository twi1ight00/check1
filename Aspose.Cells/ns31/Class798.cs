using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class798 : IDisposable, Interface17
{
	private Class794 class794_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Enum74 enum74_0;

	private Enum75 enum75_0;

	private int int_0;

	private Enum82 enum82_0;

	private Enum82 enum82_1;

	private bool bool_6 = true;

	private string string_0 = "";

	private bool bool_7;

	private string string_1;

	private Class864 class864_0 = new Class864();

	internal RectangleF rectangleF_0;

	internal RectangleF rectangleF_1;

	internal RectangleF rectangleF_2;

	internal PointF pointF_0 = PointF.Empty;

	internal PointF pointF_1 = PointF.Empty;

	internal PointF pointF_2 = PointF.Empty;

	internal double double_0;

	internal bool bool_8;

	private bool bool_9;

	public bool IsCategoryNameShown
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

	public bool IsLegendKeyShown
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

	public bool IsPercentageShown
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

	public bool IsValueShown
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

	public bool IsSeriesNameShown
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

	public bool IsBubbleSizeShown
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

	public Enum75 Separator
	{
		get
		{
			return enum75_0;
		}
		set
		{
			enum75_0 = value;
		}
	}

	public int Rotation
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

	public Enum82 TextHorizontalAlignment
	{
		get
		{
			return enum82_0;
		}
		set
		{
			enum82_0 = value;
		}
	}

	public Enum82 TextVerticalAlignment
	{
		get
		{
			return enum82_1;
		}
		set
		{
			enum82_1 = value;
		}
	}

	public bool LinkedSource
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public string Text
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			if (Text != null && Text.Length > 0)
			{
				return true;
			}
			if (!IsBubbleSizeShown && !IsCategoryNameShown && !IsPercentageShown && !IsSeriesNameShown && !IsValueShown)
			{
				return false;
			}
			return true;
		}
	}

	internal Class798(Class787 class787_0, object object_0, Enum52 enum52_0)
	{
		class794_0 = new Class794(class787_0, object_0, enum52_0);
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		enum74_0 = Enum74.const_0;
		enum75_0 = Enum75.const_0;
		int_0 = 0;
		enum82_0 = Enum82.const_1;
		enum82_1 = Enum82.const_1;
		string_1 = null;
		class864_0 = new Class864();
	}

	[SpecialName]
	internal Class794 method_0()
	{
		return class794_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class794_0;
	}

	[SpecialName]
	public Enum74 vmethod_0()
	{
		if (class794_0.imethod_0() && class794_0.vmethod_2())
		{
			return enum74_0;
		}
		return Enum74.const_9;
	}

	[SpecialName]
	public void imethod_1(Enum74 enum74_1)
	{
		enum74_0 = enum74_1;
	}

	[SpecialName]
	public string imethod_2()
	{
		return string_0;
	}

	[SpecialName]
	public void imethod_3(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_7;
	}

	[SpecialName]
	internal bool method_1()
	{
		if (Text != null && Text != "")
		{
			return true;
		}
		if (IsSeriesNameShown)
		{
			return true;
		}
		if (IsCategoryNameShown)
		{
			return true;
		}
		if (IsValueShown)
		{
			return true;
		}
		Class810 @class = null;
		if (class794_0.method_0() is Class810)
		{
			@class = (Class810)class794_0.method_0();
		}
		else if (class794_0.method_0() is Class796)
		{
			@class = ((Class796)class794_0.method_0()).method_1().method_0();
		}
		if (@class != null && @class.method_34() && IsPercentageShown)
		{
			return true;
		}
		if (@class != null && @class.method_37() && IsBubbleSizeShown)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public Interface38 imethod_4()
	{
		return class864_0;
	}

	[SpecialName]
	internal bool method_2()
	{
		return class864_0.Count > 0;
	}

	[SpecialName]
	internal bool method_3()
	{
		if (!IsSeriesNameShown)
		{
			return false;
		}
		if (IsCategoryNameShown)
		{
			return false;
		}
		if (IsValueShown)
		{
			return false;
		}
		Class810 @class = null;
		if (class794_0.method_0() is Class810)
		{
			@class = (Class810)class794_0.method_0();
		}
		else if (class794_0.method_0() is Class796)
		{
			@class = ((Class796)class794_0.method_0()).method_1().method_0();
		}
		if (@class != null && @class.method_34() && IsPercentageShown)
		{
			return false;
		}
		if (@class != null && @class.method_37() && IsBubbleSizeShown)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal int method_4()
	{
		int num = 0;
		Class810 @class = null;
		if (class794_0.method_0() is Class810)
		{
			@class = (Class810)class794_0.method_0();
		}
		else if (class794_0.method_0() is Class796)
		{
			@class = ((Class796)class794_0.method_0()).method_1().method_0();
		}
		if (@class == null)
		{
			return 27;
		}
		if (@class.method_28())
		{
			return 27;
		}
		return method_5();
	}

	private int method_5()
	{
		int num = 0;
		float num2 = 0f;
		num2 = ((!(method_0().Font.Size <= 6f)) ? 0.465f : 0.6f);
		if (method_0().Font != null)
		{
			num = Struct40.smethod_5(method_0().method_17() * num2);
			if (num < 3)
			{
				return 3;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_6()
	{
		int num = 0;
		if (method_0().Font != null)
		{
			return Struct40.smethod_5(method_0().method_17());
		}
		return 0;
	}

	[SpecialName]
	internal bool method_7()
	{
		if (double_0 > -4.71238898038469 && double_0 < -Math.PI / 2.0)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_8()
	{
		double num = 0.008697830681563268;
		if ((double_0 < num && double_0 > -Math.PI) || double_0 < Math.PI * -2.0 + num)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal int method_9()
	{
		if (!method_7() && !method_8())
		{
			return 1;
		}
		if (!method_7() && method_8())
		{
			return 2;
		}
		if (method_7() && method_8())
		{
			return 3;
		}
		return 4;
	}

	~Class798()
	{
		Dispose(bool_10: false);
	}

	public void Dispose()
	{
		Dispose(bool_10: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_10)
	{
		if (bool_9)
		{
			return;
		}
		if (bool_10)
		{
			if (class794_0 != null)
			{
				class794_0.Dispose();
			}
			if (class864_0 != null)
			{
				for (int i = 0; i < class864_0.Count; i++)
				{
					class864_0.method_0(i)?.Dispose();
				}
			}
		}
		bool_9 = true;
	}
}
