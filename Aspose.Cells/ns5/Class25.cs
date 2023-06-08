using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class25 : Class18
{
	private static readonly Point[] point_0 = new Point[22]
	{
		new Point(0, -21600),
		new Point(-2147483643, 21600),
		new Point(0, 0),
		new Point(-2147483639, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483642, -21600),
		new Point(-2147483634, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483642, 0),
		new Point(0, 0),
		new Point(0, -21600),
		new Point(-2147483643, 21600),
		new Point(-2147483633, -2147483636),
		new Point(-2147483637, -2147483646),
		new Point(-2147483631, -2147483646),
		new Point(-2147483629, 0),
		new Point(-2147483630, -2147483646),
		new Point(-2147483632, -2147483646),
		new Point(-2147483642, -21600),
		new Point(-2147483634, 21600),
		new Point(-2147483632, -2147483646),
		new Point(-2147483633, -2147483636)
	};

	private static readonly ushort[] ushort_0 = new ushort[11]
	{
		41732, 1, 42244, 1, 24576, 32770, 41732, 4, 42244, 24576,
		32768
	};

	private static readonly Point[] point_1 = new Point[5]
	{
		new Point(-2147483629, 0),
		new Point(-2147483631, -2147483646),
		new Point(-2147483626, 0),
		new Point(-2147483633, 21600),
		new Point(-2147483630, -2147483646)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[23]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(8192, 329, 0, 0),
		new Struct14(32768, 21600, 0, 328),
		new Struct14(8192, 329, 0, 0),
		new Struct14(24576, 327, 1027, 0),
		new Struct14(57344, 328, 328, 1031),
		new Struct14(8192, 327, 21600, 0),
		new Struct14(24576, 1033, 1030, 0),
		new Struct14(8193, 1029, 1, 2),
		new Struct14(40975, 1028, 21600, 1033),
		new Struct14(24576, 1034, 1033, 0),
		new Struct14(24591, 1030, 1029, 21600),
		new Struct14(32768, 21600, 0, 1036),
		new Struct14(24576, 1029, 1030, 0),
		new Struct14(8193, 1038, 1, 2),
		new Struct14(24576, 1035, 1030, 0),
		new Struct14(40960, 1035, 0, 1027),
		new Struct14(24576, 1040, 1027, 0),
		new Struct14(24576, 1039, 1033, 0),
		new Struct14(8193, 327, 2, 7),
		new Struct14(40960, 328, 0, 1044),
		new Struct14(8193, 1030, 1, 2)
	};

	private int[] int_0 = new int[3] { 13000, 19400, 7200 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(-2147483628, 2900, -2147483627, 18700)
	};

	internal Class25(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
				num5 = 13000;
				num6 = 19400;
				num7 = 7200;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 19400;
					num7 = 7200;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 13000;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num7 = 7200;
				}
				else
				{
					num5 = 13000;
					num6 = 19400;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			case 2:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 328)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
					num7 = 7200;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 19400;
					num7 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[1]).Value);
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 13000;
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
		Class14 @class = new Class14(Enum6.const_45, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
