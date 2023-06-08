using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class231 : Class160
{
	internal Class231(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 1f;
		float num2 = 1f;
		PointF[] array = new PointF[7];
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = rectangleF_0.Width * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				float num3 = ((!(rectangleF_0.Height > rectangleF_0.Width)) ? 1f : (rectangleF_0.Height / rectangleF_0.Width));
				num2 = rectangleF_0.Height * (1f - Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / (100000f * num3));
			}
			else
			{
				num = rectangleF_0.Width * 0.5f;
				float num4 = ((!(rectangleF_0.Height > rectangleF_0.Width)) ? 1f : (rectangleF_0.Height / rectangleF_0.Width));
				num2 = rectangleF_0.Height * (1f - 50000f / (100000f * num4));
			}
		}
		else
		{
			num = rectangleF_0.Width * 0.5f;
			float num5 = ((!(rectangleF_0.Height > rectangleF_0.Width)) ? 1f : (rectangleF_0.Height / rectangleF_0.Width));
			num2 = rectangleF_0.Height * (1f - 50000f / (100000f * num5));
		}
		if (num <= 0f && num2 == rectangleF_0.Height)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(float_3 + rectangleF_0.Width / 2f, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(float_3 + rectangleF_0.Width, float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(float_3 + rectangleF_0.Width / 2f, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[1], array[3]);
			return graphicsPath;
		}
		if (num <= 0f && num2 <= 0f)
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(float_3 + rectangleF_0.Width / 2f, float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(float_3 + rectangleF_0.Width, rectangleF_0.Height + float_4);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[0]);
			return graphicsPath;
		}
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference29 = ref array[0];
			reference29 = new PointF(float_3, rectangleF_0.Height - num2 + float_4);
			ref PointF reference30 = ref array[1];
			reference30 = new PointF(rectangleF_0.Width / 2f + float_3, float_4);
			ref PointF reference31 = ref array[2];
			reference31 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height - num2 + float_4);
			ref PointF reference32 = ref array[3];
			reference32 = new PointF((rectangleF_0.Width - num) / 2f + num + float_3, rectangleF_0.Height - num2 + float_4);
			ref PointF reference33 = ref array[4];
			reference33 = new PointF((rectangleF_0.Width - num) / 2f + num + float_3, rectangleF_0.Height + float_4);
			ref PointF reference34 = ref array[5];
			reference34 = new PointF((rectangleF_0.Width - num) / 2f + float_3, rectangleF_0.Height + float_4);
			ref PointF reference35 = ref array[6];
			reference35 = new PointF((rectangleF_0.Width - num) / 2f + float_3, rectangleF_0.Height - num2 + float_4);
			break;
		}
		case 2:
		{
			ref PointF reference22 = ref array[0];
			reference22 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, float_4);
			ref PointF reference23 = ref array[1];
			reference23 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, float_4);
			ref PointF reference24 = ref array[2];
			reference24 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, num2 + float_4);
			ref PointF reference25 = ref array[3];
			reference25 = new PointF(float_3 + rectangleF_0.Width, num2 + float_4);
			ref PointF reference26 = ref array[4];
			reference26 = new PointF(float_3 + rectangleF_0.Width / 2f, rectangleF_0.Height + float_4);
			ref PointF reference27 = ref array[5];
			reference27 = new PointF(float_3, num2 + float_4);
			ref PointF reference28 = ref array[6];
			reference28 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, num2 + float_4);
			break;
		}
		case 3:
		{
			ref PointF reference15 = ref array[0];
			reference15 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, float_4);
			ref PointF reference16 = ref array[1];
			reference16 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, float_4);
			ref PointF reference17 = ref array[2];
			reference17 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, num2 + float_4);
			ref PointF reference18 = ref array[3];
			reference18 = new PointF(float_3 + rectangleF_0.Width, num2 + float_4);
			ref PointF reference19 = ref array[4];
			reference19 = new PointF(float_3 + rectangleF_0.Width / 2f, rectangleF_0.Height + float_4);
			ref PointF reference20 = ref array[5];
			reference20 = new PointF(float_3, num2 + float_4);
			ref PointF reference21 = ref array[6];
			reference21 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, num2 + float_4);
			break;
		}
		case 4:
		{
			ref PointF reference8 = ref array[0];
			reference8 = new PointF(float_3, rectangleF_0.Height - num2 + float_4);
			ref PointF reference9 = ref array[1];
			reference9 = new PointF(float_3 + rectangleF_0.Width / 2f, float_4);
			ref PointF reference10 = ref array[2];
			reference10 = new PointF(float_3 + rectangleF_0.Width, rectangleF_0.Height - num2 + float_4);
			ref PointF reference11 = ref array[3];
			reference11 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, rectangleF_0.Height - num2 + float_4);
			ref PointF reference12 = ref array[4];
			reference12 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f + num, rectangleF_0.Height + float_4);
			ref PointF reference13 = ref array[5];
			reference13 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, rectangleF_0.Height + float_4);
			ref PointF reference14 = ref array[6];
			reference14 = new PointF(float_3 + (rectangleF_0.Width - num) / 2f, rectangleF_0.Height - num2 + float_4);
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
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
