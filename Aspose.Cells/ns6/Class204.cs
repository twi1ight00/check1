using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class204 : Class160
{
	internal Class204(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		num = ((class913_0.class901_0 == null) ? 100000 : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 100000 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0])));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj", num)
		}, new Class879[23]
		{
			new Class879("a", Enum89.const_11, 0L, 27273042316901L, 200000L, bool_1: false),
			new Class879("r2", Enum89.const_14, 2L, 0L, 0L, bool_1: false),
			new Class879("tw", Enum89.const_0, -27273042329630L, -27273042329613L, 1L, bool_1: false),
			new Class879("th", Enum89.const_0, -27273042329631L, -27273042329613L, 1L, bool_1: false),
			new Class879("sw", Enum89.const_0, -27273042329614L, -27273042329612L, 100000L, bool_1: false),
			new Class879("sh", Enum89.const_0, -27273042329615L, -27273042329612L, 100000L, bool_1: false),
			new Class879("dx1", Enum89.const_7, -27273042329616L, 2700000L, 0L, bool_1: false),
			new Class879("dy1", Enum89.const_13, -27273042329617L, 2700000L, 0L, bool_1: false),
			new Class879("x1", Enum89.const_1, -27273042329606L, -27273042329618L, 0L, bool_1: false),
			new Class879("y1", Enum89.const_1, -27273042329607L, 0L, -27273042329619L, bool_1: false),
			new Class879("x2", Enum89.const_2, -27273042329606L, -27273042329620L, 2L, bool_1: false),
			new Class879("y2", Enum89.const_2, -27273042329607L, -27273042329621L, 2L, bool_1: false),
			new Class879("idx", Enum89.const_7, -27273042329630L, 2700000L, 0L, bool_1: false),
			new Class879("idy", Enum89.const_13, -27273042329631L, 2700000L, 0L, bool_1: false),
			new Class879("il", Enum89.const_1, -27273042329606L, 0L, -27273042329624L, bool_1: false),
			new Class879("ir", Enum89.const_1, -27273042329606L, -27273042329624L, 0L, bool_1: false),
			new Class879("it", Enum89.const_1, -27273042329607L, 0L, -27273042329625L, bool_1: false),
			new Class879("ib", Enum89.const_1, -27273042329607L, -27273042329625L, 0L, bool_1: false),
			new Class879("wd2", Enum89.const_0, -27273042329602L, 1L, 2L, bool_1: true),
			new Class879("hd2", Enum89.const_0, -27273042329603L, 1L, 2L, bool_1: true),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true)
		}, new Class876[8]
		{
			new Class876(-27273042329610L, -27273042329607L, 0L),
			new Class876(-27273042329627L, -27273042329629L, -27273042329632L),
			new Class876(-27273042329606L, -27273042329611L, -27273042329632L),
			new Class876(-27273042329626L, -27273042329629L, -27273042329632L),
			new Class876(-27273042329608L, -27273042329607L, -27273042329633L),
			new Class876(-27273042329626L, -27273042329628L, -27273042329634L),
			new Class876(-27273042329606L, -27273042329609L, -27273042329634L),
			new Class876(-27273042329620L, -27273042329621L, -27273042329634L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, 0L, 200000L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329620L, -27273042329609L)
		}, new Class881[1]
		{
			new Class881(new Enum91[7]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_4,
				Enum91.const_4,
				Enum91.const_3,
				Enum91.const_3,
				Enum91.const_0
			}, new long[22]
			{
				-27273042329608L, -27273042329607L, -27273042329630L, -27273042329631L, -27273042329633L, -27273042329632L, -27273042329622L, -27273042329609L, -27273042329620L, -27273042329621L,
				-27273042329610L, -27273042329623L, -27273042329610L, -27273042329607L, -27273042329630L, -27273042329631L, 0L, -27273042329632L, -27273042329630L, -27273042329631L,
				-27273042329632L, -27273042329632L
			}, 0L, 0L, Enum92.const_1, bool_2: true, bool_3: true)
		}, new Class874(-27273042329626L, -27273042329628L), new Class874(-27273042329627L, -27273042329629L));
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
