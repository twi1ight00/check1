namespace ns67;

internal class Class3287 : Class3285
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_9;

	public override Class3280 vmethod_1()
	{
		Class3287 @class = new Class3287();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double y = base.AdjustValues["adj"] - (base.AdjustValues["adj"] - 10800000.0) * 0.25;
		double num = Class3089.smethod_0(0.0, y, 21599999.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double z = Class3089.smethod_2(32400000.0, 0.0, num);
		double x = Class3089.smethod_4(num2, num2, z);
		double x2 = Class3089.smethod_2(5400000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double y2 = Class3089.smethod_2(x, 0.0, num);
		double num3 = Class3089.smethod_2(21600000.0, y2, 0.0);
		double z2 = Class3089.smethod_4(x3, y2, num3);
		double z3 = Class3089.smethod_4(num2, num3, z2);
		double swingAngle = Class3089.smethod_4(x2, y2, z3);
		double z4 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, y);
		double y3 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, y);
		double y4 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y3, z4);
		double y5 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y3, z4);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y4, 0.0);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y5, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x4, y6);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 10800000.0);
	}
}
