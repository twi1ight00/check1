namespace ns67;

internal class Class3165 : Class3091
{
	public override Enum493 Kind => Enum493.const_136;

	public Class3165(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 17322.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 20172.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(21600.0, 21600.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(21600.0, 0.0);
		@class.method_4(21600.0, 17322.0);
		@class.method_6(new Struct159(10800.0, 17322.0), new Struct159(10800.0, 23922.0), new Struct159(0.0, 20172.0));
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
