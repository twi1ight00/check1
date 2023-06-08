namespace ns67;

internal class Class3228 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_39;

	public Class3228(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 21599999.0);
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 21599999.0);
		double num3 = Class3089.smethod_2(num2, 0.0, num);
		double z = Class3089.smethod_2(num3, 21600000.0, 0.0);
		double swingAngle = Class3089.smethod_4(num3, num3, z);
		double z2 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num);
		double y = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num);
		double y2 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y, z2);
		double y3 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y, z2);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y2, 0.0);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y3, 0.0);
		double z3 = Class3089.smethod_10(base.Transform2D.Extents.Cx / 2.0, num2);
		double y5 = Class3089.smethod_7(base.Transform2D.Extents.Cy / 2.0, num2);
		double y6 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y5, z3);
		double y7 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y5, z3);
		Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y6, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y7, 0.0);
		double num4 = Class3089.smethod_7(base.Transform2D.Extents.Cx / 2.0, 2700000.0);
		double num5 = Class3089.smethod_10(base.Transform2D.Extents.Cy / 2.0, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num5);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num5, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x, y4);
		@class.method_5(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cx / 2.0, num, swingAngle);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 0.0);
		values.Add("adj2", 16200000.0);
	}
}
