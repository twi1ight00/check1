using System;
using System.Drawing;
using ns218;
using ns271;

namespace ns224;

internal class Class5999
{
	private Class6730 class6730_0;

	private float float_0;

	private FontStyle fontStyle_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private Enum748 enum748_0;

	private short short_0;

	private float float_4;

	public Class6730 TrueTypeFont => class6730_0;

	public FontStyle Style => fontStyle_0;

	public bool IsBold => (fontStyle_0 & FontStyle.Bold) != 0;

	public bool IsItalic => (fontStyle_0 & FontStyle.Italic) != 0;

	public Enum748 Capitals => enum748_0;

	public float SmallCapsScaleFactor => float_4;

	public string FamilyName => class6730_0.FamilyName;

	public float SizePoints
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float AscentPoints => float_1;

	public float DescentPoints => float_2;

	public float CellHeightPoints => float_1 + float_2;

	public int AscentLis => Class5955.smethod_53(float_1);

	public int DescentLis => Class5955.smethod_53(float_2);

	public int CellHeightLis => AscentLis + DescentLis;

	public int LeadingLis => LineSpacingLis - CellHeightLis;

	public int LineSpacingLis => Class5955.smethod_53(float_3);

	public float LineSpacingPoints => float_3;

	public short StyleEx
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public Class5999(float sizePoints, FontStyle style, Class6730 trueTypeFont, Enum748 capitals)
	{
		if (trueTypeFont == null)
		{
			throw new ArgumentNullException("trueTypeFont");
		}
		class6730_0 = trueTypeFont;
		float_0 = sizePoints;
		fontStyle_0 = style;
		float_1 = class6730_0.method_4(class6730_0.Ascent, float_0);
		float_2 = class6730_0.method_4(class6730_0.Descent, float_0);
		float_3 = class6730_0.method_4(class6730_0.LineSpacing, float_0);
		enum748_0 = capitals;
		if (capitals == Enum748.const_1)
		{
			float num = class6730_0.CapHeight * 1000;
			float num2 = class6730_0.XHeight * 1000;
			num2 += num2 * 0.1f;
			float_4 = num2 / num;
		}
	}

	public Class5999(float sizePoints, FontStyle style, Class6730 trueTypeFont)
		: this(sizePoints, style, trueTypeFont, Enum748.const_0)
	{
	}

	public void method_0(Class5999 font)
	{
		class6730_0 = font.class6730_0;
		float_0 = font.float_0;
		fontStyle_0 = font.fontStyle_0;
		float_1 = font.float_1;
		float_2 = font.float_2;
		float_3 = font.float_3;
	}

	public float method_1(char c)
	{
		if (enum748_0 == Enum748.const_1 && char.IsLower(c))
		{
			c = char.ToUpperInvariant(c);
			float num = class6730_0.method_2(c, float_0);
			num *= 1000f;
			num *= float_4;
			return num / 1000f;
		}
		return class6730_0.method_2(c, float_0);
	}

	public float method_2(string text)
	{
		if (enum748_0 == Enum748.const_0)
		{
			return class6730_0.method_0(text, float_0);
		}
		return method_3(text, 0, text.Length);
	}

	public float method_3(string text, int startIndex, int charCount)
	{
		if (enum748_0 == Enum748.const_0)
		{
			return class6730_0.method_1(text, startIndex, charCount, float_0);
		}
		float num = 0f;
		Class6005 @class = new Class6005(text.Substring(startIndex, charCount));
		while (@class.MoveNext())
		{
			if (!@class.Current.IsLower)
			{
				num += class6730_0.method_0(@class.Current.Text, float_0) * 1000f;
				continue;
			}
			float num2 = class6730_0.method_0(@class.Current.Text.ToUpperInvariant(), float_0);
			num2 *= 1000f;
			num2 *= float_4;
			num += num2;
		}
		return num / 1000f;
	}

	public SizeF method_4(string text)
	{
		return new SizeF(method_2(text), CellHeightPoints);
	}

	public int method_5(char c)
	{
		return Class5955.smethod_53(method_1(c));
	}

	public int method_6(string text)
	{
		return Class5955.smethod_53(method_2(text));
	}

	public static bool smethod_0(string fontName)
	{
		return Class5964.smethod_42(fontName, "Microsoft Sans Serif");
	}
}
