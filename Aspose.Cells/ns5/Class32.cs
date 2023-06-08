using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class32 : Class18
{
	private static readonly Point[] point_0 = new Point[7]
	{
		new Point(0, 0),
		new Point(21600, 0),
		new Point(21600, 21600),
		new Point(0, 21600),
		new Point(0, 0),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645)
	};

	private static readonly ushort[] ushort_0 = new ushort[6] { 4, 24576, 32784, 1, 43520, 32768 };

	private static readonly Point[] point_1 = new Point[5]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800),
		new Point(int.MinValue, -2147483647)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[8]
	{
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(8192, 329, 0, 0),
		new Struct14(8192, 330, 0, 0),
		new Struct14(8192, 331, 0, 0),
		new Struct14(8192, 332, 0, 0),
		new Struct14(8192, 333, 0, 0),
		new Struct14(8192, 334, 0, 0)
	};

	private int[] int_0 = new int[4] { -8280, 24300, -1800, 4050 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(0, 0, 21600, 21600)
	};

	internal Class32(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		int num5 = -8280;
		int num6 = 24300;
		int num7 = -1800;
		int num8 = 4050;
		if (class898_0.class885_0.arrayList_0.Count > 0)
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
				if (item.method_0() == 330)
				{
					num8 = Convert.ToInt32(item.Value);
				}
			}
			int_0 = new int[4] { num5, num6, num7, num8 };
		}
		Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
		if (class898_0.Fill.method_5())
		{
			class898_0.Fill.method_3(Color.White);
		}
		Class14 class2 = new Class14(Enum6.const_116, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		class2.Rotation = class898_0.Rotation;
		class2.Draw(interface42_0, class898_0, rectangleF_);
		base.vmethod_4();
	}
}
