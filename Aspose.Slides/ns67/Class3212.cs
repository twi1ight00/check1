namespace ns67;

internal class Class3212 : Class3091
{
	public override Enum493 Kind => Enum493.const_74;

	public Class3212(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 5022.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 8472.0, 21600.0);
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 8757.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 10012.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 12860.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 13917.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 16577.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 3890.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 6080.0, 21600.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 7437.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 9705.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 12007.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 14277.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 14915.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(21600.0, 21600.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(8472.0, 0.0);
		@class.method_4(12860.0, 6080.0);
		@class.method_4(11050.0, 6797.0);
		@class.method_4(16577.0, 12007.0);
		@class.method_4(14767.0, 12877.0);
		@class.method_4(21600.0, 21600.0);
		@class.method_4(10012.0, 14915.0);
		@class.method_4(12222.0, 13987.0);
		@class.method_4(5022.0, 9705.0);
		@class.method_4(7602.0, 8382.0);
		@class.method_4(0.0, 3890.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
