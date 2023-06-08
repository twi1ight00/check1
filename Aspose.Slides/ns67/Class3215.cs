using System;

namespace ns67;

internal class Class3215 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_178;

	public Class3215(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(1000.0, base.AdjustValues["adj1"], 36745.0);
		double y = Class3089.smethod_2(0.0, 0.0, num);
		double val = Class3089.smethod_3(73490.0, y, 4.0);
		double val2 = Class3089.smethod_1(36745.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		double z = Math.Min(val, val2);
		double y2 = Class3089.smethod_0(1000.0, base.AdjustValues["adj3"], z);
		double y3 = Class3089.smethod_1(-4.0, y2, 1.0);
		double z2 = Class3089.smethod_2(73490.0, y3, num);
		double y4 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z2);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, 200000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cy, y4, 100000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y2, 100000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 73490.0, 200000.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num2);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double z3 = Class3089.smethod_2(x, num3, 0.0);
		double x2 = Class3089.smethod_2(num5, 0.0, z3);
		double num7 = Class3089.smethod_2(x2, 0.0, num3);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num7);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, num7);
		@class.method_5(num3, num3, 16200000.0, 21600000.0);
		@class.method_8();
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, y5);
		@class.method_5(num3, num3, 5400000.0, 21600000.0);
		@class.method_8();
		@class.method_3(num8, num5);
		@class.method_4(num9, num5);
		@class.method_4(num9, num6);
		@class.method_4(num8, num6);
		@class.method_8();
		@class.TextRectangle = new Class3457(num8, num5, num9, num6);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 23520.0);
		values.Add("adj2", 5880.0);
		values.Add("adj3", 11760.0);
	}
}
