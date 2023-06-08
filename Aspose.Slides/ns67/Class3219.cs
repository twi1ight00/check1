namespace ns67;

internal class Class3219 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_180;

	public Class3219(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 50000.0);
		double x = Class3089.smethod_0(4200000.0, base.AdjustValues["adj2"], 6600000.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double z2 = Class3089.smethod_2(100000.0, 0.0, z);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z2);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, 100000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 73490.0, 200000.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double num9 = Class3089.smethod_2(num7, 0.0, num2);
		double num10 = Class3089.smethod_2(num8, num2, 0.0);
		double num11 = Class3089.smethod_2(x, 0.0, 5400000.0);
		double num12 = Class3089.smethod_11(base.Transform2D.Extents.Cy / 2.0, num11);
		double num13 = Class3089.smethod_8(num12, base.Transform2D.Extents.Cy / 2.0, 0.0);
		double num14 = Class3089.smethod_1(num13, num2, base.Transform2D.Extents.Cy / 2.0);
		double z3 = Class3089.smethod_1(num14, 1.0, 2.0);
		double num15 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num12, z3);
		double z4 = Class3089.smethod_1(num12, num9, base.Transform2D.Extents.Cy / 2.0);
		double x2 = Class3089.smethod_2(num15, 0.0, z4);
		double z5 = Class3089.smethod_1(num12, num7, base.Transform2D.Extents.Cy / 2.0);
		double x3 = Class3089.smethod_2(num15, 0.0, z5);
		double z6 = Class3089.smethod_1(num12, num8, base.Transform2D.Extents.Cy / 2.0);
		double x4 = Class3089.smethod_2(num15, 0.0, z6);
		double z7 = Class3089.smethod_1(num12, num10, base.Transform2D.Extents.Cy / 2.0);
		double x5 = Class3089.smethod_2(num15, 0.0, z7);
		double z8 = Class3089.smethod_1(num12, 2.0, 1.0);
		double x6 = Class3089.smethod_2(num15, 0.0, z8);
		double num16 = Class3089.smethod_2(num15, num14, 0.0);
		double x7 = Class3089.smethod_2(x2, num14, 0.0);
		double x8 = Class3089.smethod_2(x3, num14, 0.0);
		double x9 = Class3089.smethod_2(x4, num14, 0.0);
		double x10 = Class3089.smethod_2(x5, num14, 0.0);
		Class3089.smethod_2(x6, num14, 0.0);
		double num17 = Class3089.smethod_1(num2, base.Transform2D.Extents.Cy / 2.0, num13);
		double y2 = Class3089.smethod_2(num15, num17, 0.0);
		double z9 = Class3089.smethod_2(num16, 0.0, num17);
		double num18 = Class3089.smethod_4(num11, y2, num16);
		double num19 = Class3089.smethod_4(num11, num15, z9);
		double num20 = Class3089.smethod_1(num2, num12, num13);
		double z10 = Class3089.smethod_2(0.0, 0.0, num20);
		double num21 = Class3089.smethod_4(num11, num20, 0.0);
		double num22 = Class3089.smethod_4(num11, 0.0, z10);
		double num23 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num18);
		double x11 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num19);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num21);
		double num24 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num22);
		Class3089.smethod_3(num18, num19, 2.0);
		Class3089.smethod_3(x11, num23, 2.0);
		Class3089.smethod_3(num21, num22, 2.0);
		Class3089.smethod_3(num9, num7, 2.0);
		Class3089.smethod_3(num8, num10, 2.0);
		Class3089.smethod_3(num24, y3, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num5, num9);
		@class.method_4(x2, num9);
		@class.method_4(num19, num22);
		@class.method_4(num18, num21);
		@class.method_4(x7, num9);
		@class.method_4(num6, num9);
		@class.method_4(num6, num7);
		@class.method_4(x8, num7);
		@class.method_4(x9, num8);
		@class.method_4(num6, num8);
		@class.method_4(num6, num10);
		@class.method_4(x10, num10);
		@class.method_4(x11, num24);
		@class.method_4(num23, y3);
		@class.method_4(x5, num10);
		@class.method_4(num5, num10);
		@class.method_4(num5, num8);
		@class.method_4(x4, num8);
		@class.method_4(x3, num7);
		@class.method_4(num5, num7);
		@class.method_8();
		@class.TextRectangle = new Class3457(num5, num9, num6, num10);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 23520.0);
		values.Add("adj2", 6600000.0);
		values.Add("adj3", 11760.0);
	}
}
