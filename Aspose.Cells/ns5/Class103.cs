using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class103 : Class18
{
	internal Class103(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
		switch (class898_0.int_2)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class898_0.method_22().Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class898_0.method_22().Width, class898_0.method_22().Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class898_0.method_22().Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
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
		float num7 = 0f;
		num = width * 0.28f;
		num2 = height * 0.26f;
		num3 = width * 0.28f;
		num4 = height * 0.28f;
		num5 = width * 0.4f;
		num6 = height * 0.36f;
		num7 = height * 0.66f;
		if (num3 == 0f)
		{
			num = class898_0.Line.Weight / 4f;
			num4 = 0f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num8 = num3 - num / 2f;
		float num9 = x + (width - num5 - num8);
		float num10 = num5 - num;
		float num11 = num6 - num2;
		graphicsPath.AddArc(x, y, num5 * 2f, num6 * 2f, 180f, 90f);
		graphicsPath.AddLine(x + num5, y, num9, y);
		graphicsPath.AddArc(num9 - num5, y, 2f * num5, 2f * num6, 270f, 90f);
		graphicsPath.AddLine(x + (width - num8), y + num6, x + (width - num8), y + (num7 - num4));
		graphicsPath.AddLine(x + (width - num8), y + (num7 - num4), x + width, y + (num7 - num4));
		graphicsPath.AddLine(x + width, y + (num7 - num4), x + (width - num3), y + num7);
		graphicsPath.AddLine(x + (width - num3), y + num7, x + width - 2f * num3, y + (num7 - num4));
		graphicsPath.AddLine(x + width - 2f * num3, y + (num7 - num4), x + (width - 2f * num3) + num8, y + (num7 - num4));
		graphicsPath.AddArc(num9 - num10, y + num2, 2f * num10, 2f * num11, 0f, -90f);
		graphicsPath.AddArc(x + num, y + num2, 2f * num10, 2f * num11, 270f, -90f);
		graphicsPath.AddLine(x + num, y + num5, x + num, y + height);
		graphicsPath.AddLine(x + num, y + height, x, y + height);
		graphicsPath.AddLine(x, y + height, x, y + num5);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
