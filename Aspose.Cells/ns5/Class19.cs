using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class19 : Class18
{
	private static readonly Point[] point_0 = new Point[17]
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

	private static readonly ushort[] ushort_0 = new ushort[10] { 8193, 1, 8193, 1, 24576, 32788, 8193, 1, 8193, 32768 };

	private static readonly Point[] point_1 = new Point[3]
	{
		new Point(21600, 0),
		new Point(0, 10800),
		new Point(21600, 21600)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[5]
	{
		new Struct14(8193, 327, 1, 2),
		new Struct14(8192, 327, 0, 0),
		new Struct14(32768, 21600, 0, 327),
		new Struct14(8192, 1024, 0, 0),
		new Struct14(32768, 21600, 0, 1024)
	};

	private int[] int_0 = new int[1] { 1800 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(6350, -2147483645), new Point(21600, -2147483644))
	};

	internal Class19(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		Class14 @class = new Class14(Enum6.const_27, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
