using System;

namespace ns67;

internal class Class3190 : Class3091
{
	public override Enum493 Kind => Enum493.const_174;

	public Class3190(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 1.0, 20.0);
		double num = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, z);
		double heightRadius = Class3089.smethod_2(base.Transform2D.Extents.Cy / 4.0, 0.0, z);
		double x = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 480000.0);
		double y = Class3089.smethod_10(base.Transform2D.Extents.Cy / 4.0, 480000.0);
		double num2 = Class3089.smethod_5(x, y);
		double num3 = Class3089.smethod_1(num2, 2.0, 1.0);
		double num4 = Class3089.smethod_2(10800000.0, 0.0, num2);
		double swingAngle = Class3089.smethod_2(10800000.0, num3, 0.0);
		double swingAngle2 = Class3089.smethod_2(10800000.0, 0.0, num3);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, 1.0, 4.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 4.0, 1.0, 4.0);
		double x2 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 4.0, num4);
		double y2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num4);
		double z2 = Class3089.smethod_8(x2, y2, 0.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy / 4.0, z2);
		double y3 = Class3089.smethod_7(x3, num4);
		double y4 = Class3089.smethod_10(x3, num4);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y3, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 4.0, y4, 0.0);
		double x5 = Class3089.smethod_7(num6, num2);
		double y6 = Class3089.smethod_10(num5, num2);
		double z3 = Class3089.smethod_8(x5, y6, 0.0);
		double x6 = Class3089.smethod_1(num5, num6, z3);
		double y7 = Class3089.smethod_7(x6, num2);
		double y8 = Class3089.smethod_10(x6, num2);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y7, 0.0);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num6);
		double y9 = Class3089.smethod_2(x8, y8, 0.0);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		Class3089.smethod_1(10800000.0, 2.0, 1.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x4, y5);
		@class.method_5(base.Transform2D.Extents.Cy / 4.0, base.Transform2D.Extents.Cx / 2.0, num4, swingAngle);
		@class.method_4(x7, y9);
		@class.method_5(num6, num5, num2, swingAngle2);
		@class.method_8();
		@class.method_3(x9, base.Transform2D.Extents.Cy / 4.0);
		@class.method_5(heightRadius, num, 10800000.0, -21600000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
