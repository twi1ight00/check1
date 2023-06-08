using System;
using System.Collections;
using System.Drawing;
using ns19;
using ns4;

namespace ns5;

internal class Class48 : Class18
{
	private static readonly Point[] point_0 = new Point[13]
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

	private static readonly ushort[] ushort_0 = new ushort[2] { 8196, 32768 };

	private static readonly Struct14[] struct14_0 = new Struct14[14]
	{
		new Struct14(8193, 327, 1, 2),
		new Struct14(8192, 327, 0, 0),
		new Struct14(8193, 328, 1, 4),
		new Struct14(8193, 328, 1, 2),
		new Struct14(8193, 328, 3, 4),
		new Struct14(24578, 1031, 327, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(24578, 327, 329, 0),
		new Struct14(24578, 1031, 329, 0),
		new Struct14(8192, 329, 0, 0),
		new Struct14(24578, 328, 1035, 0),
		new Struct14(8194, 328, 21600, 0),
		new Struct14(8194, 1035, 21600, 0),
		new Struct14(8194, 329, 21600, 0)
	};

	private static readonly Point[] point_1 = new Point[0];

	private int[] int_0 = new int[3];

	internal Class48(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		if (arrayList_.Count > 0)
		{
			foreach (Class882 item in arrayList_)
			{
				if (item.method_0() == 327)
				{
					num5 = Convert.ToInt32(item.Value);
				}
				if (item.method_0() == 328)
				{
					num6 = Convert.ToInt32(item.Value);
				}
				if (item.method_0() == 329)
				{
					num7 = Convert.ToInt32(item.Value);
				}
			}
			int_0 = new int[3] { num5, num6, num7 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, null, 21600, 21600, int.MinValue, int.MinValue, point_1);
		Class14 class2 = new Class14(Enum6.const_145, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		class2.Rotation = class898_0.Rotation;
		class2.method_14(class898_0.method_20());
		class2.method_13(class898_0.method_18());
		class2.Draw(interface42_0, class898_0, rectangleF_);
	}
}
