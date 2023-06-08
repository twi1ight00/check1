namespace ns67;

internal class Class3311 : Class3290
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum496 ShapeType => Enum496.const_15;

	public override Class3280 vmethod_1()
	{
		Class3311 @class = new Class3311();
		@class.AdjustValues["adj1"] = base.AdjustValues["adj1"];
		@class.AdjustValues["adj2"] = base.AdjustValues["adj2"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double x = Class3089.smethod_2(num, 0.0, 10800000.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double y = Class3089.smethod_2(21600000.0, 0.0, num);
		double z = Class3089.smethod_4(num2, num2, 10799999.0);
		double x2 = Class3089.smethod_4(x, y, z);
		double swingAngle = Class3089.smethod_1(x2, 2.0, 1.0);
		double z2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num);
		double y2 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num);
		double y3 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y2, z2);
		double y4 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y2, z2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y3, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y4, 0.0);
		double x4 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 99000.0);
		double y6 = Class3089.smethod_1(x4, 1.0, 100000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y6, 1.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y6, 1.0);
		double z3 = Class3089.smethod_10(num3, num);
		double y7 = Class3089.smethod_7(num4, num);
		double y8 = Class3089.smethod_6(num3, y7, z3);
		double y9 = Class3089.smethod_9(num4, y7, z3);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y9, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x3, y5);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, swingAngle);
		@class.method_4();
		@class.method_7(x5, y10);
		@class.method_0(num4, num3, num, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 10800000.0);
		values.Add("adj2", 50000.0);
	}
}
