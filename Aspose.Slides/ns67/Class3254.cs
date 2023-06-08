namespace ns67;

internal class Class3254 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_21;

	public Class3254(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 1800000.0);
		double num2 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 3600000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 3.0, 4.0);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num2);
		double y3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3.0, 4.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double x4 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, 50000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num4 = Class3089.smethod_7(x4, 900000.0);
		double num5 = Class3089.smethod_7(x4, 2700000.0);
		double num6 = Class3089.smethod_7(x4, 4500000.0);
		double num7 = Class3089.smethod_10(num3, 4500000.0);
		double num8 = Class3089.smethod_10(num3, 2700000.0);
		double num9 = Class3089.smethod_10(num3, 900000.0);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num6);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num6, 0.0);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double num12 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num8);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num9);
		double y7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num9, 0.0);
		double num13 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num8, 0.0);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num7, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x5, y6);
		@class.method_4(x, base.Transform2D.Extents.Cy / 4.0);
		@class.method_4(num10, num12);
		@class.method_4(base.Transform2D.Extents.Cx / 4.0, y2);
		@class.method_4(x6, y5);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x7, y5);
		@class.method_4(x2, y2);
		@class.method_4(num11, num12);
		@class.method_4(x3, base.Transform2D.Extents.Cy / 4.0);
		@class.method_4(x8, y6);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x8, y7);
		@class.method_4(x3, y3);
		@class.method_4(num11, num13);
		@class.method_4(x2, y4);
		@class.method_4(x7, y8);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x6, y8);
		@class.method_4(base.Transform2D.Extents.Cx / 4.0, y4);
		@class.method_4(num10, num13);
		@class.method_4(x, y3);
		@class.method_4(x5, y7);
		@class.method_8();
		@class.TextRectangle = new Class3457(num10, num12, num11, num13);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 37500.0);
	}
}
