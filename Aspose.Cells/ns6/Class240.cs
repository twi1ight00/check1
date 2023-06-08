using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class240 : Class160
{
	internal Class240(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		}, new Class879[48]
		{
			new Class879("dxPos", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false),
			new Class879("dyPos", Enum89.const_0, -27273042329603L, 27273042316902L, 100000L, bool_1: false),
			new Class879("xPos", Enum89.const_1, -27273042329606L, -27273042329612L, 0L, bool_1: false),
			new Class879("yPos", Enum89.const_1, -27273042329607L, -27273042329613L, 0L, bool_1: false),
			new Class879("ht", Enum89.const_6, -27273042329655L, -27273042329612L, -27273042329613L, bool_1: false),
			new Class879("wt", Enum89.const_12, -27273042329656L, -27273042329612L, -27273042329613L, bool_1: false),
			new Class879("g2", Enum89.const_6, -27273042329656L, -27273042329616L, -27273042329617L, bool_1: false),
			new Class879("g3", Enum89.const_12, -27273042329655L, -27273042329616L, -27273042329617L, bool_1: false),
			new Class879("g4", Enum89.const_1, -27273042329606L, -27273042329618L, 0L, bool_1: false),
			new Class879("g5", Enum89.const_1, -27273042329607L, -27273042329619L, 0L, bool_1: false),
			new Class879("g6", Enum89.const_1, -27273042329620L, 0L, -27273042329614L, bool_1: false),
			new Class879("g7", Enum89.const_1, -27273042329621L, 0L, -27273042329615L, bool_1: false),
			new Class879("g8", Enum89.const_10, -27273042329622L, -27273042329623L, 0L, bool_1: false),
			new Class879("g9", Enum89.const_0, -27273042329604L, 6600L, 21600L, bool_1: false),
			new Class879("g10", Enum89.const_1, -27273042329624L, 0L, -27273042329625L, bool_1: false),
			new Class879("g11", Enum89.const_0, -27273042329626L, 1L, 3L, bool_1: false),
			new Class879("g12", Enum89.const_0, -27273042329604L, 1800L, 21600L, bool_1: false),
			new Class879("g13", Enum89.const_1, -27273042329627L, -27273042329628L, 0L, bool_1: false),
			new Class879("g14", Enum89.const_0, -27273042329629L, -27273042329622L, -27273042329624L, bool_1: false),
			new Class879("g15", Enum89.const_0, -27273042329629L, -27273042329623L, -27273042329624L, bool_1: false),
			new Class879("g16", Enum89.const_1, -27273042329630L, -27273042329614L, 0L, bool_1: false),
			new Class879("g17", Enum89.const_1, -27273042329631L, -27273042329615L, 0L, bool_1: false),
			new Class879("g18", Enum89.const_0, -27273042329604L, 4800L, 21600L, bool_1: false),
			new Class879("g19", Enum89.const_0, -27273042329627L, 2L, 1L, bool_1: false),
			new Class879("g20", Enum89.const_1, -27273042329634L, -27273042329635L, 0L, bool_1: false),
			new Class879("g21", Enum89.const_0, -27273042329636L, -27273042329622L, -27273042329624L, bool_1: false),
			new Class879("g22", Enum89.const_0, -27273042329636L, -27273042329623L, -27273042329624L, bool_1: false),
			new Class879("g23", Enum89.const_1, -27273042329637L, -27273042329614L, 0L, bool_1: false),
			new Class879("g24", Enum89.const_1, -27273042329638L, -27273042329615L, 0L, bool_1: false),
			new Class879("g25", Enum89.const_0, -27273042329604L, 1200L, 21600L, bool_1: false),
			new Class879("g26", Enum89.const_0, -27273042329604L, 600L, 21600L, bool_1: false),
			new Class879("x23", Enum89.const_1, -27273042329614L, -27273042329642L, 0L, bool_1: false),
			new Class879("x24", Enum89.const_1, -27273042329632L, -27273042329641L, 0L, bool_1: false),
			new Class879("x25", Enum89.const_1, -27273042329639L, -27273042329628L, 0L, bool_1: false),
			new Class879("il", Enum89.const_0, -27273042329602L, 2977L, 21600L, bool_1: false),
			new Class879("it", Enum89.const_0, -27273042329603L, 3262L, 21600L, bool_1: false),
			new Class879("ir", Enum89.const_0, -27273042329602L, 17087L, 21600L, bool_1: false),
			new Class879("ib", Enum89.const_0, -27273042329603L, 17337L, 21600L, bool_1: false),
			new Class879("g27", Enum89.const_0, -27273042329602L, 67L, 21600L, bool_1: false),
			new Class879("g28", Enum89.const_0, -27273042329603L, 21577L, 21600L, bool_1: false),
			new Class879("g29", Enum89.const_0, -27273042329602L, 21582L, 21600L, bool_1: false),
			new Class879("g30", Enum89.const_0, -27273042329603L, 1235L, 21600L, bool_1: false),
			new Class879("pang", Enum89.const_5, -27273042329612L, -27273042329613L, 0L, bool_1: false),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("wd2", Enum89.const_0, -27273042329602L, 1L, 2L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true)
		}, new Class876[5]
		{
			new Class876(-27273042329650L, -27273042329607L, -27273042329657L),
			new Class876(-27273042329606L, -27273042329651L, -27273042329658L),
			new Class876(-27273042329652L, -27273042329607L, 0L),
			new Class876(-27273042329606L, -27273042329653L, -27273042329659L),
			new Class876(-27273042329614L, -27273042329615L, -27273042329654L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, 27273042316902L, -2147483647L, 2147483647L, -27273042329614L, -27273042329615L)
		}, new Class881[5]
		{
			new Class881(new Enum91[13]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_0
			}, new long[46]
			{
				3900L, 14370L, 6753L, 9190L, -11429249L, 7426832L, 5333L, 7267L, -8646143L, 5396714L,
				4365L, 5945L, -8748475L, 5983381L, 4857L, 6595L, -7859164L, 7034504L, 5333L, 7273L,
				-4722533L, 6541615L, 6775L, 9220L, -2776035L, 7816140L, 5785L, 7867L, 37501L, 6842000L,
				6752L, 9215L, 1347096L, 6910353L, 7720L, 10543L, 3974558L, 4542661L, 4360L, 5918L,
				-16496525L, 8804134L, 4345L, 5945L, -14809710L, 9151131L
			}, 43200L, 43200L, Enum92.const_1, bool_2: true, bool_3: true),
			new Class881(new Enum91[3]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_0
			}, new long[6] { -27273042329643L, -27273042329615L, -27273042329642L, -27273042329642L, 0L, 21600000L }, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true),
			new Class881(new Enum91[3]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_0
			}, new long[6] { -27273042329644L, -27273042329633L, -27273042329641L, -27273042329641L, 0L, 21600000L }, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true),
			new Class881(new Enum91[3]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_0
			}, new long[6] { -27273042329645L, -27273042329640L, -27273042329628L, -27273042329628L, 0L, 21600000L }, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true),
			new Class881(new Enum91[22]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_1,
				Enum91.const_3
			}, new long[66]
			{
				4693L, 26177L, 4345L, 5945L, 5204520L, 1585770L, 6928L, 34899L, 4360L, 5918L,
				4416628L, 686848L, 16478L, 39090L, 6752L, 9215L, 8257449L, 844866L, 28827L, 34751L,
				6752L, 9215L, 387196L, 959901L, 34129L, 22954L, 5785L, 7867L, -4217541L, 4255042L,
				41798L, 15354L, 5333L, 7273L, 1819082L, 1665090L, 38324L, 5426L, 4857L, 6595L,
				-824660L, 891534L, 29078L, 3952L, 4857L, 6595L, -8950887L, 1091722L, 22141L, 4720L,
				4365L, 5945L, -9809656L, 1061181L, 14000L, 5192L, 6753L, 9190L, -4002417L, 739161L,
				4127L, 15789L, 6753L, 9190L, 9459261L, 711490L
			}, 43200L, 43200L, Enum92.const_0, bool_2: true, bool_3: false)
		}, new Class874(-27273042329646L, -27273042329647L), new Class874(-27273042329648L, -27273042329649L));
		@class.method_0(Enum93.const_1);
		float x = float_3;
		float y = float_4;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		int num3 = array.Length;
		if (num3 == 0)
		{
			return;
		}
		for (int i = 0; i < num3 - 1; i++)
		{
			if (!class913_0.Fill.method_0())
			{
				Brush brush_ = Struct72.smethod_21(class913_0.Fill, array[i]);
				interface42_0.imethod_33(brush_, array[i]);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = new RectangleF(class913_0.method_8().X + class913_0.method_8().Width * 0.16f, class913_0.method_8().Y + class913_0.method_8().Height * 0.23f, class913_0.method_8().Width * 0.6f, class913_0.method_8().Height * 0.6f);
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
