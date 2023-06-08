namespace ns67;

internal class Class3195 : Class3091
{
	private const string string_0 = "hf";

	private const string string_1 = "vf";

	public override Enum493 Kind => Enum493.const_11;

	public Class3195(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num = Class3089.smethod_1(x, 97493.0, 100000.0);
		double num2 = Class3089.smethod_1(x, 78183.0, 100000.0);
		double num3 = Class3089.smethod_1(x, 43388.0, 100000.0);
		double z = Class3089.smethod_1(x2, 62349.0, 100000.0);
		double y = Class3089.smethod_1(x2, 22252.0, 100000.0);
		double y2 = Class3089.smethod_1(x2, 90097.0, 100000.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num6 = Class3089.smethod_2(x3, 0.0, z);
		double y3 = Class3089.smethod_2(x3, y, 0.0);
		double y4 = Class3089.smethod_2(x3, y2, 0.0);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num6);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x4, y3);
		@class.method_4(num4, num6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(num5, num6);
		@class.method_4(x7, y3);
		@class.method_4(x6, y4);
		@class.method_4(x5, y4);
		@class.method_8();
		@class.TextRectangle = new Class3457(num4, num6, num5, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("hf", 102572.0);
		values.Add("vf", 105210.0);
	}
}
