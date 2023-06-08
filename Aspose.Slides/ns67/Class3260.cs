namespace ns67;

internal class Class3260 : Class3091
{
	private const string string_0 = "adj";

	private const string string_1 = "hf";

	public override Enum493 Kind => Enum493.const_17;

	public Class3260(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double num = Class3089.smethod_7(x, 1800000.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, base.Transform2D.Extents.Cy / 4.0, 0.0);
		double num2 = Class3089.smethod_1(x, y, 50000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num4 = Class3089.smethod_1(num2, 1.0, 2.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double num7 = Class3089.smethod_10(num3, 3600000.0);
		double num8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		double num9 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num7, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x2, base.Transform2D.Extents.Cy / 4.0);
		@class.method_4(x4, num8);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x5, num8);
		@class.method_4(x3, base.Transform2D.Extents.Cy / 4.0);
		@class.method_4(num6, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x3, y2);
		@class.method_4(x5, num9);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x4, num9);
		@class.method_4(x2, y2);
		@class.method_4(num5, base.Transform2D.Extents.Cy / 2.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num5, num8, num6, num9);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 28868.0);
		values.Add("hf", 115470.0);
	}
}
