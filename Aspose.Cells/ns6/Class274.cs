using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class274 : Class160
{
	internal Class274(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[8];
		float num = 0f;
		float num2 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24562f;
				num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.1176f;
			}
		}
		else
		{
			num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24562f;
			num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.1176f;
		}
		if (num <= 0f && num2 != 0f)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num2) / 2f + float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num2) / 2f + float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num2) / 2f + num2 + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - num2) / 2f + num2 + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.StartFigure();
			return graphicsPath;
		}
		if (num == 0f && num2 == 0f)
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(0.135f * rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(0.865f * rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[0]);
			graphicsPath.CloseFigure();
		}
		else
		{
			ref PointF reference7 = ref array[0];
			reference7 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + float_4);
			ref PointF reference8 = ref array[1];
			reference8 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + float_4);
			ref PointF reference9 = ref array[2];
			reference9 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + float_4);
			ref PointF reference10 = ref array[3];
			reference10 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + float_4);
			ref PointF reference11 = ref array[4];
			reference11 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + num2 + float_4);
			ref PointF reference12 = ref array[5];
			reference12 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + num2 + float_4);
			ref PointF reference13 = ref array[6];
			reference13 = new PointF(0.865f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + num2 + num + float_4);
			ref PointF reference14 = ref array[7];
			reference14 = new PointF(0.135f * rectangleF_0.Width + float_3, (rectangleF_0.Height - 2f * num - num2) / 2f + num + num2 + num + float_4);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[0]);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(array[4], array[5]);
			graphicsPath.AddLine(array[5], array[6]);
			graphicsPath.AddLine(array[6], array[7]);
			graphicsPath.AddLine(array[7], array[4]);
			graphicsPath.CloseFigure();
		}
		return graphicsPath;
	}
}
