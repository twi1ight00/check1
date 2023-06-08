using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class54 : Class18
{
	private float float_5;

	internal Class54(Interface42 interface42_1, float float_6, float float_7, Class898 class898_1)
		: base(interface42_1, float_6, float_7, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			float_5 = rectangleF.Height * (float)((Class882)class898_0.class885_0.arrayList_0[0]).Value / 21600f;
		}
		else
		{
			float_5 = rectangleF.Height * 0.25f;
		}
		PointF[] array = new PointF[4];
		if (!class898_0.Fill.method_0())
		{
			if (float_5 == 0f)
			{
				interface42_0.imethod_37(brush, rectangleF);
			}
			else
			{
				switch (class898_0.int_2)
				{
				case 2:
				case 3:
				{
					RectangleF rectangleF_2 = new RectangleF(num, num2 + height - float_5, width, float_5);
					RectangleF rect2 = new RectangleF(num, num2 + height - float_5, width, float_5);
					ref PointF reference5 = ref array[0];
					reference5 = new PointF(float_3, height - float_5 / 2f + float_4);
					ref PointF reference6 = ref array[1];
					reference6 = new PointF(rectangleF.Width + float_3, height - float_5 / 2f + float_4);
					ref PointF reference7 = ref array[2];
					reference7 = new PointF(rectangleF.Width + float_3, float_5 / 2f + float_4);
					ref PointF reference8 = ref array[3];
					reference8 = new PointF(float_3, float_5 / 2f + float_4);
					Brush brush_ = null;
					if (class898_0.Fill.method_5())
					{
						brush_ = Struct69.smethod_1(class898_0.Fill, graphicsPath, 0.8f, 0f);
					}
					else if (class898_0.Fill.method_2().ToArgb() == Color.White.ToArgb())
					{
						Brush brush2 = brush;
					}
					else
					{
						brush_ = Struct69.smethod_3(class898_0.Fill, rectangleF_2, 0.8f, 80f);
					}
					interface42_0.imethod_31(brush_, rectangleF_2);
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddArc(rect2, 0f, -180f);
					graphicsPath3.AddLine(array[0], array[3]);
					rect2.Y = float_4;
					graphicsPath3.AddArc(rect2, 180f, 180f);
					graphicsPath3.AddLine(array[2], array[1]);
					graphicsPath3.CloseFigure();
					interface42_0.imethod_33(brush, graphicsPath3);
					break;
				}
				case 1:
				case 4:
				{
					RectangleF rectangleF_ = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, float_5));
					RectangleF rect = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, float_5));
					ref PointF reference = ref array[0];
					reference = new PointF(float_3, float_5 / 2f + float_4);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF.Width + float_3, float_5 / 2f + float_4);
					ref PointF reference3 = ref array[2];
					reference3 = new PointF(rectangleF.Width + float_3, float_5 + (rectangleF.Height - 2f * float_5) + float_5 / 2f + float_4);
					ref PointF reference4 = ref array[3];
					reference4 = new PointF(float_3, float_5 + (rectangleF.Height - 2f * float_5) + float_5 / 2f + float_4);
					Brush brush2 = null;
					brush2 = (class898_0.Fill.method_5() ? Struct69.smethod_1(class898_0.Fill, graphicsPath, 0.8f, 0f) : ((class898_0.Fill.method_2().ToArgb() != Color.White.ToArgb()) ? Struct69.smethod_3(class898_0.Fill, rectangleF_, 0.8f, 80f) : brush));
					interface42_0.imethod_31(brush2, rectangleF_);
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddArc(rect, 0f, 180f);
					graphicsPath2.AddLine(array[0], array[3]);
					rect.Y = float_5 + (rectangleF.Height - 2f * float_5 + float_4);
					graphicsPath2.AddArc(rect, 180f, -180f);
					graphicsPath2.AddLine(array[2], array[1]);
					graphicsPath2.CloseFigure();
					interface42_0.imethod_33(brush, graphicsPath2);
					break;
				}
				}
			}
		}
		if (!class898_0.Line.method_0())
		{
			if (float_5 == 0f)
			{
				interface42_0.imethod_22(pen_, (int)num, (int)num2, (int)width, (int)height);
			}
			else
			{
				switch (class898_0.int_2)
				{
				case 2:
				case 3:
				{
					RectangleF rectangleF_5 = new RectangleF(num, num2 + height - float_5, width, float_5);
					RectangleF rectangleF_6 = new RectangleF(num, num2 + height - float_5, width, float_5);
					ref PointF reference13 = ref array[0];
					reference13 = new PointF(float_3, height - float_5 / 2f + float_4);
					ref PointF reference14 = ref array[1];
					reference14 = new PointF(rectangleF.Width + float_3, height - float_5 / 2f + float_4);
					ref PointF reference15 = ref array[2];
					reference15 = new PointF(rectangleF.Width + float_3, float_5 / 2f + float_4);
					ref PointF reference16 = ref array[3];
					reference16 = new PointF(float_3, float_5 / 2f + float_4);
					interface42_0.imethod_9(pen_, rectangleF_5);
					interface42_0.imethod_4(pen_, rectangleF_6, 0f, -180f);
					interface42_0.imethod_15(pen_, array[0], array[3]);
					rectangleF_6.Y = float_4;
					interface42_0.imethod_4(pen_, rectangleF_6, 180f, 180f);
					interface42_0.imethod_15(pen_, array[2], array[1]);
					break;
				}
				case 1:
				case 4:
				{
					RectangleF rectangleF_3 = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, float_5));
					RectangleF rectangleF_4 = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, float_5));
					ref PointF reference9 = ref array[0];
					reference9 = new PointF(float_3, float_5 / 2f + float_4);
					ref PointF reference10 = ref array[1];
					reference10 = new PointF(rectangleF.Width + float_3, float_5 / 2f + float_4);
					ref PointF reference11 = ref array[2];
					reference11 = new PointF(rectangleF.Width + float_3, float_5 + (rectangleF.Height - 2f * float_5) + float_5 / 2f + float_4);
					ref PointF reference12 = ref array[3];
					reference12 = new PointF(float_3, float_5 + (rectangleF.Height - 2f * float_5) + float_5 / 2f + float_4);
					interface42_0.imethod_9(pen_, rectangleF_3);
					interface42_0.imethod_4(pen_, rectangleF_4, 0f, 180f);
					interface42_0.imethod_15(pen_, array[0], array[3]);
					rectangleF_4.Y = float_5 + (rectangleF.Height - 2f * float_5 + float_4);
					interface42_0.imethod_4(pen_, rectangleF_4, 180f, -180f);
					interface42_0.imethod_15(pen_, array[2], array[1]);
					break;
				}
				}
			}
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
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + float_5;
		rectangleF_.Width -= (float)class898_0.TextFrame.RightMargin;
		rectangleF_.Height -= (float)class898_0.TextFrame.BottomMargin;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
