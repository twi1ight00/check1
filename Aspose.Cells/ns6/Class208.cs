using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class208 : Class160
{
	internal Class208(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		float num4 = 0f;
		float num5 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = num5 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num3 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
				num4 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f;
			}
			else
			{
				num = num5 * 0.2383f;
				num2 = num5 * 0.25f;
				num3 = num5 * 0.25f;
				num4 = num5 * 0.4375f;
			}
		}
		else
		{
			num = num5 * 0.2383f;
			num2 = num5 * 0.25f;
			num3 = num5 * 0.25f;
			num4 = num5 * 0.4375f;
		}
		float num6 = num;
		float num7 = num4;
		float num8 = num3;
		float num9 = num2;
		float num10 = num7;
		float num11 = num7 - num6;
		float num12 = num9 - num6 / 2f;
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class913_0.int_3)
		{
		case 1:
			graphicsPath.AddArc(x, y + num12, 2f * num10, 2f * num10, 180f, 90f);
			graphicsPath.AddLine(x + num7, y + num12, x + (width - num8), y + num12);
			graphicsPath.AddLine(x + (width - num8), y + num12, x + (width - num8), y);
			graphicsPath.AddLine(x + (width - num8), y, x + width, y + num9);
			graphicsPath.AddLine(x + width, y + num9, x + (width - num8), y + 2f * num9);
			graphicsPath.AddLine(x + (width - num8), y + num9 + num6 / 2f, x + num7, y + 2f * num9 - num12);
			graphicsPath.AddArc(x + num6, y + num9 + num6 / 2f, 2f * num11, 2f * num11, 270f, -90f);
			graphicsPath.AddLine(x + num6, y + height, x, y + height);
			break;
		case 2:
			graphicsPath.AddArc(x, y + height - num12 - 2f * num10, 2f * num10, 2f * num10, 180f, -90f);
			graphicsPath.AddLine(x + num7, y + height - num12, x + (width - num8), y + height - num12);
			graphicsPath.AddLine(x + (width - num8), y + height - num12, x + (width - num8), y + height);
			graphicsPath.AddLine(x + (width - num8), y + height, x + width, y + height - num9);
			graphicsPath.AddLine(x + width, y + height - num9, x + (width - num8), y + height - 2f * num9);
			graphicsPath.AddLine(x + (width - num8), y + height - num - num12, x + num7, y + height - num - num12);
			graphicsPath.AddArc(x + num6, y + height - num - num12 - 2f * num11, 2f * num11, 2f * num11, 90f, 90f);
			graphicsPath.AddLine(x + num6, y, x, y);
			break;
		case 3:
			graphicsPath.AddArc(x + width - 2f * num10, y + height - num12 - 2f * num10, 2f * num10, 2f * num10, 0f, 90f);
			graphicsPath.AddLine(x + width - num7, y + height - num12, x + num8, y + height - num12);
			graphicsPath.AddLine(x + num8, y + height - num12, x + num8, y + height);
			graphicsPath.AddLine(x + num8, y + height, x, y + height - num9);
			graphicsPath.AddLine(x, y + height - num9, x + num8, y + height - 2f * num9);
			graphicsPath.AddLine(x + num8, y + height - num - num12, x + width - num7, y + height - num - num12);
			graphicsPath.AddArc(x + width - num6 - 2f * num11, y + height - num - num12 - 2f * num11, 2f * num11, 2f * num11, 90f, -90f);
			graphicsPath.AddLine(x + width - num6, y, x + width, y);
			break;
		case 4:
			graphicsPath.AddArc(x + width - 2f * num10, y + num12, 2f * num10, 2f * num10, 0f, -90f);
			graphicsPath.AddLine(x + width - num7, y + num12, x + num8, y + num12);
			graphicsPath.AddLine(x + num8, y + num12, x + num8, y);
			graphicsPath.AddLine(x + num8, y, x, y + num9);
			graphicsPath.AddLine(x, y + num9, x + num8, y + 2f * num9);
			graphicsPath.AddLine(x + num8, y + num + num12, x + width - num7, y + num + num12);
			graphicsPath.AddArc(x + width - num6 - 2f * num11, y + num + num12, 2f * num11, 2f * num11, 270f, 90f);
			graphicsPath.AddLine(x + width - num6, y + height, x + width, y + height);
			break;
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
