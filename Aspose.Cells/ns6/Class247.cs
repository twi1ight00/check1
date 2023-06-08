using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class247 : Class160
{
	internal Class247(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
		switch (class913_0.int_3)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class913_0.method_25().Width, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class913_0.method_25().Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
	}

	internal override void vmethod_3()
	{
		long num = 0L;
		long num2 = 0L;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToInt64(class913_0.class901_0.arrayList_0[0]);
				num2 = Convert.ToInt64(class913_0.class901_0.arrayList_0[1]);
			}
			else
			{
				num = -20833L;
				num2 = 62500L;
			}
			float num3 = class913_0.Width / 2f + class913_0.Width * Math.Abs((float)num / 100000f);
			float num4 = class913_0.Height / 2f + class913_0.Height * Math.Abs((float)num2 / 100000f);
			if (num3 <= class913_0.Width && num4 <= class913_0.Height)
			{
				if (!class913_0.Fill.method_0())
				{
					GraphicsPath graphicsPath = new GraphicsPath();
					graphicsPath.AddRectangle(new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height));
					Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
					interface42_0.imethod_32(brush_, class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
				}
				if (!class913_0.Line.method_0())
				{
					Pen pen_ = Struct72.smethod_0(class913_0.Line);
					interface42_0.imethod_10(pen_, class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
				}
				vmethod_4();
				return;
			}
		}
		else
		{
			num = -20833L;
			num2 = 62500L;
		}
		Class878 @class = new Class878(new Class875[2]
		{
			new Class875("adj1", num),
			new Class875("adj2", num2)
		}, new Class879[32]
		{
			new Class879("dxPos", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false),
			new Class879("dyPos", Enum89.const_0, -27273042329603L, 27273042316902L, 100000L, bool_1: false),
			new Class879("xPos", Enum89.const_1, -27273042329606L, -27273042329612L, 0L, bool_1: false),
			new Class879("yPos", Enum89.const_1, -27273042329607L, -27273042329613L, 0L, bool_1: false),
			new Class879("sdx", Enum89.const_0, -27273042329612L, -27273042329603L, 1L, bool_1: false),
			new Class879("sdy", Enum89.const_0, -27273042329613L, -27273042329602L, 1L, bool_1: false),
			new Class879("pang", Enum89.const_5, -27273042329616L, -27273042329617L, 0L, bool_1: false),
			new Class879("stAng", Enum89.const_1, -27273042329618L, 660000L, 0L, bool_1: false),
			new Class879("enAng", Enum89.const_1, -27273042329618L, 0L, 660000L, bool_1: false),
			new Class879("dx1", Enum89.const_7, -27273042329640L, -27273042329619L, 0L, bool_1: false),
			new Class879("dy1", Enum89.const_13, -27273042329641L, -27273042329619L, 0L, bool_1: false),
			new Class879("x1", Enum89.const_1, -27273042329606L, -27273042329621L, 0L, bool_1: false),
			new Class879("y1", Enum89.const_1, -27273042329607L, -27273042329622L, 0L, bool_1: false),
			new Class879("dx2", Enum89.const_7, -27273042329640L, -27273042329620L, 0L, bool_1: false),
			new Class879("dy2", Enum89.const_13, -27273042329641L, -27273042329620L, 0L, bool_1: false),
			new Class879("x2", Enum89.const_1, -27273042329606L, -27273042329625L, 0L, bool_1: false),
			new Class879("y2", Enum89.const_1, -27273042329607L, -27273042329626L, 0L, bool_1: false),
			new Class879("stAng1", Enum89.const_5, -27273042329621L, -27273042329622L, 0L, bool_1: false),
			new Class879("enAng1", Enum89.const_5, -27273042329625L, -27273042329626L, 0L, bool_1: false),
			new Class879("swAng1", Enum89.const_1, -27273042329630L, 0L, -27273042329629L, bool_1: false),
			new Class879("swAng2", Enum89.const_1, -27273042329631L, 21600000L, 0L, bool_1: false),
			new Class879("swAng", Enum89.const_3, -27273042329631L, -27273042329631L, -27273042329632L, bool_1: false),
			new Class879("idx", Enum89.const_7, -27273042329640L, 2700000L, 0L, bool_1: false),
			new Class879("idy", Enum89.const_13, -27273042329641L, 2700000L, 0L, bool_1: false),
			new Class879("il", Enum89.const_1, -27273042329606L, 0L, -27273042329634L, bool_1: false),
			new Class879("ir", Enum89.const_1, -27273042329606L, -27273042329634L, 0L, bool_1: false),
			new Class879("it", Enum89.const_1, -27273042329607L, 0L, -27273042329635L, bool_1: false),
			new Class879("ib", Enum89.const_1, -27273042329607L, -27273042329635L, 0L, bool_1: false),
			new Class879("wd2", Enum89.const_0, -27273042329602L, 1L, 2L, bool_1: true),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true)
		}, new Class876[8]
		{
			new Class876(-27273042329606L, -27273042329609L, -27273042329642L),
			new Class876(-27273042329636L, -27273042329638L, -27273042329642L),
			new Class876(-27273042329636L, -27273042329639L, -27273042329643L),
			new Class876(-27273042329606L, -27273042329611L, -27273042329643L),
			new Class876(-27273042329637L, -27273042329639L, -27273042329643L),
			new Class876(-27273042329610L, -27273042329607L, 0L),
			new Class876(-27273042329637L, -27273042329638L, -27273042329642L),
			new Class876(-27273042329614L, -27273042329615L, -27273042329618L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, 27273042316902L, -2147483647L, 2147483647L, -27273042329614L, -27273042329615L)
		}, new Class881[1]
		{
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_0
			}, new long[8] { -27273042329614L, -27273042329615L, -27273042329623L, -27273042329624L, -27273042329640L, -27273042329641L, -27273042329629L, -27273042329633L }, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329636L, -27273042329638L), new Class874(-27273042329637L, -27273042329639L));
		@class.method_0(Enum93.const_1);
		float x = float_3;
		float y = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_2 = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		int num5 = array.Length;
		if (num5 == 0)
		{
			return;
		}
		for (int i = 0; i < num5; i++)
		{
			if (!class913_0.Fill.method_0())
			{
				Brush brush_2 = Struct72.smethod_21(class913_0.Fill, array[i]);
				interface42_0.imethod_33(brush_2, array[i]);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_2, array[i]);
			}
		}
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = new RectangleF(class913_0.method_8().X + class913_0.method_8().Width * 0.17f, class913_0.method_8().Y + class913_0.method_8().Height * 0.21f, class913_0.method_8().Width * 0.65f, class913_0.method_8().Height * 0.6f);
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class913_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class913_0.TextFrame.TopMargin;
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
