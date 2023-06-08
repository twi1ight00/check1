using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class172 : Class160
{
	internal Class172(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		float num3 = 0f;
		num3 = ((class913_0.class901_0 == null) ? (rectangleF.Height * 0.17f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (rectangleF.Height * 0.17f) : (Math.Min(rectangleF.Width, rectangleF.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		PointF[] array = new PointF[4];
		if (!class913_0.Fill.method_0())
		{
			if (num3 == 0f)
			{
				interface42_0.imethod_37(brush_, rectangleF);
			}
			else
			{
				switch (class913_0.int_3)
				{
				case 2:
				case 3:
				{
					RectangleF rectangleF_2 = new RectangleF(num, num2 + height - num3, width, num3);
					RectangleF rect2 = new RectangleF(num, num2 + height - num3, width, num3);
					ref PointF reference5 = ref array[0];
					reference5 = new PointF(float_3, height - num3 / 2f + float_4);
					ref PointF reference6 = ref array[1];
					reference6 = new PointF(rectangleF.Width + float_3, height - num3 / 2f + float_4);
					ref PointF reference7 = ref array[2];
					reference7 = new PointF(rectangleF.Width + float_3, num3 / 2f + float_4);
					ref PointF reference8 = ref array[3];
					reference8 = new PointF(float_3, num3 / 2f + float_4);
					interface42_0.imethod_31(brush_, rectangleF_2);
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddArc(rect2, 0f, -180f);
					graphicsPath3.AddLine(array[0], array[3]);
					rect2.Y = float_4;
					graphicsPath3.AddArc(rect2, 180f, 180f);
					graphicsPath3.AddLine(array[2], array[1]);
					graphicsPath3.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath3);
					break;
				}
				case 1:
				case 4:
				{
					RectangleF rectangleF_ = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, num3));
					RectangleF rect = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, num3));
					ref PointF reference = ref array[0];
					reference = new PointF(float_3, num3 / 2f + float_4);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF.Width + float_3, num3 / 2f + float_4);
					ref PointF reference3 = ref array[2];
					reference3 = new PointF(rectangleF.Width + float_3, num3 + (rectangleF.Height - 2f * num3) + num3 / 2f + float_4);
					ref PointF reference4 = ref array[3];
					reference4 = new PointF(float_3, num3 + (rectangleF.Height - 2f * num3) + num3 / 2f + float_4);
					interface42_0.imethod_31(brush_, rectangleF_);
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddArc(rect, 0f, 180f);
					graphicsPath2.AddLine(array[0], array[3]);
					rect.Y = num3 + (rectangleF.Height - 2f * num3 + float_4);
					graphicsPath2.AddArc(rect, 180f, -180f);
					graphicsPath2.AddLine(array[2], array[1]);
					graphicsPath2.CloseFigure();
					interface42_0.imethod_33(brush_, graphicsPath2);
					break;
				}
				}
			}
		}
		if (!class913_0.Line.method_0())
		{
			if (num3 == 0f)
			{
				interface42_0.imethod_22(pen_, (int)num, (int)num2, (int)width, (int)height);
			}
			else
			{
				switch (class913_0.int_3)
				{
				case 2:
				case 3:
				{
					RectangleF rectangleF_5 = new RectangleF(num, num2 + height - num3, width, num3);
					RectangleF rectangleF_6 = new RectangleF(num, num2 + height - num3, width, num3);
					ref PointF reference13 = ref array[0];
					reference13 = new PointF(float_3, height - num3 / 2f + float_4);
					ref PointF reference14 = ref array[1];
					reference14 = new PointF(rectangleF.Width + float_3, height - num3 / 2f + float_4);
					ref PointF reference15 = ref array[2];
					reference15 = new PointF(rectangleF.Width + float_3, num3 / 2f + float_4);
					ref PointF reference16 = ref array[3];
					reference16 = new PointF(float_3, num3 / 2f + float_4);
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
					RectangleF rectangleF_3 = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, num3));
					RectangleF rectangleF_4 = new RectangleF(rectangleF.Location, new SizeF(rectangleF.Width, num3));
					ref PointF reference9 = ref array[0];
					reference9 = new PointF(float_3, num3 / 2f + float_4);
					ref PointF reference10 = ref array[1];
					reference10 = new PointF(rectangleF.Width + float_3, num3 / 2f + float_4);
					ref PointF reference11 = ref array[2];
					reference11 = new PointF(rectangleF.Width + float_3, num3 + (rectangleF.Height - 2f * num3) + num3 / 2f + float_4);
					ref PointF reference12 = ref array[3];
					reference12 = new PointF(float_3, num3 + (rectangleF.Height - 2f * num3) + num3 / 2f + float_4);
					interface42_0.imethod_9(pen_, rectangleF_3);
					interface42_0.imethod_4(pen_, rectangleF_4, 0f, 180f);
					interface42_0.imethod_15(pen_, array[0], array[3]);
					rectangleF_4.Y = num3 + (rectangleF.Height - 2f * num3 + float_4);
					interface42_0.imethod_4(pen_, rectangleF_4, 180f, -180f);
					interface42_0.imethod_15(pen_, array[2], array[1]);
					break;
				}
				}
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
