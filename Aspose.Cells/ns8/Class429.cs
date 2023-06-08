using System;
using System.Collections.Generic;
using System.Text;
using ns1;

namespace ns8;

internal class Class429
{
	public static string smethod_0(string string_0)
	{
		int length = string_0.Length;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			char c = string_0[i];
			if (c == '&' && i + 2 < length)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				while (smethod_2(string_0, i) > '\0' && smethod_2(string_0, i) != ';')
				{
					stringBuilder2.Append(smethod_2(string_0, i++));
				}
				if (smethod_2(string_0, i) == ';')
				{
					stringBuilder2.Append(';');
				}
				smethod_1(stringBuilder, stringBuilder2);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal static void smethod_1(StringBuilder stringBuilder_0, StringBuilder stringBuilder_1)
	{
		try
		{
			if (stringBuilder_1[1] == '#')
			{
				char c = stringBuilder_1[2];
				if (c != 'x' && c != 'X')
				{
					stringBuilder_0.Append((char)int.Parse(stringBuilder_1.ToString().Substring(2, stringBuilder_1.Length - 3)));
				}
				else
				{
					stringBuilder_0.Append((char)Convert.ToInt32(stringBuilder_1.ToString().Substring(3, stringBuilder_1.Length - 4), 16));
				}
			}
			else
			{
				char c2 = smethod_3(stringBuilder_1.ToString());
				if (c2 == '\0')
				{
					stringBuilder_0.Append(stringBuilder_1);
				}
				else
				{
					stringBuilder_0.Append(c2);
				}
			}
		}
		catch
		{
			stringBuilder_0.Append(stringBuilder_1);
		}
	}

	private static char smethod_2(string string_0, int int_0)
	{
		if (int_0 < string_0.Length)
		{
			return string_0[int_0];
		}
		return '\0';
	}

	internal static char smethod_3(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_1 == null)
			{
				Class1742.dictionary_1 = new Dictionary<string, int>(101)
				{
					{ "&quot;", 0 },
					{ "&apos;", 1 },
					{ "&amp;", 2 },
					{ "&lt;", 3 },
					{ "&gt;", 4 },
					{ "&nbsp;", 5 },
					{ "&iexcl;", 6 },
					{ "&cent;", 7 },
					{ "&pound;", 8 },
					{ "&curren;", 9 },
					{ "&yen;", 10 },
					{ "&brvbar;", 11 },
					{ "&sect;", 12 },
					{ "&uml;", 13 },
					{ "&copy;", 14 },
					{ "&ordf;", 15 },
					{ "&laquo;", 16 },
					{ "&not;", 17 },
					{ "&shy;", 18 },
					{ "&reg;", 19 },
					{ "&macr;", 20 },
					{ "&deg;", 21 },
					{ "&plusmn;", 22 },
					{ "&sup2;", 23 },
					{ "&sup3;", 24 },
					{ "&acute;", 25 },
					{ "&micro;", 26 },
					{ "&para;", 27 },
					{ "&middot;", 28 },
					{ "&cedil;", 29 },
					{ "&sup1;", 30 },
					{ "&ordm;", 31 },
					{ "&raquo;", 32 },
					{ "&frac14;", 33 },
					{ "&frac12;", 34 },
					{ "&frac34;", 35 },
					{ "&iquest;", 36 },
					{ "&Agrave;", 37 },
					{ "&Aacute;", 38 },
					{ "&Acirc;", 39 },
					{ "&Atilde;", 40 },
					{ "&Auml;", 41 },
					{ "&Aring;", 42 },
					{ "&AElig;", 43 },
					{ "&Ccedil;", 44 },
					{ "&Egrave;", 45 },
					{ "&Eacute;", 46 },
					{ "&Ecirc;", 47 },
					{ "&Euml;", 48 },
					{ "&Igrave;", 49 },
					{ "&Iacute;", 50 },
					{ "&Icirc;", 51 },
					{ "&Iuml;", 52 },
					{ "&ETH;", 53 },
					{ "&Ntilde;", 54 },
					{ "&Ograve;", 55 },
					{ "&Oacute;", 56 },
					{ "&Ocirc;", 57 },
					{ "&Otilde;", 58 },
					{ "&Ouml;", 59 },
					{ "&times;", 60 },
					{ "&Oslash;", 61 },
					{ "&Ugrave;", 62 },
					{ "&Uacute;", 63 },
					{ "&Ucirc;", 64 },
					{ "&Uuml;", 65 },
					{ "&Yacute;", 66 },
					{ "&THORN;", 67 },
					{ "&szlig;", 68 },
					{ "&agrave;", 69 },
					{ "&aacute;", 70 },
					{ "&acirc;", 71 },
					{ "&atilde;", 72 },
					{ "&auml;", 73 },
					{ "&aring;", 74 },
					{ "&aelig;", 75 },
					{ "&ccedil;", 76 },
					{ "&egrave;", 77 },
					{ "&eacute;", 78 },
					{ "&ecirc;", 79 },
					{ "&euml;", 80 },
					{ "&igrave;", 81 },
					{ "&iacute;", 82 },
					{ "&icirc;", 83 },
					{ "&iuml;", 84 },
					{ "&eth;", 85 },
					{ "&ntilde;", 86 },
					{ "&ograve;", 87 },
					{ "&oacute;", 88 },
					{ "&ocirc;", 89 },
					{ "&otilde;", 90 },
					{ "&ouml;", 91 },
					{ "&divide;", 92 },
					{ "&oslash;", 93 },
					{ "&ugrave;", 94 },
					{ "&uacute;", 95 },
					{ "&ucirc;", 96 },
					{ "&uuml;", 97 },
					{ "&yacute;", 98 },
					{ "&thorn;", 99 },
					{ "&yuml;", 100 }
				};
			}
			if (Class1742.dictionary_1.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return '"';
				case 1:
					return '\'';
				case 2:
					return '&';
				case 3:
					return '<';
				case 4:
					return '>';
				case 5:
					return ' ';
				case 6:
					return '¡';
				case 7:
					return '¢';
				case 8:
					return '£';
				case 9:
					return '¤';
				case 10:
					return '¥';
				case 11:
					return '¦';
				case 12:
					return '§';
				case 13:
					return '\u00a8';
				case 14:
					return '©';
				case 15:
					return 'ª';
				case 16:
					return '«';
				case 17:
					return '¬';
				case 18:
					return '\u00ad';
				case 19:
					return '®';
				case 20:
					return '\u00af';
				case 21:
					return '°';
				case 22:
					return '±';
				case 23:
					return '²';
				case 24:
					return '³';
				case 25:
					return '\u00b4';
				case 26:
					return 'µ';
				case 27:
					return '¶';
				case 28:
					return '·';
				case 29:
					return '\u00b8';
				case 30:
					return '¹';
				case 31:
					return 'º';
				case 32:
					return '»';
				case 33:
					return '¼';
				case 34:
					return '½';
				case 35:
					return '¾';
				case 36:
					return '¿';
				case 37:
					return 'À';
				case 38:
					return 'Á';
				case 39:
					return 'Â';
				case 40:
					return 'Ã';
				case 41:
					return 'Ä';
				case 42:
					return 'Å';
				case 43:
					return 'Æ';
				case 44:
					return 'Ç';
				case 45:
					return 'È';
				case 46:
					return 'É';
				case 47:
					return 'Ê';
				case 48:
					return 'Ë';
				case 49:
					return 'Ì';
				case 50:
					return 'Í';
				case 51:
					return 'Î';
				case 52:
					return 'Ï';
				case 53:
					return 'Ð';
				case 54:
					return 'Ñ';
				case 55:
					return 'Ò';
				case 56:
					return 'Ó';
				case 57:
					return 'Ô';
				case 58:
					return 'Õ';
				case 59:
					return 'Ö';
				case 60:
					return '×';
				case 61:
					return 'Ø';
				case 62:
					return 'Ù';
				case 63:
					return 'Ú';
				case 64:
					return 'Û';
				case 65:
					return 'Ü';
				case 66:
					return 'Ý';
				case 67:
					return 'Þ';
				case 68:
					return 'ß';
				case 69:
					return 'à';
				case 70:
					return 'á';
				case 71:
					return 'â';
				case 72:
					return 'ã';
				case 73:
					return 'ä';
				case 74:
					return 'å';
				case 75:
					return 'æ';
				case 76:
					return 'ç';
				case 77:
					return 'è';
				case 78:
					return 'é';
				case 79:
					return 'ê';
				case 80:
					return 'ë';
				case 81:
					return 'ì';
				case 82:
					return 'í';
				case 83:
					return 'î';
				case 84:
					return 'ï';
				case 85:
					return 'ð';
				case 86:
					return 'ñ';
				case 87:
					return 'ò';
				case 88:
					return 'ó';
				case 89:
					return 'ô';
				case 90:
					return 'õ';
				case 91:
					return 'ö';
				case 92:
					return '÷';
				case 93:
					return 'ø';
				case 94:
					return 'ù';
				case 95:
					return 'ú';
				case 96:
					return 'û';
				case 97:
					return 'ü';
				case 98:
					return 'ý';
				case 99:
					return 'þ';
				case 100:
					return 'ÿ';
				}
			}
		}
		return '\0';
	}
}
