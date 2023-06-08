namespace ns67;

internal class Class3184 : Class3091
{
	public override Enum493 Kind => Enum493.const_144;

	public Class3184(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 9.0, 10.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 4.0, 5.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(20.0, 20.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 2.0);
		@class.method_5(2.0, 5.0, 10800000.0, -10800000.0);
		@class.method_5(2.0, 5.0, 10800000.0, 10800000.0);
		@class.method_4(20.0, 18.0);
		@class.method_5(2.0, 5.0, 0.0, -10800000.0);
		@class.method_5(2.0, 5.0, 0.0, 10800000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, base.Transform2D.Extents.Cy / 5.0, base.Transform2D.Extents.Cx, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
