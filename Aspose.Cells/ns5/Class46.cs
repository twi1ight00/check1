using System;
using System.Collections;
using System.Drawing;
using ns19;
using ns4;

namespace ns5;

internal class Class46 : Class18
{
	private static readonly Point[] point_0 = new Point[7]
	{
		new Point(0, 0),
		new Point(int.MinValue, 0),
		new Point(-2147483647, 5400),
		new Point(-2147483647, 10800),
		new Point(-2147483647, 16200),
		new Point(-2147483646, 21600),
		new Point(21600, 21600)
	};

	private static readonly ushort[] ushort_0 = new ushort[2] { 8194, 32768 };

	private static readonly Struct14[] struct14_0 = new Struct14[4]
	{
		new Struct14(8193, 327, 1, 2),
		new Struct14(8192, 327, 0, 0),
		new Struct14(8193, 1027, 1, 2),
		new Struct14(8192, 327, 21600, 0)
	};

	private static readonly Point[] point_1 = new Point[0];

	private int[] int_0 = new int[1];

	internal Class46(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		int num5 = 0;
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		num5 = ((arrayList_.Count > 0) ? ((((Class882)arrayList_[0]).method_0() == 327) ? Convert.ToInt32(((Class882)arrayList_[0]).Value) : 0) : 0);
		int_0 = new int[1] { num5 };
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, null, 21600, 21600, int.MinValue, int.MinValue, point_1);
		Class14 @class = new Class14(Enum6.const_143, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.method_14(class898_0.method_20());
		@class.method_13(class898_0.method_18());
		@class.Draw(interface42_0, class898_0, rectangleF_);
	}
}
