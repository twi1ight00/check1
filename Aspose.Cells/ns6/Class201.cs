using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class201 : Class160
{
	internal Class201(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference10 = ref array[0];
			reference10 = new PointF(float_3, float_4);
			ref PointF reference11 = ref array[1];
			reference11 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference12 = ref array[2];
			reference12 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 2:
		{
			ref PointF reference7 = ref array[0];
			reference7 = new PointF(float_3, float_4);
			ref PointF reference8 = ref array[1];
			reference8 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference9 = ref array[2];
			reference9 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 3:
		{
			ref PointF reference4 = ref array[0];
			reference4 = new PointF(float_3, float_4);
			ref PointF reference5 = ref array[1];
			reference5 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference6 = ref array[2];
			reference6 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
