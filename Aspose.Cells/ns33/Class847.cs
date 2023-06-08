using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class847 : IDisposable, Interface29
{
	private Class823 class823_0;

	private Font font_0;

	private bool bool_0;

	private Color color_0;

	private string string_0;

	private bool bool_1 = true;

	private int int_0;

	private bool bool_2 = true;

	private int int_1;

	private bool bool_3;

	private int int_2;

	private bool bool_4;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = Struct63.smethod_24(method_0().Chart.Font);
				FontColor = class823_0.Chart.ChartArea.FontColor;
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
				if (class823_0.Chart.imethod_7() > 40)
				{
					return class823_0.Chart.method_16().method_0().method_2("lt1");
				}
				return class823_0.Chart.method_16().method_0().method_2("dk1");
			}
			return color_0;
		}
		set
		{
			bool_0 = false;
			color_0 = value;
		}
	}

	public bool LinkedSource
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

	public int Offset
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

	public int Rotation
	{
		get
		{
			if (bool_2)
			{
				return 0;
			}
			return int_1;
		}
		set
		{
			int_1 = value;
			bool_2 = false;
		}
	}

	internal Class847(Class823 class823_1)
	{
		class823_0 = class823_1;
		bool_0 = true;
		color_0 = class823_1.Chart.method_16().method_0().method_2("dk1");
		string_0 = "";
		int_0 = 100;
		int_1 = 0;
	}

	[SpecialName]
	internal Class823 method_0()
	{
		return class823_0;
	}

	[SpecialName]
	public string imethod_0()
	{
		return string_0;
	}

	[SpecialName]
	public void imethod_1(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_3;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_2;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_2;
	}

	[SpecialName]
	internal void method_2(int int_3)
	{
		int_2 = int_3;
	}

	internal float method_3()
	{
		return Struct63.smethod_3(class823_0.Chart.imethod_0().imethod_0().imethod_2(Font));
	}

	~Class847()
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
			if (bool_5 && font_0 != null)
			{
				font_0.Dispose();
			}
			bool_4 = true;
		}
	}
}
