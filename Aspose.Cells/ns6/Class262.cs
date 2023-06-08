using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class262 : Class160
{
	private float float_5;

	private float float_6;

	internal Class262(Interface42 interface42_1, float float_7, float float_8, Class913 class913_1)
		: base(interface42_1, float_7, float_8, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float_5 = 0.074f * class913_0.method_8().Width;
		float_6 = 0.092f * class913_0.method_8().Height;
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		RectangleF rect = new RectangleF(float_3, float_4 + 2f * float_6, class913_0.method_8().Width - 2f * float_5, class913_0.method_8().Height - 2f * float_6);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		if (!class913_0.Fill.method_0())
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			PointF[] array = new PointF[4]
			{
				new PointF(rect.X, rect.Y),
				new PointF(rect.X + rect.Width, rect.Y),
				new PointF(rect.X + rect.Width, rect.Y + 0.8f * rect.Height),
				new PointF(rect.X, rect.Y + 0.93f * rect.Height)
			};
			PointF pt = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height * 1.13f);
			PointF pt2 = new PointF(rect.X + rect.Width / 2f, rect.Y + 0.8f * rect.Height);
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
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - 2f * float_5, float_4 + float_6 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - 2f * float_5, float_4 + 2f * float_6)
			});
			interface42_0.imethod_33(brush_, graphicsPath3);
			GraphicsPath graphicsPath4 = new GraphicsPath();
			graphicsPath4.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + 2f * float_5, float_4 + float_6),
				new PointF(float_3 + 2f * float_5, float_4),
				new PointF(float_3 + class913_0.Width, float_4),
				new PointF(float_3 + class913_0.Width, float_4 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6)
			});
			interface42_0.imethod_33(brush_, graphicsPath4);
		}
		if (!class913_0.Line.method_0())
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			PointF[] array2 = new PointF[4]
			{
				new PointF(rect.X, rect.Y),
				new PointF(rect.X + rect.Width, rect.Y),
				new PointF(rect.X + rect.Width, rect.Y + 0.8f * rect.Height),
				new PointF(rect.X, rect.Y + 0.93f * rect.Height)
			};
			PointF pt3 = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height * 1.13f);
			PointF pt4 = new PointF(rect.X + rect.Width / 2f, rect.Y + 0.8f * rect.Height);
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
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - 2f * float_5, float_4 + float_6 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - 2f * float_5, float_4 + 2f * float_6)
			});
			interface42_0.imethod_18(pen_, graphicsPath6);
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(new PointF[6]
			{
				new PointF(float_3 + 2f * float_5, float_4 + float_6),
				new PointF(float_3 + 2f * float_5, float_4),
				new PointF(float_3 + class913_0.Width, float_4),
				new PointF(float_3 + class913_0.Width, float_4 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + 0.66f * class913_0.Height),
				new PointF(float_3 + class913_0.Width - float_5, float_4 + float_6)
			});
			interface42_0.imethod_18(pen_, graphicsPath7);
		}
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = class913_0.method_8();
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class913_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class913_0.TextFrame.TopMargin + float_6 * 2f;
		rectangleF_.Width -= float_5 * 3f;
		if (rectangleF_.Height < (float)class913_0.Font.Height)
		{
			float num2 = ((float)class913_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class913_0.Font.Height);
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
