using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class275 : Class160
{
	internal Class275(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[12];
		float num = 0f;
		num = ((class913_0.class901_0 == null) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24153f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24153f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (num <= 0f)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(0.135f * rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference2 = ref array[2];
			reference2 = new PointF(0.865f * rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			graphicsPath.AddLine(array[0], array[2]);
			graphicsPath.StartFigure();
			return graphicsPath;
		}
		ref PointF reference3 = ref array[0];
		reference3 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num) / 2f + float_4);
		ref PointF reference4 = ref array[5];
		reference4 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num) / 2f + float_4);
		ref PointF reference5 = ref array[6];
		reference5 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
		ref PointF reference6 = ref array[11];
		reference6 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
		graphicsPath.AddLine(array[0], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[11]);
		graphicsPath.AddLine(array[11], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
