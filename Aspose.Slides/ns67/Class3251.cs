using System;

namespace ns67;

internal class Class3251 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_29;

	public Class3251(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 50000.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double num3 = Class3089.smethod_1(num, 29289.0, 100000.0);
		double right = Class3089.smethod_3(x, base.Transform2D.Extents.Cx, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num, 0.0);
		@class.method_4(x, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num2);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, num);
		@class.method_5(num, num, 10800000.0, 5400000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num3, num3, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 16667.0);
		values.Add("adj2", 16667.0);
	}
}
