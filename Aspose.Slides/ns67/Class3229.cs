namespace ns67;

internal class Class3229 : Class3091
{
	public override Enum493 Kind => Enum493.const_38;

	public Class3229(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_7(base.Transform2D.Extents.Cx, 13500000.0);
		double y2 = Class3089.smethod_10(base.Transform2D.Extents.Cy, 13500000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx, y, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy, y2, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_5(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx, 10800000.0, 5400000.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
