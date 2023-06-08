namespace ns67;

internal class Class3255 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_22;

	public Class3255(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, 92388.0, 100000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, 70711.0, 100000.0);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, 38268.0, 100000.0);
		double num4 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, 92388.0, 100000.0);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, 70711.0, 100000.0);
		double num6 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, 38268.0, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double y2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num4);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num5);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num6);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num6, 0.0);
		double y6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num5, 0.0);
		double y7 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, 0.0);
		double x7 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, 50000.0);
		double num7 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, y, 50000.0);
		double num8 = Class3089.smethod_1(x7, 98079.0, 100000.0);
		double num9 = Class3089.smethod_1(x7, 83147.0, 100000.0);
		double num10 = Class3089.smethod_1(x7, 55557.0, 100000.0);
		double num11 = Class3089.smethod_1(x7, 19509.0, 100000.0);
		double num12 = Class3089.smethod_1(num7, 98079.0, 100000.0);
		double num13 = Class3089.smethod_1(num7, 83147.0, 100000.0);
		double num14 = Class3089.smethod_1(num7, 55557.0, 100000.0);
		double num15 = Class3089.smethod_1(num7, 19509.0, 100000.0);
		double x8 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num8);
		double x9 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num9);
		double x10 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num10);
		double x11 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num11);
		double x12 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num11, 0.0);
		double x13 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num10, 0.0);
		double x14 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num9, 0.0);
		double x15 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num8, 0.0);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num12);
		double y9 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num13);
		double y10 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num14);
		double y11 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num15);
		double y12 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num15, 0.0);
		double y13 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num14, 0.0);
		double y14 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num13, 0.0);
		double y15 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num12, 0.0);
		double num16 = Class3089.smethod_7(x7, 2700000.0);
		double num17 = Class3089.smethod_10(num7, 2700000.0);
		double left = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num16);
		double top = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num17);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num16, 0.0);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num17, 0.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num7);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x8, y11);
		@class.method_4(x, y4);
		@class.method_4(x9, y10);
		@class.method_4(x2, y3);
		@class.method_4(x10, y9);
		@class.method_4(x3, y2);
		@class.method_4(x11, y8);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x12, y8);
		@class.method_4(x4, y2);
		@class.method_4(x13, y9);
		@class.method_4(x5, y3);
		@class.method_4(x14, y10);
		@class.method_4(x6, y4);
		@class.method_4(x15, y11);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x15, y12);
		@class.method_4(x6, y5);
		@class.method_4(x14, y13);
		@class.method_4(x5, y6);
		@class.method_4(x13, y14);
		@class.method_4(x4, y7);
		@class.method_4(x12, y15);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x11, y15);
		@class.method_4(x3, y7);
		@class.method_4(x10, y14);
		@class.method_4(x2, y6);
		@class.method_4(x9, y13);
		@class.method_4(x, y5);
		@class.method_4(x8, y12);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 37500.0);
	}
}
