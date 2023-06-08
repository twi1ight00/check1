using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class95 : Class18
{
	internal Class95(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
			num4 = width * 0.30203703f;
			num5 = width * 0.40814814f;
			num6 = height * 0.20166667f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num4 = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num5 = width * 0.40097222f;
				num6 = height * 0.20166667f;
			}
			else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
			{
				num4 = width * 0.29833335f;
				num5 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
				num6 = height * 0.20166667f;
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
				num6 = height * 0.20166667f;
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
		num2 = (width - num4 * 2f) / 2f;
		num3 = num6;
		float num7 = width / 2f - num2;
		float num8 = num3;
		float num9 = num / 2f;
		float num10 = num2 - num / 2f;
		float num11 = width / 2f - num9;
		PointF[] points = new PointF[24]
		{
			new PointF(x + num7, y + num8),
			new PointF(x + width / 2f, y),
			new PointF(x + width - num7, y + num8),
			new PointF(x + width - num11, y + num8),
			new PointF(x + width - num11, y + height / 2f - num9),
			new PointF(x + width - num8, y + height / 2f - num9),
			new PointF(x + width - num8, y + height / 2f - num9 - num10),
			new PointF(x + width, y + height / 2f),
			new PointF(x + width - num8, y + height / 2f + num9 + num10),
			new PointF(x + width - num8, y + height / 2f + num9),
			new PointF(x + width - num11, y + height / 2f + num9),
			new PointF(x + width - num11, y + height - num8),
			new PointF(x + width - num7, y + height - num8),
			new PointF(x + width / 2f, y + height),
			new PointF(x + num7, y + height - num8),
			new PointF(x + num7 + num10, y + height - num8),
			new PointF(x + num7 + num10, y + height / 2f + num9),
			new PointF(x + num8, y + height / 2f + num9),
			new PointF(x + num8, y + height / 2f + num9 + num10),
			new PointF(x, y + height / 2f),
			new PointF(x + num8, y + height / 2f - num9 - num10),
			new PointF(x + num8, y + height / 2f - num9),
			new PointF(x + num7 + num10, y + height / 2f - num9),
			new PointF(x + num7 + num10, y + num8)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		return graphicsPath;
	}
}
