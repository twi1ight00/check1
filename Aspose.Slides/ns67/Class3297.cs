namespace ns67;

internal class Class3297 : Class3290
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_30;

	public override Class3280 vmethod_1()
	{
		Class3297 @class = new Class3297();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 93750.0);
		double y = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, 100000.0);
		double x2 = Class3089.smethod_2(0.0, y, 0.0);
		double y2 = Class3089.smethod_2(x2, y, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(0.0, 0.0);
		@class.method_8(new Struct159(base.Transform2D.Extents.Cx / 2.0, y2), new Struct159(base.Transform2D.Extents.Cx, 0.0));
		@class.method_4();
		@class.method_7(0.0, base.Transform2D.Extents.Cy);
		@class.method_6(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 50000.0);
	}
}
