using System;

namespace ns67;

internal class Class3159 : Class3091
{
	public override Enum493 Kind => Enum493.const_158;

	public Class3159(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, 29289.0, 100000.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0);
		@class.method_5(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, 10800000.0, 5400000.0);
		@class.method_4(x, 0.0);
		@class.method_5(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, 16200000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx, y);
		@class.method_5(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, 0.0, 5400000.0);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, base.Transform2D.Extents.Cy);
		@class.method_5(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 6.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num, num, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
