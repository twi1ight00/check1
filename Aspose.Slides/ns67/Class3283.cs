namespace ns67;

internal class Class3283 : Class3281
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_32;

	public override Class3280 vmethod_1()
	{
		Class3283 @class = new Class3283();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double x = Class3089.smethod_0(3000.0, base.AdjustValues["adj"], 47000.0);
		double num = Class3089.smethod_1(x, base.Transform2D.Extents.Cy, 100000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3.0, 100.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 30.0, 100.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 36.0, 100.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 63.0, 100.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 70.0, 100.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num7 = Class3089.smethod_2(num, 0.0, num2);
		double num8 = Class3089.smethod_2(num, num2, 0.0);
		double num9 = Class3089.smethod_2(x2, 0.0, num2);
		double num10 = Class3089.smethod_2(x2, num2, 0.0);
		double y = Class3089.smethod_2(num7, num7, num3);
		double y2 = Class3089.smethod_2(num8, num8, num4);
		double y3 = Class3089.smethod_2(num9, num9, num5);
		double y4 = Class3089.smethod_2(num10, num10, num6);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(0.0, 0.0);
		@class.method_6(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4();
		@class.method_7(0.0, num3);
		@class.method_8(new Struct159(base.Transform2D.Extents.Cx / 2.0, y), new Struct159(base.Transform2D.Extents.Cx, num3));
		@class.method_4();
		@class.method_7(0.0, num4);
		@class.method_8(new Struct159(base.Transform2D.Extents.Cx / 2.0, y2), new Struct159(base.Transform2D.Extents.Cx, num4));
		@class.method_4();
		@class.method_7(0.0, num5);
		@class.method_8(new Struct159(base.Transform2D.Extents.Cx / 2.0, y3), new Struct159(base.Transform2D.Extents.Cx, num5));
		@class.method_4();
		@class.method_7(0.0, num6);
		@class.method_8(new Struct159(base.Transform2D.Extents.Cx / 2.0, y4), new Struct159(base.Transform2D.Extents.Cx, num6));
		@class.method_4();
		@class.method_7(0.0, base.Transform2D.Extents.Cy);
		@class.method_6(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
