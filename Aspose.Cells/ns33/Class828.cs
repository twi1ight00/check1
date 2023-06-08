using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class828 : IDisposable, Interface13
{
	private Class821 class821_0;

	private Font font_0;

	private bool bool_0;

	private Color color_0;

	private Class840 class840_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	internal Rectangle rectangle_0;

	private Class836 class836_0;

	private Size size_0 = Size.Empty;

	private int int_0;

	private int int_1;

	private bool bool_5;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = Struct63.smethod_24(class821_0.Font);
				FontColor = Chart.ChartArea.FontColor;
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
			if (bool_0)
			{
				if (Chart.imethod_7() > 40)
				{
					return Chart.method_16().method_0().method_2("lt1");
				}
				return Chart.method_16().method_0().method_2("dk1");
			}
			return color_0;
		}
		set
		{
			bool_0 = false;
			color_0 = value;
		}
	}

	public Interface25 Border => class840_0;

	public bool IsOutlineShown
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

	internal Class821 Chart => class821_0;

	internal Class836 LegendEntries => class836_0;

	internal Class828(Class821 class821_1)
	{
		class821_0 = class821_1;
		bool_0 = true;
		color_0 = class821_1.method_16().method_0().method_2("dk1");
		class840_0 = new Class840(class821_1, Enum57.const_13);
		bool_1 = true;
		bool_2 = true;
		bool_3 = true;
		bool_4 = true;
		rectangle_0 = Rectangle.Empty;
		class836_0 = new Class836(class821_1);
	}

	[SpecialName]
	internal Class840 method_0()
	{
		return class840_0;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_0(bool bool_6)
	{
		bool_1 = bool_6;
	}

	[SpecialName]
	public bool imethod_1()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_2(bool bool_6)
	{
		bool_2 = bool_6;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_3;
	}

	[SpecialName]
	public void imethod_3(bool bool_6)
	{
		bool_3 = bool_6;
	}

	[SpecialName]
	internal Size method_1()
	{
		return size_0;
	}

	[SpecialName]
	internal void method_2(Size size_1)
	{
		size_0 = size_1;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_4(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_5()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_6(int int_2)
	{
		int_1 = int_2;
	}

	~Class828()
	{
		Dispose(bool_6: false);
	}

	public void Dispose()
	{
		Dispose(bool_6: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_6)
	{
		if (bool_5)
		{
			return;
		}
		if (bool_6)
		{
			if (font_0 != null)
			{
				font_0.Dispose();
			}
			if (class836_0 != null)
			{
				foreach (Class837 item in class836_0)
				{
					item.Dispose();
				}
			}
		}
		bool_5 = true;
	}
}
