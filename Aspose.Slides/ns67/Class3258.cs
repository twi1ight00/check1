namespace ns67;

internal class Class3258 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_15;

	public Class3258(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, 50000.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num2 = Class3089.smethod_7(x, 2700000.0);
		double num3 = Class3089.smethod_10(num, 2700000.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num4, num6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(num5, num6);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num5, num7);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(num4, num7);
		@class.method_8();
		@class.TextRectangle = new Class3457(num4, num6, num5, num7);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 12500.0);
	}
}
