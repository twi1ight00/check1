using System;

namespace ns67;

internal class Class3203 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_91;

	public Class3203(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 100000.0);
		double val = Class3089.smethod_2(100000.0, 0.0, num);
		double x = Math.Min(val, num);
		double x2 = Class3089.smethod_1(x, 1.0, 2.0);
		double z = Class3089.smethod_1(x2, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, 100000.0);
		double y2 = Class3089.smethod_2(x3, num2, 0.0);
		double z2 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num3 = Class3089.smethod_10(num2, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		double top = Class3089.smethod_2(num2, 0.0, num3);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, num3, num2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, y2);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 0.0, -5400000.0);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 5400000.0, -5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num2);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, y2);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 0.0, -5400000.0);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 5400000.0, -5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, num2);
		@class.method_5(num2, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.TextRectangle = new Class3457(left, top, base.Transform2D.Extents.Cx, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 8333.0);
		values.Add("adj2", 50000.0);
	}
}
