using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19;

internal class Class919 : Interface41
{
	protected Color color_0;

	protected Color color_1;

	protected Color color_2;

	protected int int_0;

	protected int int_1;

	protected Brush brush_0;

	protected bool bool_0;

	public Class919()
	{
		int_0 = 2;
		int_1 = 2;
		brush_0 = null;
		bool_0 = true;
	}

	public bool imethod_0(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_2, string string_0, Point point_0, StringFormat stringFormat_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_2, point_0, stringFormat_0);
		Pen pen = new Pen(color_2, int_0 + int_1);
		pen.LineJoin = LineJoin.Round;
		interface42_0.imethod_18(pen, graphicsPath);
		Pen pen2 = new Pen(color_1, int_0);
		pen2.LineJoin = LineJoin.Round;
		interface42_0.imethod_18(pen2, graphicsPath);
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

	public bool imethod_1(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_2, string string_0, Point point_0, StringFormat stringFormat_0, ref float float_0, ref float float_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_2, point_0, stringFormat_0);
		float_0 = point_0.X;
		float_1 = point_0.Y;
		if (!Class916.smethod_0(interface42_0, graphicsPath, ref float_0, ref float_1))
		{
			return false;
		}
		float float_2 = 0f;
		float float_3 = 0f;
		if (!Class916.smethod_1(interface42_0, int_0 + int_1, 0f, ref float_2, ref float_3))
		{
			return false;
		}
		float_0 += float_2;
		float_1 += float_2;
		return true;
	}
}
