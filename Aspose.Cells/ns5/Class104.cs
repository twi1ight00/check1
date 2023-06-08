using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns4;

namespace ns5;

internal class Class104 : Class18
{
	private static readonly Point[] point_0 = new Point[5]
	{
		new Point(0, 0),
		new Point(21600, 21600),
		new Point(int.MinValue, -2147483647),
		new Point(-2147483646, -2147483645),
		new Point(-2147483644, -2147483643)
	};

	private static readonly ushort[] ushort_0 = new ushort[4] { 46340, 1, 24576, 32768 };

	private static readonly Point[] point_1 = new Point[9]
	{
		new Point(10800, 0),
		new Point(3160, 3160),
		new Point(0, 10800),
		new Point(3160, 18440),
		new Point(10800, 21600),
		new Point(18440, 18440),
		new Point(21600, 10800),
		new Point(18440, 3160),
		new Point(-2147483644, -2147483643)
	};

	private static readonly Struct14[] struct14_0 = new Struct14[15]
	{
		new Struct14(16384, 10800, 1030, 0),
		new Struct14(16384, 10800, 1031, 0),
		new Struct14(16384, 10800, 1032, 0),
		new Struct14(16384, 10800, 1033, 0),
		new Struct14(8192, 327, 0, 0),
		new Struct14(8192, 328, 0, 0),
		new Struct14(16393, 10800, 1034, 0),
		new Struct14(16394, 10800, 1034, 0),
		new Struct14(16393, 10800, 1035, 0),
		new Struct14(16394, 10800, 1035, 0),
		new Struct14(8206, 1036, 0, 11),
		new Struct14(8206, 1036, 11, 0),
		new Struct14(24584, 1038, 1037, 0),
		new Struct14(8192, 327, 0, 10800),
		new Struct14(8192, 328, 0, 10800)
	};

	private int[] int_0 = new int[2] { 1350, 25920 };

	private static readonly Struct15[] struct15_0 = new Struct15[1]
	{
		new Struct15(new Point(3200, 3200), new Point(18400, 18400))
	};

	internal Class104(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		int num = (int)class898_0.X;
		int num2 = (int)class898_0.Y;
		int num3 = (int)class898_0.Width;
		int num4 = (int)class898_0.Height;
		RectangleF rectangleF = new RectangleF(num, num2, num3, num4);
		interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		int num5 = 0;
		int num6 = 0;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			switch (class898_0.class885_0.arrayList_0.Count)
			{
			default:
				num5 = 1350;
				num6 = 25920;
				break;
			case 1:
				if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
				{
					num5 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
					num6 = 25920;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328)
				{
					num5 = 1350;
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
					num6 = 25920;
				}
				else if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 328 && ((Class882)class898_0.class885_0.arrayList_0[1]).method_0() == 329)
				{
					num5 = 1350;
					num6 = Convert.ToInt32(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
				}
				break;
			}
			int_0 = new int[2] { num5, num6 };
		}
		float num7 = Math.Abs(rectangleF.Width * ((float)num5 / 21600f));
		float num8 = Math.Abs(rectangleF.Height * ((float)num6 / 21600f));
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (num5 > 0 && num6 > 0 && num7 <= rectangleF.Width && num8 <= rectangleF.Height)
		{
			if (!class898_0.Line.method_0())
			{
				interface42_0.imethod_9(pen_, rectangleF);
			}
			if (!class898_0.Fill.method_0())
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(rectangleF);
				Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
				interface42_0.imethod_31(brush_, rectangleF);
			}
			vmethod_4();
		}
		else
		{
			Class15 class15_ = new Class15(point_0, ushort_0, struct14_0, int_0, struct15_0, 21600, 21600, int.MinValue, int.MinValue, point_1);
			if (class898_0.Fill.method_5())
			{
				class898_0.Fill.method_3(Color.White);
			}
			Class14 @class = new Class14(Enum6.const_105, num, num2, num3, num4, class898_0.Line.ForeColor, class898_0.Line.Weight, class898_0.Fill.method_2(), class15_);
			@class.Rotation = class898_0.Rotation;
			@class.Draw(interface42_0, class898_0, rectangleF);
			vmethod_4();
		}
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = new RectangleF(class898_0.method_7().X + class898_0.method_7().Width / 4f, class898_0.method_7().Y + class898_0.method_7().Height / 4f, class898_0.method_7().Width, class898_0.method_7().Height);
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
