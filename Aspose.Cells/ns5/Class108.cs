using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class108 : Class18
{
	internal Class108(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.2f;
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		float num2 = num * 2f;
		RectangleF rect = new RectangleF(size: new SizeF(num2, num2), location: rectangleF_0.Location);
		graphicsPath.AddArc(rect, 180f, 90f);
		rect.X = rectangleF_0.Right - num2;
		graphicsPath.AddArc(rect, 270f, 90f);
		rect.Y = rectangleF_0.Bottom - num2;
		graphicsPath.AddArc(rect, 0f, 90f);
		rect.X = rectangleF_0.Left;
		graphicsPath.AddArc(rect, 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
