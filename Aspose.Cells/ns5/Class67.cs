using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class67 : Class18
{
	private static readonly Point[] point_0 = new Point[10]
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

	private static readonly ushort[] ushort_0 = new ushort[6] { 41730, 41988, 24576, 41988, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[8]
	{
		new Point(10800, 0),
		new Point(3160, 3160),
		new Point(0, 10800),
		new Point(3160, 18440),
		new Point(10800, 21600),
		new Point(18440, 18440),
		new Point(21600, 10800),
		new Point(18440, 3160)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[17]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(32768, 21600, 0, 327),
		new Struct14(32768, 10800, 0, 327),
		new Struct14(8193, 327, 1, 2),
		new Struct14(41088, 1027, 0, 1026),
		new Struct14(32768, 10800, 0, 1027),
		new Struct14(16384, 10800, 1027, 0),
		new Struct14(32768, 10800, 0, 1028),
		new Struct14(16384, 10800, 1028, 0),
		new Struct14(24705, 1029, 1031, 450),
		new Struct14(24706, 1029, 1031, 450),
		new Struct14(24705, 1029, 1032, 450),
		new Struct14(24706, 1029, 1032, 450),
		new Struct14(24705, 1030, 1032, 450),
		new Struct14(24706, 1030, 1032, 450),
		new Struct14(24705, 1030, 1031, 450),
		new Struct14(24706, 1030, 1031, 450)
	};

	private int[] int_0 = new int[1] { 2700 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(3200, 3200, 18400, 18400)
	};

	internal Class67(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
			int_0 = new int[1] { 2700 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_17, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.method_14(class898_0.method_20());
		@class.method_13(class898_0.method_18());
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
