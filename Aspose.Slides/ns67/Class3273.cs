using System;

namespace ns67;

internal class Class3273 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	private const string string_3 = "adj4";

	private const string string_4 = "adj5";

	public override Enum493 Kind => Enum493.const_63;

	public Class3273(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 25000.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double z2 = Class3089.smethod_1(num2, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), base.Transform2D.Extents.Cy);
		double x = Class3089.smethod_2(100000.0, 0.0, z2);
		double z3 = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double num3 = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z3);
		double x2 = Class3089.smethod_2(num3, num2, 0.0);
		double x3 = Class3089.smethod_1(x2, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), base.Transform2D.Extents.Cy);
		double y = Class3089.smethod_0(x3, base.AdjustValues["adj5"], 100000.0);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num2, 100000.0);
		double num5 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num, 100000.0);
		double z4 = Class3089.smethod_1(num4, 1.0, 2.0);
		double num6 = Class3089.smethod_2(num5, 0.0, z4);
		double num7 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double z5 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num3, 100000.0);
		double num8 = Class3089.smethod_2(num7, 0.0, z5);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num6);
		double val = Class3089.smethod_1(x4, 1.0, 2.0);
		double x5 = Math.Min(val, num8);
		double z6 = Class3089.smethod_1(x5, 100000.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj4"], z6);
		double num9 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double val2 = Class3089.smethod_2(num9, 0.0, num4);
		double num10 = Math.Max(val2, 0.0);
		double num11 = Class3089.smethod_2(num4, num10, 0.0);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num5);
		double x7 = Class3089.smethod_2(x6, 0.0, num5);
		double num12 = Class3089.smethod_2(x7, num6, 0.0);
		double x8 = Class3089.smethod_2(x4, 0.0, num9);
		Class3089.smethod_2(num12, 0.0, num10);
		Class3089.smethod_3(num4, num12, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, num9);
		@class.method_5(num9, num9, 10800000.0, 5400000.0);
		@class.method_4(x8, 0.0);
		@class.method_5(num9, num9, 16200000.0, 5400000.0);
		@class.method_4(x4, num8);
		@class.method_4(base.Transform2D.Extents.Cx, num8);
		@class.method_4(x6, num7);
		@class.method_4(x7, num8);
		@class.method_4(num12, num8);
		@class.method_4(num12, num11);
		@class.method_5(num10, num10, 0.0, -5400000.0);
		@class.method_4(num11, num4);
		@class.method_5(num10, num10, 16200000.0, -5400000.0);
		@class.method_4(num4, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 25000.0);
		values.Add("adj2", 25000.0);
		values.Add("adj3", 25000.0);
		values.Add("adj4", 43750.0);
		values.Add("adj5", 75000.0);
	}
}
