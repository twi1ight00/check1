using System;
using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns271;
using ns4;
using ns6;

namespace ns33;

internal class Class733
{
	private Font font_0;

	private Class5999 class5999_0;

	private readonly string string_0;

	private readonly float float_0;

	private readonly Enum1 enum1_0 = Enum1.const_1;

	private readonly int int_0;

	private readonly FontStyle fontStyle_0;

	private readonly bool bool_0;

	private readonly bool bool_1;

	private readonly Class54 class54_0;

	private static readonly IList<Class733> ilist_0 = new List<Class733>();

	public Font Font => font_0;

	public string FontFamily => string_0;

	public Enum1 CharSet => enum1_0;

	public int PitchAndFamily => int_0;

	public byte[] Panose
	{
		get
		{
			if (!bool_0)
			{
				return null;
			}
			return class5999_0.TrueTypeFont.Panose;
		}
	}

	public float EmSize => float_0;

	public FontStyle Style => fontStyle_0;

	public bool Available => bool_0;

	public bool NeedBoldEmulation => bool_1;

	public float SizeInPoints
	{
		get
		{
			if (font_0.Unit != GraphicsUnit.Point)
			{
				throw new Exception("Only Point graphics units are supported.");
			}
			return float_0;
		}
	}

	public Class5999 DrawingFont
	{
		get
		{
			if (class5999_0 == null)
			{
				class5999_0 = class54_0.method_2(string_0, float_0 * 4f / 3f, fontStyle_0, null);
			}
			return class5999_0;
		}
	}

	public float SmallCapsScaleFactor
	{
		get
		{
			float num = DrawingFont.SmallCapsScaleFactor;
			if (num == 0f)
			{
				Class6730 trueTypeFont = DrawingFont.TrueTypeFont;
				float num2 = trueTypeFont.CapHeight * 1000;
				float num3 = trueTypeFont.XHeight * 1000;
				num = (num3 + num3 * 0.1f) / num2;
			}
			return num;
		}
	}

	~Class733()
	{
		if (font_0 != null)
		{
			font_0.Dispose();
			font_0 = null;
		}
	}

	public Class733(Class54 fontsManager, string fontFamily, Enum1 charSet, int pitchFamily, float emSize, FontStyle style)
	{
		if (fontFamily == null)
		{
			fontFamily = "";
		}
		float_0 = emSize;
		enum1_0 = charSet;
		int_0 = pitchFamily;
		Class6730 @class = fontsManager.method_1(fontFamily, style);
		bool_0 = @class != null;
		if (!bool_0 && fontFamily.ToLower() == "arial narrow bold")
		{
			style |= FontStyle.Bold;
			@class = fontsManager.method_1("Arial Narrow", style);
			bool_0 = @class != null;
			if (bool_0)
			{
				fontFamily = "Arial Narrow";
			}
		}
		if (!bool_0 && !fontFamily.ToLower().EndsWith("unicode"))
		{
			@class = fontsManager.method_1(fontFamily + " Unicode", style);
			bool_0 = @class != null;
			if (bool_0)
			{
				fontFamily += " Unicode";
			}
		}
		if (@class != null)
		{
			FontStyle fontStyle = (@class.Style ^ style) & (FontStyle.Bold | FontStyle.Italic);
			if ((fontStyle & FontStyle.Bold) == FontStyle.Bold && (style & FontStyle.Bold) == FontStyle.Bold)
			{
				bool_1 = true;
				style &= ~FontStyle.Bold;
			}
		}
		fontStyle_0 = style;
		font_0 = fontsManager.method_3(fontFamily, emSize, style);
		class5999_0 = fontsManager.method_2(fontFamily, emSize * 4f / 3f, style, null);
		string_0 = fontFamily;
		class54_0 = fontsManager;
	}

	public static Class733 smethod_0(Class54 fontsManager, string fontFamily, Enum1 charSet, int pitchFamily, float emSize, FontStyle style)
	{
		foreach (Class733 item in ilist_0)
		{
			if (item.FontFamily.Equals(fontFamily) && item.CharSet == charSet && item.PitchAndFamily == pitchFamily && Class1165.smethod_0(item.EmSize, emSize) && item.Style == style)
			{
				return item;
			}
		}
		Class733 @class = new Class733(fontsManager, fontFamily, charSet, pitchFamily, emSize, style);
		ilist_0.Add(@class);
		if (ilist_0.Count > 100)
		{
			ilist_0.RemoveAt(0);
		}
		return @class;
	}

	public int method_0(string text, int startIndex, int length)
	{
		if (!bool_0)
		{
			return 0;
		}
		int num = startIndex + length;
		int i = startIndex;
		if (class5999_0 == null)
		{
			return 0;
		}
		Class6735 glyphs = class5999_0.TrueTypeFont.Glyphs;
		for (; i < num; i++)
		{
			if (text[i] > '\u001f')
			{
				Class6734 @class = glyphs[text[i]];
				if (@class == null)
				{
					break;
				}
			}
		}
		return i;
	}

	public int method_1(string text, int startIndex, int length)
	{
		if (!bool_0)
		{
			return startIndex + length;
		}
		int num = startIndex + length;
		int i = startIndex;
		if (class5999_0 == null)
		{
			return startIndex + length;
		}
		Class6735 glyphs = class5999_0.TrueTypeFont.Glyphs;
		for (; i < num; i++)
		{
			if (text[i] > '\u001f')
			{
				Class6734 @class = glyphs[text[i]];
				if (@class != null)
				{
					break;
				}
			}
		}
		return i;
	}

	public string[] method_2(char symbol, Enum1 charset, int pitchFamily, byte[] Panose)
	{
		return class54_0.method_4(symbol, charset, pitchFamily, Panose);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class733 @class))
		{
			return false;
		}
		if (Class1165.smethod_2(FontFamily, @class.FontFamily) && Class1165.smethod_2(CharSet, @class.CharSet) && Class1165.smethod_0(PitchAndFamily, @class.PitchAndFamily) && Class1165.smethod_0(EmSize, @class.EmSize) && Style == @class.Style)
		{
			return true;
		}
		return false;
	}
}
