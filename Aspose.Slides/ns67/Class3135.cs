using System;

namespace ns67;

internal class Class3135 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_119;

	public Class3135(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj2"], 100000.0);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num2, 0.0);
		double y = Class3089.smethod_6(base.Transform2D.Extents.Cy / 2.0, num, num2);
		double z = Class3089.smethod_9(base.Transform2D.Extents.Cx / 2.0, num, num2);
		double y2 = Class3089.smethod_6(base.Transform2D.Extents.Cx / 2.0, y, z);
		double y3 = Class3089.smethod_9(base.Transform2D.Extents.Cy / 2.0, y, z);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, y2, 0.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, y3, 0.0);
		double num5 = Class3089.smethod_2(x, 0.0, num3);
		double y4 = Class3089.smethod_2(x2, 0.0, num4);
		double num6 = Class3089.smethod_8(num5, y4, 0.0);
		double z2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 6600.0, 21600.0);
		double x3 = Class3089.smethod_2(num6, 0.0, z2);
		double x4 = Class3089.smethod_1(x3, 1.0, 3.0);
		double num7 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 1800.0, 21600.0);
		double x5 = Class3089.smethod_2(x4, num7, 0.0);
		double x6 = Class3089.smethod_1(x5, num5, num6);
		double x7 = Class3089.smethod_1(x5, y4, num6);
		double x8 = Class3089.smethod_2(x6, num3, 0.0);
		double y5 = Class3089.smethod_2(x7, num4, 0.0);
		double x9 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 4800.0, 21600.0);
		double y6 = Class3089.smethod_1(x4, 2.0, 1.0);
		double x10 = Class3089.smethod_2(x9, y6, 0.0);
		double x11 = Class3089.smethod_1(x10, num5, num6);
		double x12 = Class3089.smethod_1(x10, y4, num6);
		double x13 = Class3089.smethod_2(x11, num3, 0.0);
		double y7 = Class3089.smethod_2(x12, num4, 0.0);
		double num8 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 1200.0, 21600.0);
		double num9 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 600.0, 21600.0);
		double x14 = Class3089.smethod_2(num3, num9, 0.0);
		double x15 = Class3089.smethod_2(x8, num8, 0.0);
		double x16 = Class3089.smethod_2(x13, num7, 0.0);
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 2977.0, 21600.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3262.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 17087.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 17337.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 67.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 21577.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 21582.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 1235.0, 21600.0);
		Class3089.smethod_5(num, num2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x14, num4);
		@class.method_5(num9, num9, 0.0, 21600000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x15, y5);
		@class.method_5(num8, num8, 0.0, 21600000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x16, y7);
		@class.method_5(num7, num7, 0.0, 21600000.0);
		@class.method_8();
		@class.method_2(43200.0, 43200.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(3900.0, 14370.0);
		@class.method_5(9190.0, 6753.0, -11429249.0, 7426832.0);
		@class.method_5(7267.0, 5333.0, -8646143.0, 5396714.0);
		@class.method_5(5945.0, 4365.0, -8748475.0, 5983381.0);
		@class.method_5(6595.0, 4857.0, -7859164.0, 7034504.0);
		@class.method_5(7273.0, 5333.0, -4722533.0, 6541615.0);
		@class.method_5(9220.0, 6775.0, -2776035.0, 7816140.0);
		@class.method_5(7867.0, 5785.0, 37501.0, 6842000.0);
		@class.method_5(9215.0, 6752.0, 1347096.0, 6910353.0);
		@class.method_5(10543.0, 7720.0, 3974558.0, 4542661.0);
		@class.method_5(5918.0, 4360.0, -16496525.0, 8804134.0);
		@class.method_5(5945.0, 4345.0, -14809710.0, 9151131.0);
		@class.method_8();
		@class.method_2(43200.0, 43200.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(4693.0, 26177.0);
		@class.method_5(5945.0, 4345.0, 5204520.0, 1585770.0);
		@class.method_3(6928.0, 34899.0);
		@class.method_5(5918.0, 4360.0, 4416628.0, 686848.0);
		@class.method_3(16478.0, 39090.0);
		@class.method_5(9215.0, 6752.0, 8257449.0, 844866.0);
		@class.method_3(28827.0, 34751.0);
		@class.method_5(9215.0, 6752.0, 387196.0, 959901.0);
		@class.method_3(34129.0, 22954.0);
		@class.method_5(7867.0, 5785.0, -4217541.0, 4255042.0);
		@class.method_3(41798.0, 15354.0);
		@class.method_5(7273.0, 5333.0, 1819082.0, 1665090.0);
		@class.method_3(38324.0, 5426.0);
		@class.method_5(6595.0, 4857.0, -824660.0, 891534.0);
		@class.method_3(29078.0, 3952.0);
		@class.method_5(6595.0, 4857.0, -8950887.0, 1091722.0);
		@class.method_3(22141.0, 4720.0);
		@class.method_5(5945.0, 4365.0, -9809656.0, 1061181.0);
		@class.method_3(14000.0, 5192.0);
		@class.method_5(9190.0, 6753.0, -4002417.0, 739161.0);
		@class.method_3(4127.0, 15789.0);
		@class.method_5(9190.0, 6753.0, 9459261.0, 711490.0);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x14, num4);
		@class.method_5(num9, num9, 0.0, 21600000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x15, y5);
		@class.method_5(num8, num8, 0.0, 21600000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x16, y7);
		@class.method_5(num7, num7, 0.0, 21600000.0);
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
