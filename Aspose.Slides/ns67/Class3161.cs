namespace ns67;

internal class Class3161 : Class3091
{
	public override Enum493 Kind => Enum493.const_142;

	public Class3161(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num2 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num2);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
