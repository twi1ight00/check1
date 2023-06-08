using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class81 : Class18
{
	internal Class81(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		if (class898_0.class885_0.arrayList_0.Count == 3)
		{
			num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			num4 = width * 0.41351852f;
			num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num5 = width * 0.8565278f;
			num6 = height * 0.33185184f;
		}
		else
		{
			num4 = width * 0.41351852f;
			num5 = width * 0.8565278f;
			num6 = height * 0.33185184f;
		}
		num = width - num4 - 2f * (width - num5);
		num2 = width - num5 + num / 2f;
		num3 = num6;
		GraphicsPath graphicsPath = new GraphicsPath();
		float num7 = num2 - num / 2f;
		PointF[] array = new PointF[9];
		switch (class898_0.int_2)
		{
		case 1:
		{
			ref PointF reference28 = ref array[0];
			reference28 = new PointF(x + (width - 2f * num2), y + num3);
			ref PointF reference29 = ref array[1];
			reference29 = new PointF(x + (width - num2), y);
			ref PointF reference30 = ref array[2];
			reference30 = new PointF(x + width, y + num3);
			ref PointF reference31 = ref array[3];
			reference31 = new PointF(x + (width - num7), y + num3);
			ref PointF reference32 = ref array[4];
			reference32 = new PointF(x + (width - num7), y + height);
			ref PointF reference33 = ref array[5];
			reference33 = new PointF(x, y + height);
			ref PointF reference34 = ref array[6];
			reference34 = new PointF(x, y + (height - num));
			ref PointF reference35 = ref array[7];
			reference35 = new PointF(x + (width - num - num7), y + (height - num));
			ref PointF reference36 = ref array[8];
			reference36 = new PointF(x + (width - num - num7), y + num3);
			break;
		}
		case 2:
		{
			ref PointF reference19 = ref array[0];
			reference19 = new PointF(x + (width - 2f * num2), y + height - num3);
			ref PointF reference20 = ref array[1];
			reference20 = new PointF(x + (width - num2), y + height);
			ref PointF reference21 = ref array[2];
			reference21 = new PointF(x + width, y + height - num3);
			ref PointF reference22 = ref array[3];
			reference22 = new PointF(x + (width - num7), y + height - num3);
			ref PointF reference23 = ref array[4];
			reference23 = new PointF(x + (width - num7), y);
			ref PointF reference24 = ref array[5];
			reference24 = new PointF(x, y);
			ref PointF reference25 = ref array[6];
			reference25 = new PointF(x, y + num);
			ref PointF reference26 = ref array[7];
			reference26 = new PointF(x + (width - num - num7), y + num);
			ref PointF reference27 = ref array[8];
			reference27 = new PointF(x + (width - num - num7), y + height - num3);
			break;
		}
		case 3:
		{
			ref PointF reference10 = ref array[0];
			reference10 = new PointF(x + 2f * num2, y + height - num3);
			ref PointF reference11 = ref array[1];
			reference11 = new PointF(x + num2, y + height);
			ref PointF reference12 = ref array[2];
			reference12 = new PointF(x, y + height - num3);
			ref PointF reference13 = ref array[3];
			reference13 = new PointF(x + num7, y + height - num3);
			ref PointF reference14 = ref array[4];
			reference14 = new PointF(x + num7, y);
			ref PointF reference15 = ref array[5];
			reference15 = new PointF(x + width, y);
			ref PointF reference16 = ref array[6];
			reference16 = new PointF(x + width, y + num);
			ref PointF reference17 = ref array[7];
			reference17 = new PointF(x + num + num7, y + num);
			ref PointF reference18 = ref array[8];
			reference18 = new PointF(x + num + num7, y + height - num3);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + 2f * num2, y + num3);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num2, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x, y + num3);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + num7, y + num3);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + num7, y + height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + width, y + height);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(x + width, y + height - num);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(x + num + num7, y + height - num);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(x + num + num7, y + num3);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
