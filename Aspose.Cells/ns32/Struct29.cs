using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ns19;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct29
{
	public static void smethod_0(Interface42 interface42_0, float float_0, float float_1, float float_2, float float_3, Class806 class806_0)
	{
		if (class806_0.IsVisible)
		{
			using (Pen pen_ = smethod_5(class806_0))
			{
				interface42_0.imethod_16(pen_, float_0, float_1, float_2, float_3);
			}
		}
	}

	public static void smethod_1(Interface42 interface42_0, PointF pointF_0, PointF pointF_1, Class806 class806_0)
	{
		smethod_0(interface42_0, pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y, class806_0);
	}

	public static void smethod_2(Interface42 interface42_0, RectangleF rectangleF_0, Class806 class806_0)
	{
		smethod_4(interface42_0, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, class806_0);
	}

	public static bool smethod_3(PointF pointF_0, RectangleF rectangleF_0)
	{
		if (!((pointF_0.X < rectangleF_0.X) | (pointF_0.X > rectangleF_0.Right)) && !(pointF_0.Y < rectangleF_0.Y) && pointF_0.Y <= rectangleF_0.Bottom)
		{
			return false;
		}
		return true;
	}

	public static void smethod_4(Interface42 interface42_0, float float_0, float float_1, float float_2, float float_3, Class806 class806_0)
	{
		if (class806_0.IsVisible)
		{
			using (Pen pen_ = smethod_5(class806_0))
			{
				interface42_0.imethod_23(pen_, float_0, float_1, float_2, float_3);
			}
		}
	}

	public static Pen smethod_5(Class806 class806_0)
	{
		float num = (float)class806_0.LineStyle.Width;
		Pen pen = new Pen(class806_0.Color, num);
		if (class806_0.LineStyle.DashStyle == Enum79.const_6)
		{
			pen.DashStyle = DashStyle.Solid;
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_0)
		{
			pen.DashStyle = DashStyle.Custom;
			if (num == 1f)
			{
				pen.DashPattern = new float[2] { 19f, 5f };
			}
			else if (num == 2f)
			{
				pen.DashPattern = new float[2] { 7f, 4f };
			}
			else if (num == 3f)
			{
				pen.DashPattern = new float[2] { 7f, 4f };
			}
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_10)
		{
			pen.DashStyle = DashStyle.Custom;
			if (num == 1f)
			{
				pen.DashPattern = new float[2] { 3f, 3f };
			}
			else if (num == 2f)
			{
				pen.DashPattern = new float[2] { 2f, 4f };
			}
			else if (num == 3f)
			{
				pen.DashPattern = new float[2] { 2f, 4f };
			}
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_1)
		{
			pen.DashStyle = DashStyle.Custom;
			if (num == 1f)
			{
				pen.DashPattern = new float[4] { 9f, 6f, 3f, 6f };
			}
			else if (num == 2f)
			{
				pen.DashPattern = new float[4] { 7f, 4f, 2f, 4f };
			}
			else if (num == 3f)
			{
				pen.DashPattern = new float[4] { 7f, 4f, 2f, 4f };
			}
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_9)
		{
			pen.DashStyle = DashStyle.Custom;
			if (num == 1f)
			{
				pen.DashPattern = new float[6] { 9f, 3f, 3f, 3f, 3f, 3f };
			}
			else if (num == 2f)
			{
				pen.DashPattern = new float[6] { 7f, 4f, 2f, 4f, 2f, 4f };
			}
			else if (num == 3f)
			{
				pen.DashPattern = new float[6] { 7f, 4f, 2f, 4f, 2f, 4f };
			}
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_8)
		{
			Color black = Color.Black;
			Color white = Color.White;
			Brush brush = new HatchBrush(HatchStyle.Percent70, black, white);
			pen = new Pen(brush, num);
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_12)
		{
			Color black2 = Color.Black;
			Color white2 = Color.White;
			Brush brush2 = new HatchBrush(HatchStyle.Percent50, black2, white2);
			pen = new Pen(brush2, num);
		}
		else if (class806_0.LineStyle.DashStyle == Enum79.const_11)
		{
			Color black3 = Color.Black;
			Color white3 = Color.White;
			Brush brush3 = new HatchBrush(HatchStyle.Percent25, black3, white3);
			pen = new Pen(brush3, num);
		}
		else
		{
			pen.DashStyle = DashStyle.Solid;
		}
		return pen;
	}

	public static void smethod_6(Interface42 interface42_0, Rectangle rectangle_0, Class806 class806_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_2(interface42_0, rectangleF_, class806_0);
	}

	public static bool smethod_7(PointF pointF_0, Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_3(pointF_0, rectangleF_);
	}
}
