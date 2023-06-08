using System;

namespace ns67;

internal class Class3153 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_129;

	public Class3153(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 12500.0);
		double y2 = Class3089.smethod_0(-10000.0, base.AdjustValues["adj2"], 10000.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double num2 = Class3089.smethod_1(num, 10.0, 3.0);
		double y3 = Class3089.smethod_2(num, 0.0, num2);
		double y4 = Class3089.smethod_2(num, num2, 0.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double y5 = Class3089.smethod_2(num3, 0.0, num2);
		double y6 = Class3089.smethod_2(num3, num2, 0.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y2, 100000.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y2, 50000.0);
		double z = Math.Abs(num4);
		double num6 = Class3089.smethod_4(num5, 0.0, num5);
		double num7 = Class3089.smethod_2(0.0, 0.0, num6);
		double num8 = Class3089.smethod_4(num5, num5, 0.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num8);
		double y7 = Class3089.smethod_3(num6, num9, 6.0);
		double x = Class3089.smethod_2(num7, y7, 0.0);
		double y8 = Class3089.smethod_3(num6, num9, 3.0);
		double x2 = Class3089.smethod_2(num7, y8, 0.0);
		double x3 = Class3089.smethod_3(num7, num9, 2.0);
		double x4 = Class3089.smethod_2(x3, y7, 0.0);
		double x5 = Class3089.smethod_3(x4, num9, 2.0);
		double num10 = Class3089.smethod_2(0.0, num8, 0.0);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cx, num6, 0.0);
		double x6 = Class3089.smethod_2(num10, y7, 0.0);
		double x7 = Class3089.smethod_2(num10, y8, 0.0);
		double x8 = Class3089.smethod_3(num10, num11, 2.0);
		double x9 = Class3089.smethod_2(x8, y7, 0.0);
		double x10 = Class3089.smethod_3(x9, num11, 2.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double left = Math.Max(num7, num10);
		double right = Math.Min(num9, num11);
		double num12 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 50000.0);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num12);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num7, num);
		@class.method_6(new Struct159(x, y3), new Struct159(x2, y4), new Struct159(x3, num));
		@class.method_6(new Struct159(x4, y3), new Struct159(x5, y4), new Struct159(num9, num));
		@class.method_4(num11, num3);
		@class.method_6(new Struct159(x10, y6), new Struct159(x9, y5), new Struct159(x8, num3));
		@class.method_6(new Struct159(x7, y6), new Struct159(x6, y5), new Struct159(num10, num3));
		@class.method_8();
		@class.TextRectangle = new Class3457(left, num12, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 6250.0);
		values.Add("adj2", 0.0);
	}
}
