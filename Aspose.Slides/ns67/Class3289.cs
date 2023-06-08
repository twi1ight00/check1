namespace ns67;

internal class Class3289 : Class3285
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_11;

	public override Class3280 vmethod_1()
	{
		Class3289 @class = new Class3289();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 21599999.0);
		double x = Class3089.smethod_2(num, 0.0, 10800000.0);
		double num2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double y = Class3089.smethod_2(21600000.0, 0.0, num);
		double z = Class3089.smethod_4(num2, num2, 10799999.0);
		double x2 = Class3089.smethod_4(x, y, z);
		double swingAngle = Class3089.smethod_1(x2, 2.0, 1.0);
		double z2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["adj"]);
		double y2 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["adj"]);
		double y3 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y2, z2);
		double y4 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y2, z2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y3, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y4, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x3, y5);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, swingAngle);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 10800000.0);
	}
}
