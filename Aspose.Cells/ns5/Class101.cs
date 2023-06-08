using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class101 : Class18
{
	internal Class101(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		PointF[] array = new PointF[18];
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num5 = rectangleF_0.Height * 0.25462964f;
			num6 = rectangleF_0.Width * 5200f / 21600f;
			num7 = rectangleF_0.Height * 2630f / 21600f;
			num8 = rectangleF_0.Width * 8193f / 21600f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			}
			break;
		case 2:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			}
			break;
		case 3:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 329)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
				num8 = rectangleF_0.Width * 8193f / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * 5200f / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * 0.25462964f;
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[2]).method_0() == 330)
			{
				num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
				num7 = rectangleF_0.Height * 2630f / 21600f;
				num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			}
			break;
		case 4:
			num5 = rectangleF_0.Height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num6 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num7 = rectangleF_0.Height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			num8 = rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[3]).Value) / 21600f;
			break;
		}
		num = rectangleF_0.Width - num8 * 2f;
		num2 = rectangleF_0.Width / 2f - num6;
		num3 = num7;
		num4 = rectangleF_0.Height - num5 * 2f;
		ref PointF reference = ref array[0];
		reference = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(rectangleF_0.X + rectangleF_0.Width - num6, rectangleF_0.Y + num3);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f + num / 2f, rectangleF_0.Y + num3);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f + num / 2f, rectangleF_0.Y + num5);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + num5);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + num5 + num4);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f + num / 2f, rectangleF_0.Y + num5 + num4);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f + num / 2f, rectangleF_0.Y + num5 + num4 + num5 - num3);
		ref PointF reference9 = ref array[8];
		reference9 = new PointF(rectangleF_0.X + rectangleF_0.Width - num6, rectangleF_0.Y + num5 + num4 + num5 - num3);
		ref PointF reference10 = ref array[9];
		reference10 = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height);
		ref PointF reference11 = ref array[10];
		reference11 = new PointF(rectangleF_0.X + num6, rectangleF_0.Y + num5 + num4 + num5 - num3);
		ref PointF reference12 = ref array[11];
		reference12 = new PointF(rectangleF_0.X + num6 + num2 - num / 2f, rectangleF_0.Y + num5 + num4 + num5 - num3);
		ref PointF reference13 = ref array[12];
		reference13 = new PointF(rectangleF_0.X + num6 + num2 - num / 2f, rectangleF_0.Y + num5 + num4);
		ref PointF reference14 = ref array[13];
		reference14 = new PointF(rectangleF_0.X, rectangleF_0.Y + num5 + num4);
		ref PointF reference15 = ref array[14];
		reference15 = new PointF(rectangleF_0.X, rectangleF_0.Y + num5);
		ref PointF reference16 = ref array[15];
		reference16 = new PointF(rectangleF_0.X + num8, rectangleF_0.Y + num5);
		ref PointF reference17 = ref array[16];
		reference17 = new PointF(rectangleF_0.X + num8, rectangleF_0.Y + num3);
		ref PointF reference18 = ref array[17];
		reference18 = new PointF(rectangleF_0.X + num6, rectangleF_0.Y + num3);
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
