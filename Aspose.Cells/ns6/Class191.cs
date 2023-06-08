using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class191 : Class160
{
	internal Class191(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		PointF[] array = new PointF[11];
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference34 = ref array[0];
			reference34 = new PointF(num, num2 + 0.18f * height);
			ref PointF reference35 = ref array[1];
			reference35 = new PointF(num + 0.4f * width, num2);
			ref PointF reference36 = ref array[2];
			reference36 = new PointF(num + 0.6f * width, num2 + 0.28f * height);
			ref PointF reference37 = ref array[3];
			reference37 = new PointF(num + 0.51f * width, num2 + 0.32f * height);
			ref PointF reference38 = ref array[4];
			reference38 = new PointF(num + 0.77f * width, num2 + 0.56f * height);
			ref PointF reference39 = ref array[5];
			reference39 = new PointF(num + 0.7f * width, num2 + 0.6f * height);
			ref PointF reference40 = ref array[6];
			reference40 = new PointF(num + width, num2 + height);
			ref PointF reference41 = ref array[7];
			reference41 = new PointF(num + 0.47f * width, num2 + 0.7f * height);
			ref PointF reference42 = ref array[8];
			reference42 = new PointF(num + 0.59f * width, num2 + 0.65f * height);
			ref PointF reference43 = ref array[9];
			reference43 = new PointF(num + 0.24f * width, num2 + 0.46f * height);
			ref PointF reference44 = ref array[10];
			reference44 = new PointF(num + 0.35f * width, num2 + 0.4f * height);
			break;
		}
		case 2:
		{
			ref PointF reference23 = ref array[0];
			reference23 = new PointF(num + width, num2);
			ref PointF reference24 = ref array[1];
			reference24 = new PointF(num + 0.7f * width, num2 + 0.4f * height);
			ref PointF reference25 = ref array[2];
			reference25 = new PointF(num + 0.77f * width, num2 + 0.44f * height);
			ref PointF reference26 = ref array[3];
			reference26 = new PointF(num + 0.51f * width, num2 + 0.68f * height);
			ref PointF reference27 = ref array[4];
			reference27 = new PointF(num + 0.6f * width, num2 + 0.72f * height);
			ref PointF reference28 = ref array[5];
			reference28 = new PointF(num + 0.4f * width, num2 + height);
			ref PointF reference29 = ref array[6];
			reference29 = new PointF(num, num2 + 0.82f * height);
			ref PointF reference30 = ref array[7];
			reference30 = new PointF(num + 0.35f * width, num2 + 0.6f * height);
			ref PointF reference31 = ref array[8];
			reference31 = new PointF(num + 0.24f * width, num2 + 0.54f * height);
			ref PointF reference32 = ref array[9];
			reference32 = new PointF(num + 0.59f * width, num2 + 0.35f * height);
			ref PointF reference33 = ref array[10];
			reference33 = new PointF(num + 0.47f * width, num2 + 0.3f * height);
			break;
		}
		case 3:
		{
			ref PointF reference12 = ref array[0];
			reference12 = new PointF(num, num2);
			ref PointF reference13 = ref array[1];
			reference13 = new PointF(num + 0.3f * width, num2 + 0.4f * height);
			ref PointF reference14 = ref array[2];
			reference14 = new PointF(num + 0.23f * width, num2 + 0.44f * height);
			ref PointF reference15 = ref array[3];
			reference15 = new PointF(num + 0.49f * width, num2 + 0.68f * height);
			ref PointF reference16 = ref array[4];
			reference16 = new PointF(num + 0.4f * width, num2 + 0.72f * height);
			ref PointF reference17 = ref array[5];
			reference17 = new PointF(num + 0.6f * width, num2 + height);
			ref PointF reference18 = ref array[6];
			reference18 = new PointF(num + width, num2 + 0.82f * height);
			ref PointF reference19 = ref array[7];
			reference19 = new PointF(num + 0.65f * width, num2 + 0.6f * height);
			ref PointF reference20 = ref array[8];
			reference20 = new PointF(num + 0.76f * width, num2 + 0.54f * height);
			ref PointF reference21 = ref array[9];
			reference21 = new PointF(num + 0.41f * width, num2 + 0.35f * height);
			ref PointF reference22 = ref array[10];
			reference22 = new PointF(num + 0.53f * width, num2 + 0.3f * height);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num + width, num2 + 0.18f * height);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(num + 0.6f * width, num2);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(num + 0.4f * width, num2 + 0.28f * height);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + 0.49f * width, num2 + 0.32f * height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(num + 0.23f * width, num2 + 0.56f * height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(num + 0.3f * width, num2 + 0.6f * height);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(num, num2 + height);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(num + 0.53f * width, num2 + 0.7f * height);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(num + 0.41f * width, num2 + 0.65f * height);
			ref PointF reference10 = ref array[9];
			reference10 = new PointF(num + 0.76f * width, num2 + 0.46f * height);
			ref PointF reference11 = ref array[10];
			reference11 = new PointF(num + 0.65f * width, num2 + 0.4f * height);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
