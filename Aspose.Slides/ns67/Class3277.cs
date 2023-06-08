using System;

namespace ns67;

internal class Class3277 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_116;

	public Class3277(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj2"], 100000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		Class3089.smethod_2(num3, 0.0, base.Transform2D.Extents.Cx / 2.0);
		Class3089.smethod_2(num4, 0.0, base.Transform2D.Extents.Cy / 2.0);
		double value = Class3089.smethod_1(num, base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx);
		double x = Math.Abs(num2);
		double z = Math.Abs(value);
		double x2 = Class3089.smethod_2(x, 0.0, z);
		double y = Class3089.smethod_4(num, 7.0, 2.0);
		double y2 = Class3089.smethod_4(num, 10.0, 5.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y, 12.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y2, 12.0);
		double y3 = Class3089.smethod_4(num2, 7.0, 2.0);
		double y4 = Class3089.smethod_4(num2, 10.0, 5.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y3, 12.0);
		double y5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y4, 12.0);
		double z2 = Class3089.smethod_4(num, 0.0, num3);
		double x4 = Class3089.smethod_4(x2, 0.0, z2);
		double y6 = Class3089.smethod_4(num2, num5, num3);
		double x5 = Class3089.smethod_4(x2, y6, num5);
		double z3 = Class3089.smethod_4(num, num3, base.Transform2D.Extents.Cx);
		double x6 = Class3089.smethod_4(x2, base.Transform2D.Extents.Cx, z3);
		double y7 = Class3089.smethod_4(num2, num3, num5);
		double x7 = Class3089.smethod_4(x2, y7, num5);
		double z4 = Class3089.smethod_4(num, num6, num4);
		double y8 = Class3089.smethod_4(x2, num6, z4);
		double y9 = Class3089.smethod_4(num2, 0.0, num4);
		double y10 = Class3089.smethod_4(x2, y9, 0.0);
		double z5 = Class3089.smethod_4(num, num4, num6);
		double y11 = Class3089.smethod_4(x2, num6, z5);
		double y12 = Class3089.smethod_4(num2, num4, base.Transform2D.Extents.Cy);
		double y13 = Class3089.smethod_4(x2, y12, base.Transform2D.Extents.Cy);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(num5, 0.0);
		@class.method_4(x5, y10);
		@class.method_4(x3, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num6);
		@class.method_4(x6, y11);
		@class.method_4(base.Transform2D.Extents.Cx, y5);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(x3, base.Transform2D.Extents.Cy);
		@class.method_4(x7, y13);
		@class.method_4(num5, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, y5);
		@class.method_4(x4, y8);
		@class.method_4(0.0, num6);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", -20833.0);
		values.Add("adj2", 62500.0);
	}
}
