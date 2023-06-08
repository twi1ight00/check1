using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ns19;
using ns22;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct24
{
	public static void smethod_0(Interface42 interface42_0, Class794 class794_0)
	{
		if (!class794_0.method_18())
		{
			using (Brush brush_ = Struct18.smethod_1(class794_0.method_1(), Class1181.smethod_5(class794_0.rectangle_0)))
			{
				interface42_0.imethod_36(brush_, class794_0.rectangle_0);
			}
			Struct29.smethod_6(interface42_0, class794_0.rectangle_0, class794_0.method_2());
		}
	}

	public static void smethod_1(Interface42 interface42_0, Class787 class787_0)
	{
		Class806 @class = class787_0.method_3().method_2();
		float num = (float)@class.LineStyle.Width;
		Size size = class787_0.imethod_13();
		Rectangle rectangle_ = new Rectangle(0, 0, size.Width, size.Height);
		RectangleF rectangleF;
		if (num <= 1f)
		{
			float width = class787_0.Width - 1;
			float height = class787_0.Height - 1;
			rectangleF = new RectangleF(0f, 0f, width, height);
		}
		else
		{
			float width = class787_0.Width;
			float height = class787_0.Height;
			rectangleF = new RectangleF(num / 2f, num / 2f, width, height);
		}
		if (class787_0.IsRectangularCornered)
		{
			Struct18.smethod_0(interface42_0, Class1181.smethod_5(rectangle_), class787_0.method_3().method_1());
			Struct29.smethod_4(interface42_0, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, class787_0.method_3().method_2());
			return;
		}
		using (Brush brush_ = Struct18.smethod_1(class787_0.method_3().method_1(), Class1181.smethod_5(rectangle_)))
		{
			smethod_3(interface42_0, brush_, rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height, 13f);
		}
		using Pen pen_ = Struct29.smethod_5(class787_0.method_3().method_2());
		smethod_2(interface42_0, pen_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, 13f);
	}

	private static void smethod_2(Interface42 interface42_0, Pen pen_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(float_0 + float_4, float_1, float_0 + float_2 - float_4 * 2f, float_1);
		graphicsPath.AddArc(float_0 + float_2 - float_4 * 2f, float_1, float_4 * 2f, float_4 * 2f, 270f, 90f);
		graphicsPath.AddLine(float_0 + float_2, float_1 + float_4, float_0 + float_2, float_1 + float_3 - float_4 * 2f);
		graphicsPath.AddArc(float_0 + float_2 - float_4 * 2f, float_1 + float_3 - float_4 * 2f, float_4 * 2f, float_4 * 2f, 0f, 90f);
		graphicsPath.AddLine(float_0 + float_2 - float_4 * 2f, float_1 + float_3, float_0 + float_4, float_1 + float_3);
		graphicsPath.AddArc(float_0, float_1 + float_3 - float_4 * 2f, float_4 * 2f, float_4 * 2f, 90f, 90f);
		graphicsPath.AddLine(float_0, float_1 + float_3 - float_4 * 2f, float_0, float_1 + float_4);
		graphicsPath.AddArc(float_0, float_1, float_4 * 2f, float_4 * 2f, 180f, 90f);
		graphicsPath.CloseFigure();
		interface42_0.imethod_18(pen_0, graphicsPath);
	}

	private static void smethod_3(Interface42 interface42_0, Brush brush_0, float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(float_0 + float_4, float_1, float_0 + float_2 - float_4 * 2f, float_1);
		graphicsPath.AddArc(float_0 + float_2 - float_4 * 2f, float_1, float_4 * 2f, float_4 * 2f, 270f, 90f);
		graphicsPath.AddLine(float_0 + float_2, float_1 + float_4, float_0 + float_2, float_1 + float_3 - float_4 * 2f);
		graphicsPath.AddArc(float_0 + float_2 - float_4 * 2f, float_1 + float_3 - float_4 * 2f, float_4 * 2f, float_4 * 2f, 0f, 90f);
		graphicsPath.AddLine(float_0 + float_2 - float_4 * 2f, float_1 + float_3, float_0 + float_4, float_1 + float_3);
		graphicsPath.AddArc(float_0, float_1 + float_3 - float_4 * 2f, float_4 * 2f, float_4 * 2f, 90f, 90f);
		graphicsPath.AddLine(float_0, float_1 + float_3 - float_4 * 2f, float_0, float_1 + float_4);
		graphicsPath.AddArc(float_0, float_1, float_4 * 2f, float_4 * 2f, 180f, 90f);
		graphicsPath.CloseFigure();
		interface42_0.imethod_33(brush_0, graphicsPath);
	}
}
