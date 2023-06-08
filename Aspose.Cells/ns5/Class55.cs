using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class55 : Class18
{
	internal Class55(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[12];
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		ref PointF reference = ref array[0];
		reference = new PointF(float_3, num + float_4);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(num + float_3, num + float_4);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(num + float_3, float_4);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(rectangleF_0.Width - num + float_3, float_4);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(rectangleF_0.Width - num + float_3, num + float_4);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(rectangleF_0.Width + float_3, num + float_4);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference9 = ref array[8];
		reference9 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
		ref PointF reference10 = ref array[9];
		reference10 = new PointF(num + float_3, rectangleF_0.Height + float_4);
		ref PointF reference11 = ref array[10];
		reference11 = new PointF(num + float_3, rectangleF_0.Height - num + float_4);
		ref PointF reference12 = ref array[11];
		reference12 = new PointF(float_3, rectangleF_0.Height - num + float_4);
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[8]);
		graphicsPath.AddLine(array[8], array[9]);
		graphicsPath.AddLine(array[9], array[10]);
		graphicsPath.AddLine(array[10], array[11]);
		graphicsPath.AddLine(array[11], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
