using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class270 : Class160
{
	internal Class270(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		graphicsPath.AddArc(x + 0.7f * width, y, 0.3f * width, height, 270f, 180f);
		graphicsPath.AddLine(x + 0.85f * width, y + height, x + 0.15f * width, y + height);
		graphicsPath.AddArc(x, y, 0.3f * width, height, 90f, 180f);
		graphicsPath.AddLine(x + 0.15f * width, y, x + 0.85f * width, y);
		return graphicsPath;
	}
}
