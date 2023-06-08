using System;

namespace ns67;

internal class Class3218 : Class3091
{
	private const string string_0 = "adj1";

	public override Enum493 Kind => Enum493.const_177;

	public Class3218(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 51965.0);
		double y2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double y3 = Class3089.smethod_5(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		double x = Class3089.smethod_10(1.0, y3);
		double x2 = Class3089.smethod_7(1.0, y3);
		double num = Class3089.smethod_11(1.0, y3);
		double x3 = Class3089.smethod_8(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, 0.0);
		double z = Class3089.smethod_1(x3, 51965.0, 100000.0);
		double y4 = Class3089.smethod_2(x3, 0.0, z);
		double num2 = Class3089.smethod_1(x2, y4, 2.0);
		double num3 = Class3089.smethod_1(x, y4, 2.0);
		double num4 = Class3089.smethod_1(x, y2, 2.0);
		double num5 = Class3089.smethod_1(x2, y2, 2.0);
		double num6 = Class3089.smethod_2(num2, 0.0, num4);
		double num7 = Class3089.smethod_2(num3, num5, 0.0);
		double num8 = Class3089.smethod_2(num2, num4, 0.0);
		double num9 = Class3089.smethod_2(num3, 0.0, num5);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num8);
		double x5 = Class3089.smethod_1(x4, num, 1.0);
		double num10 = Class3089.smethod_2(x5, num9, 0.0);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num8);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num6);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double num12 = Class3089.smethod_1(x7, 1.0, num);
		double x8 = Class3089.smethod_2(num11, 0.0, num12);
		double x9 = Class3089.smethod_2(num6, num12, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num7);
		double num13 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num9);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num10);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num6, num7);
		@class.method_4(num8, num9);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num10);
		@class.method_4(x6, num9);
		@class.method_4(num11, num7);
		@class.method_4(x8, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num11, y5);
		@class.method_4(x6, num13);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, y6);
		@class.method_4(num8, num13);
		@class.method_4(num6, y5);
		@class.method_4(x9, base.Transform2D.Extents.Cy / 2.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num6, num9, num11, num13);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 23520.0);
	}
}
