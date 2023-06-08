using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class788 : IDisposable, Interface8
{
	private Class787 class787_0;

	private Color color_0;

	private Class856 class856_0;

	private Color color_1;

	private Enum71 enum71_0;

	private bool bool_0;

	internal bool bool_1;

	private bool bool_2;

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

	internal Class788(Class787 class787_1)
	{
		class787_0 = class787_1;
		color_1 = Color.White;
		color_0 = Color.White;
		bool_0 = false;
		bool_1 = true;
		enum71_0 = Enum71.const_1;
		class856_0 = new Class856(this);
	}

	[SpecialName]
	internal Class856 method_0()
	{
		return class856_0;
	}

	internal void method_1(Color color_2)
	{
		if (enum71_0 == Enum71.const_1)
		{
			ForegroundColor = color_2;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		if (enum71_0 != Enum71.const_3 && enum71_0 != Enum71.const_5 && enum71_0 != Enum71.const_4)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal bool method_3()
	{
		if (method_2())
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

	public bool method_4(Class788 class788_0)
	{
		if (!method_2() && !class788_0.method_2())
		{
			if (Formatting != class788_0.Formatting)
			{
				return false;
			}
			if (!BackgroundColor.Equals(class788_0.BackgroundColor))
			{
				return false;
			}
			if (!ForegroundColor.Equals(class788_0.ForegroundColor))
			{
				return false;
			}
			return true;
		}
		if (method_2() != class788_0.method_2())
		{
			return false;
		}
		Bitmap bitmap = new Bitmap(100, 100);
		Graphics graphics = Graphics.FromImage(bitmap);
		RectangleF rectangleF = new RectangleF(0f, 0f, 100f, 100f);
		using (Brush brush = method_0().method_2(rectangleF))
		{
			graphics.FillRectangle(brush, rectangleF);
		}
		Bitmap bitmap2 = new Bitmap(100, 100);
		Graphics graphics2 = Graphics.FromImage(bitmap2);
		using (Brush brush2 = class788_0.method_0().method_2(rectangleF))
		{
			graphics2.FillRectangle(brush2, rectangleF);
		}
		Class861 @class = new Class861();
		bool result = @class.method_0(bitmap, bitmap2);
		graphics.Dispose();
		graphics2.Dispose();
		bitmap.Dispose();
		bitmap2.Dispose();
		return result;
	}

	~Class788()
	{
		Dispose(bool_3: false);
	}

	public void Dispose()
	{
		Dispose(bool_3: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_3)
	{
		if (!bool_2)
		{
			if (bool_3 && class856_0 != null)
			{
				class856_0.Dispose();
			}
			bool_2 = true;
		}
	}
}
