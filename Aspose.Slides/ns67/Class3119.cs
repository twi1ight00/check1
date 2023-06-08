using System;

namespace ns67;

internal class Class3119 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_40;

	public Class3119(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 21599999.0);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], 50000.0);
		double num3 = Class3089.smethod_2(num2, 0.0, num);
		double z = Class3089.smethod_2(num3, 21600000.0, 0.0);
		double num4 = Class3089.smethod_4(num3, num3, z);
		double swingAngle = Class3089.smethod_2(0.0, 0.0, num4);
		double z2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num);
		double y2 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num);
		double z3 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num2);
		double y3 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num2);
		double y4 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y2, z2);
		double y5 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y2, z2);
		double y6 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y3, z3);
		double y7 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y3, z3);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y4, 0.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y5, 0.0);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y6, 0.0);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y7, 0.0);
		double z4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, z4);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, z4);
		double z5 = Class3089.smethod_10(num9, num2);
		double y8 = Class3089.smethod_7(num10, num2);
		double z6 = Class3089.smethod_10(num9, num);
		double y9 = Class3089.smethod_7(num10, num);
		double y10 = Class3089.smethod_6(num9, y8, z5);
		double y11 = Class3089.smethod_9(num10, y8, z5);
		double y12 = Class3089.smethod_6(num9, y9, z6);
		double y13 = Class3089.smethod_9(num10, y9, z6);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y10, 0.0);
		double num12 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y11, 0.0);
		double num13 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y12, 0.0);
		double num14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y13, 0.0);
		double z7 = Class3089.smethod_2(21600000.0, 0.0, num);
		double x = Class3089.smethod_2(num4, 0.0, z7);
		double val = Math.Max(num5, num11);
		double val2 = Math.Max(num7, num13);
		double z8 = Math.Max(val, val2);
		double right = Class3089.smethod_4(x, base.Transform2D.Extents.Cx, z8);
		double num15 = Class3089.smethod_2(5400000.0, 0.0, num);
		double z9 = Class3089.smethod_2(27000000.0, 0.0, num);
		double z10 = Class3089.smethod_4(num15, num15, z9);
		double x2 = Class3089.smethod_2(num4, 0.0, z10);
		double val3 = Math.Max(num6, num12);
		double val4 = Math.Max(num8, num14);
		double z11 = Math.Max(val3, val4);
		double bottom = Class3089.smethod_4(x2, base.Transform2D.Extents.Cy, z11);
		double num16 = Class3089.smethod_2(10800000.0, 0.0, num);
		double z12 = Class3089.smethod_2(32400000.0, 0.0, num);
		double z13 = Class3089.smethod_4(num16, num16, z12);
		double x3 = Class3089.smethod_2(num4, 0.0, z13);
		double val5 = Math.Min(num5, num11);
		double val6 = Math.Min(num7, num13);
		double z14 = Math.Min(val5, val6);
		double left = Class3089.smethod_4(x3, 0.0, z14);
		double num17 = Class3089.smethod_2(16200000.0, 0.0, num);
		double z15 = Class3089.smethod_2(37800000.0, 0.0, num);
		double z16 = Class3089.smethod_4(num17, num17, z15);
		double x4 = Class3089.smethod_2(num4, 0.0, z16);
		double val7 = Math.Min(num6, num12);
		double val8 = Math.Min(num8, num14);
		double z17 = Math.Min(val7, val8);
		double top = Class3089.smethod_4(x4, 0.0, z17);
		Class3089.smethod_3(num5, num13, 2.0);
		Class3089.smethod_3(num6, num14, 2.0);
		Class3089.smethod_3(num7, num11, 2.0);
		Class3089.smethod_3(num8, num12, 2.0);
		double x5 = Class3089.smethod_2(num, 0.0, 5400000.0);
		double y14 = Class3089.smethod_2(num2, 5400000.0, 0.0);
		Class3089.smethod_3(x5, y14, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num5, num6);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, num4);
		@class.method_4(num11, num12);
		@class.method_5(num10, num9, num2, swingAngle);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 10800000.0);
		values.Add("adj2", 0.0);
		values.Add("adj3", 25000.0);
	}
}
