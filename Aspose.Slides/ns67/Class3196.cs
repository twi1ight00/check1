using System;

namespace ns67;

internal class Class3196 : Class3091
{
	private const string string_0 = "adj";

	private const string string_1 = "vf";

	public override Enum493 Kind => Enum493.const_10;

	public Class3196(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj"], num);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num3 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num2, 100000.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num3);
		double num4 = Class3089.smethod_10(x, 3600000.0);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num4);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, 0.0);
		double num5 = Class3089.smethod_1(num, -1.0, 2.0);
		double x3 = Class3089.smethod_2(num2, num5, 0.0);
		double x4 = Class3089.smethod_4(x3, 4.0, 2.0);
		double y3 = Class3089.smethod_4(x3, 3.0, 2.0);
		double y4 = Class3089.smethod_4(x3, num5, 0.0);
		double x5 = Class3089.smethod_3(num2, y4, num5);
		double y5 = Class3089.smethod_1(x5, y3, -1.0);
		double y6 = Class3089.smethod_2(x4, y5, 0.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y6, 24.0);
		double num7 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y6, 24.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num6);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num7);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num3, y);
		@class.method_4(x2, y);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x2, y2);
		@class.method_4(num3, y2);
		@class.method_8();
		@class.TextRectangle = new Class3457(num6, num7, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
		values.Add("vf", 115470.0);
	}
}
