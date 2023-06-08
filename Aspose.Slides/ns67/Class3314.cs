namespace ns67;

internal class Class3314 : Class3290
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_1;

	public override Class3280 vmethod_1()
	{
		Class3314 @class = new Class3314();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(30000.0, base.AdjustValues["adj"], 70000.0);
		double num = Class3089.smethod_1(x, base.Transform2D.Extents.Cx, 100000.0);
		double x2 = Class3089.smethod_2(num, 0.0, base.Transform2D.Extents.Cx / 2.0);
		double x3 = Class3089.smethod_2(num, 0.0, 0.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double z = Class3089.smethod_1(x3, 2.0, 1.0);
		double y = Class3089.smethod_1(x4, 2.0, 1.0);
		double num2 = Class3089.smethod_4(x2, y, z);
		double num3 = Class3089.smethod_2(0.0, num2, 0.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double x5 = Class3089.smethod_4(x2, 0.0, num4);
		double x6 = Class3089.smethod_4(x2, num3, base.Transform2D.Extents.Cx);
		double x7 = Class3089.smethod_4(x2, num4, 0.0);
		double x8 = Class3089.smethod_4(x2, base.Transform2D.Extents.Cx, num3);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x5, 0.0);
		@class.method_6(x6, 0.0);
		@class.method_4();
		@class.method_7(x7, base.Transform2D.Extents.Cy);
		@class.method_6(x8, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 50000.0);
	}
}
