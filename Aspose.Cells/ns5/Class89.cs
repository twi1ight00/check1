using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class89 : Class18
{
	internal Class89(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 1f;
		float num2 = 1f;
		PointF[] array = new PointF[10];
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num = rectangleF_0.Height - 2f * (rectangleF_0.Height * 0.2336574f);
			num2 = rectangleF_0.Width * 0.74703705f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num2 = rectangleF_0.Width - Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f * rectangleF_0.Width;
				num = rectangleF_0.Height - 2f * (rectangleF_0.Height * 0.2336574f);
			}
			else
			{
				num2 = rectangleF_0.Width * 0.74703705f;
				num = rectangleF_0.Height - 2f * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f * rectangleF_0.Height);
			}
			break;
		case 2:
			num2 = rectangleF_0.Width - Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f * rectangleF_0.Width;
			num = rectangleF_0.Height - 2f * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f * rectangleF_0.Height);
			break;
		}
		if (num <= 0f && num2 == rectangleF_0.Width)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[2]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			return graphicsPath;
		}
		if (num <= 0f && num2 <= 0f)
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(float_3, float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(float_3, rectangleF_0.Height + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[0]);
			return graphicsPath;
		}
		switch (class898_0.int_2)
		{
		case 1:
		{
			ref PointF reference38 = ref array[0];
			reference38 = new PointF(float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference39 = ref array[1];
			reference39 = new PointF(rectangleF_0.Width - num2 + float_3, float_4);
			ref PointF reference40 = ref array[2];
			reference40 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference41 = ref array[3];
			reference41 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference42 = ref array[4];
			reference42 = new PointF(num2 + float_3, float_4);
			ref PointF reference43 = ref array[5];
			reference43 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference44 = ref array[6];
			reference44 = new PointF(num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference45 = ref array[7];
			reference45 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference46 = ref array[8];
			reference46 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference47 = ref array[9];
			reference47 = new PointF(rectangleF_0.Width - num2 + float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 2:
		{
			ref PointF reference28 = ref array[0];
			reference28 = new PointF(float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference29 = ref array[1];
			reference29 = new PointF(rectangleF_0.Width - num2 + float_3, float_4);
			ref PointF reference30 = ref array[2];
			reference30 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference31 = ref array[3];
			reference31 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference32 = ref array[4];
			reference32 = new PointF(num2 + float_3, float_4);
			ref PointF reference33 = ref array[5];
			reference33 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference34 = ref array[6];
			reference34 = new PointF(num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference35 = ref array[7];
			reference35 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference36 = ref array[8];
			reference36 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference37 = ref array[9];
			reference37 = new PointF(rectangleF_0.Width - num2 + float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 3:
		{
			ref PointF reference18 = ref array[0];
			reference18 = new PointF(float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference19 = ref array[1];
			reference19 = new PointF(rectangleF_0.Width - num2 + float_3, float_4);
			ref PointF reference20 = ref array[2];
			reference20 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference21 = ref array[3];
			reference21 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference22 = ref array[4];
			reference22 = new PointF(num2 + float_3, float_4);
			ref PointF reference23 = ref array[5];
			reference23 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference24 = ref array[6];
			reference24 = new PointF(num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference25 = ref array[7];
			reference25 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference26 = ref array[8];
			reference26 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference27 = ref array[9];
			reference27 = new PointF(rectangleF_0.Width - num2 + float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 4:
		{
			ref PointF reference8 = ref array[0];
			reference8 = new PointF(float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference9 = ref array[1];
			reference9 = new PointF(rectangleF_0.Width - num2 + float_3, float_4);
			ref PointF reference10 = ref array[2];
			reference10 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference11 = ref array[3];
			reference11 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + float_4);
			ref PointF reference12 = ref array[4];
			reference12 = new PointF(num2 + float_3, float_4);
			ref PointF reference13 = ref array[5];
			reference13 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference14 = ref array[6];
			reference14 = new PointF(num2 + float_3, rectangleF_0.Height + float_4);
			ref PointF reference15 = ref array[7];
			reference15 = new PointF(num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference16 = ref array[8];
			reference16 = new PointF(rectangleF_0.Width - num2 + float_3, (rectangleF_0.Height - num) / 2f + num + float_4);
			ref PointF reference17 = ref array[9];
			reference17 = new PointF(rectangleF_0.Width - num2 + float_3, rectangleF_0.Height + float_4);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[8]);
		graphicsPath.AddLine(array[8], array[9]);
		graphicsPath.AddLine(array[9], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
