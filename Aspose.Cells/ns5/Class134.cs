using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class134 : Class18
{
	internal Class134(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangleF);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_31(brush_, rectangleF);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_10(pen_, num, num2, width, height);
			interface42_0.imethod_16(pen_, num + width / 2f + (float)((double)(width / 2f) * Math.Cos(Struct67.smethod_0(45.0))), num2 + height / 2f - (float)((double)(height / 2f) * Math.Sin(Struct67.smethod_0(45.0))), num + width / 2f + (float)((double)(width / 2f) * Math.Cos(Struct67.smethod_0(225.0))), num2 + height / 2f - (float)((double)(height / 2f) * Math.Sin(Struct67.smethod_0(225.0))));
			interface42_0.imethod_16(pen_, num + width / 2f + (float)((double)(width / 2f) * Math.Cos(Struct67.smethod_0(135.0))), num2 + height / 2f - (float)((double)(height / 2f) * Math.Sin(Struct67.smethod_0(135.0))), num + width / 2f + (float)((double)(width / 2f) * Math.Cos(Struct67.smethod_0(315.0))), num2 + height / 2f - (float)((double)(height / 2f) * Math.Sin(Struct67.smethod_0(315.0))));
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
