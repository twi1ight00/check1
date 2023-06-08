using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class131 : Class18
{
	internal Class131(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class898_0.int_2)
		{
		case 1:
		{
			graphicsPath.AddArc(x, y, width, height, 45f, -300f);
			double num = (double)(x + width / 2f) + (double)(width / 2f) * Math.Cos(Struct67.smethod_0(315.0));
			double num2 = (double)(y + height / 2f) - (double)(height / 2f) * Math.Sin(Struct67.smethod_0(315.0));
			graphicsPath.AddLine(x + width / 2f, y + height, x + width, y + height);
			graphicsPath.AddLine(x + width, y + height, x + width, (float)num2);
			graphicsPath.AddLine(x + width, (float)num2, (float)num, (float)num2);
			break;
		}
		case 2:
		{
			graphicsPath.AddArc(x, y, width, height, -45f, 300f);
			double num = (double)(x + width / 2f) + (double)(width / 2f) * Math.Cos(Struct67.smethod_0(315.0));
			double num2 = (double)(y + height / 2f) + (double)(height / 2f) * Math.Sin(Struct67.smethod_0(315.0));
			graphicsPath.AddLine(x + width / 2f, y, x + width, y);
			graphicsPath.AddLine(x + width, y, x + width, (float)num2);
			graphicsPath.AddLine(x + width, (float)num2, (float)num, (float)num2);
			break;
		}
		case 3:
		{
			graphicsPath.AddArc(x, y, width, height, 270f, 300f);
			double num = (double)(x + width / 2f) - (double)(width / 2f) * Math.Cos(Struct67.smethod_0(315.0));
			double num2 = (double)(y + height / 2f) + (double)(height / 2f) * Math.Sin(Struct67.smethod_0(315.0));
			graphicsPath.AddLine((float)num, (float)num2, x, (float)num2);
			graphicsPath.AddLine(x, (float)num2, x, y);
			graphicsPath.AddLine(x, y, x + width / 2f, y);
			break;
		}
		case 4:
		{
			graphicsPath.AddArc(x, y, width, height, 90f, -300f);
			double num = (double)(x + width / 2f) - (double)(width / 2f) * Math.Cos(Struct67.smethod_0(315.0));
			double num2 = (double)(y + height / 2f) - (double)(height / 2f) * Math.Sin(Struct67.smethod_0(315.0));
			graphicsPath.AddLine((float)num, (float)num2, x, (float)num2);
			graphicsPath.AddLine(x, (float)num2, x, y + height);
			graphicsPath.AddLine(x, y + height, x + width / 2f, y + height);
			break;
		}
		}
		return graphicsPath;
	}
}
