using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class281 : Class160
{
	internal Class281(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		long num = 0L;
		num = ((class913_0.class901_0 == null) ? 50000 : ((class913_0.class901_0.arrayList_0.Count <= 0) ? 50000 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0])));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj1", num)
		}, new Class879[1]
		{
			new Class879("x1", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false)
		}, null, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329612L, -27273042329607L)
		}, new Class881[1]
		{
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2
			}, new long[8] { -27273042329608L, -27273042329609L, -27273042329612L, -27273042329609L, -27273042329612L, -27273042329611L, -27273042329610L, -27273042329611L }, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
		@class.method_0(Enum93.const_1);
		float num2 = 0f;
		float num3 = 0f;
		if (!class913_0.bool_4 && !class913_0.bool_6)
		{
			num2 = 0f - class913_0.method_6().X;
			num3 = 0f - class913_0.method_6().Y;
		}
		else
		{
			num2 = float_3;
			num3 = float_4;
		}
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rect = new RectangleF(num2, num3, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		GraphicsPath[] array = @class.method_1(rect.X, rect.Y, rect.Width, rect.Height);
		int num4 = array.Length;
		if (num4 == 0)
		{
			return;
		}
		for (int i = 0; i < num4; i++)
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
