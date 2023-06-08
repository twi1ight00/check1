using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Render;
using ns3;
using ns32;

namespace ns31;

internal class Class794 : IDisposable, Interface14
{
	private Class787 class787_0;

	private Class788 class788_0;

	private Class806 class806_0;

	private Font font_0;

	private Color color_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	internal Rectangle rectangle_0 = Rectangle.Empty;

	internal Rectangle rectangle_1 = Rectangle.Empty;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private object object_0;

	private Enum52 enum52_0;

	private bool bool_3 = true;

	private int int_4;

	private int int_5;

	private int int_6;

	private bool bool_4;

	private bool bool_5;

	public Interface8 Area => class788_0;

	public Interface25 Border => class806_0;

	public Font Font
	{
		get
		{
			if (font_0 == null)
			{
				if (enum52_0 == Enum52.const_0)
				{
					font_0 = Struct40.smethod_23("Arial", 10f, FontStyle.Regular);
					FontColor = Color.Black;
				}
				else
				{
					font_0 = Struct40.smethod_24(class787_0.Font);
					FontColor = class787_0.FontColor;
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
			return color_0;
		}
		set
		{
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
			bool_2 = false;
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
			bool_2 = false;
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
			bool_0 = false;
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
			bool_1 = false;
		}
	}

	internal Class787 Chart => class787_0;

	internal Class794(Class787 class787_1, object object_1, Enum52 enum52_1)
	{
		class787_0 = class787_1;
		int_2 = 0;
		int_3 = 0;
		int_0 = 0;
		int_1 = 0;
		class788_0 = new Class788(class787_1);
		class806_0 = new Class806(class787_1);
		color_0 = Color.Black;
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
	public void imethod_5(bool bool_6)
	{
		bool_3 = bool_6;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_4;
	}

	[SpecialName]
	public void imethod_6(bool bool_6)
	{
		bool_4 = bool_6;
	}

	[SpecialName]
	internal Class788 method_1()
	{
		return class788_0;
	}

	[SpecialName]
	internal Class806 method_2()
	{
		return class806_0;
	}

	internal void method_3(Font font_1)
	{
		font_0 = font_1;
	}

	[SpecialName]
	public virtual Rectangle vmethod_1()
	{
		return new Rectangle(int_2, int_3, int_0, int_1);
	}

	[SpecialName]
	public bool imethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_1(bool bool_6)
	{
		bool_0 = bool_6;
	}

	[SpecialName]
	public bool vmethod_2()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_2(bool bool_6)
	{
		bool_1 = bool_6;
	}

	[SpecialName]
	public bool imethod_3()
	{
		return bool_2;
	}

	[SpecialName]
	public void imethod_4(bool bool_6)
	{
		bool_2 = bool_6;
	}

	internal Size method_4()
	{
		int width = Struct40.smethod_5((float)Width * (float)method_12() / (float)method_14());
		int height = Struct40.smethod_5((float)Height * (float)method_13() / (float)method_14());
		return new Size(width, height);
	}

	internal int method_5()
	{
		return Struct40.smethod_5((float)Width * (float)method_12() / (float)method_14());
	}

	internal int method_6()
	{
		return Struct40.smethod_5((float)Height * (float)method_13() / (float)method_14());
	}

	internal int method_7()
	{
		return Struct40.smethod_5((float)X * (float)method_12() / (float)method_14());
	}

	internal int method_8()
	{
		return Struct40.smethod_5((float)Y * (float)method_13() / (float)method_14());
	}

	internal void method_9()
	{
		rectangle_0.X = rectangle_1.X;
		rectangle_0.Y = rectangle_1.Y;
		rectangle_0.Width = rectangle_1.Width;
		rectangle_0.Height = rectangle_1.Height;
		ChartType_Chart chartType_Chart = ChartType_Chart.Column;
		int num = Class817.int_2;
		if (enum52_0 == Enum52.const_12)
		{
			chartType_Chart = ((!(object_0 is Class810)) ? ((Class796)object_0).method_1().method_0().method_22() : ((Class810)object_0).method_22());
			if (chartType_Chart == ChartType_Chart.Pie || chartType_Chart == ChartType_Chart.Doughnut)
			{
				return;
			}
		}
		if (!bool_0)
		{
			if ((enum52_0 == Enum52.const_12 && !vmethod_0()) || (enum52_0 == Enum52.const_16 && !vmethod_0()))
			{
				int x = rectangle_0.X;
				if (chartType_Chart == ChartType_Chart.Bar)
				{
					int num2 = int_2;
					int_2 = int_3;
					x -= method_7();
					int_2 = num2;
				}
				else
				{
					x += method_7();
				}
				rectangle_0.X = ((x >= num) ? x : num);
				if (rectangle_0.Right + num > class787_0.Width)
				{
					rectangle_0.X = class787_0.Width - num - rectangle_0.Width;
				}
			}
			else if ((enum52_0 == Enum52.const_8 && !vmethod_0()) || (enum52_0 == Enum52.const_9 && !vmethod_0()) || (enum52_0 == Enum52.const_13 && !vmethod_0()))
			{
				int x2 = rectangle_0.X;
				if (method_0() is Class789 && enum52_0 == Enum52.const_9)
				{
					Class789 @class = (Class789)method_0();
					if (@class.method_0() == Enum54.const_1 || @class.method_0() == Enum54.const_2)
					{
						x2 = ((!@class.bool_10) ? (x2 - method_7()) : (x2 + method_7()));
					}
					else if (@class.method_0() != 0 && @class.method_0() != Enum54.const_3)
					{
						x2 += method_7();
					}
					else
					{
						int num3 = int_2;
						int_2 = int_3;
						x2 += method_7();
						int_2 = num3;
					}
				}
				else
				{
					x2 += method_7();
				}
				rectangle_0.X = ((x2 >= num) ? x2 : num);
				if (rectangle_0.Right + num > class787_0.Width)
				{
					rectangle_0.X = class787_0.Width - num - rectangle_0.Width;
				}
			}
			else if (enum52_0 != Enum52.const_1)
			{
				if (enum52_0 == Enum52.const_10)
				{
					rectangle_0.X = method_7();
					rectangle_0.X += num;
				}
				else
				{
					rectangle_0.X = method_7();
				}
			}
		}
		if (!bool_1)
		{
			if ((enum52_0 == Enum52.const_12 && !vmethod_0()) || (enum52_0 == Enum52.const_16 && !vmethod_0()))
			{
				int y = rectangle_0.Y;
				if (chartType_Chart == ChartType_Chart.Bar)
				{
					int num4 = int_3;
					int_3 = int_2;
					y -= method_8();
					int_3 = num4;
				}
				else
				{
					y += method_8();
				}
				rectangle_0.Y = ((y >= num) ? y : num);
				if (rectangle_0.Bottom + num > class787_0.Height)
				{
					rectangle_0.Y = class787_0.Height - num - rectangle_0.Height;
				}
			}
			else if ((enum52_0 == Enum52.const_8 && !vmethod_0()) || (enum52_0 == Enum52.const_9 && !vmethod_0()) || (enum52_0 == Enum52.const_13 && !vmethod_0()))
			{
				int y2 = rectangle_0.Y;
				if (method_0() is Class789 && enum52_0 == Enum52.const_9)
				{
					Class789 class2 = (Class789)method_0();
					if (class2.method_0() != Enum54.const_1 && class2.method_0() != Enum54.const_2)
					{
						if (class2.method_0() != 0 && class2.method_0() != Enum54.const_3)
						{
							y2 += method_8();
						}
						else
						{
							int num5 = int_3;
							int_3 = int_2;
							y2 = ((!class2.bool_10) ? (y2 + method_8()) : (y2 - method_8()));
							int_3 = num5;
						}
					}
					else
					{
						y2 -= method_8();
					}
				}
				else
				{
					y2 += method_8();
				}
				rectangle_0.Y = ((y2 >= num) ? y2 : num);
				if (rectangle_0.Bottom + num > class787_0.Height)
				{
					rectangle_0.Y = class787_0.Height - num - rectangle_0.Height;
				}
			}
			else if (enum52_0 != Enum52.const_1)
			{
				if (enum52_0 == Enum52.const_10)
				{
					rectangle_0.Y = method_8();
					rectangle_0.Y += num;
				}
				else
				{
					rectangle_0.Y = method_8();
				}
			}
		}
		if (!bool_2 && enum52_0 == Enum52.const_10)
		{
			Size size = method_4();
			rectangle_0.Width = size.Width;
			rectangle_0.Height = size.Height;
		}
	}

	internal void method_10(int int_7)
	{
		int_4 = int_7;
	}

	internal void method_11(int int_7)
	{
		int_5 = int_7;
	}

	private int method_12()
	{
		int num = Class817.int_2;
		switch (enum52_0)
		{
		default:
			if (vmethod_0())
			{
				return class787_0.Width - 2 * num;
			}
			return int_4;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_10:
			return class787_0.Width - 2 * num;
		}
	}

	private int method_13()
	{
		int num = Class817.int_2;
		switch (enum52_0)
		{
		default:
			if (vmethod_0())
			{
				return class787_0.Height - 2 * num;
			}
			return int_5;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_10:
			return class787_0.Height - 2 * num;
		}
	}

	private int method_14()
	{
		switch (enum52_0)
		{
		default:
			return int_6;
		case Enum52.const_9:
		case Enum52.const_12:
		case Enum52.const_13:
		case Enum52.const_16:
			if (vmethod_0())
			{
				return 4000;
			}
			return 1000;
		case Enum52.const_1:
		case Enum52.const_8:
		case Enum52.const_10:
			return 4000;
		}
	}

	internal Rectangle method_15()
	{
		method_9();
		Rectangle result = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		int num = Class817.int_2;
		if (result.X > num)
		{
			result.X -= num;
		}
		if (result.Y > num)
		{
			result.Y -= num;
		}
		int num2 = 4000;
		int num3 = class787_0.Height - 2 * num;
		int num4 = class787_0.Width - 2 * num;
		ChartType_Chart chartType_Chart = ChartType_Chart.Column;
		if (enum52_0 == Enum52.const_12)
		{
			chartType_Chart = ((!(object_0 is Class810)) ? ((Class796)object_0).method_1().method_0().method_22() : ((Class810)object_0).method_22());
		}
		if (enum52_0 == Enum52.const_12)
		{
			if (chartType_Chart == ChartType_Chart.Bar)
			{
				result.X = Struct40.smethod_5((double)num2 * (double)result.Y / (double)num3);
			}
			else
			{
				result.X = Struct40.smethod_5((double)num2 * (double)result.X / (double)num4);
			}
		}
		else
		{
			result.X = Struct40.smethod_5((double)num2 * (double)result.X / (double)num4);
		}
		if (enum52_0 == Enum52.const_12)
		{
			if (chartType_Chart == ChartType_Chart.Bar)
			{
				result.Y = Struct40.smethod_5((double)num2 * (double)result.X / (double)num4);
			}
			else
			{
				result.Y = Struct40.smethod_5((double)num2 * (double)result.Y / (double)num3);
			}
		}
		else
		{
			result.Y = Struct40.smethod_5((double)num2 * (double)result.Y / (double)num3);
		}
		result.Width = Struct40.smethod_5((double)num2 * (double)result.Width / (double)num4);
		result.Height = Struct40.smethod_5((double)num2 * (double)result.Height / (double)num3);
		return result;
	}

	internal Rectangle method_16()
	{
		Rectangle result = new Rectangle(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, rectangle_1.Height);
		int num = Class817.int_2;
		if (result.X > num)
		{
			result.X -= num;
		}
		if (result.Y > num)
		{
			result.Y -= num;
		}
		result.X = Struct40.smethod_5((double)method_14() * (double)result.X / (double)method_12());
		result.Y = Struct40.smethod_5((double)method_14() * (double)result.Y / (double)method_13());
		result.Width = Struct40.smethod_5((double)method_14() * (double)result.Width / (double)method_12());
		result.Height = Struct40.smethod_5((double)method_14() * (double)result.Height / (double)method_13());
		return result;
	}

	internal float method_17()
	{
		return Struct40.smethod_3(Chart.imethod_0().imethod_0().imethod_2(Font));
	}

	internal bool method_18()
	{
		method_9();
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0)
		{
			return false;
		}
		return true;
	}

	~Class794()
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
			if (class788_0 != null)
			{
				class788_0.Dispose();
			}
		}
		bool_5 = true;
	}
}
