using System;

namespace ns67;

internal class Class3323 : Class3290
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum496 ShapeType => Enum496.const_24;

	public override Class3280 vmethod_1()
	{
		Class3323 @class = new Class3323();
		@class.AdjustValues["adj1"] = base.AdjustValues["adj1"];
		@class.AdjustValues["adj2"] = base.AdjustValues["adj2"];
		return @class;
	}

	internal override Class3340 vmethod_3()
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
		double x = Class3089.smethod_2(0.0, 0.0, num6);
		double num7 = Class3089.smethod_4(num5, num5, 0.0);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num7);
		double y7 = Class3089.smethod_3(num6, num8, 6.0);
		double x2 = Class3089.smethod_2(x, y7, 0.0);
		double y8 = Class3089.smethod_3(num6, num8, 3.0);
		double x3 = Class3089.smethod_2(x, y8, 0.0);
		double x4 = Class3089.smethod_3(x, num8, 2.0);
		double x5 = Class3089.smethod_2(x4, y7, 0.0);
		double x6 = Class3089.smethod_3(x5, num8, 2.0);
		double x7 = Class3089.smethod_2(0.0, num7, 0.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx, num6, 0.0);
		double x8 = Class3089.smethod_2(x7, y7, 0.0);
		double x9 = Class3089.smethod_2(x7, y8, 0.0);
		double x10 = Class3089.smethod_3(x7, num9, 2.0);
		double x11 = Class3089.smethod_2(x10, y7, 0.0);
		double x12 = Class3089.smethod_3(x11, num9, 2.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x, num);
		@class.method_3(new Struct159(x2, y4), new Struct159(x3, y3), new Struct159(x4, num));
		@class.method_3(new Struct159(x5, y4), new Struct159(x6, y3), new Struct159(num8, num));
		@class.method_4();
		@class.method_7(x7, num3);
		@class.method_3(new Struct159(x8, y6), new Struct159(x9, y5), new Struct159(x10, num3));
		@class.method_3(new Struct159(x11, y6), new Struct159(x12, y5), new Struct159(num9, num3));
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 6250.0);
		values.Add("adj2", 0.0);
	}
}
