using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class294 : Class160
{
	internal Class294(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] points = new PointF[24]
		{
			new PointF(x + 0.015f * width, y + 0.105f * height),
			new PointF(x + 0.3369f * width, y + 0.2916f * height),
			new PointF(x + 0.3841f * width, y + 0.105f * height),
			new PointF(x + 0.5f * width, y + 0.2682f * height),
			new PointF(x + 0.6717f * width, y + 0f * height),
			new PointF(x + 0.6545f * width, y + 0.2478f * height),
			new PointF(x + 0.8519f * width, y + 0.207f * height),
			new PointF(x + 0.7725f * width, y + 0.3382f * height),
			new PointF(x + 0.9742f * width, y + 0.3761f * height),
			new PointF(x + 0.8155f * width, y + 0.484f * height),
			new PointF(x + 1f * width, y + 0.6152f * height),
			new PointF(x + 0.779f * width, y + 0.6006f * height),
			new PointF(x + 0.8412f * width, y + 0.8367f * height),
			new PointF(x + 0.6502f * width, y + 0.6706f * height),
			new PointF(x + 0.6137f * width, y + 0.9155f * height),
			new PointF(x + 0.4871f * width, y + 0.691f * height),
			new PointF(x + 0.3927f * width, y + 1f * height),
			new PointF(x + 0.3562f * width, y + 0.7201f * height),
			new PointF(x + 0.221f * width, y + 0.8192f * height),
			new PointF(x + 0.2618f * width, y + 0.6443f * height),
			new PointF(x + 0.0064f * width, y + 0.6764f * height),
			new PointF(x + 0.1695f * width, y + 0.5481f * height),
			new PointF(x + 0f * width, y + 0.3994f * height),
			new PointF(x + 0.2124f * width, y + 0.3557f * height)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		return graphicsPath;
	}
}
