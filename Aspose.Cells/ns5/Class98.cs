using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class98 : Class18
{
	internal Class98(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.Width;
		float height = class898_0.Height;
		float num3 = 0f;
		float num4 = 0f;
		RectangleF rect = new RectangleF(num, num2, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (class898_0.class885_0.arrayList_0.Count == 2)
		{
			num4 = width - width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			num3 = height - 2f * (height * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) / 21600f);
		}
		else if (class898_0.class885_0.arrayList_0.Count == 1)
		{
			if (((Class882)class898_0.class885_0.arrayList_0[0]).Value == 327)
			{
				num3 = height - 2f * (height * 0.27027777f);
				num4 = width - width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
			}
			else
			{
				num3 = width - width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f);
				num4 = width - width * 0.7558333f;
			}
		}
		else
		{
			num4 = width - width * 0.7558333f;
			num3 = height - 2f * (height * 0.27027777f);
		}
		float num5 = width - num4;
		float num6 = (height - num3) / 2f;
		float height2 = height - 2f * num6;
		float num7 = width;
		float width2 = 0.03333f * num7;
		float width3 = 0.06065f * num7;
		RectangleF rectangleF_ = new RectangleF(num, num2 + num6, width2, height2);
		RectangleF rectangleF_2 = new RectangleF(num + 0.06444f * num7, num2 + num6, width3, height2);
		PointF[] array = new PointF[7];
		GraphicsPath graphicsPath2 = new GraphicsPath();
		ref PointF reference = ref array[0];
		reference = new PointF(num + 0.15777f * num7, num2 + num6);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(num + num5, num2 + num6);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(num + num5, num2);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(num + width, num2 + height / 2f);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(num + num5, num2 + height);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(num + num5, num2 + height - num6);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(num + 0.15777f * num7, num2 + height - num6);
		graphicsPath2.AddPolygon(array);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_37(brush_, rectangleF_);
			interface42_0.imethod_37(brush_, rectangleF_2);
			interface42_0.imethod_33(brush_, graphicsPath2);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_23(pen_, num, num2 + num6, width2, height2);
			interface42_0.imethod_23(pen_, num + 0.06444f * num7, num2 + num6, width3, height2);
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		base.vmethod_4();
	}
}
