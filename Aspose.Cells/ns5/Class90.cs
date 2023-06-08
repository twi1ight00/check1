using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class90 : Class18
{
	internal Class90(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num4 = width * 0.29833335f;
			num5 = width * 0.40097222f;
			num6 = height * 0.28800926f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num5 = width * 0.40097222f;
				num6 = height * 0.28800926f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				num4 = width * 0.29833335f;
				num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = height * 0.28800926f;
			}
			else
			{
				num4 = width * 0.29833335f;
				num5 = width * 0.40097222f;
				num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			break;
		case 2:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
			{
				num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num6 = height * 0.28800926f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num5 = width * 0.40097222f;
				num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num4 = width * 0.29833335f;
				num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			break;
		case 3:
			num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			break;
		}
		num = width - num5 * 2f;
		num2 = num6;
		num3 = (width - num4 * 2f) / 2f;
		float num7 = width / 2f - num2;
		float num8 = num3;
		float num9 = num / 2f;
		float num10 = num2 - num / 2f;
		float num11 = width / 2f - num9;
		PointF[] array = new PointF[17];
		switch (class898_0.int_2)
		{
		case 2:
		case 3:
		{
			ref PointF reference18 = ref array[0];
			reference18 = new PointF(x + num7, y + height - num8);
			ref PointF reference19 = ref array[1];
			reference19 = new PointF(x + width / 2f, y + height);
			ref PointF reference20 = ref array[2];
			reference20 = new PointF(x + width - num7, y + height - num8);
			ref PointF reference21 = ref array[3];
			reference21 = new PointF(x + width - num11, y + height - num8);
			ref PointF reference22 = ref array[4];
			reference22 = new PointF(x + width - num11, y + num10 + num);
			ref PointF reference23 = ref array[5];
			reference23 = new PointF(x + width - num8, y + num10 + num);
			ref PointF reference24 = ref array[6];
			reference24 = new PointF(x + width - num8, y + 2f * num2);
			ref PointF reference25 = ref array[7];
			reference25 = new PointF(x + width, y + num2);
			ref PointF reference26 = ref array[8];
			reference26 = new PointF(x + width - num8, y);
			ref PointF reference27 = ref array[9];
			reference27 = new PointF(x + width - num8, y + num10);
			ref PointF reference28 = ref array[10];
			reference28 = new PointF(x + num8, y + num10);
			ref PointF reference29 = ref array[11];
			reference29 = new PointF(x + num8, y);
			ref PointF reference30 = ref array[12];
			reference30 = new PointF(x, y + num2);
			ref PointF reference31 = ref array[13];
			reference31 = new PointF(x + num8, y + 2f * num2);
			ref PointF reference32 = ref array[14];
			reference32 = new PointF(x + num8, y + 2f * num2 - num10);
			ref PointF reference33 = ref array[15];
			reference33 = new PointF(x + num11, y + 2f * num2 - num10);
			ref PointF reference34 = ref array[16];
			reference34 = new PointF(x + num11, y + height - num8);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + num7, y + num8);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + width / 2f, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + width - num7, y + num8);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + width - num11, y + num8);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + width - num11, y + height - num10 - 2f * num9);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + width - num8, y + height - num10 - 2f * num9);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(x + width - num8, y + height - 2f * num10 - 2f * num9);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(x + width, y + height - num10 - num9);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(x + width - num8, y + height);
			ref PointF reference10 = ref array[9];
			reference10 = new PointF(x + width - num8, y + height - num10);
			ref PointF reference11 = ref array[10];
			reference11 = new PointF(x + num8, y + height - num10);
			ref PointF reference12 = ref array[11];
			reference12 = new PointF(x + num8, y + height);
			ref PointF reference13 = ref array[12];
			reference13 = new PointF(x, y + height - num10 - num9);
			ref PointF reference14 = ref array[13];
			reference14 = new PointF(x + num8, y + height - 2f * num10 - 2f * num9);
			ref PointF reference15 = ref array[14];
			reference15 = new PointF(x + num8, y + height - num10 - 2f * num9);
			ref PointF reference16 = ref array[15];
			reference16 = new PointF(x + num11, y + height - num10 - 2f * num9);
			ref PointF reference17 = ref array[16];
			reference17 = new PointF(x + num11, y + num8);
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
