using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class92 : Class18
{
	internal Class92(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		float num2 = 0f;
		if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			num2 = width * (Convert.ToSingle(21600 - ((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num = height * Convert.ToSingle(10800 - ((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 10800f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num2 = width * (Convert.ToSingle(21600 - ((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = height * (7f / 15f);
			}
			else
			{
				num2 = width * (7f / 30f);
				num = height * Convert.ToSingle(10800 - ((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 10800f;
			}
		}
		else
		{
			num2 = width * (7f / 30f);
			num = height * (7f / 15f);
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num3 = (height - num) / 2f;
		float num4 = num / 2f / (num3 + num / 2f) * num2;
		PointF[] array = new PointF[8];
		switch (class898_0.int_2)
		{
		case 1:
		case 2:
		{
			ref PointF reference9 = ref array[0];
			reference9 = new PointF(x, y + num3);
			ref PointF reference10 = ref array[1];
			reference10 = new PointF(x + width - num2, y + num3);
			ref PointF reference11 = ref array[2];
			reference11 = new PointF(x + width - num2, y);
			ref PointF reference12 = ref array[3];
			reference12 = new PointF(x + width, y + height / 2f);
			ref PointF reference13 = ref array[4];
			reference13 = new PointF(x + width - num2, y + height);
			ref PointF reference14 = ref array[5];
			reference14 = new PointF(x + width - num2, y + height - num3);
			ref PointF reference15 = ref array[6];
			reference15 = new PointF(x, y + height - num3);
			ref PointF reference16 = ref array[7];
			reference16 = new PointF(x + num4, y + num3 + num / 2f);
			break;
		}
		case 3:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + width, y + num3);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num2, y + num3);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + num2, y);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x, y + height / 2f);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + num2, y + height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + num2, y + height - num3);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(x + width, y + height - num3);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(x + width - num4, y + num3 + num / 2f);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
