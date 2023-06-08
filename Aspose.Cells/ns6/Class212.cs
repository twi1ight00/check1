using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class212 : Class160
{
	internal Class212(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		long num = 0L;
		long num2 = 0L;
		long num3 = 0L;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToInt64(class913_0.class901_0.arrayList_0[0]);
				num2 = Convert.ToInt64(class913_0.class901_0.arrayList_0[1]);
				num3 = Convert.ToInt64(class913_0.class901_0.arrayList_0[2]);
			}
			else
			{
				num = 25000L;
				num2 = 50000L;
				num3 = 25000L;
			}
		}
		else
		{
			num = 25000L;
			num2 = 50000L;
			num3 = 25000L;
		}
		Class878 @class = new Class878(new Class875[3]
		{
			new Class875("adj1", num),
			new Class875("adj2", num2),
			new Class875("adj3", num3)
		}, new Class879[45]
		{
			new Class879("maxAdj2", Enum89.const_0, 50000L, -27273042329603L, -27273042329604L, bool_1: false),
			new Class879("a2", Enum89.const_11, 0L, 27273042316902L, -27273042329612L, bool_1: false),
			new Class879("a1", Enum89.const_11, 0L, 27273042316901L, -27273042329613L, bool_1: false),
			new Class879("th", Enum89.const_0, -27273042329604L, -27273042329614L, 100000L, bool_1: false),
			new Class879("aw", Enum89.const_0, -27273042329604L, -27273042329613L, 100000L, bool_1: false),
			new Class879("q1", Enum89.const_2, -27273042329615L, -27273042329616L, 4L, bool_1: false),
			new Class879("hR", Enum89.const_1, -27273042329652L, 0L, -27273042329617L, bool_1: false),
			new Class879("q7", Enum89.const_0, -27273042329618L, 2L, 1L, bool_1: false),
			new Class879("q8", Enum89.const_0, -27273042329619L, -27273042329619L, 1L, bool_1: false),
			new Class879("q9", Enum89.const_0, -27273042329615L, -27273042329615L, 1L, bool_1: false),
			new Class879("q10", Enum89.const_1, -27273042329620L, 0L, -27273042329621L, bool_1: false),
			new Class879("q11", Enum89.const_14, -27273042329622L, 0L, 0L, bool_1: false),
			new Class879("idx", Enum89.const_0, -27273042329623L, -27273042329602L, -27273042329619L, bool_1: false),
			new Class879("maxAdj3", Enum89.const_0, 100000L, -27273042329624L, -27273042329604L, bool_1: false),
			new Class879("a3", Enum89.const_11, 0L, 27273042316903L, -27273042329625L, bool_1: false),
			new Class879("ah", Enum89.const_0, -27273042329604L, -27273042329626L, 100000L, bool_1: false),
			new Class879("y3", Enum89.const_1, -27273042329618L, -27273042329615L, 0L, bool_1: false),
			new Class879("q2", Enum89.const_0, -27273042329602L, -27273042329602L, 1L, bool_1: false),
			new Class879("q3", Enum89.const_0, -27273042329627L, -27273042329627L, 1L, bool_1: false),
			new Class879("q4", Enum89.const_1, -27273042329629L, 0L, -27273042329630L, bool_1: false),
			new Class879("q5", Enum89.const_14, -27273042329631L, 0L, 0L, bool_1: false),
			new Class879("dy", Enum89.const_0, -27273042329632L, -27273042329618L, -27273042329602L, bool_1: false),
			new Class879("y5", Enum89.const_1, -27273042329618L, -27273042329633L, 0L, bool_1: false),
			new Class879("y7", Enum89.const_1, -27273042329628L, -27273042329633L, 0L, bool_1: false),
			new Class879("q6", Enum89.const_1, -27273042329616L, 0L, -27273042329615L, bool_1: false),
			new Class879("dh", Enum89.const_0, -27273042329636L, 1L, 2L, bool_1: false),
			new Class879("y4", Enum89.const_1, -27273042329634L, 0L, -27273042329637L, bool_1: false),
			new Class879("y8", Enum89.const_1, -27273042329635L, -27273042329637L, 0L, bool_1: false),
			new Class879("aw2", Enum89.const_0, -27273042329616L, 1L, 2L, bool_1: false),
			new Class879("y6", Enum89.const_1, -27273042329611L, 0L, -27273042329640L, bool_1: false),
			new Class879("x1", Enum89.const_1, -27273042329608L, -27273042329627L, 0L, bool_1: false),
			new Class879("swAng", Enum89.const_5, -27273042329627L, -27273042329633L, 0L, bool_1: false),
			new Class879("mswAng", Enum89.const_1, 0L, 0L, -27273042329643L, bool_1: false),
			new Class879("ix", Enum89.const_1, -27273042329608L, -27273042329624L, 0L, bool_1: false),
			new Class879("iy", Enum89.const_2, -27273042329618L, -27273042329628L, 2L, bool_1: false),
			new Class879("q12", Enum89.const_0, -27273042329615L, 1L, 2L, bool_1: false),
			new Class879("dang2", Enum89.const_5, -27273042329624L, -27273042329647L, 0L, bool_1: false),
			new Class879("swAng2", Enum89.const_1, -27273042329648L, 0L, -27273042329643L, bool_1: false),
			new Class879("swAng3", Enum89.const_1, -27273042329643L, -27273042329648L, 0L, bool_1: false),
			new Class879("stAng3", Enum89.const_1, 0L, 0L, -27273042329648L, bool_1: false),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("cd3", Enum89.const_0, -27273042329601L, 1L, 3L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true)
		}, new Class876[5]
		{
			new Class876(-27273042329608L, -27273042329647L, -27273042329653L),
			new Class876(-27273042329642L, -27273042329638L, -27273042329653L),
			new Class876(-27273042329608L, -27273042329641L, -27273042329654L),
			new Class876(-27273042329642L, -27273042329639L, -27273042329655L),
			new Class876(-27273042329610L, -27273042329646L, 0L)
		}, new Class873[3]
		{
			new Class873(bool_1: false, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316901L, 0L, -27273042329613L, -27273042329642L, -27273042329634L),
			new Class873(bool_1: false, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316902L, 0L, -27273042329612L, -27273042329610L, -27273042329638L),
			new Class873(bool_1: false, 27273042316903L, 0L, -27273042329625L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329642L, -27273042329611L)
		}, new Class881[3]
		{
			new Class881(new Enum91[7]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_0
			}, new long[16]
			{
				-27273042329608L, -27273042329641L, -27273042329642L, -27273042329638L, -27273042329642L, -27273042329634L, -27273042329602L, -27273042329618L, -27273042329643L, -27273042329649L,
				-27273042329602L, -27273042329618L, -27273042329651L, -27273042329650L, -27273042329642L, -27273042329639L
			}, 0L, 0L, Enum92.const_1, bool_2: false, bool_3: false),
			new Class881(new Enum91[5]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_0
			}, new long[12]
			{
				-27273042329610L, -27273042329628L, -27273042329602L, -27273042329618L, 0L, -5400000L, -27273042329608L, -27273042329609L, -27273042329602L, -27273042329618L,
				-27273042329656L, -27273042329655L
			}, 0L, 0L, Enum92.const_5, bool_2: false, bool_3: false),
			new Class881(new Enum91[11]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_3
			}, new long[30]
			{
				-27273042329610L, -27273042329628L, -27273042329602L, -27273042329618L, 0L, -5400000L, -27273042329608L, -27273042329609L, -27273042329602L, -27273042329618L,
				-27273042329656L, -27273042329655L, -27273042329610L, -27273042329628L, -27273042329602L, -27273042329618L, 0L, -27273042329643L, -27273042329642L, -27273042329639L,
				-27273042329608L, -27273042329641L, -27273042329642L, -27273042329638L, -27273042329642L, -27273042329634L, -27273042329602L, -27273042329618L, -27273042329643L, -27273042329649L
			}, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: false)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
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
		int num4 = array.Length;
		if (num4 == 0)
		{
			return;
		}
		for (int i = 0; i < num4; i++)
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
