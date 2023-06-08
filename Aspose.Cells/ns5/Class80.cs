using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class80 : Class18
{
	private static readonly Point[] point_0 = new Point[11]
	{
		new Point(0, 21600),
		new Point(0, 12160),
		new Point(12427, -2147483647),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, 0),
		new Point(21600, 6079),
		new Point(int.MinValue, 12158),
		new Point(int.MinValue, -2147483646),
		new Point(12427, -2147483646),
		new Point(-2147483644, 12160),
		new Point(-2147483644, 21600)
	};

	private static readonly ushort[] ushort_0 = new ushort[7] { 1, 43009, 6, 42753, 1, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(int.MinValue, 0),
		new Point(int.MinValue, 12158),
		new Point(-2147483645, 21600),
		new Point(21600, 6079)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[9]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(32768, 12158, 0, 328),
		new Struct14(32768, 6079, 0, 328),
		new Struct14(8193, 1027, 2, 1),
		new Struct14(32768, 21600, 0, 1030),
		new Struct14(24576, 1032, 1031, 6079),
		new Struct14(32768, 6079, 0, 328),
		new Struct14(32768, 21600, 0, 327)
	};

	private int[] int_0 = new int[2] { 15100, 2900 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(12427, -2147483647, -2147483643, -2147483646)
	};

	private static readonly Enum5[] enum5_0 = new Enum5[4]
	{
		Enum5.const_2,
		Enum5.const_4,
		Enum5.const_4,
		Enum5.const_1
	};

	internal Class80(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
				num5 = 15100;
				num6 = 2100;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 2100;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 15100;
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
					num6 = 2100;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 15100;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			}
			int_0 = new int[2] { num5, num6 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1, enum5_0);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 @class = new Class14(Enum6.const_39, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
