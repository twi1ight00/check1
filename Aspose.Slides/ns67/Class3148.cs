namespace ns67;

internal class Class3148 : Class3091
{
	private const string string_0 = "vf";

	public override Enum493 Kind => Enum493.const_13;

	public Class3148(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2160000.0);
		double num2 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 4320000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num5 = Class3089.smethod_10(x, 4320000.0);
		double num6 = Class3089.smethod_10(x, 2160000.0);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num5);
		double num7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num6, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num5, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num3, num7);
		@class.method_4(x2, y);
		@class.method_4(x3, y);
		@class.method_4(num4, num7);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num4, num8);
		@class.method_4(x3, y2);
		@class.method_4(x2, y2);
		@class.method_4(num3, num8);
		@class.method_8();
		@class.TextRectangle = new Class3457(num3, num7, num4, num8);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("vf", 105146.0);
	}
}
