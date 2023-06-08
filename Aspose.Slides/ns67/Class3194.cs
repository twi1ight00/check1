namespace ns67;

internal class Class3194 : Class3091
{
	public override Enum493 Kind => Enum493.const_75;

	public Class3194(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, 49.0, 48.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 10.0, 48.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y = Class3089.smethod_2(0.0, 0.0, base.Transform2D.Extents.Cy / 3.0);
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 1.0, 6.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 5.0, 6.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 2.0, 3.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy / 4.0);
		@class.method_6(new Struct159(x3, y), new Struct159(x4, base.Transform2D.Extents.Cy / 4.0), new Struct159(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy));
		@class.method_6(new Struct159(x, base.Transform2D.Extents.Cy / 4.0), new Struct159(x2, y), new Struct159(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy / 4.0));
		@class.method_8();
		@class.TextRectangle = new Class3457(left, base.Transform2D.Extents.Cy / 4.0, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
