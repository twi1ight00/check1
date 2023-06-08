namespace ns67;

internal class Class3216 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_179;

	public Class3216(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 36745.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double z2 = Class3089.smethod_2(100000.0, 0.0, z);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z2);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num, 100000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 73490.0, 200000.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double num7 = Class3089.smethod_2(num5, 0.0, num2);
		double num8 = Class3089.smethod_2(num6, num2, 0.0);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double num10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		Class3089.smethod_3(num7, num5, 2.0);
		Class3089.smethod_3(num6, num8, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(num9, num7);
		@class.method_4(num10, num7);
		@class.method_4(num10, num5);
		@class.method_4(num9, num5);
		@class.method_8();
		@class.method_3(num9, num6);
		@class.method_4(num10, num6);
		@class.method_4(num10, num8);
		@class.method_4(num9, num8);
		@class.method_8();
		@class.TextRectangle = new Class3457(num9, num7, num10, num8);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 23520.0);
		values.Add("adj2", 11760.0);
	}
}
