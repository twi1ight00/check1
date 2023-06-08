using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class246 : Class160
{
	internal Class246(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
		switch (class913_0.int_3)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class913_0.method_25().Width, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class913_0.method_25().Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
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
		float num7 = 0f;
		float num8 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
				num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
				num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
				num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
				num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
				num7 = Convert.ToSingle(class913_0.class901_0.arrayList_0[7]) / 100000f * class913_0.Width;
				num8 = Convert.ToSingle(class913_0.class901_0.arrayList_0[6]) / 100000f * class913_0.Height;
			}
			else
			{
				num = -0.08333f * class913_0.Width;
				num2 = 0.1875f * class913_0.Height;
				num3 = -0.16667f * class913_0.Width;
				num4 = 0.1875f * class913_0.Height;
				num5 = -0.16667f * class913_0.Width;
				num6 = 1f * class913_0.Height;
				num7 = -0.08333f * class913_0.Width;
				num8 = 1.12963f * class913_0.Height;
			}
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = 0.1875f * class913_0.Height;
			num3 = -0.16667f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 1f * class913_0.Height;
			num7 = -0.08333f * class913_0.Width;
			num8 = 1.12963f * class913_0.Height;
		}
		float num9 = ((!(num5 > ((num > num3) ? num3 : num))) ? num5 : ((num > num3) ? num3 : num));
		num9 = ((num7 > num9) ? num9 : num7);
		float num10 = ((!(num5 < ((num < num3) ? num3 : num))) ? num5 : ((num < num3) ? num3 : num));
		num10 = ((num7 < num10) ? num10 : num7);
		float num11 = ((!(num6 > ((num2 > num4) ? num4 : num2))) ? num6 : ((num2 > num4) ? num4 : num2));
		num11 = ((num8 > num11) ? num11 : num8);
		float num12 = ((!(num6 < ((num2 < num4) ? num4 : num2))) ? num6 : ((num2 < num4) ? num4 : num2));
		num12 = ((num8 < num12) ? num12 : num8);
		float num13 = 0f;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		if (num9 < 0f)
		{
			num13 = 0f - num9;
		}
		if (num10 > width)
		{
			num14 = num10 - width;
		}
		if (num12 > height)
		{
			num16 = num12 - height;
		}
		if (num11 < 0f)
		{
			num15 = 0f - num11;
		}
		if (class913_0.method_21())
		{
			num = 0f - num + width;
			num3 = 0f - num3 + width;
			num5 = 0f - num5 + width;
			num7 = 0f - num7 + width;
			num13 = num14;
		}
		if (class913_0.method_21())
		{
			num2 = 0f - num2 + height;
			num4 = 0f - num4 + height;
			num6 = 0f - num6 + height;
			num8 = 0f - num8 + height;
			num15 = num16;
		}
		RectangleF rect = new RectangleF(x + num13, y + num15, width, height);
		graphicsPath.AddRectangle(rect);
		graphicsPath.AddLine(x + num + num13, y + num2 + num15, x + num3 + num13, y + num4 + num15);
		graphicsPath.StartFigure();
		graphicsPath.AddLine(x + num3 + num13, y + num4 + num15, x + num5 + num13, y + num6 + num15);
		graphicsPath.StartFigure();
		graphicsPath.AddLine(x + num5 + num13, y + num6 + num15, x + num7 + num13, y + num8 + num15);
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.Width;
		float height = class913_0.Height;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
			num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
			num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
			num7 = Convert.ToSingle(class913_0.class901_0.arrayList_0[7]) / 100000f * class913_0.Width;
			num8 = Convert.ToSingle(class913_0.class901_0.arrayList_0[6]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = 0.1875f * class913_0.Height;
			num3 = -0.16667f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 1f * class913_0.Height;
			num7 = -0.08333f * class913_0.Width;
			num8 = 1.12963f * class913_0.Height;
		}
		float num9 = ((!(num5 > ((num > num3) ? num3 : num))) ? num5 : ((num > num3) ? num3 : num));
		num9 = ((num7 > num9) ? num9 : num7);
		float num10 = ((!(num5 < ((num < num3) ? num3 : num))) ? num5 : ((num < num3) ? num3 : num));
		num10 = ((num7 < num10) ? num10 : num7);
		float num11 = ((!(num6 > ((num2 > num4) ? num4 : num2))) ? num6 : ((num2 > num4) ? num4 : num2));
		num11 = ((num8 > num11) ? num11 : num8);
		float num12 = ((!(num6 < ((num2 < num4) ? num4 : num2))) ? num6 : ((num2 < num4) ? num4 : num2));
		num12 = ((num8 < num12) ? num12 : num8);
		float num13 = 0f;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		if (num9 < 0f)
		{
			num13 = 0f - num9;
		}
		if (num10 > width)
		{
			num14 = num10 - width;
		}
		if (num12 > height)
		{
			num16 = num12 - height;
		}
		if (num11 < 0f)
		{
			num15 = 0f - num11;
		}
		if (class913_0.method_21())
		{
			num = 0f - num + width;
			num3 = 0f - num3 + width;
			num5 = 0f - num5 + width;
			num7 = 0f - num7 + width;
			num13 = num14;
		}
		if (class913_0.method_21())
		{
			num2 = 0f - num2 + height;
			num4 = 0f - num4 + height;
			num6 = 0f - num6 + height;
			num8 = 0f - num8 + height;
			num15 = num16;
		}
		RectangleF rectangleF_ = new RectangleF(x + num13, y + num15, width, height);
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num17 = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num17;
			}
		}
		else
		{
			rectangleF_.X += num17;
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
