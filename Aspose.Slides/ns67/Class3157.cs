using System;

namespace ns67;

internal class Class3157 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_124;

	public Class3157(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 100000.0);
		double y = Class3089.smethod_0(25000.0, base.AdjustValues["adj2"], 75000.0);
		double x = Class3089.smethod_2(100000.0, 0.0, num);
		double z = Class3089.smethod_1(x, 1.0, 2.0);
		double val = Class3089.smethod_2(num, 0.0, z);
		double x2 = Math.Max(0.0, val);
		double y2 = Class3089.smethod_0(x2, base.AdjustValues["adj3"], num);
		double z2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y, 200000.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, z2);
		double num3 = Class3089.smethod_2(num2, base.Transform2D.Extents.Cx / 8.0, 0.0);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num3);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, base.Transform2D.Extents.Cx / 8.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y2, 100000.0);
		double x5 = Class3089.smethod_1(4.0, num5, base.Transform2D.Extents.Cx);
		double z3 = Class3089.smethod_1(num3, num3, base.Transform2D.Extents.Cx);
		double y3 = Class3089.smethod_2(num3, 0.0, z3);
		double num6 = Class3089.smethod_1(x5, y3, 1.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num6);
		double num7 = Class3089.smethod_1(num3, 1.0, 2.0);
		double z4 = Class3089.smethod_1(x5, num7, 1.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z4);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num7);
		z3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, 100000.0);
		double y6 = Class3089.smethod_2(z3, 0.0, num5);
		double z5 = Class3089.smethod_1(num2, num2, base.Transform2D.Extents.Cx);
		double y7 = Class3089.smethod_2(num2, 0.0, z5);
		double x7 = Class3089.smethod_1(x5, y7, 1.0);
		double num8 = Class3089.smethod_2(x7, y6, 0.0);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num8);
		double x8 = Class3089.smethod_2(num5, y6, num8);
		double x9 = Class3089.smethod_2(x8, num5, 0.0);
		double num9 = Class3089.smethod_2(x9, y6, 0.0);
		double y9 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num9);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z3);
		double x10 = Class3089.smethod_1(num5, 14.0, 16.0);
		double z6 = Class3089.smethod_3(x10, num10, 2.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z6);
		double z7 = Class3089.smethod_2(x7, num10, 0.0);
		double y11 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z7);
		double z8 = Class3089.smethod_2(num8, num10, 0.0);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z8);
		double num12 = Class3089.smethod_1(num2, 1.0, 2.0);
		double x11 = Class3089.smethod_1(x5, num12, 1.0);
		double z9 = Class3089.smethod_2(x11, num10, 0.0);
		double y12 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z9);
		double x12 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num12);
		double z10 = Class3089.smethod_2(num9, num10, 0.0);
		double y13 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z10);
		double z11 = Class3089.smethod_2(num6, y6, 0.0);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z11);
		double z12 = Class3089.smethod_2(z3, z3, z11);
		double y15 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z12);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_7(new Struct159(num7, y5), new Struct159(num3, y4));
		@class.method_4(num2, y8);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y9), new Struct159(num4, y8));
		@class.method_4(x3, y4);
		@class.method_7(new Struct159(x6, y5), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy));
		@class.method_4(x4, y10);
		@class.method_4(base.Transform2D.Extents.Cx, z3);
		@class.method_7(new Struct159(x12, y12), new Struct159(num4, y11));
		@class.method_4(num4, num11);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y13), new Struct159(num2, num11));
		@class.method_4(num2, y11);
		@class.method_7(new Struct159(num12, y12), new Struct159(0.0, z3));
		@class.method_4(base.Transform2D.Extents.Cx / 8.0, y10);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(num3, y14);
		@class.method_4(num3, y4);
		@class.method_4(num2, y8);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y9), new Struct159(num4, y8));
		@class.method_4(x3, y4);
		@class.method_4(x3, y14);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y15), new Struct159(num3, y14));
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(base.Transform2D.Extents.Cx / 8.0, y10);
		@class.method_4(0.0, z3);
		@class.method_7(new Struct159(num12, y12), new Struct159(num2, y11));
		@class.method_4(num2, num11);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y13), new Struct159(num4, num11));
		@class.method_4(num4, y11);
		@class.method_7(new Struct159(x12, y12), new Struct159(base.Transform2D.Extents.Cx, z3));
		@class.method_4(x4, y10);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_7(new Struct159(x6, y5), new Struct159(x3, y4));
		@class.method_4(num4, y8);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y9), new Struct159(num2, y8));
		@class.method_4(num3, y4);
		@class.method_7(new Struct159(num7, y5), new Struct159(0.0, base.Transform2D.Extents.Cy));
		@class.method_8();
		@class.method_3(num2, y8);
		@class.method_4(num2, y11);
		@class.method_3(num4, y11);
		@class.method_4(num4, y8);
		@class.method_3(num3, y14);
		@class.method_4(num3, y4);
		@class.method_3(x3, y4);
		@class.method_4(x3, y14);
		@class.TextRectangle = new Class3457(num2, num11, num4, num10);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 25000.0);
		values.Add("adj2", 50000.0);
		values.Add("adj3", 12500.0);
	}
}
