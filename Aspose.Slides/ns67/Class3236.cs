namespace ns67;

internal class Class3236 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_122;

	public Class3236(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 33333.0);
		double y2 = Class3089.smethod_0(25000.0, base.AdjustValues["adj2"], 75000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, base.Transform2D.Extents.Cx / 8.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, y2, 200000.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double x2 = Class3089.smethod_2(num2, base.Transform2D.Extents.Cx / 32.0, 0.0);
		double x3 = Class3089.smethod_2(num3, 0.0, base.Transform2D.Extents.Cx / 32.0);
		double x4 = Class3089.smethod_2(num2, base.Transform2D.Extents.Cx / 8.0, 0.0);
		double x5 = Class3089.smethod_2(num3, 0.0, base.Transform2D.Extents.Cx / 8.0);
		double x6 = Class3089.smethod_2(x4, 0.0, base.Transform2D.Extents.Cx / 32.0);
		double x7 = Class3089.smethod_2(x5, base.Transform2D.Extents.Cx / 32.0, 0.0);
		double z = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num5);
		double num7 = Class3089.smethod_2(0.0, num5, 0.0);
		double y3 = Class3089.smethod_3(num7, base.Transform2D.Extents.Cy, 2.0);
		double num8 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 400000.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num8);
		double y5 = Class3089.smethod_2(num4, 0.0, num8);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(x6, base.Transform2D.Extents.Cy);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, -10800000.0);
		@class.method_4(x2, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, 10800000.0);
		@class.method_4(x3, num6);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, 10800000.0);
		@class.method_4(x7, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -10800000.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(x, y3);
		@class.method_4(base.Transform2D.Extents.Cx, num7);
		@class.method_4(num3, num7);
		@class.method_4(num3, num8);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 0.0, -5400000.0);
		@class.method_4(x2, 0.0);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -5400000.0);
		@class.method_4(num2, num7);
		@class.method_4(0.0, num7);
		@class.method_4(base.Transform2D.Extents.Cx / 8.0, y3);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(x4, y4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 0.0, -5400000.0);
		@class.method_4(x2, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, 10800000.0);
		@class.method_4(x4, num6);
		@class.method_8();
		@class.method_3(x5, y4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 10800000.0, 5400000.0);
		@class.method_4(x3, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, -10800000.0);
		@class.method_4(x5, num6);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(base.Transform2D.Extents.Cx / 8.0, y3);
		@class.method_4(0.0, num7);
		@class.method_4(num2, num7);
		@class.method_4(num2, num8);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 10800000.0, 5400000.0);
		@class.method_4(x3, 0.0);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, 5400000.0);
		@class.method_4(num3, num7);
		@class.method_4(num3, num7);
		@class.method_4(base.Transform2D.Extents.Cx, num7);
		@class.method_4(x, y3);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(x7, base.Transform2D.Extents.Cy);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, 10800000.0);
		@class.method_4(x3, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 5400000.0, -10800000.0);
		@class.method_4(x2, num6);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, -10800000.0);
		@class.method_4(x6, num4);
		@class.method_5(num8, base.Transform2D.Extents.Cx / 32.0, 16200000.0, 10800000.0);
		@class.method_8();
		@class.method_3(x4, num6);
		@class.method_4(x4, y4);
		@class.method_3(x5, y4);
		@class.method_4(x5, num6);
		@class.method_3(num2, y5);
		@class.method_4(num2, num7);
		@class.method_3(num3, num7);
		@class.method_4(num3, y5);
		@class.TextRectangle = new Class3457(num2, 0.0, num3, num6);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 16667.0);
		values.Add("adj2", 50000.0);
	}
}
