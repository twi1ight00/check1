using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns3;

namespace ns33;

internal class Class822 : IDisposable, Interface8
{
	private Class821 class821_0;

	private Enum52 enum52_0;

	private Color color_0;

	private Class856 class856_0;

	private Color color_1;

	private Enum71 enum71_0;

	private bool bool_0;

	internal bool bool_1;

	private object object_0;

	private bool bool_2 = true;

	private bool bool_3;

	public bool InvertIfNegative
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			bool_1 = false;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Color.Empty;
			}
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Interface34 FillFormat => class856_0;

	public Color ForegroundColor
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Color.Empty;
			}
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public Enum71 Formatting
	{
		get
		{
			return enum71_0;
		}
		set
		{
			enum71_0 = value;
		}
	}

	internal Class822(Class821 class821_1, object object_1, Enum52 enum52_1)
	{
		class821_0 = class821_1;
		object_0 = object_1;
		enum52_0 = enum52_1;
		color_1 = Color.Empty;
		color_0 = Color.Empty;
		bool_0 = false;
		bool_1 = true;
		enum71_0 = Enum71.const_1;
		class856_0 = new Class856(this);
	}

	[SpecialName]
	internal Enum52 method_0()
	{
		return enum52_0;
	}

	[SpecialName]
	internal bool method_1()
	{
		if (enum71_0 != Enum71.const_3 && enum71_0 != Enum71.const_5 && enum71_0 != Enum71.const_4)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_2()
	{
		if (method_1())
		{
			return false;
		}
		if (enum71_0 == Enum71.const_0)
		{
			return true;
		}
		if (color_1.A <= 250)
		{
			return true;
		}
		return false;
	}

	public bool method_3(Class822 class822_0)
	{
		if (!method_1() && !class822_0.method_1())
		{
			if (Formatting != class822_0.Formatting)
			{
				return false;
			}
			if (!BackgroundColor.Equals(class822_0.BackgroundColor))
			{
				return false;
			}
			if (!ForegroundColor.Equals(class822_0.ForegroundColor))
			{
				return false;
			}
			return true;
		}
		if (method_1() != class822_0.method_1())
		{
			return false;
		}
		Bitmap bitmap = new Bitmap(100, 100);
		Graphics graphics = Graphics.FromImage(bitmap);
		RectangleF rectangleF = new RectangleF(0f, 0f, 100f, 100f);
		Brush brush = method_12(rectangleF);
		graphics.FillRectangle(brush, rectangleF);
		Bitmap bitmap2 = new Bitmap(100, 100);
		Graphics graphics2 = Graphics.FromImage(bitmap2);
		Brush brush2 = class822_0.method_12(rectangleF);
		graphics2.FillRectangle(brush2, rectangleF);
		Class861 @class = new Class861();
		bool result = @class.method_0(bitmap, bitmap2);
		brush.Dispose();
		brush2.Dispose();
		graphics.Dispose();
		graphics2.Dispose();
		bitmap.Dispose();
		bitmap2.Dispose();
		return result;
	}

	internal void method_4(Color color_2)
	{
		if (enum71_0 == Enum71.const_1)
		{
			ForegroundColor = color_2;
		}
	}

	internal void method_5()
	{
		if (enum71_0 != Enum71.const_1 || !bool_2)
		{
			return;
		}
		Color color = class821_0.method_16().method_0().method_2("dk1");
		switch (enum52_0)
		{
		case Enum52.const_0:
			if (class821_0.imethod_7() <= 32)
			{
				color_1 = class821_0.method_16().method_0().method_2("bg1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				color_1 = class821_0.method_16().method_0().method_2("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else
			{
				color_1 = color;
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		case Enum52.const_1:
			if (class821_0.method_17())
			{
				enum71_0 = Enum71.const_0;
			}
			else
			{
				method_6(bool_4: true);
			}
			break;
		case Enum52.const_3:
		case Enum52.const_4:
			method_6(bool_4: false);
			break;
		case Enum52.const_14:
			if (class821_0.imethod_7() == 1)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 2)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 8)
			{
				int num7 = class821_0.imethod_7() - 2;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num7);
				color_1 = class821_0.method_16().method_0().method_6(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 9)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 10)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 16)
			{
				int num8 = class821_0.imethod_7() - 10;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num8);
				color_1 = class821_0.method_16().method_0().method_6(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 17)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 18)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 24)
			{
				int num9 = class821_0.imethod_7() - 18;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num9);
				color_1 = class821_0.method_16().method_0().method_6(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 25)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 26)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 32)
			{
				int num10 = class821_0.imethod_7() - 26;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num10);
				color_1 = class821_0.method_16().method_0().method_6(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				color_1 = class821_0.method_16().method_0().method_2("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 41)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 42)
			{
				color_1 = class821_0.method_16().method_0().method_2("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 48)
			{
				int num11 = class821_0.imethod_7() - 42;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num11);
				color_1 = class821_0.method_16().method_0().method_6(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		case Enum52.const_15:
			if (class821_0.imethod_7() == 1)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 2)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 8)
			{
				int num = class821_0.imethod_7() - 2;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 9)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 10)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 16)
			{
				int num2 = class821_0.imethod_7() - 10;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num2);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 17)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 18)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 24)
			{
				int num3 = class821_0.imethod_7() - 18;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num3);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 25)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 26)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 32)
			{
				int num4 = class821_0.imethod_7() - 26;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num4);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 33)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 34)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				int num5 = class821_0.imethod_7() - 34;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num5);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 41)
			{
				color_1 = class821_0.method_16().method_0().method_6(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() == 42)
			{
				color_1 = color;
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class821_0.imethod_7() <= 48)
			{
				int num6 = class821_0.imethod_7() - 42;
				color_1 = class821_0.method_16().method_0().method_2("accent" + num6);
				color_1 = class821_0.method_16().method_0().method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		}
		bool_2 = false;
	}

	private void method_6(bool bool_4)
	{
		if (class821_0.imethod_7() <= 32)
		{
			if (bool_4)
			{
				color_1 = class821_0.method_16().method_0().method_2("bg1");
				color_1 = Color.FromArgb(255, color_1);
			}
		}
		else if (class821_0.imethod_7() <= 34)
		{
			color_1 = class821_0.method_16().method_0().method_2("dk1");
			color_1 = class821_0.method_16().method_0().method_6(color_1, 0.2);
			color_1 = Color.FromArgb(255, color_1);
		}
		else if (class821_0.imethod_7() <= 40)
		{
			int num = class821_0.imethod_7() - 34;
			color_1 = class821_0.method_16().method_0().method_2("accent" + num);
			color_1 = class821_0.method_16().method_0().method_6(color_1, 0.2);
			color_1 = Color.FromArgb(255, color_1);
		}
		else
		{
			color_1 = class821_0.method_16().method_0().method_2("dk1");
			color_1 = class821_0.method_16().method_0().method_6(color_1, 0.95);
			color_1 = Color.FromArgb(255, color_1);
		}
	}

	internal void method_7(Rectangle rectangle_0)
	{
		method_8(new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height));
	}

	internal void method_8(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF_0);
		method_10(graphicsPath, 1f);
	}

	internal void method_9(GraphicsPath graphicsPath_0)
	{
		method_10(graphicsPath_0, 1f);
	}

	internal void method_10(GraphicsPath graphicsPath_0, float float_0)
	{
		method_11(graphicsPath_0, float_0, graphicsPath_0);
	}

	internal void method_11(GraphicsPath graphicsPath_0, float float_0, GraphicsPath graphicsPath_1)
	{
		if (Formatting != 0 && graphicsPath_0 != null && graphicsPath_1 != null)
		{
			Brush brush_ = method_14(graphicsPath_1, float_0);
			Interface42 @interface = class821_0.imethod_0();
			@interface.imethod_33(brush_, graphicsPath_0);
			method_15(brush_);
		}
	}

	internal Brush method_12(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF_0);
		return method_14(graphicsPath, 1f);
	}

	internal Brush method_13(GraphicsPath graphicsPath_0)
	{
		return method_14(graphicsPath_0, 1f);
	}

	internal Brush method_14(GraphicsPath graphicsPath_0, float float_0)
	{
		method_5();
		bool flag = method_16();
		Brush brush = null;
		if (method_1())
		{
			return class856_0.method_3(graphicsPath_0, flag, float_0);
		}
		Color color = color_1;
		if (flag)
		{
			color = color_0;
		}
		return new SolidBrush(Color.FromArgb(color.A, (int)((float)(int)color.R * float_0), (int)((float)(int)color.G * float_0), (int)((float)(int)color.B * float_0)));
	}

	private void method_15(Brush brush_0)
	{
		if (method_1())
		{
			class856_0.method_4(brush_0);
		}
		else
		{
			brush_0.Dispose();
		}
	}

	internal bool method_16()
	{
		bool result = false;
		if (enum52_0 == Enum52.const_7 && !bool_1)
		{
			Class831 @class = (Class831)object_0;
			if (InvertIfNegative && @class.method_7())
			{
				result = true;
			}
		}
		else if (enum52_0 == Enum52.const_7 && bool_1)
		{
			Class831 class2 = (Class831)object_0;
			if (class2.method_1().method_0().method_6()
				.InvertIfNegative && class2.method_7())
			{
				result = true;
			}
		}
		return result;
	}

	~Class822()
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
			if (bool_4 && class856_0 != null)
			{
				class856_0.Dispose();
			}
			bool_3 = true;
		}
	}
}
