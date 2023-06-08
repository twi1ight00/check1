using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class53 : Class18
{
	private static readonly Point[] point_0 = new Point[10]
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

	private static readonly ushort[] ushort_0 = new ushort[4] { 41988, 42244, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(10800, -2147483633),
		new Point(-2147483636, -2147483635),
		new Point(10800, -2147483632),
		new Point(-2147483634, -2147483635)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[17]
	{
		new Struct14(16394, 10800, 327, 0),
		new Struct14(16393, 10800, 327, 0),
		new Struct14(8192, 1024, 10800, 0),
		new Struct14(8192, 1025, 10800, 0),
		new Struct14(32768, 21600, 0, 1026),
		new Struct14(32768, 10800, 0, 328),
		new Struct14(16384, 10800, 328, 0),
		new Struct14(24586, 1029, 327, 0),
		new Struct14(24585, 1029, 327, 0),
		new Struct14(24586, 1035, 327, 0),
		new Struct14(24585, 1035, 327, 0),
		new Struct14(16386, 10800, 328, 0),
		new Struct14(8192, 1033, 10800, 0),
		new Struct14(8192, 1034, 10800, 0),
		new Struct14(32768, 21600, 0, 1036),
		new Struct14(8198, 1024, 21600, 0),
		new Struct14(57350, 1024, 1030, 1029)
	};

	private int[] int_0 = new int[2] { 11796480, 5400 };

	internal Class53(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
				num5 = 11796480;
				num6 = 5400;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 5400;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 11796480;
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
					num6 = 5400;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 11796480;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			}
			int_0 = new int[2] { num5, num6 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, null, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_18, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
