using System;

namespace ns67;

internal class Class3123 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_94;

	public Class3123(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 25000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 50000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num3 = Class3089.smethod_1(num, 29289.0, 100000.0);
		double num4 = Class3089.smethod_2(num, num3, 0.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num4);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(num2, base.Transform2D.Extents.Cy);
		@class.method_5(num, num, 5400000.0, 5400000.0);
		@class.method_4(num, y3);
		@class.method_5(num, num, 0.0, -5400000.0);
		@class.method_5(num, num, 5400000.0, -5400000.0);
		@class.method_4(num, num);
		@class.method_5(num, num, 10800000.0, 5400000.0);
		@class.method_4(x, 0.0);
		@class.method_5(num, num, 16200000.0, 5400000.0);
		@class.method_4(x2, y2);
		@class.method_5(num, num, 10800000.0, -5400000.0);
		@class.method_5(num, num, 16200000.0, -5400000.0);
		@class.method_4(x2, y4);
		@class.method_5(num, num, 0.0, 5400000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(num2, base.Transform2D.Extents.Cy);
		@class.method_5(num, num, 5400000.0, 5400000.0);
		@class.method_4(num, y3);
		@class.method_5(num, num, 0.0, -5400000.0);
		@class.method_5(num, num, 5400000.0, -5400000.0);
		@class.method_4(num, num);
		@class.method_5(num, num, 10800000.0, 5400000.0);
		@class.method_3(x, 0.0);
		@class.method_5(num, num, 16200000.0, 5400000.0);
		@class.method_4(x2, y2);
		@class.method_5(num, num, 10800000.0, -5400000.0);
		@class.method_5(num, num, 16200000.0, -5400000.0);
		@class.method_4(x2, y4);
		@class.method_5(num, num, 0.0, 5400000.0);
		@class.TextRectangle = new Class3457(num4, num4, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 8333.0);
	}
}
