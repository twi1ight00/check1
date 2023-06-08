using System;

namespace ns67;

internal class Class3209 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_125;

	public Class3209(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], 33333.0);
		double z = Class3089.smethod_2(100000.0, 0.0, num);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, base.Transform2D.Extents.Cx / 32.0);
		double z2 = Class3089.smethod_1(100000.0, y2, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y3 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z2);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y3, 100000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, -200000.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num5, num4);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, num5);
		double num8 = Class3089.smethod_2(num6, num4, 0.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num8);
		double num9 = Class3089.smethod_1(num8, 2.0, 1.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num9);
		double num10 = Class3089.smethod_2(num9, 0.0, num6);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num10);
		double num12 = Class3089.smethod_1(num, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 400000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, base.Transform2D.Extents.Cx / 32.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cx / 32.0, 0.0);
		double y6 = Class3089.smethod_2(num6, num12, 0.0);
		double y7 = Class3089.smethod_2(num11, 0.0, num12);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, num8);
		@class.method_4(num2, 0.0);
		@class.method_4(num2, num6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num6);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 16200000.0, 10800000.0);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -10800000.0);
		@class.method_4(num3, num11);
		@class.method_4(num3, y5);
		@class.method_4(base.Transform2D.Extents.Cx, y4);
		@class.method_4(num3, base.Transform2D.Extents.Cy);
		@class.method_4(num3, num7);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num7);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 5400000.0, 5400000.0);
		@class.method_4(x, num10);
		@class.method_4(num2, num10);
		@class.method_4(num2, num9);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(x2, y6);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 0.0, 5400000.0);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -10800000.0);
		@class.method_4(x2, num11);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, num8);
		@class.method_4(num2, 0.0);
		@class.method_4(num2, num6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num6);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 16200000.0, 10800000.0);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -10800000.0);
		@class.method_4(num3, num11);
		@class.method_4(num3, y5);
		@class.method_4(base.Transform2D.Extents.Cx, y4);
		@class.method_4(num3, base.Transform2D.Extents.Cy);
		@class.method_4(num3, num7);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num7);
		@class.method_5(num12, base.Transform2D.Extents.Cx / 32.0, 5400000.0, 5400000.0);
		@class.method_4(x, num10);
		@class.method_4(num2, num10);
		@class.method_4(num2, num9);
		@class.method_8();
		@class.method_3(x2, y6);
		@class.method_4(x2, num11);
		@class.method_3(x, y7);
		@class.method_4(x, num10);
		@class.TextRectangle = new Class3457(num2, num6, num3, num7);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
		values.Add("adj2", 50000.0);
		values.Add("adj3", 16667.0);
	}
}
