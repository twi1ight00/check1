using System;
using System.Drawing;
using ns218;
using ns4;
using ns62;

namespace ns15;

internal sealed class Class204 : Class203
{
	[Flags]
	internal enum Enum20 : byte
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4,
		flag_3 = 8
	}

	private static readonly Point[] point_78 = new Point[11]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(int.MinValue, -2147483645),
		new Point(-2147483646, -2147483645),
		new Point(-2147483646, -2147483647),
		new Point(21600, 10800),
		new Point(-2147483646, -2147483644),
		new Point(-2147483646, -2147483643),
		new Point(int.MinValue, -2147483643),
		new Point(int.MinValue, 21600),
		new Point(0, 21600)
	};

	private static readonly ushort[] ushort_47 = new ushort[3] { 10, 24576, 32768 };

	private static readonly Struct15[] struct15_37 = new Struct15[7]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(8194, 327, 0, 0)
	};

	private static readonly int[] int_34 = new int[4] { 14400, 5400, 18000, 8100 };

	private static readonly Struct16[] struct16_38 = new Struct16[1]
	{
		new Struct16(new Point(0, 0), new Point(int.MinValue, 21600))
	};

	private static readonly Point[] point_79 = new Point[4]
	{
		new Point(-2147483642, 0),
		new Point(0, 10800),
		new Point(-2147483642, 21600),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_50 = new Class204(point_78, ushort_47, struct15_37, int_34, struct16_38, 21600, 21600, int.MinValue, int.MinValue, point_79);

	private static readonly Point[] point_80 = new Point[11]
	{
		new Point(int.MinValue, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, 21600),
		new Point(int.MinValue, -2147483643),
		new Point(-2147483646, -2147483643),
		new Point(-2147483646, -2147483644),
		new Point(0, 10800),
		new Point(-2147483646, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(int.MinValue, -2147483645)
	};

	private static readonly ushort[] ushort_48 = new ushort[3] { 10, 24576, 32768 };

	private static readonly Struct15[] struct15_38 = new Struct15[7]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(8194, 327, 21600, 0)
	};

	private static readonly int[] int_35 = new int[4] { 7200, 5400, 3600, 8100 };

	private static readonly Struct16[] struct16_39 = new Struct16[1]
	{
		new Struct16(new Point(int.MinValue, 0), new Point(21600, 21600))
	};

	private static readonly Point[] point_81 = new Point[4]
	{
		new Point(-2147483642, 0),
		new Point(0, 10800),
		new Point(-2147483642, 21600),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_51 = new Class204(point_80, ushort_48, struct15_38, int_35, struct16_39, 21600, 21600, int.MinValue, int.MinValue, point_81);

	private static readonly Point[] point_82 = new Point[11]
	{
		new Point(21600, int.MinValue),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(0, int.MinValue),
		new Point(-2147483645, int.MinValue),
		new Point(-2147483645, -2147483646),
		new Point(-2147483647, -2147483646),
		new Point(10800, 0),
		new Point(-2147483644, -2147483646),
		new Point(-2147483643, -2147483646),
		new Point(-2147483643, int.MinValue)
	};

	private static readonly ushort[] ushort_49 = new ushort[3] { 10, 24576, 32768 };

	private static readonly Struct15[] struct15_39 = new Struct15[7]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(8194, 327, 21600, 0)
	};

	private static readonly int[] int_36 = new int[4] { 7200, 5400, 3600, 8100 };

	private static readonly Struct16[] struct16_40 = new Struct16[1]
	{
		new Struct16(new Point(0, int.MinValue), new Point(21600, 21600))
	};

	private static readonly Point[] point_83 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, -2147483642),
		new Point(10800, 21600),
		new Point(21600, -2147483642)
	};

	private static readonly Class204 class204_52 = new Class204(point_82, ushort_49, struct15_39, int_36, struct16_40, 21600, 21600, int.MinValue, int.MinValue, point_83);

	private static readonly Point[] point_84 = new Point[11]
	{
		new Point(0, int.MinValue),
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, int.MinValue),
		new Point(-2147483643, int.MinValue),
		new Point(-2147483643, -2147483646),
		new Point(-2147483644, -2147483646),
		new Point(10800, 21600),
		new Point(-2147483647, -2147483646),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, int.MinValue)
	};

	private static readonly ushort[] ushort_50 = new ushort[3] { 10, 24576, 32768 };

	private static readonly Struct15[] struct15_40 = new Struct15[7]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(8194, 327, 0, 0)
	};

	private static readonly int[] int_37 = new int[4] { 14400, 5400, 18000, 8100 };

	private static readonly Struct16[] struct16_41 = new Struct16[1]
	{
		new Struct16(new Point(0, 0), new Point(21600, int.MinValue))
	};

	private static readonly Point[] point_85 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, -2147483642),
		new Point(10800, 21600),
		new Point(21600, -2147483642)
	};

	private static readonly Class204 class204_53 = new Class204(point_84, ushort_50, struct15_40, int_37, struct16_41, 21600, 21600, int.MinValue, int.MinValue, point_85);

	private static readonly Point[] point_86 = new Point[18]
	{
		new Point(int.MinValue, 0),
		new Point(-2147483644, 0),
		new Point(-2147483644, -2147483645),
		new Point(-2147483642, -2147483645),
		new Point(-2147483642, -2147483647),
		new Point(21600, 10800),
		new Point(-2147483642, -2147483643),
		new Point(-2147483642, -2147483641),
		new Point(-2147483644, -2147483641),
		new Point(-2147483644, 21600),
		new Point(int.MinValue, 21600),
		new Point(int.MinValue, -2147483641),
		new Point(-2147483646, -2147483641),
		new Point(-2147483646, -2147483643),
		new Point(0, 10800),
		new Point(-2147483646, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(int.MinValue, -2147483645)
	};

	private static readonly ushort[] ushort_51 = new ushort[3] { 17, 24576, 32768 };

	private static readonly Struct15[] struct15_41 = new Struct15[8]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1026),
		new Struct15(32768, 21600, 0, 1027)
	};

	private static readonly int[] int_38 = new int[4] { 5400, 5500, 2700, 8100 };

	private static readonly Struct16[] struct16_42 = new Struct16[1]
	{
		new Struct16(new Point(int.MinValue, 0), new Point(-2147483644, 21600))
	};

	private static readonly Class204 class204_54 = new Class204(point_86, ushort_51, struct15_41, int_38, struct16_42, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_87 = new Point[18]
	{
		new Point(0, int.MinValue),
		new Point(0, -2147483644),
		new Point(-2147483645, -2147483644),
		new Point(-2147483645, -2147483642),
		new Point(-2147483647, -2147483642),
		new Point(10800, 21600),
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483642),
		new Point(-2147483641, -2147483644),
		new Point(21600, -2147483644),
		new Point(21600, int.MinValue),
		new Point(-2147483641, int.MinValue),
		new Point(-2147483641, -2147483646),
		new Point(-2147483643, -2147483646),
		new Point(10800, 0),
		new Point(-2147483647, -2147483646),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, int.MinValue)
	};

	private static readonly ushort[] ushort_52 = new ushort[3] { 17, 24576, 32768 };

	private static readonly Struct15[] struct15_42 = new Struct15[8]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1026),
		new Struct15(32768, 21600, 0, 1027)
	};

	private static readonly int[] int_39 = new int[4] { 5400, 5500, 2700, 8100 };

	private static readonly Struct16[] struct16_43 = new Struct16[1]
	{
		new Struct16(new Point(0, int.MinValue), new Point(21600, -2147483644))
	};

	private static readonly Class204 class204_55 = new Class204(point_87, ushort_52, struct15_42, int_39, struct16_43, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_88 = new Point[32]
	{
		new Point(int.MinValue, int.MinValue),
		new Point(-2147483645, int.MinValue),
		new Point(-2147483645, -2147483646),
		new Point(-2147483647, -2147483646),
		new Point(10800, 0),
		new Point(-2147483643, -2147483646),
		new Point(-2147483641, -2147483646),
		new Point(-2147483641, int.MinValue),
		new Point(-2147483644, int.MinValue),
		new Point(-2147483644, -2147483645),
		new Point(-2147483642, -2147483645),
		new Point(-2147483642, -2147483647),
		new Point(21600, 10800),
		new Point(-2147483642, -2147483643),
		new Point(-2147483642, -2147483641),
		new Point(-2147483644, -2147483641),
		new Point(-2147483644, -2147483644),
		new Point(-2147483641, -2147483644),
		new Point(-2147483641, -2147483642),
		new Point(-2147483643, -2147483642),
		new Point(10800, 21600),
		new Point(-2147483647, -2147483642),
		new Point(-2147483645, -2147483642),
		new Point(-2147483645, -2147483644),
		new Point(int.MinValue, -2147483644),
		new Point(int.MinValue, -2147483641),
		new Point(-2147483646, -2147483641),
		new Point(-2147483646, -2147483643),
		new Point(0, 10800),
		new Point(-2147483646, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(int.MinValue, -2147483645)
	};

	private static readonly ushort[] ushort_53 = new ushort[3] { 31, 24576, 32768 };

	private static readonly Struct15[] struct15_43 = new Struct15[8]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0),
		new Struct15(8192, 330, 0, 0),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1026),
		new Struct15(32768, 21600, 0, 1027)
	};

	private static readonly int[] int_40 = new int[4] { 5400, 8100, 2700, 9400 };

	private static readonly Struct16[] struct16_44 = new Struct16[1]
	{
		new Struct16(new Point(int.MinValue, int.MinValue), new Point(-2147483644, -2147483644))
	};

	private static readonly Class204 class204_56 = new Class204(point_88, ushort_53, struct15_43, int_40, struct16_44, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_89 = new Point[10]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(6140, 6350),
		new Point(8470, 8680),
		new Point(13130, 6350),
		new Point(15460, 8680),
		new Point(4870, -2147483647),
		new Point(8680, -2147483646),
		new Point(12920, -2147483646),
		new Point(16730, -2147483647)
	};

	private static readonly ushort[] ushort_54 = new ushort[11]
	{
		41730, 24576, 32772, 41730, 24576, 33026, 41730, 24576, 33026, 8193,
		33024
	};

	private static readonly Struct15[] struct15_44 = new Struct15[3]
	{
		new Struct15(8192, 327, 0, 15510),
		new Struct15(32768, 17520, 0, 1024),
		new Struct15(16384, 15510, 1024, 0)
	};

	private static readonly Struct16[] struct16_45 = new Struct16[1]
	{
		new Struct16(new Point(0, -2147483647), new Point(-2147483644, 21600))
	};

	private static readonly int[] int_41 = new int[1] { 17520 };

	private static readonly Class204 class204_57 = new Class204(point_89, ushort_54, struct15_44, int_41, Class203.struct16_5, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_90 = new Point[4]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, int.MinValue),
		new Point(-2147483647, -2147483647)
	};

	private static readonly ushort[] ushort_55 = new ushort[3] { 41730, 41730, 32768 };

	private static readonly Struct15[] struct15_45 = new Struct15[2]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 327)
	};

	private static readonly Class204 class204_58 = new Class204(point_90, ushort_55, struct15_45, Class203.int_11, Class203.struct16_5, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_91 = new Point[10]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, int.MinValue),
		new Point(-2147483647, -2147483647),
		new Point(-2147483639, -2147483638),
		new Point(-2147483637, -2147483636),
		new Point(int.MinValue, int.MinValue),
		new Point(-2147483647, -2147483647),
		new Point(-2147483635, -2147483634),
		new Point(-2147483633, -2147483632)
	};

	private static readonly ushort[] ushort_56 = new ushort[6] { 41730, 41988, 24576, 41988, 24576, 32768 };

	private static readonly Struct15[] struct15_46 = new Struct15[17]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(32768, 10800, 0, 327),
		new Struct15(8193, 327, 1, 2),
		new Struct15(41088, 1027, 0, 1026),
		new Struct15(32768, 10800, 0, 1027),
		new Struct15(16384, 10800, 1027, 0),
		new Struct15(32768, 10800, 0, 1028),
		new Struct15(16384, 10800, 1028, 0),
		new Struct15(24705, 1029, 1031, 450),
		new Struct15(24706, 1029, 1031, 450),
		new Struct15(24705, 1029, 1032, 450),
		new Struct15(24706, 1029, 1032, 450),
		new Struct15(24705, 1030, 1032, 450),
		new Struct15(24706, 1030, 1032, 450),
		new Struct15(24705, 1030, 1031, 450),
		new Struct15(24706, 1030, 1031, 450)
	};

	private static readonly Class204 class204_59 = new Class204(point_91, ushort_56, struct15_46, Class203.int_8, Class203.struct16_5, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_92 = new Point[10]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(-2147483644, -2147483645),
		new Point(-2147483646, -2147483645),
		new Point(-2147483643, -2147483643),
		new Point(-2147483642, -2147483642),
		new Point(-2147483646, -2147483645),
		new Point(-2147483644, -2147483645),
		new Point(0, 0),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_57 = new ushort[4] { 41988, 42244, 24576, 32768 };

	private static readonly int[] int_42 = new int[2] { 11796480, 5400 };

	private static readonly Struct15[] struct15_47 = new Struct15[17]
	{
		new Struct15(16394, 10800, 327, 0),
		new Struct15(16393, 10800, 327, 0),
		new Struct15(8192, 1024, 10800, 0),
		new Struct15(8192, 1025, 10800, 0),
		new Struct15(32768, 21600, 0, 1026),
		new Struct15(32768, 10800, 0, 328),
		new Struct15(16384, 10800, 328, 0),
		new Struct15(24586, 1029, 327, 0),
		new Struct15(24585, 1029, 327, 0),
		new Struct15(24586, 1035, 327, 0),
		new Struct15(24585, 1035, 327, 0),
		new Struct15(16386, 10800, 328, 0),
		new Struct15(8192, 1033, 10800, 0),
		new Struct15(8192, 1034, 10800, 0),
		new Struct15(32768, 21600, 0, 1036),
		new Struct15(8198, 1024, 21600, 0),
		new Struct15(57350, 1024, 1030, 1029)
	};

	private static readonly Point[] point_93 = new Point[4]
	{
		new Point(10800, -2147483633),
		new Point(-2147483636, -2147483635),
		new Point(10800, -2147483632),
		new Point(-2147483634, -2147483635)
	};

	private static readonly Class204 class204_60 = new Class204(point_92, ushort_57, struct15_47, int_42, null, 21600, 21600, int.MinValue, int.MinValue, point_93);

	private static readonly Point[] point_94 = new Point[101]
	{
		new Point(10800, 21599),
		new Point(321, 6886),
		new Point(70, 6036),
		new Point(-9, 5766),
		new Point(-1, 5474),
		new Point(2, 5192),
		new Point(6, 4918),
		new Point(43, 4641),
		new Point(101, 4370),
		new Point(159, 4103),
		new Point(245, 3837),
		new Point(353, 3582),
		new Point(460, 3326),
		new Point(591, 3077),
		new Point(741, 2839),
		new Point(892, 2598),
		new Point(1066, 2369),
		new Point(1253, 2155),
		new Point(1443, 1938),
		new Point(1651, 1732),
		new Point(1874, 1543),
		new Point(2097, 1351),
		new Point(2337, 1174),
		new Point(2587, 1014),
		new Point(2839, 854),
		new Point(3106, 708),
		new Point(3380, 584),
		new Point(3656, 459),
		new Point(3945, 350),
		new Point(4237, 264),
		new Point(4533, 176),
		new Point(4838, 108),
		new Point(5144, 66),
		new Point(5454, 22),
		new Point(5771, 1),
		new Point(6086, 3),
		new Point(6407, 7),
		new Point(6731, 35),
		new Point(7048, 89),
		new Point(7374, 144),
		new Point(7700, 226),
		new Point(8015, 335),
		new Point(8344, 447),
		new Point(8667, 590),
		new Point(8972, 756),
		new Point(9297, 932),
		new Point(9613, 1135),
		new Point(9907, 1363),
		new Point(10224, 1609),
		new Point(10504, 1900),
		new Point(10802, 2169),
		new Point(11697, 1363),
		new Point(11971, 1116),
		new Point(12304, 934),
		new Point(12630, 756),
		new Point(12935, 590),
		new Point(13528, 450),
		new Point(13589, 335),
		new Point(13901, 226),
		new Point(14227, 144),
		new Point(14556, 89),
		new Point(14872, 35),
		new Point(15195, 7),
		new Point(15517, 3),
		new Point(15830, 0),
		new Point(16147, 22),
		new Point(16458, 66),
		new Point(16764, 109),
		new Point(17068, 177),
		new Point(17365, 264),
		new Point(17658, 349),
		new Point(17946, 458),
		new Point(18222, 584),
		new Point(18496, 708),
		new Point(18762, 854),
		new Point(19015, 1014),
		new Point(19264, 1172),
		new Point(19504, 1349),
		new Point(19730, 1543),
		new Point(19950, 1731),
		new Point(20158, 1937),
		new Point(20350, 2155),
		new Point(20536, 2369),
		new Point(20710, 2598),
		new Point(20861, 2839),
		new Point(21010, 3074),
		new Point(21143, 3323),
		new Point(21251, 3582),
		new Point(21357, 3835),
		new Point(21443, 4099),
		new Point(21502, 4370),
		new Point(21561, 4639),
		new Point(21595, 4916),
		new Point(21600, 5192),
		new Point(21606, 5474),
		new Point(21584, 5760),
		new Point(21532, 6036),
		new Point(21478, 6326),
		new Point(21366, 6603),
		new Point(21282, 6887),
		new Point(10802, 21602)
	};

	private static readonly ushort[] ushort_58 = new ushort[7] { 2, 8208, 1, 8208, 1, 24576, 32772 };

	private static readonly Struct16[] struct16_46 = new Struct16[1]
	{
		new Struct16(new Point(5080, 2540), new Point(16520, 13550))
	};

	private static readonly Point[] point_95 = new Point[4]
	{
		new Point(10800, 2180),
		new Point(3090, 10800),
		new Point(10800, 21600),
		new Point(18490, 10800)
	};

	private static readonly int[] int_43 = new int[4] { -9, 0, 21606, 21602 };

	private static readonly Class204 class204_61 = new Class204(point_94, ushort_58, null, null, struct16_46, 21615, 21602, int.MinValue, int.MinValue, point_95);

	private static readonly Point[] point_96 = new Point[12]
	{
		new Point(8458, 0),
		new Point(0, 3923),
		new Point(7564, 8416),
		new Point(4993, 9720),
		new Point(12197, 13904),
		new Point(9987, 14934),
		new Point(21600, 21600),
		new Point(14768, 12911),
		new Point(16558, 12016),
		new Point(11030, 6840),
		new Point(12831, 6120),
		new Point(8458, 0)
	};

	private static readonly ushort[] ushort_59 = new ushort[4] { 16384, 11, 24576, 32768 };

	private static readonly Struct16[] struct16_47 = new Struct16[1]
	{
		new Struct16(new Point(8680, 7410), new Point(13970, 14190))
	};

	private static readonly Point[] point_97 = new Point[7]
	{
		new Point(8458, 0),
		new Point(0, 3923),
		new Point(4993, 9720),
		new Point(9987, 14934),
		new Point(21600, 21600),
		new Point(16558, 12016),
		new Point(12831, 6120)
	};

	private static readonly Enum17[] enum17_5 = new Enum17[7]
	{
		Enum17.const_2,
		Enum17.const_2,
		Enum17.const_3,
		Enum17.const_3,
		Enum17.const_4,
		Enum17.const_1,
		Enum17.const_1
	};

	private static readonly Class204 class204_62 = new Class204(point_96, ushort_59, null, null, struct16_47, 21600, 21600, int.MinValue, int.MinValue, point_97, enum17_5);

	private static readonly Point[] point_98 = new Point[26]
	{
		new Point(0, 10800),
		new Point(-2147483644, -2147483640),
		new Point(-2147483644, -2147483639),
		new Point(-2147483638, -2147483637),
		new Point(-2147483636, -2147483635),
		new Point(-2147483634, -2147483633),
		new Point(-2147483632, -2147483631),
		new Point(-2147483630, -2147483629),
		new Point(-2147483628, -2147483627),
		new Point(-2147483626, -2147483625),
		new Point(-2147483624, -2147483623),
		new Point(-2147483622, -2147483621),
		new Point(-2147483620, -2147483619),
		new Point(-2147483618, -2147483617),
		new Point(-2147483616, -2147483615),
		new Point(-2147483614, -2147483613),
		new Point(-2147483612, -2147483611),
		new Point(-2147483610, -2147483609),
		new Point(-2147483608, -2147483607),
		new Point(-2147483606, -2147483605),
		new Point(-2147483604, -2147483603),
		new Point(-2147483602, -2147483601),
		new Point(-2147483600, -2147483599),
		new Point(-2147483598, -2147483597),
		new Point(int.MinValue, int.MinValue),
		new Point(-2147483647, -2147483647)
	};

	private static readonly ushort[] ushort_60 = new ushort[27]
	{
		2, 24576, 32768, 2, 24576, 32768, 2, 24576, 32768, 2,
		24576, 32768, 2, 24576, 32768, 2, 24576, 32768, 2, 24576,
		32768, 2, 24576, 32768, 41730, 24576, 32768
	};

	private static readonly Struct15[] struct15_48 = new Struct15[54]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(8192, 327, 0, 2700),
		new Struct15(8193, 1026, 5080, 7425),
		new Struct15(8192, 1027, 2540, 0),
		new Struct15(32768, 10125, 0, 327),
		new Struct15(8193, 1029, 2120, 7425),
		new Struct15(8192, 1030, 210, 0),
		new Struct15(16384, 10800, 1031, 0),
		new Struct15(32768, 10800, 0, 1031),
		new Struct15(129, 0, 10800, 450),
		new Struct15(130, 0, 10800, 450),
		new Struct15(24705, 1028, 1032, 450),
		new Struct15(24706, 1028, 1032, 450),
		new Struct15(24705, 1028, 1033, 450),
		new Struct15(24706, 1028, 1033, 450),
		new Struct15(129, 0, 10800, 900),
		new Struct15(130, 0, 10800, 900),
		new Struct15(24705, 1028, 1032, 900),
		new Struct15(24706, 1028, 1032, 900),
		new Struct15(24705, 1028, 1033, 900),
		new Struct15(24706, 1028, 1033, 900),
		new Struct15(129, 0, 10800, 1350),
		new Struct15(130, 0, 10800, 1350),
		new Struct15(24705, 1028, 1032, 1350),
		new Struct15(24706, 1028, 1032, 1350),
		new Struct15(24705, 1028, 1033, 1350),
		new Struct15(24706, 1028, 1033, 1350),
		new Struct15(129, 0, 10800, 1800),
		new Struct15(130, 0, 10800, 1800),
		new Struct15(24705, 1028, 1032, 1800),
		new Struct15(24706, 1028, 1032, 1800),
		new Struct15(24705, 1028, 1033, 1800),
		new Struct15(24706, 1028, 1033, 1800),
		new Struct15(129, 0, 10800, 2250),
		new Struct15(130, 0, 10800, 2250),
		new Struct15(24705, 1028, 1032, 2250),
		new Struct15(24706, 1028, 1032, 2250),
		new Struct15(24705, 1028, 1033, 2250),
		new Struct15(24706, 1028, 1033, 2250),
		new Struct15(129, 0, 10800, 2700),
		new Struct15(130, 0, 10800, 2700),
		new Struct15(24705, 1028, 1032, 2700),
		new Struct15(24706, 1028, 1032, 2700),
		new Struct15(24705, 1028, 1033, 2700),
		new Struct15(24706, 1028, 1033, 2700),
		new Struct15(129, 0, 10800, 3150),
		new Struct15(130, 0, 10800, 3150),
		new Struct15(24705, 1028, 1032, 3150),
		new Struct15(24706, 1028, 1032, 3150),
		new Struct15(24705, 1028, 1033, 3150),
		new Struct15(24706, 1028, 1033, 3150),
		new Struct15(8321, 327, 10800, 450),
		new Struct15(8321, 327, 10800, 2250)
	};

	private static readonly Struct16[] struct16_48 = new Struct16[1]
	{
		new Struct16(new Point(-2147483596, -2147483596), new Point(-2147483595, -2147483595))
	};

	private static readonly Class204 class204_63 = new Class204(point_98, ushort_60, struct15_48, Class203.int_11, struct16_48, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_99 = new Point[13]
	{
		new Point(21600, 0),
		new Point(-2147483645, -2147483644),
		new Point(int.MinValue, 5080),
		new Point(int.MinValue, 10800),
		new Point(int.MinValue, 16520),
		new Point(-2147483645, -2147483643),
		new Point(21600, 21600),
		new Point(9740, 21600),
		new Point(0, 16730),
		new Point(0, 10800),
		new Point(0, 4870),
		new Point(9740, 0),
		new Point(21600, 0)
	};

	private static readonly ushort[] ushort_61 = new ushort[3] { 8196, 24576, 32768 };

	private static readonly Struct15[] struct15_49 = new Struct15[11]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(8193, 1025, 1, 2),
		new Struct15(24576, 1026, 327, 0),
		new Struct15(8193, 327, 1794, 10000),
		new Struct15(32768, 21600, 0, 1028),
		new Struct15(8193, 327, 4000, 18900),
		new Struct15(32897, 0, 10800, 1030),
		new Struct15(32898, 0, 10800, 1030),
		new Struct15(24576, 1031, 1031, 0),
		new Struct15(32768, 21600, 0, 1032)
	};

	private static readonly Struct16[] struct16_49 = new Struct16[1]
	{
		new Struct16(new Point(-2147483639, -2147483640), new Point(int.MinValue, -2147483638))
	};

	private static readonly Point[] point_100 = new Point[4]
	{
		new Point(21600, 0),
		new Point(0, 10800),
		new Point(21600, 21600),
		new Point(int.MinValue, 10800)
	};

	private static readonly Enum17[] enum17_6 = new Enum17[4]
	{
		Enum17.const_2,
		Enum17.const_3,
		Enum17.const_4,
		Enum17.const_1
	};

	private static readonly Class204 class204_64 = new Class204(point_99, ushort_61, struct15_49, Class203.int_13, struct16_49, 21600, 21600, int.MinValue, int.MinValue, point_100, enum17_6);

	private static readonly Point[] point_101 = new Point[17]
	{
		new Point(int.MinValue, 0),
		new Point(0, -2147483647),
		new Point(0, -2147483646),
		new Point(int.MinValue, 21600),
		new Point(-2147483645, 21600),
		new Point(21600, -2147483646),
		new Point(21600, -2147483647),
		new Point(-2147483645, 0),
		new Point(int.MinValue, 0),
		new Point(int.MinValue, 0),
		new Point(0, -2147483647),
		new Point(0, -2147483646),
		new Point(int.MinValue, 21600),
		new Point(-2147483645, 21600),
		new Point(21600, -2147483646),
		new Point(21600, -2147483647),
		new Point(-2147483645, 0)
	};

	private static readonly ushort[] ushort_62 = new ushort[18]
	{
		42753, 1, 43009, 1, 42753, 1, 43009, 1, 24576, 33044,
		42753, 1, 43009, 32768, 42753, 1, 43009, 32768
	};

	private static readonly Struct15[] struct15_50 = new Struct15[16]
	{
		new Struct15(24576, 320, 327, 0),
		new Struct15(24576, 321, 327, 0),
		new Struct15(40960, 323, 0, 327),
		new Struct15(40960, 322, 0, 327),
		new Struct15(8322, 327, 0, 450),
		new Struct15(8192, 1028, 0, 10800),
		new Struct15(32768, 0, 0, 327),
		new Struct15(40960, 1030, 0, 1029),
		new Struct15(40960, 320, 0, 1031),
		new Struct15(40960, 321, 0, 1031),
		new Struct15(24576, 322, 1031, 0),
		new Struct15(24576, 323, 1031, 0),
		new Struct15(40960, 320, 0, 1029),
		new Struct15(40960, 321, 0, 1029),
		new Struct15(24576, 322, 1029, 0),
		new Struct15(24576, 323, 1029, 0)
	};

	private static readonly Struct16[] struct16_50 = new Struct16[1]
	{
		new Struct16(new Point(-2147483640, -2147483639), new Point(-2147483638, -2147483637))
	};

	private static readonly Class204 class204_65 = new Class204(point_101, ushort_62, struct15_50, Class203.int_9, struct16_50, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly ushort[] ushort_63 = new ushort[9] { 43009, 1, 42753, 1, 43009, 1, 42753, 24576, 32772 };

	private static readonly Struct16[] struct16_51 = new Struct16[1]
	{
		new Struct16(new Point(-2147483636, -2147483635), new Point(-2147483634, -2147483633))
	};

	private static readonly Class204 class204_66 = new Class204(point_101, ushort_63, struct15_50, Class203.int_9, struct16_51, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_102 = new Point[29]
	{
		new Point(-2147483644, 0),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483642),
		new Point(0, 10800),
		new Point(int.MinValue, -2147483641),
		new Point(int.MinValue, -2147483646),
		new Point(-2147483644, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, -2147483641),
		new Point(21600, 10800),
		new Point(-2147483645, -2147483642),
		new Point(-2147483645, -2147483647),
		new Point(-2147483640, 0),
		new Point(-2147483644, 0),
		new Point(-2147483644, 0),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483642),
		new Point(0, 10800),
		new Point(int.MinValue, -2147483641),
		new Point(int.MinValue, -2147483646),
		new Point(-2147483644, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, -2147483641),
		new Point(21600, 10800),
		new Point(-2147483645, -2147483642),
		new Point(-2147483645, -2147483647),
		new Point(-2147483640, 0)
	};

	private static readonly ushort[] ushort_64 = new ushort[30]
	{
		42753, 1, 43009, 42753, 1, 43009, 1, 42753, 1, 43009,
		42753, 1, 43009, 1, 24576, 32784, 42753, 1, 43009, 42753,
		1, 43009, 32768, 42753, 1, 43009, 42753, 1, 43009, 32768
	};

	private static readonly Struct15[] struct15_51 = new Struct15[15]
	{
		new Struct15(24576, 320, 327, 0),
		new Struct15(24576, 321, 327, 0),
		new Struct15(40960, 323, 0, 327),
		new Struct15(40960, 322, 0, 327),
		new Struct15(8193, 1024, 2, 1),
		new Struct15(8193, 327, 2, 1),
		new Struct15(32768, 10800, 0, 327),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(40960, 322, 0, 1029),
		new Struct15(8193, 327, 1, 3),
		new Struct15(24576, 1033, 327, 0),
		new Struct15(24576, 320, 1034, 0),
		new Struct15(24576, 321, 1033, 0),
		new Struct15(40960, 322, 0, 1034),
		new Struct15(40960, 323, 0, 1033)
	};

	private static readonly Struct16[] struct16_52 = new Struct16[1]
	{
		new Struct16(new Point(-2147483637, -2147483636), new Point(-2147483635, -2147483634))
	};

	private static readonly Class204 class204_67 = new Class204(point_102, ushort_64, struct15_51, Class203.int_6, struct16_52, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Struct15[] struct15_52 = new Struct15[5]
	{
		new Struct15(8193, 327, 1, 2),
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(8192, 1024, 0, 0),
		new Struct15(32768, 21600, 0, 1024)
	};

	private static readonly ushort[] ushort_65 = new ushort[10] { 8193, 1, 8193, 1, 24576, 32788, 8193, 1, 8193, 32768 };

	private static readonly Point[] point_103 = new Point[17]
	{
		new Point(21600, 0),
		new Point(10800, 0),
		new Point(0, -2147483645),
		new Point(0, -2147483647),
		new Point(0, -2147483646),
		new Point(0, -2147483644),
		new Point(10800, 21600),
		new Point(21600, 21600),
		new Point(21600, 0),
		new Point(21600, 0),
		new Point(10800, 0),
		new Point(0, -2147483645),
		new Point(0, -2147483647),
		new Point(0, -2147483646),
		new Point(0, -2147483644),
		new Point(10800, 21600),
		new Point(21600, 21600)
	};

	private static readonly Struct16[] struct16_53 = new Struct16[1]
	{
		new Struct16(new Point(6350, -2147483645), new Point(21600, -2147483644))
	};

	private static readonly Point[] point_104 = new Point[3]
	{
		new Point(21600, 0),
		new Point(0, 10800),
		new Point(21600, 21600)
	};

	private static readonly Class204 class204_68 = new Class204(point_103, ushort_65, struct15_52, Class203.int_6, struct16_53, 21600, 21600, int.MinValue, int.MinValue, point_104);

	private static readonly Point[] point_105 = new Point[17]
	{
		new Point(0, 0),
		new Point(10800, 0),
		new Point(21600, -2147483645),
		new Point(21600, -2147483647),
		new Point(21600, -2147483646),
		new Point(21600, -2147483644),
		new Point(10800, 21600),
		new Point(0, 21600),
		new Point(0, 0),
		new Point(0, 0),
		new Point(10800, 0),
		new Point(21600, -2147483645),
		new Point(21600, -2147483647),
		new Point(21600, -2147483646),
		new Point(21600, -2147483644),
		new Point(10800, 21600),
		new Point(0, 21600)
	};

	private static readonly Struct16[] struct16_54 = new Struct16[1]
	{
		new Struct16(new Point(0, -2147483645), new Point(15150, -2147483644))
	};

	private static readonly Point[] point_106 = new Point[3]
	{
		new Point(0, 0),
		new Point(0, 21600),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_69 = new Class204(point_105, ushort_65, struct15_52, Class203.int_6, struct16_54, 21600, 21600, int.MinValue, int.MinValue, point_106);

	private static readonly Struct15[] struct15_53 = new Struct15[11]
	{
		new Struct15(8193, 327, 1, 2),
		new Struct15(8192, 327, 0, 0),
		new Struct15(40960, 1028, 0, 327),
		new Struct15(40960, 1028, 0, 1024),
		new Struct15(8192, 328, 0, 0),
		new Struct15(24576, 1028, 1024, 0),
		new Struct15(24576, 1028, 327, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(8193, 327, 10000, 31953),
		new Struct15(32768, 21600, 0, 1033)
	};

	private static readonly ushort[] ushort_66 = new ushort[14]
	{
		8193, 1, 8194, 1, 8193, 1, 24576, 32784, 8193, 1,
		8194, 1, 8193, 32768
	};

	private static readonly int[] int_44 = new int[2] { 1800, 10800 };

	private static readonly Point[] point_107 = new Point[31]
	{
		new Point(21600, 0),
		new Point(16200, 0),
		new Point(10800, int.MinValue),
		new Point(10800, -2147483647),
		new Point(10800, -2147483646),
		new Point(10800, -2147483645),
		new Point(5400, -2147483644),
		new Point(0, -2147483644),
		new Point(5400, -2147483644),
		new Point(10800, -2147483643),
		new Point(10800, -2147483642),
		new Point(10800, -2147483641),
		new Point(10800, -2147483640),
		new Point(16200, 21600),
		new Point(21600, 21600),
		new Point(21600, 0),
		new Point(21600, 0),
		new Point(16200, 0),
		new Point(10800, int.MinValue),
		new Point(10800, -2147483647),
		new Point(10800, -2147483646),
		new Point(10800, -2147483645),
		new Point(5400, -2147483644),
		new Point(0, -2147483644),
		new Point(5400, -2147483644),
		new Point(10800, -2147483643),
		new Point(10800, -2147483642),
		new Point(10800, -2147483641),
		new Point(10800, -2147483640),
		new Point(16200, 21600),
		new Point(21600, 21600)
	};

	private static readonly Struct16[] struct16_55 = new Struct16[1]
	{
		new Struct16(new Point(13800, -2147483639), new Point(21600, -2147483638))
	};

	private static readonly Class204 class204_70 = new Class204(point_107, ushort_66, struct15_53, int_44, struct16_55, 21600, 21600, int.MinValue, int.MinValue, point_104);

	private static readonly Point[] point_108 = new Point[31]
	{
		new Point(0, 0),
		new Point(5400, 0),
		new Point(10800, int.MinValue),
		new Point(10800, -2147483647),
		new Point(10800, -2147483646),
		new Point(10800, -2147483645),
		new Point(16200, -2147483644),
		new Point(21600, -2147483644),
		new Point(16200, -2147483644),
		new Point(10800, -2147483643),
		new Point(10800, -2147483642),
		new Point(10800, -2147483641),
		new Point(10800, -2147483640),
		new Point(5400, 21600),
		new Point(0, 21600),
		new Point(0, 0),
		new Point(0, 0),
		new Point(5400, 0),
		new Point(10800, int.MinValue),
		new Point(10800, -2147483647),
		new Point(10800, -2147483646),
		new Point(10800, -2147483645),
		new Point(16200, -2147483644),
		new Point(21600, -2147483644),
		new Point(16200, -2147483644),
		new Point(10800, -2147483643),
		new Point(10800, -2147483642),
		new Point(10800, -2147483641),
		new Point(10800, -2147483640),
		new Point(5400, 21600),
		new Point(0, 21600)
	};

	private static readonly Struct16[] struct16_56 = new Struct16[1]
	{
		new Struct16(new Point(0, -2147483639), new Point(7800, -2147483638))
	};

	private static readonly Class204 class204_71 = new Class204(point_108, ushort_66, struct15_53, int_44, struct16_56, 21600, 21600, int.MinValue, int.MinValue, point_106);

	private static readonly Point[] point_109 = new Point[25]
	{
		new Point(10901, 5905),
		new Point(8458, 2399),
		new Point(7417, 6425),
		new Point(476, 2399),
		new Point(4732, 7722),
		new Point(106, 8718),
		new Point(3828, 11880),
		new Point(243, 14689),
		new Point(5772, 14041),
		new Point(4868, 17719),
		new Point(7819, 15730),
		new Point(8590, 21600),
		new Point(10637, 15038),
		new Point(13349, 19840),
		new Point(14125, 14561),
		new Point(18248, 18195),
		new Point(16938, 13044),
		new Point(21600, 13393),
		new Point(17710, 10579),
		new Point(21198, 8242),
		new Point(16806, 7417),
		new Point(18482, 4560),
		new Point(14257, 5429),
		new Point(14623, 106),
		new Point(10901, 5905)
	};

	private static readonly ushort[] ushort_67 = new ushort[3] { 24, 24576, 32772 };

	private static readonly Struct16[] struct16_57 = new Struct16[1]
	{
		new Struct16(new Point(4627, 6320), new Point(16702, 13937))
	};

	private static readonly Point[] point_110 = new Point[4]
	{
		new Point(14623, 106),
		new Point(106, 8718),
		new Point(8590, 21600),
		new Point(21600, 13393)
	};

	private static readonly Class204 class204_72 = new Class204(point_109, ushort_67, null, null, struct16_57, 21600, 21600, int.MinValue, int.MinValue, point_110);

	private static readonly Point[] point_111 = new Point[29]
	{
		new Point(11464, 4340),
		new Point(9722, 1887),
		new Point(8548, 6383),
		new Point(4503, 3626),
		new Point(5373, 7816),
		new Point(1174, 8270),
		new Point(3934, 11592),
		new Point(0, 12875),
		new Point(3329, 15372),
		new Point(1283, 17824),
		new Point(4804, 18239),
		new Point(4918, 21600),
		new Point(7525, 18125),
		new Point(8698, 19712),
		new Point(9871, 17371),
		new Point(11614, 18844),
		new Point(12178, 15937),
		new Point(14943, 17371),
		new Point(14640, 14348),
		new Point(18878, 15632),
		new Point(16382, 12311),
		new Point(18270, 11292),
		new Point(16986, 9404),
		new Point(21600, 6646),
		new Point(16382, 6533),
		new Point(18005, 3172),
		new Point(14524, 5778),
		new Point(14789, 0),
		new Point(11464, 4340)
	};

	private static readonly ushort[] ushort_68 = new ushort[3] { 28, 24576, 32772 };

	private static readonly Struct16[] struct16_58 = new Struct16[1]
	{
		new Struct16(new Point(5372, 6382), new Point(14640, 15935))
	};

	private static readonly Point[] point_112 = new Point[4]
	{
		new Point(9722, 1887),
		new Point(0, 12875),
		new Point(11614, 18844),
		new Point(21600, 6646)
	};

	private static readonly Class204 class204_73 = new Class204(point_111, ushort_68, null, null, struct16_58, 21600, 21600, int.MinValue, int.MinValue, point_112);

	private static readonly Point[] point_113 = new Point[9]
	{
		new Point(0, 10800),
		new Point(int.MinValue, int.MinValue),
		new Point(10800, 0),
		new Point(-2147483647, int.MinValue),
		new Point(21600, 10800),
		new Point(-2147483647, -2147483647),
		new Point(10800, 21600),
		new Point(int.MinValue, -2147483647),
		new Point(0, 10800)
	};

	private static readonly ushort[] ushort_69 = new ushort[3] { 8, 24576, 32772 };

	private static readonly Struct15[] struct15_54 = new Struct15[4]
	{
		new Struct15(32768, 10800, 0, 1026),
		new Struct15(16384, 10800, 1026, 0),
		new Struct15(8193, 1027, 19601, 27720),
		new Struct15(32768, 10800, 0, 327)
	};

	private static readonly Struct16[] struct16_59 = new Struct16[1]
	{
		new Struct16(new Point(-2147483644, -2147483644), new Point(-2147483645, -2147483645))
	};

	private static readonly Class204 class204_74 = new Class204(point_113, ushort_69, struct15_54, Class203.int_12, struct16_59, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_114 = new Point[11]
	{
		new Point(10797, 0),
		new Point(8278, 8256),
		new Point(0, 8256),
		new Point(6722, 13405),
		new Point(4198, 21600),
		new Point(10797, 16580),
		new Point(17401, 21600),
		new Point(14878, 13405),
		new Point(21600, 8256),
		new Point(13321, 8256),
		new Point(10797, 0)
	};

	private static readonly ushort[] ushort_70 = new ushort[3] { 10, 24576, 32772 };

	private static readonly Struct16[] struct16_60 = new Struct16[1]
	{
		new Struct16(new Point(6722, 8256), new Point(14878, 15460))
	};

	private static readonly Point[] point_115 = new Point[5]
	{
		new Point(10800, 0),
		new Point(0, 8256),
		new Point(4198, 21600),
		new Point(17401, 21600),
		new Point(21600, 8256)
	};

	private static readonly Class204 class204_75 = new Class204(point_114, ushort_70, null, null, struct16_60, 21600, 21600, int.MinValue, int.MinValue, point_115);

	private static readonly Struct15[] struct15_55 = new Struct15[101]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8321, 1024, 10800, 3150),
		new Struct15(8322, 1024, 10800, 3150),
		new Struct15(8321, 1024, 10800, 1350),
		new Struct15(8322, 1024, 10800, 1350),
		new Struct15(129, 0, 10800, 0),
		new Struct15(130, 0, 10800, 0),
		new Struct15(8321, 1024, 10800, 75),
		new Struct15(8322, 1024, 10800, 75),
		new Struct15(129, 0, 10800, 150),
		new Struct15(130, 0, 10800, 150),
		new Struct15(8321, 1024, 10800, 225),
		new Struct15(8322, 1024, 10800, 225),
		new Struct15(129, 0, 10800, 300),
		new Struct15(130, 0, 10800, 300),
		new Struct15(8321, 1024, 10800, 375),
		new Struct15(8322, 1024, 10800, 375),
		new Struct15(129, 0, 10800, 450),
		new Struct15(130, 0, 10800, 450),
		new Struct15(8321, 1024, 10800, 525),
		new Struct15(8322, 1024, 10800, 525),
		new Struct15(129, 0, 10800, 600),
		new Struct15(130, 0, 10800, 600),
		new Struct15(8321, 1024, 10800, 675),
		new Struct15(8322, 1024, 10800, 675),
		new Struct15(129, 0, 10800, 750),
		new Struct15(130, 0, 10800, 750),
		new Struct15(8321, 1024, 10800, 825),
		new Struct15(8322, 1024, 10800, 825),
		new Struct15(129, 0, 10800, 900),
		new Struct15(130, 0, 10800, 900),
		new Struct15(8321, 1024, 10800, 975),
		new Struct15(8322, 1024, 10800, 975),
		new Struct15(129, 0, 10800, 1050),
		new Struct15(130, 0, 10800, 1050),
		new Struct15(8321, 1024, 10800, 1125),
		new Struct15(8322, 1024, 10800, 1125),
		new Struct15(129, 0, 10800, 1200),
		new Struct15(130, 0, 10800, 1200),
		new Struct15(8321, 1024, 10800, 1275),
		new Struct15(8322, 1024, 10800, 1275),
		new Struct15(129, 0, 10800, 1350),
		new Struct15(130, 0, 10800, 1350),
		new Struct15(8321, 1024, 10800, 1425),
		new Struct15(8322, 1024, 10800, 1425),
		new Struct15(129, 0, 10800, 1500),
		new Struct15(130, 0, 10800, 1500),
		new Struct15(8321, 1024, 10800, 1575),
		new Struct15(8322, 1024, 10800, 1575),
		new Struct15(129, 0, 10800, 1650),
		new Struct15(130, 0, 10800, 1650),
		new Struct15(8321, 1024, 10800, 1725),
		new Struct15(8322, 1024, 10800, 1725),
		new Struct15(129, 0, 10800, 1800),
		new Struct15(130, 0, 10800, 1800),
		new Struct15(8321, 1024, 10800, 1875),
		new Struct15(8322, 1024, 10800, 1875),
		new Struct15(129, 0, 10800, 1950),
		new Struct15(130, 0, 10800, 1950),
		new Struct15(8321, 1024, 10800, 2025),
		new Struct15(8322, 1024, 10800, 2025),
		new Struct15(129, 0, 10800, 2100),
		new Struct15(130, 0, 10800, 2100),
		new Struct15(8321, 1024, 10800, 2175),
		new Struct15(8322, 1024, 10800, 2175),
		new Struct15(129, 0, 10800, 2250),
		new Struct15(130, 0, 10800, 2250),
		new Struct15(8321, 1024, 10800, 2325),
		new Struct15(8322, 1024, 10800, 2325),
		new Struct15(129, 0, 10800, 2400),
		new Struct15(130, 0, 10800, 2400),
		new Struct15(8321, 1024, 10800, 2475),
		new Struct15(8322, 1024, 10800, 2475),
		new Struct15(129, 0, 10800, 2550),
		new Struct15(130, 0, 10800, 2550),
		new Struct15(8321, 1024, 10800, 2625),
		new Struct15(8322, 1024, 10800, 2625),
		new Struct15(129, 0, 10800, 2700),
		new Struct15(130, 0, 10800, 2700),
		new Struct15(8321, 1024, 10800, 2775),
		new Struct15(8322, 1024, 10800, 2775),
		new Struct15(129, 0, 10800, 2850),
		new Struct15(130, 0, 10800, 2850),
		new Struct15(8321, 1024, 10800, 2925),
		new Struct15(8322, 1024, 10800, 2925),
		new Struct15(129, 0, 10800, 3000),
		new Struct15(130, 0, 10800, 3000),
		new Struct15(8321, 1024, 10800, 3075),
		new Struct15(8322, 1024, 10800, 3075),
		new Struct15(129, 0, 10800, 3150),
		new Struct15(130, 0, 10800, 3150),
		new Struct15(8321, 1024, 10800, 3225),
		new Struct15(8322, 1024, 10800, 3225),
		new Struct15(129, 0, 10800, 3300),
		new Struct15(130, 0, 10800, 3300),
		new Struct15(8321, 1024, 10800, 3375),
		new Struct15(8322, 1024, 10800, 3375),
		new Struct15(129, 0, 10800, 3450),
		new Struct15(130, 0, 10800, 3450),
		new Struct15(8321, 1024, 10800, 3525),
		new Struct15(8322, 1024, 10800, 3525)
	};

	private static readonly Point[] point_116 = new Point[17]
	{
		new Point(-2147483643, -2147483642),
		new Point(-2147483637, -2147483636),
		new Point(-2147483631, -2147483630),
		new Point(-2147483625, -2147483624),
		new Point(-2147483619, -2147483618),
		new Point(-2147483613, -2147483612),
		new Point(-2147483607, -2147483606),
		new Point(-2147483601, -2147483600),
		new Point(-2147483595, -2147483594),
		new Point(-2147483589, -2147483588),
		new Point(-2147483583, -2147483582),
		new Point(-2147483577, -2147483576),
		new Point(-2147483571, -2147483570),
		new Point(-2147483565, -2147483564),
		new Point(-2147483559, -2147483558),
		new Point(-2147483553, -2147483552),
		new Point(-2147483643, -2147483642)
	};

	private static readonly ushort[] ushort_71 = new ushort[3] { 16, 24576, 32772 };

	private static readonly Struct16[] struct16_61 = new Struct16[1]
	{
		new Struct16(new Point(-2147483647, -2147483646), new Point(-2147483645, -2147483644))
	};

	private static readonly Class204 class204_76 = new Class204(point_116, ushort_71, struct15_55, Class203.int_7, struct16_61, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_117 = new Point[33]
	{
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483640),
		new Point(-2147483639, -2147483638),
		new Point(-2147483637, -2147483636),
		new Point(-2147483635, -2147483634),
		new Point(-2147483633, -2147483632),
		new Point(-2147483631, -2147483630),
		new Point(-2147483629, -2147483628),
		new Point(-2147483627, -2147483626),
		new Point(-2147483625, -2147483624),
		new Point(-2147483623, -2147483622),
		new Point(-2147483621, -2147483620),
		new Point(-2147483619, -2147483618),
		new Point(-2147483617, -2147483616),
		new Point(-2147483615, -2147483614),
		new Point(-2147483613, -2147483612),
		new Point(-2147483611, -2147483610),
		new Point(-2147483609, -2147483608),
		new Point(-2147483607, -2147483606),
		new Point(-2147483605, -2147483604),
		new Point(-2147483603, -2147483602),
		new Point(-2147483601, -2147483600),
		new Point(-2147483599, -2147483598),
		new Point(-2147483597, -2147483596),
		new Point(-2147483595, -2147483594),
		new Point(-2147483593, -2147483592),
		new Point(-2147483591, -2147483590),
		new Point(-2147483589, -2147483588),
		new Point(-2147483587, -2147483586),
		new Point(-2147483585, -2147483584),
		new Point(-2147483583, -2147483582),
		new Point(-2147483581, -2147483580),
		new Point(-2147483643, -2147483642)
	};

	private static readonly ushort[] ushort_72 = new ushort[3] { 32, 24576, 32772 };

	private static readonly Struct15[] struct15_56 = new Struct15[69]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8321, 1024, 10800, 3150),
		new Struct15(8322, 1024, 10800, 3150),
		new Struct15(8321, 1024, 10800, 1350),
		new Struct15(8322, 1024, 10800, 1350),
		new Struct15(129, 0, 10800, 0),
		new Struct15(130, 0, 10800, 0),
		new Struct15(8321, 1024, 10800, 113),
		new Struct15(8322, 1024, 10800, 113),
		new Struct15(129, 0, 10800, 225),
		new Struct15(130, 0, 10800, 225),
		new Struct15(8321, 1024, 10800, 338),
		new Struct15(8322, 1024, 10800, 338),
		new Struct15(129, 0, 10800, 450),
		new Struct15(130, 0, 10800, 450),
		new Struct15(8321, 1024, 10800, 563),
		new Struct15(8322, 1024, 10800, 563),
		new Struct15(129, 0, 10800, 675),
		new Struct15(130, 0, 10800, 675),
		new Struct15(8321, 1024, 10800, 788),
		new Struct15(8322, 1024, 10800, 788),
		new Struct15(129, 0, 10800, 900),
		new Struct15(130, 0, 10800, 900),
		new Struct15(8321, 1024, 10800, 1013),
		new Struct15(8322, 1024, 10800, 1013),
		new Struct15(129, 0, 10800, 1125),
		new Struct15(130, 0, 10800, 1125),
		new Struct15(8321, 1024, 10800, 1238),
		new Struct15(8322, 1024, 10800, 1238),
		new Struct15(129, 0, 10800, 1350),
		new Struct15(130, 0, 10800, 1350),
		new Struct15(8321, 1024, 10800, 1463),
		new Struct15(8322, 1024, 10800, 1463),
		new Struct15(129, 0, 10800, 1575),
		new Struct15(130, 0, 10800, 1575),
		new Struct15(8321, 1024, 10800, 1688),
		new Struct15(8322, 1024, 10800, 1688),
		new Struct15(129, 0, 10800, 1800),
		new Struct15(130, 0, 10800, 1800),
		new Struct15(8321, 1024, 10800, 1913),
		new Struct15(8322, 1024, 10800, 1913),
		new Struct15(129, 0, 10800, 2025),
		new Struct15(130, 0, 10800, 2025),
		new Struct15(8321, 1024, 10800, 2138),
		new Struct15(8322, 1024, 10800, 2138),
		new Struct15(129, 0, 10800, 2250),
		new Struct15(130, 0, 10800, 2250),
		new Struct15(8321, 1024, 10800, 2363),
		new Struct15(8322, 1024, 10800, 2363),
		new Struct15(129, 0, 10800, 2475),
		new Struct15(130, 0, 10800, 2475),
		new Struct15(8321, 1024, 10800, 2588),
		new Struct15(8322, 1024, 10800, 2588),
		new Struct15(129, 0, 10800, 2700),
		new Struct15(130, 0, 10800, 2700),
		new Struct15(8321, 1024, 10800, 2813),
		new Struct15(8322, 1024, 10800, 2813),
		new Struct15(129, 0, 10800, 2925),
		new Struct15(130, 0, 10800, 2925),
		new Struct15(8321, 1024, 10800, 3038),
		new Struct15(8322, 1024, 10800, 3038),
		new Struct15(129, 0, 10800, 3150),
		new Struct15(130, 0, 10800, 3150),
		new Struct15(8321, 1024, 10800, 3263),
		new Struct15(8322, 1024, 10800, 3263),
		new Struct15(129, 0, 10800, 3375),
		new Struct15(130, 0, 10800, 3375),
		new Struct15(8321, 1024, 10800, 3488),
		new Struct15(8322, 1024, 10800, 3488)
	};

	private static readonly Class204 class204_77 = new Class204(point_117, ushort_72, struct15_56, Class203.int_7, struct16_61, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_118 = new Point[49]
	{
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483640),
		new Point(-2147483639, -2147483638),
		new Point(-2147483637, -2147483636),
		new Point(-2147483635, -2147483634),
		new Point(-2147483633, -2147483632),
		new Point(-2147483631, -2147483630),
		new Point(-2147483629, -2147483628),
		new Point(-2147483627, -2147483626),
		new Point(-2147483625, -2147483624),
		new Point(-2147483623, -2147483622),
		new Point(-2147483621, -2147483620),
		new Point(-2147483619, -2147483618),
		new Point(-2147483617, -2147483616),
		new Point(-2147483615, -2147483614),
		new Point(-2147483613, -2147483612),
		new Point(-2147483611, -2147483610),
		new Point(-2147483609, -2147483608),
		new Point(-2147483607, -2147483606),
		new Point(-2147483605, -2147483604),
		new Point(-2147483603, -2147483602),
		new Point(-2147483601, -2147483600),
		new Point(-2147483599, -2147483598),
		new Point(-2147483597, -2147483596),
		new Point(-2147483595, -2147483594),
		new Point(-2147483593, -2147483592),
		new Point(-2147483591, -2147483590),
		new Point(-2147483589, -2147483588),
		new Point(-2147483587, -2147483586),
		new Point(-2147483585, -2147483584),
		new Point(-2147483583, -2147483582),
		new Point(-2147483581, -2147483580),
		new Point(-2147483579, -2147483578),
		new Point(-2147483577, -2147483576),
		new Point(-2147483575, -2147483574),
		new Point(-2147483573, -2147483572),
		new Point(-2147483571, -2147483570),
		new Point(-2147483569, -2147483568),
		new Point(-2147483567, -2147483566),
		new Point(-2147483565, -2147483564),
		new Point(-2147483563, -2147483562),
		new Point(-2147483561, -2147483560),
		new Point(-2147483559, -2147483558),
		new Point(-2147483557, -2147483556),
		new Point(-2147483555, -2147483554),
		new Point(-2147483553, -2147483552),
		new Point(-2147483551, -2147483550),
		new Point(-2147483549, -2147483548),
		new Point(-2147483643, -2147483642)
	};

	private static readonly ushort[] ushort_73 = new ushort[3] { 48, 24576, 32772 };

	private static readonly Class204 class204_78 = new Class204(point_118, ushort_73, struct15_55, Class203.int_7, struct16_61, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Struct15[] struct15_57 = new Struct15[133]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8321, 1024, 10800, 3150),
		new Struct15(8322, 1024, 10800, 3150),
		new Struct15(8321, 1024, 10800, 1350),
		new Struct15(8322, 1024, 10800, 1350),
		new Struct15(129, 0, 10800, 0),
		new Struct15(130, 0, 10800, 0),
		new Struct15(8321, 1024, 10800, 56),
		new Struct15(8322, 1024, 10800, 56),
		new Struct15(129, 0, 10800, 113),
		new Struct15(130, 0, 10800, 113),
		new Struct15(8321, 1024, 10800, 169),
		new Struct15(8322, 1024, 10800, 169),
		new Struct15(129, 0, 10800, 225),
		new Struct15(130, 0, 10800, 225),
		new Struct15(8321, 1024, 10800, 281),
		new Struct15(8322, 1024, 10800, 281),
		new Struct15(129, 0, 10800, 338),
		new Struct15(130, 0, 10800, 338),
		new Struct15(8321, 1024, 10800, 394),
		new Struct15(8322, 1024, 10800, 394),
		new Struct15(129, 0, 10800, 450),
		new Struct15(130, 0, 10800, 450),
		new Struct15(8321, 1024, 10800, 506),
		new Struct15(8322, 1024, 10800, 506),
		new Struct15(129, 0, 10800, 563),
		new Struct15(130, 0, 10800, 563),
		new Struct15(8321, 1024, 10800, 619),
		new Struct15(8322, 1024, 10800, 619),
		new Struct15(129, 0, 10800, 675),
		new Struct15(130, 0, 10800, 675),
		new Struct15(8321, 1024, 10800, 731),
		new Struct15(8322, 1024, 10800, 731),
		new Struct15(129, 0, 10800, 788),
		new Struct15(130, 0, 10800, 788),
		new Struct15(8321, 1024, 10800, 843),
		new Struct15(8322, 1024, 10800, 843),
		new Struct15(129, 0, 10800, 900),
		new Struct15(130, 0, 10800, 900),
		new Struct15(8321, 1024, 10800, 956),
		new Struct15(8322, 1024, 10800, 956),
		new Struct15(129, 0, 10800, 1013),
		new Struct15(130, 0, 10800, 1013),
		new Struct15(8321, 1024, 10800, 1069),
		new Struct15(8322, 1024, 10800, 1069),
		new Struct15(129, 0, 10800, 1125),
		new Struct15(130, 0, 10800, 1125),
		new Struct15(8321, 1024, 10800, 1181),
		new Struct15(8322, 1024, 10800, 1181),
		new Struct15(129, 0, 10800, 1238),
		new Struct15(130, 0, 10800, 1238),
		new Struct15(8321, 1024, 10800, 1294),
		new Struct15(8322, 1024, 10800, 1294),
		new Struct15(129, 0, 10800, 1350),
		new Struct15(130, 0, 10800, 1350),
		new Struct15(8321, 1024, 10800, 1406),
		new Struct15(8322, 1024, 10800, 1406),
		new Struct15(129, 0, 10800, 1462),
		new Struct15(130, 0, 10800, 1462),
		new Struct15(8321, 1024, 10800, 1519),
		new Struct15(8322, 1024, 10800, 1519),
		new Struct15(129, 0, 10800, 1575),
		new Struct15(130, 0, 10800, 1575),
		new Struct15(8321, 1024, 10800, 1631),
		new Struct15(8322, 1024, 10800, 1631),
		new Struct15(129, 0, 10800, 1688),
		new Struct15(130, 0, 10800, 1688),
		new Struct15(8321, 1024, 10800, 1744),
		new Struct15(8322, 1024, 10800, 1744),
		new Struct15(129, 0, 10800, 1800),
		new Struct15(130, 0, 10800, 1800),
		new Struct15(8321, 1024, 10800, 1856),
		new Struct15(8322, 1024, 10800, 1856),
		new Struct15(129, 0, 10800, 1913),
		new Struct15(130, 0, 10800, 1913),
		new Struct15(8321, 1024, 10800, 1969),
		new Struct15(8322, 1024, 10800, 1969),
		new Struct15(129, 0, 10800, 2025),
		new Struct15(130, 0, 10800, 2025),
		new Struct15(8321, 1024, 10800, 2081),
		new Struct15(8322, 1024, 10800, 2081),
		new Struct15(129, 0, 10800, 2138),
		new Struct15(130, 0, 10800, 2138),
		new Struct15(8321, 1024, 10800, 2194),
		new Struct15(8322, 1024, 10800, 2194),
		new Struct15(129, 0, 10800, 2250),
		new Struct15(130, 0, 10800, 2250),
		new Struct15(8321, 1024, 10800, 2306),
		new Struct15(8322, 1024, 10800, 2306),
		new Struct15(129, 0, 10800, 2362),
		new Struct15(130, 0, 10800, 2362),
		new Struct15(8321, 1024, 10800, 2418),
		new Struct15(8322, 1024, 10800, 2418),
		new Struct15(129, 0, 10800, 2475),
		new Struct15(130, 0, 10800, 2475),
		new Struct15(8321, 1024, 10800, 2531),
		new Struct15(8322, 1024, 10800, 2531),
		new Struct15(129, 0, 10800, 2587),
		new Struct15(130, 0, 10800, 2587),
		new Struct15(8321, 1024, 10800, 2643),
		new Struct15(8322, 1024, 10800, 2643),
		new Struct15(129, 0, 10800, 2700),
		new Struct15(130, 0, 10800, 2700),
		new Struct15(8321, 1024, 10800, 2756),
		new Struct15(8322, 1024, 10800, 2756),
		new Struct15(129, 0, 10800, 2812),
		new Struct15(130, 0, 10800, 2812),
		new Struct15(8321, 1024, 10800, 2868),
		new Struct15(8322, 1024, 10800, 2868),
		new Struct15(129, 0, 10800, 2925),
		new Struct15(130, 0, 10800, 2925),
		new Struct15(8321, 1024, 10800, 2981),
		new Struct15(8322, 1024, 10800, 2981),
		new Struct15(129, 0, 10800, 3037),
		new Struct15(130, 0, 10800, 3037),
		new Struct15(8321, 1024, 10800, 3093),
		new Struct15(8322, 1024, 10800, 3093),
		new Struct15(129, 0, 10800, 3150),
		new Struct15(130, 0, 10800, 3150),
		new Struct15(8321, 1024, 10800, 3206),
		new Struct15(8322, 1024, 10800, 3206),
		new Struct15(129, 0, 10800, 3262),
		new Struct15(130, 0, 10800, 3262),
		new Struct15(8321, 1024, 10800, 3318),
		new Struct15(8322, 1024, 10800, 3318),
		new Struct15(129, 0, 10800, 3375),
		new Struct15(130, 0, 10800, 3375),
		new Struct15(8321, 1024, 10800, 3431),
		new Struct15(8322, 1024, 10800, 3431),
		new Struct15(129, 0, 10800, 3487),
		new Struct15(130, 0, 10800, 3487),
		new Struct15(8321, 1024, 10800, 3543),
		new Struct15(8322, 1024, 10800, 3543)
	};

	private static readonly Point[] point_119 = new Point[65]
	{
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483640),
		new Point(-2147483639, -2147483638),
		new Point(-2147483637, -2147483636),
		new Point(-2147483635, -2147483634),
		new Point(-2147483633, -2147483632),
		new Point(-2147483631, -2147483630),
		new Point(-2147483629, -2147483628),
		new Point(-2147483627, -2147483626),
		new Point(-2147483625, -2147483624),
		new Point(-2147483623, -2147483622),
		new Point(-2147483621, -2147483620),
		new Point(-2147483619, -2147483618),
		new Point(-2147483617, -2147483616),
		new Point(-2147483615, -2147483614),
		new Point(-2147483613, -2147483612),
		new Point(-2147483611, -2147483610),
		new Point(-2147483609, -2147483608),
		new Point(-2147483607, -2147483606),
		new Point(-2147483605, -2147483604),
		new Point(-2147483603, -2147483602),
		new Point(-2147483601, -2147483600),
		new Point(-2147483599, -2147483598),
		new Point(-2147483597, -2147483596),
		new Point(-2147483595, -2147483594),
		new Point(-2147483593, -2147483592),
		new Point(-2147483591, -2147483590),
		new Point(-2147483589, -2147483588),
		new Point(-2147483587, -2147483586),
		new Point(-2147483585, -2147483584),
		new Point(-2147483583, -2147483582),
		new Point(-2147483581, -2147483580),
		new Point(-2147483579, -2147483578),
		new Point(-2147483577, -2147483576),
		new Point(-2147483575, -2147483574),
		new Point(-2147483573, -2147483572),
		new Point(-2147483571, -2147483570),
		new Point(-2147483569, -2147483568),
		new Point(-2147483567, -2147483566),
		new Point(-2147483565, -2147483564),
		new Point(-2147483563, -2147483562),
		new Point(-2147483561, -2147483560),
		new Point(-2147483559, -2147483558),
		new Point(-2147483557, -2147483556),
		new Point(-2147483555, -2147483554),
		new Point(-2147483553, -2147483552),
		new Point(-2147483551, -2147483550),
		new Point(-2147483549, -2147483548),
		new Point(-2147483547, -2147483546),
		new Point(-2147483545, -2147483544),
		new Point(-2147483543, -2147483542),
		new Point(-2147483541, -2147483540),
		new Point(-2147483539, -2147483538),
		new Point(-2147483537, -2147483536),
		new Point(-2147483535, -2147483534),
		new Point(-2147483533, -2147483532),
		new Point(-2147483531, -2147483530),
		new Point(-2147483529, -2147483528),
		new Point(-2147483527, -2147483526),
		new Point(-2147483525, -2147483524),
		new Point(-2147483523, -2147483522),
		new Point(-2147483521, -2147483520),
		new Point(-2147483519, -2147483518),
		new Point(-2147483517, -2147483516),
		new Point(-2147483643, -2147483642)
	};

	private static readonly ushort[] ushort_74 = new ushort[3] { 64, 24576, 32772 };

	private static readonly Class204 class204_79 = new Class204(point_119, ushort_74, struct15_57, Class203.int_7, struct16_61, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_120 = new Point[54]
	{
		new Point(-2147483636, -2147483647),
		new Point(-2147483636, -2147483635),
		new Point(-2147483636, -2147483634),
		new Point(-2147483633, 21600),
		new Point(-2147483632, 21600),
		new Point(0, 21600),
		new Point(2750, -2147483641),
		new Point(0, -2147483646),
		new Point(int.MinValue, -2147483646),
		new Point(int.MinValue, -2147483644),
		new Point(int.MinValue, -2147483643),
		new Point(-2147483638, 0),
		new Point(-2147483637, 0),
		new Point(-2147483631, 0),
		new Point(-2147483630, 0),
		new Point(-2147483629, -2147483643),
		new Point(-2147483629, -2147483644),
		new Point(-2147483629, -2147483646),
		new Point(21600, -2147483646),
		new Point(18850, -2147483641),
		new Point(21600, 21600),
		new Point(-2147483628, 21600),
		new Point(-2147483627, 21600),
		new Point(-2147483626, -2147483634),
		new Point(-2147483626, -2147483635),
		new Point(-2147483626, -2147483647),
		new Point(-2147483636, -2147483647),
		new Point(-2147483636, -2147483635),
		new Point(-2147483636, -2147483625),
		new Point(-2147483633, -2147483624),
		new Point(-2147483632, -2147483624),
		new Point(-2147483637, -2147483624),
		new Point(-2147483638, -2147483624),
		new Point(int.MinValue, -2147483622),
		new Point(int.MinValue, -2147483623),
		new Point(int.MinValue, -2147483621),
		new Point(-2147483638, -2147483647),
		new Point(-2147483637, -2147483647),
		new Point(-2147483626, -2147483647),
		new Point(-2147483626, -2147483635),
		new Point(-2147483626, -2147483625),
		new Point(-2147483627, -2147483624),
		new Point(-2147483628, -2147483624),
		new Point(-2147483631, -2147483624),
		new Point(-2147483630, -2147483624),
		new Point(-2147483629, -2147483622),
		new Point(-2147483629, -2147483623),
		new Point(-2147483629, -2147483621),
		new Point(-2147483630, -2147483647),
		new Point(-2147483631, -2147483647),
		new Point(int.MinValue, -2147483623),
		new Point(int.MinValue, -2147483646),
		new Point(-2147483629, -2147483623),
		new Point(-2147483629, -2147483646)
	};

	private static readonly ushort[] ushort_75 = new ushort[27]
	{
		1, 8193, 5, 8193, 1, 8193, 5, 8193, 1, 24576,
		32768, 1, 8193, 1, 8194, 24576, 33026, 1, 8193, 1,
		8194, 24576, 33026, 1, 32768, 1, 32768
	};

	private static readonly Struct15[] struct15_58 = new Struct15[28]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(8193, 1026, 1, 2),
		new Struct15(8193, 1027, 1, 2),
		new Struct15(8193, 1028, 1, 2),
		new Struct15(8193, 1025, 1, 2),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(0, 420, 0, 0),
		new Struct15(8193, 1032, 2, 1),
		new Struct15(24576, 1024, 1032, 0),
		new Struct15(24576, 1024, 1033, 0),
		new Struct15(8192, 1024, 2700, 0),
		new Struct15(32768, 21600, 0, 1028),
		new Struct15(32768, 21600, 0, 1029),
		new Struct15(40960, 1036, 0, 1032),
		new Struct15(40960, 1036, 0, 1033),
		new Struct15(32768, 21600, 0, 1035),
		new Struct15(32768, 21600, 0, 1034),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1040),
		new Struct15(32768, 21600, 0, 1039),
		new Struct15(32768, 21600, 0, 1036),
		new Struct15(40960, 1037, 0, 1029),
		new Struct15(24576, 1025, 1027, 0),
		new Struct15(24576, 1025, 1028, 0),
		new Struct15(24576, 1049, 1029, 0),
		new Struct15(40960, 1049, 0, 1029)
	};

	private static readonly int[] int_45 = new int[2] { 5400, 18900 };

	private static readonly Struct16[] struct16_62 = new Struct16[1]
	{
		new Struct16(new Point(int.MinValue, 0), new Point(-2147483629, -2147483647))
	};

	private static readonly Point[] point_121 = new Point[4]
	{
		new Point(10800, 0),
		new Point(2750, -2147483641),
		new Point(10800, -2147483647),
		new Point(18850, -2147483641)
	};

	private static readonly Class204 class204_80 = new Class204(point_120, ushort_75, struct15_58, int_45, struct16_62, 21600, 21600, int.MinValue, int.MinValue, point_121);

	private static readonly Point[] point_122 = new Point[54]
	{
		new Point(-2147483636, -2147483646),
		new Point(-2147483636, -2147483644),
		new Point(-2147483636, -2147483643),
		new Point(-2147483633, 0),
		new Point(-2147483632, 0),
		new Point(0, 0),
		new Point(2750, -2147483642),
		new Point(0, -2147483647),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483635),
		new Point(int.MinValue, -2147483634),
		new Point(-2147483638, 21600),
		new Point(-2147483637, 21600),
		new Point(-2147483631, 21600),
		new Point(-2147483630, 21600),
		new Point(-2147483629, -2147483634),
		new Point(-2147483629, -2147483635),
		new Point(-2147483629, -2147483647),
		new Point(21600, -2147483647),
		new Point(18850, -2147483642),
		new Point(21600, 0),
		new Point(-2147483628, 0),
		new Point(-2147483627, 0),
		new Point(-2147483626, -2147483643),
		new Point(-2147483626, -2147483644),
		new Point(-2147483626, -2147483646),
		new Point(-2147483636, -2147483646),
		new Point(-2147483636, -2147483644),
		new Point(-2147483636, -2147483620),
		new Point(-2147483633, -2147483619),
		new Point(-2147483632, -2147483619),
		new Point(-2147483637, -2147483619),
		new Point(-2147483638, -2147483619),
		new Point(int.MinValue, -2147483617),
		new Point(int.MinValue, -2147483618),
		new Point(int.MinValue, -2147483616),
		new Point(-2147483638, -2147483646),
		new Point(-2147483637, -2147483646),
		new Point(-2147483626, -2147483646),
		new Point(-2147483626, -2147483644),
		new Point(-2147483626, -2147483620),
		new Point(-2147483627, -2147483619),
		new Point(-2147483628, -2147483619),
		new Point(-2147483631, -2147483619),
		new Point(-2147483630, -2147483619),
		new Point(-2147483629, -2147483617),
		new Point(-2147483629, -2147483618),
		new Point(-2147483629, -2147483616),
		new Point(-2147483630, -2147483646),
		new Point(-2147483631, -2147483646),
		new Point(int.MinValue, -2147483618),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483629, -2147483618),
		new Point(-2147483629, -2147483647)
	};

	private static readonly Point[] point_123 = new Point[4]
	{
		new Point(10800, -2147483646),
		new Point(2750, -2147483642),
		new Point(10800, 21600),
		new Point(18850, -2147483642)
	};

	private static readonly Struct15[] struct15_59 = new Struct15[33]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(32768, 21600, 0, 328),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(8193, 1026, 1, 2),
		new Struct15(8193, 1027, 1, 2),
		new Struct15(8193, 1028, 1, 2),
		new Struct15(8193, 1025, 1, 2),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(0, 420, 0, 0),
		new Struct15(8193, 1032, 2, 1),
		new Struct15(24576, 1024, 1032, 0),
		new Struct15(24576, 1024, 1033, 0),
		new Struct15(8192, 1024, 2700, 0),
		new Struct15(32768, 21600, 0, 1028),
		new Struct15(32768, 21600, 0, 1029),
		new Struct15(40960, 1036, 0, 1032),
		new Struct15(40960, 1036, 0, 1033),
		new Struct15(32768, 21600, 0, 1035),
		new Struct15(32768, 21600, 0, 1034),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1040),
		new Struct15(32768, 21600, 0, 1039),
		new Struct15(32768, 21600, 0, 1036),
		new Struct15(40960, 1037, 0, 1029),
		new Struct15(24576, 1025, 1027, 0),
		new Struct15(24576, 1025, 1028, 0),
		new Struct15(24576, 1049, 1029, 0),
		new Struct15(40960, 1049, 0, 1029),
		new Struct15(24576, 1028, 1029, 0),
		new Struct15(32768, 21600, 0, 1048),
		new Struct15(32768, 21600, 0, 1049),
		new Struct15(32768, 21600, 0, 1050),
		new Struct15(32768, 21600, 0, 1051)
	};

	private static readonly int[] int_46 = new int[2] { 5400, 2700 };

	private static readonly Struct16[] struct16_63 = new Struct16[1]
	{
		new Struct16(new Point(int.MinValue, -2147483646), new Point(-2147483629, 21600))
	};

	private static readonly Class204 class204_81 = new Class204(point_122, ushort_75, struct15_59, int_46, struct16_63, 21600, 21600, int.MinValue, int.MinValue, point_123);

	private static readonly Point[] point_124 = new Point[49]
	{
		new Point(0, int.MinValue),
		new Point(-2147483647, -2147483646),
		new Point(-2147483645, -2147483644),
		new Point(-2147483643, -2147483642),
		new Point(-2147483643, -2147483641),
		new Point(-2147483640, -2147483639),
		new Point(-2147483643, -2147483638),
		new Point(-2147483647, -2147483637),
		new Point(0, 21600),
		new Point(2700, -2147483635),
		new Point(0, int.MinValue),
		new Point(21600, int.MinValue),
		new Point(-2147483634, -2147483646),
		new Point(-2147483633, -2147483644),
		new Point(-2147483632, -2147483642),
		new Point(-2147483632, -2147483641),
		new Point(-2147483631, -2147483639),
		new Point(-2147483632, -2147483638),
		new Point(-2147483634, -2147483637),
		new Point(21600, 21600),
		new Point(18900, -2147483635),
		new Point(21600, int.MinValue),
		new Point(-2147483643, -2147483641),
		new Point(-2147483629, -2147483628),
		new Point(-2147483627, -2147483626),
		new Point(-2147483625, -2147483624),
		new Point(-2147483625, -2147483623),
		new Point(-2147483643, -2147483641),
		new Point(-2147483632, -2147483641),
		new Point(-2147483622, -2147483628),
		new Point(-2147483621, -2147483626),
		new Point(-2147483620, -2147483624),
		new Point(-2147483620, -2147483623),
		new Point(-2147483632, -2147483641),
		new Point(-2147483643, -2147483619),
		new Point(-2147483618, -2147483617),
		new Point(-2147483616, 0),
		new Point(10800, 0),
		new Point(-2147483615, 0),
		new Point(-2147483614, -2147483617),
		new Point(-2147483632, -2147483619),
		new Point(-2147483632, -2147483641),
		new Point(-2147483614, -2147483613),
		new Point(-2147483615, -2147483612),
		new Point(10800, -2147483612),
		new Point(-2147483616, -2147483612),
		new Point(-2147483618, -2147483613),
		new Point(-2147483643, -2147483641),
		new Point(-2147483643, -2147483619)
	};

	private static readonly ushort[] ushort_76 = new ushort[26]
	{
		8193, 2, 8193, 2, 24576, 32768, 8193, 2, 8193, 2,
		24576, 32768, 8193, 2, 24576, 32770, 8193, 2, 24576, 32770,
		8194, 1, 8194, 1, 24576, 32768
	};

	private static readonly Struct15[] struct15_60 = new Struct15[78]
	{
		new Struct15(24576, 329, 1061, 0),
		new Struct15(8193, 327, 1, 3),
		new Struct15(24576, 1024, 1063, 0),
		new Struct15(8193, 327, 2, 3),
		new Struct15(40960, 1030, 0, 1072),
		new Struct15(8192, 327, 0, 0),
		new Struct15(24576, 1053, 1061, 0),
		new Struct15(24576, 1053, 328, 0),
		new Struct15(8192, 327, 2700, 0),
		new Struct15(24576, 1081, 328, 0),
		new Struct15(40960, 1033, 0, 1082),
		new Struct15(8192, 1063, 21600, 0),
		new Struct15(57345, 1086, 1086, 1071),
		new Struct15(24576, 1042, 1088, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(32768, 21600, 0, 1032),
		new Struct15(24576, 1036, 1061, 0),
		new Struct15(8192, 327, 900, 0),
		new Struct15(24576, 1031, 1093, 0),
		new Struct15(8192, 327, 1800, 0),
		new Struct15(24576, 1048, 1100, 0),
		new Struct15(8192, 327, 2700, 0),
		new Struct15(24576, 1097, 328, 0),
		new Struct15(24576, 1048, 1061, 0),
		new Struct15(32768, 21600, 0, 1043),
		new Struct15(32768, 21600, 0, 1045),
		new Struct15(32768, 21600, 0, 1047),
		new Struct15(57345, 1069, 1069, 1071),
		new Struct15(8193, 1091, 2, 3),
		new Struct15(24576, 1053, 1094, 0),
		new Struct15(8193, 1092, 1, 3),
		new Struct15(32768, 21600, 0, 1056),
		new Struct15(32768, 21600, 0, 1054),
		new Struct15(24576, 328, 1055, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(32768, 21600, 0, 1062),
		new Struct15(24576, 328, 329, 0),
		new Struct15(24577, 1064, 1065, 1),
		new Struct15(16385, 10800, 1066, 1),
		new Struct15(8192, 1067, 0, 1),
		new Struct15(24577, 329, 1, 5400),
		new Struct15(32768, 1, 0, 1068),
		new Struct15(8193, 1025, 1, 10800),
		new Struct15(32768, 1, 0, 1070),
		new Struct15(8193, 327, 1, 10800),
		new Struct15(32769, 1, 1, 329),
		new Struct15(24577, 1073, 1074, 1),
		new Struct15(24577, 1075, 1066, 1),
		new Struct15(40960, 1069, 0, 1076),
		new Struct15(32768, 10800, 0, 327),
		new Struct15(32768, 1, 0, 1077),
		new Struct15(8193, 1027, 1, 10800),
		new Struct15(57345, 1079, 1079, 1071),
		new Struct15(32768, 1, 0, 1080),
		new Struct15(8193, 1032, 1, 10800),
		new Struct15(24576, 1078, 1061, 0),
		new Struct15(24577, 1083, 1084, 1),
		new Struct15(24577, 1085, 1066, 1),
		new Struct15(40960, 1079, 0, 1069),
		new Struct15(32768, 10800, 0, 1032),
		new Struct15(32768, 1, 0, 1087),
		new Struct15(1, 2700, 1, 10800),
		new Struct15(8193, 328, 1, 2),
		new Struct15(32768, 1, 0, 1090),
		new Struct15(8193, 1054, 1, 10800),
		new Struct15(8192, 327, 5400, 0),
		new Struct15(8192, 327, 21600, 0),
		new Struct15(24577, 1073, 1, -12),
		new Struct15(24577, 1073, 1095, 1),
		new Struct15(40960, 1089, 0, 1069),
		new Struct15(8193, 1043, 1, 10800),
		new Struct15(57345, 1098, 1098, 1071),
		new Struct15(32768, 1, 0, 1099),
		new Struct15(8193, 1047, 1, 10800),
		new Struct15(24577, 1101, 1066, -12),
		new Struct15(32768, 10800, 0, 1047)
	};

	private static int[] int_47 = new int[3] { 5400, 16200, 2700 };

	private static Struct16[] struct16_64 = new Struct16[1]
	{
		new Struct16(-2147483643, -2147483619, -2147483632, -2147483641)
	};

	private static readonly Point[] point_125 = new Point[4]
	{
		new Point(10800, 0),
		new Point(2700, -2147483635),
		new Point(10800, -2147483612),
		new Point(18900, -2147483635)
	};

	private static readonly Class204 class204_82 = new Class204(point_124, ushort_76, struct15_60, int_47, struct16_64, 21600, 21600, 10800, 10800, point_125);

	private static readonly Point[] point_126 = new Point[49]
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

	private static readonly Struct15[] struct15_61 = new Struct15[97]
	{
		new Struct15(24576, 1103, 1061, 0),
		new Struct15(8193, 327, 1, 3),
		new Struct15(24576, 1024, 1063, 0),
		new Struct15(8193, 327, 2, 3),
		new Struct15(40960, 1030, 0, 1072),
		new Struct15(8192, 327, 0, 0),
		new Struct15(24576, 1053, 1061, 0),
		new Struct15(24576, 1053, 1102, 0),
		new Struct15(8192, 327, 2700, 0),
		new Struct15(24576, 1081, 1102, 0),
		new Struct15(40960, 1033, 0, 1082),
		new Struct15(8192, 1063, 21600, 0),
		new Struct15(57345, 1086, 1086, 1071),
		new Struct15(24576, 1042, 1088, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(32768, 21600, 0, 1027),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(32768, 21600, 0, 1032),
		new Struct15(24576, 1036, 1061, 0),
		new Struct15(8192, 327, 900, 0),
		new Struct15(24576, 1031, 1093, 0),
		new Struct15(8192, 327, 1800, 0),
		new Struct15(24576, 1048, 1100, 0),
		new Struct15(8192, 327, 2700, 0),
		new Struct15(24576, 1097, 1102, 0),
		new Struct15(24576, 1048, 1061, 0),
		new Struct15(32768, 21600, 0, 1043),
		new Struct15(32768, 21600, 0, 1045),
		new Struct15(32768, 21600, 0, 1047),
		new Struct15(57345, 1069, 1069, 1071),
		new Struct15(8193, 1091, 2, 3),
		new Struct15(24576, 1053, 1094, 0),
		new Struct15(8193, 1092, 1, 3),
		new Struct15(32768, 21600, 0, 1056),
		new Struct15(32768, 21600, 0, 1054),
		new Struct15(24576, 1102, 1055, 0),
		new Struct15(8192, 1102, 0, 0),
		new Struct15(32768, 21600, 0, 1062),
		new Struct15(24576, 1102, 1103, 0),
		new Struct15(24577, 1064, 1065, 1),
		new Struct15(16385, 10800, 1066, 1),
		new Struct15(8192, 1067, 0, 1),
		new Struct15(24577, 1103, 1, 5400),
		new Struct15(32768, 1, 0, 1068),
		new Struct15(8193, 1025, 1, 10800),
		new Struct15(32768, 1, 0, 1070),
		new Struct15(8193, 327, 1, 10800),
		new Struct15(32769, 1, 1, 1103),
		new Struct15(24577, 1073, 1074, 1),
		new Struct15(24577, 1075, 1066, 1),
		new Struct15(40960, 1069, 0, 1076),
		new Struct15(32768, 10800, 0, 327),
		new Struct15(32768, 1, 0, 1077),
		new Struct15(8193, 1027, 1, 10800),
		new Struct15(57345, 1079, 1079, 1071),
		new Struct15(32768, 1, 0, 1080),
		new Struct15(8193, 1032, 1, 10800),
		new Struct15(24576, 1078, 1061, 0),
		new Struct15(24577, 1083, 1084, 1),
		new Struct15(24577, 1085, 1066, 1),
		new Struct15(40960, 1079, 0, 1069),
		new Struct15(32768, 10800, 0, 1032),
		new Struct15(32768, 1, 0, 1087),
		new Struct15(1, 2700, 1, 10800),
		new Struct15(8193, 1102, 1, 2),
		new Struct15(32768, 1, 0, 1090),
		new Struct15(8193, 1054, 1, 10800),
		new Struct15(8192, 327, 5400, 0),
		new Struct15(8192, 327, 21600, 0),
		new Struct15(24577, 1073, 1, -12),
		new Struct15(24577, 1073, 1095, 1),
		new Struct15(40960, 1089, 0, 1069),
		new Struct15(8193, 1043, 1, 10800),
		new Struct15(57345, 1098, 1098, 1071),
		new Struct15(32768, 1, 0, 1099),
		new Struct15(8193, 1047, 1, 10800),
		new Struct15(24577, 1101, 1066, -12),
		new Struct15(32768, 10800, 0, 1047),
		new Struct15(32768, 21600, 0, 328),
		new Struct15(32768, 21600, 0, 329),
		new Struct15(32768, 21600, 0, 1024),
		new Struct15(32768, 21600, 0, 1026),
		new Struct15(32768, 21600, 0, 1028),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(32768, 21600, 0, 1031),
		new Struct15(32768, 21600, 0, 1033),
		new Struct15(32768, 21600, 0, 1034),
		new Struct15(32768, 21600, 0, 1035),
		new Struct15(32768, 21600, 0, 1037),
		new Struct15(32768, 21600, 0, 1044),
		new Struct15(32768, 21600, 0, 1046),
		new Struct15(32768, 21600, 0, 1048),
		new Struct15(32768, 21600, 0, 1049),
		new Struct15(32768, 21600, 0, 1053),
		new Struct15(32768, 21600, 0, 1055),
		new Struct15(32768, 21600, 0, 1059),
		new Struct15(32768, 21600, 0, 1060)
	};

	private static int[] int_48 = new int[3] { 5400, 5400, 18900 };

	private static Struct16[] struct16_65 = new Struct16[1]
	{
		new Struct16(-2147483643, -2147483564, -2147483632, -2147483555)
	};

	private static readonly Point[] point_127 = new Point[4]
	{
		new Point(10800, -2147483552),
		new Point(2700, -2147483560),
		new Point(10800, 21600),
		new Point(18900, -2147483560)
	};

	private static readonly Class204 class204_83 = new Class204(point_126, ushort_76, struct15_61, int_48, struct16_65, 21600, 21600, 10800, 10800, point_127);

	private static readonly Point[] point_128 = new Point[20]
	{
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, 0),
		new Point(-2147483645, 0),
		new Point(-2147483644, 0),
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483642),
		new Point(-2147483640, -2147483642),
		new Point(-2147483639, -2147483647),
		new Point(-2147483639, -2147483647),
		new Point(-2147483638, -2147483637),
		new Point(-2147483638, -2147483637),
		new Point(-2147483636, 21600),
		new Point(-2147483635, 21600),
		new Point(-2147483634, 21600),
		new Point(-2147483633, -2147483632),
		new Point(-2147483631, -2147483632),
		new Point(-2147483630, -2147483632),
		new Point(-2147483629, -2147483637),
		new Point(-2147483629, -2147483637)
	};

	private static readonly ushort[] ushort_77 = new ushort[5] { 8195, 1, 8195, 24576, 32768 };

	private static readonly Struct15[] struct15_62 = new Struct15[37]
	{
		new Struct15(8197, 1054, 0, 0),
		new Struct15(8192, 327, 0, 0),
		new Struct15(24576, 1024, 1044, 0),
		new Struct15(24576, 1024, 1045, 0),
		new Struct15(24576, 1024, 1046, 0),
		new Struct15(24576, 1024, 1047, 0),
		new Struct15(8193, 1025, 2, 1),
		new Struct15(24576, 1024, 1048, 0),
		new Struct15(24576, 1024, 1049, 0),
		new Struct15(24576, 1024, 1050, 0),
		new Struct15(24576, 1043, 1050, 0),
		new Struct15(32768, 21600, 0, 1025),
		new Struct15(24576, 1043, 1049, 0),
		new Struct15(24576, 1043, 1048, 0),
		new Struct15(24576, 1043, 1047, 0),
		new Struct15(24576, 1043, 1046, 0),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(24576, 1043, 1045, 0),
		new Struct15(24576, 1043, 1044, 0),
		new Struct15(8197, 1053, 0, 0),
		new Struct15(8193, 1051, 2, 10),
		new Struct15(8193, 1051, 18, 40),
		new Struct15(8193, 1051, 4, 5),
		new Struct15(8193, 1051, 6, 5),
		new Struct15(8193, 1051, 62, 40),
		new Struct15(8193, 1051, 18, 10),
		new Struct15(8193, 1051, 2, 1),
		new Struct15(24580, 328, 1052, 0),
		new Struct15(32768, 21600, 0, 328),
		new Struct15(8193, 1055, 2, 1),
		new Struct15(8193, 1055, -2, 1),
		new Struct15(8192, 328, 0, 10800),
		new Struct15(24581, 1053, 1054, 0),
		new Struct15(24578, 1028, 1029, 0),
		new Struct15(24578, 1038, 1039, 0),
		new Struct15(32768, 10800, 0, 328),
		new Struct15(32768, 21600, 0, 1059)
	};

	private static readonly int[] int_49 = new int[2] { 2700, 10800 };

	private static readonly Struct16[] struct16_66 = new Struct16[1]
	{
		new Struct16(new Point(-2147483616, -2147483642), new Point(-2147483622, -2147483632))
	};

	private static readonly Point[] point_129 = new Point[4]
	{
		new Point(-2147483615, -2147483647),
		new Point(-2147483613, 10800),
		new Point(-2147483614, -2147483637),
		new Point(-2147483612, 10800)
	};

	private static readonly Class204 class204_84 = new Class204(point_128, ushort_77, struct15_62, int_49, struct16_66, 21600, 21600, 10800, 10800, point_129);

	private static readonly Point[] point_130 = new Point[32]
	{
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, 0),
		new Point(-2147483645, 0),
		new Point(-2147483644, 0),
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483642),
		new Point(-2147483640, -2147483642),
		new Point(-2147483639, 0),
		new Point(-2147483638, 0),
		new Point(-2147483637, 0),
		new Point(-2147483636, -2147483642),
		new Point(-2147483635, -2147483642),
		new Point(-2147483634, -2147483642),
		new Point(-2147483633, -2147483647),
		new Point(-2147483633, -2147483647),
		new Point(-2147483632, -2147483631),
		new Point(-2147483632, -2147483631),
		new Point(-2147483630, 21600),
		new Point(-2147483629, 21600),
		new Point(-2147483628, 21600),
		new Point(-2147483627, -2147483626),
		new Point(-2147483625, -2147483626),
		new Point(-2147483624, -2147483626),
		new Point(-2147483623, 21600),
		new Point(-2147483622, 21600),
		new Point(-2147483621, 21600),
		new Point(-2147483620, -2147483626),
		new Point(-2147483619, -2147483626),
		new Point(-2147483618, -2147483626),
		new Point(-2147483617, -2147483631),
		new Point(-2147483617, -2147483631)
	};

	private static readonly ushort[] ushort_78 = new ushort[5] { 8197, 1, 8197, 24576, 32768 };

	private static readonly Struct15[] struct15_63 = new Struct15[53]
	{
		new Struct15(8197, 1072, 0, 0),
		new Struct15(8192, 327, 0, 0),
		new Struct15(24576, 1024, 1056, 0),
		new Struct15(24576, 1024, 1057, 0),
		new Struct15(24576, 1024, 1058, 0),
		new Struct15(24576, 1024, 1059, 0),
		new Struct15(8193, 327, 2, 1),
		new Struct15(24576, 1024, 1060, 0),
		new Struct15(24576, 1024, 1061, 0),
		new Struct15(24576, 1024, 1062, 0),
		new Struct15(24576, 1024, 1063, 0),
		new Struct15(24576, 1024, 1064, 0),
		new Struct15(24576, 1024, 1065, 0),
		new Struct15(24576, 1024, 1066, 0),
		new Struct15(24576, 1024, 1067, 0),
		new Struct15(24576, 1024, 1068, 0),
		new Struct15(24576, 1055, 1068, 0),
		new Struct15(32768, 21600, 0, 327),
		new Struct15(24576, 1055, 1067, 0),
		new Struct15(24576, 1055, 1066, 0),
		new Struct15(24576, 1055, 1065, 0),
		new Struct15(24576, 1055, 1064, 0),
		new Struct15(32768, 21600, 0, 1030),
		new Struct15(24576, 1055, 1063, 0),
		new Struct15(24576, 1055, 1062, 0),
		new Struct15(24576, 1055, 1061, 0),
		new Struct15(24576, 1055, 1060, 0),
		new Struct15(24576, 1055, 1059, 0),
		new Struct15(24576, 1055, 1058, 0),
		new Struct15(24576, 1055, 1057, 0),
		new Struct15(24576, 1055, 1056, 0),
		new Struct15(8197, 1071, 0, 0),
		new Struct15(8193, 1069, 2, 20),
		new Struct15(8193, 1069, 4, 20),
		new Struct15(8193, 1069, 8, 20),
		new Struct15(8193, 1069, 12, 20),
		new Struct15(8193, 1069, 16, 20),
		new Struct15(8193, 1069, 20, 20),
		new Struct15(8193, 1069, 20, 20),
		new Struct15(8193, 1069, 24, 20),
		new Struct15(8193, 1069, 28, 20),
		new Struct15(8193, 1069, 32, 20),
		new Struct15(8193, 1069, 36, 20),
		new Struct15(8193, 1069, 38, 20),
		new Struct15(8193, 1069, 2, 1),
		new Struct15(24580, 328, 1070, 0),
		new Struct15(32768, 21600, 0, 328),
		new Struct15(8193, 1073, 2, 1),
		new Struct15(8193, 1073, -2, 1),
		new Struct15(8192, 328, 0, 10800),
		new Struct15(24581, 1071, 1072, 0),
		new Struct15(32768, 10800, 0, 328),
		new Struct15(32768, 21600, 0, 1075)
	};

	private static readonly int[] int_50 = new int[2] { 1400, 10800 };

	private static readonly Struct16[] struct16_67 = new Struct16[1]
	{
		new Struct16(new Point(-2147483598, -2147483642), new Point(-2147483604, -2147483622))
	};

	private static readonly Point[] point_131 = new Point[4]
	{
		new Point(-2147483640, -2147483647),
		new Point(-2147483597, 10800),
		new Point(-2147483624, -2147483631),
		new Point(-2147483596, 10800)
	};

	private static readonly Class204 class204_85 = new Class204(point_130, ushort_78, struct15_63, int_50, struct16_67, 21600, 21600, 10800, 10800, point_131);

	private static readonly Point[] point_132 = new Point[28]
	{
		new Point(-2147483640, 21600),
		new Point(0, -2147483628),
		new Point(-2147483640, -2147483629),
		new Point(-2147483641, -2147483629),
		new Point(-2147483641, -2147483630),
		new Point(-2147483637, 0),
		new Point(-2147483638, 0),
		new Point(21600, -2147483630),
		new Point(-2147483638, -2147483631),
		new Point(-2147483639, -2147483631),
		new Point(-2147483639, -2147483628),
		new Point(-2147483636, 21600),
		new Point(-2147483635, -2147483630),
		new Point(-2147483637, -2147483631),
		new Point(-2147483634, -2147483627),
		new Point(-2147483637, -2147483630),
		new Point(-2147483641, -2147483628),
		new Point(-2147483640, 21600),
		new Point(0, -2147483628),
		new Point(-2147483640, -2147483629),
		new Point(-2147483633, -2147483626),
		new Point(-2147483640, -2147483628),
		new Point(-2147483637, 0),
		new Point(-2147483635, -2147483630),
		new Point(-2147483641, -2147483629),
		new Point(-2147483641, -2147483628),
		new Point(-2147483637, -2147483631),
		new Point(-2147483638, -2147483631)
	};

	private static readonly ushort[] ushort_79 = new ushort[23]
	{
		42754, 2, 43009, 1, 42754, 2, 43009, 24576, 32768, 43009,
		42754, 24576, 33026, 43011, 42754, 24576, 33026, 42753, 32768, 1,
		32768, 1, 32768
	};

	private static readonly Struct15[] struct15_64 = new Struct15[24]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8193, 1024, 1, 2),
		new Struct15(24576, 1024, 1025, 0),
		new Struct15(8193, 1024, 2, 1),
		new Struct15(8193, 1025, 1, 2),
		new Struct15(24576, 1024, 1028, 0),
		new Struct15(24576, 1025, 1028, 0),
		new Struct15(24576, 320, 1024, 0),
		new Struct15(24576, 320, 1025, 0),
		new Struct15(40960, 322, 0, 1024),
		new Struct15(40960, 322, 0, 1025),
		new Struct15(24576, 320, 1026, 0),
		new Struct15(40960, 322, 0, 1026),
		new Struct15(24576, 320, 1027, 0),
		new Struct15(24576, 320, 1029, 0),
		new Struct15(24576, 320, 1030, 0),
		new Struct15(40960, 322, 0, 1030),
		new Struct15(24576, 321, 1024, 0),
		new Struct15(24576, 321, 1025, 0),
		new Struct15(40960, 323, 0, 1024),
		new Struct15(40960, 323, 0, 1025),
		new Struct15(24576, 321, 1030, 0),
		new Struct15(40960, 323, 0, 1030),
		new Struct15(40960, 322, 0, 1029)
	};

	private static readonly Struct16[] struct16_68 = new Struct16[1]
	{
		new Struct16(-2147483634, -2147483631, -2147483625, -2147483628)
	};

	private static readonly Point[] point_133 = new Point[4]
	{
		new Point(10800, 0),
		new Point(-2147483641, 10800),
		new Point(10800, 21600),
		new Point(-2147483639, 10800)
	};

	private static readonly Class204 class204_86 = new Class204(point_132, ushort_79, struct15_64, Class203.int_8, struct16_68, 21600, 21600, 11000, 10800, point_133);

	private static readonly Point[] point_134 = new Point[28]
	{
		new Point(21600, -2147483640),
		new Point(-2147483628, 0),
		new Point(-2147483629, -2147483640),
		new Point(-2147483629, -2147483641),
		new Point(-2147483630, -2147483641),
		new Point(0, -2147483637),
		new Point(0, -2147483638),
		new Point(-2147483630, 21600),
		new Point(-2147483631, -2147483638),
		new Point(-2147483631, -2147483639),
		new Point(-2147483628, -2147483639),
		new Point(21600, -2147483636),
		new Point(-2147483630, -2147483635),
		new Point(-2147483631, -2147483637),
		new Point(-2147483627, -2147483634),
		new Point(-2147483630, -2147483637),
		new Point(-2147483628, -2147483641),
		new Point(21600, -2147483640),
		new Point(-2147483628, 0),
		new Point(-2147483629, -2147483640),
		new Point(-2147483626, -2147483633),
		new Point(-2147483628, -2147483640),
		new Point(0, -2147483637),
		new Point(-2147483630, -2147483635),
		new Point(-2147483629, -2147483641),
		new Point(-2147483628, -2147483641),
		new Point(-2147483631, -2147483637),
		new Point(-2147483631, -2147483638)
	};

	private static readonly Struct15[] struct15_65 = new Struct15[25]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8193, 1024, 1, 2),
		new Struct15(24576, 1024, 1025, 0),
		new Struct15(8193, 1024, 2, 1),
		new Struct15(8193, 1025, 1, 2),
		new Struct15(24576, 1024, 1028, 0),
		new Struct15(24576, 1025, 1028, 0),
		new Struct15(24576, 321, 1024, 0),
		new Struct15(24576, 321, 1025, 0),
		new Struct15(40960, 323, 0, 1024),
		new Struct15(40960, 323, 0, 1025),
		new Struct15(24576, 321, 1026, 0),
		new Struct15(40960, 323, 0, 1026),
		new Struct15(24576, 321, 1027, 0),
		new Struct15(24576, 321, 1029, 0),
		new Struct15(24576, 321, 1030, 0),
		new Struct15(40960, 323, 0, 1030),
		new Struct15(24576, 320, 1024, 0),
		new Struct15(24576, 320, 1025, 0),
		new Struct15(40960, 322, 0, 1024),
		new Struct15(40960, 322, 0, 1025),
		new Struct15(24576, 320, 1030, 0),
		new Struct15(40960, 322, 0, 1030),
		new Struct15(24576, 320, 1024, 0),
		new Struct15(40960, 323, 0, 1024)
	};

	private static readonly ushort[] ushort_80 = new ushort[22]
	{
		43010, 2, 42753, 1, 43010, 2, 42753, 24576, 32768, 42755,
		24576, 33026, 42755, 43010, 24576, 33026, 43009, 32768, 1, 32768,
		1, 32768
	};

	private static readonly Struct16[] struct16_69 = new Struct16[1]
	{
		new Struct16(-2147483631, -2147483634, -2147483628, -2147483624)
	};

	private static readonly Point[] point_135 = new Point[4]
	{
		new Point(10800, -2147483641),
		new Point(0, 10800),
		new Point(10800, -2147483639),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_87 = new Class204(point_134, ushort_80, struct15_65, Class203.int_8, struct16_69, 21600, 21600, 10800, 11000, point_135);

	private static readonly Point[] point_136 = new Point[5]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_81 = new ushort[3] { 4, 24576, 32768 };

	private static readonly Class204 class204_88 = new Class204(point_136, ushort_81, null, null, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_137 = new Point[8]
	{
		new Point(0, -2147483646),
		new Point(int.MinValue, 0),
		new Point(-2147483647, 0),
		new Point(21600, -2147483646),
		new Point(21600, -2147483645),
		new Point(-2147483647, 21600),
		new Point(int.MinValue, 21600),
		new Point(0, -2147483645)
	};

	private static readonly ushort[] ushort_82 = new ushort[9] { 43009, 1, 42753, 1, 43009, 1, 42753, 24576, 32772 };

	private static readonly Struct15[] struct15_66 = new Struct15[8]
	{
		new Struct15(8192, 320, 2540, 0),
		new Struct15(8192, 322, 0, 2540),
		new Struct15(8192, 321, 2540, 0),
		new Struct15(8192, 323, 0, 2540),
		new Struct15(8192, 320, 800, 0),
		new Struct15(8192, 322, 0, 800),
		new Struct15(8192, 321, 800, 0),
		new Struct15(8192, 323, 0, 800)
	};

	private static readonly Struct16[] struct16_70 = new Struct16[1]
	{
		new Struct16(new Point(-2147483644, -2147483642), new Point(-2147483643, -2147483641))
	};

	private static readonly Class204 class204_89 = new Class204(point_137, ushort_82, struct15_66, null, struct16_70, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_138 = new Point[5]
	{
		new Point(0, 10800),
		new Point(10800, 0),
		new Point(21600, 10800),
		new Point(10800, 21600),
		new Point(0, 10800)
	};

	private static readonly ushort[] ushort_83 = new ushort[3] { 4, 24576, 32772 };

	private static readonly Struct16[] struct16_71 = new Struct16[1]
	{
		new Struct16(new Point(5400, 5400), new Point(16200, 16200))
	};

	private static readonly Class204 class204_90 = new Class204(point_138, ushort_83, null, null, struct16_71, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_139 = new Point[5]
	{
		new Point(4230, 0),
		new Point(21600, 0),
		new Point(17370, 21600),
		new Point(0, 21600),
		new Point(4230, 0)
	};

	private static readonly ushort[] ushort_84 = new ushort[3] { 4, 24576, 32772 };

	private static readonly Struct16[] struct16_72 = new Struct16[1]
	{
		new Struct16(new Point(4230, 0), new Point(17370, 21600))
	};

	private static readonly Point[] point_140 = new Point[6]
	{
		new Point(12960, 0),
		new Point(10800, 0),
		new Point(2160, 10800),
		new Point(8600, 21600),
		new Point(10800, 21600),
		new Point(19400, 10800)
	};

	private static readonly Class204 class204_91 = new Class204(point_139, ushort_84, null, null, struct16_72, 21600, 21600, int.MinValue, int.MinValue, point_140);

	private static readonly Point[] point_141 = new Point[8]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(2540, 0),
		new Point(2540, 21600),
		new Point(19060, 0),
		new Point(19060, 21600)
	};

	private static readonly ushort[] ushort_85 = new ushort[7] { 3, 24576, 32768, 1, 32768, 1, 32768 };

	private static readonly Struct16[] struct16_73 = new Struct16[1]
	{
		new Struct16(new Point(2540, 0), new Point(19060, 21600))
	};

	private static readonly Class204 class204_92 = new Class204(point_141, ushort_85, null, null, struct16_73, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_142 = new Point[8]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(4230, 0),
		new Point(4230, 21600),
		new Point(0, 4230),
		new Point(21600, 4230)
	};

	private static readonly ushort[] ushort_86 = new ushort[7] { 3, 24576, 32768, 1, 32768, 1, 32768 };

	private static readonly Struct16[] struct16_74 = new Struct16[1]
	{
		new Struct16(new Point(4230, 4230), new Point(21600, 21600))
	};

	private static readonly Class204 class204_93 = new Class204(point_142, ushort_86, null, null, struct16_74, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_143 = new Point[9]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 17360),
		new Point(13050, 17220),
		new Point(13340, 20770),
		new Point(5620, 21600),
		new Point(2860, 21100),
		new Point(1850, 20700),
		new Point(0, 20120)
	};

	private static readonly ushort[] ushort_87 = new ushort[4] { 2, 8194, 24576, 32768 };

	private static readonly Struct16[] struct16_75 = new Struct16[1]
	{
		new Struct16(new Point(0, 0), new Point(21600, 17360))
	};

	private static readonly Point[] point_144 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 20320),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_94 = new Class204(point_143, ushort_87, null, null, struct16_75, 21600, 21600, int.MinValue, int.MinValue, point_144);

	private static readonly Point[] point_145 = new Point[23]
	{
		new Point(0, 3600),
		new Point(1500, 3600),
		new Point(1500, 1800),
		new Point(3000, 1800),
		new Point(3000, 0),
		new Point(21600, 0),
		new Point(21600, 14409),
		new Point(20100, 14409),
		new Point(20100, 16209),
		new Point(18600, 16209),
		new Point(18600, 18009),
		new Point(11610, 17893),
		new Point(11472, 20839),
		new Point(4833, 21528),
		new Point(2450, 21113),
		new Point(1591, 20781),
		new Point(0, 20300),
		new Point(1500, 3600),
		new Point(18600, 3600),
		new Point(18600, 16209),
		new Point(3000, 1800),
		new Point(20100, 1800),
		new Point(20100, 14409)
	};

	private static readonly ushort[] ushort_88 = new ushort[8] { 10, 8194, 24576, 32768, 2, 33024, 2, 33024 };

	private static readonly Struct16[] struct16_76 = new Struct16[1]
	{
		new Struct16(new Point(0, 3600), new Point(18600, 18009))
	};

	private static readonly Point[] point_146 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 19890),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_95 = new Class204(point_145, ushort_88, null, null, struct16_76, 21600, 21600, int.MinValue, int.MinValue, point_146);

	private static readonly Point[] point_147 = new Point[6]
	{
		new Point(3470, 21600),
		new Point(0, 10800),
		new Point(3470, 0),
		new Point(18130, 0),
		new Point(21600, 10800),
		new Point(18130, 21600)
	};

	private static readonly ushort[] ushort_89 = new ushort[5] { 42754, 1, 42754, 24576, 32772 };

	private static readonly Struct16[] struct16_77 = new Struct16[1]
	{
		new Struct16(new Point(1060, 3180), new Point(20540, 18420))
	};

	private static readonly Class204 class204_96 = new Class204(point_147, ushort_89, null, null, struct16_77, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_148 = new Point[7]
	{
		new Point(4350, 0),
		new Point(17250, 0),
		new Point(21600, 10800),
		new Point(17250, 21600),
		new Point(4350, 21600),
		new Point(0, 10800),
		new Point(4350, 0)
	};

	private static readonly ushort[] ushort_90 = new ushort[3] { 6, 24576, 32772 };

	private static readonly Struct16[] struct16_78 = new Struct16[1]
	{
		new Struct16(new Point(4350, 0), new Point(17250, 21600))
	};

	private static readonly Class204 class204_97 = new Class204(point_148, ushort_90, null, null, struct16_78, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_149 = new Point[5]
	{
		new Point(0, 4300),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(0, 4300)
	};

	private static readonly ushort[] ushort_91 = new ushort[3] { 4, 24576, 32772 };

	private static readonly Struct16[] struct16_79 = new Struct16[1]
	{
		new Struct16(new Point(0, 4300), new Point(21600, 21600))
	};

	private static readonly Point[] point_150 = new Point[4]
	{
		new Point(10800, 2150),
		new Point(0, 10800),
		new Point(10800, 19890),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_98 = new Class204(point_149, ushort_91, null, null, struct16_79, 21600, 21600, int.MinValue, int.MinValue, point_150);

	private static readonly Point[] point_151 = new Point[5]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(17250, 21600),
		new Point(4350, 21600),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_92 = new ushort[3] { 4, 24576, 32772 };

	private static readonly Struct16[] struct16_80 = new Struct16[1]
	{
		new Struct16(new Point(4350, 0), new Point(17250, 21600))
	};

	private static readonly Point[] point_152 = new Point[4]
	{
		new Point(10800, 0),
		new Point(2160, 10800),
		new Point(10800, 21600),
		new Point(19440, 10800)
	};

	private static readonly Class204 class204_99 = new Class204(point_151, ushort_92, null, null, struct16_80, 21600, 21600, int.MinValue, int.MinValue, point_152);

	private static readonly Point[] point_153 = new Point[2]
	{
		new Point(0, 0),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_93 = new ushort[3] { 41730, 24576, 32772 };

	private static readonly Struct16[] struct16_81 = new Struct16[1]
	{
		new Struct16(new Point(3180, 3180), new Point(18420, 18420))
	};

	private static readonly Class204 class204_100 = new Class204(point_153, ushort_93, null, null, struct16_81, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_154 = new Point[6]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 17150),
		new Point(10800, 21600),
		new Point(0, 17150),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_94 = new ushort[3] { 5, 24576, 32772 };

	private static readonly Struct16[] struct16_82 = new Struct16[1]
	{
		new Struct16(new Point(0, 0), new Point(21600, 17150))
	};

	private static readonly Class204 class204_101 = new Class204(point_154, ushort_94, null, null, struct16_82, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_155 = new Point[6]
	{
		new Point(4300, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(0, 4300),
		new Point(4300, 0)
	};

	private static readonly ushort[] ushort_95 = new ushort[3] { 5, 24576, 32772 };

	private static readonly Struct16[] struct16_83 = new Struct16[1]
	{
		new Struct16(new Point(0, 4300), new Point(21600, 21600))
	};

	private static readonly Class204 class204_102 = new Class204(point_155, ushort_95, null, null, struct16_83, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_156 = new Point[26]
	{
		new Point(0, 2230),
		new Point(820, 3990),
		new Point(3410, 3980),
		new Point(5370, 4360),
		new Point(7430, 4030),
		new Point(10110, 3890),
		new Point(10690, 2270),
		new Point(11440, 300),
		new Point(14200, 160),
		new Point(16150, 0),
		new Point(18670, 170),
		new Point(20690, 390),
		new Point(21600, 2230),
		new Point(21600, 19420),
		new Point(20640, 17510),
		new Point(18320, 17490),
		new Point(16140, 17240),
		new Point(14710, 17370),
		new Point(11310, 17510),
		new Point(10770, 19430),
		new Point(10150, 21150),
		new Point(7380, 21290),
		new Point(5290, 21600),
		new Point(3220, 21250),
		new Point(610, 21130),
		new Point(0, 19420)
	};

	private static readonly ushort[] ushort_96 = new ushort[5] { 8196, 1, 8196, 24576, 32768 };

	private static readonly Struct16[] struct16_84 = new Struct16[1]
	{
		new Struct16(new Point(0, 4360), new Point(21600, 17240))
	};

	private static readonly Point[] point_157 = new Point[4]
	{
		new Point(10800, 2020),
		new Point(0, 10800),
		new Point(10800, 19320),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_103 = new Class204(point_156, ushort_96, null, null, struct16_84, 21600, 21600, int.MinValue, int.MinValue, point_157);

	private static readonly Point[] point_158 = new Point[6]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(3100, 3100),
		new Point(18500, 18500),
		new Point(3100, 18500),
		new Point(18500, 3100)
	};

	private static readonly ushort[] ushort_97 = new ushort[7] { 41730, 24576, 32772, 1, 32768, 1, 32768 };

	private static readonly Struct16[] struct16_85 = new Struct16[1]
	{
		new Struct16(new Point(3100, 3100), new Point(18500, 18500))
	};

	private static readonly Class204 class204_104 = new Class204(point_158, ushort_97, null, null, struct16_85, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_159 = new Point[6]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(0, 10800),
		new Point(21600, 10800),
		new Point(10800, 0),
		new Point(10800, 21600)
	};

	private static readonly ushort[] ushort_98 = new ushort[7] { 41730, 24576, 32772, 1, 32768, 1, 32768 };

	private static readonly Struct16[] struct16_86 = new Struct16[1]
	{
		new Struct16(new Point(3100, 3100), new Point(18500, 18500))
	};

	private static readonly Class204 class204_105 = new Class204(point_159, ushort_98, null, null, struct16_86, 21600, 21600, int.MinValue, int.MinValue, Class203.point_9);

	private static readonly Point[] point_160 = new Point[5]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(21600, 0),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_99 = new ushort[3] { 4, 24576, 32768 };

	private static readonly Struct16[] struct16_87 = new Struct16[1]
	{
		new Struct16(new Point(5400, 5400), new Point(16200, 16200))
	};

	private static readonly Point[] point_161 = new Point[3]
	{
		new Point(10800, 0),
		new Point(10800, 10800),
		new Point(10800, 21600)
	};

	private static readonly Class204 class204_106 = new Class204(point_160, ushort_99, null, null, struct16_87, 21600, 21600, int.MinValue, int.MinValue, point_161);

	private static readonly Point[] point_162 = new Point[6]
	{
		new Point(0, 10800),
		new Point(10800, 0),
		new Point(21600, 10800),
		new Point(10800, 21600),
		new Point(0, 10800),
		new Point(21600, 10800)
	};

	private static readonly ushort[] ushort_100 = new ushort[5] { 3, 24576, 32772, 1, 32768 };

	private static readonly Struct16[] struct16_88 = new Struct16[1]
	{
		new Struct16(new Point(5400, 5400), new Point(16200, 16200))
	};

	private static readonly Class204 class204_107 = new Class204(point_162, ushort_100, null, null, struct16_88, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_163 = new Point[4]
	{
		new Point(10800, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(10800, 0)
	};

	private static readonly ushort[] ushort_101 = new ushort[3] { 3, 24576, 32772 };

	private static readonly Struct16[] struct16_89 = new Struct16[1]
	{
		new Struct16(new Point(5400, 10800), new Point(16200, 21600))
	};

	private static readonly Point[] point_164 = new Point[4]
	{
		new Point(10800, 0),
		new Point(5400, 10800),
		new Point(10800, 21600),
		new Point(16200, 10800)
	};

	private static readonly Class204 class204_108 = new Class204(point_163, ushort_101, null, null, struct16_89, 21600, 21600, int.MinValue, int.MinValue, point_164);

	private static readonly Point[] point_165 = new Point[4]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(10800, 21600),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_102 = new ushort[3] { 3, 24576, 32772 };

	private static readonly Struct16[] struct16_90 = new Struct16[1]
	{
		new Struct16(new Point(5400, 0), new Point(16200, 10800))
	};

	private static readonly Class204 class204_109 = new Class204(point_165, ushort_102, null, null, struct16_90, 21600, 21600, int.MinValue, int.MinValue, point_164);

	private static readonly Point[] point_166 = new Point[6]
	{
		new Point(3600, 21600),
		new Point(0, 10800),
		new Point(3600, 0),
		new Point(21600, 0),
		new Point(18000, 10800),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_103 = new ushort[5] { 42754, 1, 42754, 24576, 32772 };

	private static readonly Struct16[] struct16_91 = new Struct16[1]
	{
		new Struct16(new Point(3600, 0), new Point(18000, 21600))
	};

	private static readonly Point[] point_167 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(18000, 10800)
	};

	private static readonly Class204 class204_110 = new Class204(point_166, ushort_103, null, null, struct16_91, 21600, 21600, int.MinValue, int.MinValue, point_167);

	private static readonly Point[] point_168 = new Point[5]
	{
		new Point(10800, 0),
		new Point(21600, 10800),
		new Point(10800, 21600),
		new Point(0, 21600),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_104 = new ushort[4] { 42754, 2, 24576, 32772 };

	private static readonly Struct16[] struct16_92 = new Struct16[1]
	{
		new Struct16(new Point(0, 3100), new Point(18500, 18500))
	};

	private static readonly Class204 class204_111 = new Class204(point_168, ushort_104, null, null, struct16_92, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_169 = new Point[15]
	{
		new Point(20980, 18150),
		new Point(20980, 21600),
		new Point(10670, 21600),
		new Point(4770, 21540),
		new Point(0, 16720),
		new Point(0, 10800),
		new Point(0, 4840),
		new Point(4840, 0),
		new Point(10800, 0),
		new Point(16740, 0),
		new Point(21600, 4840),
		new Point(21600, 10800),
		new Point(21600, 13520),
		new Point(20550, 16160),
		new Point(18670, 18170)
	};

	private static readonly ushort[] ushort_105 = new ushort[4] { 2, 8196, 24576, 32768 };

	private static readonly Struct16[] struct16_93 = new Struct16[1]
	{
		new Struct16(new Point(3100, 3100), new Point(18500, 18500))
	};

	private static readonly Class204 class204_112 = new Class204(point_169, ushort_105, null, null, struct16_93, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_170 = new Point[9]
	{
		new Point(0, 3400),
		new Point(10800, 0),
		new Point(21600, 3400),
		new Point(21600, 18200),
		new Point(10800, 21600),
		new Point(0, 18200),
		new Point(0, 3400),
		new Point(10800, 6800),
		new Point(21600, 3400)
	};

	private static readonly ushort[] ushort_106 = new ushort[7] { 43010, 1, 43010, 24576, 32768, 43010, 32768 };

	private static readonly Struct16[] struct16_94 = new Struct16[1]
	{
		new Struct16(new Point(0, 6800), new Point(21600, 18200))
	};

	private static readonly Point[] point_171 = new Point[5]
	{
		new Point(10800, 6800),
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_113 = new Class204(point_170, ushort_106, null, null, struct16_94, 21600, 21600, int.MinValue, int.MinValue, point_171);

	private static readonly Point[] point_172 = new Point[9]
	{
		new Point(18200, 0),
		new Point(21600, 10800),
		new Point(18200, 21600),
		new Point(3400, 21600),
		new Point(0, 10800),
		new Point(3400, 0),
		new Point(18200, 0),
		new Point(14800, 10800),
		new Point(18200, 21600)
	};

	private static readonly ushort[] ushort_107 = new ushort[7] { 42754, 1, 42754, 24576, 32768, 42754, 32768 };

	private static readonly Struct16[] struct16_95 = new Struct16[1]
	{
		new Struct16(new Point(3400, 0), new Point(14800, 21600))
	};

	private static readonly Point[] point_173 = new Point[5]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(14800, 10800),
		new Point(21600, 10800)
	};

	private static readonly Class204 class204_114 = new Class204(point_172, ushort_107, null, null, struct16_95, 21600, 21600, int.MinValue, int.MinValue, point_173);

	private static readonly Point[] point_174 = new Point[6]
	{
		new Point(3600, 0),
		new Point(17800, 0),
		new Point(21600, 10800),
		new Point(17800, 21600),
		new Point(3600, 21600),
		new Point(0, 10800)
	};

	private static readonly ushort[] ushort_108 = new ushort[5] { 1, 42754, 2, 24576, 32768 };

	private static readonly Struct16[] struct16_96 = new Struct16[1]
	{
		new Struct16(new Point(3600, 0), new Point(17800, 21600))
	};

	private static readonly Class204 class204_115 = new Class204(point_174, ushort_108, null, null, struct16_96, 21600, 21600, int.MinValue, int.MinValue, Class203.point_2);

	private static readonly Point[] point_175 = new Point[29]
	{
		new Point(0, 0),
		new Point(0, 3590),
		new Point(-2147483646, -2147483645),
		new Point(0, 8970),
		new Point(0, 12630),
		new Point(-2147483644, -2147483643),
		new Point(0, 18010),
		new Point(0, 21600),
		new Point(3590, 21600),
		new Point(-2147483642, -2147483641),
		new Point(8970, 21600),
		new Point(12630, 21600),
		new Point(-2147483640, -2147483639),
		new Point(18010, 21600),
		new Point(21600, 21600),
		new Point(21600, 18010),
		new Point(-2147483638, -2147483637),
		new Point(21600, 12630),
		new Point(21600, 8970),
		new Point(-2147483636, -2147483635),
		new Point(21600, 3590),
		new Point(21600, 0),
		new Point(18010, 0),
		new Point(-2147483634, -2147483633),
		new Point(12630, 0),
		new Point(8970, 0),
		new Point(-2147483632, -2147483631),
		new Point(3590, 0),
		new Point(0, 0)
	};

	private static readonly ushort[] ushort_109 = new ushort[3] { 28, 24576, 32768 };

	private static readonly Struct15[] struct15_67 = new Struct15[42]
	{
		new Struct15(8192, 327, 0, 10800),
		new Struct15(8192, 328, 0, 10800),
		new Struct15(24582, 1042, 327, 0),
		new Struct15(24582, 1042, 328, 6280),
		new Struct15(24582, 1047, 327, 0),
		new Struct15(24582, 1047, 328, 15320),
		new Struct15(24582, 1050, 327, 6280),
		new Struct15(24582, 1050, 328, 21600),
		new Struct15(24582, 1053, 327, 15320),
		new Struct15(24582, 1053, 328, 21600),
		new Struct15(24582, 1056, 327, 21600),
		new Struct15(24582, 1056, 328, 15320),
		new Struct15(24582, 1058, 327, 21600),
		new Struct15(24582, 1058, 328, 6280),
		new Struct15(24582, 1060, 327, 15320),
		new Struct15(24582, 1060, 328, 0),
		new Struct15(24582, 1062, 327, 6280),
		new Struct15(24582, 1062, 328, 0),
		new Struct15(40966, 327, -1, 1043),
		new Struct15(40966, 1025, -1, 1046),
		new Struct15(8195, 1024, 0, 0),
		new Struct15(8195, 1025, 0, 0),
		new Struct15(40960, 1044, 0, 1045),
		new Struct15(40966, 327, -1, 1048),
		new Struct15(24582, 1025, 1046, -1),
		new Struct15(8192, 328, 0, 21600),
		new Struct15(24582, 1049, 1051, -1),
		new Struct15(40966, 1024, -1, 1052),
		new Struct15(40960, 1045, 0, 1044),
		new Struct15(24582, 1049, 1054, -1),
		new Struct15(24582, 1024, 1052, -1),
		new Struct15(8192, 327, 0, 21600),
		new Struct15(24582, 1055, 1057, -1),
		new Struct15(24582, 1025, 1046, -1),
		new Struct15(24582, 1055, 1059, -1),
		new Struct15(40966, 1025, -1, 1046),
		new Struct15(40966, 328, -1, 1061),
		new Struct15(24582, 1024, 1052, -1),
		new Struct15(40966, 328, -1, 1063),
		new Struct15(40966, 1024, -1, 1052),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0)
	};

	private static readonly int[] int_51 = new int[2] { 1400, 25920 };

	private static readonly Struct16[] struct16_97 = new Struct16[1]
	{
		new Struct16(new Point(0, 0), new Point(21600, 21600))
	};

	private static readonly Point[] point_176 = new Point[5]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800),
		new Point(-2147483608, -2147483607)
	};

	private static readonly Class204 class204_116 = new Class204(point_175, ushort_109, struct15_67, int_51, struct16_97, 21600, 21600, int.MinValue, int.MinValue, point_176);

	private static readonly Point[] point_177 = new Point[25]
	{
		new Point(3590, 0),
		new Point(0, 3590),
		new Point(-2147483646, -2147483645),
		new Point(0, 8970),
		new Point(0, 12630),
		new Point(-2147483644, -2147483643),
		new Point(0, 18010),
		new Point(3590, 21600),
		new Point(-2147483642, -2147483641),
		new Point(8970, 21600),
		new Point(12630, 21600),
		new Point(-2147483640, -2147483639),
		new Point(18010, 21600),
		new Point(21600, 18010),
		new Point(-2147483638, -2147483637),
		new Point(21600, 12630),
		new Point(21600, 8970),
		new Point(-2147483636, -2147483635),
		new Point(21600, 3590),
		new Point(18010, 0),
		new Point(-2147483634, -2147483633),
		new Point(12630, 0),
		new Point(8970, 0),
		new Point(-2147483632, -2147483631),
		new Point(3590, 0)
	};

	private static readonly ushort[] ushort_110 = new ushort[10] { 42753, 5, 43009, 5, 42753, 5, 43009, 5, 24576, 32768 };

	private static readonly Struct15[] struct15_68 = new Struct15[42]
	{
		new Struct15(8192, 327, 0, 10800),
		new Struct15(8192, 328, 0, 10800),
		new Struct15(24582, 1042, 327, 0),
		new Struct15(24582, 1042, 328, 6280),
		new Struct15(24582, 1047, 327, 0),
		new Struct15(24582, 1047, 328, 15320),
		new Struct15(24582, 1050, 327, 6280),
		new Struct15(24582, 1050, 328, 21600),
		new Struct15(24582, 1053, 327, 15320),
		new Struct15(24582, 1053, 328, 21600),
		new Struct15(24582, 1056, 327, 21600),
		new Struct15(24582, 1056, 328, 15320),
		new Struct15(24582, 1058, 327, 21600),
		new Struct15(24582, 1058, 328, 6280),
		new Struct15(24582, 1060, 327, 15320),
		new Struct15(24582, 1060, 328, 0),
		new Struct15(24582, 1062, 327, 6280),
		new Struct15(24582, 1062, 328, 0),
		new Struct15(40966, 327, -1, 1043),
		new Struct15(40966, 1025, -1, 1046),
		new Struct15(8195, 1024, 0, 0),
		new Struct15(8195, 1025, 0, 0),
		new Struct15(40960, 1044, 0, 1045),
		new Struct15(40966, 327, -1, 1048),
		new Struct15(24582, 1025, 1046, -1),
		new Struct15(8192, 328, 0, 21600),
		new Struct15(24582, 1049, 1051, -1),
		new Struct15(40966, 1024, -1, 1052),
		new Struct15(40960, 1045, 0, 1044),
		new Struct15(24582, 1049, 1054, -1),
		new Struct15(24582, 1024, 1052, -1),
		new Struct15(8192, 327, 0, 21600),
		new Struct15(24582, 1055, 1057, -1),
		new Struct15(24582, 1025, 1046, -1),
		new Struct15(24582, 1055, 1059, -1),
		new Struct15(40966, 1025, -1, 1046),
		new Struct15(40966, 328, -1, 1061),
		new Struct15(24582, 1024, 1052, -1),
		new Struct15(40966, 328, -1, 1063),
		new Struct15(40966, 1024, -1, 1052),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0)
	};

	private static readonly int[] int_52 = new int[2] { 1350, 25920 };

	private static readonly Struct16[] struct16_98 = new Struct16[1]
	{
		new Struct16(new Point(800, 800), new Point(20800, 20800))
	};

	private static readonly Point[] point_178 = new Point[5]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800),
		new Point(-2147483608, -2147483607)
	};

	private static readonly Class204 class204_117 = new Class204(point_177, ushort_110, struct15_68, int_52, struct16_98, 21600, 21600, int.MinValue, int.MinValue, point_178);

	private static readonly Point[] point_179 = new Point[5]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(-2147483644, -2147483643)
	};

	private static readonly Struct15[] struct15_69 = new Struct15[15]
	{
		new Struct15(16384, 10800, 1030, 0),
		new Struct15(16384, 10800, 1031, 0),
		new Struct15(16384, 10800, 1032, 0),
		new Struct15(16384, 10800, 1033, 0),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(16393, 10800, 1034, 0),
		new Struct15(16394, 10800, 1034, 0),
		new Struct15(16393, 10800, 1035, 0),
		new Struct15(16394, 10800, 1035, 0),
		new Struct15(8206, 1036, 0, 11),
		new Struct15(8206, 1036, 11, 0),
		new Struct15(24584, 1038, 1037, 0),
		new Struct15(8192, 327, 0, 10800),
		new Struct15(8192, 328, 0, 10800)
	};

	private static readonly ushort[] ushort_111 = new ushort[4] { 42244, 1, 24576, 32768 };

	private static readonly int[] int_53 = new int[2] { 1350, 25920 };

	private static readonly Struct16[] struct16_99 = new Struct16[1]
	{
		new Struct16(new Point(3200, 3200), new Point(18400, 18400))
	};

	private static readonly Point[] point_180 = new Point[9]
	{
		new Point(10800, 0),
		new Point(3160, 3160),
		new Point(0, 10800),
		new Point(3160, 18440),
		new Point(10800, 21600),
		new Point(18440, 18440),
		new Point(21600, 10800),
		new Point(18440, 3160),
		new Point(-2147483644, -2147483643)
	};

	private static readonly Class204 class204_118 = new Class204(point_179, ushort_111, struct15_69, int_53, struct16_99, 21600, 21600, int.MinValue, int.MinValue, point_180);

	private static readonly Point[] point_181 = new Point[117]
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

	private static readonly Struct15[] struct15_70 = new Struct15[26]
	{
		new Struct15(16384, 9000, 1036, 0),
		new Struct15(16384, 9000, 1037, 0),
		new Struct15(16384, 12600, 1036, 0),
		new Struct15(16384, 12600, 1037, 0),
		new Struct15(16384, 9600, 1038, 0),
		new Struct15(16384, 9600, 1039, 0),
		new Struct15(16384, 12000, 1038, 0),
		new Struct15(16384, 12000, 1039, 0),
		new Struct15(8192, 327, 0, 600),
		new Struct15(8192, 328, 0, 600),
		new Struct15(8192, 327, 600, 0),
		new Struct15(8192, 328, 600, 0),
		new Struct15(57355, 1040, 1046, 1047),
		new Struct15(57356, 1040, 1046, 1047),
		new Struct15(57355, 1041, 1046, 1047),
		new Struct15(57356, 1041, 1046, 1047),
		new Struct15(8192, 1043, 12600, 0),
		new Struct15(8192, 1042, 15600, 0),
		new Struct15(8193, 1043, 2, 0),
		new Struct15(8193, 1044, 1, 3),
		new Struct15(8192, 1045, 0, 17400),
		new Struct15(24704, 1046, 1047, 0),
		new Struct15(8192, 327, 0, 10800),
		new Struct15(8192, 328, 0, 10800),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0)
	};

	private static readonly ushort[] ushort_112 = new ushort[34]
	{
		8214, 24576, 32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193,
		32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193, 32768, 8193,
		32768, 8193, 32768, 8193, 32768, 42242, 24576, 32768, 42242, 24576,
		32768, 42242, 24576, 32768
	};

	private static readonly int[] int_54 = new int[2] { 1350, 25920 };

	private static readonly Struct16[] struct16_100 = new Struct16[1]
	{
		new Struct16(new Point(3000, 3320), new Point(17110, 17330))
	};

	private static readonly Point[] point_182 = new Point[5]
	{
		new Point(10800, 1220),
		new Point(50, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800),
		new Point(-2147483624, -2147483623)
	};

	private static readonly Class204 class204_119 = new Class204(point_181, ushort_112, struct15_70, int_54, struct16_100, 21300, 21600, int.MinValue, int.MinValue, point_182);

	private static readonly Point[] point_183 = new Point[2]
	{
		new Point(0, 0),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_113 = new ushort[2] { 1, 32768 };

	private static readonly Class204 class204_120 = new Class204(point_183, ushort_113, null, null, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_184 = new Point[4]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(int.MinValue, 21600),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_114 = new ushort[2] { 3, 32768 };

	private static readonly Struct15[] struct15_71 = new Struct15[1]
	{
		new Struct15(8192, 327, 0, 0)
	};

	private static readonly Class204 class204_121 = new Class204(point_184, ushort_114, struct15_71, Class203.int_13, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_185 = new Point[3]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_115 = new ushort[2] { 2, 32768 };

	private static readonly Class204 class204_122 = new Class204(point_185, ushort_115, null, null, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_186 = new Point[5]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(int.MinValue, -2147483647),
		new Point(21600, -2147483647),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_116 = new ushort[2] { 4, 32768 };

	private static readonly Struct15[] struct15_72 = new Struct15[2]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0)
	};

	private static readonly int[] int_55 = new int[2] { 10800, 10800 };

	private static readonly Class204 class204_123 = new Class204(point_186, ushort_116, struct15_72, int_55, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_187 = new Point[6]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483647),
		new Point(-2147483646, 21600),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_117 = new ushort[2] { 5, 32768 };

	private static readonly Struct15[] struct15_73 = new Struct15[3]
	{
		new Struct15(8192, 327, 0, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8192, 329, 0, 0)
	};

	private static readonly int[] int_56 = new int[3] { 10800, 10800, 10800 };

	private static readonly Class204 class204_124 = new Class204(point_187, ushort_117, struct15_73, int_56, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_188 = new Point[7]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(-2147483647, 5400),
		new Point(-2147483647, 10800),
		new Point(-2147483647, 16200),
		new Point(-2147483646, 21600),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_118 = new ushort[2] { 8194, 32768 };

	private static readonly Struct15[] struct15_74 = new Struct15[4]
	{
		new Struct15(8193, 327, 1, 2),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8193, 1027, 1, 2),
		new Struct15(8192, 327, 21600, 0)
	};

	private static readonly Class204 class204_125 = new Class204(point_188, ushort_118, struct15_74, Class203.int_4, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_189 = new Point[4]
	{
		new Point(0, 0),
		new Point(10800, 0),
		new Point(21600, 10800),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_119 = new ushort[2] { 8193, 32768 };

	private static readonly Class204 class204_126 = new Class204(point_189, ushort_119, null, null, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);

	private static readonly Point[] point_190 = new Point[10]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(-2147483647, -2147483646),
		new Point(-2147483647, -2147483645),
		new Point(-2147483647, -2147483644),
		new Point(-2147483643, -2147483642),
		new Point(-2147483641, -2147483642),
		new Point(-2147483640, -2147483642),
		new Point(21600, -2147483639),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_120 = new ushort[2] { 8195, 32768 };

	private static readonly Struct15[] struct15_75 = new Struct15[10]
	{
		new Struct15(8193, 327, 1, 2),
		new Struct15(8192, 327, 0, 0),
		new Struct15(8193, 328, 1, 4),
		new Struct15(8193, 328, 1, 2),
		new Struct15(8193, 328, 3, 4),
		new Struct15(24578, 327, 1031, 0),
		new Struct15(8192, 328, 0, 0),
		new Struct15(8194, 327, 21600, 0),
		new Struct15(8194, 1031, 21600, 0),
		new Struct15(8194, 328, 21600, 0)
	};

	private static readonly int[] int_57;

	private static readonly Class204 class204_127;

	private static readonly Point[] point_191;

	private static readonly ushort[] ushort_121;

	private static readonly Struct15[] struct15_76;

	private static readonly int[] int_58;

	private static readonly Class204 class204_128;

	private static readonly Point[] point_192;

	private static readonly ushort[] ushort_122;

	private static readonly Struct15[] struct15_77;

	private static readonly Struct16[] struct16_101;

	private static readonly Class204 class204_129;

	private static readonly Point[] point_193;

	private static readonly ushort[] ushort_123;

	private static readonly Struct16[] struct16_102;

	private static readonly Class204 class204_130;

	private static readonly Point[] point_194;

	private static readonly ushort[] ushort_124;

	private static readonly Struct15[] struct15_78;

	private static readonly Struct16[] struct16_103;

	private static readonly int[] int_59;

	private static readonly Point[] point_195;

	private static readonly Class204 class204_131;

	private static readonly int[] int_60;

	private static readonly Class204 class204_132;

	private static readonly Point[] point_196;

	private static readonly ushort[] ushort_125;

	private static readonly int[] int_61;

	private static readonly Class204 class204_133;

	private static readonly Point[] point_197;

	private static readonly ushort[] ushort_126;

	private static readonly int[] int_62;

	private static readonly Class204 class204_134;

	private static readonly ushort[] ushort_127;

	private static readonly Class204 class204_135;

	private static readonly Point[] point_198;

	private static readonly ushort[] ushort_128;

	private static readonly Class204 class204_136;

	private static readonly Point[] point_199;

	private static readonly ushort[] ushort_129;

	private static readonly Class204 class204_137;

	private static readonly Point[] point_200;

	private static readonly ushort[] ushort_130;

	private static readonly Class204 class204_138;

	private static readonly ushort[] ushort_131;

	private static readonly Class204 class204_139;

	private static readonly Class204 class204_140;

	private static readonly ushort[] ushort_132;

	private static readonly Class204 class204_141;

	private static readonly ushort[] ushort_133;

	private static readonly Class204 class204_142;

	private static readonly Class204 class204_143;

	private static readonly ushort[] ushort_134;

	private static readonly Class204 class204_144;

	private static readonly ushort[] ushort_135;

	private static readonly Class204 class204_145;

	private static readonly ushort[] ushort_136;

	private static readonly Class204 class204_146;

	private static void smethod_0(Point[] points, float scaleX, float scaleY)
	{
		for (int i = 0; i < points.Length; i++)
		{
			if ((points[i].X & int.MinValue) == 0 || points[i].X >= -1073741824)
			{
				points[i].X = (int)Math.Round((float)points[i].X * scaleX);
			}
			if ((points[i].Y & int.MinValue) == 0 || points[i].Y >= -1073741824)
			{
				points[i].Y = (int)Math.Round((float)points[i].Y * scaleY);
			}
		}
	}

	private static Point smethod_1(Point point, float scaleX, float scaleY)
	{
		if ((point.X & int.MinValue) == 0 || point.X >= -1073741824)
		{
			point.X = (int)Math.Round((float)point.X * scaleX);
		}
		if ((point.Y & int.MinValue) == 0 || point.Y >= -1073741824)
		{
			point.Y = (int)Math.Round((float)point.Y * scaleY);
		}
		return point;
	}

	public static Point[] smethod_2(Class2934 arrayProp)
	{
		if (arrayProp.CbElem != 4 && arrayProp.CbElem != 8)
		{
			return null;
		}
		Point[] array = new Point[arrayProp.NElems];
		if (arrayProp.CbElem == 4)
		{
			for (int i = 0; i < arrayProp.NElems; i++)
			{
				uint num = (uint)arrayProp[i];
				ref Point reference = ref array[i];
				reference = new Point((ushort)(num & 0xFFFF), (ushort)(num >> 16));
			}
		}
		else
		{
			for (int j = 0; j < arrayProp.NElems; j++)
			{
				ulong num2 = arrayProp[j];
				ref Point reference2 = ref array[j];
				reference2 = new Point((int)(num2 & 0xFFFFFFFFL), (int)(num2 >> 32));
			}
		}
		return array;
	}

	internal Class2934 method_0()
	{
		if (ushort_0 == null)
		{
			return null;
		}
		Class2934 @class = new Class2934(Enum426.const_63, (ushort)ushort_0.Length, 2);
		for (int i = 0; i < ushort_0.Length; i++)
		{
			@class[i] = ushort_0[i];
		}
		return @class;
	}

	internal Class2934 method_1()
	{
		return smethod_3(Enum426.const_62, point_0);
	}

	internal Class2934 method_2()
	{
		return smethod_3(Enum426.const_72, point_1);
	}

	private static Class2934 smethod_3(Enum426 id, Point[] points)
	{
		if (points == null)
		{
			return null;
		}
		Class2934 @class = new Class2934(id, (ushort)points.Length, 8);
		for (int i = 0; i < points.Length; i++)
		{
			Class1162.smethod_16(@class.Value, 6 + i * 8, points[i].X);
			Class1162.smethod_16(@class.Value, 6 + i * 8 + 4, points[i].Y);
		}
		return @class;
	}

	internal Class2934 method_3()
	{
		if (struct15_0 == null)
		{
			return null;
		}
		Class2934 @class = new Class2934(Enum426.const_77, (ushort)struct15_0.Length, 8);
		for (int i = 0; i < struct15_0.Length; i++)
		{
			Struct15 @struct = struct15_0[i];
			Class1162.smethod_13(@class.Value, 6 + i * 8, @struct.ushort_0);
			Class1162.smethod_12(@class.Value, 6 + i * 8 + 2, @struct.short_0);
			Class1162.smethod_12(@class.Value, 6 + i * 8 + 4, @struct.short_1);
			Class1162.smethod_12(@class.Value, 6 + i * 8 + 6, @struct.short_2);
		}
		return @class;
	}

	internal Class2934 method_4()
	{
		if (struct16_1 == null)
		{
			return null;
		}
		Class2934 @class = new Class2934(Enum426.const_78, (ushort)struct16_1.Length, 16);
		for (int i = 0; i < struct16_1.Length; i++)
		{
			Struct16 @struct = struct16_1[i];
			Class1162.smethod_16(@class.Value, 6 + i * 16, @struct.point_0.X);
			Class1162.smethod_16(@class.Value, 6 + i * 16 + 4, @struct.point_0.Y);
			Class1162.smethod_16(@class.Value, 6 + i * 16 + 8, @struct.point_1.X);
			Class1162.smethod_16(@class.Value, 6 + i * 16 + 12, @struct.point_1.Y);
		}
		return @class;
	}

	internal Class204(Point[] vertices, ushort[] elements, Struct15[] calculationData, int[] defData, Struct16[] textRects, int width, int height, int xRef, int yRef, Point[] connectionPoints)
		: this(vertices, elements, calculationData, defData, textRects, width, height, xRef, yRef, connectionPoints, null)
	{
	}

	internal Class204(Point[] vertices, ushort[] elements, Struct15[] calculationData, int[] defData, Struct16[] textRects, int width, int height, int xRef, int yRef, Point[] connectionPoints, Enum17[] connectionDirections)
	{
		point_0 = vertices;
		ushort_0 = elements;
		struct15_0 = calculationData;
		base.DefData = defData;
		if (textRects == null)
		{
			textRects = Class203.struct16_0;
		}
		struct16_1 = textRects;
		base.Width = width;
		base.Height = height;
		if (connectionPoints != null)
		{
			point_1 = connectionPoints;
		}
		else
		{
			point_1 = Class203.point_2;
		}
		enum17_0 = connectionDirections;
	}

	internal static Class204 smethod_4(Enum18 type)
	{
		return type switch
		{
			Enum18.const_4 => Class203.class204_2, 
			Enum18.const_3 => Class203.class204_6, 
			Enum18.const_6 => Class203.class204_9, 
			Enum18.const_7 => Class203.class204_3, 
			Enum18.const_1 => Class203.class204_5, 
			Enum18.const_2 => Class203.class204_7, 
			Enum18.const_8 => Class203.class204_10, 
			Enum18.const_5 => Class203.class204_8, 
			Enum18.const_9 => Class203.class204_12, 
			Enum18.const_90 => class204_75, 
			Enum18.const_31 => Class203.class204_14, 
			Enum18.const_49 => Class203.class204_32, 
			Enum18.const_12 => Class203.class204_35, 
			Enum18.const_135 => class204_129, 
			Enum18.const_23 => Class203.class204_0, 
			Enum18.const_26 => class204_66, 
			Enum18.const_11 => Class203.class204_13, 
			Enum18.const_16 => class204_58, 
			Enum18.const_137 => class204_120, 
			Enum18.const_138 => class204_122, 
			Enum18.const_139 => class204_121, 
			Enum18.const_140 => class204_123, 
			Enum18.const_141 => class204_124, 
			Enum18.const_142 => class204_126, 
			Enum18.const_143 => class204_125, 
			Enum18.const_144 => class204_127, 
			Enum18.const_145 => class204_128, 
			Enum18.const_116 => class204_140, 
			Enum18.const_117 => class204_141, 
			Enum18.const_118 => class204_142, 
			Enum18.const_112 => class204_136, 
			Enum18.const_113 => class204_137, 
			Enum18.const_114 => class204_138, 
			Enum18.const_108 => class204_132, 
			Enum18.const_109 => class204_133, 
			Enum18.const_110 => class204_134, 
			Enum18.const_120 => class204_144, 
			Enum18.const_121 => class204_145, 
			Enum18.const_122 => class204_146, 
			Enum18.const_96 => class204_81, 
			Enum18.const_95 => class204_80, 
			Enum18.const_50 => Class203.class204_33, 
			Enum18.const_10 => Class203.class204_11, 
			Enum18.const_17 => class204_59, 
			Enum18.const_91 => class204_76, 
			Enum18.const_92 => class204_77, 
			Enum18.const_94 => class204_79, 
			Enum18.const_103 => class204_116, 
			Enum18.const_104 => class204_117, 
			Enum18.const_105 => class204_118, 
			Enum18.const_101 => class204_84, 
			Enum18.const_14 => Class203.class204_37, 
			Enum18.const_32 => Class203.class204_15, 
			Enum18.const_34 => Class203.class204_16, 
			Enum18.const_33 => Class203.class204_17, 
			Enum18.const_35 => Class203.class204_18, 
			Enum18.const_36 => Class203.class204_19, 
			Enum18.const_87 => class204_72, 
			Enum18.const_88 => class204_73, 
			Enum18.const_20 => class204_62, 
			Enum18.const_19 => class204_61, 
			Enum18.const_37 => Class203.class204_20, 
			Enum18.const_52 => class204_51, 
			Enum18.const_51 => class204_50, 
			Enum18.const_53 => class204_52, 
			Enum18.const_54 => class204_53, 
			Enum18.const_55 => class204_54, 
			Enum18.const_56 => class204_55, 
			Enum18.const_57 => class204_56, 
			Enum18.const_13 => Class203.class204_36, 
			Enum18.const_27 => class204_68, 
			Enum18.const_28 => class204_69, 
			Enum18.const_29 => class204_70, 
			Enum18.const_30 => class204_71, 
			Enum18.const_41 => Class203.class204_24, 
			Enum18.const_42 => Class203.class204_25, 
			Enum18.const_39 => Class203.class204_22, 
			Enum18.const_93 => class204_78, 
			Enum18.const_47 => Class203.class204_30, 
			Enum18.const_48 => Class203.class204_31, 
			Enum18.const_18 => class204_60, 
			Enum18.const_15 => class204_57, 
			Enum18.const_99 => class204_86, 
			Enum18.const_100 => class204_87, 
			Enum18.const_58 => Class203.class204_34, 
			Enum18.const_40 => Class203.class204_23, 
			Enum18.const_43 => Class203.class204_27, 
			Enum18.const_44 => Class203.class204_26, 
			Enum18.const_45 => Class203.class204_28, 
			Enum18.const_46 => Class203.class204_29, 
			Enum18.const_106 => class204_119, 
			Enum18.const_98 => class204_83, 
			Enum18.const_97 => class204_82, 
			Enum18.const_59 => class204_88, 
			Enum18.const_61 => class204_90, 
			Enum18.const_62 => class204_91, 
			Enum18.const_63 => class204_92, 
			Enum18.const_64 => class204_93, 
			Enum18.const_65 => class204_94, 
			Enum18.const_66 => class204_95, 
			Enum18.const_67 => class204_96, 
			Enum18.const_68 => class204_97, 
			Enum18.const_69 => class204_98, 
			Enum18.const_70 => class204_99, 
			Enum18.const_71 => class204_100, 
			Enum18.const_73 => class204_102, 
			Enum18.const_74 => class204_103, 
			Enum18.const_75 => class204_104, 
			Enum18.const_76 => class204_105, 
			Enum18.const_77 => class204_106, 
			Enum18.const_78 => class204_107, 
			Enum18.const_79 => class204_108, 
			Enum18.const_80 => class204_109, 
			Enum18.const_81 => class204_110, 
			Enum18.const_83 => class204_112, 
			Enum18.const_84 => class204_113, 
			Enum18.const_85 => class204_114, 
			Enum18.const_86 => class204_115, 
			Enum18.const_82 => class204_111, 
			Enum18.const_60 => class204_89, 
			Enum18.const_72 => class204_101, 
			Enum18.const_115 => class204_139, 
			Enum18.const_111 => class204_135, 
			Enum18.const_107 => class204_131, 
			Enum18.const_119 => class204_143, 
			Enum18.const_38 => Class203.class204_21, 
			Enum18.const_21 => class204_63, 
			Enum18.const_22 => class204_64, 
			Enum18.const_24 => class204_65, 
			Enum18.const_25 => class204_67, 
			Enum18.const_89 => class204_74, 
			Enum18.const_102 => class204_85, 
			Enum18.const_123 => Class203.class204_38, 
			Enum18.const_124 => Class203.class204_39, 
			Enum18.const_125 => Class203.class204_40, 
			Enum18.const_126 => Class203.class204_41, 
			Enum18.const_128 => Class203.class204_43, 
			Enum18.const_127 => Class203.class204_42, 
			Enum18.const_130 => Class203.class204_45, 
			Enum18.const_129 => Class203.class204_44, 
			Enum18.const_131 => Class203.class204_46, 
			Enum18.const_132 => Class203.class204_47, 
			Enum18.const_133 => Class203.class204_48, 
			Enum18.const_134 => Class203.class204_49, 
			_ => null, 
		};
	}

	internal float method_5(short index, int[] adjustValues, ref byte geometryRef)
	{
		if (struct15_0 == null)
		{
			throw new ApplicationException("Autoshape haven't calculation data");
		}
		ushort num = struct15_0[index].ushort_0;
		short[] array = new short[3]
		{
			struct15_0[index].short_0,
			struct15_0[index].short_1,
			struct15_0[index].short_2
		};
		double[] array2 = new double[3]
		{
			struct15_0[index].short_0,
			struct15_0[index].short_1,
			struct15_0[index].short_2
		};
		for (int i = 0; i < 3; i++)
		{
			if ((num & (8192 << i)) == 0)
			{
				continue;
			}
			if (((uint)array[i] & 0x400u) != 0)
			{
				array2[i] = method_5((short)(array[i] & 0xFF), adjustValues, ref geometryRef);
				continue;
			}
			switch (array[i])
			{
			case 320:
				array2[i] = 0.0;
				geometryRef |= 1;
				break;
			case 321:
				array2[i] = 0.0;
				geometryRef |= 4;
				break;
			case 322:
				array2[i] = base.Width;
				geometryRef |= 2;
				break;
			case 323:
				array2[i] = base.Height;
				geometryRef |= 8;
				break;
			default:
				array2[i] = 0.0;
				break;
			case 327:
			case 328:
			case 329:
			case 330:
			case 331:
			case 332:
			case 333:
			case 334:
			case 335:
			case 336:
				try
				{
					array2[i] = adjustValues[array[i] - 327];
				}
				catch (IndexOutOfRangeException innerException)
				{
					throw new IndexOutOfRangeException("Size of adjustValues array is not enough", innerException);
				}
				break;
			}
		}
		switch (num & 0xFF)
		{
		case 128:
			if (array2[2] == 0.0)
			{
				array2[0] = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1]);
				break;
			}
			if (array2[0] == 0.0)
			{
				array2[0] = array2[1];
			}
			array2[0] = Math.Sqrt(array2[2] * array2[2] - array2[0] * array2[0]);
			break;
		case 129:
			array2[2] *= 0.0017453292519943296;
			array2[0] = 10800.0 + Math.Cos(array2[2]) * (array2[0] - 10800.0) + Math.Sin(array2[2]) * (array2[1] - 10800.0);
			break;
		case 130:
			array2[2] *= 0.0017453292519943296;
			array2[0] = 10800.0 - Math.Sin(array2[2]) * (array2[0] - 10800.0) + Math.Cos(array2[2]) * (array2[1] - 10800.0);
			break;
		case 0:
			array2[0] += array2[1] - array2[2];
			break;
		case 1:
			if (array2[1] != 0.0)
			{
				array2[0] *= array2[1];
			}
			if (array2[2] != 0.0)
			{
				array2[0] /= array2[2];
			}
			break;
		case 2:
			array2[0] = (array2[0] + array2[1]) / 2.0;
			break;
		case 3:
			array2[0] = Math.Abs(array2[0]);
			break;
		case 4:
			if (array2[0] > array2[1])
			{
				array2[0] = array2[1];
			}
			break;
		case 5:
			if (array2[0] < array2[1])
			{
				array2[0] = array2[1];
			}
			break;
		case 6:
			if (array2[0] > 0.0)
			{
				array2[0] = array2[1];
			}
			else
			{
				array2[0] = array2[2];
			}
			break;
		case 7:
			array2[0] = Math.Sqrt(array2[0] * array2[0] + array2[1] * array2[1] + array2[2] * array2[2]);
			break;
		case 8:
			array2[0] = Class5963.smethod_1(Math.Atan2(array2[1], array2[0])) * 65536.0;
			break;
		case 9:
			array2[0] *= Math.Sin(Class5963.smethod_0(array2[1]) / 65536.0);
			break;
		case 10:
			array2[0] *= Math.Cos(Class5963.smethod_0(array2[1]) / 65536.0);
			break;
		case 11:
			array2[0] *= Math.Cos(Math.Atan2(array2[2], array2[1]));
			break;
		case 12:
			array2[0] *= Math.Sin(Math.Atan2(array2[2], array2[1]));
			break;
		case 13:
			array2[0] = Math.Sqrt(array2[0]);
			break;
		case 14:
			array2[0] += (array2[1] - array2[2]) * 65536.0;
			break;
		case 15:
			if (array2[1] != 0.0)
			{
				array2[0] /= array2[1];
				array2[0] = array2[2] * Math.Sqrt(1.0 - array2[0] * array2[0]);
			}
			break;
		case 16:
			array2[0] *= Math.Tan(array2[1]);
			break;
		}
		return (float)array2[0];
	}

	static Class204()
	{
		int[] array = new int[2];
		int_57 = array;
		class204_127 = new Class204(point_190, ushort_120, struct15_75, int_57, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);
		point_191 = new Point[13]
		{
			new Point(0, 0),
			new Point(int.MinValue, 0),
			new Point(-2147483647, -2147483646),
			new Point(-2147483647, -2147483645),
			new Point(-2147483647, -2147483644),
			new Point(-2147483643, -2147483642),
			new Point(-2147483641, -2147483642),
			new Point(-2147483640, -2147483642),
			new Point(-2147483639, -2147483638),
			new Point(-2147483639, -2147483637),
			new Point(-2147483639, -2147483636),
			new Point(-2147483635, 21600),
			new Point(21600, 21600)
		};
		ushort_121 = new ushort[2] { 8196, 32768 };
		struct15_76 = new Struct15[14]
		{
			new Struct15(8193, 327, 1, 2),
			new Struct15(8192, 327, 0, 0),
			new Struct15(8193, 328, 1, 4),
			new Struct15(8193, 328, 1, 2),
			new Struct15(8193, 328, 3, 4),
			new Struct15(24578, 1031, 327, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(24578, 327, 329, 0),
			new Struct15(24578, 1031, 329, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(24578, 328, 1035, 0),
			new Struct15(8194, 328, 21600, 0),
			new Struct15(8194, 1035, 21600, 0),
			new Struct15(8194, 329, 21600, 0)
		};
		array = new int[3];
		int_58 = array;
		class204_128 = new Class204(point_191, ushort_121, struct15_76, int_58, null, 21600, 21600, int.MinValue, int.MinValue, Class203.point_3);
		point_192 = new Point[19]
		{
			new Point(0, 3600),
			new Point(0, 1800),
			new Point(1800, 0),
			new Point(3600, 0),
			new Point(18000, 0),
			new Point(19800, 0),
			new Point(21600, 1800),
			new Point(21600, 3600),
			new Point(21600, 14400),
			new Point(21600, 16200),
			new Point(19800, 18000),
			new Point(18000, 18000),
			new Point(5400, 18000),
			new Point(int.MinValue, 21600),
			new Point(3600, 18000),
			new Point(1800, 18000),
			new Point(0, 16200),
			new Point(0, 14400),
			new Point(0, 3600)
		};
		ushort_122 = new ushort[10] { 8193, 1, 8193, 1, 8193, 3, 8193, 1, 24576, 32768 };
		struct15_77 = new Struct15[1]
		{
			new Struct15(8192, 327, 0, 0)
		};
		struct16_101 = new Struct16[1]
		{
			new Struct16(new Point(1400, 1400), new Point(20400, 16800))
		};
		class204_129 = new Class204(point_192, ushort_122, struct15_77, Class203.int_6, struct16_101, 21600, 21600, int.MinValue, int.MinValue, null);
		point_193 = new Point[6]
		{
			new Point(0, 0),
			new Point(21600, 16200),
			new Point(9600, 16200),
			new Point(4000, 14400),
			new Point(int.MinValue, 21600),
			new Point(9600, 16200)
		};
		ushort_123 = new ushort[4] { 41732, 2, 24576, 32768 };
		struct16_102 = new Struct16[1]
		{
			new Struct16(new Point(3200, 2400), new Point(18400, 13800))
		};
		class204_130 = new Class204(point_193, ushort_123, struct15_77, Class203.int_6, struct16_102, 21600, 21600, int.MinValue, int.MinValue, null);
		point_194 = new Point[7]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645)
		};
		ushort_124 = new ushort[6] { 4, 24576, 32768, 1, 43520, 32768 };
		struct15_78 = new Struct15[8]
		{
			new Struct15(8192, 327, 0, 0),
			new Struct15(8192, 328, 0, 0),
			new Struct15(8192, 329, 0, 0),
			new Struct15(8192, 330, 0, 0),
			new Struct15(8192, 331, 0, 0),
			new Struct15(8192, 332, 0, 0),
			new Struct15(8192, 333, 0, 0),
			new Struct15(8192, 334, 0, 0)
		};
		struct16_103 = new Struct16[1]
		{
			new Struct16(0, 0, 21600, 21600)
		};
		int_59 = new int[4] { -1800, 24300, -1800, 4050 };
		point_195 = new Point[5]
		{
			new Point(10800, 0),
			new Point(0, 10800),
			new Point(10800, 21600),
			new Point(21600, 10800),
			new Point(int.MinValue, -2147483647)
		};
		class204_131 = new Class204(point_194, ushort_124, struct15_78, int_59, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		int_60 = new int[4] { -8280, 24300, -1800, 4050 };
		class204_132 = new Class204(point_194, ushort_124, struct15_78, int_60, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		point_196 = new Point[8]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(-2147483644, -2147483643)
		};
		ushort_125 = new ushort[6] { 4, 24576, 32768, 2, 43520, 32768 };
		int_61 = new int[6] { -10080, 24300, -3600, 4050, -1800, 4050 };
		class204_133 = new Class204(point_196, ushort_125, struct15_78, int_61, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		point_197 = new Point[9]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(-2147483644, -2147483643),
			new Point(-2147483642, -2147483641)
		};
		ushort_126 = new ushort[6] { 4, 24576, 32768, 3, 43520, 32768 };
		int_62 = new int[8] { 23400, 24400, 25200, 21600, 25200, 4050, 23400, 4050 };
		class204_134 = new Class204(point_197, ushort_126, struct15_78, int_62, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_127 = new ushort[6] { 4, 24576, 32784, 1, 43520, 32768 };
		class204_135 = new Class204(point_194, ushort_127, struct15_78, int_59, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		point_198 = new Point[9]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(-2147483646, 0),
			new Point(-2147483646, 21600)
		};
		ushort_128 = new ushort[9] { 4, 24576, 32784, 1, 43520, 32768, 1, 43520, 32803 };
		class204_136 = new Class204(point_198, ushort_128, struct15_78, int_60, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		point_199 = new Point[10]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(-2147483644, -2147483643),
			new Point(-2147483644, 0),
			new Point(-2147483644, 21600)
		};
		ushort_129 = new ushort[9] { 4, 24576, 32784, 2, 43520, 32768, 1, 43520, 32803 };
		class204_137 = new Class204(point_199, ushort_129, struct15_78, int_61, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		point_200 = new Point[11]
		{
			new Point(0, 0),
			new Point(21600, 0),
			new Point(21600, 21600),
			new Point(0, 21600),
			new Point(0, 0),
			new Point(int.MinValue, -2147483647),
			new Point(-2147483646, -2147483645),
			new Point(-2147483644, -2147483643),
			new Point(-2147483642, -2147483641),
			new Point(-2147483642, 0),
			new Point(-2147483642, 21600)
		};
		ushort_130 = new ushort[9] { 4, 24576, 32784, 3, 43520, 32768, 1, 43520, 32803 };
		class204_138 = new Class204(point_200, ushort_130, struct15_78, int_62, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_131 = new ushort[6] { 4, 24576, 32784, 1, 43520, 32768 };
		class204_139 = new Class204(point_194, ushort_131, struct15_78, int_59, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		class204_140 = new Class204(point_194, ushort_131, struct15_78, int_60, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_132 = new ushort[6] { 4, 24576, 32784, 2, 43520, 32768 };
		class204_141 = new Class204(point_196, ushort_132, struct15_78, int_61, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_133 = new ushort[6] { 4, 24576, 32784, 3, 43520, 32768 };
		class204_142 = new Class204(point_197, ushort_133, struct15_78, int_62, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		class204_143 = class204_131;
		ushort_134 = new ushort[9] { 4, 24576, 32768, 1, 43520, 32768, 1, 43520, 32803 };
		class204_144 = new Class204(point_198, ushort_134, struct15_78, int_60, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_135 = new ushort[9] { 4, 24576, 32768, 2, 43520, 32768, 1, 43520, 32803 };
		class204_145 = new Class204(point_199, ushort_135, struct15_78, int_61, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
		ushort_136 = new ushort[9] { 4, 24576, 32768, 3, 43520, 32768, 1, 43520, 32803 };
		class204_146 = new Class204(point_200, ushort_136, struct15_78, int_62, struct16_103, 21600, 21600, int.MinValue, int.MinValue, point_195);
	}
}
