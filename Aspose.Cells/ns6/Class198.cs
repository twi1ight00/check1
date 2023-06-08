using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class198 : Class160
{
	internal Class198(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[8];
		float num = 0f;
		num = ((class913_0.class901_0 == null) ? (rectangleF_0.Height * 0.13f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (rectangleF_0.Height * 0.13f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		float num2 = num * 2f;
		SizeF size = new SizeF(num2, num2);
		rectangleF_0.X = 0f - num + float_3;
		rectangleF_0.Y = 0f - num + float_4;
		RectangleF rect = new RectangleF(rectangleF_0.Location, size);
		ref PointF reference = ref array[0];
		reference = new PointF(num + float_3, float_4);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(rectangleF_0.Width - num + float_3, float_4);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(rectangleF_0.Width + float_3, num + float_4);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(num + float_3, rectangleF_0.Height + float_4);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(float_3, num + float_4);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddArc(rect, 90f, -90f);
		graphicsPath.AddLine(array[0], array[1]);
		rect.X = rectangleF_0.Right;
		graphicsPath.AddArc(rect, 180f, -90f);
		graphicsPath.AddLine(array[2], array[3]);
		rect.Y = rectangleF_0.Bottom;
		graphicsPath.AddArc(rect, 270f, -90f);
		graphicsPath.AddLine(array[4], array[5]);
		rect.X = rectangleF_0.Left;
		graphicsPath.AddArc(rect, 360f, -90f);
		graphicsPath.AddLine(array[6], array[7]);
		return graphicsPath;
	}
}
