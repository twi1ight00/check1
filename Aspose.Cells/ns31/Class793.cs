using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class793 : IDisposable, Interface13
{
	private Class787 class787_0;

	private Font font_0;

	private Color color_0;

	private Class806 class806_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	internal Rectangle rectangle_0;

	private Class802 class802_0;

	private Size size_0 = Size.Empty;

	private int int_0;

	private int int_1;

	private bool bool_4;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = Struct40.smethod_24(class787_0.Font);
				FontColor = class787_0.FontColor;
			}
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public Color FontColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Interface25 Border => class806_0;

	public bool IsOutlineShown
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

	internal Class787 Chart => class787_0;

	internal Class802 LegendEntries => class802_0;

	internal Class793(Class787 class787_1)
	{
		class787_0 = class787_1;
		color_0 = Color.Black;
		class806_0 = new Class806(class787_1);
		bool_0 = true;
		bool_1 = true;
		bool_2 = true;
		bool_3 = true;
		rectangle_0 = Rectangle.Empty;
		class802_0 = new Class802(class787_1);
	}

	[SpecialName]
	internal Class806 method_0()
	{
		return class806_0;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_0(bool bool_5)
	{
		bool_0 = bool_5;
	}

	[SpecialName]
	public bool imethod_1()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_2(bool bool_5)
	{
		bool_1 = bool_5;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_3(bool bool_5)
	{
		bool_2 = bool_5;
	}

	[SpecialName]
	internal int method_1()
	{
		int num = 0;
		if (Font != null)
		{
			num = Struct40.smethod_5(method_6() * 0.25f);
			if (num < 4)
			{
				return 4;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_2()
	{
		int num = 0;
		if (Font != null)
		{
			num = Struct40.smethod_5(method_6() * 0.2f);
			if (num < 4)
			{
				return 4;
			}
			return num;
		}
		return 0;
	}

	[SpecialName]
	internal int method_3()
	{
		int num = 0;
		if (Font != null)
		{
			return Struct40.smethod_5(method_6() * 0.2f);
		}
		return 0;
	}

	[SpecialName]
	internal int method_4()
	{
		Class808 @class = class787_0.method_7();
		int num = 0;
		if (@class.method_24())
		{
			return class787_0.method_6().method_11();
		}
		return class787_0.method_6().method_10();
	}

	[SpecialName]
	internal int method_5()
	{
		int num = 0;
		float num2 = 0f;
		num2 = ((!(Font.Size <= 6f)) ? 0.465f : 0.6f);
		if (Font != null)
		{
			num = Struct40.smethod_5(method_6() * num2);
			if (num < 3)
			{
				return 3;
			}
			return num;
		}
		return 0;
	}

	internal float method_6()
	{
		return Struct40.smethod_3(Chart.imethod_0().imethod_0().imethod_2(Font));
	}

	[SpecialName]
	internal Size method_7()
	{
		return size_0;
	}

	[SpecialName]
	internal void method_8(Size size_1)
	{
		size_0 = size_1;
	}

	[SpecialName]
	internal int method_9()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_10(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_11()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_12(int int_2)
	{
		int_1 = int_2;
	}

	~Class793()
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
		if (bool_4)
		{
			return;
		}
		if (bool_5)
		{
			if (font_0 != null)
			{
				font_0.Dispose();
			}
			if (class802_0 != null)
			{
				foreach (Class803 item in class802_0)
				{
					item.Dispose();
				}
			}
		}
		bool_4 = true;
	}
}
