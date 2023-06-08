namespace ns67;

internal class Class3166 : Class3091
{
	public override Enum493 Kind => Enum493.const_149;

	public Class3166(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 3.0, 4.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(2.0, 2.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 2.0);
		@class.method_4(1.0, 0.0);
		@class.method_4(2.0, 2.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(base.Transform2D.Extents.Cx / 4.0, base.Transform2D.Extents.Cy / 2.0, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
