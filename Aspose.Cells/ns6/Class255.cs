using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class255 : Class160
{
	internal Class255(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class913_0.int_3)
		{
		case 1:
		case 2:
			graphicsPath.AddArc(x + 2f * width / 3f, y, width / 3f, height, 270f, 180f);
			graphicsPath.AddLine(x + 5f * width / 6f, y + height, x + width / 6f, y + height);
			graphicsPath.AddLine(x + width / 6f, y + height, x, y + height / 2f);
			graphicsPath.AddLine(x, y + height / 2f, x + width / 6f, y);
			graphicsPath.AddLine(x + width / 6f, y, 5f * width / 6f, y);
			break;
		case 3:
		case 4:
			graphicsPath.AddArc(x, y, width / 3f, height, 90f, 180f);
			graphicsPath.AddLine(x + width / 6f, y, x + 5f * width / 6f, y);
			graphicsPath.AddLine(x + 5f * width / 6f, y, x + width, y + height / 2f);
			graphicsPath.AddLine(x + width, y + height / 2f, x + 5f * width / 6f, y + height);
			graphicsPath.AddLine(x + 5f * width / 6f, y + height, width / 6f, y + height);
			break;
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
