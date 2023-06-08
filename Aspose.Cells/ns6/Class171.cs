using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class171 : Class160
{
	internal Class171(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = Math.Min(rectangleF_0.Width, rectangleF_0.Height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 60000f;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 60000f;
				num3 = num4 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			}
			else
			{
				num = 180f;
				num2 = 0f;
				num3 = num4 * 25000f / 100000f;
			}
		}
		else
		{
			num = 180f;
			num2 = 0f;
			num3 = num4 * 25000f / 100000f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num5 = float_3;
		float num6 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rect = new RectangleF(num5, num6, width, height);
		if (num2 > 180f && num2 <= 360f)
		{
			graphicsPath.AddArc(rect, num, num2 - num);
		}
		else
		{
			graphicsPath.AddArc(rect, num, 360f - num + num2);
		}
		if (num2 > 180f && num2 <= 360f)
		{
			graphicsPath.AddArc(num5 + num3, num6 + num3, width - 2f * num3, height - 2f * num3, num2, 0f - (num2 - num));
		}
		else
		{
			graphicsPath.AddArc(num5 + num3, num6 + num3, width - 2f * num3, height - 2f * num3, num2, 0f - (360f - num + num2));
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
