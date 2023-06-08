using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class143 : Class18
{
	internal Class143(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
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
		Brush brush_3 = Struct69.smethod_1(class898_0.Fill, graphicsPath_3, 0.8f, 0f);
		GraphicsPath graphicsPath_4 = method_3(x, y, width, height, 3);
		Brush brush_4 = Struct69.smethod_0(class898_0.Fill, graphicsPath_4);
		GraphicsPath graphicsPath_5 = method_3(x, y, width, height, 4);
		Brush brush_5 = Struct69.smethod_1(class898_0.Fill, graphicsPath_5, 0.8f, 0f);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_33(brush_, graphicsPath_);
			interface42_0.imethod_33(brush_2, graphicsPath_2);
			interface42_0.imethod_33(brush_4, graphicsPath_4);
			interface42_0.imethod_33(brush_3, graphicsPath_3);
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

	private GraphicsPath method_3(float float_5, float float_6, float float_7, float float_8, int int_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (2588f * ((class898_0.Width > class898_0.Height) ? class898_0.Height : class898_0.Width) / 21600f) : (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) * ((class898_0.Width > class898_0.Height) ? class898_0.Height : class898_0.Width) / 21600f));
		float num2 = num;
		switch (class898_0.int_2)
		{
		case 1:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 0f, 90f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + num2, float_5 + num2 / 2f, float_6 + num2);
				graphicsPath.AddArc(float_5, float_6 + num2, num2, num2, 270f, -180f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + 2f * num2, float_5 + num2 / 2f, float_6 + 1.5f * num2);
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + 1.25f * num2, num2 / 2f, num2 / 2f, 180f, 180f);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 2f * num2, num2, num2, 90f, -90f);
				graphicsPath.AddLine(float_5 + float_7, float_6 + float_8 - 1.5f * num2, float_5 + float_7, float_6 + num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + 0.25f * num2, num2 / 2f, num2 / 2f, 180f, -180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + num2);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + num2, float_5 + float_7 - num2, float_6 + num2);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2, float_5 + float_7 - num2, float_6 + num2 / 2f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + 0.25f * num2, num2 / 2f, num2 / 2f, 0f, 180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 180f, 270f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + num2, float_5 + float_7 - num2 / 2f, float_6 + num2 / 2f);
				break;
			case 3:
				graphicsPath.AddLine(float_5 + num2, float_6 + 1.5f * num2, float_5 + num2, float_6 + float_8 - num2 / 2f);
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, 0f, 180f);
				graphicsPath.AddLine(float_5, float_6 + float_8 - num2 / 2f, float_5, float_6 + 1.5f * num2);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5, float_6 + num2, num2, num2, 180f, -180f);
				break;
			default:
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + 1.25f * num2, num2 / 2f, num2 / 2f, 180f, 180f);
				graphicsPath.AddArc(float_5, float_6 + num2, num2, num2, 0f, 90f);
				graphicsPath.CloseFigure();
				break;
			}
			break;
		case 2:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 0f, -90f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5, float_6 + float_8 - 2f * num2, num2, num2, 90f, 180f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8 - 2f * num2, float_5 + num2 / 2f, float_6 + float_8 - 1.5f * num2);
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + float_8 - 1.75f * num2, num2 / 2f, num2 / 2f, 180f, -180f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2, float_5 + float_7 - num2 / 2f, float_6 + num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + num2, num2, num2, 270f, 90f);
				graphicsPath.AddLine(float_5 + float_7, float_6 + 1.5f * num2, float_5 + float_7, float_6 + float_8 - num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 0.75f * num2, num2 / 2f, num2 / 2f, 180f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2, float_5 + float_7 - num2, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2, float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 0.75f * num2, num2 / 2f, num2 / 2f, 0f, -180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 180f, -270f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2 / 2f);
				break;
			case 3:
				graphicsPath.AddLine(float_5, float_6 + float_8 - 1.5f * num2, float_5, float_6 + num2 / 2f);
				graphicsPath.AddArc(float_5, float_6, num2, num2, 180f, 180f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2, float_6 + float_8 - 1.5f * num2);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5, float_6 + float_8 - 2f * num2, num2, num2, 0f, -180f);
				break;
			default:
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + float_8 - 1.75f * num2, num2 / 2f, num2 / 2f, 180f, -180f);
				graphicsPath.AddArc(float_5, float_6 + float_8 - 2f * num2, num2, num2, 0f, -90f);
				graphicsPath.CloseFigure();
				break;
			}
			break;
		case 3:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, 180f, 90f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8 - num2, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 2f * num2, num2, num2, 90f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - 2f * num2, float_5 + float_7 - num2 / 2f, float_6 + float_8 - 1.5f * num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 1.75f * num2, num2 / 2f, num2 / 2f, 0f, 180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2, float_5 + num2 / 2f, float_6 + num2);
				graphicsPath.AddArc(float_5, float_6 + num2, num2, num2, 270f, -90f);
				graphicsPath.AddLine(float_5, float_6 + 1.5f * num2, float_5, float_6 + float_8 - num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + float_8 - 0.75f * num2, num2 / 2f, num2 / 2f, 180f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2 / 2f, float_5 + num2, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2 / 2f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + num2 / 2f, float_6 + float_8 - 0.75f * num2, num2 / 2f, num2 / 2f, 180f, 180f);
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, 0f, 270f);
				break;
			case 3:
				graphicsPath.AddLine(float_5 + float_7, float_6 + float_8 - 1.5f * num2, float_5 + float_7, float_6 + num2 / 2f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 0f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2 / 2f, float_5 + float_7 - num2, float_6 + float_8 - 1.5f * num2);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 2f * num2, num2, num2, 180f, 180f);
				break;
			default:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 1.75f * num2, num2 / 2f, num2 / 2f, 0f, 180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - 2f * num2, num2, num2, 180f, 90f);
				graphicsPath.CloseFigure();
				break;
			}
			break;
		case 4:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5, float_6, num2, num2, 180f, -90f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + num2, float_5 + float_7 - num2 / 2f, float_6 + num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + num2, num2, num2, 270f, 180f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + 2f * num2, float_5 + float_7 - num2 / 2f, float_6 + 1.5f * num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + 1.25f * num2, num2 / 2f, num2 / 2f, 0f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5, float_6 + float_8 - 2f * num2, num2, num2, 90f, 90f);
				graphicsPath.AddLine(float_5, float_6 + float_8 - 1.5f * num2, float_5, float_6 + num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + 0.5f * num2, float_6 + 0.25f * num2, num2 / 2f, num2 / 2f, 180f, -180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2, float_6 + num2);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2, float_5 + num2 / 2f, float_6 + num2);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + num2, float_5 + num2 / 2f, float_6 + num2 / 2f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + num2 / 2f, float_6 + 0.25f * num2, num2 / 2f, num2 / 2f, 180f, -180f);
				graphicsPath.AddArc(float_5, float_6, num2, num2, 0f, -270f);
				break;
			case 3:
				graphicsPath.AddLine(float_5 + float_7, float_6 + 1.5f * num2, float_5 + float_7, float_6 + float_8 - num2 / 2f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 0f, 180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2, float_6 + 1.5f * num2);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + num2, num2, num2, 180f, -180f);
				break;
			default:
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + 1.25f * num2, num2 / 2f, num2 / 2f, 0f, -180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + num2, num2, num2, 180f, -90f);
				graphicsPath.CloseFigure();
				break;
			}
			break;
		}
		return graphicsPath;
	}
}
