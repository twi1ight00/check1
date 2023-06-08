using System;

namespace ns67;

internal class Class3110 : Class3091
{
	public override Enum493 Kind => Enum493.const_170;

	public Class3110(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 8.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double x3 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 4.0);
		double y2 = Class3089.smethod_1(x3, 1.0, 8.0);
		double y3 = Class3089.smethod_1(x3, 5.0, 16.0);
		double y4 = Class3089.smethod_1(x3, 5.0, 8.0);
		double y5 = Class3089.smethod_1(x3, 11.0, 16.0);
		double y6 = Class3089.smethod_1(x3, 3.0, 4.0);
		double y7 = Class3089.smethod_1(x3, 7.0, 8.0);
		double y8 = Class3089.smethod_2(num2, y2, 0.0);
		double y9 = Class3089.smethod_2(num2, y3, 0.0);
		double y10 = Class3089.smethod_2(num2, y5, 0.0);
		double y11 = Class3089.smethod_2(num2, y7, 0.0);
		double x4 = Class3089.smethod_2(x, y3, 0.0);
		double x5 = Class3089.smethod_2(x, y4, 0.0);
		double x6 = Class3089.smethod_2(x, y6, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_3(x, y9);
		@class.method_4(x, y10);
		@class.method_4(x4, y10);
		@class.method_4(x5, y);
		@class.method_4(x5, num2);
		@class.method_4(x4, y9);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_1, extrusionOk: false, stroke: false);
		@class.method_3(x, y9);
		@class.method_4(x, y10);
		@class.method_4(x4, y10);
		@class.method_4(x5, y);
		@class.method_4(x5, num2);
		@class.method_4(x4, y9);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x, y9);
		@class.method_4(x4, y9);
		@class.method_4(x5, num2);
		@class.method_4(x5, y);
		@class.method_4(x4, y10);
		@class.method_4(x, y10);
		@class.method_8();
		@class.method_3(x6, y9);
		@class.method_4(x2, y8);
		@class.method_3(x6, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x2, base.Transform2D.Extents.Cy / 2.0);
		@class.method_3(x6, y10);
		@class.method_4(x2, y11);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
