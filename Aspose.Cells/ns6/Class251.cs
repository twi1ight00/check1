using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class251 : Class160
{
	internal Class251(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] array = new PointF[4];
		ref PointF reference = ref array[0];
		reference = new PointF(x, y);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(x + width, y);
		ref PointF reference3 = ref array[3];
		reference3 = new PointF(x + width, y + height);
		ref PointF reference4 = ref array[2];
		reference4 = new PointF(x, y + height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
