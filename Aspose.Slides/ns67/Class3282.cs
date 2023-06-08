using System;

namespace ns67;

internal class Class3282 : Class3281
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum496 ShapeType => Enum496.const_16;

	public override Class3280 vmethod_1()
	{
		Class3282 @class = new Class3282();
		@class.AdjustValues["adj1"] = base.AdjustValues["adj1"];
		@class.AdjustValues["adj2"] = base.AdjustValues["adj2"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double x = Class3089.smethod_2(5400000.0, 0.0, num);
		double x2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double y = Class3089.smethod_2(21600000.0, 0.0, num);
		double z = Class3089.smethod_4(x3, num, 0.0);
		double z2 = Class3089.smethod_4(x2, 10800000.0, z);
		double y2 = Class3089.smethod_4(x, y, z2);
		double num2 = Class3089.smethod_4(num, y2, 0.0);
		double y3 = Class3089.smethod_2(21600000.0, 0.0, num2);
		double num3 = Class3089.smethod_4(num2, y3, 0.0);
		double y4 = Class3089.smethod_1(x, 2.0, 1.0);
		double z3 = Class3089.smethod_1(x3, 2.0, 1.0);
		double y5 = Class3089.smethod_2(0.0, 0.0, z3);
		double z4 = Class3089.smethod_2(0.0, 0.0, 10800000.0);
		double z5 = Class3089.smethod_4(x3, y5, z4);
		double z6 = Class3089.smethod_4(x2, 10800000.0, z5);
		double y6 = Class3089.smethod_4(x, y4, z6);
		double num4 = Class3089.smethod_4(num, y6, 10800000.0);
		double num5 = Class3089.smethod_2(0.0, 0.0, num4);
		double num6 = Class3089.smethod_4(x2, num3, num2);
		double num7 = Class3089.smethod_4(x2, num2, num3);
		double swingAngle = Class3089.smethod_4(x2, num4, num5);
		double swingAngle2 = Class3089.smethod_4(x2, num5, num4);
		double z7 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num6);
		double y7 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num6);
		double y8 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y7, z7);
		double y9 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y7, z7);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y9, 0.0);
		double z8 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num7);
		double y11 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num7);
		double y12 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y11, z8);
		double y13 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y11, z8);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y12, 0.0);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y13, 0.0);
		double x6 = Class3089.smethod_0(40000.0, base.AdjustValues["adj2"], 99000.0);
		double y15 = Class3089.smethod_1(x6, 1.0, 100000.0);
		double num8 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y15, 1.0);
		double num9 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y15, 1.0);
		double z9 = Class3089.smethod_10(num8, num6);
		double y16 = Class3089.smethod_7(num9, num6);
		double y17 = Class3089.smethod_6(num8, y16, z9);
		double y18 = Class3089.smethod_9(num9, y16, z9);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y17, 0.0);
		double y19 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y18, 0.0);
		double z10 = Class3089.smethod_10(num8, num7);
		double y20 = Class3089.smethod_7(num9, num7);
		double y21 = Class3089.smethod_6(num8, y20, z10);
		double y22 = Class3089.smethod_9(num9, y20, z10);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y21, 0.0);
		double y23 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y22, 0.0);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num9);
		double num10 = Class3089.smethod_1(x9, 1.0, 2.0);
		double y24 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num10);
		double y25 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num10, 0.0);
		num4 = Class3089.smethod_1(num10, num10, 1.0);
		double z11 = Class3089.smethod_1(num9, num9, 1.0);
		double z12 = Class3089.smethod_1(num4, 1.0, z11);
		double x10 = Class3089.smethod_2(1.0, 0.0, z12);
		double y26 = Class3089.smethod_1(num8, num8, 1.0);
		double d = Class3089.smethod_1(x10, y26, 1.0);
		double num11 = Math.Sqrt(d);
		double x11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num11);
		double x12 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num11, 0.0);
		double z13 = Class3089.smethod_10(num8, base.AdjustValues["adj1"]);
		double y27 = Class3089.smethod_7(num9, base.AdjustValues["adj1"]);
		double y28 = Class3089.smethod_6(num8, y27, z13);
		double y29 = Class3089.smethod_9(num9, y27, z13);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y28, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y29, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x4, y10);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num6, swingAngle);
		@class.method_4();
		@class.method_7(x7, y19);
		@class.method_0(num9, num8, num6, swingAngle);
		@class.method_4();
		@class.method_7(x11, y24);
		@class.method_6(x12, y24);
		@class.method_4();
		@class.method_7(x11, y25);
		@class.method_6(x12, y25);
		@class.method_4();
		@class.method_7(x8, y23);
		@class.method_0(num9, num8, num7, swingAngle2);
		@class.method_4();
		@class.method_7(x5, y14);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num7, swingAngle2);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 10800000.0);
		values.Add("adj2", 50000.0);
	}
}
