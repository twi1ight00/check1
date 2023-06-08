using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class114 : Class18
{
	internal Class114(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
			graphicsPath.AddLine(x, y, x + 0.5f * width, y);
			graphicsPath.AddArc(x, y, width, height, 270f, 180f);
			graphicsPath.AddLine(x + width / 2f, y + height, x, y + height);
			graphicsPath.AddLine(x, y + height, x, y);
			break;
		case 3:
		case 4:
			graphicsPath.AddArc(x, y, width, height, 90f, 180f);
			graphicsPath.AddLine(x + width / 2f, y, x + width, y);
			graphicsPath.AddLine(x + width, y, x + width, y + height);
			graphicsPath.AddLine(x + width, y + height, x + width / 2f, y + height);
			break;
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
