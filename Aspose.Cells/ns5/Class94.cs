using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class94 : Class18
{
	internal Class94(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		PointF[] array = new PointF[32];
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num2 = rectangleF_0.Height * 0.24851851f;
			num = rectangleF_0.Width * 5368f / 21600f;
			num4 = rectangleF_0.Height * 8048f / 21600f;
			num3 = rectangleF_0.Width * 8048f / 21600f;
			num6 = rectangleF_0.Height * 2716f / 21600f;
			num5 = rectangleF_0.Width * 2716f / 21600f;
			num8 = rectangleF_0.Height * 9468f / 21600f;
			num7 = rectangleF_0.Width * 9468f / 21600f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			break;
		case 2:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			break;
		case 3:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 329)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num8 = rectangleF_0.Height * 9468f / 21600f;
				num7 = rectangleF_0.Width * 9468f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * 8048f / 21600f;
				num3 = rectangleF_0.Width * 8048f / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * 0.24851851f;
				num = rectangleF_0.Width * 5368f / 21600f;
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num6 = rectangleF_0.Height * 2716f / 21600f;
				num5 = rectangleF_0.Width * 2716f / 21600f;
				num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			break;
		case 4:
			num2 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num = rectangleF_0.Width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num4 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num3 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num6 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			num5 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			num8 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[3]).Value) / 21600f;
			num7 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[3]).Value) / 21600f;
			break;
		}
		ref PointF reference = ref array[0];
		reference = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(rectangleF_0.X + num5, rectangleF_0.Y + num4);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(rectangleF_0.X + num5, rectangleF_0.Y + num8);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num * 2f) / 2f, rectangleF_0.Y + num8);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num * 2f) / 2f, rectangleF_0.Y + (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(rectangleF_0.X + num7, rectangleF_0.Y + (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(rectangleF_0.X + num7, rectangleF_0.Y + num6);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + num6);
		ref PointF reference9 = ref array[8];
		reference9 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y);
		ref PointF reference10 = ref array[9];
		reference10 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + num6);
		ref PointF reference11 = ref array[10];
		reference11 = new PointF(rectangleF_0.X + rectangleF_0.Width - num7, rectangleF_0.Y + num6);
		ref PointF reference12 = ref array[11];
		reference12 = new PointF(rectangleF_0.X + rectangleF_0.Width - num7, rectangleF_0.Y + (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference13 = ref array[12];
		reference13 = new PointF(rectangleF_0.X + (rectangleF_0.Width - (rectangleF_0.Width - num * 2f) / 2f), rectangleF_0.Y + (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference14 = ref array[13];
		reference14 = new PointF(rectangleF_0.X + (rectangleF_0.Width - (rectangleF_0.Width - num * 2f) / 2f), rectangleF_0.Y + num8);
		ref PointF reference15 = ref array[14];
		reference15 = new PointF(rectangleF_0.X + rectangleF_0.Width - num5, rectangleF_0.Y + num8);
		ref PointF reference16 = ref array[15];
		reference16 = new PointF(rectangleF_0.X + rectangleF_0.Width - num5, rectangleF_0.Y + num4);
		ref PointF reference17 = ref array[16];
		reference17 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f);
		ref PointF reference18 = ref array[17];
		reference18 = new PointF(rectangleF_0.X + rectangleF_0.Width - num5, rectangleF_0.Y + rectangleF_0.Height - num4);
		ref PointF reference19 = ref array[18];
		reference19 = new PointF(rectangleF_0.X + rectangleF_0.Width - num5, rectangleF_0.Y + rectangleF_0.Height - num8);
		ref PointF reference20 = ref array[19];
		reference20 = new PointF(rectangleF_0.X + rectangleF_0.Width - (rectangleF_0.Width - num * 2f) / 2f, rectangleF_0.Y + rectangleF_0.Height - num8);
		ref PointF reference21 = ref array[20];
		reference21 = new PointF(rectangleF_0.X + (rectangleF_0.Width - (rectangleF_0.Width - num * 2f) / 2f), rectangleF_0.Y + rectangleF_0.Height - (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference22 = ref array[21];
		reference22 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num7), rectangleF_0.Y + rectangleF_0.Height - (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference23 = ref array[22];
		reference23 = new PointF(rectangleF_0.X + rectangleF_0.Width - num7, rectangleF_0.Y + rectangleF_0.Height - num6);
		ref PointF reference24 = ref array[23];
		reference24 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + rectangleF_0.Height - num6);
		ref PointF reference25 = ref array[24];
		reference25 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height);
		ref PointF reference26 = ref array[25];
		reference26 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + rectangleF_0.Height - num6);
		ref PointF reference27 = ref array[26];
		reference27 = new PointF(rectangleF_0.X + num7, rectangleF_0.Y + rectangleF_0.Height - num6);
		ref PointF reference28 = ref array[27];
		reference28 = new PointF(rectangleF_0.X + num7, rectangleF_0.Y + rectangleF_0.Height - (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference29 = ref array[28];
		reference29 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num * 2f) / 2f, rectangleF_0.Height - (rectangleF_0.Height - num2 * 2f) / 2f);
		ref PointF reference30 = ref array[29];
		reference30 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num * 2f) / 2f, rectangleF_0.Y + rectangleF_0.Height - num8);
		ref PointF reference31 = ref array[30];
		reference31 = new PointF(rectangleF_0.X + num5, rectangleF_0.Y + rectangleF_0.Height - num8);
		ref PointF reference32 = ref array[31];
		reference32 = new PointF(rectangleF_0.X + num5, rectangleF_0.Y + rectangleF_0.Height - num4);
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
