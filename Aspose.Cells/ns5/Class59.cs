using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class59 : Class18
{
	private static readonly Point[] point_0 = new Point[29]
	{
		new Point(-2147483644, 0),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483642),
		new Point(0, 10800),
		new Point(int.MinValue, -2147483641),
		new Point(int.MinValue, -2147483646),
		new Point(-2147483644, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, -2147483641),
		new Point(21600, 10800),
		new Point(-2147483645, -2147483642),
		new Point(-2147483645, -2147483647),
		new Point(-2147483640, 0),
		new Point(-2147483644, 0),
		new Point(-2147483644, 0),
		new Point(int.MinValue, -2147483647),
		new Point(int.MinValue, -2147483642),
		new Point(0, 10800),
		new Point(int.MinValue, -2147483641),
		new Point(int.MinValue, -2147483646),
		new Point(-2147483644, 21600),
		new Point(-2147483640, 21600),
		new Point(-2147483645, -2147483646),
		new Point(-2147483645, -2147483641),
		new Point(21600, 10800),
		new Point(-2147483645, -2147483642),
		new Point(-2147483645, -2147483647),
		new Point(-2147483640, 0)
	};

	private static readonly ushort[] ushort_0 = new ushort[30]
	{
		42753, 1, 43009, 42753, 1, 43009, 1, 42753, 1, 43009,
		42753, 1, 43009, 1, 24576, 32784, 42753, 1, 43009, 42753,
		1, 43009, 32768, 42753, 1, 43009, 42753, 1, 43009, 32768
	};

	private static readonly Point[] point_1 = new Point[4]
	{
		new Point(10800, 0),
		new Point(0, 10800),
		new Point(10800, 21600),
		new Point(21600, 10800)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[15]
	{
		new Struct14(24576, 320, 327, 0),
		new Struct14(24576, 321, 327, 0),
		new Struct14(40960, 323, 0, 327),
		new Struct14(40960, 322, 0, 327),
		new Struct14(8193, 1024, 2, 1),
		new Struct14(8193, 327, 2, 1),
		new Struct14(32768, 10800, 0, 327),
		new Struct14(32768, 21600, 0, 1030),
		new Struct14(40960, 322, 0, 1029),
		new Struct14(8193, 327, 1, 3),
		new Struct14(24576, 1033, 327, 0),
		new Struct14(24576, 320, 1034, 0),
		new Struct14(24576, 321, 1033, 0),
		new Struct14(40960, 322, 0, 1034),
		new Struct14(40960, 323, 0, 1033)
	};

	private int[] int_0 = new int[1] { 1800 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(-2147483637, -2147483636), new Point(-2147483635, -2147483634))
	};

	internal Class59(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
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
		Class14 @class = new Class14(Enum6.const_25, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
		@class.Rotation = class898_0.Rotation;
		@class.Draw(interface42_0, class898_0, rectangleF_);
		vmethod_4();
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = class898_0.method_7();
		float num = 0f;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? 1736f : Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value));
		float num2 = num * ((width > height) ? height : width) / 21600f;
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - (num2 + class898_0.Line.Weight * 16f) / 2f, 0f - class898_0.Line.Weight * 16f / 2f);
		}
		float num3 = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num3;
			}
		}
		else
		{
			rectangleF_.X += num3;
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
