namespace ns67;

internal class Class3308 : Class3290
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum496 ShapeType => Enum496.const_13;

	public override Class3280 vmethod_1()
	{
		Class3308 @class = new Class3308();
		@class.AdjustValues["adj1"] = base.AdjustValues["adj1"];
		@class.AdjustValues["adj2"] = base.AdjustValues["adj2"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double z = Class3089.smethod_2(32400000.0, 0.0, num);
		double x = Class3089.smethod_4(num2, num2, z);
		double x2 = Class3089.smethod_2(5400000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double y = Class3089.smethod_2(x, 0.0, num);
		double num3 = Class3089.smethod_2(21600000.0, y, 0.0);
		double z2 = Class3089.smethod_4(x3, y, num3);
		double z3 = Class3089.smethod_4(num2, num3, z2);
		double swingAngle = Class3089.smethod_4(x2, y, z3);
		double z4 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num);
		double y2 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num);
		double y3 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y2, z4);
		double y4 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y2, z4);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y3, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y4, 0.0);
		double x5 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 99000.0);
		double y6 = Class3089.smethod_1(x5, 1.0, 100000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y6, 1.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y6, 1.0);
		double z5 = Class3089.smethod_10(num4, num);
		double y7 = Class3089.smethod_7(num5, num);
		double y8 = Class3089.smethod_6(num4, y7, z5);
		double y9 = Class3089.smethod_9(num5, y7, z5);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y9, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x4, y5);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, swingAngle);
		@class.method_4();
		@class.method_7(x6, y10);
		@class.method_0(num5, num4, num, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 10800000.0);
		values.Add("adj2", 50000.0);
	}
}
