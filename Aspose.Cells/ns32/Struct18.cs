using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ns19;
using ns22;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct18
{
	public static void smethod_0(Interface42 interface42_0, RectangleF rectangleF_0, Class788 class788_0)
	{
		if (class788_0.Formatting != 0)
		{
			using (Brush brush_ = smethod_1(class788_0, rectangleF_0))
			{
				interface42_0.imethod_37(brush_, rectangleF_0);
			}
		}
	}

	public static Brush smethod_1(Class788 class788_0, RectangleF rectangleF_0)
	{
		return smethod_2(class788_0, rectangleF_0, bool_0: false);
	}

	public static Brush smethod_2(Class788 class788_0, RectangleF rectangleF_0, bool bool_0)
	{
		Brush brush = null;
		if (class788_0.method_2())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rectangleF_0);
			return class788_0.method_0().method_3(graphicsPath, bool_0, 1f);
		}
		if (bool_0)
		{
			return new SolidBrush(class788_0.BackgroundColor);
		}
		return new SolidBrush(class788_0.ForegroundColor);
	}

	public static Brush smethod_3(Class788 class788_0, RectangleF rectangleF_0, float float_0)
	{
		Brush brush = null;
		if (class788_0.method_2())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rectangleF_0);
			return class788_0.method_0().method_3(graphicsPath, bool_1: false, float_0);
		}
		Color color = Color.FromArgb((int)((float)(int)Class1178.smethod_1(class788_0.ForegroundColor) * float_0), (int)((float)(int)Class1178.smethod_2(class788_0.ForegroundColor) * float_0), (int)((float)(int)Class1178.smethod_3(class788_0.ForegroundColor) * float_0));
		if (Class1178.smethod_0(class788_0.ForegroundColor))
		{
			color = Color.Empty;
		}
		return new SolidBrush(color);
	}
}
