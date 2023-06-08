using System.Collections;
using System.IO;
using ns101;
using ns128;
using ns146;
using ns149;

namespace ns147;

internal class Class4671 : Class4655
{
	public const string string_0 = "post";

	internal const string string_1 = "post";

	private float float_0;

	private float float_1;

	private short short_0;

	private short short_1;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private string[] string_2 = new string[258]
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

	public float Format
	{
		get
		{
			method_0();
			return float_0;
		}
	}

	public float ItalicAngle
	{
		get
		{
			method_0();
			return float_1;
		}
	}

	public short UnderlinePosition
	{
		get
		{
			method_0();
			return short_0;
		}
	}

	public short UnderlineThickness
	{
		get
		{
			method_0();
			return short_1;
		}
	}

	public uint IsFixedPitch
	{
		get
		{
			method_0();
			return uint_3;
		}
	}

	public uint MinMemType42
	{
		get
		{
			method_0();
			return uint_4;
		}
	}

	public uint MaxMemType42
	{
		get
		{
			method_0();
			return uint_5;
		}
	}

	public uint MinMemType1
	{
		get
		{
			method_0();
			return uint_6;
		}
	}

	public uint MaxMemType1
	{
		get
		{
			method_0();
			return uint_7;
		}
	}

	internal Class4671(Class4681 ttfTables, Class4411 font)
		: base(ttfTables, font)
	{
		float_0 = 3f;
		uint_3 = 0u;
	}

	internal Class4671(Class4651 context, uint checkSum, uint offset, uint length)
		: base(context, checkSum, offset, length)
	{
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
	}

	public string method_2(int glyphIndex)
	{
		method_0();
		if (!hashtable_1.ContainsKey(glyphIndex) && (float_0 == 1f || float_0 == 3f) && glyphIndex < string_2.Length)
		{
			return string_2[glyphIndex];
		}
		if (hashtable_1.ContainsKey(glyphIndex))
		{
			return (string)hashtable_1[glyphIndex];
		}
		return ".notdef";
	}

	public int method_3(string glyphName)
	{
		method_0();
		if (!hashtable_0.ContainsKey(glyphName))
		{
			return 0;
		}
		return (int)hashtable_0[glyphName];
	}

	internal override void vmethod_2(Class4689 ttfReader)
	{
		base.vmethod_2(ttfReader);
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		base.vmethod_0(ttfReader);
		ttfReader.Seek(base.Offset);
		float_0 = ttfReader.method_8();
		float_1 = ttfReader.method_8();
		short_0 = ttfReader.method_14();
		short_1 = ttfReader.method_14();
		uint_3 = ttfReader.method_19();
		uint_4 = ttfReader.method_19();
		uint_5 = ttfReader.method_19();
		uint_6 = ttfReader.method_19();
		uint_7 = ttfReader.method_19();
		if ((double)float_0 == 1.0)
		{
			return;
		}
		if ((double)float_0 == 2.0)
		{
			ushort num = ttfReader.method_18();
			if (num != base.TTFTables.MaxpTable.NumGlyphs)
			{
				Class4555.smethod_0("number of glyphs in post and maxp tables is not equal");
			}
			ushort[] array = new ushort[num];
			ushort num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ushort num3 = ttfReader.method_18();
				if (num3 >= 32768)
				{
					Class4555.smethod_0($"glyph index={i} has invalid post glyph name index = {num3}");
					num3 = 0;
				}
				array[i] = num3;
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			int num4 = ((num2 > 257) ? (num2 - 257) : 0);
			string[] array2 = new string[num4];
			for (int j = 0; j < num4; j++)
			{
				byte bytesNum = ttfReader.ReadByte();
				array2[j] = ttfReader.method_4(bytesNum, "us-ascii");
			}
			for (int k = 0; k < num; k++)
			{
				int num5 = array[k];
				if (num5 < 257 + num4)
				{
					if (num5 <= 257)
					{
						hashtable_1[k] = string_2[num5];
					}
					else
					{
						hashtable_1[k] = array2[num5 - 257 - 1];
					}
					hashtable_0[hashtable_1[k]] = k;
				}
			}
		}
		else if ((double)float_0 != 2.5 && float_0 != 3f && float_0 == 4f)
		{
			for (int l = 0; l < base.TTFTables.MaxpTable.NumGlyphs; l++)
			{
				hashtable_1[l] = $"a{ttfReader.method_18()}";
				hashtable_0[hashtable_1[l]] = l;
			}
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length, out uint checksum)
	{
		if (base.IsNewFont)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using Class4685 @class = new Class4685(stream, closeStreamOnDispose: true);
				@class.method_11(float_0);
				@class.method_11(float_1);
				@class.method_5(short_0);
				@class.method_5(short_1);
				@class.method_9(uint_3);
				@class.method_9(uint_4);
				@class.method_9(uint_5);
				@class.method_9(uint_6);
				@class.method_9(uint_7);
				if (float_0 != 2f)
				{
				}
				method_1(@class, stream, out tableBytes, out length, out checksum);
				return;
			}
		}
		base.Save(out tableBytes, out length, out checksum);
	}
}
