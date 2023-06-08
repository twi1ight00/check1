using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class259 : Class160
{
	internal Class259(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(x, y + 0.2f * height);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(x + width, y);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(x + width, y + height);
			ref PointF reference16 = ref array[3];
			reference16 = new PointF(x, y + height);
			break;
		}
		case 2:
		{
			ref PointF reference9 = ref array[0];
			reference9 = new PointF(x, y);
			ref PointF reference10 = ref array[1];
			reference10 = new PointF(x + width, y);
			ref PointF reference11 = ref array[2];
			reference11 = new PointF(x + width, y + height);
			ref PointF reference12 = ref array[3];
			reference12 = new PointF(x, y + 0.8f * height);
			break;
		}
		case 3:
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(x, y);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(x + width, y);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(x + width, y + 0.8f * height);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(x, y + height);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x, y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + width, y + 0.2f * rectangleF_0.Height);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x + width, y + height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x, y + height);
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
