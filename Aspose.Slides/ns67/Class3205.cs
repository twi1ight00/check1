using System;

namespace ns67;

internal class Class3205 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	private const string string_3 = "adj4";

	private const string string_4 = "adj5";

	public override Enum493 Kind => Enum493.const_65;

	public Class3205(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj5"], 25000.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double num2 = Class3089.smethod_0(1.0, base.AdjustValues["adj3"], 21599999.0);
		double num3 = Class3089.smethod_0(0.0, base.AdjustValues["adj4"], 21599999.0);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num5 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num, 100000.0);
		double y2 = Class3089.smethod_1(num4, 1.0, 2.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y2, num5);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y2, num5);
		double num8 = Class3089.smethod_2(num6, 0.0, num4);
		double num9 = Class3089.smethod_2(num7, 0.0, num4);
		double x = Class3089.smethod_2(num8, y2, 0.0);
		double x2 = Class3089.smethod_2(num9, y2, 0.0);
		double z2 = Class3089.smethod_10(x, num2);
		double y3 = Class3089.smethod_7(x2, num2);
		double num10 = Class3089.smethod_6(x, y3, z2);
		double num11 = Class3089.smethod_9(x2, y3, z2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num10, 0.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num11, 0.0);
		double num12 = Math.Min(num8, num9);
		double num13 = Class3089.smethod_1(num10, num10, 1.0);
		double num14 = Class3089.smethod_1(num11, num11, 1.0);
		double z3 = Class3089.smethod_1(num12, num12, 1.0);
		double x5 = Class3089.smethod_2(num13, 0.0, z3);
		double y4 = Class3089.smethod_2(num14, 0.0, z3);
		double x6 = Class3089.smethod_1(x5, y4, num13);
		double z4 = Class3089.smethod_1(x6, 1.0, num14);
		double d = Class3089.smethod_2(1.0, 0.0, z4);
		double y5 = Math.Sqrt(d);
		double x7 = Class3089.smethod_1(x5, 1.0, num10);
		double z5 = Class3089.smethod_1(x7, 1.0, num11);
		double y6 = Class3089.smethod_3(1.0, y5, z5);
		double num15 = Class3089.smethod_5(1.0, y6);
		double z6 = Class3089.smethod_2(num15, 21600000.0, 0.0);
		double x8 = Class3089.smethod_4(num15, num15, z6);
		double num16 = Class3089.smethod_2(x8, 0.0, num2);
		double z7 = Class3089.smethod_2(num16, 21600000.0, 0.0);
		double num17 = Class3089.smethod_4(num16, num16, z7);
		double x9 = Class3089.smethod_2(num17, 0.0, 10800000.0);
		double y7 = Class3089.smethod_2(num17, 0.0, 21600000.0);
		double value = Class3089.smethod_4(x9, y7, num17);
		double x10 = Math.Abs(value);
		double x11 = Class3089.smethod_1(x10, -1.0, 1.0);
		double x12 = Math.Abs(base.AdjustValues["adj2"]);
		double y8 = Class3089.smethod_1(x12, -1.0, 1.0);
		double y9 = Class3089.smethod_0(x11, y8, 0.0);
		double num18 = Class3089.smethod_2(num2, y9, 0.0);
		double z8 = Class3089.smethod_10(x, num18);
		double y10 = Class3089.smethod_7(x2, num18);
		double y11 = Class3089.smethod_6(x, y10, z8);
		double y12 = Class3089.smethod_9(x2, y10, z8);
		double x13 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y11, 0.0);
		double y13 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y12, 0.0);
		double z9 = Class3089.smethod_10(num6, num3);
		double y14 = Class3089.smethod_7(num7, num3);
		double y15 = Class3089.smethod_6(num6, y14, z9);
		double y16 = Class3089.smethod_9(num7, y14, z9);
		double x14 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y15, 0.0);
		double y17 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y16, 0.0);
		double z10 = Class3089.smethod_10(num8, num3);
		double y18 = Class3089.smethod_7(num9, num3);
		double y19 = Class3089.smethod_6(num8, y18, z10);
		double y20 = Class3089.smethod_9(num9, y18, z10);
		double x15 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y19, 0.0);
		double y21 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y20, 0.0);
		double y22 = Class3089.smethod_7(num5, num18);
		double y23 = Class3089.smethod_10(num5, num18);
		double num19 = Class3089.smethod_2(x3, y22, 0.0);
		double num20 = Class3089.smethod_2(x4, y23, 0.0);
		double z11 = Class3089.smethod_7(num5, num18);
		double z12 = Class3089.smethod_10(num5, num18);
		double num21 = Class3089.smethod_2(x3, 0.0, z11);
		double num22 = Class3089.smethod_2(x4, 0.0, z12);
		double x16 = Class3089.smethod_2(num21, 0.0, base.Transform2D.Extents.Cx / 2.0);
		double x17 = Class3089.smethod_2(num22, 0.0, base.Transform2D.Extents.Cy / 2.0);
		double x18 = Class3089.smethod_2(num19, 0.0, base.Transform2D.Extents.Cx / 2.0);
		double x19 = Class3089.smethod_2(num20, 0.0, base.Transform2D.Extents.Cy / 2.0);
		double num23 = Math.Min(num6, num7);
		double num24 = Class3089.smethod_1(x16, num23, num6);
		double num25 = Class3089.smethod_1(x17, num23, num7);
		double x20 = Class3089.smethod_1(x18, num23, num6);
		double num26 = Class3089.smethod_1(x19, num23, num7);
		double num27 = Class3089.smethod_2(x20, 0.0, num24);
		double num28 = Class3089.smethod_2(num26, 0.0, num25);
		double num29 = Class3089.smethod_8(num27, num28, 0.0);
		double x21 = Class3089.smethod_1(num24, num26, 1.0);
		double z13 = Class3089.smethod_1(x20, num25, 1.0);
		double num30 = Class3089.smethod_2(x21, 0.0, z13);
		double x22 = Class3089.smethod_1(num23, num23, 1.0);
		double num31 = Class3089.smethod_1(num29, num29, 1.0);
		double x23 = Class3089.smethod_1(x22, num31, 1.0);
		double z14 = Class3089.smethod_1(num30, num30, 1.0);
		double val = Class3089.smethod_2(x23, 0.0, z14);
		double d2 = Math.Max(val, 0.0);
		double y24 = Math.Sqrt(d2);
		double x24 = Class3089.smethod_1(num28, -1.0, 1.0);
		double x25 = Class3089.smethod_4(x24, -1.0, 1.0);
		double x26 = Class3089.smethod_1(x25, num27, 1.0);
		double num32 = Class3089.smethod_1(x26, y24, 1.0);
		double x27 = Class3089.smethod_1(num30, num28, 1.0);
		double num33 = Class3089.smethod_3(x27, num32, num31);
		double x28 = Class3089.smethod_2(x27, 0.0, num32);
		double z15 = Class3089.smethod_1(x28, 1.0, num31);
		double x29 = Math.Abs(num28);
		double num34 = Class3089.smethod_1(x29, y24, 1.0);
		double x30 = Class3089.smethod_1(num30, num27, -1.0);
		double num35 = Class3089.smethod_3(x30, num34, num31);
		double x31 = Class3089.smethod_2(x30, 0.0, num34);
		double z16 = Class3089.smethod_1(x31, 1.0, num31);
		double x32 = Class3089.smethod_2(x20, 0.0, num33);
		double x33 = Class3089.smethod_2(x20, 0.0, z15);
		double y25 = Class3089.smethod_2(num26, 0.0, num35);
		double y26 = Class3089.smethod_2(num26, 0.0, z16);
		double z17 = Class3089.smethod_8(x32, y25, 0.0);
		double x34 = Class3089.smethod_8(x33, y26, 0.0);
		double x35 = Class3089.smethod_2(x34, 0.0, z17);
		double x36 = Class3089.smethod_4(x35, num33, z15);
		double x37 = Class3089.smethod_4(x35, num35, z16);
		double num36 = Class3089.smethod_1(x36, num6, num23);
		double y27 = Class3089.smethod_1(x37, num7, num23);
		double num37 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num36, 0.0);
		double num38 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y27, 0.0);
		double num39 = Class3089.smethod_1(x16, num12, num8);
		double num40 = Class3089.smethod_1(x17, num12, num9);
		double x38 = Class3089.smethod_1(x18, num12, num8);
		double num41 = Class3089.smethod_1(x19, num12, num9);
		double num42 = Class3089.smethod_2(x38, 0.0, num39);
		double num43 = Class3089.smethod_2(num41, 0.0, num40);
		double num44 = Class3089.smethod_8(num42, num43, 0.0);
		double x39 = Class3089.smethod_1(num39, num41, 1.0);
		double z18 = Class3089.smethod_1(x38, num40, 1.0);
		double num45 = Class3089.smethod_2(x39, 0.0, z18);
		double x40 = Class3089.smethod_1(num12, num12, 1.0);
		double num46 = Class3089.smethod_1(num44, num44, 1.0);
		double x41 = Class3089.smethod_1(x40, num46, 1.0);
		double z19 = Class3089.smethod_1(num45, num45, 1.0);
		double val2 = Class3089.smethod_2(x41, 0.0, z19);
		double d3 = Math.Max(val2, 0.0);
		double y28 = Math.Sqrt(d3);
		double x42 = Class3089.smethod_1(x25, num42, 1.0);
		double num47 = Class3089.smethod_1(x42, y28, 1.0);
		double x43 = Class3089.smethod_1(num45, num43, 1.0);
		double num48 = Class3089.smethod_3(x43, num47, num46);
		double x44 = Class3089.smethod_2(x43, 0.0, num47);
		double z20 = Class3089.smethod_1(x44, 1.0, num46);
		double x45 = Math.Abs(num43);
		double num49 = Class3089.smethod_1(x45, y28, 1.0);
		double x46 = Class3089.smethod_1(num45, num42, -1.0);
		double num50 = Class3089.smethod_3(x46, num49, num46);
		double x47 = Class3089.smethod_2(x46, 0.0, num49);
		double z21 = Class3089.smethod_1(x47, 1.0, num46);
		double x48 = Class3089.smethod_2(num39, 0.0, num48);
		double x49 = Class3089.smethod_2(num39, 0.0, z20);
		double y29 = Class3089.smethod_2(num40, 0.0, num50);
		double y30 = Class3089.smethod_2(num40, 0.0, z21);
		double z22 = Class3089.smethod_8(x48, y29, 0.0);
		double x50 = Class3089.smethod_8(x49, y30, 0.0);
		double x51 = Class3089.smethod_2(x50, 0.0, z22);
		double x52 = Class3089.smethod_4(x51, num48, z20);
		double x53 = Class3089.smethod_4(x51, num50, z21);
		double num51 = Class3089.smethod_1(x52, num8, num12);
		double y31 = Class3089.smethod_1(x53, num9, num12);
		double num52 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num51, 0.0);
		double num53 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y31, 0.0);
		double num54 = Class3089.smethod_5(num51, y31);
		double z23 = Class3089.smethod_2(num54, 21600000.0, 0.0);
		double num55 = Class3089.smethod_4(num54, num54, z23);
		double num56 = Class3089.smethod_2(num3, 0.0, num55);
		double z24 = Class3089.smethod_2(num56, 21600000.0, 0.0);
		double num57 = Class3089.smethod_4(num56, num56, z24);
		double startAngle = Class3089.smethod_2(num55, num57, 0.0);
		double swingAngle = Class3089.smethod_2(0.0, 0.0, num57);
		double x54 = Class3089.smethod_2(num37, 0.0, num52);
		double y32 = Class3089.smethod_2(num38, 0.0, num53);
		double x55 = Class3089.smethod_8(x54, y32, 0.0);
		double x56 = Class3089.smethod_1(x55, 1.0, 2.0);
		double x57 = Class3089.smethod_2(x56, 0.0, num5);
		double x58 = Class3089.smethod_4(x57, num37, num19);
		double y33 = Class3089.smethod_4(x57, num38, num20);
		double x59 = Class3089.smethod_4(x57, num52, num21);
		double y34 = Class3089.smethod_4(x57, num53, num22);
		double num58 = Class3089.smethod_5(num36, y27);
		double z25 = Class3089.smethod_2(num58, 21600000.0, 0.0);
		double x60 = Class3089.smethod_4(num58, num58, z25);
		double num59 = Class3089.smethod_2(x60, 0.0, num3);
		double y35 = Class3089.smethod_2(num59, 0.0, 21600000.0);
		double num60 = Class3089.smethod_4(num59, y35, num59);
		double startAngle2 = Class3089.smethod_2(num3, num60, 0.0);
		double swingAngle2 = Class3089.smethod_2(0.0, 0.0, num60);
		double z26 = Class3089.smethod_10(x, num3);
		double y36 = Class3089.smethod_7(x2, num3);
		num42 = Class3089.smethod_6(x, y36, z26);
		num43 = Class3089.smethod_9(x2, y36, z26);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num42, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num43, 0.0);
		Class3089.smethod_2(num3, 5400000.0, 0.0);
		Class3089.smethod_2(num18, 0.0, 5400000.0);
		Class3089.smethod_2(num18, 10800000.0, 0.0);
		double num61 = Class3089.smethod_7(num6, 2700000.0);
		double num62 = Class3089.smethod_10(num7, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num61);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num61, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num62);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num62, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x14, y17);
		@class.method_4(x15, y21);
		@class.method_5(num9, num8, startAngle, swingAngle);
		@class.method_4(x59, y34);
		@class.method_4(x13, y13);
		@class.method_4(x58, y33);
		@class.method_4(num37, num38);
		@class.method_5(num7, num6, startAngle2, swingAngle2);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 12500.0);
		values.Add("adj2", -1142319.0);
		values.Add("adj3", 1142319.0);
		values.Add("adj4", 10800000.0);
		values.Add("adj5", 12500.0);
	}
}
