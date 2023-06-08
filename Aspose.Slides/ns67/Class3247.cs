namespace ns67;

internal class Class3247 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_78;

	public Class3247(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(-4653.0, base.AdjustValues["adj"], 4653.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx, 4969.0, 21699.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 6215.0, 21600.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 13135.0, 21600.0);
		double x4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 16640.0, 21600.0);
		double y2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 7570.0, 21600.0);
		double x5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 16515.0, 21600.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double y3 = Class3089.smethod_2(x5, 0.0, num);
		double x6 = Class3089.smethod_2(x5, num, 0.0);
		double y4 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 50000.0);
		double y5 = Class3089.smethod_2(x6, y4, 0.0);
		double num2 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num3 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double widthRadius = Class3089.smethod_1(base.Transform2D.Extents.Cx, 1125.0, 21600.0);
		double heightRadius = Class3089.smethod_1(base.Transform2D.Extents.Cy, 1125.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 21600000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: true);
		@class.method_3(x2, y2);
		@class.method_5(heightRadius, widthRadius, 10800000.0, 21600000.0);
		@class.method_3(x3, y2);
		@class.method_5(heightRadius, widthRadius, 10800000.0, 21600000.0);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x, y3);
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx / 2.0, y5), new Struct159(x4, y3));
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 21600000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 4653.0);
	}
}
