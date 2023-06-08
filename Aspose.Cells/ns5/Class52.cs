using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class52 : Class18
{
	internal Class52(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		float num3 = 0f;
		new RectangleF(num, num2, width, height);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		num3 = ((arrayList_.Count <= 0) ? 0.14f : (Convert.ToSingle(((Class882)arrayList_[0]).Value) / 21600f));
		PointF pointF = new PointF(num, num2);
		PointF pointF2 = new PointF(num + width, num2);
		PointF pointF3 = new PointF(num + width, num2 + height);
		PointF pointF4 = new PointF(num, num2 + height);
		PointF pointF5 = new PointF(num + num3 * width, num2 + num3 * height);
		PointF pointF6 = new PointF(num + (1f - num3) * width, num2 + num3 * height);
		PointF pointF7 = new PointF(num + (1f - num3) * width, num2 + (1f - num3) * height);
		PointF pointF8 = new PointF(num + num3 * width, num2 + (1f - num3) * height);
		PointF[] pointF_ = new PointF[4] { pointF, pointF2, pointF6, pointF5 };
		PointF[] pointF_2 = new PointF[4] { pointF2, pointF3, pointF7, pointF6 };
		PointF[] pointF_3 = new PointF[4] { pointF3, pointF4, pointF8, pointF7 };
		PointF[] pointF_4 = new PointF[4] { pointF4, pointF, pointF5, pointF8 };
		PointF[] array = new PointF[4] { pointF5, pointF6, pointF7, pointF8 };
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(array);
		Brush brush_ = Struct69.smethod_1(class898_0.Fill, graphicsPath, 0.6f, 0f);
		Brush brush_2 = Struct69.smethod_1(class898_0.Fill, graphicsPath, 0.8f, 0f);
		Brush brush_3 = Struct69.smethod_1(class898_0.Fill, graphicsPath, 1f, 0f);
		Brush brush_4 = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_35(brush_3, pointF_);
			interface42_0.imethod_35(brush_, pointF_2);
			interface42_0.imethod_35(brush_2, pointF_3);
			interface42_0.imethod_35(brush_3, pointF_4);
			interface42_0.imethod_35(brush_4, array);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_20(pen_, pointF_);
			interface42_0.imethod_20(pen_, pointF_2);
			interface42_0.imethod_20(pen_, pointF_3);
			interface42_0.imethod_20(pen_, pointF_4);
			interface42_0.imethod_20(pen_, array);
		}
		base.vmethod_4();
	}
}
