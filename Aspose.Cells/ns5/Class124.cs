using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class124 : Class18
{
	private float float_5;

	private float float_6;

	internal Class124(Interface42 interface42_1, float float_7, float float_8, Class898 class898_1)
		: base(interface42_1, float_7, float_8, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float_5 = 0.074f * class898_0.method_7().Width;
		float_6 = 0.092f * class898_0.method_7().Height;
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		RectangleF rectangleF = new RectangleF(float_3, float_4 + 2f * float_6, class898_0.method_7().Width - 2f * float_5, class898_0.method_7().Height - 2f * float_6);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(class898_0.method_7());
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		if (!class898_0.Fill.method_0())
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			PointF[] array = new PointF[4]
			{
				new PointF(rectangleF.X, rectangleF.Y),
				new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y),
				new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + 0.8f * rectangleF.Height),
				new PointF(rectangleF.X, rectangleF.Y + 0.93f * rectangleF.Height)
			};
			PointF pt = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height * 1.13f);
			PointF pt2 = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + 0.8f * rectangleF.Height);
			graphicsPath2.AddLine(array[0], array[1]);
			graphicsPath2.AddLine(array[1], array[2]);
			graphicsPath2.AddBezier(array[2], pt2, pt, array[3]);
			graphicsPath2.AddLine(array[3], array[0]);
			graphicsPath2.CloseFigure();
			interface42_0.imethod_33(brush_, graphicsPath2);
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + float_5, float_4 + 2f * float_6),
				new PointF(float_3 + float_5, float_4 + float_6),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - 2f * float_5, float_4 + float_6 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - 2f * float_5, float_4 + 2f * float_6)
			});
			interface42_0.imethod_33(brush_, graphicsPath3);
			GraphicsPath graphicsPath4 = new GraphicsPath();
			graphicsPath4.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + 2f * float_5, float_4 + float_6),
				new PointF(float_3 + 2f * float_5, float_4),
				new PointF(float_3 + class898_0.Width, float_4),
				new PointF(float_3 + class898_0.Width, float_4 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6)
			});
			interface42_0.imethod_33(brush_, graphicsPath4);
		}
		if (!class898_0.Line.method_0())
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			PointF[] array2 = new PointF[4]
			{
				new PointF(rectangleF.X, rectangleF.Y),
				new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y),
				new PointF(rectangleF.X + rectangleF.Width, rectangleF.Y + 0.8f * rectangleF.Height),
				new PointF(rectangleF.X, rectangleF.Y + 0.93f * rectangleF.Height)
			};
			PointF pt3 = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height * 1.13f);
			PointF pt4 = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + 0.8f * rectangleF.Height);
			graphicsPath5.AddLine(array2[0], array2[1]);
			graphicsPath5.AddLine(array2[1], array2[2]);
			graphicsPath5.AddBezier(array2[2], pt4, pt3, array2[3]);
			graphicsPath5.AddLine(array2[3], array2[0]);
			graphicsPath5.CloseFigure();
			interface42_0.imethod_18(pen_, graphicsPath5);
			GraphicsPath graphicsPath6 = new GraphicsPath();
			graphicsPath6.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + float_5, float_4 + 2f * float_6),
				new PointF(float_3 + float_5, float_4 + float_6),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - 2f * float_5, float_4 + float_6 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - 2f * float_5, float_4 + 2f * float_6)
			});
			interface42_0.imethod_18(pen_, graphicsPath6);
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + 2f * float_5, float_4 + float_6),
				new PointF(float_3 + 2f * float_5, float_4),
				new PointF(float_3 + class898_0.Width, float_4),
				new PointF(float_3 + class898_0.Width, float_4 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + 0.66f * class898_0.Height),
				new PointF(float_3 + class898_0.Width - float_5, float_4 + float_6)
			});
			interface42_0.imethod_18(pen_, graphicsPath7);
		}
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = class898_0.method_7();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + float_6 * 2f;
		rectangleF_.Width -= float_5 * 3f;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
