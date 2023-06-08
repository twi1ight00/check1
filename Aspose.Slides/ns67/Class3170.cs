namespace ns67;

internal class Class3170 : Class3091
{
	public override Enum493 Kind => Enum493.const_155;

	public Class3170(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 2.0, 3.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(6.0, 6.0, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(1.0, 0.0);
		@class.method_4(5.0, 0.0);
		@class.method_5(3.0, 1.0, 16200000.0, 10800000.0);
		@class.method_4(1.0, 6.0);
		@class.method_5(3.0, 1.0, 5400000.0, 10800000.0);
		@class.method_8();
		@class.method_2(6.0, 6.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(5.0, 6.0);
		@class.method_5(3.0, 1.0, 5400000.0, 10800000.0);
		@class.method_2(6.0, 6.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(1.0, 0.0);
		@class.method_4(5.0, 0.0);
		@class.method_5(3.0, 1.0, 16200000.0, 10800000.0);
		@class.method_4(1.0, 6.0);
		@class.method_5(3.0, 1.0, 5400000.0, 10800000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(base.Transform2D.Extents.Cx / 6.0, 0.0, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
