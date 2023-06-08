using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class112 : Class18
{
	internal Class112(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		_ = rectangleF_0.X;
		_ = rectangleF_0.Y;
		_ = rectangleF_0.Width;
		_ = rectangleF_0.Height;
		PointF[] array = new PointF[4];
		float num = 0.21f * Math.Min(rectangleF_0.Width, rectangleF_0.Height);
		switch (class898_0.int_2)
		{
		case 1:
		case 3:
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(num + float_3, float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 2:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width - num + float_3, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + float_3, rectangleF_0.Height + float_4);
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
