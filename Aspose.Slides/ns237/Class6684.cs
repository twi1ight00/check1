using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ns218;
using ns224;
using ns235;
using ns271;

namespace ns237;

internal class Class6684
{
	private const float float_0 = (float)Math.PI / 9f;

	private readonly Class6672 class6672_0;

	private readonly Class6514 class6514_0;

	private bool bool_0;

	private float float_1;

	private float float_2;

	private Class6002 class6002_0;

	private string string_0;

	internal Class6684(Class6672 context, Class6514 stream)
	{
		class6672_0 = context;
		class6514_0 = stream;
	}

	internal void method_0(Class6219 glyphs)
	{
		string text = method_10(glyphs.Text);
		Enum872 @enum = ((!class6672_0.Options.FontException.Contains(glyphs.Font.FamilyName)) ? class6672_0.Options.FontEmbeddingRule : class6672_0.Options.FontException[glyphs.Font.FamilyName]);
		bool isComposite = true;
		if (Class5957.smethod_4((int)@enum, 1) && (isComposite = !Class5964.smethod_21(text)) && !Class5957.smethod_4((int)@enum, 4) && !Class5957.smethod_4((int)@enum, 2))
		{
			@enum |= Enum872.flag_1;
		}
		Class5999 @class = glyphs.Font;
		if (!smethod_2(@class, text))
		{
			@class = smethod_3(@class, text);
		}
		Class6527 pdfFont = class6672_0.Resources.method_1(@class, isComposite, @enum);
		if (glyphs.Font.Capitals == Enum748.const_0)
		{
			method_1(text, pdfFont, glyphs.Origin, 1f, isComposite, glyphs);
			return;
		}
		Class6005 class2 = new Class6005(text);
		PointF origin = glyphs.Origin;
		while (class2.MoveNext())
		{
			if (!class2.Current.IsLower)
			{
				method_1(class2.Current.Text, pdfFont, origin, 1f, isComposite, glyphs);
			}
			else
			{
				method_1(class2.Current.Text.ToUpperInvariant(), pdfFont, origin, glyphs.Font.SmallCapsScaleFactor, isComposite, glyphs);
			}
			origin.X += glyphs.Font.method_2(class2.Current.Text);
		}
	}

	private void method_1(string text, Class6527 pdfFont, PointF location, float scaleFactor, bool isComposite, Class6219 glyphs)
	{
		method_2();
		class6672_0.GraphicStateWriter.method_7(pdfFont, glyphs.Font.SizePoints, class6514_0);
		class6672_0.GraphicStateWriter.method_9(glyphs.CharSpace, class6514_0);
		method_4(pdfFont, location, scaleFactor);
		if (!(glyphs.OutlineColor != Class5998.class5998_141) && !pdfFont.IsSimulateBold)
		{
			method_7(0);
			class6672_0.GraphicStateWriter.method_5(glyphs.Color, isStroking: false, class6514_0);
		}
		else
		{
			if (glyphs.Color != Class5998.class5998_141)
			{
				method_7(2);
				class6672_0.GraphicStateWriter.method_5(glyphs.Color, isStroking: false, class6514_0);
			}
			else
			{
				method_7(1);
			}
			if (pdfFont.IsSimulateBold && glyphs.OutlineColor.IsEmpty)
			{
				float value = glyphs.Font.SizePoints / 30f;
				class6514_0.method_5("{0} w", Class6678.smethod_2(value));
				Class5998 color = ((glyphs.Color != Class5998.class5998_141) ? glyphs.Color : glyphs.OutlineColor);
				class6672_0.GraphicStateWriter.method_5(color, isStroking: true, class6514_0);
			}
			else if (!glyphs.OutlineColor.IsEmpty && pdfFont.IsSimulateBold)
			{
				class6514_0.method_5("{0} w", Class6678.smethod_2(glyphs.OutlineWidth));
				class6672_0.GraphicStateWriter.method_5(glyphs.OutlineColor, isStroking: true, class6514_0);
			}
			else if (!glyphs.OutlineColor.IsEmpty)
			{
				class6514_0.method_5("{0} w", Class6678.smethod_2(glyphs.OutlineWidth));
				class6672_0.GraphicStateWriter.method_5(glyphs.OutlineColor, isStroking: true, class6514_0);
			}
		}
		if (isComposite)
		{
			bool flag = method_8(text, (Class6530)pdfFont);
			bool flag2 = glyphs.CharSpace != 0f;
			if (!flag && !flag2)
			{
				float_1 += glyphs.Size.Width;
			}
		}
		else
		{
			method_9(text, (Class6529)pdfFont);
		}
	}

	internal void method_2()
	{
		if (!bool_0)
		{
			class6514_0.method_4("BT");
			bool_0 = true;
			string_0 = "Tj";
			class6002_0 = new Class6002();
		}
	}

	internal void method_3()
	{
		if (bool_0)
		{
			class6514_0.method_4("ET");
			bool_0 = false;
		}
	}

	private void method_4(Class6527 font, PointF location, float scaleFactor)
	{
		Class6002 @class = smethod_1(font, location);
		@class.method_5(scaleFactor, scaleFactor, MatrixOrder.Prepend);
		if (smethod_0(@class) && smethod_0(class6002_0))
		{
			if (@class.M31 == float_1 && @class.M32 == float_2)
			{
				return;
			}
			float num = @class.M31 - class6002_0.M31;
			float num2 = @class.M32 - class6002_0.M32;
			if (num == 0f)
			{
				if (num2 != class6672_0.GraphicStateWriter.GraphicState.TextLeading)
				{
					class6672_0.GraphicStateWriter.method_6(num2, class6514_0);
				}
				string_0 = "'";
			}
			else if (num2 == class6672_0.GraphicStateWriter.GraphicState.TextLeading)
			{
				class6514_0.method_6("{0} {1} Td", Class6678.smethod_2(num), Class6678.smethod_2(0f - num2));
			}
			else
			{
				class6514_0.method_6("{0} {1} TD", Class6678.smethod_2(num), Class6678.smethod_2(0f - num2));
				class6672_0.GraphicStateWriter.GraphicState.TextLeading = num2;
			}
			method_6(@class);
			class6002_0 = @class;
		}
		else
		{
			method_5(@class);
			method_6(@class);
			class6002_0 = @class;
		}
	}

	private void method_5(Class6002 matrix)
	{
		class6514_0.method_9(matrix, "Tm");
	}

	private static bool smethod_0(Class6002 matrix)
	{
		if (matrix.M11 == 1f && matrix.M12 == 0f && matrix.M21 == 0f && matrix.M22 == -1f)
		{
			return true;
		}
		return false;
	}

	private static Class6002 smethod_1(Class6527 font, PointF location)
	{
		return new Class6002(1f, 0f, font.IsSimulateItalic ? ((float)Math.PI / 9f) : 0f, -1f, location.X, location.Y);
	}

	private void method_6(Class6002 textMatrix)
	{
		float_1 = textMatrix.M31;
		float_2 = textMatrix.M32;
	}

	private void method_7(int mode)
	{
		class6672_0.GraphicStateWriter.method_8(mode, class6514_0);
	}

	private bool method_8(string text, Class6530 font)
	{
		class6514_0.Write("(");
		if (font.BaseFontName.IndexOf("MicrosoftNewTaiLue") != -1)
		{
			text = text.Replace("ᦵ", "ᦵ◌");
			text = text.Replace("ᦶ", "ᦶ◌");
			text = text.Replace("ᦷ", "ᦷ◌");
			text = text.Replace("ᦺ", "ᦺ◌");
		}
		bool result = font.method_3(text, class6514_0.Writer);
		class6514_0.method_4(")");
		class6514_0.method_4(string_0);
		string_0 = "Tj";
		return result;
	}

	internal static bool smethod_2(Class5999 font, string unicodeString)
	{
		int num = 0;
		while (true)
		{
			if (num < unicodeString.Length)
			{
				char charCode = unicodeString[num];
				Class6734 @class = font.TrueTypeFont.Glyphs.method_0(charCode);
				if (@class.Equals(font.TrueTypeFont.Glyphs.MissingGlyph))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static Class5999 smethod_3(Class5999 originalFont, string unicodeString)
	{
		Class5999 @class = null;
		if (Class6652.Instance.vmethod_0("Arial Unicode MS", originalFont.Style) != null)
		{
			@class = Class6652.Instance.method_1("Arial Unicode MS", originalFont.SizePoints, originalFont.Style);
		}
		Class5999 result = Class6652.Instance.method_1("MS Gothic", originalFont.SizePoints, originalFont.Style);
		Class5999 class2 = Class6652.Instance.method_1("Times New Roman", originalFont.SizePoints, originalFont.Style);
		if (originalFont.FamilyName == "Arial")
		{
			if (@class != null && smethod_2(@class, unicodeString))
			{
				return @class;
			}
			return result;
		}
		if (smethod_2(class2, unicodeString))
		{
			return class2;
		}
		if (@class != null && smethod_2(@class, unicodeString))
		{
			return @class;
		}
		return result;
	}

	private void method_9(string text, Class6528 font)
	{
		class6514_0.Write("(");
		font.vmethod_4(text);
		class6514_0.method_10(text);
		class6514_0.method_4(")");
		class6514_0.method_4(string_0);
		string_0 = "Tj";
	}

	private string method_10(string text)
	{
		if (text.IndexOf('\t') == -1)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < class6672_0.Options.TabSize; i++)
		{
			stringBuilder.Append(' ');
		}
		string value = stringBuilder.ToString();
		stringBuilder = new StringBuilder();
		foreach (char c in text)
		{
			if (c == '\t')
			{
				stringBuilder.Append(value);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
