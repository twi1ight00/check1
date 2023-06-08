using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class292 : Class160
{
	private float float_5;

	private float float_6;

	internal Class292(Interface42 interface42_1, float float_7, float float_8, Class913 class913_1)
		: base(interface42_1, float_7, float_8, class913_1)
	{
		if (!class913_0.method_21())
		{
			class913_0.Rotation = 180;
		}
		else
		{
			class913_0.Rotation = 0;
		}
	}

	internal override void vmethod_3()
	{
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.Width;
		float height = class913_0.Height;
		RectangleF rect = new RectangleF(x, y, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath graphicsPath_ = method_3(x, y, width, height, 0);
		GraphicsPath graphicsPath_2 = method_3(x, y, width, height, 1);
		GraphicsPath graphicsPath_3 = method_3(x, y, width, height, 2);
		GraphicsPath graphicsPath_4 = method_3(x, y, width, height, 3);
		GraphicsPath graphicsPath_5 = method_3(x, y, width, height, 4);
		if (!class913_0.Fill.method_0())
		{
			interface42_0.imethod_33(brush_, graphicsPath_);
			interface42_0.imethod_33(brush_, graphicsPath_2);
			interface42_0.imethod_33(brush_, graphicsPath_3);
			interface42_0.imethod_33(brush_, graphicsPath_4);
			interface42_0.imethod_33(brush_, graphicsPath_5);
		}
		if (!class913_0.Line.method_0())
		{
			interface42_0.imethod_18(pen_, graphicsPath_);
			interface42_0.imethod_18(pen_, graphicsPath_2);
			interface42_0.imethod_18(pen_, graphicsPath_3);
			interface42_0.imethod_18(pen_, graphicsPath_4);
			interface42_0.imethod_18(pen_, graphicsPath_5);
		}
		base.vmethod_4();
	}

	public GraphicsPath method_3(float float_7, float float_8, float float_9, float float_10, int int_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				float_6 = class913_0.Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				float_5 = class913_0.Width / 2f * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				float_6 = class913_0.Height * 16667f / 100000f;
				float_5 = class913_0.Width / 2f * 50000f / 100000f;
			}
		}
		else
		{
			float_6 = class913_0.Height * 16667f / 100000f;
			float_5 = class913_0.Width / 2f * 50000f / 100000f;
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
