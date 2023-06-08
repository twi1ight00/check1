using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class832 : IDisposable, Interface17
{
	private Class829 class829_0;

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

	private bool bool_6;

	private string string_0 = "";

	private bool bool_7;

	private string string_1;

	private Class864 class864_0;

	internal RectangleF rectangleF_0;

	internal RectangleF rectangleF_1;

	internal PointF pointF_0 = PointF.Empty;

	internal PointF pointF_1 = PointF.Empty;

	internal PointF pointF_2 = PointF.Empty;

	internal double double_0;

	private bool bool_8;

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

	internal Class832(Class821 class821_0, object object_0, Enum52 enum52_0)
	{
		class829_0 = new Class829(class821_0, object_0, enum52_0, Enum57.const_14);
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
		bool_6 = true;
		class864_0 = new Class864();
	}

	[SpecialName]
	internal Class829 method_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Enum74 vmethod_0()
	{
		if (method_0().imethod_0() && method_0().vmethod_1())
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
		Class844 @class = null;
		if (class829_0.method_0() is Class844)
		{
			@class = (Class844)class829_0.method_0();
		}
		else if (class829_0.method_0() is Class831)
		{
			@class = ((Class831)class829_0.method_0()).method_1().method_0();
		}
		if (@class != null && @class.method_33() && IsPercentageShown)
		{
			return true;
		}
		if (@class != null && @class.method_35() && IsBubbleSizeShown)
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
		Class844 @class = null;
		if (class829_0.method_0() is Class844)
		{
			@class = (Class844)class829_0.method_0();
		}
		else if (class829_0.method_0() is Class831)
		{
			@class = ((Class831)class829_0.method_0()).method_1().method_0();
		}
		if (@class != null && @class.method_33() && IsPercentageShown)
		{
			return false;
		}
		if (@class != null && @class.method_35() && IsBubbleSizeShown)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal int method_4()
	{
		int num = 0;
		Class844 @class = null;
		if (class829_0.method_0() is Class844)
		{
			@class = (Class844)class829_0.method_0();
		}
		else if (class829_0.method_0() is Class831)
		{
			@class = ((Class831)class829_0.method_0()).method_1().method_0();
		}
		if (@class == null)
		{
			return 27;
		}
		if (@class.method_27())
		{
			return 27;
		}
		return method_5();
	}

	internal int method_5()
	{
		int num = 0;
		float num2 = 0f;
		num2 = ((!(method_0().Font.Size <= 6f)) ? 0.465f : 0.6f);
		if (method_0().Font != null)
		{
			num = Struct63.smethod_5(method_0().method_15() * num2);
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
			return Struct63.smethod_5(method_0().method_15());
		}
		return 0;
	}

	~Class832()
	{
		Dispose(bool_9: false);
	}

	public void Dispose()
	{
		Dispose(bool_9: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_9)
	{
		if (bool_8)
		{
			return;
		}
		if (bool_9)
		{
			if (class829_0 != null)
			{
				class829_0.Dispose();
			}
			if (class864_0 != null)
			{
				for (int i = 0; i < class864_0.Count; i++)
				{
					class864_0.method_0(i)?.Dispose();
				}
			}
		}
		bool_8 = true;
	}
}
