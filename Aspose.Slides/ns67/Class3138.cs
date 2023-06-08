namespace ns67;

internal class Class3138 : Class3091
{
	public override Enum493 Kind => Enum493.const_181;

	public Class3138(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_8(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, 0.0);
		double num = Class3089.smethod_1(1.0, y, 20.0);
		double num2 = Class3089.smethod_2(0.0, base.Transform2D.Extents.Cy, num);
		double num3 = Class3089.smethod_2(0.0, base.Transform2D.Extents.Cx, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(num, 0.0);
		@class.method_4(0.0, num);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, num2);
		@class.method_4(num, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num3, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, num2);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(num3, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(num, num, num3, num2);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
