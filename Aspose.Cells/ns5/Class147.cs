using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class147 : Class18
{
	internal Class147(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (height / 2f * 0.24898148f) : (height / 2f * (1f - Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 10800f)));
		float num2 = height / 2f - num;
		float num3 = height - 2f * num2;
		float num4 = num3 * width / height;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		for (int i = 0; i < 4; i++)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(i * 90)) * (double)width / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(i * 90))) * (double)height / 2.0));
			ref PointF reference2 = ref array[1];
			reference2 = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(45 + i * 90)) * (double)num4 / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(45 + i * 90))) * (double)num3 / 2.0));
			ref PointF reference3 = ref array[2];
			reference3 = new PointF((float)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0((i + 1) * 90)) * (double)width / 2.0), (float)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0((i + 1) * 90))) * (double)height / 2.0));
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		return graphicsPath;
	}
}
