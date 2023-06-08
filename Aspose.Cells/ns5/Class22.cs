using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class22 : Class18
{
	private static readonly Point[] point_0 = new Point[11]
	{
		new Point(-2147483645, -2147483645),
		new Point(-2147483628, -2147483628),
		new Point(-2147483629, -2147483630),
		new Point(-2147483631, -2147483632),
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(-2147483639, -2147483640),
		new Point(-2147483637, -2147483638),
		new Point(-2147483624, -2147483625),
		new Point(-2147483617, -2147483618),
		new Point(-2147483619, -2147483620)
	};

	private static readonly ushort[] ushort_0 = new ushort[5] { 41988, 42244, 3, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[6]
	{
		new Point(-2147483598, -2147483599),
		new Point(-2147483606, -2147483605),
		new Point(-2147483596, -2147483597),
		new Point(-2147483624, -2147483625),
		new Point(-2147483617, -2147483618),
		new Point(-2147483619, -2147483620)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[57]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(8192, 329, 0, 0),
		new Struct14(32768, 10800, 0, 329),
		new Struct14(16393, 10800, 327, 0),
		new Struct14(16394, 10800, 327, 0),
		new Struct14(16393, 10800, 328, 0),
		new Struct14(16394, 10800, 328, 0),
		new Struct14(8192, 1028, 10800, 0),
		new Struct14(8192, 1029, 10800, 0),
		new Struct14(8192, 1030, 10800, 0),
		new Struct14(8192, 1031, 10800, 0),
		new Struct14(24585, 1026, 327, 0),
		new Struct14(24586, 1026, 327, 0),
		new Struct14(24585, 1026, 328, 0),
		new Struct14(24586, 1026, 328, 0),
		new Struct14(8192, 1036, 10800, 0),
		new Struct14(8192, 1037, 10800, 0),
		new Struct14(8192, 1038, 10800, 0),
		new Struct14(8192, 1039, 10800, 0),
		new Struct14(32768, 21600, 0, 1027),
		new Struct14(16393, 13500, 328, 0),
		new Struct14(16394, 13500, 328, 0),
		new Struct14(8192, 1045, 10800, 0),
		new Struct14(8192, 1046, 10800, 0),
		new Struct14(8192, 329, 0, 2700),
		new Struct14(24585, 1049, 328, 0),
		new Struct14(24586, 1049, 328, 0),
		new Struct14(8192, 1050, 10800, 0),
		new Struct14(8192, 1051, 10800, 0),
		new Struct14(24576, 1058, 1060, 0),
		new Struct14(24576, 1059, 1061, 0),
		new Struct14(24585, 1063, 328, 0),
		new Struct14(24586, 1063, 328, 0),
		new Struct14(8192, 1056, 10800, 0),
		new Struct14(8192, 1057, 10800, 0),
		new Struct14(24585, 1065, 1062, 0),
		new Struct14(24586, 1065, 1062, 0),
		new Struct14(8206, 328, 90, 0),
		new Struct14(32768, 10800, 0, 1064),
		new Struct14(8193, 1027, 1, 2),
		new Struct14(8192, 1064, 2700, 0),
		new Struct14(24578, 1041, 1033, 0),
		new Struct14(24578, 1040, 1032, 0),
		new Struct14(24578, 1024, 1080, 0),
		new Struct14(16393, 10800, 1068, 0),
		new Struct14(16394, 10800, 1068, 0),
		new Struct14(24585, 1026, 1068, 0),
		new Struct14(24586, 1026, 1068, 0),
		new Struct14(8192, 1069, 10800, 0),
		new Struct14(8192, 1070, 10800, 0),
		new Struct14(8192, 1071, 10800, 0),
		new Struct14(8192, 1072, 10800, 0),
		new Struct14(40960, 1025, 0, 1024),
		new Struct14(8206, 0, 360, 0),
		new Struct14(40966, 1077, 0, 1078),
		new Struct14(24576, 1025, 1079, 0)
	};

	private int[] int_0 = new int[3] { 11796480, 0, 5500 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(3200, 3200, 18400, 18400)
	};

	internal Class22(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
				num5 = 11796480;
				num6 = 0;
				num7 = 5500;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 0;
					num7 = 5500;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 11796480;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num7 = 5500;
				}
				else
				{
					num5 = 11796480;
					num6 = 0;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			case 2:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
					num7 = 5500;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 0;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 11796480;
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
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_58, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
