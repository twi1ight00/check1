using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class304 : Class160
{
	internal Class304(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				if (width > height)
				{
					float num2 = Math.Min(width, height);
					num = num2 * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				}
				else
				{
					float num3 = Math.Max(width, height);
					num = num3 * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				}
			}
			else if (width > height)
			{
				float num4 = Math.Min(width, height);
				num = num4 * 35591f / 100000f;
			}
			else
			{
				float num5 = Math.Max(width, height);
				num = num5 * 35591f / 100000f;
			}
		}
		else if (width > height)
		{
			float num6 = Math.Min(width, height);
			num = num6 * 35591f / 100000f;
		}
		else
		{
			float num7 = Math.Max(width, height);
			num = num7 * 35591f / 100000f;
		}
		height = (float)((double)(2f * height) / (1.0 + Math.Sin(Struct70.smethod_0(64.28571428571429))));
		width = (float)((double)width / Math.Cos(Struct70.smethod_0(12.857142857142858)));
		float num8 = rectangleF_0.Height / 2f - num;
		float num9 = height - 2f * num8;
		float num10 = num9 * width / height;
		x = (float)((double)x - (double)width * (1.0 - Math.Cos(Struct70.smethod_0(12.857142857142858))) / 2.0);
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		for (int i = 0; i < 7; i++)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(-12 + i * 360 / 7)) * (double)width / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct70.smethod_0(-12 + i * 360 / 7)) * (double)height / 2.0));
			ref PointF reference2 = ref array[2];
			reference2 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(-12 + (i + 1) * 360 / 7)) * (double)width / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct70.smethod_0(-12 + (i + 1) * 360 / 7)) * (double)height / 2.0));
			ref PointF reference3 = ref array[1];
			reference3 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(12 + i * 360 / 7)) * (double)num10 / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct70.smethod_0(12 + i * 360 / 7)) * (double)num9 / 2.0));
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		return graphicsPath;
	}
}
