namespace ns67;

internal class Class3242 : Class3091
{
	public override Enum493 Kind => Enum493.const_3;

	public Class3242(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 7.0, 12.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 7.0, 12.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 11.0, 12.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(base.Transform2D.Extents.Cx / 12.0, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
