using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class165 : Class160
{
	internal Class165(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
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
				num = -25532L;
				num2 = -670584L;
				num3 = 75000L;
			}
		}
		else
		{
			num = -25532L;
			num2 = -670584L;
			num3 = 75000L;
		}
		Class878 @class = new Class878(new Class875[3]
		{
			new Class875("adj1", num),
			new Class875("adj2", num2),
			new Class875("adj3", num3)
		}, new Class879[6]
		{
			new Class879("x1", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false),
			new Class879("x3", Enum89.const_0, -27273042329602L, 27273042316903L, 100000L, bool_1: false),
			new Class879("x2", Enum89.const_2, -27273042329612L, -27273042329613L, 2L, bool_1: false),
			new Class879("y2", Enum89.const_0, -27273042329603L, 27273042316902L, 100000L, bool_1: false),
			new Class879("y1", Enum89.const_2, -27273042329609L, -27273042329615L, 2L, bool_1: false),
			new Class879("y3", Enum89.const_2, -27273042329611L, -27273042329615L, 2L, bool_1: false)
		}, null, new Class873[3]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329612L, -27273042329616L),
			new Class873(bool_1: false, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316902L, -2147483647L, 2147483647L, -27273042329614L, -27273042329615L),
			new Class873(bool_1: false, 27273042316903L, -2147483647L, 2147483647L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329613L, -27273042329617L)
		}, new Class881[1]
		{
			new Class881(new Enum91[6]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2
			}, new long[12]
			{
				-27273042329608L, -27273042329609L, -27273042329612L, -27273042329609L, -27273042329612L, -27273042329615L, -27273042329613L, -27273042329615L, -27273042329613L, -27273042329611L,
				-27273042329610L, -27273042329611L
			}, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
		@class.method_0(Enum93.const_1);
		float num4 = 0f;
		float num5 = 0f;
		if (!class913_0.bool_4 && !class913_0.bool_6)
		{
			num4 = 0f - class913_0.method_6().X;
			num5 = 0f - class913_0.method_6().Y;
		}
		else
		{
			num4 = float_3;
			num5 = float_4;
		}
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rect = new RectangleF(num4, num5, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rect.X, rect.Y, rect.Width, rect.Height);
		int num6 = array.Length;
		if (num6 == 0)
		{
			return;
		}
		for (int i = 0; i < num6; i++)
		{
			if (!class913_0.Line.method_0())
			{
				interface42_0.imethod_18(pen_, array[i]);
			}
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
