namespace ns67;

internal class Class3217 : Class3091
{
	private const string string_0 = "adj1";

	public override Enum493 Kind => Enum493.const_176;

	public Class3217(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 100000.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 73490.0, 200000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num5, num3);
		@class.method_4(num6, num3);
		@class.method_4(num6, num4);
		@class.method_4(num5, num4);
		@class.method_8();
		@class.TextRectangle = new Class3457(num5, num3, num6, num4);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 23520.0);
	}
}
