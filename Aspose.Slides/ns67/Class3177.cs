namespace ns67;

internal class Class3177 : Class3091
{
	public override Enum493 Kind => Enum493.const_159;

	public Class3177(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 4.0, 5.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(10.0, 10.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(10.0, 0.0);
		@class.method_4(10.0, 8.0);
		@class.method_4(5.0, 10.0);
		@class.method_4(0.0, 8.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
