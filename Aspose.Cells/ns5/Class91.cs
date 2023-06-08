using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class91 : Class18
{
	internal Class91(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
		switch (class898_0.int_2)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class898_0.Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class898_0.Width, class898_0.Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class898_0.Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		if (class898_0.class885_0.arrayList_0.Count == 3)
		{
			num = width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num2 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num3 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
			num4 = height * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num5 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[2]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			num = width * 9146f / 21600f;
			num2 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num3 = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
			num4 = height * 9146f / 21600f;
			num5 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num6 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f;
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			num = width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num2 = width * 18486f / 21600f;
			num3 = width * 6314f / 21600f;
			num4 = height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f;
			num5 = height * 18486f / 21600f;
			num6 = height * 6314f / 21600f;
		}
		else
		{
			num = width * 9146f / 21600f;
			num2 = width * 18486f / 21600f;
			num3 = width * 6314f / 21600f;
			num4 = height * 9146f / 21600f;
			num5 = height * 18486f / 21600f;
			num6 = height * 6314f / 21600f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(new PointF[12]
		{
			new PointF(x, y + (height - num4) / 2f + num4),
			new PointF(x + num3, y + num4),
			new PointF(x + num3, y + (height - num5) + num4),
			new PointF(x + num + (width - num2), y + (height - num5) + num4),
			new PointF(x + num + (width - num2), y + num6),
			new PointF(x + num, y + num6),
			new PointF(x + num + (width - num) / 2f, y),
			new PointF(x + width, y + num6),
			new PointF(x + num2, y + num6),
			new PointF(x + num2, y + num5),
			new PointF(x + num3, y + num5),
			new PointF(x + num3, y + height)
		});
		return graphicsPath;
	}
}
