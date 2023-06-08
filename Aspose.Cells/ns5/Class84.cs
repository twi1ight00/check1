using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class84 : Class18
{
	internal Class84(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		float num14 = 0f;
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num11 = height * 14294f / 21600f;
			num12 = width * 5233f / 21600f;
			num13 = height * 18106f / 21600f;
			num14 = width * 7905f / 21600f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * 5233f / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * 5233f / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 330)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * 5233f / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			break;
		case 2:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * 5233f / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * 5233f / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * 5233f / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			break;
		case 3:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 329)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num14 = width * 7905f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num13 = height * 18106f / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num12 = width * 5233f / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num11 = height * 14294f / 21600f;
				num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			break;
		case 4:
			num11 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num12 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num13 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			num14 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[3]).Value) / 21600f;
			break;
		}
		num3 = width - 2f * num14;
		num4 = width / 2f - num12;
		num5 = height - num13;
		num6 = num11;
		num9 = num6;
		num10 = height - num5;
		num7 = width / 2f - num4;
		num8 = width / 2f - num3 / 2f;
		PointF[] array = new PointF[11];
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class898_0.int_2)
		{
		case 2:
		case 3:
		{
			ref PointF reference12 = ref array[0];
			reference12 = new PointF(num, num2 + height - num9);
			ref PointF reference13 = ref array[1];
			reference13 = new PointF(num + num8, num2 + height - num9);
			ref PointF reference14 = ref array[2];
			reference14 = new PointF(num + num8, num2 + num5);
			ref PointF reference15 = ref array[3];
			reference15 = new PointF(num + num7, num2 + num5);
			ref PointF reference16 = ref array[4];
			reference16 = new PointF(num + width / 2f, num2);
			ref PointF reference17 = ref array[5];
			reference17 = new PointF(num + width - num7, num2 + num5);
			ref PointF reference18 = ref array[6];
			reference18 = new PointF(num + width - num8, num2 + num5);
			ref PointF reference19 = ref array[7];
			reference19 = new PointF(num + width - num8, num2 + height - num9);
			ref PointF reference20 = ref array[8];
			reference20 = new PointF(num + width, num2 + height - num9);
			ref PointF reference21 = ref array[9];
			reference21 = new PointF(num + width, num2 + height);
			ref PointF reference22 = ref array[10];
			reference22 = new PointF(num, num2 + height);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num, num2);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(num, num2 + num9);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(num + num8, num2 + num9);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + num8, num2 + num10);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(num + num7, num2 + num10);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(num + width / 2f, num2 + height);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(num + width - num7, num2 + num10);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(num + width - num8, num2 + num10);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(num + width - num8, num2 + num9);
			ref PointF reference10 = ref array[9];
			reference10 = new PointF(num + width, num2 + num9);
			ref PointF reference11 = ref array[10];
			reference11 = new PointF(num + width, num2);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
