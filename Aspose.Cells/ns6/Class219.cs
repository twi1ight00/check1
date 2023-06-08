using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class219 : Class160
{
	internal Class219(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		PointF[] array = new PointF[18];
		float num5 = Math.Min(rectangleF_0.Width, rectangleF_0.Height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = num5 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num3 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
				num4 = rectangleF_0.Width * Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f;
			}
			else
			{
				num = num5 * 0.25f;
				num2 = num5 * 25000f / 100000f;
				num3 = num5 * 25000f / 100000f;
				num4 = rectangleF_0.Width * 48123f / 100000f;
			}
		}
		else
		{
			num = num5 * 0.25f;
			num2 = num5 * 25000f / 100000f;
			num3 = num5 * 25000f / 100000f;
			num4 = rectangleF_0.Width * 48123f / 100000f;
		}
		ref PointF reference = ref array[0];
		reference = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num2);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f, rectangleF_0.Y);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f + num4, rectangleF_0.Y);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f + num4, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f);
		ref PointF reference8 = ref array[7];
		reference8 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f);
		ref PointF reference9 = ref array[8];
		reference9 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num2);
		ref PointF reference10 = ref array[9];
		reference10 = new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f);
		ref PointF reference11 = ref array[10];
		reference11 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + rectangleF_0.Height / 2f + num2);
		ref PointF reference12 = ref array[11];
		reference12 = new PointF(rectangleF_0.X + rectangleF_0.Width - num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f + num);
		ref PointF reference13 = ref array[12];
		reference13 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f + num4, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f + num);
		ref PointF reference14 = ref array[13];
		reference14 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f + num4, rectangleF_0.Y + rectangleF_0.Height);
		ref PointF reference15 = ref array[14];
		reference15 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f, rectangleF_0.Y + rectangleF_0.Height);
		ref PointF reference16 = ref array[15];
		reference16 = new PointF(rectangleF_0.X + (rectangleF_0.Width - num4) / 2f, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f + num);
		ref PointF reference17 = ref array[16];
		reference17 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + rectangleF_0.Height / 2f - num / 2f + num);
		ref PointF reference18 = ref array[17];
		reference18 = new PointF(rectangleF_0.X + num3, rectangleF_0.Y + rectangleF_0.Height / 2f + num2);
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
