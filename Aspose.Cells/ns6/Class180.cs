using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class180 : Class160
{
	internal Class180(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = float_3;
		float num2 = float_4;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] array = new PointF[12]
		{
			new PointF(num + 0.37f * width, num2),
			new PointF(num + 0.63f * width, num2),
			new PointF(num + 0.86f * width, num2 + 0.14f * height),
			new PointF(num + width, num2 + 0.37f * height),
			new PointF(num + width, num2 + 0.63f * height),
			new PointF(num + 0.86f * width, num2 + 0.86f * height),
			new PointF(num + 0.63f * width, num2 + height),
			new PointF(num + 0.37f * width, num2 + height),
			new PointF(num + 0.14f * width, num2 + 0.86f * height),
			new PointF(num, num2 + 0.63f * height),
			new PointF(num, num2 + 0.37f * height),
			new PointF(num + 0.14f * width, num2 + 0.14f * height)
		};
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[8]);
		graphicsPath.AddLine(array[8], array[9]);
		graphicsPath.AddLine(array[9], array[10]);
		graphicsPath.AddLine(array[10], array[11]);
		graphicsPath.AddLine(array[11], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
