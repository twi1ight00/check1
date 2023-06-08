using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class26 : Class18
{
	private static readonly Point[] point_0 = new Point[117]
	{
		new Point(1930, 7160),
		new Point(1530, 4490),
		new Point(3400, 1970),
		new Point(5270, 1970),
		new Point(5860, 1950),
		new Point(6470, 2210),
		new Point(6970, 2600),
		new Point(7450, 1390),
		new Point(8340, 650),
		new Point(9340, 650),
		new Point(10004, 690),
		new Point(10710, 1050),
		new Point(11210, 1700),
		new Point(11570, 630),
		new Point(12330, 0),
		new Point(13150, 0),
		new Point(13840, 0),
		new Point(14470, 460),
		new Point(14870, 1160),
		new Point(15330, 440),
		new Point(16020, 0),
		new Point(16740, 0),
		new Point(17910, 0),
		new Point(18900, 1130),
		new Point(19110, 2710),
		new Point(20240, 3150),
		new Point(21060, 4580),
		new Point(21060, 6220),
		new Point(21060, 6720),
		new Point(21000, 7200),
		new Point(20830, 7660),
		new Point(21310, 8460),
		new Point(21600, 9450),
		new Point(21600, 10460),
		new Point(21600, 12750),
		new Point(20310, 14680),
		new Point(18650, 15010),
		new Point(18650, 17200),
		new Point(17370, 18920),
		new Point(15770, 18920),
		new Point(15220, 18920),
		new Point(14700, 18710),
		new Point(14240, 18310),
		new Point(13820, 20240),
		new Point(12490, 21600),
		new Point(11000, 21600),
		new Point(9890, 21600),
		new Point(8840, 20790),
		new Point(8210, 19510),
		new Point(7620, 20000),
		new Point(7930, 20290),
		new Point(6240, 20290),
		new Point(4850, 20290),
		new Point(3570, 19280),
		new Point(2900, 17640),
		new Point(1300, 17600),
		new Point(480, 16300),
		new Point(480, 14660),
		new Point(480, 13900),
		new Point(690, 13210),
		new Point(1070, 12640),
		new Point(380, 12160),
		new Point(0, 11210),
		new Point(0, 10120),
		new Point(0, 8590),
		new Point(840, 7330),
		new Point(1930, 7160),
		new Point(1930, 7160),
		new Point(1950, 7410),
		new Point(2040, 7690),
		new Point(2090, 7920),
		new Point(6970, 2600),
		new Point(7200, 2790),
		new Point(7480, 3050),
		new Point(7670, 3310),
		new Point(11210, 1700),
		new Point(11130, 1910),
		new Point(11080, 2160),
		new Point(11030, 2400),
		new Point(14870, 1160),
		new Point(14720, 1400),
		new Point(14640, 1720),
		new Point(14540, 2010),
		new Point(19110, 2710),
		new Point(19130, 2890),
		new Point(19230, 3290),
		new Point(19190, 3380),
		new Point(20830, 7660),
		new Point(20660, 8170),
		new Point(20430, 8620),
		new Point(20110, 8990),
		new Point(18660, 15010),
		new Point(18740, 14200),
		new Point(18280, 12200),
		new Point(17000, 11450),
		new Point(14240, 18310),
		new Point(14320, 17980),
		new Point(14350, 17680),
		new Point(14370, 17360),
		new Point(8220, 19510),
		new Point(8060, 19250),
		new Point(7960, 18950),
		new Point(7860, 18640),
		new Point(2900, 17640),
		new Point(3090, 17600),
		new Point(3280, 17540),
		new Point(3460, 17450),
		new Point(1070, 12640),
		new Point(1400, 12900),
		new Point(1780, 13130),
		new Point(2330, 13040),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(-2147483644, -2147483643),
		new Point(-2147483642, -2147483641),
		new Point(-2147483640, -2147483639),
		new Point(-2147483638, -2147483637)
	};

	private static readonly ushort[] ushort_0 = new ushort[34]
	{
		8214, 24576, 32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193,
		32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193,
		32768, 8193, 32768, 8193, 32768, 46338, 24576, 32768, 46338, 24576,
		32768, 46338, 24576, 32768
	};

	private static readonly Point[] point_1 = new Point[5]
	{
		new Point(10800, 1220),
		new Point(50, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800),
		new Point(-2147483624, -2147483623)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[26]
	{
		new Struct14(16384, 9000, 1036, 0),
		new Struct14(16384, 9000, 1037, 0),
		new Struct14(16384, 12600, 1036, 0),
		new Struct14(16384, 12600, 1037, 0),
		new Struct14(16384, 9600, 1038, 0),
		new Struct14(16384, 9600, 1039, 0),
		new Struct14(16384, 12000, 1038, 0),
		new Struct14(16384, 12000, 1039, 0),
		new Struct14(8192, 327, 0, 600),
		new Struct14(8192, 328, 0, 600),
		new Struct14(8192, 327, 600, 0),
		new Struct14(8192, 328, 600, 0),
		new Struct14(57355, 1040, 1046, 1047),
		new Struct14(57356, 1040, 1046, 1047),
		new Struct14(57355, 1041, 1046, 1047),
		new Struct14(57356, 1041, 1046, 1047),
		new Struct14(8192, 1043, 12600, 0),
		new Struct14(8192, 1042, 15600, 0),
		new Struct14(8193, 1043, 2, 0),
		new Struct14(8193, 1044, 1, 3),
		new Struct14(8192, 1045, 0, 17400),
		new Struct14(24704, 1046, 1047, 0),
		new Struct14(8192, 327, 0, 10800),
		new Struct14(8192, 328, 0, 10800),
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0)
	};

	private int[] int_0 = new int[2] { 1350, 25920 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(3000, 3320), new Point(17110, 17330))
	};

	internal Class26(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		int num = (int)class898_0.X;
		int num2 = (int)class898_0.Y;
		int num3 = (int)class898_0.Width;
		int num4 = (int)class898_0.Height;
		RectangleF rectangleF_ = new RectangleF(num, num2, num3, num4);
		interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		int num5 = 0;
		int num6 = 0;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			switch (class898_0.class885_0.arrayList_0.Count)
			{
			default:
				num5 = 1350;
				num6 = 25920;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 25920;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 1350;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			case 2:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 25920;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 1350;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			}
			int_0 = new int[2] { num5, num6 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_106, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
