using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class61 : Class18
{
	internal Class61(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		float num3 = 0f;
		num3 = ((class898_0.class885_0.arrayList_0.Count <= 0) ? 0.17f : (1f - Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
		new RectangleF(num, num2, width, height);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		float num4 = num3 * width;
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		PointF[] array = new PointF[5];
		PointF[] array2 = new PointF[3];
		switch (class898_0.int_2)
		{
		case 1:
		{
			PointF pointF = new PointF(num, num2);
			PointF pointF2 = new PointF(num + width, num2);
			PointF pointF3 = new PointF(num + width, num2 + height - num4);
			PointF pointF4 = new PointF(num + width - num4, num2 + height);
			PointF pointF5 = new PointF(num, num2 + height);
			PointF pointF6 = new PointF(num + width - 0.8f * num4, num2 + height - 0.8f * num4);
			array[0] = pointF;
			array[1] = pointF2;
			array[2] = pointF3;
			array[3] = pointF4;
			array[4] = pointF5;
			array2[0] = pointF3;
			array2[1] = pointF4;
			array2[2] = pointF6;
			break;
		}
		case 2:
		{
			PointF pointF = new PointF(num, num2);
			PointF pointF2 = new PointF(num + width - num4, num2);
			PointF pointF3 = new PointF(num + width, num2 + num4);
			PointF pointF4 = new PointF(num + width, num2 + height);
			PointF pointF5 = new PointF(num, num2 + height);
			PointF pointF6 = new PointF(num + width - 0.8f * num4, num2 + 0.8f * num4);
			array[0] = pointF;
			array[1] = pointF2;
			array[2] = pointF3;
			array[3] = pointF4;
			array[4] = pointF5;
			array2[0] = pointF2;
			array2[1] = pointF3;
			array2[2] = pointF6;
			break;
		}
		case 3:
		{
			PointF pointF = new PointF(num + num4, num2);
			PointF pointF2 = new PointF(num + width, num2);
			PointF pointF3 = new PointF(num + width, num2 + height);
			PointF pointF4 = new PointF(num, num2 + height);
			PointF pointF5 = new PointF(num, num2 + num4);
			PointF pointF6 = new PointF(num + 0.8f * num4, num2 + 0.8f * num4);
			array[0] = pointF;
			array[1] = pointF2;
			array[2] = pointF3;
			array[3] = pointF4;
			array[4] = pointF5;
			array2[0] = pointF;
			array2[1] = pointF5;
			array2[2] = pointF6;
			break;
		}
		case 4:
		{
			PointF pointF = new PointF(num, num2);
			PointF pointF2 = new PointF(num + width, num2);
			PointF pointF3 = new PointF(num + width, num2 + height);
			PointF pointF4 = new PointF(num + num4, num2 + height);
			PointF pointF5 = new PointF(num, num2 + height - num4);
			PointF pointF6 = new PointF(num + 0.8f * num4, num2 + height - 0.8f * num4);
			array[0] = pointF;
			array[1] = pointF2;
			array[2] = pointF3;
			array[3] = pointF4;
			array[4] = pointF5;
			array2[0] = pointF4;
			array2[1] = pointF5;
			array2[2] = pointF6;
			break;
		}
		}
		if (!class898_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(array);
			Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
			interface42_0.imethod_35(brush_, array);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(array2);
			Brush brush_2 = Struct69.smethod_1(class898_0.Fill, graphicsPath2, 0.8f, 0f);
			interface42_0.imethod_35(brush_2, array2);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_20(pen_, array);
			interface42_0.imethod_20(pen_, array2);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
