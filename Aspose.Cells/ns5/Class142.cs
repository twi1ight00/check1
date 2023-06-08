using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class142 : Class18
{
	internal Class142(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] points = new PointF[28]
		{
			new PointF(x + 0.0557f * width, y + 0.3832f * height),
			new PointF(x + 0.2516f * width, y + 0.3641f * height),
			new PointF(x + 0.2103f * width, y + 0.1712f * height),
			new PointF(x + 0.3979f * width, y + 0.2962f * height),
			new PointF(x + 0.4516f * width, y + 0.0898f * height),
			new PointF(x + 0.532f * width, y + 0.2038f * height),
			new PointF(x + 0.6866f * width, y + 0f * height),
			new PointF(x + 0.6742f * width, y + 0.269f * height),
			new PointF(x + 0.8351f * width, y + 0.1495f * height),
			new PointF(x + 0.7588f * width, y + 0.3044f * height),
			new PointF(x + 1f * width, y + 0.3098f * height),
			new PointF(x + 0.7876f * width, y + 0.4375f * height),
			new PointF(x + 0.8474f * width, y + 0.5245f * height),
			new PointF(x + 0.7588f * width, y + 0.5734f * height),
			new PointF(x + 0.8742f * width, y + 0.7228f * height),
			new PointF(x + 0.6784f * width, y + 0.6658f * height),
			new PointF(x + 0.6928f * width, y + 0.8043f * height),
			new PointF(x + 0.5649f * width, y + 0.7391f * height),
			new PointF(x + 0.5402f * width, y + 0.875f * height),
			new PointF(x + 0.4598f * width, y + 0.8043f * height),
			new PointF(x + 0.4062f * width, y + 0.913f * height),
			new PointF(x + 0.3505f * width, y + 0.8397f * height),
			new PointF(x + 0.2287f * width, y + 1f * height),
			new PointF(x + 0.2247f * width, y + 0.8451f * height),
			new PointF(x + 0.0619f * width, y + 0.8261f * height),
			new PointF(x + 0.1567f * width, y + 0.712f * height),
			new PointF(x + 0f * width, y + 0.5978f * height),
			new PointF(x + 0.1835f * width, y + 0.538f * height)
		};
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		return graphicsPath;
	}
}
