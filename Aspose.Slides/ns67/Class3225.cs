using System;

namespace ns67;

internal class Class3225 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_12;

	public Class3225(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num2 = Class3089.smethod_1(num, 1.0, 2.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, num);
		@class.method_4(num, 0.0);
		@class.method_4(x, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num);
		@class.method_4(base.Transform2D.Extents.Cx, y2);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_4(num, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, y2);
		@class.method_8();
		@class.TextRectangle = new Class3457(num2, num2, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 29289.0);
	}
}
