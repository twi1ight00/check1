namespace ns67;

internal class Class3214 : Class3091
{
	public override Enum493 Kind => Enum493.const_1;

	public Class3214(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
