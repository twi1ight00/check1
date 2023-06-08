using System;

namespace ns67;

internal class Class3233 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	private const string string_3 = "adj4";

	public override Enum493 Kind => Enum493.const_61;

	public Class3233(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 50000.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double z2 = Class3089.smethod_2(50000.0, 0.0, num);
		double num3 = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z2);
		double z3 = Class3089.smethod_1(num3, 2.0, 1.0);
		double z4 = Class3089.smethod_2(100000.0, 0.0, z3);
		double y = Class3089.smethod_0(num2, base.AdjustValues["adj4"], z4);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num, 100000.0);
		double num5 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num2, 200000.0);
		double num6 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num3, 100000.0);
		double num7 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y, 200000.0);
		double num8 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num6);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num7);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num7, 0.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num6);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num8);
		double num12 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num8, 0.0);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num4);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num5);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num5, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num6, y3);
		@class.method_4(num6, y5);
		@class.method_4(num9, y5);
		@class.method_4(num9, num11);
		@class.method_4(x4, num11);
		@class.method_4(x4, num6);
		@class.method_4(x2, num6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x3, num6);
		@class.method_4(x5, num6);
		@class.method_4(x5, num11);
		@class.method_4(num10, num11);
		@class.method_4(num10, y5);
		@class.method_4(x, y5);
		@class.method_4(x, y3);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x, y4);
		@class.method_4(x, y6);
		@class.method_4(num10, y6);
		@class.method_4(num10, num12);
		@class.method_4(x5, num12);
		@class.method_4(x5, y2);
		@class.method_4(x3, y2);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x2, y2);
		@class.method_4(x4, y2);
		@class.method_4(x4, num12);
		@class.method_4(num9, num12);
		@class.method_4(num9, y6);
		@class.method_4(num6, y6);
		@class.method_4(num6, y4);
		@class.method_8();
		@class.TextRectangle = new Class3457(num9, num11, num10, num12);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 18515.0);
		values.Add("adj2", 18515.0);
		values.Add("adj3", 18515.0);
		values.Add("adj4", 48123.0);
	}
}
