using System;

namespace ns67;

internal class Class3267 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_35;

	public Class3267(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 200000.0);
		double y2 = Math.Sqrt(2.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y2, 1.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y2, 1.0);
		double x3 = Class3089.smethod_1(x, y, 100000.0);
		double x4 = Class3089.smethod_1(x2, y, 100000.0);
		double y3 = Class3089.smethod_7(x3, 2700000.0);
		double z = Class3089.smethod_10(x4, 2700000.0);
		double num = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y3, 0.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, z);
		double x5 = Class3089.smethod_3(base.Transform2D.Extents.Cx / 2.0, num, 2.0);
		double y5 = Class3089.smethod_3(base.Transform2D.Extents.Cy / 2.0, y4, 2.0);
		double num2 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num3 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_7(new Struct159(x5, 0.0), new Struct159(num, y4));
		@class.method_7(new Struct159(base.Transform2D.Extents.Cx, y5), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0));
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 100000.0);
	}
}
