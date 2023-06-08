using System;

namespace ns67;

internal class Class3191 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_172;

	public Class3191(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 20000.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 5358.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double x = Class3089.smethod_1(num, 1.0, 2.0);
		double y3 = Class3089.smethod_1(num2, 1.0, 2.0);
		double y4 = Class3089.smethod_2(x, y3, 0.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(num4, 0.0, num3);
		double x3 = Class3089.smethod_4(x2, num3, num4);
		double num5 = Class3089.smethod_5(x3, y4);
		double y5 = Class3089.smethod_2(19800000.0, 0.0, num5);
		double y6 = Class3089.smethod_2(19800000.0, num5, 0.0);
		double x4 = Class3089.smethod_7(num4, y5);
		double y7 = Class3089.smethod_10(num3, y5);
		double num6 = Class3089.smethod_5(x4, y7);
		double x5 = Class3089.smethod_7(num3, num6);
		double y8 = Class3089.smethod_10(num4, num6);
		double z = Class3089.smethod_8(x5, y8, 0.0);
		double x6 = Class3089.smethod_1(num4, num3, z);
		double y9 = Class3089.smethod_7(x6, num6);
		double y10 = Class3089.smethod_10(x6, num6);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y9, 0.0);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y10, 0.0);
		double x7 = Class3089.smethod_7(num4, y6);
		double y11 = Class3089.smethod_10(num3, y6);
		double num9 = Class3089.smethod_5(x7, y11);
		double x8 = Class3089.smethod_7(num3, num9);
		double y12 = Class3089.smethod_10(num4, num9);
		double z2 = Class3089.smethod_8(x8, y12, 0.0);
		double x9 = Class3089.smethod_1(num4, num3, z2);
		double y13 = Class3089.smethod_7(x9, num9);
		double y14 = Class3089.smethod_10(x9, num9);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y13, 0.0);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y14, 0.0);
		double num12 = Class3089.smethod_2(num7, 0.0, num10);
		double num13 = Class3089.smethod_2(num8, 0.0, num11);
		Class3089.smethod_8(num12, num13, 0.0);
		y = Class3089.smethod_5(num13, num12);
		double num14 = Class3089.smethod_10(num2, y);
		double num15 = Class3089.smethod_7(num2, y);
		double x10 = Class3089.smethod_2(num10, num14, 0.0);
		double x11 = Class3089.smethod_2(num11, num15, 0.0);
		double x12 = Class3089.smethod_2(num7, 0.0, num14);
		double x13 = Class3089.smethod_2(num8, 0.0, num15);
		double y15 = Class3089.smethod_10(num, y);
		double z3 = Class3089.smethod_7(num, y);
		double num16 = Class3089.smethod_2(x11, y15, 0.0);
		double num17 = Class3089.smethod_2(x10, 0.0, z3);
		double num18 = Class3089.smethod_2(x13, y15, 0.0);
		double num19 = Class3089.smethod_2(x12, 0.0, z3);
		double y16 = Class3089.smethod_2(16200000.0, num5, 0.0);
		double x14 = Class3089.smethod_7(num4, y16);
		double y17 = Class3089.smethod_10(num3, y16);
		double num20 = Class3089.smethod_5(x14, y17);
		double x15 = Class3089.smethod_7(num3, num20);
		double y18 = Class3089.smethod_10(num4, num20);
		double z4 = Class3089.smethod_8(x15, y18, 0.0);
		double x16 = Class3089.smethod_1(num4, num3, z4);
		double num21 = Class3089.smethod_7(x16, num20);
		double y19 = Class3089.smethod_10(x16, num20);
		double x17 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num21, 0.0);
		double num22 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y19, 0.0);
		double x18 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num21);
		double x19 = Class3089.smethod_2(x17, 0.0, num2);
		double x20 = Class3089.smethod_2(x18, num2, 0.0);
		double num23 = Class3089.smethod_2(num22, 0.0, num);
		double swingAngle = Class3089.smethod_2(num6, 0.0, num20);
		double y20 = Class3089.smethod_2(1800000.0, 0.0, num5);
		double y21 = Class3089.smethod_2(1800000.0, num5, 0.0);
		double x21 = Class3089.smethod_7(num4, y20);
		double y22 = Class3089.smethod_10(num3, y20);
		double x22 = Class3089.smethod_5(x21, y22);
		double y23 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num11);
		double x23 = Class3089.smethod_7(num4, y21);
		double y24 = Class3089.smethod_10(num3, y21);
		double startAngle = Class3089.smethod_5(x23, y24);
		double num24 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num8);
		double y25 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num18);
		double y26 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num16);
		double swingAngle2 = Class3089.smethod_2(x22, 0.0, num9);
		double y27 = Class3089.smethod_2(5400000.0, num5, 0.0);
		double x24 = Class3089.smethod_7(num4, y27);
		double y28 = Class3089.smethod_10(num3, y27);
		double startAngle2 = Class3089.smethod_5(x24, y28);
		double y29 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num22);
		double y30 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num23);
		double y31 = Class3089.smethod_2(9000000.0, num5, 0.0);
		double x25 = Class3089.smethod_7(num4, y31);
		double y32 = Class3089.smethod_10(num3, y31);
		double startAngle3 = Class3089.smethod_5(x25, y32);
		double x26 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num10);
		double x27 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num17);
		double x28 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num19);
		double y33 = Class3089.smethod_2(12600000.0, num5, 0.0);
		double x29 = Class3089.smethod_7(num4, y33);
		double y34 = Class3089.smethod_10(num3, y33);
		double startAngle4 = Class3089.smethod_5(x29, y34);
		double num25 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num7);
		double x30 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num19);
		double x31 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num17);
		double z5 = Class3089.smethod_3(num19, num17, 2.0);
		double z6 = Class3089.smethod_3(num18, num16, 2.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z6);
		Class3089.smethod_3(base.Transform2D.Extents.Cx, 0.0, z5);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num7, num8);
		@class.method_4(num19, num18);
		@class.method_4(num17, num16);
		@class.method_4(num10, num11);
		@class.method_5(num3, num4, num9, swingAngle2);
		@class.method_4(num17, y26);
		@class.method_4(num19, y25);
		@class.method_4(num7, num24);
		@class.method_5(num3, num4, startAngle, swingAngle);
		@class.method_4(x19, y30);
		@class.method_4(x20, y30);
		@class.method_4(x18, y29);
		@class.method_5(num3, num4, startAngle2, swingAngle);
		@class.method_4(x28, y25);
		@class.method_4(x27, y26);
		@class.method_4(x26, y23);
		@class.method_5(num3, num4, startAngle3, swingAngle2);
		@class.method_4(x31, num16);
		@class.method_4(x30, num18);
		@class.method_4(num25, num8);
		@class.method_5(num3, num4, startAngle4, swingAngle);
		@class.method_4(x20, num23);
		@class.method_4(x19, num23);
		@class.method_4(x17, num22);
		@class.method_5(num3, num4, num20, swingAngle);
		@class.method_8();
		@class.TextRectangle = new Class3457(num25, num8, num7, num24);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 15000.0);
		values.Add("adj2", 3526.0);
	}
}
