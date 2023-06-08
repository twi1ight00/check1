using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class78 : Class18
{
	internal Class78(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] array = new PointF[4];
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (rectangleF_0.Width * 0.2549537f) : (rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f)));
		switch (class898_0.int_2)
		{
		case 2:
		case 3:
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(x + num, y);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(x + width - num, y);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(x + width, y + height);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(x, y + height);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x, y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + width, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + width - num, y + height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + num, y + height);
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
