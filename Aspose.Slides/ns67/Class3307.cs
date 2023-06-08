namespace ns67;

internal class Class3307 : Class3290
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum496 ShapeType => Enum496.const_14;

	public override Class3280 vmethod_1()
	{
		Class3307 @class = new Class3307();
		@class.AdjustValues["adj1"] = base.AdjustValues["adj1"];
		@class.AdjustValues["adj2"] = base.AdjustValues["adj2"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double y = Class3089.smethod_2(32400000.0, 0.0, num);
		double x = Class3089.smethod_2(0.0, 0.0, num2);
		double num3 = Class3089.smethod_4(x, y, num2);
		double x2 = Class3089.smethod_2(5400000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double num4 = Class3089.smethod_2(num, 0.0, num3);
		double num5 = Class3089.smethod_2(num4, 0.0, 21600000.0);
		double z = Class3089.smethod_2(0.0, 0.0, 10800000.0);
		double z2 = Class3089.smethod_4(x3, num4, num5);
		double z3 = Class3089.smethod_4(num2, num5, z2);
		double y2 = Class3089.smethod_4(x2, num4, z3);
		double swingAngle = Class3089.smethod_4(num3, y2, z);
		double z4 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num3);
		double y3 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num3);
		double y4 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y3, z4);
		double y5 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y3, z4);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y4, 0.0);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y5, 0.0);
		double x5 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 99000.0);
		double y7 = Class3089.smethod_1(x5, 1.0, 100000.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y7, 1.0);
		double num7 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y7, 1.0);
		double z5 = Class3089.smethod_10(num6, num);
		double y8 = Class3089.smethod_7(num7, num);
		double y9 = Class3089.smethod_6(num6, y8, z5);
		double y10 = Class3089.smethod_9(num7, y8, z5);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y9, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y10, 0.0);
		double z6 = Class3089.smethod_10(num6, num3);
		double y11 = Class3089.smethod_7(num7, num3);
		double y12 = Class3089.smethod_6(num6, y11, z6);
		double y13 = Class3089.smethod_9(num7, y11, z6);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y12, 0.0);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y13, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x6, y14);
		@class.method_0(num7, num6, num3, swingAngle);
		@class.method_4();
		@class.method_7(x4, y6);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num3, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 0.0);
		values.Add("adj2", 25000.0);
	}
}
