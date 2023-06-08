using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class60 : Class18
{
	private static readonly Point[] point_0 = new Point[17]
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

	private static readonly ushort[] ushort_0 = new ushort[18]
	{
		42753, 1, 43009, 1, 42753, 1, 43009, 1, 24576, 33044,
		42753, 1, 43009, 32768, 42753, 1, 43009, 32768
	};

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[16]
	{
		new Struct14(24576, 320, 327, 0),
		new Struct14(24576, 321, 327, 0),
		new Struct14(40960, 323, 0, 327),
		new Struct14(40960, 322, 0, 327),
		new Struct14(8322, 327, 0, 450),
		new Struct14(8192, 1028, 0, 10800),
		new Struct14(32768, 0, 0, 327),
		new Struct14(40960, 1030, 0, 1029),
		new Struct14(40960, 320, 0, 1031),
		new Struct14(40960, 321, 0, 1031),
		new Struct14(24576, 322, 1031, 0),
		new Struct14(24576, 323, 1031, 0),
		new Struct14(40960, 320, 0, 1029),
		new Struct14(40960, 321, 0, 1029),
		new Struct14(24576, 322, 1029, 0),
		new Struct14(24576, 323, 1029, 0)
	};

	private int[] int_0 = new int[1] { 3600 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(-2147483640, -2147483639), new Point(-2147483638, -2147483637))
	};

	internal Class60(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
			int_0 = new int[1] { 1800 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_24, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
