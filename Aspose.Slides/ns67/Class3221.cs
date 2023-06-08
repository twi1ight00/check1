using System;

namespace ns67;

internal class Class3221 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_77;

	public Class3221(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 87500.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_1(num, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double z = Class3089.smethod_2(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 0.0, num);
		double z2 = Class3089.smethod_1(num, num, z);
		double x = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), z);
		double x2 = Class3089.smethod_1(x, 2.0, 1.0);
		double x3 = Class3089.smethod_2(x2, 0.0, z2);
		double x4 = Class3089.smethod_2(x3, 0.0, num);
		double x5 = Class3089.smethod_1(x4, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double x6 = Class3089.smethod_1(x3, 1.0, 2.0);
		double x7 = Class3089.smethod_2(x6, 0.0, num);
		double num3 = Class3089.smethod_1(x7, base.Transform2D.Extents.Cy / 2.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double num4 = Class3089.smethod_1(num, 9598.0, 32768.0);
		double left = Class3089.smethod_1(num4, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double num5 = Class3089.smethod_2(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 0.0, num4);
		double x8 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 1.0);
		double z3 = Class3089.smethod_1(num5, num5, 1.0);
		double d = Class3089.smethod_2(x8, 0.0, z3);
		double x9 = Math.Sqrt(d);
		double num6 = Class3089.smethod_1(x9, base.Transform2D.Extents.Cy / 2.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num6, 0.0);
		double x10 = Class3089.smethod_2(x5, 0.0, num2);
		double num7 = Class3089.smethod_1(x10, 1.0, 2.0);
		double x11 = Class3089.smethod_2(num2, num7, base.Transform2D.Extents.Cx);
		double x12 = Class3089.smethod_1(x11, -1.0, 1.0);
		double y2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, -1.0, 1.0);
		double num8 = Class3089.smethod_5(x12, y2);
		double x13 = Class3089.smethod_5(x12, base.Transform2D.Extents.Cy / 2.0);
		double x14 = Class3089.smethod_2(x13, 0.0, 21600000.0);
		double swingAngle = Class3089.smethod_2(x14, 0.0, num8);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx, 5400000.0, 10800000.0);
		@class.method_5(num3, num7, num8, swingAngle);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, num2, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 50000.0);
	}
}
