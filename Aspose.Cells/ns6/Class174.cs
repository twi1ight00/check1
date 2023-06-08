using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class174 : Class160
{
	internal Class174(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		graphicsPath.AddArc(x + 0.088f * width, y + 0.097f * height, 0.318f * width, 0.445f * height, 165f, 150f);
		graphicsPath.AddArc(x + 0.307f * width, y + 0.034f * height, 0.25f * width, 0.371f * height, 210f, 103f);
		graphicsPath.AddArc(x + 0.503f * width, y + 0.008f * height, 0.212f * width, 0.329f * height, 180f, 133f);
		graphicsPath.AddArc(x + 0.663f * width, y + 0.005f * height, 0.231f * width, 0.19f * height, 195f, 192f);
		graphicsPath.AddArc(x + 0.736f * width, y + 0.132f * height, 0.243f * width, 0.329f * height, 283f, 127f);
		graphicsPath.AddArc(x + 0.7f * width, y + 0.281f * height, 0.3f * width, 0.426f * height, 322f, 122f);
		graphicsPath.AddArc(x + 0.597f * width, y + 0.511f * height, 0.271f * width, 0.374f * height, 300f, 182f);
		graphicsPath.AddArc(x + 0.356f * width, y + 0.61f * height, 0.313f * width, 0.392f * height, 0f, 165f);
		graphicsPath.AddArc(x + 0.127f * width, y + 0.555f * height, 0.32f * width, 0.392f * height, 54f, 101f);
		graphicsPath.AddArc(x + 0.021f * width, y + 0.539f * height, 0.266f * width, 0.297f * height, 87f, 135f);
		graphicsPath.AddArc(x + 0.005f * width, y + 0.342f * height, 0.21f * width, 0.268f * height, 80f, 179f);
		return graphicsPath;
	}
}
