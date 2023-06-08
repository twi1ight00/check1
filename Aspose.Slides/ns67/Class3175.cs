namespace ns67;

internal class Class3175 : Class3091
{
	public override Enum493 Kind => Enum493.const_137;

	public Class3175(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3675.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 20782.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 9298.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 12286.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 18595.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		double width = 21600.0;
		double height = 21600.0;
		@class.method_2(width, height, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 20782.0);
		@class.method_6(new Struct159(9298.0, 23542.0), new Struct159(9298.0, 18022.0), new Struct159(18595.0, 18022.0));
		@class.method_4(18595.0, 3675.0);
		@class.method_4(0.0, 3675.0);
		@class.method_8();
		@class.method_3(1532.0, 3675.0);
		@class.method_4(1532.0, 1815.0);
		@class.method_4(20000.0, 1815.0);
		@class.method_4(20000.0, 16252.0);
		@class.method_6(new Struct159(19298.0, 16252.0), new Struct159(18595.0, 16352.0), new Struct159(18595.0, 16352.0));
		@class.method_4(18595.0, 3675.0);
		@class.method_8();
		@class.method_3(2972.0, 1815.0);
		@class.method_4(2972.0, 0.0);
		@class.method_4(21600.0, 0.0);
		@class.method_4(21600.0, 14392.0);
		@class.method_6(new Struct159(20800.0, 14392.0), new Struct159(20000.0, 14467.0), new Struct159(20000.0, 14467.0));
		@class.method_4(20000.0, 1815.0);
		@class.method_8();
		@class.method_2(width, height, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 3675.0);
		@class.method_4(18595.0, 3675.0);
		@class.method_4(18595.0, 18022.0);
		@class.method_6(new Struct159(9298.0, 18022.0), new Struct159(9298.0, 23542.0), new Struct159(0.0, 20782.0));
		@class.method_8();
		@class.method_3(1532.0, 3675.0);
		@class.method_4(1532.0, 1815.0);
		@class.method_4(20000.0, 1815.0);
		@class.method_4(20000.0, 16252.0);
		@class.method_6(new Struct159(19298.0, 16252.0), new Struct159(18595.0, 16352.0), new Struct159(18595.0, 16352.0));
		@class.method_3(2972.0, 1815.0);
		@class.method_4(2972.0, 0.0);
		@class.method_4(21600.0, 0.0);
		@class.method_4(21600.0, 14392.0);
		@class.method_6(new Struct159(20800.0, 14392.0), new Struct159(20000.0, 14467.0), new Struct159(20000.0, 14467.0));
		@class.method_2(width, height, Enum492.const_5, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 20782.0);
		@class.method_6(new Struct159(9298.0, 23542.0), new Struct159(9298.0, 18022.0), new Struct159(18595.0, 18022.0));
		@class.method_4(18595.0, 16352.0);
		@class.method_6(new Struct159(18595.0, 16352.0), new Struct159(19298.0, 16252.0), new Struct159(20000.0, 16252.0));
		@class.method_4(20000.0, 14467.0);
		@class.method_6(new Struct159(20000.0, 14467.0), new Struct159(20800.0, 14392.0), new Struct159(21600.0, 14392.0));
		@class.method_4(21600.0, 0.0);
		@class.method_4(2972.0, 0.0);
		@class.method_4(2972.0, 1815.0);
		@class.method_4(1532.0, 1815.0);
		@class.method_4(1532.0, 3675.0);
		@class.method_4(0.0, 3675.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
