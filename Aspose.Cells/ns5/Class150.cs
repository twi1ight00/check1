using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class150 : Class18
{
	private float float_5;

	private float float_6;

	internal Class150(Interface42 interface42_1, float float_7, float float_8, Class898 class898_1)
		: base(interface42_1, float_7, float_8, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float x = class898_0.X;
		float y = class898_0.Y;
		float width = class898_0.Width;
		float height = class898_0.Height;
		new RectangleF(x, y, width, height);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		GraphicsPath graphicsPath_ = method_3(x, y, width, height, 0);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath_);
		GraphicsPath graphicsPath_2 = method_3(x, y, width, height, 1);
		Brush brush_2 = Struct69.smethod_0(class898_0.Fill, graphicsPath_2);
		GraphicsPath graphicsPath_3 = method_3(x, y, width, height, 2);
		Brush brush_3 = Struct69.smethod_0(class898_0.Fill, graphicsPath_3);
		GraphicsPath graphicsPath_4 = method_3(x, y, width, height, 3);
		Brush brush_4 = Struct69.smethod_1(class898_0.Fill, graphicsPath_4, 0.8f, 0f);
		GraphicsPath graphicsPath_5 = method_3(x, y, width, height, 4);
		Brush brush_5 = Struct69.smethod_1(class898_0.Fill, graphicsPath_5, 0.8f, 0f);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_33(brush_, graphicsPath_);
			interface42_0.imethod_33(brush_2, graphicsPath_2);
			interface42_0.imethod_33(brush_3, graphicsPath_3);
			interface42_0.imethod_33(brush_4, graphicsPath_4);
			interface42_0.imethod_33(brush_5, graphicsPath_5);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_18(pen_, graphicsPath_);
			interface42_0.imethod_18(pen_, graphicsPath_2);
			interface42_0.imethod_18(pen_, graphicsPath_3);
			interface42_0.imethod_18(pen_, graphicsPath_4);
			interface42_0.imethod_18(pen_, graphicsPath_5);
		}
		base.vmethod_4();
	}

	internal GraphicsPath method_3(float float_7, float float_8, float float_9, float float_10, int int_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			float_6 = class898_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			float_5 = class898_0.Width / 3f * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				float_6 = class898_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			else
			{
				float_6 = class898_0.Height * 5452f / 21600f;
			}
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				float_5 = class898_0.Width / 3f * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			else
			{
				float_5 = class898_0.Width / 3f * 18753f / 21600f;
			}
		}
		else
		{
			float_6 = class898_0.Height * 5452f / 21600f;
			float_5 = class898_0.Width / 3f * 18753f / 21600f;
		}
		float num = float_9 / 2f - float_5;
		float num2 = float_10 - float_6;
		float num3 = float_10 - num2;
		switch (int_0)
		{
		case 0:
			graphicsPath.AddArc(float_7 + num, float_8 + num2, 0.0555f * float_9, num3 / 2f, 180f, 90f);
			graphicsPath.AddLine(float_7 + num + 0.0277f * float_9, float_8 + num2, float_7 + float_9 - 0.0277f * float_9 - num, float_8 + num2);
			graphicsPath.AddArc(float_7 + float_9 - 0.0555f * float_9 - num, float_8 + num2, 0.0555f * float_9, num3 / 2f, -90f, 90f);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(float_7 + float_9 - num, float_8 + float_10 - 3f * num3 / 4f, float_7 + float_9 - num, float_8 + num3 / 4f);
			graphicsPath.AddArc(float_7 + float_9 - 0.0555f * float_9 - num, float_8, 0.0555f * float_9, num3 / 2f, 0f, -90f);
			graphicsPath.AddLine(float_7 + float_9 - num - 0.0277f * float_9, float_8, float_7 + num + 0.0277f * float_9, float_8);
			graphicsPath.AddArc(float_7 + num, float_8, 0.0555f * float_9, num3 / 2f, 270f, -90f);
			graphicsPath.AddLine(float_7 + num, float_8 + num3 / 4f, float_7 + num, float_8 + float_10 - 3f * num3 / 4f);
			break;
		case 1:
			graphicsPath.AddLine(float_7, float_8 + num3, float_7 + num, float_8 + num3);
			graphicsPath.AddLine(float_7 + num, float_8 + num3, float_7 + num, float_8 + float_10 - 3f * num3 / 4f);
			graphicsPath.AddArc(float_7 + num, float_8 + num2, 0.0555f * float_9, num3 / 2f, 180f, -90f);
			graphicsPath.AddLine(float_7 + num + 0.0277f * float_9, float_8 + float_10 - num3 / 2f, float_7 + num + 0.1f * float_9, float_8 + float_10 - num3 / 2f);
			graphicsPath.AddArc(float_7 + num + 0.0722f * float_9, float_8 + num2 + num3 / 2f, 0.0555f * float_9, num3 / 2f, 270f, 180f);
			graphicsPath.AddLine(float_7, float_8 + float_10, float_7 + 0.125f * float_9, float_8 + num3 + num2 / 2f);
			graphicsPath.AddLine(float_7 + 0.125f * float_9, float_8 + num3 + num2 / 2f, float_7, float_8 + num3);
			graphicsPath.CloseFigure();
			break;
		case 2:
			graphicsPath.AddLine(float_7 + float_9, float_8 + num3, float_7 + float_9 - num, float_8 + num3);
			graphicsPath.AddLine(float_7 + float_9 - num, float_8 + num3, float_7 + float_9 - num, float_8 + float_10 - 3f * num3 / 4f);
			graphicsPath.AddArc(float_7 + float_9 - 0.0555f * float_9 - num, float_8 + num2, 0.0555f * float_9, num3 / 2f, 0f, 90f);
			graphicsPath.AddArc(float_7 + float_9 - num - 0.1277f * float_9, float_8 + num2 + num3 / 2f, 0.0555f * float_9, num3 / 2f, 270f, -180f);
			graphicsPath.AddLine(float_7 + float_9, float_8 + float_10, float_7 + 0.875f * float_9, float_8 + num3 + num2 / 2f);
			graphicsPath.AddLine(float_7 + 0.875f * float_9, float_8 + num3 + num2 / 2f, float_7 + float_9, float_8 + num3);
			graphicsPath.CloseFigure();
			break;
		case 3:
			graphicsPath.AddArc(float_7 + num, float_8 + num2, 0.0555f * float_9, num3 / 2f, 270f, -180f);
			graphicsPath.AddArc(float_7 + num + 0.0722f * float_9, float_8 + num2 + num3 / 2f, 0.0555f * float_9, num3 / 2f, 270f, 90f);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(float_7 + num + 0.1277f * float_9, float_8 + float_10 - num3 / 4f, float_7 + num + 0.1277f * float_9, float_8 + num2);
			graphicsPath.AddLine(float_7 + num + 0.1277f * float_9, float_8 + num2, float_7 + num + 0.0277f * float_9, float_8 + num2);
			break;
		default:
			graphicsPath.AddArc(float_7 + float_9 - 0.0555f * float_9 - num, float_8 + num2, 0.0555f * float_9, num3 / 2f, 270f, 180f);
			graphicsPath.AddArc(float_7 + float_9 - num - 0.1277f * float_9, float_8 + num2 + num3 / 2f, 0.0555f * float_9, num3 / 2f, 270f, -90f);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(float_7 + float_9 - num - 0.1277f * float_9, float_8 + float_10 - num3 / 4f, float_7 + float_9 - num - 0.1277f * float_9, float_8 + num2);
			graphicsPath.AddLine(float_7 + float_9 - num - 0.1277f * float_9, float_8 + num2, float_7 + float_9 - num - 0.0277f * float_9, float_8 + num2);
			break;
		}
		return graphicsPath;
	}
}
