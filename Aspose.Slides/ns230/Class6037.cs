using System;
using System.Collections;
using System.Text;
using ns226;
using ns229;

namespace ns230;

internal class Class6037 : Class6026
{
	internal class Class6066 : Class6056
	{
		public static Class6066 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6066(header, data);
		}

		protected Class6066(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6066(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6037(method_16(), data);
		}
	}

	private enum Enum779
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 8,
		const_3 = 10,
		const_4 = 12,
		const_5 = 16,
		const_6 = 20,
		const_7 = 24,
		const_8 = 28,
		const_9 = 32,
		const_10 = 34
	}

	private static int int_0 = 65536;

	private static int int_1 = 131072;

	private static int int_2 = 258;

	private readonly ArrayList arrayList_0 = new ArrayList();

	private static string[] string_0 = new string[258]
	{
		".notdef", ".null", "nonmarkingreturn", "space", "exclam", "quotedbl", "numbersign", "dollar", "percent", "ampersand",
		"quotesingle", "parenleft", "parenright", "asterisk", "plus", "comma", "hyphen", "period", "slash", "zero",
		"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "colon",
		"semicolon", "less", "equal", "greater", "question", "at", "A", "B", "C", "D",
		"E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
		"O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
		"Y", "Z", "bracketleft", "backslash", "bracketright", "asciicircum", "underscore", "grave", "a", "b",
		"c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
		"m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
		"w", "x", "y", "z", "braceleft", "bar", "braceright", "asciitilde", "Adieresis", "Aring",
		"Ccedilla", "Eacute", "Ntilde", "Odieresis", "Udieresis", "aacute", "agrave", "acircumflex", "adieresis", "atilde",
		"aring", "ccedilla", "eacute", "egrave", "ecircumflex", "edieresis", "iacute", "igrave", "icircumflex", "idieresis",
		"ntilde", "oacute", "ograve", "ocircumflex", "odieresis", "otilde", "uacute", "ugrave", "ucircumflex", "udieresis",
		"dagger", "degree", "cent", "sterling", "section", "bullet", "paragraph", "germandbls", "registered", "copyright",
		"trademark", "acute", "dieresis", "notequal", "AE", "Oslash", "infinity", "plusminus", "lessequal", "greaterequal",
		"yen", "mu", "partialdiff", "summation", "product", "pi", "integral", "ordfeminine", "ordmasculine", "Omega",
		"ae", "oslash", "questiondown", "exclamdown", "logicalnot", "radical", "florin", "approxequal", "Delta", "guillemotleft",
		"guillemotright", "ellipsis", "nonbreakingspace", "Agrave", "Atilde", "Otilde", "OE", "oe", "endash", "emdash",
		"quotedblleft", "quotedblright", "quoteleft", "quoteright", "divide", "lozenge", "ydieresis", "Ydieresis", "fraction", "currency",
		"guilsinglleft", "guilsinglright", "fi", "fl", "daggerdbl", "periodcentered", "quotesinglbase", "quotedblbase", "perthousand", "Acircumflex",
		"Ecircumflex", "Aacute", "Edieresis", "Egrave", "Iacute", "Icircumflex", "Idieresis", "Igrave", "Oacute", "Ocircumflex",
		"apple", "Ograve", "Uacute", "Ucircumflex", "Ugrave", "dotlessi", "circumflex", "tilde", "macron", "breve",
		"dotaccent", "ring", "cedilla", "hungarumlaut", "ogonek", "caron", "Lslash", "lslash", "Scaron", "scaron",
		"Zcaron", "zcaron", "brokenbar", "Eth", "eth", "Yacute", "yacute", "Thorn", "thorn", "minus",
		"multiply", "onesuperior", "twosuperior", "threesuperior", "onehalf", "onequarter", "threequarters", "franc", "Gbreve", "gbreve",
		"Idotaccent", "Scedilla", "scedilla", "Cacute", "cacute", "Ccaron", "ccaron", "dcroat"
	};

	private Class6037(Class6110 header, Class6016 data)
		: base(header, data)
	{
	}

	public int method_12()
	{
		return class6016_0.method_23(0);
	}

	public int method_13()
	{
		return class6016_0.method_23(4);
	}

	public int method_14()
	{
		return class6016_0.method_26(8);
	}

	public long method_15()
	{
		return class6016_0.method_19(12);
	}

	public bool method_16()
	{
		return method_15() != 0L;
	}

	public long method_17()
	{
		return class6016_0.method_19(16);
	}

	public long method_18()
	{
		return class6016_0.method_19(20);
	}

	public long method_19()
	{
		return class6016_0.method_19(24);
	}

	public long method_20()
	{
		return class6016_0.method_19(28);
	}

	public int method_21()
	{
		if (method_12() == int_0)
		{
			return int_2;
		}
		if (method_12() == int_1)
		{
			return class6016_0.method_16(32);
		}
		return -1;
	}

	public string method_22(int glyphNum)
	{
		if (glyphNum >= 0 && glyphNum < method_21())
		{
			int num = 0;
			if (method_12() == int_0)
			{
				num = glyphNum;
			}
			else if (method_12() == int_1)
			{
				num = class6016_0.method_16(34 + 2 * glyphNum);
			}
			if (num < int_2)
			{
				return string_0[num];
			}
			return (string)method_23()[num - int_2];
		}
		throw new IndexOutOfRangeException();
	}

	private ArrayList method_23()
	{
		return arrayList_0;
	}

	private ArrayList method_24()
	{
		ArrayList arrayList = null;
		if (method_12() == int_1)
		{
			arrayList = new ArrayList();
			int num;
			for (int i = 34 + 2 * method_21(); i < method_2(); i += 1 + num)
			{
				num = class6016_0.method_13(i);
				byte[] array = new byte[num];
				class6016_0.method_14(i + 1, array, 0, num);
				try
				{
					Encoding encoding = Encoding.GetEncoding("iso-8859-1");
					arrayList.Add(encoding.GetString(array));
				}
				catch (ArgumentException)
				{
				}
			}
		}
		else if (method_12() == int_0)
		{
			throw new InvalidOperationException("Not meaningful to parse version 1 table");
		}
		return arrayList;
	}
}
