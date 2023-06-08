using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class133 : Class18
{
	internal Class133(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		case 2:
			graphicsPath.AddArc(x, y, 0.3f * width, height, 90f, 180f);
			graphicsPath.AddLine(x + 0.15f * width, y, x + 0.85f * width, y);
			graphicsPath.AddArc(x + 0.85f * width, y, 0.3f * width, height, 270f, -180f);
			graphicsPath.AddLine(x + 0.85f * width, y + height, x + 0.15f * width, y + height);
			break;
		case 3:
		case 4:
			graphicsPath.AddLine(x, y, x + 0.15f * width, y);
			graphicsPath.AddArc(x + rectangleF_0.Width * 0.7f, y, 0.3f * width, height, 270f, 180f);
			graphicsPath.AddLine(x + 0.85f * width, y + height, x, y + height);
			graphicsPath.AddArc(x - 0.15f * width, y, 0.3f * width, height, 90f, -180f);
			break;
		}
		return graphicsPath;
	}
}
