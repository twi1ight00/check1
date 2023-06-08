using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class193 : Class160
{
	internal Class193(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
		int int_ = class913_0.int_3;
		if (int_ != 1 && int_ == 4)
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class913_0.method_25().Width, 0f);
			interface42_0.imethod_58(matrix_);
		}
	}

	internal override void vmethod_3()
	{
		long num = 0L;
		num = ((class913_0.class901_0 == null) ? 50000 : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 50000 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0])));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj", num)
		}, new Class879[38]
		{
			new Class879("a", Enum89.const_11, 0L, 27273042316901L, 87500L, bool_1: false),
			new Class879("g0", Enum89.const_0, -27273042329604L, -27273042329612L, 100000L, bool_1: false),
			new Class879("g0w", Enum89.const_0, -27273042329613L, -27273042329602L, -27273042329604L, bool_1: false),
			new Class879("g1", Enum89.const_1, -27273042329604L, 0L, -27273042329613L, bool_1: false),
			new Class879("g2", Enum89.const_0, -27273042329613L, -27273042329613L, -27273042329615L, bool_1: false),
			new Class879("g3", Enum89.const_0, -27273042329604L, -27273042329604L, -27273042329615L, bool_1: false),
			new Class879("g4", Enum89.const_0, -27273042329617L, 2L, 1L, bool_1: false),
			new Class879("g5", Enum89.const_1, -27273042329618L, 0L, -27273042329616L, bool_1: false),
			new Class879("g6", Enum89.const_1, -27273042329619L, 0L, -27273042329613L, bool_1: false),
			new Class879("g6w", Enum89.const_0, -27273042329620L, -27273042329602L, -27273042329604L, bool_1: false),
			new Class879("g7", Enum89.const_0, -27273042329619L, 1L, 2L, bool_1: false),
			new Class879("g8", Enum89.const_1, -27273042329622L, 0L, -27273042329613L, bool_1: false),
			new Class879("dy1", Enum89.const_0, -27273042329623L, -27273042329646L, -27273042329604L, bool_1: false),
			new Class879("g10h", Enum89.const_1, -27273042329607L, 0L, -27273042329624L, bool_1: false),
			new Class879("g11h", Enum89.const_1, -27273042329607L, -27273042329624L, 0L, bool_1: false),
			new Class879("g12", Enum89.const_0, -27273042329613L, 9598L, 32768L, bool_1: false),
			new Class879("g12w", Enum89.const_0, -27273042329627L, -27273042329602L, -27273042329604L, bool_1: false),
			new Class879("g13", Enum89.const_1, -27273042329604L, 0L, -27273042329627L, bool_1: false),
			new Class879("q1", Enum89.const_0, -27273042329604L, -27273042329604L, 1L, bool_1: false),
			new Class879("q2", Enum89.const_0, -27273042329629L, -27273042329629L, 1L, bool_1: false),
			new Class879("q3", Enum89.const_1, -27273042329630L, 0L, -27273042329631L, bool_1: false),
			new Class879("q4", Enum89.const_14, -27273042329632L, 0L, 0L, bool_1: false),
			new Class879("dy4", Enum89.const_0, -27273042329633L, -27273042329646L, -27273042329604L, bool_1: false),
			new Class879("g15h", Enum89.const_1, -27273042329607L, 0L, -27273042329634L, bool_1: false),
			new Class879("g16h", Enum89.const_1, -27273042329607L, -27273042329634L, 0L, bool_1: false),
			new Class879("g17w", Enum89.const_1, -27273042329621L, 0L, -27273042329614L, bool_1: false),
			new Class879("g18w", Enum89.const_0, -27273042329637L, 1L, 2L, bool_1: false),
			new Class879("dx2p", Enum89.const_1, -27273042329614L, -27273042329638L, -27273042329602L, bool_1: false),
			new Class879("dx2", Enum89.const_0, -27273042329639L, -1L, 1L, bool_1: false),
			new Class879("dy2", Enum89.const_0, -27273042329646L, -1L, 1L, bool_1: false),
			new Class879("stAng1", Enum89.const_5, -27273042329640L, -27273042329641L, 0L, bool_1: false),
			new Class879("enAngp1", Enum89.const_5, -27273042329640L, -27273042329646L, 0L, bool_1: false),
			new Class879("enAng1", Enum89.const_1, -27273042329643L, 0L, 21600000L, bool_1: false),
			new Class879("swAng1", Enum89.const_1, -27273042329644L, 0L, -27273042329642L, bool_1: false),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true)
		}, new Class876[4]
		{
			new Class876(-27273042329610L, -27273042329609L, -27273042329647L),
			new Class876(-27273042329608L, -27273042329607L, -27273042329648L),
			new Class876(-27273042329610L, -27273042329611L, -27273042329649L),
			new Class876(-27273042329614L, -27273042329607L, 0L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, 0L, 87500L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329614L, -27273042329607L)
		}, new Class881[1]
		{
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_0
			}, new long[10] { -27273042329610L, -27273042329611L, -27273042329602L, -27273042329646L, -27273042329649L, -27273042329648L, -27273042329638L, -27273042329624L, -27273042329642L, -27273042329645L }, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329628L, -27273042329635L), new Class874(-27273042329614L, -27273042329636L));
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
		int num2 = array.Length;
		if (num2 == 0)
		{
			return;
		}
		for (int i = 0; i < num2; i++)
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
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
