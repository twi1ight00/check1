using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class224 : Class160
{
	internal Class224(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		float num2 = Math.Min(width, height);
		num = ((class913_0.class901_0 == null) ? (num2 * 0.5f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (num2 * 0.5f) : (num2 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f))));
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[5];
		switch (class913_0.int_3)
		{
		case 1:
		case 2:
		{
			ref PointF reference6 = ref array[0];
			reference6 = new PointF(x, y);
			ref PointF reference7 = ref array[1];
			reference7 = new PointF(x + width - num, y);
			ref PointF reference8 = ref array[2];
			reference8 = new PointF(x + width, y + height / 2f);
			ref PointF reference9 = ref array[3];
			reference9 = new PointF(x + width - num, y + height);
			ref PointF reference10 = ref array[4];
			reference10 = new PointF(x, y + height);
			graphicsPath.AddPolygon(array);
			break;
		}
		case 3:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + width, y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x, y + height / 2f);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + num, y + height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + width, y + height);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[4]);
			graphicsPath.AddLine(array[4], array[0]);
			break;
		}
		}
		return graphicsPath;
	}
}
