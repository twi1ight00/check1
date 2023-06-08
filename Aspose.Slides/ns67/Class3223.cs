using System;

namespace ns67;

internal class Class3223 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_42;

	public Class3223(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double y2 = Class3089.smethod_5(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		double x = Class3089.smethod_7(num3, y2);
		double y3 = Class3089.smethod_10(num2, y2);
		double z = Class3089.smethod_8(x, y3, 0.0);
		double x2 = Class3089.smethod_1(num2, num3, z);
		double y4 = Class3089.smethod_1(num, 1.0, 2.0);
		double num4 = Class3089.smethod_5(x2, y4);
		double y5 = Class3089.smethod_1(num4, 2.0, 1.0);
		double swingAngle = Class3089.smethod_2(-10800000.0, y5, 0.0);
		double x3 = Class3089.smethod_5(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		double num5 = Class3089.smethod_2(x3, 0.0, num4);
		double startAngle = Class3089.smethod_2(num5, 0.0, 10800000.0);
		double x4 = Class3089.smethod_7(num3, num5);
		double y6 = Class3089.smethod_10(num2, num5);
		double z2 = Class3089.smethod_8(x4, y6, 0.0);
		double x5 = Class3089.smethod_1(num2, num3, z2);
		double num6 = Class3089.smethod_7(x5, num5);
		double num7 = Class3089.smethod_10(x5, num5);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num6, 0.0);
		double y7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num7, 0.0);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num6);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double num8 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num9 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num8);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num8, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num9);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num9, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.method_3(x6, y7);
		@class.method_5(num3, num2, num5, swingAngle);
		@class.method_8();
		@class.method_3(x7, y8);
		@class.method_5(num3, num2, startAngle, swingAngle);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 18750.0);
	}
}
