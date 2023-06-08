using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class49 : Class18
{
	private static readonly Point[] point_0 = new Point[4]
	{
		new Point(10800, -2147483552),
		new Point(2700, -2147483560),
		new Point(10800, 21600),
		new Point(18900, -2147483560)
	};

	private static Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(-2147483643, -2147483564, -2147483632, -2147483555)
	};

	private int[] int_0 = new int[3] { 5400, 5400, 18900 };

	private static readonly Struct14[] struct14_0 = new Struct14[97]
	{
		new Struct14(24576, 1103, 1061, 0),
		new Struct14(8193, 327, 1, 3),
		new Struct14(24576, 1024, 1063, 0),
		new Struct14(8193, 327, 2, 3),
		new Struct14(40960, 1030, 0, 1072),
		new Struct14(8192, 327, 0, 0),
		new Struct14(24576, 1053, 1061, 0),
		new Struct14(24576, 1053, 1102, 0),
		new Struct14(8192, 327, 2700, 0),
		new Struct14(24576, 1081, 1102, 0),
		new Struct14(40960, 1033, 0, 1082),
		new Struct14(8192, 1063, 21600, 0),
		new Struct14(57345, 1086, 1086, 1071),
		new Struct14(24576, 1042, 1088, 0),
		new Struct14(32768, 21600, 0, 1025),
		new Struct14(32768, 21600, 0, 1027),
		new Struct14(32768, 21600, 0, 327),
		new Struct14(32768, 21600, 0, 1032),
		new Struct14(24576, 1036, 1061, 0),
		new Struct14(8192, 327, 900, 0),
		new Struct14(24576, 1031, 1093, 0),
		new Struct14(8192, 327, 1800, 0),
		new Struct14(24576, 1048, 1100, 0),
		new Struct14(8192, 327, 2700, 0),
		new Struct14(24576, 1097, 1102, 0),
		new Struct14(24576, 1048, 1061, 0),
		new Struct14(32768, 21600, 0, 1043),
		new Struct14(32768, 21600, 0, 1045),
		new Struct14(32768, 21600, 0, 1047),
		new Struct14(57345, 1069, 1069, 1071),
		new Struct14(8193, 1091, 2, 3),
		new Struct14(24576, 1053, 1094, 0),
		new Struct14(8193, 1092, 1, 3),
		new Struct14(32768, 21600, 0, 1056),
		new Struct14(32768, 21600, 0, 1054),
		new Struct14(24576, 1102, 1055, 0),
		new Struct14(8192, 1102, 0, 0),
		new Struct14(32768, 21600, 0, 1062),
		new Struct14(24576, 1102, 1103, 0),
		new Struct14(24577, 1064, 1065, 1),
		new Struct14(16385, 10800, 1066, 1),
		new Struct14(8192, 1067, 0, 1),
		new Struct14(24577, 1103, 1, 5400),
		new Struct14(32768, 1, 0, 1068),
		new Struct14(8193, 1025, 1, 10800),
		new Struct14(32768, 1, 0, 1070),
		new Struct14(8193, 327, 1, 10800),
		new Struct14(32769, 1, 1, 1103),
		new Struct14(24577, 1073, 1074, 1),
		new Struct14(24577, 1075, 1066, 1),
		new Struct14(40960, 1069, 0, 1076),
		new Struct14(32768, 10800, 0, 327),
		new Struct14(32768, 1, 0, 1077),
		new Struct14(8193, 1027, 1, 10800),
		new Struct14(57345, 1079, 1079, 1071),
		new Struct14(32768, 1, 0, 1080),
		new Struct14(8193, 1032, 1, 10800),
		new Struct14(24576, 1078, 1061, 0),
		new Struct14(24577, 1083, 1084, 1),
		new Struct14(24577, 1085, 1066, 1),
		new Struct14(40960, 1079, 0, 1069),
		new Struct14(32768, 10800, 0, 1032),
		new Struct14(32768, 1, 0, 1087),
		new Struct14(1, 2700, 1, 10800),
		new Struct14(8193, 1102, 1, 2),
		new Struct14(32768, 1, 0, 1090),
		new Struct14(8193, 1054, 1, 10800),
		new Struct14(8192, 327, 5400, 0),
		new Struct14(8192, 327, 21600, 0),
		new Struct14(24577, 1073, 1, -12),
		new Struct14(24577, 1073, 1095, 1),
		new Struct14(40960, 1089, 0, 1069),
		new Struct14(8193, 1043, 1, 10800),
		new Struct14(57345, 1098, 1098, 1071),
		new Struct14(32768, 1, 0, 1099),
		new Struct14(8193, 1047, 1, 10800),
		new Struct14(24577, 1101, 1066, -12),
		new Struct14(32768, 10800, 0, 1047),
		new Struct14(32768, 21600, 0, 328),
		new Struct14(32768, 21600, 0, 329),
		new Struct14(32768, 21600, 0, 1024),
		new Struct14(32768, 21600, 0, 1026),
		new Struct14(32768, 21600, 0, 1028),
		new Struct14(32768, 21600, 0, 1030),
		new Struct14(32768, 21600, 0, 1031),
		new Struct14(32768, 21600, 0, 1033),
		new Struct14(32768, 21600, 0, 1034),
		new Struct14(32768, 21600, 0, 1035),
		new Struct14(32768, 21600, 0, 1037),
		new Struct14(32768, 21600, 0, 1044),
		new Struct14(32768, 21600, 0, 1046),
		new Struct14(32768, 21600, 0, 1048),
		new Struct14(32768, 21600, 0, 1049),
		new Struct14(32768, 21600, 0, 1053),
		new Struct14(32768, 21600, 0, 1055),
		new Struct14(32768, 21600, 0, 1059),
		new Struct14(32768, 21600, 0, 1060)
	};

	private static readonly ushort[] ushort_0 = new ushort[26]
	{
		8193, 2, 8193, 2, 24576, 32768, 8193, 2, 8193, 2,
		24576, 32768, 8193, 2, 24576, 32770, 8193, 2, 24576, 32770,
		8194, 1, 8194, 1, 24576, 32768
	};

	private static readonly Point[] point_1 = new Point[49]
	{
		new Point(0, -2147483568),
		new Point(-2147483647, -2147483567),
		new Point(-2147483645, -2147483566),
		new Point(-2147483643, -2147483565),
		new Point(-2147483643, -2147483564),
		new Point(-2147483640, -2147483563),
		new Point(-2147483643, -2147483562),
		new Point(-2147483647, -2147483561),
		new Point(0, 0),
		new Point(2700, -2147483560),
		new Point(0, -2147483568),
		new Point(21600, -2147483568),
		new Point(-2147483634, -2147483567),
		new Point(-2147483633, -2147483566),
		new Point(-2147483632, -2147483565),
		new Point(-2147483632, -2147483564),
		new Point(-2147483631, -2147483563),
		new Point(-2147483632, -2147483562),
		new Point(-2147483634, -2147483561),
		new Point(21600, 0),
		new Point(18900, -2147483560),
		new Point(21600, -2147483568),
		new Point(-2147483643, -2147483564),
		new Point(-2147483629, -2147483559),
		new Point(-2147483627, -2147483558),
		new Point(-2147483625, -2147483557),
		new Point(-2147483625, -2147483556),
		new Point(-2147483643, -2147483564),
		new Point(-2147483632, -2147483564),
		new Point(-2147483622, -2147483559),
		new Point(-2147483621, -2147483558),
		new Point(-2147483620, -2147483557),
		new Point(-2147483620, -2147483556),
		new Point(-2147483632, -2147483564),
		new Point(-2147483643, -2147483555),
		new Point(-2147483618, -2147483554),
		new Point(-2147483616, 21600),
		new Point(10800, 21600),
		new Point(-2147483615, 21600),
		new Point(-2147483614, -2147483554),
		new Point(-2147483632, -2147483555),
		new Point(-2147483632, -2147483564),
		new Point(-2147483614, -2147483553),
		new Point(-2147483615, -2147483552),
		new Point(10800, -2147483552),
		new Point(-2147483616, -2147483552),
		new Point(-2147483618, -2147483553),
		new Point(-2147483643, -2147483564),
		new Point(-2147483643, -2147483555)
	};

	internal Class49(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		int num7 = 0;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			switch (class898_0.class885_0.arrayList_0.Count)
			{
			default:
				num5 = 5400;
				num6 = 5400;
				num7 = 18900;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 5400;
					num7 = 18900;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 5400;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num7 = 18900;
				}
				else
				{
					num5 = 5400;
					num6 = 5400;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			case 2:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
					num7 = 18900;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 5400;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 5400;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				}
				break;
			case 3:
				num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[2]).Value);
				break;
			}
			int_0 = new int[3] { num5, num6, num7 };
		}
		Class15 class15_ = new Class15(point_1, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, 10800, 10800, point_0);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_98, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
