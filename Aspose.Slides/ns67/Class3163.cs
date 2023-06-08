namespace ns67;

internal class Class3163 : Class3091
{
	public override Enum493 Kind => Enum493.const_157;

	public Class3163(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 10800000.0);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
