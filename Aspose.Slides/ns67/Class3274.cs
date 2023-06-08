using System;

namespace ns67;

internal class Class3274 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_126;

	public Class3274(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 25000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_1(num, 1.0, 2.0);
		double num3 = Class3089.smethod_1(num, 1.0, 4.0);
		double x = Class3089.smethod_2(num, num2, 0.0);
		double x2 = Class3089.smethod_2(num, num, 0.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		Class3089.smethod_2(num4, 0.0, num2);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(num2, base.Transform2D.Extents.Cy);
		@class.method_5(num2, num2, 5400000.0, -5400000.0);
		@class.method_4(num2, num5);
		@class.method_5(num3, num3, 5400000.0, -10800000.0);
		@class.method_4(num, y2);
		@class.method_4(num, num2);
		@class.method_5(num2, num2, 10800000.0, 5400000.0);
		@class.method_4(x3, 0.0);
		@class.method_5(num2, num2, 16200000.0, 10800000.0);
		@class.method_4(num4, num);
		@class.method_4(num4, num5);
		@class.method_5(num2, num2, 0.0, 5400000.0);
		@class.method_8();
		@class.method_3(x2, num2);
		@class.method_5(num2, num2, 0.0, 5400000.0);
		@class.method_5(num3, num3, 5400000.0, 10800000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(x2, num2);
		@class.method_5(num2, num2, 0.0, 5400000.0);
		@class.method_5(num3, num3, 5400000.0, 10800000.0);
		@class.method_8();
		@class.method_3(num, num5);
		@class.method_5(num2, num2, 0.0, 16200000.0);
		@class.method_5(num3, num3, 16200000.0, 10800000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(num, y2);
		@class.method_4(num, num2);
		@class.method_5(num2, num2, 10800000.0, 5400000.0);
		@class.method_4(x3, 0.0);
		@class.method_5(num2, num2, 16200000.0, 10800000.0);
		@class.method_4(num4, num);
		@class.method_4(num4, num5);
		@class.method_5(num2, num2, 0.0, 5400000.0);
		@class.method_4(num2, base.Transform2D.Extents.Cy);
		@class.method_5(num2, num2, 5400000.0, 10800000.0);
		@class.method_8();
		@class.method_3(x, 0.0);
		@class.method_5(num2, num2, 16200000.0, 10800000.0);
		@class.method_5(num3, num3, 5400000.0, 10800000.0);
		@class.method_4(x2, num2);
		@class.method_3(num4, num);
		@class.method_4(x, num);
		@class.method_3(num2, y2);
		@class.method_5(num3, num3, 16200000.0, 10800000.0);
		@class.method_4(num, num5);
		@class.method_3(num2, base.Transform2D.Extents.Cy);
		@class.method_5(num2, num2, 5400000.0, -5400000.0);
		@class.method_4(num, y2);
		@class.TextRectangle = new Class3457(num, num, num4, num5);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 12500.0);
	}
}
