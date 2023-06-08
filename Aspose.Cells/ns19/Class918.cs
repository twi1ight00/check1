using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19;

internal class Class918 : Interface41
{
	protected Color color_0;

	protected Color color_1;

	protected int int_0;

	protected Brush brush_0;

	protected bool bool_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	public void method_0(Color color_2, Color color_3, int int_1)
	{
		color_0 = color_2;
		bool_0 = true;
		color_1 = color_3;
		int_0 = int_1;
		float_0 = -1.5f;
		float_1 = 0f;
		float_2 = 1f;
		float_3 = 0.5f;
		float_4 = 130f;
		float_5 = 88f;
	}

	public void method_1(Brush brush_1, Color color_2, int int_1)
	{
		brush_0 = brush_1;
		bool_0 = false;
		color_1 = color_2;
		int_0 = int_1;
		float_0 = -1.5f;
		float_1 = 0f;
		float_2 = 1f;
		float_3 = 0.5f;
		float_4 = 50f;
		float_5 = 40f;
	}

	public bool imethod_0(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_0, StringFormat stringFormat_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_1, point_0, stringFormat_0);
		Matrix matrix = new Matrix();
		matrix.Shear(float_0, float_1);
		matrix.Scale(float_2, float_3);
		matrix.Translate(float_4, float_5);
		interface42_0.imethod_58(matrix);
		if (bool_0)
		{
			SolidBrush solidBrush = new SolidBrush(color_0);
			interface42_0.imethod_33(solidBrush, graphicsPath);
		}
		else
		{
			interface42_0.imethod_33(brush_0, graphicsPath);
		}
		interface42_0.ResetTransform();
		for (int i = 1; i <= int_0; i++)
		{
			Pen pen = new Pen(color_1, i);
			pen.LineJoin = LineJoin.Round;
			interface42_0.imethod_18(pen, graphicsPath);
		}
		if (bool_0)
		{
			SolidBrush solidBrush2 = new SolidBrush(color_0);
			interface42_0.imethod_33(solidBrush2, graphicsPath);
		}
		else
		{
			interface42_0.imethod_33(brush_0, graphicsPath);
		}
		return true;
	}

	public bool imethod_1(Interface42 interface42_0, FontFamily fontFamily_0, FontStyle fontStyle_0, int int_1, string string_0, Point point_0, StringFormat stringFormat_0, ref float float_6, ref float float_7)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddString(string_0, fontFamily_0, (int)fontStyle_0, int_1, point_0, stringFormat_0);
		float_6 = point_0.X;
		float_7 = point_0.Y;
		if (!Class916.smethod_0(interface42_0, graphicsPath, ref float_6, ref float_7))
		{
			return false;
		}
		float num = 0f;
		float num2 = 0f;
		if (!Class916.smethod_1(interface42_0, int_0, 0f, ref num, ref num2))
		{
			return false;
		}
		float_6 += num;
		float_7 += num;
		return true;
	}
}
