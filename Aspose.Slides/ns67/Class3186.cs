namespace ns67;

internal class Class3186 : Class3091
{
	public override Enum493 Kind => Enum493.const_145;

	public Class3186(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num2 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num2);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(num3, num5);
		@class.method_4(num4, num6);
		@class.method_3(num4, num5);
		@class.method_4(num3, num6);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 16200000.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 0.0, 5400000.0);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, 5400000.0, 5400000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num3, num5, num4, num6);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
