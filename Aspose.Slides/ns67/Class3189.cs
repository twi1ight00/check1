using System;

namespace ns67;

internal class Class3189 : Class3091
{
	private const string string_0 = "adj1";

	public override Enum493 Kind => Enum493.const_83;

	public Class3189(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_3(num, num);
		@class.method_4(num, num3);
		@class.method_4(num2, num3);
		@class.method_4(num2, num);
		@class.method_8();
		@class.TextRectangle = new Class3457(num, num, num2, num3);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 12500.0);
	}
}
