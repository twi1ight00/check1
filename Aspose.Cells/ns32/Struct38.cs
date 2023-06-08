using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using ns19;
using ns22;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct38
{
	public static void smethod_0(Class787 class787_0, Class812 class812_0)
	{
		if (class812_0.method_0().method_0() is Class789 && class787_0.method_8().method_18())
		{
			return;
		}
		Class794 @class = class812_0.method_0();
		if (class812_0.IsVisible)
		{
			Interface42 @interface = class787_0.imethod_0();
			class812_0.method_0().method_9();
			Rectangle rectangle_ = class812_0.method_0().rectangle_0;
			using (Brush brush_ = Struct18.smethod_1(class812_0.method_0().method_1(), Class1181.smethod_5(rectangle_)))
			{
				@interface.imethod_36(brush_, rectangle_);
			}
			if (class812_0.method_0().method_2().IsVisible)
			{
				@interface.imethod_21(Struct29.smethod_5(class812_0.method_0().method_2()), rectangle_);
			}
			TextRenderingHint textRenderingHint_ = class787_0.imethod_0().imethod_56();
			if (class787_0.method_3().method_1().method_3() && class812_0.method_0().method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			smethod_4(class787_0.imethod_0(), @class.rectangle_0, class812_0.Text, class812_0.Rotation, @class.Font, @class.FontColor, class812_0.TextHorizontalAlignment, class812_0.TextVerticalAlignment);
			if (class787_0.method_3().method_1().method_3() && @class.method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
	}

	public static void smethod_1(Class787 class787_0, Class799 class799_0)
	{
		if (class799_0.vmethod_0() != 0 && class799_0.vmethod_2())
		{
			Interface42 @interface = class787_0.imethod_0();
			Class794 @class = class799_0.method_2();
			@class.method_9();
			Rectangle rectangle_ = @class.rectangle_0;
			using (Brush brush_ = Struct18.smethod_1(@class.method_1(), Class1181.smethod_5(rectangle_)))
			{
				@interface.imethod_36(brush_, rectangle_);
			}
			if (@class.method_2().IsVisible)
			{
				@interface.imethod_21(Struct29.smethod_5(@class.method_2()), rectangle_);
			}
			smethod_4(class787_0.imethod_0(), @class.rectangle_0, class799_0.vmethod_1(), class799_0.Rotation, @class.Font, @class.FontColor, class799_0.TextHorizontalAlignment, class799_0.TextVerticalAlignment);
		}
	}

	public static Size smethod_2(Class787 class787_0, Class799 class799_0, SizeF sizeF_0, Rectangle rectangle_0)
	{
		Class794 @class = class799_0.method_2();
		Size size = new Size(0, 0);
		if (class799_0.vmethod_0() != 0 && class799_0.vmethod_2())
		{
			size = Struct37.smethod_0(class787_0.imethod_0(), class799_0.vmethod_1(), class799_0.Rotation, @class.Font, sizeF_0, class799_0.TextHorizontalAlignment, class799_0.TextVerticalAlignment);
			@class.method_10(rectangle_0.Width);
			@class.method_11(rectangle_0.Height);
		}
		@class.rectangle_1.Size = size;
		return size;
	}

	public static Size smethod_3(Interface42 interface42_0, Class812 class812_0, SizeF sizeF_0)
	{
		return Struct37.smethod_0(interface42_0, class812_0.Text, class812_0.Rotation, class812_0.method_0().Font, sizeF_0, class812_0.TextHorizontalAlignment, class812_0.TextVerticalAlignment);
	}

	public static void smethod_4(Interface42 interface42_0, Rectangle rectangle_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = Struct37.smethod_8(enum82_0);
		stringFormat.LineAlignment = Struct37.smethod_8(enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangle_0.Width, 2.0) + Math.Pow(rectangle_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), string_0: string_0, font_0: font_0, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 255:
			Struct37.smethod_15(interface42_0, string_0, font_0, color_0, rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
			break;
		case 90:
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			rectangle_0 = new Rectangle(-rectangle_0.Height / 2, -rectangle_0.Width / 2, rectangle_0.Height, rectangle_0.Width);
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			break;
		}
	}
}
