using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class185 : Class160
{
	internal Class185(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		ref PointF reference = ref array[0];
		reference = new PointF(float_3, float_4);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(rectangleF_0.Width + float_3, float_4);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(float_3, rectangleF_0.Height + float_4);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(num + float_3, num + float_4);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(rectangleF_0.Width - num + float_3, num + float_4);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(num + float_3, rectangleF_0.Height - num + float_4);
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[0]);
		graphicsPath.CloseFigure();
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[4]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
