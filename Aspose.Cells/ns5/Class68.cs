using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class68 : Class18
{
	internal Class68(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.3f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f)));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[8]
		{
			new PointF(num + float_3, float_4),
			new PointF(rectangleF_0.Width - num + float_3, float_4),
			new PointF(rectangleF_0.Width + float_3, num + float_4),
			new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height - num + float_4),
			new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4),
			new PointF(num + float_3, rectangleF_0.Height + float_4),
			new PointF(float_3, rectangleF_0.Height - num + float_4),
			new PointF(float_3, num + float_4)
		};
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
