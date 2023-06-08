using System;

namespace ns67;

internal class Class3249 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_32;

	public Class3249(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 50000.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		double x3 = Class3089.smethod_2(num, 0.0, num2);
		double x4 = Class3089.smethod_4(x3, num, num2);
		double num3 = Class3089.smethod_1(x4, 1.0, 2.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num3);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num, 0.0);
		@class.method_4(x2, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num2);
		@class.method_4(base.Transform2D.Extents.Cx, y3);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_4(num2, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, y4);
		@class.method_4(0.0, num);
		@class.method_8();
		@class.TextRectangle = new Class3457(num3, num3, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 0.0);
		values.Add("adj2", 16667.0);
	}
}
