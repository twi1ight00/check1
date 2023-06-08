using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class111 : Class18
{
	internal Class111(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		return graphicsPath;
	}
}
