namespace ns67;

internal class Class3171 : Class3091
{
	public override Enum493 Kind => Enum493.const_153;

	public Class3171(Class3448 xfrm)
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
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double swingAngle = Class3089.smethod_5(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, swingAngle);
		@class.method_4(base.Transform2D.Extents.Cx, num3);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, num3);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
