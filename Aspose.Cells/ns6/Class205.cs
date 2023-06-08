using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class205 : Class160
{
	internal Class205(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = ((class913_0.class901_0 == null) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.25f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.25f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f))));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[4];
		if (class913_0.int_3 == 1 || class913_0.int_3 == 4)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num + float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width - num + float_3, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[0]);
		}
		if (class913_0.int_3 == 2 || class913_0.int_3 == 3)
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(float_3, float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(num + float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[0]);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
