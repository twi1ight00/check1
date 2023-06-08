using System;

namespace ns67;

internal class Class3204 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_89;

	public Class3204(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], z);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double z2 = Class3089.smethod_7(base.Transform2D.Extents.Cx, 2700000.0);
		double num2 = Class3089.smethod_10(num, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		double top = Class3089.smethod_2(num, 0.0, num2);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, num2, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_5(num, base.Transform2D.Extents.Cx, 5400000.0, 5400000.0);
		@class.method_4(0.0, num);
		@class.method_5(num, base.Transform2D.Extents.Cx, 10800000.0, 5400000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_5(num, base.Transform2D.Extents.Cx, 5400000.0, 5400000.0);
		@class.method_4(0.0, num);
		@class.method_5(num, base.Transform2D.Extents.Cx, 10800000.0, 5400000.0);
		@class.TextRectangle = new Class3457(left, top, base.Transform2D.Extents.Cx, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 8333.0);
	}
}
