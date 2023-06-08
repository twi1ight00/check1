using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using ns19;
using ns3;
using ns34;

namespace ns33;

internal class Class848 : IDisposable, Interface30
{
	private Class829 class829_0;

	private int int_0;

	private string string_0;

	private Enum82 enum82_0;

	private Enum82 enum82_1;

	private Class864 class864_0;

	internal bool bool_0 = true;

	private Size size_0 = Size.Empty;

	private bool bool_1;

	public int Rotation
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_0 = false;
		}
	}

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Enum82 TextHorizontalAlignment
	{
		get
		{
			return enum82_0;
		}
		set
		{
			enum82_0 = value;
		}
	}

	public Enum82 TextVerticalAlignment
	{
		get
		{
			return enum82_1;
		}
		set
		{
			enum82_1 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			if (string_0 == null)
			{
				return false;
			}
			if (string_0.Length > 0)
			{
				return true;
			}
			return false;
		}
	}

	internal Class848(Class821 class821_0, object object_0, Enum52 enum52_0, Enum57 enum57_0)
	{
		class829_0 = new Class829(class821_0, object_0, enum52_0, enum57_0);
		int_0 = 0;
		string_0 = "";
		class829_0.method_1().Formatting = Enum71.const_0;
		enum82_0 = Enum82.const_1;
		enum82_1 = Enum82.const_1;
		class829_0.Border.Formatting = Enum71.const_0;
		class864_0 = new Class864();
	}

	[SpecialName]
	internal Class829 method_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Interface14 imethod_0()
	{
		return class829_0;
	}

	[SpecialName]
	public Interface38 imethod_1()
	{
		return class864_0;
	}

	[SpecialName]
	internal bool method_1()
	{
		return class864_0.Count > 0;
	}

	internal void method_2()
	{
		if (IsVisible && (!(class829_0.method_0() is Class823) || !class829_0.Chart.method_8().method_16()))
		{
			Interface42 @interface = class829_0.Chart.imethod_0();
			TextRenderingHint textRenderingHint_ = class829_0.Chart.imethod_0().imethod_56();
			if (class829_0.Chart.method_3().method_1().method_2() && class829_0.method_1().method_2())
			{
				@interface.imethod_57(TextRenderingHint.AntiAlias);
			}
			class829_0.method_9();
			int num = class829_0.rectangle_0.X + class829_0.rectangle_0.Width / 2;
			int num2 = class829_0.rectangle_0.Y + class829_0.rectangle_0.Height / 2;
			RectangleF rectangleF = new RectangleF(-size_0.Width / 2, -size_0.Height / 2, size_0.Width, size_0.Height);
			@interface.imethod_49(num, num2);
			@interface.imethod_45(-Rotation);
			class829_0.method_1().method_8(rectangleF);
			class829_0.method_2().method_10(rectangleF);
			if (!method_1())
			{
				Struct61.smethod_1(@interface, rectangleF, Text, 0, class829_0.Font, class829_0.FontColor, TextHorizontalAlignment, TextVerticalAlignment);
			}
			else
			{
				Class863 @class = new Class863();
				@class.TextHorizontalAlignment = Struct61.smethod_13(TextHorizontalAlignment);
				@class.TextVerticalAlignment = Struct61.smethod_13(TextVerticalAlignment);
				Class866 class2 = new Class866(rectangleF, @class, imethod_1(), method_0().Font);
				class2.method_0(@interface);
			}
			@interface.ResetTransform();
			if (class829_0.Chart.method_3().method_1().method_2() && class829_0.method_1().method_2())
			{
				@interface.imethod_57(textRenderingHint_);
			}
		}
	}

	internal Size method_3(SizeF sizeF_0)
	{
		Size empty = Size.Empty;
		if (!method_1())
		{
			empty = (size_0 = Struct61.smethod_3(class829_0.Chart.imethod_0(), Text, 0, class829_0.Font, sizeF_0, TextHorizontalAlignment, TextVerticalAlignment));
			double num = (double)int_0 * Math.PI / 180.0;
			int width = (int)((double)empty.Width * Math.Abs(Math.Cos(num)) + (double)empty.Height * Math.Abs(Math.Sin(num)) + 0.5);
			int height = (int)((double)empty.Width * Math.Abs(Math.Sin(num)) + (double)empty.Height * Math.Abs(Math.Cos(num)) + 0.5);
			return new Size(width, height);
		}
		Class863 @class = new Class863();
		@class.TextHorizontalAlignment = StringAlignment.Center;
		@class.TextVerticalAlignment = StringAlignment.Center;
		RectangleF rectangleF_ = new RectangleF(0f, 0f, sizeF_0.Width, sizeF_0.Height);
		Class866 class2 = new Class866(rectangleF_, @class, imethod_1(), method_0().Font);
		RectangleF rectangleF = class2.Calculate(method_0().Chart.imethod_0());
		empty = (size_0 = new Size((int)((double)rectangleF.Width + 0.5), (int)((double)rectangleF.Height + 0.5)));
		double num2 = (double)int_0 * Math.PI / 180.0;
		int width2 = (int)((double)empty.Width * Math.Abs(Math.Cos(num2)) + (double)empty.Height * Math.Abs(Math.Sin(num2)) + 0.5);
		int height2 = (int)((double)empty.Width * Math.Abs(Math.Sin(num2)) + (double)empty.Height * Math.Abs(Math.Cos(num2)) + 0.5);
		return new Size(width2, height2);
	}

	~Class848()
	{
		Dispose(bool_2: false);
	}

	public void Dispose()
	{
		Dispose(bool_2: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_2)
	{
		if (!bool_1)
		{
			if (bool_2 && class829_0 != null)
			{
				class829_0.Dispose();
			}
			bool_1 = true;
		}
	}
}
