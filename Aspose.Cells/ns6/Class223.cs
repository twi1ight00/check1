using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class223 : Class160
{
	internal Class223(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		float num2 = 0f;
		float num3 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = ((!(height > width)) ? (num3 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)) : (num3 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / (100000f * width / height))));
				num2 = num3 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				num = ((!(height > width)) ? (num3 * 0.5f) : (num3 * (50000f / (100000f * width / height))));
				num2 = num3 * 0.5f;
			}
		}
		else
		{
			num = ((!(height > width)) ? (num3 * 0.5f) : (num3 * (50000f / (100000f * width / height))));
			num2 = num3 * 0.5f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num4 = (height - num) / 2f;
		float num5 = num / 2f / (num4 + num / 2f) * num2;
		PointF[] array = new PointF[8];
		switch (class913_0.int_3)
		{
		case 1:
		case 2:
		{
			ref PointF reference9 = ref array[0];
			reference9 = new PointF(x, y + num4);
			ref PointF reference10 = ref array[1];
			reference10 = new PointF(x + width - num2, y + num4);
			ref PointF reference11 = ref array[2];
			reference11 = new PointF(x + width - num2, y);
			ref PointF reference12 = ref array[3];
			reference12 = new PointF(x + width, y + height / 2f);
			ref PointF reference13 = ref array[4];
			reference13 = new PointF(x + width - num2, y + height);
			ref PointF reference14 = ref array[5];
			reference14 = new PointF(x + width - num2, y + height - num4);
			ref PointF reference15 = ref array[6];
			reference15 = new PointF(x, y + height - num4);
			ref PointF reference16 = ref array[7];
			reference16 = new PointF(x + num5, y + num4 + num / 2f);
			break;
		}
		case 3:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + width, y + num4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num2, y + num4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + num2, y);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x, y + height / 2f);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + num2, y + height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + num2, y + height - num4);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(x + width, y + height - num4);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(x + width - num5, y + num4 + num / 2f);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
