using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class62 : Class18
{
	private static readonly Point[] point_0 = new Point[101]
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

	private static readonly ushort[] ushort_0 = new ushort[7] { 2, 8208, 1, 8208, 1, 24576, 32772 };

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(10800, 2180),
		new Point(3090, 10800),
		new Point(10800, 21600),
		new Point(18490, 10800)
	};

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(5080, 2540), new Point(16520, 13550))
	};

	internal Class62(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		Class15 class15_ = new Class15(point_0, ushort_0, null, null, struct15_0, 21615, 21602, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_19, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
