using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class132 : Class18
{
	internal Class132(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] points = new PointF[4]
		{
			new PointF(x + width / 2f, y),
			new PointF(x + width, y + height / 2f),
			new PointF(x + width / 2f, y + height),
			new PointF(x, y + height / 2f)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		graphicsPath.AddLine(x, y + height / 2f, x + width, y + height / 2f);
		return graphicsPath;
	}
}
