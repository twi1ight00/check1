using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class217 : Class160
{
	internal Class217(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num3 = num11 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num4 = num11 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num5 = num11 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
				num6 = width * Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f;
			}
			else
			{
				num3 = num11 * 0.25f;
				num4 = num11 * 0.25f;
				num5 = num11 * 0.25f;
				num6 = width * 0.64616f;
			}
		}
		else
		{
			num3 = num11 * 0.25f;
			num4 = num11 * 0.25f;
			num5 = num11 * 0.25f;
			num6 = width * 0.64616f;
		}
		num7 = num6;
		num8 = width - num5;
		num9 = height / 2f - num4;
		num10 = height / 2f - num3 / 2f;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[11];
		switch (class913_0.int_3)
		{
		case 1:
		case 2:
		{
			ref PointF reference12 = ref array[0];
			reference12 = new PointF(num + width - num7, num2);
			ref PointF reference13 = ref array[1];
			reference13 = new PointF(num + width, num2);
			ref PointF reference14 = ref array[2];
			reference14 = new PointF(num + width, num2 + height);
			ref PointF reference15 = ref array[3];
			reference15 = new PointF(num + width - num7, num2 + height);
			ref PointF reference16 = ref array[4];
			reference16 = new PointF(num + width - num7, num2 + height - num10);
			ref PointF reference17 = ref array[5];
			reference17 = new PointF(num + num5, num2 + height - num10);
			ref PointF reference18 = ref array[6];
			reference18 = new PointF(num + num5, num2 + height - num9);
			ref PointF reference19 = ref array[7];
			reference19 = new PointF(num, num2 + height / 2f);
			ref PointF reference20 = ref array[8];
			reference20 = new PointF(num + num5, num2 + num9);
			ref PointF reference21 = ref array[9];
			reference21 = new PointF(num + num5, num2 + num10);
			ref PointF reference22 = ref array[10];
			reference22 = new PointF(num + width - num7, num2 + num10);
			break;
		}
		case 3:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num, num2);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(num + num7, num2);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(num + num7, num2 + num10);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + num8, num2 + num10);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(num + num8, num2 + num9);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(num + width, num2 + height / 2f);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(num + num8, num2 + height - num9);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(num + num8, num2 + height - num10);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(num + num7, num2 + height - num10);
			ref PointF reference10 = ref array[9];
			reference10 = new PointF(num + num7, num2 + height);
			ref PointF reference11 = ref array[10];
			reference11 = new PointF(num, num2 + height);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
