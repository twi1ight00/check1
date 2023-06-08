using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class307 : Class160
{
	internal Class307(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
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
			interface42_0.imethod_33(brush_, graphicsPath_4);
			interface42_0.imethod_33(brush_, graphicsPath_3);
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

	private GraphicsPath method_3(float float_5, float float_6, float float_7, float float_8, int int_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		num = ((class913_0.class901_0 == null) ? (13630f * ((class913_0.Width > class913_0.Height) ? class913_0.Height : class913_0.Width) / 100000f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (13630f * ((class913_0.Width > class913_0.Height) ? class913_0.Height : class913_0.Width) / 100000f) : (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) * ((class913_0.Width > class913_0.Height) ? class913_0.Height : class913_0.Width) / 100000f)));
		float num2 = num;
		switch (class913_0.int_3)
		{
		case 1:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + num2, float_6, num2, num2, 0f, -180f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2, float_6 + float_8 - num2 / 2f);
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, 0f, 90f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8, float_5 + float_7 - 1.5f * num2, float_6 + float_8);
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6 + float_8 - num2, num2, num2, 90f, -90f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2, float_6 + num2);
				graphicsPath.AddArc(float_5 + 1.25f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 90f, 180f);
				graphicsPath.AddLine(float_5 + 1.5f * num2, float_6 + num2 / 2f, float_5 + 2f * num2, float_6 + num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + num2, float_6, num2, num2, -90f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + 1.5f * num2, float_6 + num2, float_5 + float_7 - num2 / 2f, float_6 + num2);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 90f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6, float_5 + 1.5f * num2, float_6);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + num2, float_6, num2, num2, 0f, 90f);
				graphicsPath.AddArc(float_5 + 1.25f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 90f, 180f);
				graphicsPath.CloseFigure();
				break;
			case 3:
				graphicsPath.AddArc(float_5 + 0.25f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, -90f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8 - num2 / 2f, float_5 + num2, float_6 + float_8 - num2 / 2f);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2 / 2f, float_5 + num2, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2);
				break;
			default:
				graphicsPath.AddArc(float_5 + 0.25f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 90f, -180f);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, -90f, -270f);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2 / 2f, float_5 + num2 / 2f, float_6 + float_8 - num2 / 2f);
				break;
			}
			break;
		case 2:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + num2, float_6 + float_8 - num2, num2, num2, 0f, 180f);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2 / 2f, float_5 + num2, float_6 + num2 / 2f);
				graphicsPath.AddArc(float_5, float_6, num2, num2, 0f, -90f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6, float_5 + float_7 - 1.5f * num2, float_6);
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6, num2, num2, 270f, 90f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2 / 2f, float_5 + float_7 - num2, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5 + 1.25f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 270f, -180f);
				graphicsPath.AddLine(float_5 + 1.5f * num2, float_6 + float_8 - num2 / 2f, float_5 + 2f * num2, float_6 + float_8 - num2 / 2f);
				break;
			case 1:
				graphicsPath.AddArc(float_5 + num2, float_6 + float_8 - num2, num2, num2, 270f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + 1.5f * num2, float_6 + float_8, float_5 + float_7 - num2 / 2f, float_6 + float_8);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 90f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2, float_5 + 1.5f * num2, float_6 + float_8 - num2);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + num2, float_6 + float_8 - num2, num2, num2, 0f, -90f);
				graphicsPath.AddArc(float_5 + 1.25f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 270f, -180f);
				graphicsPath.CloseFigure();
				break;
			case 3:
				graphicsPath.AddArc(float_5 + 0.25f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 270f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + num2, float_5 + num2, float_6 + num2);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2, float_5 + num2, float_6 + num2 / 2f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2 / 2f, float_6 + num2 / 2f);
				break;
			default:
				graphicsPath.AddArc(float_5 + 0.25f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 270f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5, float_6, num2, num2, 90f, 270f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2 / 2f, float_6 + num2 / 2f);
				break;
			}
			break;
		case 3:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6 + float_8 - num2, num2, num2, 180f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2, float_6 + num2 / 2f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 180f, 90f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6, float_5 + 1.5f * num2, float_6);
				graphicsPath.AddArc(float_5 + num2, float_6, num2, num2, 270f, -90f);
				graphicsPath.AddLine(float_5 + num2, float_6 + num2 / 2f, float_5 + num2, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2, float_5 + float_7 - 1.5f * num2, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5 + float_7 - 1.75f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 270f, 180f);
				graphicsPath.AddLine(float_5 + float_7 - 1.5f * num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - 2f * num2, float_6 + float_8 - num2 / 2f);
				break;
			case 1:
				graphicsPath.AddLine(float_5 + float_7 - 1.5f * num2, float_6 + float_8 - num2, float_5 + num2 / 2f, float_6 + float_8 - num2);
				graphicsPath.AddArc(float_5, float_6 + float_8 - num2, num2, num2, 270f, -180f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + float_8, float_5 + float_7 - 1.5f * num2, float_6 + float_8);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6 + float_8 - num2, num2, num2, 90f, 180f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6 + float_8 - num2, num2, num2, 270f, -90f);
				graphicsPath.AddArc(float_5 + float_7 - 1.75f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 90f, -180f);
				graphicsPath.CloseFigure();
				break;
			case 3:
				graphicsPath.AddArc(float_5 + float_7 - 0.75f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 270f, -180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + num2, float_5 + float_7 - num2, float_6 + num2);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2, float_5 + float_7 - num2, float_6 + num2 / 2f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + num2 / 2f);
				break;
			default:
				graphicsPath.AddArc(float_5 + float_7 - 0.75f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 270f, -180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6, num2, num2, 90f, -270f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + num2 / 2f);
				graphicsPath.StartFigure();
				break;
			}
			break;
		case 4:
			switch (int_0)
			{
			case 0:
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6, num2, num2, 180f, 180f);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + num2 / 2f, float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 180f, -90f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8, float_5 + 1.5f * num2, float_6 + float_8);
				graphicsPath.AddArc(float_5 + num2, float_6 + float_8 - num2, num2, num2, 90f, 90f);
				graphicsPath.AddLine(float_5 + num2, float_6 + float_8 - num2 / 2f, float_5 + num2, float_6 + num2);
				graphicsPath.AddArc(float_5 + float_7 - 1.75f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 90f, -180f);
				graphicsPath.AddLine(float_5 + float_7 - 1.5f * num2, float_6 + num2 / 2f, float_5 + float_7 - 2f * num2, float_6 + num2 / 2f);
				break;
			case 1:
				graphicsPath.AddLine(float_5 + float_7 - 1.5f * num2, float_6, float_5 + num2 / 2f, float_6);
				graphicsPath.AddArc(float_5, float_6, num2, num2, 270f, -180f);
				graphicsPath.AddLine(float_5 + num2 / 2f, float_6 + num2, float_5 + float_7 - 1.5f * num2, float_6 + num2);
				graphicsPath.StartFigure();
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6, num2, num2, 90f, 180f);
				break;
			case 2:
				graphicsPath.AddArc(float_5 + float_7 - 2f * num2, float_6, num2, num2, 180f, -90f);
				graphicsPath.AddArc(float_5 + float_7 - 1.75f * num2, float_6 + num2 / 2f, num2 / 2f, num2 / 2f, 90f, -180f);
				graphicsPath.CloseFigure();
				break;
			case 3:
				graphicsPath.AddArc(float_5 + float_7 - 0.75f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 90f, 180f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2, float_5 + float_7 - num2, float_6 + float_8 - num2);
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2 / 2f);
				break;
			default:
				graphicsPath.AddArc(float_5 + float_7 - 0.75f * num2, float_6 + float_8 - num2, num2 / 2f, num2 / 2f, 90f, 180f);
				graphicsPath.AddArc(float_5 + float_7 - num2, float_6 + float_8 - num2, num2, num2, 270f, 270f);
				graphicsPath.StartFigure();
				graphicsPath.AddLine(float_5 + float_7 - num2, float_6 + float_8 - num2 / 2f, float_5 + float_7 - num2 / 2f, float_6 + float_8 - num2 / 2f);
				break;
			}
			break;
		}
		return graphicsPath;
	}
}
