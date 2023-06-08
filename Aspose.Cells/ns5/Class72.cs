using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class72 : Class18
{
	internal Class72(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[5];
		switch (class898_0.int_2)
		{
		case 2:
		case 3:
		{
			ref PointF reference6 = ref array[0];
			reference6 = new PointF(float_3 + rectangleF_0.Width / 2f * 0.38f, float_4);
			ref PointF reference7 = ref array[1];
			reference7 = new PointF(rectangleF_0.Width / 2f + rectangleF_0.Width / 2f * 0.62f + float_3, float_4);
			ref PointF reference8 = ref array[2];
			reference8 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + rectangleF_0.Height / 2f * 0.24f + float_4);
			ref PointF reference9 = ref array[3];
			reference9 = new PointF(rectangleF_0.Width / 2f + float_3, float_4 + rectangleF_0.Height);
			ref PointF reference10 = ref array[4];
			reference10 = new PointF(float_3, rectangleF_0.Height / 2f + rectangleF_0.Height / 2f * 0.24f + float_4);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(rectangleF_0.Width / 2f + float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f - rectangleF_0.Height / 2f * 0.24f + float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Width / 2f + rectangleF_0.Width / 2f * 0.62f + float_3, rectangleF_0.Height + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(rectangleF_0.Width / 2f - rectangleF_0.Width / 2f * 0.62f + float_3, rectangleF_0.Height + float_4);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(float_3, rectangleF_0.Height / 2f - rectangleF_0.Height / 2f * 0.24f + float_4);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
