using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19;

internal class Class921 : Interface41
{
	protected Color color_0;

	protected Color color_1;

	protected int int_0;

	protected Brush brush_0;

	protected bool bool_0;

	public Class921()
	{
		int_0 = 2;
		brush_0 = null;
		bool_0 = true;
	}

	public void method_0(Color color_2, Color color_3, int int_1)
	{
		color_0 = color_2;
		bool_0 = true;
		color_1 = color_3;
		int_0 = int_1;
	}

	public void method_1(Brush brush_1, Color color_2, int int_1)
	{
		brush_0 = brush_1;
		bool_0 = false;
		color_1 = color_2;
		int_0 = int_1;
	}

	public bool imethod_0(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_0, StringFormat stringFormat_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_1, point_0, stringFormat_0);
		Pen pen = new Pen(color_1, int_0);
		pen.LineJoin = LineJoin.Round;
		interface42_0.imethod_18(pen, graphicsPath);
		if (bool_0)
		{
			SolidBrush solidBrush = new SolidBrush(color_0);
			interface42_0.imethod_33(solidBrush, graphicsPath);
		}
		else
		{
			interface42_0.imethod_33(brush_0, graphicsPath);
		}
		return true;
	}

	public bool imethod_1(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_0, StringFormat stringFormat_0, ref float float_0, ref float float_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_1, point_0, stringFormat_0);
		float_0 = point_0.X;
		float_1 = point_0.Y;
		if (!Class916.smethod_0(interface42_0, graphicsPath, ref float_0, ref float_1))
		{
			return false;
		}
		float float_2 = 0f;
		float float_3 = 0f;
		if (!Class916.smethod_1(interface42_0, int_0, 0f, ref float_2, ref float_3))
		{
			return false;
		}
		float_0 += float_2;
		float_1 += float_2;
		return true;
	}
}
