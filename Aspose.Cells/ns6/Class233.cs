using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class233 : Class160
{
	internal Class233(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		float num5 = 0f;
		float num6 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = num6 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = num6 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num3 = num6 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
				num4 = num6 * Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f;
				num5 = ((!(height > width)) ? (num6 * Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f) : (num6 * Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / (100000f * width / height)));
			}
			else
			{
				num = num6 * 0.25f;
				num2 = num6 * 0.25f;
				num3 = num6 * 0.25f;
				num4 = num6 * 0.42665f;
				num5 = ((!(height > width)) ? (num6 * 0.75f) : (num6 * (75000f / (100000f * (width / height)))));
			}
		}
		else
		{
			num = num6 * 0.25f;
			num2 = num6 * 0.25f;
			num3 = num6 * 0.25f;
			num4 = num6 * 0.42665f;
			num5 = ((!(height > width)) ? (num6 * 0.75f) : (num6 * (75000f / (100000f * (width / height)))));
		}
		if (num2 == 0f)
		{
			num = class913_0.Line.Weight / 4f;
			num3 = 0f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num7 = num2 - num / 2f;
		float num8 = x + (width - num4 - num7);
		float num9 = num4 - num;
		if (num5 == 0f)
		{
			num9 = 0f;
		}
		switch (class913_0.int_3)
		{
		case 1:
			if (num4 > 0f && num9 > 0f)
			{
				graphicsPath.AddArc(x, y, num4 * 2f, num4 * 2f, 180f, 90f);
				graphicsPath.AddLine(x + num4, y, num8, y);
				graphicsPath.AddArc(num8 - num4, y, 2f * num4, 2f * num4, 270f, 90f);
				graphicsPath.AddLine(x + (width - num7), y + num4, x + (width - num7), y + (num5 - num3));
				graphicsPath.AddLine(x + (width - num7), y + (num5 - num3), x + width, y + (num5 - num3));
				graphicsPath.AddLine(x + width, y + (num5 - num3), x + (width - num2), y + num5);
				graphicsPath.AddLine(x + (width - num2), y + num5, x + width - 2f * num2, y + (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2, y + (num5 - num3), x + (width - 2f * num2) + num7, y + (num5 - num3));
				graphicsPath.AddLine(x + (width - 2f * num2) + num7, y + (num5 - num3), x + (width - 2f * num2) + num7, y + (num + num9));
				graphicsPath.AddArc(num8 - num9, y + num, 2f * num9, 2f * num9, 0f, -90f);
				graphicsPath.AddArc(x + num, y + num, 2f * num9, 2f * num9, 270f, -90f);
				graphicsPath.AddLine(x + num, y + num4, x + num, y + height);
				graphicsPath.AddLine(x + num, y + height, x, y + height);
				graphicsPath.AddLine(x, y + height, x, y + num4);
			}
			else if (num4 == 0f)
			{
				graphicsPath.AddLine(x, y, x + width - num7, y);
				graphicsPath.AddLine(x + width - num7, y, x + width - num7, y + num5 - num3);
				graphicsPath.AddLine(x + width - num7, y + num5 - num3, x + width, y + num5 - num3);
				graphicsPath.AddLine(x + width, y + num5 - num3, x + width - (num / 2f + num7), y + num5);
				graphicsPath.AddLine(x + width - (num / 2f + num7), y + num5, x + width - 2f * num2, y + num5 - num3);
				graphicsPath.AddLine(x + width - 2f * num2, y + num5 - num3, x + width - 2f * num2 + num7, y + num5 - num3);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + num5 - num3, x + width - 2f * num2 + num7, y + num);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + num, x + num, y + num);
				graphicsPath.AddLine(x + num, y + num, x + num, y + height);
				graphicsPath.AddLine(x + num, y + height, x, y + height);
				graphicsPath.AddLine(x, y + height, x, y);
			}
			else if (num4 > 0f && num9 <= 0f)
			{
				graphicsPath.AddArc(x, y, num4 * 2f, num4 * 2f, 180f, 90f);
				graphicsPath.AddLine(x + num4, y, num8, y);
				graphicsPath.AddArc(num8 - num4, y, 2f * num4, 2f * num4, 270f, 90f);
				graphicsPath.AddLine(x + (width - num7), y + num4, x + (width - num7), y + (num5 - num3));
				graphicsPath.AddLine(x + (width - num7), y + (num5 - num3), x + width, y + (num5 - num3));
				graphicsPath.AddLine(x + width, y + (num5 - num3), x + (width - num2), y + num5);
				graphicsPath.AddLine(x + (width - num2), y + num5, x + width - 2f * num2, y + (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2, y + (num5 - num3), x + (width - 2f * num2) + num7, y + (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + (num5 - num3), x + width - 2f * num2 + num7, y + num);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + num, x + num, y + num);
				graphicsPath.AddLine(x + num, y + num, x + num, y + height);
				graphicsPath.AddLine(x + num, y + height, x, y + height);
				graphicsPath.AddLine(x, y + height, x, y + num4);
			}
			break;
		case 2:
			if (num4 > 0f && num9 > 0f)
			{
				graphicsPath.AddArc(x, y + height - 2f * num4, num4 * 2f, num4 * 2f, 180f, -90f);
				graphicsPath.AddLine(x + num4, y + height, num8, y + height);
				graphicsPath.AddArc(num8 - num4, y + height - 2f * num4, 2f * num4, 2f * num4, 90f, -90f);
				graphicsPath.AddLine(x + (width - num7), y + height - num4, x + (width - num7), y + height - (num5 - num3));
				graphicsPath.AddLine(x + (width - num7), y + height - (num5 - num3), x + width, y + height - (num5 - num3));
				graphicsPath.AddLine(x + width, y + height - (num5 - num3), x + (width - num2), y + height - num5);
				graphicsPath.AddLine(x + (width - num2), y + height - num5, x + width - 2f * num2, y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2, y + height - (num5 - num3), x + (width - 2f * num2) + num7, y + height - (num5 - num3));
				graphicsPath.AddLine(x + (width - 2f * num2) + num7, y + height - (num5 - num3), x + (width - 2f * num2) + num7, y + height - (num + num9));
				graphicsPath.AddArc(num8 - num9, y + height - num - 2f * num9, 2f * num9, 2f * num9, 0f, 90f);
				graphicsPath.AddArc(x + num, y + height - num - 2f * num9, 2f * num9, 2f * num9, 90f, 90f);
				graphicsPath.AddLine(x + num, y + height - num4, x + num, y);
				graphicsPath.AddLine(x + num, y, x, y);
				graphicsPath.AddLine(x, y, x, y + height - num4);
			}
			else if (num4 == 0f)
			{
				graphicsPath.AddLine(x, y + height, x + width - num7, y + height);
				graphicsPath.AddLine(x + width - num7, y + height, x + width - num7, y + height - num5 + num3);
				graphicsPath.AddLine(x + width - num7, y + height - num5 + num3, x + width, y + height - num5 + num3);
				graphicsPath.AddLine(x + width, y + height - num5 + num3, x + width - (num / 2f + num7), y + height - num5);
				graphicsPath.AddLine(x + width - (num / 2f + num7), y + height - num5, x + width - 2f * num2, y + height - num5 + num3);
				graphicsPath.AddLine(x + width - 2f * num2, y + height - num5 + num3, x + width - 2f * num2 + num7, y + height - num5 + num3);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + height - num5 + num3, x + width - 2f * num2 + num7, y + height - num);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + height - num, x + num, y + height - num);
				graphicsPath.AddLine(x + num, y + height - num, x + num, y);
				graphicsPath.AddLine(x + num, y, x, y);
				graphicsPath.AddLine(x, y, x, y + height);
			}
			else if (num4 > 0f && num9 <= 0f)
			{
				graphicsPath.AddArc(x, y + height - 2f * num4, num4 * 2f, num4 * 2f, 180f, -90f);
				graphicsPath.AddLine(x + num4, y + height, num8, y + height);
				graphicsPath.AddArc(num8 - num4, y + height - 2f * num4, 2f * num4, 2f * num4, 90f, -90f);
				graphicsPath.AddLine(x + (width - num7), y + height - num4, x + (width - num7), y + height - (num5 - num3));
				graphicsPath.AddLine(x + (width - num7), y + height - (num5 - num3), x + width, y + height - (num5 - num3));
				graphicsPath.AddLine(x + width, y + height - (num5 - num3), x + (width - num2), y + height - num5);
				graphicsPath.AddLine(x + (width - num2), y + height - num5, x + width - 2f * num2, y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2, y + height - (num5 - num3), x + (width - 2f * num2) + num7, y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + height - (num5 - num3), x + width - 2f * num2 + num7, y + height - num);
				graphicsPath.AddLine(x + width - 2f * num2 + num7, y + height - num, x + num, y + height - num);
				graphicsPath.AddLine(x + num, y + height - num, x + num, y);
				graphicsPath.AddLine(x + num, y, x, y);
				graphicsPath.AddLine(x, y, x, y + height - num4);
			}
			break;
		case 3:
			if (num4 > 0f && num9 > 0f)
			{
				graphicsPath.AddArc(x + width - 2f * num4, y + height - 2f * num4, num4 * 2f, num4 * 2f, 0f, 90f);
				graphicsPath.AddLine(x + width - num4, y + height, x + width - num8, y + height);
				graphicsPath.AddArc(x + num7, y + height - 2f * num4, 2f * num4, 2f * num4, 90f, 90f);
				graphicsPath.AddLine(x + width - (width - num7), y + height - num4, x + width - (width - num7), y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - (width - num7), y + height - (num5 - num3), x, y + height - (num5 - num3));
				graphicsPath.AddLine(x, y + height - (num5 - num3), x + width - (width - num2), y + height - num5);
				graphicsPath.AddLine(x + width - (width - num2), y + height - num5, x + width - (width - 2f * num2), y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - (width - 2f * num2), y + height - (num5 - num3), x + width - (width - 2f * num2 + num7), y + height - (num5 - num3));
				graphicsPath.AddLine(x + width - (width - 2f * num2 + num7), y + height - (num5 - num3), x + width - (width - 2f * num2 + num7), y + height - (num + num9));
				graphicsPath.AddArc(x + num + num7, y + height - num - 2f * num9, 2f * num9, 2f * num9, 180f, -90f);
				graphicsPath.AddArc(x + width - num - 2f * (num4 - num), y + height - num - 2f * num9, 2f * num9, 2f * num9, 90f, -90f);
				graphicsPath.AddLine(x + width - num, y + height - num4, x + width - num, y);
				graphicsPath.AddLine(x + width - num, y, x + width, y);
				graphicsPath.AddLine(x + width, y, x + width, y + height - num4);
			}
			else if (num4 == 0f)
			{
				graphicsPath.AddLine(x + width, y + height, x + num7, y + height);
				graphicsPath.AddLine(x + num7, y + height, x + num7, y + height - num5 + num3);
				graphicsPath.AddLine(x + num7, y + height - num5 + num3, x, y + height - num5 + num3);
				graphicsPath.AddLine(x, y + height - num5 + num3, x + (num / 2f + num7), y + height - num5);
				graphicsPath.AddLine(x + (num / 2f + num7), y + height - num5, x + 2f * num2, y + height - num5 + num3);
				graphicsPath.AddLine(x + 2f * num2, y + height - num5 + num3, x + 2f * num2 - num7, y + height - num5 + num3);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + height - num5 + num3, x + 2f * num2 - num7, y + height - num);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + height - num, x + width - num, y + height - num);
				graphicsPath.AddLine(x + width - num, y + height - num, x + width - num, y);
				graphicsPath.AddLine(x + width - num, y, x + width, y);
				graphicsPath.AddLine(x + width, y, x + width, y + height);
			}
			else if (num4 > 0f && num9 <= 0f)
			{
				graphicsPath.AddArc(x + width - 2f * num4, y + height - 2f * num4, num4 * 2f, num4 * 2f, 0f, 90f);
				graphicsPath.AddLine(x + width - num4, y + height, x + num7 + num4, y + height);
				graphicsPath.AddArc(x + num7, y + height - 2f * num4, 2f * num4, 2f * num4, 90f, 90f);
				graphicsPath.AddLine(x + num7, y + height - num4, x + num7, y + height - (num5 - num3));
				graphicsPath.AddLine(x + num7, y + height - (num5 - num3), x, y + height - (num5 - num3));
				graphicsPath.AddLine(x, y + height - (num5 - num3), x + num2, y + height - num5);
				graphicsPath.AddLine(x + num2, y + height - num5, x + 2f * num2, y + height - (num5 - num3));
				graphicsPath.AddLine(x + 2f * num2, y + height - (num5 - num3), x + 2f * num2 - num7, y + height - (num5 - num3));
				graphicsPath.AddLine(x + 2f * num2 - num7, y + height - (num5 - num3), x + 2f * num2 - num7, y + height - num);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + height - num, x + width - num, y + height - num);
				graphicsPath.AddLine(x + width - num, y + height - num, x + width - num, y);
				graphicsPath.AddLine(x + width - num, y, x + width, y);
				graphicsPath.AddLine(x + width, y, x + width, y + height - num4);
			}
			break;
		case 4:
			if (num4 > 0f && num9 > 0f)
			{
				graphicsPath.AddArc(x + width - 2f * num4, y, num4 * 2f, num4 * 2f, 0f, -90f);
				graphicsPath.AddLine(x + width - num4, y, x + width - num8, y);
				graphicsPath.AddArc(x + num7, y, 2f * num4, 2f * num4, 270f, -90f);
				graphicsPath.AddLine(x + width - (width - num7), y + num4, x + width - (width - num7), y + (num5 - num3));
				graphicsPath.AddLine(x + width - (width - num7), y + (num5 - num3), x, y + (num5 - num3));
				graphicsPath.AddLine(x, y + (num5 - num3), x + width - (width - num2), y + num5);
				graphicsPath.AddLine(x + width - (width - num2), y + num5, x + width - (width - 2f * num2), y + (num5 - num3));
				graphicsPath.AddLine(x + width - (width - 2f * num2), y + (num5 - num3), x + width - (width - 2f * num2 + num7), y + (num5 - num3));
				graphicsPath.AddLine(x + width - (width - 2f * num2 + num7), y + (num5 - num3), x + width - (width - 2f * num2 + num7), y + (num + num9));
				graphicsPath.AddArc(x + num + num7, y + num, 2f * num9, 2f * num9, 180f, 90f);
				graphicsPath.AddArc(x + width - num - 2f * num9, y + num, 2f * num9, 2f * num9, 270f, 90f);
				graphicsPath.AddLine(x + width - num, y + num4, x + width - num, y + height);
				graphicsPath.AddLine(x + width - num, y + height, x + width, y + height);
				graphicsPath.AddLine(x + width, y + height, x + width, y + num4);
			}
			else if (num4 == 0f)
			{
				graphicsPath.AddLine(x + width, y, x + num7, y);
				graphicsPath.AddLine(x + num7, y, x + num7, y + num5 - num3);
				graphicsPath.AddLine(x + num7, y + num5 - num3, x, y + num5 - num3);
				graphicsPath.AddLine(x, y + num5 - num3, x + (num / 2f + num7), y + num5);
				graphicsPath.AddLine(x + (num / 2f + num7), y + num5, x + 2f * num2, y + num5 - num3);
				graphicsPath.AddLine(x + 2f * num2, y + num5 - num3, x + 2f * num2 - num7, y + num5 - num3);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + num5 - num3, x + 2f * num2 - num7, y + num);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + num, x + width - num, y + num);
				graphicsPath.AddLine(x + width - num, y + num, x + width - num, y + height);
				graphicsPath.AddLine(x + width - num, y + height, x + width, y + height);
				graphicsPath.AddLine(x + width, y + height, x + width, y);
			}
			else if (num4 > 0f && num9 <= 0f)
			{
				graphicsPath.AddArc(x + width - 2f * num4, y, num4 * 2f, num4 * 2f, 0f, -90f);
				graphicsPath.AddLine(x + width - num4, y, x + num7 + num4, y);
				graphicsPath.AddArc(x + num7, y, 2f * num4, 2f * num4, 270f, -90f);
				graphicsPath.AddLine(x + num7, y + num4, x + num7, y + (num5 - num3));
				graphicsPath.AddLine(x + num7, y + (num5 - num3), x, y + (num5 - num3));
				graphicsPath.AddLine(x, y + (num5 - num3), x + num2, y + num5);
				graphicsPath.AddLine(x + num2, y + num5, x + 2f * num2, y + (num5 - num3));
				graphicsPath.AddLine(x + 2f * num2, y + (num5 - num3), x + 2f * num2 - num7, y + (num5 - num3));
				graphicsPath.AddLine(x + 2f * num2 - num7, y + (num5 - num3), x + 2f * num2 - num7, y + num);
				graphicsPath.AddLine(x + 2f * num2 - num7, y + num, x + width - num, y + num);
				graphicsPath.AddLine(x + width - num, y + num, x + width - num, y + height);
				graphicsPath.AddLine(x + width - num, y + height, x + width, y + height);
				graphicsPath.AddLine(x + width, y + height, x + width, y + num4);
			}
			break;
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
