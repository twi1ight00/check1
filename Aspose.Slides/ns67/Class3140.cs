namespace ns67;

internal class Class3140 : Class3091
{
	public override Enum493 Kind => Enum493.const_100;

	public Class3140(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_6(new Struct159(base.Transform2D.Extents.Cx / 2.0, 0.0), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy));
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
