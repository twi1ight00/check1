using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class117 : Class18
{
	internal Class117(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[4];
		switch (class898_0.int_2)
		{
		case 1:
		{
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + 0.8f * rectangleF_0.Height);
			ref PointF reference16 = ref array[3];
			reference16 = new PointF(rectangleF_0.X, rectangleF_0.Y + 0.93f * rectangleF_0.Height);
			PointF pt = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height * 1.13f);
			PointF pt2 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + 0.8f * rectangleF_0.Height);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddBezier(array[2], pt2, pt, array[3]);
			graphicsPath.AddLine(array[3], array[0]);
			break;
		}
		case 2:
		{
			ref PointF reference9 = ref array[0];
			reference9 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height * 0.07f);
			ref PointF reference10 = ref array[1];
			reference10 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.2f);
			ref PointF reference11 = ref array[2];
			reference11 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference12 = ref array[3];
			reference12 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			graphicsPath.AddBezier(pt2: new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y - rectangleF_0.Height * 0.13f), pt3: new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + 0.2f * rectangleF_0.Height), pt1: array[0], pt4: array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[0]);
			break;
		}
		case 3:
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height * 0.2f);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height * 0.07f);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height);
			graphicsPath.AddBezier(pt3: new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y - rectangleF_0.Height * 0.13f), pt2: new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + 0.2f * rectangleF_0.Height), pt1: array[0], pt4: array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[0]);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + 0.93f * rectangleF_0.Height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(rectangleF_0.X, rectangleF_0.Y + 0.8f * rectangleF_0.Height);
			PointF pt = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height * 1.13f);
			PointF pt2 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + 0.8f * rectangleF_0.Height);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddBezier(array[2], pt, pt2, array[3]);
			graphicsPath.AddLine(array[3], array[0]);
			break;
		}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
