using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class51 : Class18
{
	private static readonly Point[] point_0 = new Point[10]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(10800, 10800),
		new Point(int.MinValue, -2147483647),
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645)
	};

	private static readonly ushort[] ushort_0 = new ushort[6] { 42244, 2, 24576, 32788, 42244, 32768 };

	private static readonly Point[] point_1 = new Point[3]
	{
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(10800, 10800)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[8]
	{
		new Struct14(16384, 10800, 1028, 0),
		new Struct14(16384, 10800, 1029, 0),
		new Struct14(16384, 10800, 1030, 0),
		new Struct14(16384, 10800, 1031, 0),
		new Struct14(16394, 10800, 327, 0),
		new Struct14(16393, 10800, 327, 0),
		new Struct14(16394, 10800, 328, 0),
		new Struct14(16393, 10800, 328, 0)
	};

	private int[] int_0 = new int[2] { 17694720, 0 };

	internal Class51(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		switch (arrayList_.Count)
		{
		default:
			num5 = 17694720;
			num6 = 0;
			break;
		case 1:
			if (((Class882)arrayList_[0]).method_0() == 327)
			{
				num5 = Convert.ToInt32(((Class882)arrayList_[0]).Value);
				num6 = 0;
			}
			else if (((Class882)arrayList_[0]).method_0() == 328)
			{
				num5 = 17694720;
				num6 = Convert.ToInt32(((Class882)arrayList_[0]).Value);
			}
			break;
		case 2:
			if (((Class882)arrayList_[0]).method_0() == 327 && ((Class882)arrayList_[1]).method_0() == 328)
			{
				num5 = Convert.ToInt32(((Class882)arrayList_[0]).Value);
				num6 = Convert.ToInt32(((Class882)arrayList_[1]).Value);
			}
			else if (((Class882)arrayList_[0]).method_0() == 327 && ((Class882)arrayList_[1]).method_0() == 329)
			{
				num5 = Convert.ToInt32(((Class882)arrayList_[0]).Value);
				num6 = 0;
			}
			else if (((Class882)arrayList_[0]).method_0() == 328 && ((Class882)arrayList_[1]).method_0() == 329)
			{
				num5 = 17694720;
				num6 = Convert.ToInt32(((Class882)arrayList_[0]).Value);
			}
			break;
		}
		int_0 = new int[2] { num5, num6 };
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, null, 21600, 21600, int.MinValue, int.MinValue, point_1);
		Class14 @class = new Class14(Enum6.const_23, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
