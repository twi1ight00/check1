using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class170 : Class160
{
	internal Class170(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		float num3 = 0f;
		RectangleF rect = new RectangleF(num, num2, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		num3 = ((class913_0.class901_0 == null) ? 0.14f : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 0.14f : (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
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
		PointF[] pointF_5 = new PointF[4] { pointF5, pointF6, pointF7, pointF8 };
		if (!class913_0.Fill.method_0())
		{
			interface42_0.imethod_35(brush_, pointF_);
			interface42_0.imethod_35(brush_, pointF_2);
			interface42_0.imethod_35(brush_, pointF_3);
			interface42_0.imethod_35(brush_, pointF_4);
			interface42_0.imethod_35(brush_, pointF_5);
		}
		if (!class913_0.Line.method_0())
		{
			interface42_0.imethod_20(pen_, pointF_);
			interface42_0.imethod_20(pen_, pointF_2);
			interface42_0.imethod_20(pen_, pointF_3);
			interface42_0.imethod_20(pen_, pointF_4);
			interface42_0.imethod_20(pen_, pointF_5);
		}
		base.vmethod_4();
	}
}
