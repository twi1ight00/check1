using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns16;

internal class Class1542
{
	internal bool bool_0;

	internal Class1543 class1543_0 = new Class1543();

	private string string_0;

	private bool bool_1;

	private bool bool_2;

	private FontUnderlineType fontUnderlineType_0;

	private string string_1;

	private string string_2;

	private int int_0 = -1;

	private string string_3;

	private InternalColor internalColor_0 = new InternalColor(bool_0: false);

	private int int_1 = -1;

	private int int_2 = 1;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private int int_3 = -1;

	internal bool IsItalic
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			class1543_0.method_1(Enum216.const_1);
		}
	}

	internal bool IsBold
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			class1543_0.method_1(Enum216.const_2);
		}
	}

	internal double Size
	{
		get
		{
			if (int_3 == -1)
			{
				return -1.0;
			}
			return (float)int_3 / 20f;
		}
		set
		{
			method_16((int)(value * 20.0));
			class1543_0.method_1(Enum216.const_4);
		}
	}

	internal string Name
	{
		get
		{
			return string_3;
		}
		set
		{
			string text;
			if ((text = value) == null || !(text == "(使用中文字体)"))
			{
				string_3 = value;
				class1543_0.method_1(Enum216.const_6);
			}
		}
	}

	internal bool IsStrikeout
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			class1543_0.method_1(Enum216.const_9);
		}
	}

	internal bool IsSubscript
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
			class1543_0.method_1(Enum216.const_10);
		}
	}

	internal bool IsSuperscript
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
			class1543_0.method_1(Enum216.const_11);
		}
	}

	[SpecialName]
	internal string method_0()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_1(string string_4)
	{
		string_0 = string_4;
		class1543_0.method_1(Enum216.const_1);
	}

	[SpecialName]
	internal FontUnderlineType method_2()
	{
		return fontUnderlineType_0;
	}

	[SpecialName]
	internal void method_3(FontUnderlineType fontUnderlineType_1)
	{
		fontUnderlineType_0 = fontUnderlineType_1;
		class1543_0.method_1(Enum216.const_3);
	}

	[SpecialName]
	internal string method_4()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_5(string string_4)
	{
		string_1 = string_4;
	}

	[SpecialName]
	internal string method_6()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_7(string string_4)
	{
		string_2 = string_4;
	}

	[SpecialName]
	internal int method_8()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_9(int int_4)
	{
		int_0 = int_4;
		class1543_0.method_1(Enum216.const_5);
	}

	[SpecialName]
	internal InternalColor method_10()
	{
		return internalColor_0;
	}

	[SpecialName]
	internal void method_11(InternalColor internalColor_1)
	{
		internalColor_0 = internalColor_1;
		class1543_0.method_1(Enum216.const_7);
	}

	[SpecialName]
	internal int method_12()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_13(int int_4)
	{
		int_1 = int_4;
	}

	[SpecialName]
	internal void method_14(int int_4)
	{
		int_2 = int_4;
	}

	[SpecialName]
	internal int method_15()
	{
		return int_3;
	}

	[SpecialName]
	internal void method_16(int int_4)
	{
		int_3 = int_4;
		class1543_0.method_1(Enum216.const_4);
		class1543_0.method_1(Enum216.const_12);
	}

	internal void method_17(Class1542 class1542_0, double double_0)
	{
		if (class1542_0 != null)
		{
			if (class1542_0.class1543_0.method_0(Enum216.const_7) && !class1543_0.method_0(Enum216.const_7))
			{
				method_10().method_19(class1542_0.method_10());
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_5) && !class1543_0.method_0(Enum216.const_5))
			{
				method_9(class1542_0.method_8());
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_2) && !class1543_0.method_0(Enum216.const_2))
			{
				IsBold = class1542_0.IsBold;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_1) && !class1543_0.method_0(Enum216.const_1))
			{
				IsItalic = class1542_0.IsItalic;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_3) && !class1543_0.method_0(Enum216.const_3))
			{
				method_3(class1542_0.method_2());
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_9) && !class1543_0.method_0(Enum216.const_9))
			{
				IsStrikeout = class1542_0.IsStrikeout;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_10) && !class1543_0.method_0(Enum216.const_10))
			{
				IsSubscript = class1542_0.IsSubscript;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_11) && !class1543_0.method_0(Enum216.const_11))
			{
				IsSuperscript = class1542_0.IsSuperscript;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_6) && !class1543_0.method_0(Enum216.const_6))
			{
				Name = class1542_0.Name;
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_12) && !class1543_0.method_0(Enum216.const_12))
			{
				method_16((int)((double)class1542_0.method_15() * double_0));
			}
			if (class1542_0.class1543_0.method_0(Enum216.const_13) && !class1543_0.method_0(Enum216.const_13))
			{
				method_1(class1542_0.method_0());
			}
		}
	}

	internal void method_18(Style style_0)
	{
		Font font = style_0.Font;
		if (font != null)
		{
			method_19(font);
		}
	}

	internal void method_19(Font font_0)
	{
		if (font_0 == null)
		{
			return;
		}
		if (class1543_0.method_0(Enum216.const_7) && !font_0.IsModified(StyleModifyFlag.FontColor))
		{
			font_0.InternalColor.method_19(method_10());
			font_0.method_29(StyleModifyFlag.FontColor);
		}
		if (method_8() != -1 && class1543_0.method_0(Enum216.const_5) && !font_0.IsModified(StyleModifyFlag.FontFamily))
		{
			font_0.method_12(Convert.ToByte(method_8()));
		}
		if (class1543_0.method_0(Enum216.const_2) && !font_0.IsModified(StyleModifyFlag.FontWeight))
		{
			font_0.IsBold = IsBold;
		}
		if (class1543_0.method_0(Enum216.const_1) && !font_0.IsModified(StyleModifyFlag.FontItalic))
		{
			font_0.IsItalic = IsItalic;
		}
		if (class1543_0.method_0(Enum216.const_3) && !font_0.IsModified(StyleModifyFlag.FontUnderline))
		{
			font_0.Underline = method_2();
		}
		if (class1543_0.method_0(Enum216.const_9) && !font_0.IsModified(StyleModifyFlag.FontStrike))
		{
			font_0.IsStrikeout = IsStrikeout;
		}
		if (class1543_0.method_0(Enum216.const_10) && !font_0.IsModified(StyleModifyFlag.FontScript))
		{
			font_0.IsSubscript = IsSubscript;
		}
		if (class1543_0.method_0(Enum216.const_11) && !font_0.IsModified(StyleModifyFlag.FontScript))
		{
			font_0.IsSuperscript = IsSuperscript;
		}
		if (Name != null && class1543_0.method_0(Enum216.const_6) && !font_0.IsModified(StyleModifyFlag.FontName))
		{
			font_0.method_13(Name);
			switch (Name)
			{
			case "Brush Script MT":
			case "Monotype Corsiva":
				font_0.IsItalic = true;
				break;
			case "Berlin Sans FB Demi":
			case "Aharoni":
				font_0.IsBold = true;
				break;
			}
		}
		if (method_15() != -1 && class1543_0.method_0(Enum216.const_12) && !font_0.IsModified(StyleModifyFlag.FontWeight))
		{
			font_0.method_17(method_15());
		}
		if (Size != -1.0 && class1543_0.method_0(Enum216.const_4) && !font_0.IsModified(StyleModifyFlag.FontSize))
		{
			font_0.DoubleSize = Size;
		}
		if (method_0() != null)
		{
			font_0.method_1(method_0());
		}
	}

	internal void method_20(Font font_0)
	{
		if (font_0 == null)
		{
			return;
		}
		if (class1543_0.method_0(Enum216.const_7))
		{
			font_0.InternalColor.method_19(method_10());
			font_0.method_29(StyleModifyFlag.FontColor);
		}
		if (method_8() != -1 && class1543_0.method_0(Enum216.const_5))
		{
			font_0.method_12(Convert.ToByte(method_8()));
		}
		if (class1543_0.method_0(Enum216.const_2))
		{
			font_0.IsBold = IsBold;
		}
		if (class1543_0.method_0(Enum216.const_1))
		{
			font_0.IsItalic = IsItalic;
		}
		if (class1543_0.method_0(Enum216.const_3))
		{
			font_0.Underline = method_2();
		}
		if (class1543_0.method_0(Enum216.const_9))
		{
			font_0.IsStrikeout = IsStrikeout;
		}
		if (class1543_0.method_0(Enum216.const_10))
		{
			font_0.IsSubscript = IsSubscript;
		}
		if (class1543_0.method_0(Enum216.const_11))
		{
			font_0.IsSuperscript = IsSuperscript;
		}
		if (Name != null && class1543_0.method_0(Enum216.const_6))
		{
			font_0.method_13(Name);
			switch (Name)
			{
			case "Brush Script MT":
			case "Monotype Corsiva":
				font_0.IsItalic = true;
				break;
			case "Berlin Sans FB Demi":
			case "Aharoni":
				font_0.IsBold = true;
				break;
			}
		}
		if (method_15() != -1 && class1543_0.method_0(Enum216.const_12))
		{
			font_0.method_17(method_15());
		}
		if (Size != -1.0 && class1543_0.method_0(Enum216.const_4))
		{
			font_0.DoubleSize = Size;
		}
		if (method_0() != null)
		{
			font_0.method_1(method_0());
		}
	}

	internal bool method_21()
	{
		return !class1543_0.method_0(Enum216.const_0);
	}
}
