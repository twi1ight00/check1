namespace ns67;

internal class Class3309 : Class3290
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_6;

	public override Class3280 vmethod_1()
	{
		Class3309 @class = new Class3309();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(50000.0, base.AdjustValues["adj"], 100000.0);
		double num = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, 100000.0);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(0.0, 0.0);
		@class.method_6(base.Transform2D.Extents.Cx / 2.0, y);
		@class.method_6(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4();
		@class.method_7(0.0, num);
		@class.method_6(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_6(base.Transform2D.Extents.Cx, num);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 75000.0);
	}
}
