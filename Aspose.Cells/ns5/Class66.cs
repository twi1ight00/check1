using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class66 : Class18
{
	private static readonly Point[] point_0 = new Point[13]
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

	private static readonly ushort[] ushort_0 = new ushort[3] { 8196, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(21600, 0),
		new Point(0, 10800),
		new Point(21600, 21600),
		new Point(int.MinValue, 10800)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[11]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(32768, 21600, 0, 327),
		new Struct14(8193, 1025, 1, 2),
		new Struct14(24576, 1026, 327, 0),
		new Struct14(8193, 327, 1794, 10000),
		new Struct14(32768, 21600, 0, 1028),
		new Struct14(8193, 327, 4000, 18900),
		new Struct14(32897, 0, 10800, 1030),
		new Struct14(32898, 0, 10800, 1030),
		new Struct14(24576, 1031, 1031, 0),
		new Struct14(32768, 21600, 0, 1032)
	};

	private int[] int_0 = new int[1] { 10800 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(-2147483639, -2147483640), new Point(int.MinValue, -2147483638))
	};

	private static readonly Enum5[] enum5_0 = new Enum5[4]
	{
		Enum5.const_2,
		Enum5.const_3,
		Enum5.const_4,
		Enum5.const_1
	};

	internal Class66(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
			int_0 = new int[1] { 10800 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1, enum5_0);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_22, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
