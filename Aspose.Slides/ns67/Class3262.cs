namespace ns67;

internal class Class3262 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_19;

	public Class3262(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num2 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num2);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, 50000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num4 = Class3089.smethod_1(x3, 92388.0, 100000.0);
		double num5 = Class3089.smethod_1(x3, 38268.0, 100000.0);
		double num6 = Class3089.smethod_1(num3, 92388.0, 100000.0);
		double num7 = Class3089.smethod_1(num3, 38268.0, 100000.0);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num7, 0.0);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num6, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num8, y4);
		@class.method_4(x, y2);
		@class.method_4(x4, num10);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x5, num10);
		@class.method_4(x2, y2);
		@class.method_4(num9, y4);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num9, y5);
		@class.method_4(x2, y3);
		@class.method_4(x5, num11);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x4, num11);
		@class.method_4(x, y3);
		@class.method_4(num8, y5);
		@class.method_8();
		@class.TextRectangle = new Class3457(num8, num10, num9, num11);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 37500.0);
	}
}
