using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class77 : Class18
{
	private static readonly Point[] point_0 = new Point[26]
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

	private static readonly ushort[] ushort_0 = new ushort[27]
	{
		2, 24576, 32768, 2, 24576, 32768, 2, 24576, 32768, 2,
		24576, 32768, 2, 24576, 32768, 2, 24576, 32768, 2, 24576,
		32768, 2, 24576, 32768, 41730, 24576, 32768
	};

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[54]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(32768, 21600, 0, 327),
		new Struct14(8192, 327, 0, 2700),
		new Struct14(8193, 1026, 5080, 7425),
		new Struct14(8192, 1027, 2540, 0),
		new Struct14(32768, 10125, 0, 327),
		new Struct14(8193, 1029, 2120, 7425),
		new Struct14(8192, 1030, 210, 0),
		new Struct14(16384, 10800, 1031, 0),
		new Struct14(32768, 10800, 0, 1031),
		new Struct14(129, 0, 10800, 450),
		new Struct14(130, 0, 10800, 450),
		new Struct14(24705, 1028, 1032, 450),
		new Struct14(24706, 1028, 1032, 450),
		new Struct14(24705, 1028, 1033, 450),
		new Struct14(24706, 1028, 1033, 450),
		new Struct14(129, 0, 10800, 900),
		new Struct14(130, 0, 10800, 900),
		new Struct14(24705, 1028, 1032, 900),
		new Struct14(24706, 1028, 1032, 900),
		new Struct14(24705, 1028, 1033, 900),
		new Struct14(24706, 1028, 1033, 900),
		new Struct14(129, 0, 10800, 1350),
		new Struct14(130, 0, 10800, 1350),
		new Struct14(24705, 1028, 1032, 1350),
		new Struct14(24706, 1028, 1032, 1350),
		new Struct14(24705, 1028, 1033, 1350),
		new Struct14(24706, 1028, 1033, 1350),
		new Struct14(129, 0, 10800, 1800),
		new Struct14(130, 0, 10800, 1800),
		new Struct14(24705, 1028, 1032, 1800),
		new Struct14(24706, 1028, 1032, 1800),
		new Struct14(24705, 1028, 1033, 1800),
		new Struct14(24706, 1028, 1033, 1800),
		new Struct14(129, 0, 10800, 2250),
		new Struct14(130, 0, 10800, 2250),
		new Struct14(24705, 1028, 1032, 2250),
		new Struct14(24706, 1028, 1032, 2250),
		new Struct14(24705, 1028, 1033, 2250),
		new Struct14(24706, 1028, 1033, 2250),
		new Struct14(129, 0, 10800, 2700),
		new Struct14(130, 0, 10800, 2700),
		new Struct14(24705, 1028, 1032, 2700),
		new Struct14(24706, 1028, 1032, 2700),
		new Struct14(24705, 1028, 1033, 2700),
		new Struct14(24706, 1028, 1033, 2700),
		new Struct14(129, 0, 10800, 3150),
		new Struct14(130, 0, 10800, 3150),
		new Struct14(24705, 1028, 1032, 3150),
		new Struct14(24706, 1028, 1032, 3150),
		new Struct14(24705, 1028, 1033, 3150),
		new Struct14(24706, 1028, 1033, 3150),
		new Struct14(8321, 327, 10800, 450),
		new Struct14(8321, 327, 10800, 2250)
	};

	private int[] int_0 = new int[1] { 5400 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(-2147483596, -2147483596), new Point(-2147483595, -2147483595))
	};

	internal Class77(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
			int_0 = new int[1] { num5 };
		}
		else
		{
			int_0 = new int[1] { 5400 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_21, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
