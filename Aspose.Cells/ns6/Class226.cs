using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class226 : Class160
{
	internal Class226(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		float num3 = 0f;
		float num4 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = num4 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = num4 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num3 = num4 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			}
			else
			{
				num = num4 * 0.25f;
				num2 = num4 * 0.25f;
				num3 = num4 * 0.25f;
			}
		}
		else
		{
			num = num4 * 0.25f;
			num2 = num4 * 0.25f;
			num3 = num4 * 0.25f;
		}
		float num5 = width / 2f - num2;
		float num6 = num3;
		float num7 = num / 2f;
		float num8 = num2 - num / 2f;
		float num9 = width / 2f - num7;
		PointF[] points = new PointF[24]
		{
			new PointF(x + num5, y + num6),
			new PointF(x + width / 2f, y),
			new PointF(x + width - num5, y + num6),
			new PointF(x + width - num9, y + num6),
			new PointF(x + width - num9, y + height / 2f - num7),
			new PointF(x + width - num6, y + height / 2f - num7),
			new PointF(x + width - num6, y + height / 2f - num7 - num8),
			new PointF(x + width, y + height / 2f),
			new PointF(x + width - num6, y + height / 2f + num7 + num8),
			new PointF(x + width - num6, y + height / 2f + num7),
			new PointF(x + width - num9, y + height / 2f + num7),
			new PointF(x + width - num9, y + height - num6),
			new PointF(x + width - num5, y + height - num6),
			new PointF(x + width / 2f, y + height),
			new PointF(x + num5, y + height - num6),
			new PointF(x + num5 + num8, y + height - num6),
			new PointF(x + num5 + num8, y + height / 2f + num7),
			new PointF(x + num6, y + height / 2f + num7),
			new PointF(x + num6, y + height / 2f + num7 + num8),
			new PointF(x, y + height / 2f),
			new PointF(x + num6, y + height / 2f - num7 - num8),
			new PointF(x + num6, y + height / 2f - num7),
			new PointF(x + num5 + num8, y + height / 2f - num7),
			new PointF(x + num5 + num8, y + num6)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		return graphicsPath;
	}
}
