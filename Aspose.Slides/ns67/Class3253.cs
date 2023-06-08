namespace ns67;

internal class Class3253 : Class3091
{
	private const string string_0 = "adj";

	private const string string_1 = "hf";

	public override Enum493 Kind => Enum493.const_20;

	public Class3253(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double num = Class3089.smethod_1(x, 95106.0, 100000.0);
		double num2 = Class3089.smethod_1(x, 58779.0, 100000.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, 80902.0, 100000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, 30902.0, 100000.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num4);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double num5 = Class3089.smethod_1(x, y, 50000.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num7 = Class3089.smethod_1(num5, 80902.0, 100000.0);
		double num8 = Class3089.smethod_1(num5, 30902.0, 100000.0);
		double num9 = Class3089.smethod_1(num6, 95106.0, 100000.0);
		double num10 = Class3089.smethod_1(num6, 58779.0, 100000.0);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num5);
		double num11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num7);
		double x7 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num8);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num8, 0.0);
		double num12 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num7, 0.0);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num5, 0.0);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num9);
		double num13 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num10);
		double num14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num10, 0.0);
		double y7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num9, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x2, y3);
		@class.method_4(num11, num13);
		@class.method_4(x3, y2);
		@class.method_4(x7, y6);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x8, y6);
		@class.method_4(x4, y2);
		@class.method_4(num12, num13);
		@class.method_4(x5, y3);
		@class.method_4(x9, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x5, y4);
		@class.method_4(num12, num14);
		@class.method_4(x4, y5);
		@class.method_4(x8, y7);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x7, y7);
		@class.method_4(x3, y5);
		@class.method_4(num11, num14);
		@class.method_4(x2, y4);
		@class.method_4(x6, base.Transform2D.Extents.Cy / 2.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(num11, num13, num12, num14);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 42533.0);
		values.Add("hf", 105146.0);
	}
}
