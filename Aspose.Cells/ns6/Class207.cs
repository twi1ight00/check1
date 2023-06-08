using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class207 : Class160
{
	internal Class207(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		long num3 = 0L;
		long num4 = 0L;
		long num5 = 0L;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToInt64(class913_0.class901_0.arrayList_0[0]);
				num2 = Convert.ToInt64(class913_0.class901_0.arrayList_0[1]);
				num3 = Convert.ToInt64(class913_0.class901_0.arrayList_0[2]);
				num4 = Convert.ToInt64(class913_0.class901_0.arrayList_0[3]);
				num5 = Convert.ToInt64(class913_0.class901_0.arrayList_0[4]);
			}
			else
			{
				num = 12500L;
				num2 = 1142319L;
				num3 = 20457681L;
				num4 = 10800000L;
				num5 = 12500L;
			}
		}
		else
		{
			num = 12500L;
			num2 = 1142319L;
			num3 = 20457681L;
			num4 = 10800000L;
			num5 = 12500L;
		}
		Class878 @class = new Class878(new Class875[5]
		{
			new Class875("adj1", num),
			new Class875("adj2", num2),
			new Class875("adj3", num3),
			new Class875("adj4", num4),
			new Class875("adj5", num5)
		}, new Class879[196]
		{
			new Class879("a5", Enum89.const_11, 0L, 27273042316905L, 25000L, bool_1: false),
			new Class879("maxAdj1", Enum89.const_0, -27273042329612L, 2L, 1L, bool_1: false),
			new Class879("a1", Enum89.const_11, 0L, 27273042316901L, -27273042329613L, bool_1: false),
			new Class879("enAng", Enum89.const_11, 1L, 27273042316903L, 21599999L, bool_1: false),
			new Class879("stAng", Enum89.const_11, 0L, 27273042316904L, 21599999L, bool_1: false),
			new Class879("th", Enum89.const_0, -27273042329604L, -27273042329614L, 100000L, bool_1: false),
			new Class879("thh", Enum89.const_0, -27273042329604L, -27273042329612L, 100000L, bool_1: false),
			new Class879("th2", Enum89.const_0, -27273042329617L, 1L, 2L, bool_1: false),
			new Class879("rw1", Enum89.const_1, -27273042329804L, -27273042329619L, -27273042329618L, bool_1: false),
			new Class879("rh1", Enum89.const_1, -27273042329805L, -27273042329619L, -27273042329618L, bool_1: false),
			new Class879("rw2", Enum89.const_1, -27273042329620L, 0L, -27273042329617L, bool_1: false),
			new Class879("rh2", Enum89.const_1, -27273042329621L, 0L, -27273042329617L, bool_1: false),
			new Class879("rw3", Enum89.const_1, -27273042329622L, -27273042329619L, 0L, bool_1: false),
			new Class879("rh3", Enum89.const_1, -27273042329623L, -27273042329619L, 0L, bool_1: false),
			new Class879("wtH", Enum89.const_13, -27273042329624L, -27273042329615L, 0L, bool_1: false),
			new Class879("htH", Enum89.const_7, -27273042329625L, -27273042329615L, 0L, bool_1: false),
			new Class879("dxH", Enum89.const_6, -27273042329624L, -27273042329627L, -27273042329626L, bool_1: false),
			new Class879("dyH", Enum89.const_12, -27273042329625L, -27273042329627L, -27273042329626L, bool_1: false),
			new Class879("xH", Enum89.const_1, -27273042329606L, -27273042329628L, 0L, bool_1: false),
			new Class879("yH", Enum89.const_1, -27273042329607L, -27273042329629L, 0L, bool_1: false),
			new Class879("rI", Enum89.const_9, -27273042329622L, -27273042329623L, 0L, bool_1: false),
			new Class879("u1", Enum89.const_0, -27273042329628L, -27273042329628L, 1L, bool_1: false),
			new Class879("u2", Enum89.const_0, -27273042329629L, -27273042329629L, 1L, bool_1: false),
			new Class879("u3", Enum89.const_0, -27273042329632L, -27273042329632L, 1L, bool_1: false),
			new Class879("u4", Enum89.const_1, -27273042329633L, 0L, -27273042329635L, bool_1: false),
			new Class879("u5", Enum89.const_1, -27273042329634L, 0L, -27273042329635L, bool_1: false),
			new Class879("u6", Enum89.const_0, -27273042329636L, -27273042329637L, -27273042329633L, bool_1: false),
			new Class879("u7", Enum89.const_0, -27273042329638L, 1L, -27273042329634L, bool_1: false),
			new Class879("u8", Enum89.const_1, 1L, 0L, -27273042329639L, bool_1: false),
			new Class879("u9", Enum89.const_14, -27273042329640L, 0L, 0L, bool_1: false),
			new Class879("u10", Enum89.const_0, -27273042329636L, 1L, -27273042329628L, bool_1: false),
			new Class879("u11", Enum89.const_0, -27273042329642L, 1L, -27273042329629L, bool_1: false),
			new Class879("u12", Enum89.const_2, 1L, -27273042329641L, -27273042329643L, bool_1: false),
			new Class879("u13", Enum89.const_5, 1L, -27273042329644L, 0L, bool_1: false),
			new Class879("u14", Enum89.const_1, -27273042329645L, 21600000L, 0L, bool_1: false),
			new Class879("u15", Enum89.const_3, -27273042329645L, -27273042329645L, -27273042329646L, bool_1: false),
			new Class879("u16", Enum89.const_1, -27273042329647L, 0L, -27273042329615L, bool_1: false),
			new Class879("u17", Enum89.const_1, -27273042329648L, 21600000L, 0L, bool_1: false),
			new Class879("u18", Enum89.const_3, -27273042329648L, -27273042329648L, -27273042329649L, bool_1: false),
			new Class879("u19", Enum89.const_1, -27273042329650L, 0L, -27273042329806L, bool_1: false),
			new Class879("u20", Enum89.const_1, -27273042329650L, 0L, 21600000L, bool_1: false),
			new Class879("u21", Enum89.const_3, -27273042329651L, -27273042329652L, -27273042329650L, bool_1: false),
			new Class879("maxAng", Enum89.const_4, -27273042329653L, 0L, 0L, bool_1: false),
			new Class879("aAng", Enum89.const_11, 0L, 27273042316902L, -27273042329654L, bool_1: false),
			new Class879("ptAng", Enum89.const_1, -27273042329615L, -27273042329655L, 0L, bool_1: false),
			new Class879("wtA", Enum89.const_13, -27273042329624L, -27273042329656L, 0L, bool_1: false),
			new Class879("htA", Enum89.const_7, -27273042329625L, -27273042329656L, 0L, bool_1: false),
			new Class879("dxA", Enum89.const_6, -27273042329624L, -27273042329658L, -27273042329657L, bool_1: false),
			new Class879("dyA", Enum89.const_12, -27273042329625L, -27273042329658L, -27273042329657L, bool_1: false),
			new Class879("xA", Enum89.const_1, -27273042329606L, -27273042329659L, 0L, bool_1: false),
			new Class879("yA", Enum89.const_1, -27273042329607L, -27273042329660L, 0L, bool_1: false),
			new Class879("wtE", Enum89.const_13, -27273042329620L, -27273042329616L, 0L, bool_1: false),
			new Class879("htE", Enum89.const_7, -27273042329621L, -27273042329616L, 0L, bool_1: false),
			new Class879("dxE", Enum89.const_6, -27273042329620L, -27273042329664L, -27273042329663L, bool_1: false),
			new Class879("dyE", Enum89.const_12, -27273042329621L, -27273042329664L, -27273042329663L, bool_1: false),
			new Class879("xE", Enum89.const_1, -27273042329606L, -27273042329665L, 0L, bool_1: false),
			new Class879("yE", Enum89.const_1, -27273042329607L, -27273042329666L, 0L, bool_1: false),
			new Class879("dxG", Enum89.const_7, -27273042329618L, -27273042329656L, 0L, bool_1: false),
			new Class879("dyG", Enum89.const_13, -27273042329618L, -27273042329656L, 0L, bool_1: false),
			new Class879("xG", Enum89.const_1, -27273042329630L, -27273042329669L, 0L, bool_1: false),
			new Class879("yG", Enum89.const_1, -27273042329631L, -27273042329670L, 0L, bool_1: false),
			new Class879("dxB", Enum89.const_7, -27273042329618L, -27273042329656L, 0L, bool_1: false),
			new Class879("dyB", Enum89.const_13, -27273042329618L, -27273042329656L, 0L, bool_1: false),
			new Class879("xB", Enum89.const_1, -27273042329630L, 0L, -27273042329673L, bool_1: false),
			new Class879("yB", Enum89.const_1, -27273042329631L, 0L, -27273042329674L, bool_1: false),
			new Class879("sx1", Enum89.const_1, -27273042329675L, 0L, -27273042329606L, bool_1: false),
			new Class879("sy1", Enum89.const_1, -27273042329676L, 0L, -27273042329607L, bool_1: false),
			new Class879("sx2", Enum89.const_1, -27273042329671L, 0L, -27273042329606L, bool_1: false),
			new Class879("sy2", Enum89.const_1, -27273042329672L, 0L, -27273042329607L, bool_1: false),
			new Class879("rO", Enum89.const_9, -27273042329620L, -27273042329621L, 0L, bool_1: false),
			new Class879("x1O", Enum89.const_0, -27273042329677L, -27273042329681L, -27273042329620L, bool_1: false),
			new Class879("y1O", Enum89.const_0, -27273042329678L, -27273042329681L, -27273042329621L, bool_1: false),
			new Class879("x2O", Enum89.const_0, -27273042329679L, -27273042329681L, -27273042329620L, bool_1: false),
			new Class879("y2O", Enum89.const_0, -27273042329680L, -27273042329681L, -27273042329621L, bool_1: false),
			new Class879("dxO", Enum89.const_1, -27273042329684L, 0L, -27273042329682L, bool_1: false),
			new Class879("dyO", Enum89.const_1, -27273042329685L, 0L, -27273042329683L, bool_1: false),
			new Class879("dO", Enum89.const_10, -27273042329686L, -27273042329687L, 0L, bool_1: false),
			new Class879("q1", Enum89.const_0, -27273042329682L, -27273042329685L, 1L, bool_1: false),
			new Class879("q2", Enum89.const_0, -27273042329684L, -27273042329683L, 1L, bool_1: false),
			new Class879("DO", Enum89.const_1, -27273042329689L, 0L, -27273042329690L, bool_1: false),
			new Class879("q3", Enum89.const_0, -27273042329681L, -27273042329681L, 1L, bool_1: false),
			new Class879("q4", Enum89.const_0, -27273042329688L, -27273042329688L, 1L, bool_1: false),
			new Class879("q5", Enum89.const_0, -27273042329692L, -27273042329693L, 1L, bool_1: false),
			new Class879("q6", Enum89.const_0, -27273042329691L, -27273042329691L, 1L, bool_1: false),
			new Class879("q7", Enum89.const_1, -27273042329694L, 0L, -27273042329695L, bool_1: false),
			new Class879("q8", Enum89.const_8, -27273042329696L, 0L, 0L, bool_1: false),
			new Class879("sdelO", Enum89.const_14, -27273042329697L, 0L, 0L, bool_1: false),
			new Class879("ndyO", Enum89.const_0, -27273042329687L, -1L, 1L, bool_1: false),
			new Class879("sdyO", Enum89.const_3, -27273042329699L, -1L, 1L, bool_1: false),
			new Class879("q9", Enum89.const_0, -27273042329700L, -27273042329686L, 1L, bool_1: false),
			new Class879("q10", Enum89.const_0, -27273042329701L, -27273042329698L, 1L, bool_1: false),
			new Class879("q11", Enum89.const_0, -27273042329691L, -27273042329687L, 1L, bool_1: false),
			new Class879("dxF1", Enum89.const_2, -27273042329703L, -27273042329702L, -27273042329693L, bool_1: false),
			new Class879("q12", Enum89.const_1, -27273042329703L, 0L, -27273042329702L, bool_1: false),
			new Class879("dxF2", Enum89.const_0, -27273042329705L, 1L, -27273042329693L, bool_1: false),
			new Class879("adyO", Enum89.const_4, -27273042329687L, 0L, 0L, bool_1: false),
			new Class879("q13", Enum89.const_0, -27273042329707L, -27273042329698L, 1L, bool_1: false),
			new Class879("q14", Enum89.const_0, -27273042329691L, -27273042329686L, -1L, bool_1: false),
			new Class879("dyF1", Enum89.const_2, -27273042329709L, -27273042329708L, -27273042329693L, bool_1: false),
			new Class879("q15", Enum89.const_1, -27273042329709L, 0L, -27273042329708L, bool_1: false),
			new Class879("dyF2", Enum89.const_0, -27273042329711L, 1L, -27273042329693L, bool_1: false),
			new Class879("q16", Enum89.const_1, -27273042329684L, 0L, -27273042329704L, bool_1: false),
			new Class879("q17", Enum89.const_1, -27273042329684L, 0L, -27273042329706L, bool_1: false),
			new Class879("q18", Enum89.const_1, -27273042329685L, 0L, -27273042329710L, bool_1: false),
			new Class879("q19", Enum89.const_1, -27273042329685L, 0L, -27273042329712L, bool_1: false),
			new Class879("q20", Enum89.const_10, -27273042329713L, -27273042329715L, 0L, bool_1: false),
			new Class879("q21", Enum89.const_10, -27273042329714L, -27273042329716L, 0L, bool_1: false),
			new Class879("q22", Enum89.const_1, -27273042329718L, 0L, -27273042329717L, bool_1: false),
			new Class879("dxF", Enum89.const_3, -27273042329719L, -27273042329704L, -27273042329706L, bool_1: false),
			new Class879("dyF", Enum89.const_3, -27273042329719L, -27273042329710L, -27273042329712L, bool_1: false),
			new Class879("sdxF", Enum89.const_0, -27273042329720L, -27273042329620L, -27273042329681L, bool_1: false),
			new Class879("sdyF", Enum89.const_0, -27273042329721L, -27273042329621L, -27273042329681L, bool_1: false),
			new Class879("xF", Enum89.const_1, -27273042329606L, -27273042329722L, 0L, bool_1: false),
			new Class879("yF", Enum89.const_1, -27273042329607L, -27273042329723L, 0L, bool_1: false),
			new Class879("x1I", Enum89.const_0, -27273042329677L, -27273042329632L, -27273042329622L, bool_1: false),
			new Class879("y1I", Enum89.const_0, -27273042329678L, -27273042329632L, -27273042329623L, bool_1: false),
			new Class879("x2I", Enum89.const_0, -27273042329679L, -27273042329632L, -27273042329622L, bool_1: false),
			new Class879("y2I", Enum89.const_0, -27273042329680L, -27273042329632L, -27273042329623L, bool_1: false),
			new Class879("dxI", Enum89.const_1, -27273042329728L, 0L, -27273042329726L, bool_1: false),
			new Class879("dyI", Enum89.const_1, -27273042329729L, 0L, -27273042329727L, bool_1: false),
			new Class879("dI", Enum89.const_10, -27273042329730L, -27273042329731L, 0L, bool_1: false),
			new Class879("v1", Enum89.const_0, -27273042329726L, -27273042329729L, 1L, bool_1: false),
			new Class879("v2", Enum89.const_0, -27273042329728L, -27273042329727L, 1L, bool_1: false),
			new Class879("DI", Enum89.const_1, -27273042329733L, 0L, -27273042329734L, bool_1: false),
			new Class879("v3", Enum89.const_0, -27273042329632L, -27273042329632L, 1L, bool_1: false),
			new Class879("v4", Enum89.const_0, -27273042329732L, -27273042329732L, 1L, bool_1: false),
			new Class879("v5", Enum89.const_0, -27273042329736L, -27273042329737L, 1L, bool_1: false),
			new Class879("v6", Enum89.const_0, -27273042329735L, -27273042329735L, 1L, bool_1: false),
			new Class879("v7", Enum89.const_1, -27273042329738L, 0L, -27273042329739L, bool_1: false),
			new Class879("v8", Enum89.const_8, -27273042329740L, 0L, 0L, bool_1: false),
			new Class879("sdelI", Enum89.const_14, -27273042329741L, 0L, 0L, bool_1: false),
			new Class879("v9", Enum89.const_0, -27273042329700L, -27273042329730L, 1L, bool_1: false),
			new Class879("v10", Enum89.const_0, -27273042329743L, -27273042329742L, 1L, bool_1: false),
			new Class879("v11", Enum89.const_0, -27273042329735L, -27273042329731L, 1L, bool_1: false),
			new Class879("dxC1", Enum89.const_2, -27273042329745L, -27273042329744L, -27273042329737L, bool_1: false),
			new Class879("v12", Enum89.const_1, -27273042329745L, 0L, -27273042329744L, bool_1: false),
			new Class879("dxC2", Enum89.const_0, -27273042329747L, 1L, -27273042329737L, bool_1: false),
			new Class879("adyI", Enum89.const_4, -27273042329731L, 0L, 0L, bool_1: false),
			new Class879("v13", Enum89.const_0, -27273042329749L, -27273042329742L, 1L, bool_1: false),
			new Class879("v14", Enum89.const_0, -27273042329735L, -27273042329730L, -1L, bool_1: false),
			new Class879("dyC1", Enum89.const_2, -27273042329751L, -27273042329750L, -27273042329737L, bool_1: false),
			new Class879("v15", Enum89.const_1, -27273042329751L, 0L, -27273042329750L, bool_1: false),
			new Class879("dyC2", Enum89.const_0, -27273042329753L, 1L, -27273042329737L, bool_1: false),
			new Class879("v16", Enum89.const_1, -27273042329726L, 0L, -27273042329746L, bool_1: false),
			new Class879("v17", Enum89.const_1, -27273042329726L, 0L, -27273042329748L, bool_1: false),
			new Class879("v18", Enum89.const_1, -27273042329727L, 0L, -27273042329752L, bool_1: false),
			new Class879("v19", Enum89.const_1, -27273042329727L, 0L, -27273042329754L, bool_1: false),
			new Class879("v20", Enum89.const_10, -27273042329755L, -27273042329757L, 0L, bool_1: false),
			new Class879("v21", Enum89.const_10, -27273042329756L, -27273042329758L, 0L, bool_1: false),
			new Class879("v22", Enum89.const_1, -27273042329760L, 0L, -27273042329759L, bool_1: false),
			new Class879("dxC", Enum89.const_3, -27273042329761L, -27273042329746L, -27273042329748L, bool_1: false),
			new Class879("dyC", Enum89.const_3, -27273042329761L, -27273042329752L, -27273042329754L, bool_1: false),
			new Class879("sdxC", Enum89.const_0, -27273042329762L, -27273042329622L, -27273042329632L, bool_1: false),
			new Class879("sdyC", Enum89.const_0, -27273042329763L, -27273042329623L, -27273042329632L, bool_1: false),
			new Class879("xC", Enum89.const_1, -27273042329606L, -27273042329764L, 0L, bool_1: false),
			new Class879("yC", Enum89.const_1, -27273042329607L, -27273042329765L, 0L, bool_1: false),
			new Class879("ist0", Enum89.const_5, -27273042329764L, -27273042329765L, 0L, bool_1: false),
			new Class879("ist1", Enum89.const_1, -27273042329768L, 21600000L, 0L, bool_1: false),
			new Class879("istAng", Enum89.const_3, -27273042329768L, -27273042329768L, -27273042329769L, bool_1: false),
			new Class879("isw1", Enum89.const_1, -27273042329616L, 0L, -27273042329770L, bool_1: false),
			new Class879("isw2", Enum89.const_1, -27273042329771L, 0L, 21600000L, bool_1: false),
			new Class879("iswAng", Enum89.const_3, -27273042329771L, -27273042329772L, -27273042329771L, bool_1: false),
			new Class879("p1", Enum89.const_1, -27273042329724L, 0L, -27273042329766L, bool_1: false),
			new Class879("p2", Enum89.const_1, -27273042329725L, 0L, -27273042329767L, bool_1: false),
			new Class879("p3", Enum89.const_10, -27273042329774L, -27273042329775L, 0L, bool_1: false),
			new Class879("p4", Enum89.const_0, -27273042329776L, 1L, 2L, bool_1: false),
			new Class879("p5", Enum89.const_1, -27273042329777L, 0L, -27273042329618L, bool_1: false),
			new Class879("xGp", Enum89.const_3, -27273042329778L, -27273042329724L, -27273042329671L, bool_1: false),
			new Class879("yGp", Enum89.const_3, -27273042329778L, -27273042329725L, -27273042329672L, bool_1: false),
			new Class879("xBp", Enum89.const_3, -27273042329778L, -27273042329766L, -27273042329675L, bool_1: false),
			new Class879("yBp", Enum89.const_3, -27273042329778L, -27273042329767L, -27273042329676L, bool_1: false),
			new Class879("en0", Enum89.const_5, -27273042329722L, -27273042329723L, 0L, bool_1: false),
			new Class879("en1", Enum89.const_1, -27273042329783L, 21600000L, 0L, bool_1: false),
			new Class879("en2", Enum89.const_3, -27273042329783L, -27273042329783L, -27273042329784L, bool_1: false),
			new Class879("sw0", Enum89.const_1, -27273042329785L, 0L, -27273042329616L, bool_1: false),
			new Class879("sw1", Enum89.const_1, -27273042329786L, 21600000L, 0L, bool_1: false),
			new Class879("swAng", Enum89.const_3, -27273042329786L, -27273042329786L, -27273042329787L, bool_1: false),
			new Class879("wtI", Enum89.const_13, -27273042329624L, -27273042329616L, 0L, bool_1: false),
			new Class879("htI", Enum89.const_7, -27273042329625L, -27273042329616L, 0L, bool_1: false),
			new Class879("dxIdub", Enum89.const_6, -27273042329624L, -27273042329790L, -27273042329789L, bool_1: false),
			new Class879("dyIdub", Enum89.const_12, -27273042329625L, -27273042329790L, -27273042329789L, bool_1: false),
			new Class879("xI", Enum89.const_1, -27273042329606L, -27273042329730L, 0L, bool_1: false),
			new Class879("yI", Enum89.const_1, -27273042329607L, -27273042329731L, 0L, bool_1: false),
			new Class879("aI", Enum89.const_1, -27273042329616L, 0L, -27273042329807L, bool_1: false),
			new Class879("aA", Enum89.const_1, -27273042329656L, -27273042329807L, 0L, bool_1: false),
			new Class879("aB", Enum89.const_1, -27273042329656L, -27273042329806L, 0L, bool_1: false),
			new Class879("idx", Enum89.const_7, -27273042329620L, 2700000L, 0L, bool_1: false),
			new Class879("idy", Enum89.const_13, -27273042329621L, 2700000L, 0L, bool_1: false),
			new Class879("il", Enum89.const_1, -27273042329606L, 0L, -27273042329798L, bool_1: false),
			new Class879("ir", Enum89.const_1, -27273042329606L, -27273042329798L, 0L, bool_1: false),
			new Class879("it", Enum89.const_1, -27273042329607L, 0L, -27273042329799L, bool_1: false),
			new Class879("ib", Enum89.const_1, -27273042329607L, -27273042329799L, 0L, bool_1: false),
			new Class879("wd2", Enum89.const_0, -27273042329602L, 1L, 2L, bool_1: true),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true)
		}, new Class876[4]
		{
			new Class876(-27273042329793L, -27273042329794L, -27273042329795L),
			new Class876(-27273042329779L, -27273042329780L, -27273042329656L),
			new Class876(-27273042329661L, -27273042329662L, -27273042329796L),
			new Class876(-27273042329781L, -27273042329782L, -27273042329797L)
		}, new Class873[4]
		{
			new Class873(bool_1: true, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316902L, 0L, -27273042329654L, -27273042329661L, -27273042329662L),
			new Class873(bool_1: true, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316904L, 0L, 21599999L, -27273042329667L, -27273042329668L),
			new Class873(bool_1: true, 27273042316901L, 0L, -27273042329613L, 27273042316903L, 0L, 21599999L, -27273042329724L, -27273042329725L),
			new Class873(bool_1: true, 27273042316905L, 0L, 25000L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329675L, -27273042329676L)
		}, new Class881[1]
		{
			new Class881(new Enum91[8]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_0
			}, new long[18]
			{
				-27273042329667L, -27273042329668L, -27273042329620L, -27273042329621L, -27273042329616L, -27273042329788L, -27273042329779L, -27273042329780L, -27273042329661L, -27273042329662L,
				-27273042329781L, -27273042329782L, -27273042329766L, -27273042329767L, -27273042329622L, -27273042329623L, -27273042329770L, -27273042329773L
			}, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329800L, -27273042329802L), new Class874(-27273042329801L, -27273042329803L));
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
		int num6 = array.Length;
		if (num6 == 0)
		{
			return;
		}
		for (int i = 0; i < num6; i++)
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
