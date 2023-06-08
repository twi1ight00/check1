namespace ns67;

internal class Class3259 : Class3091
{
	private const string string_0 = "adj";

	private const string string_1 = "hf";

	private const string string_2 = "vf";

	public override Enum493 Kind => Enum493.const_16;

	public Class3259(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num = Class3089.smethod_7(x, 1080000.0);
		double num2 = Class3089.smethod_7(x, 18360000.0);
		double z = Class3089.smethod_10(x2, 1080000.0);
		double z2 = Class3089.smethod_10(x2, 18360000.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y2 = Class3089.smethod_2(x3, 0.0, z);
		double y3 = Class3089.smethod_2(x3, 0.0, z2);
		double x8 = Class3089.smethod_1(x, y, 50000.0);
		double num3 = Class3089.smethod_1(x2, y, 50000.0);
		double num4 = Class3089.smethod_7(x8, 20520000.0);
		double num5 = Class3089.smethod_7(x8, 3240000.0);
		double z3 = Class3089.smethod_10(num3, 3240000.0);
		double z4 = Class3089.smethod_10(num3, 20520000.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double x10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double num8 = Class3089.smethod_2(x3, 0.0, z3);
		double y4 = Class3089.smethod_2(x3, 0.0, z4);
		double num9 = Class3089.smethod_2(x3, num3, 0.0);
		Class3089.smethod_2(x3, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x4, y2);
		@class.method_4(x9, num8);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x10, num8);
		@class.method_4(x7, y2);
		@class.method_4(num7, y4);
		@class.method_4(x6, y3);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num9);
		@class.method_4(x5, y3);
		@class.method_4(num6, y4);
		@class.method_8();
		@class.TextRectangle = new Class3457(num6, num8, num7, num9);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 19098.0);
		values.Add("hf", 105146.0);
		values.Add("vf", 110557.0);
	}
}
