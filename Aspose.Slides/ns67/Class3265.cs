namespace ns67;

internal class Class3265 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_76;

	public Class3265(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(12500.0, base.AdjustValues["adj"], 46875.0);
		double num2 = Class3089.smethod_2(50000.0, 0.0, num);
		double num3 = Class3089.smethod_1(num2, 30274.0, 32768.0);
		double num4 = Class3089.smethod_1(num2, 12540.0, 32768.0);
		Class3089.smethod_2(num3, 50000.0, 0.0);
		Class3089.smethod_2(num4, 50000.0, 0.0);
		double x = Class3089.smethod_2(50000.0, 0.0, num3);
		double x2 = Class3089.smethod_2(50000.0, 0.0, num4);
		double num5 = Class3089.smethod_1(num2, 23170.0, 32768.0);
		double y = Class3089.smethod_2(50000.0, num5, 0.0);
		double y2 = Class3089.smethod_2(50000.0, 0.0, num5);
		double num6 = Class3089.smethod_1(x, 3.0, 4.0);
		double x3 = Class3089.smethod_1(x2, 3.0, 4.0);
		double num7 = Class3089.smethod_2(num6, 3662.0, 0.0);
		double num8 = Class3089.smethod_2(x3, 3662.0, 0.0);
		double num9 = Class3089.smethod_2(x3, 12500.0, 0.0);
		double y3 = Class3089.smethod_2(100000.0, 0.0, num6);
		double y4 = Class3089.smethod_2(100000.0, 0.0, num7);
		double y5 = Class3089.smethod_2(100000.0, 0.0, num8);
		double y6 = Class3089.smethod_2(100000.0, 0.0, num9);
		double x4 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 18436.0, 21600.0);
		double y7 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3163.0, 21600.0);
		double x5 = Class3089.smethod_1(base.Transform2D.Extents.Cx, 3163.0, 21600.0);
		double y8 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 18436.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, y, 100000.0);
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, y2, 100000.0);
		double x6 = Class3089.smethod_1(base.Transform2D.Extents.Cx, num6, 100000.0);
		double x7 = Class3089.smethod_1(base.Transform2D.Extents.Cx, num7, 100000.0);
		double x8 = Class3089.smethod_1(base.Transform2D.Extents.Cx, num8, 100000.0);
		double x9 = Class3089.smethod_1(base.Transform2D.Extents.Cx, num9, 100000.0);
		double x10 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y3, 100000.0);
		double x11 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y4, 100000.0);
		double x12 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y5, 100000.0);
		double x13 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y6, 100000.0);
		double x14 = Class3089.smethod_1(base.Transform2D.Extents.Cx, num, 100000.0);
		double widthRadius = Class3089.smethod_1(base.Transform2D.Extents.Cx, num2, 100000.0);
		double heightRadius = Class3089.smethod_1(base.Transform2D.Extents.Cy, num2, 100000.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, y2, 100000.0);
		double y9 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num6, 100000.0);
		double y10 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num7, 100000.0);
		double y11 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num8, 100000.0);
		double y12 = Class3089.smethod_1(base.Transform2D.Extents.Cy, num9, 100000.0);
		double y13 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y3, 100000.0);
		double y14 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y4, 100000.0);
		double y15 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y5, 100000.0);
		double y16 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y6, 100000.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x10, y16);
		@class.method_4(x10, y12);
		@class.method_8();
		@class.method_3(x4, y7);
		@class.method_4(x11, y11);
		@class.method_4(x12, y10);
		@class.method_8();
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x13, y9);
		@class.method_4(x9, y9);
		@class.method_8();
		@class.method_3(x5, y7);
		@class.method_4(x8, y10);
		@class.method_4(x7, y11);
		@class.method_8();
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x6, y12);
		@class.method_4(x6, y16);
		@class.method_8();
		@class.method_3(x5, y8);
		@class.method_4(x7, y15);
		@class.method_4(x8, y14);
		@class.method_8();
		@class.method_3(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x9, y13);
		@class.method_4(x13, y13);
		@class.method_8();
		@class.method_3(x4, y8);
		@class.method_4(x12, y14);
		@class.method_4(x11, y15);
		@class.method_8();
		@class.method_3(x14, base.Transform2D.Extents.Cy / 2.0);
		@class.method_5(heightRadius, widthRadius, 10800000.0, 21600000.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
