namespace ns67;

internal class Class3288 : Class3285
{
	private const string string_0 = "adj";

	public override Enum496 ShapeType => Enum496.const_12;

	public override Class3280 vmethod_1()
	{
		Class3288 @class = new Class3288();
		@class.AdjustValues["adj"] = base.AdjustValues["adj"];
		return @class;
	}

	internal override Class3340 vmethod_3()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 21599999.0);
		double x = Class3089.smethod_2(5400000.0, 0.0, num);
		double x2 = Class3089.smethod_2(10800000.0, 0.0, num);
		double x3 = Class3089.smethod_2(16200000.0, 0.0, num);
		double y = Class3089.smethod_2(21600000.0, 0.0, num);
		double z = Class3089.smethod_4(x3, num, 0.0);
		double z2 = Class3089.smethod_4(x2, 10800000.0, z);
		double y2 = Class3089.smethod_4(x, y, z2);
		double num2 = Class3089.smethod_4(num, y2, 0.0);
		double y3 = Class3089.smethod_2(21600000.0, 0.0, num2);
		double num3 = Class3089.smethod_4(num2, y3, 0.0);
		double y4 = Class3089.smethod_1(x, 2.0, 1.0);
		double z3 = Class3089.smethod_1(x3, 2.0, 1.0);
		double y5 = Class3089.smethod_2(0.0, 0.0, z3);
		double z4 = Class3089.smethod_2(0.0, 0.0, 10800000.0);
		double z5 = Class3089.smethod_4(x3, y5, z4);
		double z6 = Class3089.smethod_4(x2, 10800000.0, z5);
		double y6 = Class3089.smethod_4(x, y4, z6);
		double num4 = Class3089.smethod_4(num, y6, 10800000.0);
		double num5 = Class3089.smethod_2(0.0, 0.0, num4);
		double num6 = Class3089.smethod_4(x2, num3, num2);
		double num7 = Class3089.smethod_4(x2, num2, num3);
		double swingAngle = Class3089.smethod_4(x2, num4, num5);
		double swingAngle2 = Class3089.smethod_4(x2, num5, num4);
		double z7 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num6);
		double y7 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num6);
		double y8 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y7, z7);
		double y9 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y7, z7);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y9, 0.0);
		double z8 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num7);
		double y11 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num7);
		double y12 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y11, z8);
		double y13 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y11, z8);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y12, 0.0);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y13, 0.0);
		double z9 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["adj"]);
		double y15 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["adj"]);
		double y16 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y15, z9);
		double y17 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y15, z9);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y16, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y17, 0.0);
		Class3340 @class = new Class3340(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_4();
		@class.method_7(x4, y10);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num6, swingAngle);
		@class.method_4();
		@class.method_7(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_6(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4();
		@class.method_7(x5, y14);
		@class.method_0(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num7, swingAngle2);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 10800000.0);
	}
}
