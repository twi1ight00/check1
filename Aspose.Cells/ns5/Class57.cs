using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class57 : Class18
{
	internal Class57(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[4]
		{
			new PointF(rectangleF_0.Width / 2f + float_3, float_4),
			new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4),
			new PointF(rectangleF_0.Width / 2f + float_3, rectangleF_0.Height + float_4),
			new PointF(float_3, rectangleF_0.Height / 2f + float_4)
		};
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
