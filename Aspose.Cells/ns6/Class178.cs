using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class178 : Class160
{
	internal Class178(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[4];
		float num = 0f;
		float num2 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = rectangleF_0.Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				num2 = rectangleF_0.Width * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
			}
			else
			{
				num = rectangleF_0.Height * 0.5f;
				num2 = rectangleF_0.Width * 0.5f;
			}
		}
		else
		{
			num = rectangleF_0.Height * 0.5f;
			num2 = rectangleF_0.Width * 0.5f;
		}
		if (num <= 0f)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[0]);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference16 = ref array[0];
			reference16 = new PointF(float_3, num + float_4);
			ref PointF reference17 = ref array[1];
			reference17 = new PointF(num2 + float_3, float_4);
			ref PointF reference18 = ref array[2];
			reference18 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference19 = ref array[3];
			reference19 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 2:
		{
			ref PointF reference12 = ref array[0];
			reference12 = new PointF(float_3, float_4);
			ref PointF reference13 = ref array[1];
			reference13 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference14 = ref array[2];
			reference14 = new PointF(num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference15 = ref array[3];
			reference15 = new PointF(float_3, rectangleF_0.Height - num + float_4);
			break;
		}
		case 3:
		{
			ref PointF reference8 = ref array[0];
			reference8 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference9 = ref array[1];
			reference9 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height - num + float_4);
			ref PointF reference10 = ref array[2];
			reference10 = new PointF(rectangleF_0.Width - num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference11 = ref array[3];
			reference11 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 4:
		{
			ref PointF reference4 = ref array[0];
			reference4 = new PointF(float_3, float_4);
			ref PointF reference5 = ref array[1];
			reference5 = new PointF(rectangleF_0.Width - num2 + float_3, float_4);
			ref PointF reference6 = ref array[2];
			reference6 = new PointF(rectangleF_0.Width + float_3, num + float_4);
			ref PointF reference7 = ref array[3];
			reference7 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
