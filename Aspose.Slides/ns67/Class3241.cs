using System;

namespace ns67;

internal class Class3241 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_90;

	public Class3241(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], z);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double y3 = Class3089.smethod_7(base.Transform2D.Extents.Cx, 2700000.0);
		double num2 = Class3089.smethod_10(num, 2700000.0);
		double right = Class3089.smethod_2(0.0, y3, 0.0);
		double top = Class3089.smethod_2(num, 0.0, num2);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, num2, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_5(num, base.Transform2D.Extents.Cx, 16200000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx, y2);
		@class.method_5(num, base.Transform2D.Extents.Cx, 0.0, 5400000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_5(num, base.Transform2D.Extents.Cx, 16200000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx, y2);
		@class.method_5(num, base.Transform2D.Extents.Cx, 0.0, 5400000.0);
		@class.TextRectangle = new Class3457(0.0, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 8333.0);
	}
}
