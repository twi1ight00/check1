namespace ns67;

internal class Class3151 : Class3091
{
	public override Enum493 Kind => Enum493.const_14;

	public Class3151(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, 2894.0, 21600.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx, 7906.0, 21600.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 13694.0, 21600.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 18706.0, 21600.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 2894.0, 21600.0);
		double y = Class3089.smethod_1(base.Transform2D.Extents.Cy, 7906.0, 21600.0);
		double y2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 13694.0, 21600.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 18706.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, y);
		@class.method_4(num, num3);
		@class.method_4(x, 0.0);
		@class.method_4(x2, 0.0);
		@class.method_4(num2, num3);
		@class.method_4(base.Transform2D.Extents.Cx, y);
		@class.method_4(base.Transform2D.Extents.Cx, y2);
		@class.method_4(num2, num4);
		@class.method_4(x2, base.Transform2D.Extents.Cy);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_4(num, num4);
		@class.method_4(0.0, y2);
		@class.method_8();
		@class.TextRectangle = new Class3457(num, num3, num2, num4);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
