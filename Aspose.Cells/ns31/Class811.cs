using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;
using ns32;

namespace ns31;

internal class Class811 : IDisposable, Interface29
{
	private Class789 class789_0;

	private Font font_0;

	private Color color_0;

	private string string_0;

	private bool bool_0 = true;

	private int int_0;

	private bool bool_1 = true;

	private int int_1;

	private bool bool_2;

	private int int_2;

	private bool bool_3;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = Struct40.smethod_24(method_0().Chart.Font);
				FontColor = class789_0.Chart.FontColor;
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

	public bool LinkedSource
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
			if (bool_1)
			{
				return 0;
			}
			return int_1;
		}
		set
		{
			int_1 = value;
			bool_1 = false;
		}
	}

	internal Class811(Class789 class789_1)
	{
		class789_0 = class789_1;
		color_0 = Color.Black;
		string_0 = "";
		int_0 = 100;
		int_1 = 0;
	}

	[SpecialName]
	internal Class789 method_0()
	{
		return class789_0;
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
		return bool_2;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_1;
	}

	[SpecialName]
	public void vmethod_2(bool bool_4)
	{
		bool_1 = bool_4;
		if (bool_4)
		{
			int_1 = 0;
		}
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
		return Struct40.smethod_3(class789_0.Chart.imethod_0().imethod_0().imethod_2(Font));
	}

	~Class811()
	{
		Dispose(bool_4: false);
	}

	public void Dispose()
	{
		Dispose(bool_4: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_4)
	{
		if (!bool_3)
		{
			if (bool_4 && font_0 != null)
			{
				font_0.Dispose();
			}
			bool_3 = true;
		}
	}
}
