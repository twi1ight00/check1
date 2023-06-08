using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;
using ns34;

namespace ns33;

internal class Class829 : IDisposable, Interface14
{
	private Class821 class821_0;

	private Class822 class822_0;

	private Class840 class840_0;

	private Font font_0;

	private bool bool_0;

	private Color color_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal Rectangle rectangle_0 = Rectangle.Empty;

	internal Rectangle rectangle_1 = Rectangle.Empty;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private object object_0;

	private Enum52 enum52_0;

	private int int_4;

	private int int_5;

	private int int_6;

	private bool bool_5 = true;

	private bool bool_6 = true;

	private bool bool_7;

	public Interface8 Area => class822_0;

	public Interface25 Border => class840_0;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				if (enum52_0 == Enum52.const_0)
				{
					font_0 = Struct63.smethod_23("Calibri", 10f, FontStyle.Regular);
				}
				else
				{
					Font font = Chart.Font;
					switch (enum52_0)
					{
					default:
						font_0 = Struct63.smethod_23(font.Name, font.Size, font.Style);
						break;
					case Enum52.const_8:
					{
						FontStyle style2 = font.Style;
						style2 |= FontStyle.Bold;
						font_0 = Struct63.smethod_23(font.Name, font.Size * 1.2f, style2);
						break;
					}
					case Enum52.const_9:
					{
						FontStyle style = font.Style;
						style |= FontStyle.Bold;
						font_0 = Struct63.smethod_23(font.Name, font.Size, style);
						break;
					}
					}
					FontColor = Chart.ChartArea.FontColor;
				}
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

	public virtual int Width
	{
		get
		{
			Enum52 @enum = enum52_0;
			if (@enum != Enum52.const_1 && @enum != Enum52.const_10)
			{
				return int_0;
			}
			if (!imethod_3() && int_0 + X > 4000)
			{
				return 4000 - X;
			}
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_3 = false;
		}
	}

	public virtual int Height
	{
		get
		{
			Enum52 @enum = enum52_0;
			if (@enum != Enum52.const_1 && @enum != Enum52.const_10)
			{
				return int_1;
			}
			if (!imethod_3() && int_1 + Y > 4000)
			{
				return 4000 - Y;
			}
			return int_1;
		}
		set
		{
			int_1 = value;
			bool_3 = false;
		}
	}

	public virtual int X
	{
		get
		{
			Enum52 @enum = enum52_0;
			if (@enum != Enum52.const_1 && @enum != Enum52.const_10)
			{
				return int_2;
			}
			if (int_2 >= 0)
			{
				return int_2;
			}
			return 0;
		}
		set
		{
			int_2 = value;
			bool_1 = false;
		}
	}

	public virtual int Y
	{
		get
		{
			Enum52 @enum = enum52_0;
			if (@enum != Enum52.const_1 && @enum != Enum52.const_10)
			{
				return int_3;
			}
			if (int_3 >= 0)
			{
				return int_3;
			}
			return 0;
		}
		set
		{
			int_3 = value;
			bool_2 = false;
		}
	}

	internal Class821 Chart => class821_0;

	internal Class829(Class821 class821_1, object object_1, Enum52 enum52_1, Enum57 enum57_0)
	{
		class821_0 = class821_1;
		int_2 = 0;
		int_3 = 0;
		int_0 = 0;
		int_1 = 0;
		class822_0 = new Class822(class821_1, object_1, enum52_1);
		class840_0 = new Class840(class821_1, enum57_0);
		bool_0 = true;
		color_0 = class821_1.method_16().method_0().method_2("dk1");
		rectangle_0 = Rectangle.Empty;
		rectangle_1 = Rectangle.Empty;
		object_0 = object_1;
		enum52_0 = enum52_1;
	}

	[SpecialName]
	internal object method_0()
	{
		return object_0;
	}

	[SpecialName]
	internal Class822 method_1()
	{
		return class822_0;
	}

	[SpecialName]
	internal Class840 method_2()
	{
		return class840_0;
	}

	internal void method_3(Font font_1)
	{
		font_0 = font_1;
	}

	[SpecialName]
	public virtual Rectangle vmethod_0()
	{
		return new Rectangle(int_2, int_3, int_0, int_1);
	}

	[SpecialName]
	public bool imethod_0()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_1(bool bool_8)
	{
		bool_1 = bool_8;
	}

	[SpecialName]
	public bool vmethod_1()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_2(bool bool_8)
	{
		bool_2 = bool_8;
	}

	[SpecialName]
	public bool imethod_3()
	{
		return bool_3;
	}

	[SpecialName]
	public void imethod_4(bool bool_8)
	{
		bool_3 = bool_8;
	}

	internal Size method_4()
	{
		int width = Width * method_10() / method_12();
		int height = Height * method_11() / method_12();
		return new Size(width, height);
	}

	internal int method_5()
	{
		return Width * method_10() / method_12();
	}

	internal int method_6()
	{
		return Height * method_11() / method_12();
	}

	internal int method_7()
	{
		return X * method_10() / method_12();
	}

	internal int method_8()
	{
		return Y * method_11() / method_12();
	}

	[SpecialName]
	public void imethod_6(bool bool_8)
	{
		bool_4 = bool_8;
	}

	internal void method_9()
	{
		rectangle_0.X = rectangle_1.X;
		rectangle_0.Y = rectangle_1.Y;
		rectangle_0.Width = rectangle_1.Width;
		rectangle_0.Height = rectangle_1.Height;
		ChartType_Chart chartType_Chart = ChartType_Chart.Column;
		if (enum52_0 == Enum52.const_12)
		{
			chartType_Chart = ((!(object_0 is Class844)) ? ((Class831)object_0).method_1().method_0().method_22() : ((Class844)object_0).method_22());
		}
		if (!bool_1)
		{
			if ((enum52_0 == Enum52.const_12 && !bool_4) || (enum52_0 == Enum52.const_16 && !bool_4) || (enum52_0 == Enum52.const_8 && !bool_4) || (enum52_0 == Enum52.const_9 && !bool_4))
			{
				int x = rectangle_0.X;
				x = ((chartType_Chart != ChartType_Chart.Bar || enum52_0 != Enum52.const_12 || method_17()) ? (x + method_7()) : (x - method_7()));
				rectangle_0.X = ((x >= 0) ? x : 0);
				if (rectangle_0.Right > class821_0.Width)
				{
					rectangle_0.X = class821_0.Width - rectangle_0.Width;
				}
				bool_3 = true;
			}
			else if (enum52_0 != Enum52.const_1)
			{
				int num = method_7();
				rectangle_0.X = ((num >= 0) ? num : 0);
				if (rectangle_0.Right > class821_0.Width)
				{
					rectangle_0.X = class821_0.Width - rectangle_0.Width;
				}
			}
		}
		if (!bool_2)
		{
			if ((enum52_0 == Enum52.const_12 && !bool_4) || (enum52_0 == Enum52.const_16 && !bool_4) || (enum52_0 == Enum52.const_8 && !bool_4) || (enum52_0 == Enum52.const_9 && !bool_4))
			{
				int y = rectangle_0.Y;
				y += method_8();
				rectangle_0.Y = ((y >= 0) ? y : 0);
				if (rectangle_0.Bottom > class821_0.Height)
				{
					rectangle_0.Y = class821_0.Height - rectangle_0.Height;
				}
			}
			else if (enum52_0 != Enum52.const_1)
			{
				int num2 = method_8();
				rectangle_0.Y = ((num2 >= 0) ? num2 : 0);
				if (rectangle_0.Bottom > class821_0.Height)
				{
					rectangle_0.Y = class821_0.Height - rectangle_0.Height;
				}
			}
		}
		if (!bool_3 && enum52_0 == Enum52.const_10)
		{
			Size size = method_4();
			rectangle_0.Width = size.Width;
			rectangle_0.Height = size.Height;
		}
	}

	private int method_10()
	{
		switch (enum52_0)
		{
		default:
			return int_4;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_9:
		case Enum52.const_10:
		case Enum52.const_12:
		case Enum52.const_13:
			return class821_0.Position.Width;
		}
	}

	private int method_11()
	{
		switch (enum52_0)
		{
		default:
			return int_5;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_9:
		case Enum52.const_10:
		case Enum52.const_12:
		case Enum52.const_13:
			return class821_0.Position.Height;
		}
	}

	private int method_12()
	{
		switch (enum52_0)
		{
		default:
			return int_6;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_9:
		case Enum52.const_10:
		case Enum52.const_12:
		case Enum52.const_13:
		case Enum52.const_16:
			return 4000;
		}
	}

	internal Rectangle method_13()
	{
		if (!vmethod_2() && enum52_0 != Enum52.const_1)
		{
			return vmethod_0();
		}
		method_9();
		Rectangle result = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		ChartType_Chart chartType_Chart = ChartType_Chart.Column;
		if (enum52_0 == Enum52.const_12)
		{
			chartType_Chart = ((!(object_0 is Class844)) ? ((Class831)object_0).method_1().method_0().method_22() : ((Class844)object_0).method_22());
		}
		if (enum52_0 == Enum52.const_12)
		{
			if (chartType_Chart == ChartType_Chart.Bar)
			{
				result.X = Struct63.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
			}
			else
			{
				result.X = Struct63.smethod_5((double)method_12() * (double)result.X / (double)method_10());
			}
		}
		else
		{
			result.X = Struct63.smethod_5((double)method_12() * (double)result.X / (double)method_10());
		}
		if (enum52_0 == Enum52.const_12)
		{
			if (chartType_Chart == ChartType_Chart.Bar)
			{
				result.Y = Struct63.smethod_5((double)method_12() * (double)result.X / (double)method_10());
			}
			else
			{
				result.Y = Struct63.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
			}
		}
		else
		{
			result.Y = Struct63.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
		}
		result.Width = Struct63.smethod_5((double)method_12() * (double)result.Width / (double)method_10());
		result.Height = Struct63.smethod_5((double)method_12() * (double)result.Height / (double)method_11());
		return result;
	}

	internal Rectangle method_14()
	{
		Rectangle result = new Rectangle(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, rectangle_1.Height);
		result.X = Struct63.smethod_5((double)method_12() * (double)result.X / (double)method_10());
		result.Y = Struct63.smethod_5((double)method_12() * (double)result.Y / (double)method_11());
		result.Width = Struct63.smethod_5((double)method_12() * (double)result.Width / (double)method_10());
		result.Height = Struct63.smethod_5((double)method_12() * (double)result.Height / (double)method_11());
		return result;
	}

	[SpecialName]
	public bool vmethod_2()
	{
		return bool_5;
	}

	[SpecialName]
	public void imethod_5(bool bool_8)
	{
		bool_5 = bool_8;
	}

	[SpecialName]
	internal float method_15()
	{
		return Struct63.smethod_3(Chart.imethod_0().imethod_0().imethod_2(Font));
	}

	internal bool method_16()
	{
		method_9();
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_17()
	{
		return bool_6;
	}

	[SpecialName]
	internal void method_18(bool bool_8)
	{
		bool_6 = bool_8;
	}

	internal void method_19()
	{
		if (!method_16())
		{
			method_1().method_7(rectangle_0);
			method_2().method_9(rectangle_0);
		}
	}

	~Class829()
	{
		Dispose(bool_8: false);
	}

	public void Dispose()
	{
		Dispose(bool_8: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_8)
	{
		if (bool_7)
		{
			return;
		}
		if (bool_8)
		{
			if (font_0 != null)
			{
				font_0.Dispose();
			}
			if (class822_0 != null)
			{
				class822_0.Dispose();
			}
		}
		bool_7 = true;
	}
}
