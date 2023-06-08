namespace ns67;

internal class Class3180 : Class3091
{
	public override Enum493 Kind => Enum493.const_134;

	public Class3180(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 7.0, 8.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(1.0, 1.0, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(1.0, 0.0);
		@class.method_4(1.0, 1.0);
		@class.method_4(0.0, 1.0);
		@class.method_8();
		@class.method_2(8.0, 8.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(1.0, 0.0);
		@class.method_4(1.0, 8.0);
		@class.method_3(7.0, 0.0);
		@class.method_4(7.0, 8.0);
		@class.method_2(1.0, 1.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(1.0, 0.0);
		@class.method_4(1.0, 1.0);
		@class.method_4(0.0, 1.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(base.Transform2D.Extents.Cx / 8.0, 0.0, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
