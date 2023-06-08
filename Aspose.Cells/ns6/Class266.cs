using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class266 : Class160
{
	internal Class266(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		case 3:
			graphicsPath.AddArc(x, y, 0.5f * width, 0.2f * height, 180f, -180f);
			graphicsPath.AddArc(x + 0.5f * width, y, 0.5f * width, 0.2f * height, 180f, 180f);
			graphicsPath.AddLine(x + width, y + 0.1f * height, x + width, y + 0.9f * height);
			graphicsPath.AddArc(x + 0.5f * width, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, -180f);
			graphicsPath.AddArc(x, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, 180f);
			graphicsPath.AddLine(x, y + 0.9f * height, x, y + 0.1f * height);
			break;
		case 2:
		case 4:
			graphicsPath.AddArc(x, y, 0.5f * width, 0.2f * height, 180f, 180f);
			graphicsPath.AddArc(x + rectangleF_0.Width * 0.5f, y, 0.5f * width, 0.2f * height, 180f, -180f);
			graphicsPath.AddLine(x + width, y + 0.1f * height, x + width, y + 0.9f * height);
			graphicsPath.AddArc(x + rectangleF_0.Width * 0.5f, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, 180f);
			graphicsPath.AddArc(x, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, -180f);
			graphicsPath.AddLine(x, y + 0.9f * height, x, y + 0.1f * height);
			break;
		}
		return graphicsPath;
	}
}
