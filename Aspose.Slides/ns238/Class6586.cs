using System.Collections;
using ns218;
using ns271;

namespace ns238;

internal class Class6586
{
	private const int int_0 = 1024;

	private Hashtable hashtable_0;

	private char[] char_0;

	private Class6733 class6733_0;

	private Class6730 class6730_0;

	public char[] Chars
	{
		get
		{
			if (char_0 == null)
			{
				hashtable_0 = class6733_0.method_3();
				char_0 = new char[hashtable_0.Count];
				for (int i = 0; i < hashtable_0.Count; i++)
				{
					char_0[i] = (char)class6733_0.CharsToNewGlyphIndexes.method_4(class6733_0.CharsToNewGlyphIndexes.method_6(i));
				}
				smethod_0(char_0);
			}
			return char_0;
		}
	}

	public short Ascent => method_5(class6730_0.Ascent, 1024f);

	public short Descent => method_5(class6730_0.Descent, 1024f);

	public short Leading => Descent;

	public Class6586(Class6730 font)
	{
		class6730_0 = font;
		class6733_0 = new Class6733(font, isFullEmbedding: false);
	}

	public void method_0(string text)
	{
		for (int i = 0; i < text.Length; i++)
		{
			class6733_0.method_0(text[i]);
		}
	}

	public int method_1(char c)
	{
		int result = Chars.Length - 1;
		for (int i = 0; i < Chars.Length; i++)
		{
			if (Chars[i] == c)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public Class6658 method_2(char c)
	{
		return (Class6658)hashtable_0[class6733_0.method_0(c)];
	}

	public short method_3(char c)
	{
		return method_5(class6730_0.Glyphs.method_0(c).AdvanceWidth, 1024f);
	}

	public short method_4(char c, float fontSize)
	{
		return method_5(class6730_0.Glyphs.method_0(c).AdvanceWidth, fontSize);
	}

	private short method_5(int advance, float fontSize)
	{
		return (short)Class5955.smethod_29((float)advance * fontSize / (float)class6730_0.EmHeight);
	}

	private static void smethod_0(char[] characters)
	{
		for (int i = 0; i < characters.Length; i++)
		{
			for (int j = i; j < characters.Length; j++)
			{
				if (characters[j] < characters[i])
				{
					char c = characters[i];
					characters[i] = characters[j];
					characters[j] = c;
				}
			}
		}
	}
}
