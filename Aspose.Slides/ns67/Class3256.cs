namespace ns67;

internal class Class3256 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_23;

	public Class3256(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 900000.0);
		double num2 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 1800000.0);
		double num3 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num4 = base.Transform2D.Extents.Cx / 4.0;
		double num5 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 4500000.0);
		double num6 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 4500000.0);
		double num7 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 3600000.0);
		double num8 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double num9 = base.Transform2D.Extents.Cy / 4.0;
		double num10 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 900000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num8);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num9);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num10);
		double y7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num10, 0.0);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num9, 0.0);
		double y9 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num8, 0.0);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num7, 0.0);
		double y11 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num6, 0.0);
		double x11 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, 50000.0);
		double num11 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num12 = Class3089.smethod_1(x11, 99144.0, 100000.0);
		double num13 = Class3089.smethod_1(x11, 92388.0, 100000.0);
		double num14 = Class3089.smethod_1(x11, 79335.0, 100000.0);
		double num15 = Class3089.smethod_1(x11, 60876.0, 100000.0);
		double num16 = Class3089.smethod_1(x11, 38268.0, 100000.0);
		double num17 = Class3089.smethod_1(x11, 13053.0, 100000.0);
		double num18 = Class3089.smethod_1(num11, 99144.0, 100000.0);
		double num19 = Class3089.smethod_1(num11, 92388.0, 100000.0);
		double num20 = Class3089.smethod_1(num11, 79335.0, 100000.0);
		double num21 = Class3089.smethod_1(num11, 60876.0, 100000.0);
		double num22 = Class3089.smethod_1(num11, 38268.0, 100000.0);
		double num23 = Class3089.smethod_1(num11, 13053.0, 100000.0);
		double x12 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num12);
		double x13 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num13);
		double x14 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num14);
		double x15 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num15);
		double x16 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num16);
		double x17 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num17);
		double x18 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num17, 0.0);
		double x19 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num16, 0.0);
		double x20 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num15, 0.0);
		double x21 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num14, 0.0);
		double x22 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num13, 0.0);
		double x23 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num12, 0.0);
		double y12 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num18);
		double y13 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num19);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num20);
		double y15 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num21);
		double y16 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num22);
		double y17 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num23);
		double y18 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num23, 0.0);
		double y19 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num22, 0.0);
		double y20 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num21, 0.0);
		double y21 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num20, 0.0);
		double y22 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num19, 0.0);
		double y23 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num18, 0.0);
		double num24 = Class3089.smethod_7(x11, 2700000.0);
		double num25 = Class3089.smethod_10(num11, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num24);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num25);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num24, 0.0);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num25, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num11);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x12, y17);
		@class.method_4(x, y6);
		@class.method_4(x13, y16);
		@class.method_4(x2, y5);
		@class.method_4(x14, y15);
		@class.method_4(x3, y4);
		@class.method_4(x15, y14);
		@class.method_4(x4, y3);
		@class.method_4(x16, y13);
		@class.method_4(x5, y2);
		@class.method_4(x17, y12);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x18, y12);
		@class.method_4(x6, y2);
		@class.method_4(x19, y13);
		@class.method_4(x7, y3);
		@class.method_4(x20, y14);
		@class.method_4(x8, y4);
		@class.method_4(x21, y15);
		@class.method_4(x9, y5);
		@class.method_4(x22, y16);
		@class.method_4(x10, y6);
		@class.method_4(x23, y17);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x23, y18);
		@class.method_4(x10, y7);
		@class.method_4(x22, y19);
		@class.method_4(x9, y8);
		@class.method_4(x21, y20);
		@class.method_4(x8, y9);
		@class.method_4(x20, y21);
		@class.method_4(x7, y10);
		@class.method_4(x19, y22);
		@class.method_4(x6, y11);
		@class.method_4(x18, y23);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x17, y23);
		@class.method_4(x5, y11);
		@class.method_4(x16, y22);
		@class.method_4(x4, y10);
		@class.method_4(x15, y21);
		@class.method_4(x3, y9);
		@class.method_4(x14, y20);
		@class.method_4(x2, y8);
		@class.method_4(x13, y19);
		@class.method_4(x, y7);
		@class.method_4(x12, y18);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 37500.0);
	}
}
