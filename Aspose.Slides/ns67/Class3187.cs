namespace ns67;

internal class Class3187 : Class3091
{
	public override Enum493 Kind => Enum493.const_138;

	public Class3187(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 1018.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 20582.0, 21600.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3163.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 18437.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(21600.0, 21600.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(3475.0, 0.0);
		@class.method_4(18125.0, 0.0);
		@class.method_5(10800.0, 3475.0, 16200000.0, 10800000.0);
		@class.method_4(3475.0, 21600.0);
		@class.method_5(10800.0, 3475.0, 5400000.0, 10800000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
