using System;

namespace ns67;

internal class Class3144 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_70;

	public Class3144(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 100000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double z2 = Class3089.smethod_3(num, num2, 4.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, z2);
		double num4 = Class3089.smethod_1(num3, 2.0, 1.0);
		double x = Class3089.smethod_1(num4, num4, 1.0);
		double z3 = Class3089.smethod_1(num, num, 1.0);
		double d = Class3089.smethod_2(x, 0.0, z3);
		double x2 = Math.Sqrt(d);
		double num5 = Class3089.smethod_1(x2, base.Transform2D.Extents.Cy, num4);
		double z4 = Class3089.smethod_1(100000.0, num5, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z4);
		double num6 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), base.AdjustValues["adj3"], 100000.0);
		double num7 = Class3089.smethod_2(num3, num, 0.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cy, 1.0);
		double z5 = Class3089.smethod_1(num6, num6, 1.0);
		double d2 = Class3089.smethod_2(x3, 0.0, z5);
		double x4 = Math.Sqrt(d2);
		double y3 = Class3089.smethod_1(x4, num3, base.Transform2D.Extents.Cy);
		double x5 = Class3089.smethod_2(num3, y3, 0.0);
		double x6 = Class3089.smethod_2(num7, y3, 0.0);
		double x7 = Class3089.smethod_2(num2, 0.0, num);
		double num8 = Class3089.smethod_1(x7, 1.0, 2.0);
		double x8 = Class3089.smethod_2(x5, 0.0, num8);
		double x9 = Class3089.smethod_2(x6, num8, 0.0);
		double z6 = Class3089.smethod_1(num2, 1.0, 2.0);
		double x10 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z6);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num6);
		double num9 = Class3089.smethod_5(num6, y3);
		double swingAngle = Class3089.smethod_2(0.0, 0.0, num9);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num5);
		double x11 = Class3089.smethod_3(num3, num7, 2.0);
		double y6 = Class3089.smethod_1(num, 1.0, 2.0);
		double num10 = Class3089.smethod_5(num5, y6);
		double startAngle = Class3089.smethod_2(16200000.0, num9, 0.0);
		double startAngle2 = Class3089.smethod_2(16200000.0, 0.0, num10);
		double swingAngle2 = Class3089.smethod_2(num10, 0.0, 5400000.0);
		double swingAngle3 = Class3089.smethod_2(5400000.0, num10, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(x10, base.Transform2D.Extents.Cy);
		@class.method_4(x8, y4);
		@class.method_4(x5, y4);
		@class.method_5(base.Transform2D.Extents.Cy, num3, startAngle, swingAngle);
		@class.method_4(num7, 0.0);
		@class.method_5(base.Transform2D.Extents.Cy, num3, 16200000.0, num9);
		@class.method_4(x9, y4);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(x11, y5);
		@class.method_5(base.Transform2D.Extents.Cy, num3, startAngle2, swingAngle2);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_5(base.Transform2D.Extents.Cy, num3, 10800000.0, swingAngle3);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x11, y5);
		@class.method_5(base.Transform2D.Extents.Cy, num3, startAngle2, swingAngle2);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_5(base.Transform2D.Extents.Cy, num3, 10800000.0, 5400000.0);
		@class.method_4(num7, 0.0);
		@class.method_5(base.Transform2D.Extents.Cy, num3, 16200000.0, num9);
		@class.method_4(x9, y4);
		@class.method_4(x10, base.Transform2D.Extents.Cy);
		@class.method_4(x8, y4);
		@class.method_4(x5, y4);
		@class.method_5(base.Transform2D.Extents.Cy, num3, startAngle, swingAngle);
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 25000.0);
		values.Add("adj2", 50000.0);
		values.Add("adj3", 25000.0);
	}
}
