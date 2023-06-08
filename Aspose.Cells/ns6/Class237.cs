using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class237 : Class160
{
	internal Class237(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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

	internal override void vmethod_3()
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.Width;
		float height = class913_0.Height;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
				num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
				num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
			}
			else
			{
				num = -0.08333f * class913_0.Width;
				num2 = -0.38333f * class913_0.Width;
				num3 = 0.1875f * class913_0.Height;
				num4 = 1.125f * class913_0.Height;
			}
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = -0.38333f * class913_0.Width;
			num3 = 0.1875f * class913_0.Height;
			num4 = 1.125f * class913_0.Height;
		}
		float num5 = ((num > num2) ? num2 : num);
		float num6 = ((num < num2) ? num2 : num);
		float num7 = ((num3 > num4) ? num4 : num3);
		float num8 = ((num3 < num4) ? num4 : num3);
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		if (num5 < 0f)
		{
			num9 = 0f - num5;
		}
		if (num6 > width)
		{
			num10 = num6 - width;
		}
		if (num8 > height)
		{
			num12 = num8 - height;
		}
		if (num7 < 0f)
		{
			num11 = 0f - num7;
		}
		if (class913_0.method_23())
		{
			num = 0f - num + width;
			num2 = 0f - num2 + width;
			num9 = num10;
		}
		if (class913_0.method_21())
		{
			num3 = 0f - num3 + height;
			num4 = 0f - num4 + height;
			num11 = num12;
		}
		RectangleF rect = new RectangleF(x + num9, y + num11, width, height);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath2);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (!class913_0.Fill.method_0())
		{
			graphicsPath.AddRectangle(rect);
			interface42_0.imethod_33(brush_, graphicsPath);
		}
		interface42_0.imethod_16(pen_, x + num + num9, y + num3 + num11, x + num2 + num9, y + num4 + num11);
		interface42_0.imethod_16(pen_, x + num + num9, y + num11, x + num + num9, y + height + num11);
		vmethod_4();
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
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = -0.38333f * class913_0.Width;
			num3 = 0.1875f * class913_0.Height;
			num4 = 1.125f * class913_0.Height;
		}
		float num5 = ((num > num2) ? num2 : num);
		float num6 = ((num < num2) ? num2 : num);
		float num7 = ((num3 > num4) ? num4 : num3);
		float num8 = ((num3 < num4) ? num4 : num3);
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		if (num5 < 0f)
		{
			num9 = 0f - num5;
		}
		if (num6 > width)
		{
			num10 = num6 - width;
		}
		if (num8 > height)
		{
			num12 = num8 - height;
		}
		if (num7 < 0f)
		{
			num11 = 0f - num7;
		}
		if (class913_0.method_23())
		{
			num = 0f - num + width;
			num2 = 0f - num2 + width;
			num9 = num10;
		}
		if (class913_0.method_21())
		{
			num3 = 0f - num3 + height;
			num4 = 0f - num4 + height;
			num11 = num12;
		}
		RectangleF rectangleF_ = new RectangleF(x + num9, y + num11, width, height);
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num13 = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num13;
			}
		}
		else
		{
			rectangleF_.X += num13;
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
