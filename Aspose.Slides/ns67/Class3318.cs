namespace ns67;

internal class Class3318 : Class3290
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_2;

	public override Class3280 vmethod_1()
	{
		Class3318 @class = new Class3318();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(14286.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, 1.0, 3.0);
		double num2 = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, 100000.0);
		double x2 = Class3089.smethod_2(0.0, num, 0.0);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double y = Class3089.smethod_2(0.0, num2, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(0.0, y);
		@class.method_6(x2, 0.0);
		@class.method_6(x3, 0.0);
		@class.method_6(base.Transform2D.Extents.Cx, y);
		@class.method_4();
		@class.method_7(0.0, y2);
		@class.method_6(x2, base.Transform2D.Extents.Cy);
		@class.method_6(x3, base.Transform2D.Extents.Cy);
		@class.method_6(base.Transform2D.Extents.Cx, y2);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
