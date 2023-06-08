using System;

namespace ns67;

internal class Class3108 : Class3091
{
	public override Enum493 Kind => Enum493.const_171;

	public Class3108(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 8.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double x4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 4.0);
		double y = Class3089.smethod_1(x4, 1455.0, 21600.0);
		double y2 = Class3089.smethod_1(x4, 1905.0, 21600.0);
		double y3 = Class3089.smethod_1(x4, 2325.0, 21600.0);
		double y4 = Class3089.smethod_1(x4, 16155.0, 21600.0);
		double y5 = Class3089.smethod_1(x4, 17010.0, 21600.0);
		double y6 = Class3089.smethod_1(x4, 19335.0, 21600.0);
		double y7 = Class3089.smethod_1(x4, 19725.0, 21600.0);
		double y8 = Class3089.smethod_1(x4, 20595.0, 21600.0);
		double y9 = Class3089.smethod_1(x4, 5280.0, 21600.0);
		double y10 = Class3089.smethod_1(x4, 5730.0, 21600.0);
		double y11 = Class3089.smethod_1(x4, 6630.0, 21600.0);
		double y12 = Class3089.smethod_1(x4, 7492.0, 21600.0);
		double y13 = Class3089.smethod_1(x4, 9067.0, 21600.0);
		double y14 = Class3089.smethod_1(x4, 9555.0, 21600.0);
		double y15 = Class3089.smethod_1(x4, 13342.0, 21600.0);
		double y16 = Class3089.smethod_1(x4, 14580.0, 21600.0);
		double y17 = Class3089.smethod_1(x4, 15592.0, 21600.0);
		double num2 = Class3089.smethod_2(x2, y, 0.0);
		double x5 = Class3089.smethod_2(x2, y2, 0.0);
		double x6 = Class3089.smethod_2(x2, y3, 0.0);
		double x7 = Class3089.smethod_2(x2, y4, 0.0);
		double x8 = Class3089.smethod_2(x2, y5, 0.0);
		double x9 = Class3089.smethod_2(x2, y6, 0.0);
		double x10 = Class3089.smethod_2(x2, y7, 0.0);
		double x11 = Class3089.smethod_2(x2, y8, 0.0);
		double y18 = Class3089.smethod_2(x, y9, 0.0);
		double y19 = Class3089.smethod_2(x, y10, 0.0);
		double y20 = Class3089.smethod_2(x, y11, 0.0);
		double y21 = Class3089.smethod_2(x, y12, 0.0);
		double y22 = Class3089.smethod_2(x, y13, 0.0);
		double y23 = Class3089.smethod_2(x, y14, 0.0);
		double y24 = Class3089.smethod_2(x, y15, 0.0);
		double y25 = Class3089.smethod_2(x, y16, 0.0);
		double y26 = Class3089.smethod_2(x, y17, 0.0);
		Class3089.smethod_2(x, num2, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_3(x2, y18);
		@class.method_4(x2, y23);
		@class.method_4(num2, y23);
		@class.method_4(x5, y22);
		@class.method_4(x6, y22);
		@class.method_4(x6, y26);
		@class.method_4(x8, y26);
		@class.method_4(x8, y24);
		@class.method_4(x9, y24);
		@class.method_4(x11, y25);
		@class.method_4(x3, y25);
		@class.method_4(x3, y20);
		@class.method_4(x11, y20);
		@class.method_4(x10, y21);
		@class.method_4(x8, y21);
		@class.method_4(x8, y20);
		@class.method_4(x7, y19);
		@class.method_4(x5, y19);
		@class.method_4(num2, y18);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_1, extrusionOk: false, stroke: false);
		@class.method_3(x2, y18);
		@class.method_4(x2, y23);
		@class.method_4(num2, y23);
		@class.method_4(x5, y22);
		@class.method_4(x6, y22);
		@class.method_4(x6, y26);
		@class.method_4(x8, y26);
		@class.method_4(x8, y24);
		@class.method_4(x9, y24);
		@class.method_4(x11, y25);
		@class.method_4(x3, y25);
		@class.method_4(x3, y20);
		@class.method_4(x11, y20);
		@class.method_4(x10, y21);
		@class.method_4(x8, y21);
		@class.method_4(x8, y20);
		@class.method_4(x7, y19);
		@class.method_4(x5, y19);
		@class.method_4(num2, y18);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x2, y18);
		@class.method_4(num2, y18);
		@class.method_4(x5, y19);
		@class.method_4(x7, y19);
		@class.method_4(x8, y20);
		@class.method_4(x8, y21);
		@class.method_4(x10, y21);
		@class.method_4(x11, y20);
		@class.method_4(x3, y20);
		@class.method_4(x3, y25);
		@class.method_4(x11, y25);
		@class.method_4(x9, y24);
		@class.method_4(x8, y24);
		@class.method_4(x8, y26);
		@class.method_4(x6, y26);
		@class.method_4(x6, y22);
		@class.method_4(x5, y22);
		@class.method_4(num2, y23);
		@class.method_4(x2, y23);
		@class.method_8();
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
