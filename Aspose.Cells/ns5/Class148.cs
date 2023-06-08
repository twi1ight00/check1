using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class148 : Class18
{
	internal Class148(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		num = height / 2f * 0.4f;
		height = (float)((double)(2f * height) / (1.0 + Math.Sin(Struct67.smethod_0(54.0))));
		width = (float)((double)width / Math.Cos(Struct67.smethod_0(18.0)));
		float num2 = rectangleF_0.Height / 2f - num + 6f;
		float num3 = height - 2f * num2;
		float num4 = num3 * width / height;
		x = (float)((double)x - (double)width * (1.0 - Math.Cos(Struct67.smethod_0(18.0))) / 2.0);
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		switch (class898_0.int_2)
		{
		case 2:
		case 3:
		{
			for (int j = 0; j < 5; j++)
			{
				ref PointF reference4 = ref array[0];
				reference4 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(18 + j * 72)) * (double)width / 2.0), (int)((double)(y + height) - ((double)(height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(18 + j * 72))) * (double)height / 2.0)));
				ref PointF reference5 = ref array[1];
				reference5 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(54 + j * 72)) * (double)num4 / 2.0), (int)((double)(y + height) - ((double)(height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(54 + j * 72))) * (double)num3 / 2.0)));
				ref PointF reference6 = ref array[2];
				reference6 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(18 + (j + 1) * 72)) * (double)width / 2.0), (int)((double)(y + height) - ((double)(height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(18 + (j + 1) * 72))) * (double)height / 2.0)));
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
			break;
		}
		case 1:
		case 4:
		{
			for (int i = 0; i < 5; i++)
			{
				ref PointF reference = ref array[0];
				reference = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(18 + i * 72)) * (double)width / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(18 + i * 72))) * (double)height / 2.0));
				ref PointF reference2 = ref array[1];
				reference2 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(54 + i * 72)) * (double)num4 / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(54 + i * 72))) * (double)num3 / 2.0));
				ref PointF reference3 = ref array[2];
				reference3 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(18 + (i + 1) * 72)) * (double)width / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct67.smethod_0(18 + (i + 1) * 72))) * (double)height / 2.0));
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
			}
			break;
		}
		}
		return graphicsPath;
	}
}
