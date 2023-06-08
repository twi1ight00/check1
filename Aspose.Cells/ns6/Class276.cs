using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class276 : Class160
{
	internal Class276(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = (float)Struct70.smethod_0(Struct70.smethod_1(Math.Atan(rectangleF_0.Height / rectangleF_0.Width)));
		PointF[] array = new PointF[12];
		float num2 = 0f;
		num2 = ((class913_0.class901_0 == null) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24153f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24153f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (num2 <= 0f)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(0.24f * rectangleF_0.Width + float_3, 0.24f * rectangleF_0.Height + float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width * 0.76f + float_3, rectangleF_0.Height * 0.24f + float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(0.76f * rectangleF_0.Width + float_3, rectangleF_0.Height * 0.76f + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(0.24f * rectangleF_0.Width + float_3, rectangleF_0.Height * 0.76f + float_4);
			graphicsPath.AddLine(array[0], array[2]);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(array[1], array[3]);
			graphicsPath.StartFigure();
			return graphicsPath;
		}
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		num5 = num2 / 2f;
		num3 = (float)((double)num5 * Math.Sin(num));
		num4 = (float)((double)num5 * Math.Cos(num));
		float num6 = 0.24f * rectangleF_0.Width;
		float num7 = 0.24f * rectangleF_0.Height;
		float num8 = num5 / (float)Math.Cos(num);
		float num9 = num5 / (float)Math.Sin(num);
		ref PointF reference5 = ref array[0];
		reference5 = new PointF(float_3 + num3 + num6, float_4 + num7 - num4);
		ref PointF reference6 = ref array[1];
		reference6 = new PointF(float_3 + rectangleF_0.Width / 2f, float_4 + rectangleF_0.Height / 2f - num8);
		ref PointF reference7 = ref array[2];
		reference7 = new PointF(float_3 + rectangleF_0.Width / 2f + num6 - num3, float_4 + num7 - num4);
		ref PointF reference8 = ref array[3];
		reference8 = new PointF(float_3 + rectangleF_0.Width / 2f + num6 + num3, float_4 + num7 + num4);
		ref PointF reference9 = ref array[4];
		reference9 = new PointF(float_3 + rectangleF_0.Width / 2f + num9, float_4 + rectangleF_0.Height / 2f);
		ref PointF reference10 = ref array[5];
		reference10 = new PointF(float_3 + rectangleF_0.Width / 2f + num6 + num3, float_4 + rectangleF_0.Height - (num7 + num4));
		ref PointF reference11 = ref array[6];
		reference11 = new PointF(float_3 + rectangleF_0.Width / 2f + num6 - num3, float_4 + rectangleF_0.Height - (num7 - num4));
		ref PointF reference12 = ref array[7];
		reference12 = new PointF(float_3 + rectangleF_0.Width / 2f, float_4 + rectangleF_0.Height / 2f + num8);
		ref PointF reference13 = ref array[8];
		reference13 = new PointF(float_3 + num6 + num3, float_4 + rectangleF_0.Height - (num7 - num4));
		ref PointF reference14 = ref array[9];
		reference14 = new PointF(float_3 + num6 - num3, float_4 + rectangleF_0.Height - (num7 + num4));
		ref PointF reference15 = ref array[10];
		reference15 = new PointF(float_3 + rectangleF_0.Width / 2f - num9, float_4 + rectangleF_0.Height / 2f);
		ref PointF reference16 = ref array[11];
		reference16 = new PointF(float_3 + num6 - num3, float_4 + num7 + num4);
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[6]);
		graphicsPath.AddLine(array[6], array[7]);
		graphicsPath.AddLine(array[7], array[8]);
		graphicsPath.AddLine(array[8], array[9]);
		graphicsPath.AddLine(array[9], array[10]);
		graphicsPath.AddLine(array[10], array[11]);
		graphicsPath.AddLine(array[11], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
