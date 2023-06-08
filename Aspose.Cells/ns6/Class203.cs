using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class203 : Class160
{
	internal Class203(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		long num = 0L;
		num = ((class913_0.class901_0 == null) ? 25000 : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 25000 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0])));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj", num)
		}, new Class879[50]
		{
			new Class879("a", Enum89.const_11, 12500L, 27273042316901L, 46875L, bool_1: false),
			new Class879("g0", Enum89.const_1, 50000L, 0L, -27273042329612L, bool_1: false),
			new Class879("g1", Enum89.const_0, -27273042329613L, 30274L, 32768L, bool_1: false),
			new Class879("g2", Enum89.const_0, -27273042329613L, 12540L, 32768L, bool_1: false),
			new Class879("g3", Enum89.const_1, -27273042329614L, 50000L, 0L, bool_1: false),
			new Class879("g4", Enum89.const_1, -27273042329615L, 50000L, 0L, bool_1: false),
			new Class879("g5", Enum89.const_1, 50000L, 0L, -27273042329614L, bool_1: false),
			new Class879("g6", Enum89.const_1, 50000L, 0L, -27273042329615L, bool_1: false),
			new Class879("g7", Enum89.const_0, -27273042329613L, 23170L, 32768L, bool_1: false),
			new Class879("g8", Enum89.const_1, 50000L, -27273042329620L, 0L, bool_1: false),
			new Class879("g9", Enum89.const_1, 50000L, 0L, -27273042329620L, bool_1: false),
			new Class879("g10", Enum89.const_0, -27273042329618L, 3L, 4L, bool_1: false),
			new Class879("g11", Enum89.const_0, -27273042329619L, 3L, 4L, bool_1: false),
			new Class879("g12", Enum89.const_1, -27273042329623L, 3662L, 0L, bool_1: false),
			new Class879("g13", Enum89.const_1, -27273042329624L, 3662L, 0L, bool_1: false),
			new Class879("g14", Enum89.const_1, -27273042329624L, 12500L, 0L, bool_1: false),
			new Class879("g15", Enum89.const_1, 100000L, 0L, -27273042329623L, bool_1: false),
			new Class879("g16", Enum89.const_1, 100000L, 0L, -27273042329625L, bool_1: false),
			new Class879("g17", Enum89.const_1, 100000L, 0L, -27273042329626L, bool_1: false),
			new Class879("g18", Enum89.const_1, 100000L, 0L, -27273042329627L, bool_1: false),
			new Class879("ox1", Enum89.const_0, -27273042329602L, 18436L, 21600L, bool_1: false),
			new Class879("oy1", Enum89.const_0, -27273042329603L, 3163L, 21600L, bool_1: false),
			new Class879("ox2", Enum89.const_0, -27273042329602L, 3163L, 21600L, bool_1: false),
			new Class879("oy2", Enum89.const_0, -27273042329603L, 18436L, 21600L, bool_1: false),
			new Class879("x8", Enum89.const_0, -27273042329602L, -27273042329621L, 100000L, bool_1: false),
			new Class879("x9", Enum89.const_0, -27273042329602L, -27273042329622L, 100000L, bool_1: false),
			new Class879("x10", Enum89.const_0, -27273042329602L, -27273042329623L, 100000L, bool_1: false),
			new Class879("x12", Enum89.const_0, -27273042329602L, -27273042329625L, 100000L, bool_1: false),
			new Class879("x13", Enum89.const_0, -27273042329602L, -27273042329626L, 100000L, bool_1: false),
			new Class879("x14", Enum89.const_0, -27273042329602L, -27273042329627L, 100000L, bool_1: false),
			new Class879("x15", Enum89.const_0, -27273042329602L, -27273042329628L, 100000L, bool_1: false),
			new Class879("x16", Enum89.const_0, -27273042329602L, -27273042329629L, 100000L, bool_1: false),
			new Class879("x17", Enum89.const_0, -27273042329602L, -27273042329630L, 100000L, bool_1: false),
			new Class879("x18", Enum89.const_0, -27273042329602L, -27273042329631L, 100000L, bool_1: false),
			new Class879("x19", Enum89.const_0, -27273042329602L, -27273042329612L, 100000L, bool_1: false),
			new Class879("wR", Enum89.const_0, -27273042329602L, -27273042329613L, 100000L, bool_1: false),
			new Class879("hR", Enum89.const_0, -27273042329603L, -27273042329613L, 100000L, bool_1: false),
			new Class879("y8", Enum89.const_0, -27273042329603L, -27273042329621L, 100000L, bool_1: false),
			new Class879("y9", Enum89.const_0, -27273042329603L, -27273042329622L, 100000L, bool_1: false),
			new Class879("y10", Enum89.const_0, -27273042329603L, -27273042329623L, 100000L, bool_1: false),
			new Class879("y12", Enum89.const_0, -27273042329603L, -27273042329625L, 100000L, bool_1: false),
			new Class879("y13", Enum89.const_0, -27273042329603L, -27273042329626L, 100000L, bool_1: false),
			new Class879("y14", Enum89.const_0, -27273042329603L, -27273042329627L, 100000L, bool_1: false),
			new Class879("y15", Enum89.const_0, -27273042329603L, -27273042329628L, 100000L, bool_1: false),
			new Class879("y16", Enum89.const_0, -27273042329603L, -27273042329629L, 100000L, bool_1: false),
			new Class879("y17", Enum89.const_0, -27273042329603L, -27273042329630L, 100000L, bool_1: false),
			new Class879("y18", Enum89.const_0, -27273042329603L, -27273042329631L, 100000L, bool_1: false),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true)
		}, new Class876[4]
		{
			new Class876(-27273042329606L, -27273042329609L, -27273042329659L),
			new Class876(-27273042329608L, -27273042329607L, -27273042329660L),
			new Class876(-27273042329606L, -27273042329611L, -27273042329661L),
			new Class876(-27273042329610L, -27273042329607L, 0L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, 12500L, 46875L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329646L, -27273042329607L)
		}, new Class881[1]
		{
			new Class881(new Enum91[35]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_0,
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_0
			}, new long[54]
			{
				-27273042329610L, -27273042329607L, -27273042329642L, -27273042329658L, -27273042329642L, -27273042329654L, -27273042329632L, -27273042329633L, -27273042329643L, -27273042329653L,
				-27273042329644L, -27273042329652L, -27273042329606L, -27273042329609L, -27273042329645L, -27273042329651L, -27273042329641L, -27273042329651L, -27273042329634L, -27273042329633L,
				-27273042329640L, -27273042329652L, -27273042329639L, -27273042329653L, -27273042329608L, -27273042329607L, -27273042329638L, -27273042329654L, -27273042329638L, -27273042329658L,
				-27273042329634L, -27273042329635L, -27273042329639L, -27273042329657L, -27273042329640L, -27273042329656L, -27273042329606L, -27273042329611L, -27273042329641L, -27273042329655L,
				-27273042329645L, -27273042329655L, -27273042329632L, -27273042329635L, -27273042329644L, -27273042329656L, -27273042329643L, -27273042329657L, -27273042329646L, -27273042329607L,
				-27273042329647L, -27273042329648L, -27273042329660L, 21600000L
			}, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329637L, -27273042329650L), new Class874(-27273042329636L, -27273042329649L));
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
