namespace ns67;

internal class Class3304 : Class3290
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_25;

	public override Class3280 vmethod_1()
	{
		Class3304 @class = new Class3304();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 20000.0);
		double num = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, 100000.0);
		double z = Class3089.smethod_1(num, 1.0, 3.0);
		double num2 = Class3089.smethod_2(0.0, 0.0, z);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		double y2 = Class3089.smethod_2(0.0, num, 0.0);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double y4 = Class3089.smethod_2(0.0, num2, 0.0);
		double y5 = Class3089.smethod_2(0.0, y, 0.0);
		double x2 = Class3089.smethod_2(0.0, base.Transform2D.Extents.Cx / 3.0, 0.0);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, base.Transform2D.Extents.Cx / 3.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(0.0, y2);
		@class.method_3(new Struct159(x2, y4), new Struct159(x3, y4), new Struct159(base.Transform2D.Extents.Cx, y2));
		@class.method_4();
		@class.method_7(0.0, y3);
		@class.method_3(new Struct159(x2, y5), new Struct159(x3, y5), new Struct159(base.Transform2D.Extents.Cx, y3));
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 18750.0);
	}
}
