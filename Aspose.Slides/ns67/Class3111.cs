using System;

namespace ns67;

internal class Class3111 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_88;

	public Class3111(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 21599999.0);
		double num3 = Class3089.smethod_2(num2, 0.0, num);
		double z = Class3089.smethod_2(num3, 21600000.0, 0.0);
		double num4 = Class3089.smethod_4(num3, num3, z);
		double z2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num);
		double y = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num);
		double y2 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y, z2);
		double y3 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y, z2);
		double z3 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num2);
		double y4 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num2);
		double y5 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y4, z3);
		double y6 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y4, z3);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y2, 0.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y3, 0.0);
		double val = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y5, 0.0);
		double val2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y6, 0.0);
		double z4 = Class3089.smethod_2(21600000.0, 0.0, num);
		double x = Class3089.smethod_2(num4, 0.0, z4);
		double z5 = Math.Max(num5, val);
		double right = Class3089.smethod_4(x, base.Transform2D.Extents.Cx, z5);
		double num7 = Class3089.smethod_2(5400000.0, 0.0, num);
		double z6 = Class3089.smethod_2(27000000.0, 0.0, num);
		double z7 = Class3089.smethod_4(num7, num7, z6);
		double x2 = Class3089.smethod_2(num4, 0.0, z7);
		double z8 = Math.Max(num6, val2);
		double bottom = Class3089.smethod_4(x2, base.Transform2D.Extents.Cy, z8);
		double num8 = Class3089.smethod_2(10800000.0, 0.0, num);
		double z9 = Class3089.smethod_2(32400000.0, 0.0, num);
		double z10 = Class3089.smethod_4(num8, num8, z9);
		double x3 = Class3089.smethod_2(num4, 0.0, z10);
		double z11 = Math.Min(num5, val);
		double left = Class3089.smethod_4(x3, 0.0, z11);
		double num9 = Class3089.smethod_2(16200000.0, 0.0, num);
		double z12 = Class3089.smethod_2(37800000.0, 0.0, num);
		double z13 = Class3089.smethod_4(num9, num9, z12);
		double x4 = Class3089.smethod_2(num4, 0.0, z13);
		double z14 = Math.Min(num6, val2);
		double top = Class3089.smethod_4(x4, 0.0, z14);
		double x5 = Class3089.smethod_2(num, 0.0, 5400000.0);
		double y7 = Class3089.smethod_2(num2, 5400000.0, 0.0);
		Class3089.smethod_3(x5, y7, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(num5, num6);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, num4);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(num5, num6);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, num4);
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 16200000.0);
		values.Add("adj2", 0.0);
	}
}
