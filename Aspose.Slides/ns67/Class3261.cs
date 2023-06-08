namespace ns67;

internal class Class3261 : Class3091
{
	private const string string_0 = "adj";

	private const string string_1 = "hf";

	private const string string_2 = "vf";

	public override Enum493 Kind => Enum493.const_18;

	public Class3261(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num = Class3089.smethod_1(x, 97493.0, 100000.0);
		double num2 = Class3089.smethod_1(x, 78183.0, 100000.0);
		double num3 = Class3089.smethod_1(x, 43388.0, 100000.0);
		double z = Class3089.smethod_1(x2, 62349.0, 100000.0);
		double y2 = Class3089.smethod_1(x2, 22252.0, 100000.0);
		double y3 = Class3089.smethod_1(x2, 90097.0, 100000.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y4 = Class3089.smethod_2(x3, 0.0, z);
		double y5 = Class3089.smethod_2(x3, y2, 0.0);
		double y6 = Class3089.smethod_2(x3, y3, 0.0);
		double x10 = Class3089.smethod_1(x, y, 50000.0);
		double num4 = Class3089.smethod_1(x2, y, 50000.0);
		double num5 = Class3089.smethod_1(x10, 97493.0, 100000.0);
		double num6 = Class3089.smethod_1(x10, 78183.0, 100000.0);
		double num7 = Class3089.smethod_1(x10, 43388.0, 100000.0);
		double x11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num6);
		double x12 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num7);
		double x13 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num7, 0.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num6, 0.0);
		double x14 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double z2 = Class3089.smethod_1(num4, 90097.0, 100000.0);
		double z3 = Class3089.smethod_1(num4, 22252.0, 100000.0);
		double y7 = Class3089.smethod_1(num4, 62349.0, 100000.0);
		double num10 = Class3089.smethod_2(x3, 0.0, z2);
		double y8 = Class3089.smethod_2(x3, 0.0, z3);
		double num11 = Class3089.smethod_2(x3, y7, 0.0);
		double y9 = Class3089.smethod_2(x3, num4, 0.0);
		Class3089.smethod_2(x3, 0.0, num4);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x4, y5);
		@class.method_4(x11, y8);
		@class.method_4(x5, y4);
		@class.method_4(x12, num10);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x13, num10);
		@class.method_4(x8, y4);
		@class.method_4(x14, y8);
		@class.method_4(x9, y5);
		@class.method_4(num9, num11);
		@class.method_4(x7, y6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, y9);
		@class.method_4(x6, y6);
		@class.method_4(num8, num11);
		@class.method_8();
		@class.TextRectangle = new Class3457(num8, num10, num9, num11);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 34601.0);
		values.Add("hf", 102572.0);
		values.Add("vf", 105210.0);
	}
}
