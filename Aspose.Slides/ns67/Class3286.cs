namespace ns67;

internal class Class3286 : Class3285
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_10;

	public override Class3280 vmethod_1()
	{
		Class3286 @class = new Class3286();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double y = base.AdjustValues["adj"] - base.AdjustValues["adj"] * 0.35;
		double num = Class3089.smethod_0(0.0, y, 21599999.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double y2 = Class3089.smethod_2(32400000.0, 0.0, num);
		double x = Class3089.smethod_2(0.0, 0.0, num2);
		double num3 = Class3089.smethod_4(x, y2, num2);
		double x2 = Class3089.smethod_2(5400000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double num4 = Class3089.smethod_2(num, 0.0, num3);
		double num5 = Class3089.smethod_2(num4, 0.0, 21600000.0);
		double z = Class3089.smethod_2(0.0, 0.0, 10800000.0);
		double z2 = Class3089.smethod_4(x3, num4, num5);
		double z3 = Class3089.smethod_4(num2, num5, z2);
		double y3 = Class3089.smethod_4(x2, num4, z3);
		double swingAngle = Class3089.smethod_4(num3, y3, z);
		double z4 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, y);
		double y4 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, y);
		double y5 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y4, z4);
		double y6 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y4, z4);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y5, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y6, 0.0);
		double z5 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num3);
		double y7 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num3);
		double y8 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y7, z5);
		double y9 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y7, z5);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y9, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x4, y10);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num3, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 0.0);
	}
}
