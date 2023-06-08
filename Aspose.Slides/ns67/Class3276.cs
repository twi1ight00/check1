namespace ns67;

internal class Class3276 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_118;

	public Class3276(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj2"], 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double x2 = Class3089.smethod_1(num, base.Transform2D.Extents.Cy, 1.0);
		double y2 = Class3089.smethod_1(num2, base.Transform2D.Extents.Cx, 1.0);
		double x3 = Class3089.smethod_5(x2, y2);
		double y3 = Class3089.smethod_2(x3, 660000.0, 0.0);
		double y4 = Class3089.smethod_2(x3, 0.0, 660000.0);
		double num3 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, y3);
		double y5 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, y3);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y5, 0.0);
		double num4 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, y4);
		double y7 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, y4);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y7, 0.0);
		double num5 = Class3089.smethod_5(num3, y5);
		double x5 = Class3089.smethod_5(num4, y7);
		double num6 = Class3089.smethod_2(x5, 0.0, num5);
		double z = Class3089.smethod_2(num6, 21600000.0, 0.0);
		double swingAngle = Class3089.smethod_4(num6, num6, z);
		double num7 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num8 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num7);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num7, 0.0);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num8);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num8, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x, y);
		@class.method_4(x4, y6);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num5, swingAngle);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", -20833.0);
		values.Add("adj2", 62500.0);
	}
}
