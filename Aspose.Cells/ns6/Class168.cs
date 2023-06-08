using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class168 : Class160
{
	internal Class168(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
		num = ((class913_0.class901_0 == null) ? 8333 : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 8333 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0])));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj", num)
		}, new Class879[12]
		{
			new Class879("maxAdj", Enum89.const_0, 50000L, -27273042329603L, -27273042329604L, bool_1: false),
			new Class879("a", Enum89.const_11, 0L, 27273042316901L, -27273042329612L, bool_1: false),
			new Class879("y1", Enum89.const_0, -27273042329604L, -27273042329613L, 100000L, bool_1: false),
			new Class879("y2", Enum89.const_1, -27273042329611L, 0L, -27273042329614L, bool_1: false),
			new Class879("dx1", Enum89.const_7, -27273042329602L, 2700000L, 0L, bool_1: false),
			new Class879("dy1", Enum89.const_13, -27273042329614L, 2700000L, 0L, bool_1: false),
			new Class879("ir", Enum89.const_1, -27273042329608L, -27273042329616L, 0L, bool_1: false),
			new Class879("it", Enum89.const_1, -27273042329614L, 0L, -27273042329617L, bool_1: false),
			new Class879("ib", Enum89.const_1, -27273042329611L, -27273042329617L, -27273042329614L, bool_1: false),
			new Class879("cd4", Enum89.const_0, -27273042329601L, 1L, 4L, bool_1: true),
			new Class879("3cd4", Enum89.const_0, -27273042329601L, 3L, 4L, bool_1: true),
			new Class879("cd2", Enum89.const_0, -27273042329601L, 1L, 2L, bool_1: true)
		}, new Class876[3]
		{
			new Class876(-27273042329608L, -27273042329609L, -27273042329621L),
			new Class876(-27273042329608L, -27273042329611L, -27273042329622L),
			new Class876(-27273042329610L, -27273042329607L, -27273042329623L)
		}, new Class873[1]
		{
			new Class873(bool_1: false, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316901L, 0L, -27273042329612L, -27273042329610L, -27273042329614L)
		}, new Class881[2]
		{
			new Class881(new Enum91[5]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_3,
				Enum91.const_0
			}, new long[12]
			{
				-27273042329608L, -27273042329609L, -27273042329602L, -27273042329614L, -27273042329622L, -27273042329621L, -27273042329610L, -27273042329615L, -27273042329602L, -27273042329614L,
				0L, -27273042329621L
			}, 0L, 0L, Enum92.const_1, bool_2: false, bool_3: false),
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_3,
				Enum91.const_2,
				Enum91.const_3
			}, new long[12]
			{
				-27273042329608L, -27273042329609L, -27273042329602L, -27273042329614L, -27273042329622L, -27273042329621L, -27273042329610L, -27273042329615L, -27273042329602L, -27273042329614L,
				0L, -27273042329621L
			}, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329619L), new Class874(-27273042329618L, -27273042329620L));
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
		if (array.Length != 0)
		{
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, array[1]);
			if (!class913_0.Fill.method_0())
			{
				interface42_0.imethod_33(brush_, array[1]);
			}
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[1]);
			}
			base.vmethod_4();
			interface42_0.imethod_55(smoothingMode_);
		}
	}
}
