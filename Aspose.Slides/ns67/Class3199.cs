namespace ns67;

internal class Class3199 : Class3091
{
	public override Enum493 Kind => Enum493.const_79;

	public Class3199(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 4627.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 8485.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 16702.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 14522.0, 21600.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 6320.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 8615.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 13937.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 13290.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(21600.0, 21600.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(10800.0, 5800.0);
		@class.method_4(14522.0, 0.0);
		@class.method_4(14155.0, 5325.0);
		@class.method_4(18380.0, 4457.0);
		@class.method_4(16702.0, 7315.0);
		@class.method_4(21097.0, 8137.0);
		@class.method_4(17607.0, 10475.0);
		@class.method_4(21600.0, 13290.0);
		@class.method_4(16837.0, 12942.0);
		@class.method_4(18145.0, 18095.0);
		@class.method_4(14020.0, 14457.0);
		@class.method_4(13247.0, 19737.0);
		@class.method_4(10532.0, 14935.0);
		@class.method_4(8485.0, 21600.0);
		@class.method_4(7715.0, 15627.0);
		@class.method_4(4762.0, 17617.0);
		@class.method_4(5667.0, 13937.0);
		@class.method_4(135.0, 14587.0);
		@class.method_4(3722.0, 11775.0);
		@class.method_4(0.0, 8615.0);
		@class.method_4(4627.0, 7617.0);
		@class.method_4(370.0, 2295.0);
		@class.method_4(7312.0, 6320.0);
		@class.method_4(8352.0, 2295.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
