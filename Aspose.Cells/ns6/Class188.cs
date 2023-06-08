using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class188 : Class160
{
	internal Class188(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		PointF[] array = new PointF[7];
		switch (class913_0.int_3)
		{
		case 2:
		case 3:
		{
			ref PointF reference8 = ref array[0];
			reference8 = new PointF(num + 0.28f * width, num2);
			ref PointF reference9 = ref array[1];
			reference9 = new PointF(num + 0.72f * width, num2);
			ref PointF reference10 = ref array[2];
			reference10 = new PointF(num + width, num2 + 0.36f * height);
			ref PointF reference11 = ref array[3];
			reference11 = new PointF(num + 0.9f * width, num2 + 0.8f * height);
			ref PointF reference12 = ref array[4];
			reference12 = new PointF(num + 0.5f * width, num2 + height);
			ref PointF reference13 = ref array[5];
			reference13 = new PointF(num + 0.1f * width, num2 + 0.8f * height);
			ref PointF reference14 = ref array[6];
			reference14 = new PointF(num, num2 + 0.36f * height);
			break;
		}
		case 1:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num + 0.5f * width, num2);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(num + 0.9f * width, num2 + 0.2f * height);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(num + width, num2 + 0.64f * height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + 0.72f * width, num2 + height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(num + 0.28f * width, num2 + height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(num, num2 + 0.64f * height);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(num + 0.1f * width, num2 + 0.2f * height);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
