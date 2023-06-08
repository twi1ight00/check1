using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class263 : Class160
{
	internal Class263(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		PointF[] array = new PointF[5];
		switch (class913_0.int_3)
		{
		case 2:
		case 3:
		{
			ref PointF reference6 = ref array[0];
			reference6 = new PointF(x, y + rectangleF_0.Height * 0.2f);
			ref PointF reference7 = ref array[1];
			reference7 = new PointF(x + width * 0.5f, y);
			ref PointF reference8 = ref array[2];
			reference8 = new PointF(x + width, y + 0.2f * height);
			ref PointF reference9 = ref array[3];
			reference9 = new PointF(x + width, y + height);
			ref PointF reference10 = ref array[4];
			reference10 = new PointF(x, y + height);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x, y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + width, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + width, y + 0.8f * height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + 0.5f * width, y + height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x, y + 0.8f * height);
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
