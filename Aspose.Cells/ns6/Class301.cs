using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class301 : Class160
{
	internal Class301(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
				num = num4 * 13542f / 100000f;
			}
			else
			{
				float num5 = Math.Max(width, height);
				num = num5 * 13542f / 100000f;
			}
		}
		else if (width > height)
		{
			float num6 = Math.Min(width, height);
			num = num6 * 13542f / 100000f;
		}
		else
		{
			float num7 = Math.Max(width, height);
			num = num7 * 13542f / 100000f;
		}
		float num8 = height / 2f - num;
		float num9 = height - 2f * num8;
		float num10 = num9 * width / height;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		for (int i = 0; i < 4; i++)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(i * 90)) * (double)width / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0(i * 90))) * (double)height / 2.0));
			ref PointF reference2 = ref array[1];
			reference2 = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(45 + i * 90)) * (double)num10 / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0(45 + i * 90))) * (double)num9 / 2.0));
			ref PointF reference3 = ref array[2];
			reference3 = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0((i + 1) * 90)) * (double)width / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0((i + 1) * 90))) * (double)height / 2.0));
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		return graphicsPath;
	}
}
