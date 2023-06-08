using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SolrNet.Utils;

internal class HttpEncoder
{
	private static char[] hexChars;

	private static object entitiesLock;

	private static SortedDictionary<string, char> entities;

	private static HttpEncoder defaultEncoder;

	private static HttpEncoder currentEncoder;

	private static IDictionary<string, char> Entities
	{
		get
		{
			lock (entitiesLock)
			{
				if (entities == null)
				{
					InitEntities();
				}
				return entities;
			}
		}
	}

	public static HttpEncoder Current => currentEncoder;

	public static HttpEncoder Default => defaultEncoder;

	static HttpEncoder()
	{
		hexChars = "0123456789abcdef".ToCharArray();
		entitiesLock = new object();
		defaultEncoder = new HttpEncoder();
		currentEncoder = defaultEncoder;
	}

	internal static void HeaderNameValueEncode(string headerName, string headerValue, out string encodedHeaderName, out string encodedHeaderValue)
	{
		if (string.IsNullOrEmpty(headerName))
		{
			encodedHeaderName = headerName;
		}
		else
		{
			encodedHeaderName = EncodeHeaderString(headerName);
		}
		if (string.IsNullOrEmpty(headerValue))
		{
			encodedHeaderValue = headerValue;
		}
		else
		{
			encodedHeaderValue = EncodeHeaderString(headerValue);
		}
	}

	private static void StringBuilderAppend(string s, ref StringBuilder sb)
	{
		if (sb == null)
		{
			sb = new StringBuilder(s);
		}
		else
		{
			sb.Append(s);
		}
	}

	private static string EncodeHeaderString(string input)
	{
		StringBuilder sb = null;
		foreach (char ch in input)
		{
			if ((ch < ' ' && ch != '\t') || ch == '\u007f')
			{
				StringBuilderAppend($"%{(int)ch:x2}", ref sb);
			}
		}
		if (sb != null)
		{
			return sb.ToString();
		}
		return input;
	}

	internal static string UrlPathEncode(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		using MemoryStream result = new MemoryStream();
		int length = value.Length;
		for (int i = 0; i < length; i++)
		{
			UrlPathEncodeChar(value[i], result);
		}
		return Encoding.ASCII.GetString(result.ToArray());
	}

	internal static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int blen = bytes.Length;
		if (blen == 0)
		{
			return new byte[0];
		}
		if (offset < 0 || offset >= blen)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || count > blen - offset)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		using MemoryStream result = new MemoryStream(count);
		int end = offset + count;
		for (int i = offset; i < end; i++)
		{
			UrlEncodeChar((char)bytes[i], result, isUnicode: false);
		}
		return result.ToArray();
	}

	internal static string HtmlEncode(string s)
	{
		if (s == null)
		{
			return null;
		}
		if (s.Length == 0)
		{
			return string.Empty;
		}
		bool needEncode = false;
		foreach (char c in s)
		{
			if (c == '&' || c == '"' || c == '<' || c == '>' || c > '\u009f')
			{
				needEncode = true;
				break;
			}
		}
		if (!needEncode)
		{
			return s;
		}
		StringBuilder output = new StringBuilder();
		int len = s.Length;
		for (int i = 0; i < len; i++)
		{
			switch (s[i])
			{
			case '&':
				output.Append("&amp;");
				continue;
			case '>':
				output.Append("&gt;");
				continue;
			case '<':
				output.Append("&lt;");
				continue;
			case '"':
				output.Append("&quot;");
				continue;
			case '＜':
				output.Append("&#65308;");
				continue;
			case '＞':
				output.Append("&#65310;");
				continue;
			}
			char ch = s[i];
			if (ch > '\u009f' && ch < 'Ā')
			{
				output.Append("&#");
				int num = ch;
				output.Append(num.ToString(CultureInfo.InvariantCulture));
				output.Append(";");
			}
			else
			{
				output.Append(ch);
			}
		}
		return output.ToString();
	}

	internal static string HtmlAttributeEncode(string s)
	{
		if (s == null)
		{
			return null;
		}
		if (s.Length == 0)
		{
			return string.Empty;
		}
		bool needEncode = false;
		foreach (char c in s)
		{
			if (c == '&' || c == '"' || c == '<')
			{
				needEncode = true;
				break;
			}
		}
		if (!needEncode)
		{
			return s;
		}
		StringBuilder output = new StringBuilder();
		int len = s.Length;
		for (int i = 0; i < len; i++)
		{
			switch (s[i])
			{
			case '&':
				output.Append("&amp;");
				break;
			case '"':
				output.Append("&quot;");
				break;
			case '<':
				output.Append("&lt;");
				break;
			default:
				output.Append(s[i]);
				break;
			}
		}
		return output.ToString();
	}

	internal static string HtmlDecode(string s)
	{
		if (s == null)
		{
			return null;
		}
		if (s.Length == 0)
		{
			return string.Empty;
		}
		if (s.IndexOf('&') == -1)
		{
			return s;
		}
		StringBuilder entity = new StringBuilder();
		StringBuilder output = new StringBuilder();
		int len = s.Length;
		int state = 0;
		int number = 0;
		bool is_hex_value = false;
		bool have_trailing_digits = false;
		for (int i = 0; i < len; i++)
		{
			char c = s[i];
			if (state == 0)
			{
				if (c == '&')
				{
					entity.Append(c);
					state = 1;
				}
				else
				{
					output.Append(c);
				}
				continue;
			}
			if (c == '&')
			{
				state = 1;
				if (have_trailing_digits)
				{
					entity.Append(number.ToString(CultureInfo.InvariantCulture));
					have_trailing_digits = false;
				}
				output.Append(entity.ToString());
				entity.Length = 0;
				entity.Append('&');
				continue;
			}
			switch (state)
			{
			case 1:
				if (c == ';')
				{
					state = 0;
					output.Append(entity.ToString());
					output.Append(c);
					entity.Length = 0;
				}
				else
				{
					number = 0;
					is_hex_value = false;
					state = ((c == '#') ? 3 : 2);
					entity.Append(c);
				}
				break;
			case 2:
				entity.Append(c);
				if (c == ';')
				{
					string key = entity.ToString();
					if (key.Length > 1 && Entities.ContainsKey(key.Substring(1, key.Length - 2)))
					{
						key = Entities[key.Substring(1, key.Length - 2)].ToString();
					}
					output.Append(key);
					state = 0;
					entity.Length = 0;
				}
				break;
			case 3:
				if (c == ';')
				{
					if (number > 65535)
					{
						output.Append("&#");
						output.Append(number.ToString(CultureInfo.InvariantCulture));
						output.Append(";");
					}
					else
					{
						output.Append((char)number);
					}
					state = 0;
					entity.Length = 0;
					have_trailing_digits = false;
				}
				else if (is_hex_value && Uri.IsHexDigit(c))
				{
					number = number * 16 + Uri.FromHex(c);
					have_trailing_digits = true;
				}
				else if (char.IsDigit(c))
				{
					number = number * 10 + (c - 48);
					have_trailing_digits = true;
				}
				else if (number == 0 && (c == 'x' || c == 'X'))
				{
					is_hex_value = true;
				}
				else
				{
					state = 2;
					if (have_trailing_digits)
					{
						entity.Append(number.ToString(CultureInfo.InvariantCulture));
						have_trailing_digits = false;
					}
					entity.Append(c);
				}
				break;
			}
		}
		if (entity.Length > 0)
		{
			output.Append(entity.ToString());
		}
		else if (have_trailing_digits)
		{
			output.Append(number.ToString(CultureInfo.InvariantCulture));
		}
		return output.ToString();
	}

	internal static bool NotEncoded(char c)
	{
		return c == '!' || c == '(' || c == ')' || c == '*' || c == '-' || c == '.' || c == '_' || c == '\'';
	}

	internal static void UrlEncodeChar(char c, Stream result, bool isUnicode)
	{
		if (c > 'ÿ')
		{
			result.WriteByte(37);
			result.WriteByte(117);
			int idx = (int)c >> 12;
			result.WriteByte((byte)hexChars[idx]);
			idx = ((int)c >> 8) & 0xF;
			result.WriteByte((byte)hexChars[idx]);
			idx = ((int)c >> 4) & 0xF;
			result.WriteByte((byte)hexChars[idx]);
			idx = c & 0xF;
			result.WriteByte((byte)hexChars[idx]);
		}
		else if (c > ' ' && NotEncoded(c))
		{
			result.WriteByte((byte)c);
		}
		else if (c == ' ')
		{
			result.WriteByte(43);
		}
		else if (c < '0' || (c < 'A' && c > '9') || (c > 'Z' && c < 'a') || c > 'z')
		{
			if (isUnicode && c > '\u007f')
			{
				result.WriteByte(37);
				result.WriteByte(117);
				result.WriteByte(48);
				result.WriteByte(48);
			}
			else
			{
				result.WriteByte(37);
			}
			int idx = (int)c >> 4;
			result.WriteByte((byte)hexChars[idx]);
			idx = c & 0xF;
			result.WriteByte((byte)hexChars[idx]);
		}
		else
		{
			result.WriteByte((byte)c);
		}
	}

	internal static void UrlPathEncodeChar(char c, Stream result)
	{
		if (c < '!' || c > '~')
		{
			byte[] bIn = Encoding.UTF8.GetBytes(c.ToString());
			for (int i = 0; i < bIn.Length; i++)
			{
				result.WriteByte(37);
				int idx = bIn[i] >> 4;
				result.WriteByte((byte)hexChars[idx]);
				idx = bIn[i] & 0xF;
				result.WriteByte((byte)hexChars[idx]);
			}
		}
		else if (c == ' ')
		{
			result.WriteByte(37);
			result.WriteByte(50);
			result.WriteByte(48);
		}
		else
		{
			result.WriteByte((byte)c);
		}
	}

	private static void InitEntities()
	{
		entities = new SortedDictionary<string, char>(StringComparer.Ordinal);
		entities.Add("nbsp", '\u00a0');
		entities.Add("iexcl", '¡');
		entities.Add("cent", '¢');
		entities.Add("pound", '£');
		entities.Add("curren", '¤');
		entities.Add("yen", '¥');
		entities.Add("brvbar", '¦');
		entities.Add("sect", '§');
		entities.Add("uml", '\u00a8');
		entities.Add("copy", '©');
		entities.Add("ordf", 'ª');
		entities.Add("laquo", '«');
		entities.Add("not", '¬');
		entities.Add("shy", '\u00ad');
		entities.Add("reg", '®');
		entities.Add("macr", '\u00af');
		entities.Add("deg", '°');
		entities.Add("plusmn", '±');
		entities.Add("sup2", '²');
		entities.Add("sup3", '³');
		entities.Add("acute", '\u00b4');
		entities.Add("micro", 'µ');
		entities.Add("para", '¶');
		entities.Add("middot", '·');
		entities.Add("cedil", '\u00b8');
		entities.Add("sup1", '¹');
		entities.Add("ordm", 'º');
		entities.Add("raquo", '»');
		entities.Add("frac14", '¼');
		entities.Add("frac12", '½');
		entities.Add("frac34", '¾');
		entities.Add("iquest", '¿');
		entities.Add("Agrave", 'À');
		entities.Add("Aacute", 'Á');
		entities.Add("Acirc", 'Â');
		entities.Add("Atilde", 'Ã');
		entities.Add("Auml", 'Ä');
		entities.Add("Aring", 'Å');
		entities.Add("AElig", 'Æ');
		entities.Add("Ccedil", 'Ç');
		entities.Add("Egrave", 'È');
		entities.Add("Eacute", 'É');
		entities.Add("Ecirc", 'Ê');
		entities.Add("Euml", 'Ë');
		entities.Add("Igrave", 'Ì');
		entities.Add("Iacute", 'Í');
		entities.Add("Icirc", 'Î');
		entities.Add("Iuml", 'Ï');
		entities.Add("ETH", 'Ð');
		entities.Add("Ntilde", 'Ñ');
		entities.Add("Ograve", 'Ò');
		entities.Add("Oacute", 'Ó');
		entities.Add("Ocirc", 'Ô');
		entities.Add("Otilde", 'Õ');
		entities.Add("Ouml", 'Ö');
		entities.Add("times", '×');
		entities.Add("Oslash", 'Ø');
		entities.Add("Ugrave", 'Ù');
		entities.Add("Uacute", 'Ú');
		entities.Add("Ucirc", 'Û');
		entities.Add("Uuml", 'Ü');
		entities.Add("Yacute", 'Ý');
		entities.Add("THORN", 'Þ');
		entities.Add("szlig", 'ß');
		entities.Add("agrave", 'à');
		entities.Add("aacute", 'á');
		entities.Add("acirc", 'â');
		entities.Add("atilde", 'ã');
		entities.Add("auml", 'ä');
		entities.Add("aring", 'å');
		entities.Add("aelig", 'æ');
		entities.Add("ccedil", 'ç');
		entities.Add("egrave", 'è');
		entities.Add("eacute", 'é');
		entities.Add("ecirc", 'ê');
		entities.Add("euml", 'ë');
		entities.Add("igrave", 'ì');
		entities.Add("iacute", 'í');
		entities.Add("icirc", 'î');
		entities.Add("iuml", 'ï');
		entities.Add("eth", 'ð');
		entities.Add("ntilde", 'ñ');
		entities.Add("ograve", 'ò');
		entities.Add("oacute", 'ó');
		entities.Add("ocirc", 'ô');
		entities.Add("otilde", 'õ');
		entities.Add("ouml", 'ö');
		entities.Add("divide", '÷');
		entities.Add("oslash", 'ø');
		entities.Add("ugrave", 'ù');
		entities.Add("uacute", 'ú');
		entities.Add("ucirc", 'û');
		entities.Add("uuml", 'ü');
		entities.Add("yacute", 'ý');
		entities.Add("thorn", 'þ');
		entities.Add("yuml", 'ÿ');
		entities.Add("fnof", 'ƒ');
		entities.Add("Alpha", 'Α');
		entities.Add("Beta", 'Β');
		entities.Add("Gamma", 'Γ');
		entities.Add("Delta", 'Δ');
		entities.Add("Epsilon", 'Ε');
		entities.Add("Zeta", 'Ζ');
		entities.Add("Eta", 'Η');
		entities.Add("Theta", 'Θ');
		entities.Add("Iota", 'Ι');
		entities.Add("Kappa", 'Κ');
		entities.Add("Lambda", 'Λ');
		entities.Add("Mu", 'Μ');
		entities.Add("Nu", 'Ν');
		entities.Add("Xi", 'Ξ');
		entities.Add("Omicron", 'Ο');
		entities.Add("Pi", 'Π');
		entities.Add("Rho", 'Ρ');
		entities.Add("Sigma", 'Σ');
		entities.Add("Tau", 'Τ');
		entities.Add("Upsilon", 'Υ');
		entities.Add("Phi", 'Φ');
		entities.Add("Chi", 'Χ');
		entities.Add("Psi", 'Ψ');
		entities.Add("Omega", 'Ω');
		entities.Add("alpha", 'α');
		entities.Add("beta", 'β');
		entities.Add("gamma", 'γ');
		entities.Add("delta", 'δ');
		entities.Add("epsilon", 'ε');
		entities.Add("zeta", 'ζ');
		entities.Add("eta", 'η');
		entities.Add("theta", 'θ');
		entities.Add("iota", 'ι');
		entities.Add("kappa", 'κ');
		entities.Add("lambda", 'λ');
		entities.Add("mu", 'μ');
		entities.Add("nu", 'ν');
		entities.Add("xi", 'ξ');
		entities.Add("omicron", 'ο');
		entities.Add("pi", 'π');
		entities.Add("rho", 'ρ');
		entities.Add("sigmaf", 'ς');
		entities.Add("sigma", 'σ');
		entities.Add("tau", 'τ');
		entities.Add("upsilon", 'υ');
		entities.Add("phi", 'φ');
		entities.Add("chi", 'χ');
		entities.Add("psi", 'ψ');
		entities.Add("omega", 'ω');
		entities.Add("thetasym", 'ϑ');
		entities.Add("upsih", 'ϒ');
		entities.Add("piv", 'ϖ');
		entities.Add("bull", '•');
		entities.Add("hellip", '…');
		entities.Add("prime", '′');
		entities.Add("Prime", '″');
		entities.Add("oline", '‾');
		entities.Add("frasl", '⁄');
		entities.Add("weierp", '℘');
		entities.Add("image", 'ℑ');
		entities.Add("real", 'ℜ');
		entities.Add("trade", '™');
		entities.Add("alefsym", 'ℵ');
		entities.Add("larr", '←');
		entities.Add("uarr", '↑');
		entities.Add("rarr", '→');
		entities.Add("darr", '↓');
		entities.Add("harr", '↔');
		entities.Add("crarr", '↵');
		entities.Add("lArr", '⇐');
		entities.Add("uArr", '⇑');
		entities.Add("rArr", '⇒');
		entities.Add("dArr", '⇓');
		entities.Add("hArr", '⇔');
		entities.Add("forall", '∀');
		entities.Add("part", '∂');
		entities.Add("exist", '∃');
		entities.Add("empty", '∅');
		entities.Add("nabla", '∇');
		entities.Add("isin", '∈');
		entities.Add("notin", '∉');
		entities.Add("ni", '∋');
		entities.Add("prod", '∏');
		entities.Add("sum", '∑');
		entities.Add("minus", '−');
		entities.Add("lowast", '∗');
		entities.Add("radic", '√');
		entities.Add("prop", '∝');
		entities.Add("infin", '∞');
		entities.Add("ang", '∠');
		entities.Add("and", '∧');
		entities.Add("or", '∨');
		entities.Add("cap", '∩');
		entities.Add("cup", '∪');
		entities.Add("int", '∫');
		entities.Add("there4", '∴');
		entities.Add("sim", '∼');
		entities.Add("cong", '≅');
		entities.Add("asymp", '≈');
		entities.Add("ne", '≠');
		entities.Add("equiv", '≡');
		entities.Add("le", '≤');
		entities.Add("ge", '≥');
		entities.Add("sub", '⊂');
		entities.Add("sup", '⊃');
		entities.Add("nsub", '⊄');
		entities.Add("sube", '⊆');
		entities.Add("supe", '⊇');
		entities.Add("oplus", '⊕');
		entities.Add("otimes", '⊗');
		entities.Add("perp", '⊥');
		entities.Add("sdot", '⋅');
		entities.Add("lceil", '⌈');
		entities.Add("rceil", '⌉');
		entities.Add("lfloor", '⌊');
		entities.Add("rfloor", '⌋');
		entities.Add("lang", '〈');
		entities.Add("rang", '〉');
		entities.Add("loz", '◊');
		entities.Add("spades", '♠');
		entities.Add("clubs", '♣');
		entities.Add("hearts", '♥');
		entities.Add("diams", '♦');
		entities.Add("quot", '"');
		entities.Add("amp", '&');
		entities.Add("lt", '<');
		entities.Add("gt", '>');
		entities.Add("OElig", 'Œ');
		entities.Add("oelig", 'œ');
		entities.Add("Scaron", 'Š');
		entities.Add("scaron", 'š');
		entities.Add("Yuml", 'Ÿ');
		entities.Add("circ", 'ˆ');
		entities.Add("tilde", '\u02dc');
		entities.Add("ensp", '\u2002');
		entities.Add("emsp", '\u2003');
		entities.Add("thinsp", '\u2009');
		entities.Add("zwnj", '\u200c');
		entities.Add("zwj", '\u200d');
		entities.Add("lrm", '\u200e');
		entities.Add("rlm", '\u200f');
		entities.Add("ndash", '–');
		entities.Add("mdash", '—');
		entities.Add("lsquo", '‘');
		entities.Add("rsquo", '’');
		entities.Add("sbquo", '‚');
		entities.Add("ldquo", '“');
		entities.Add("rdquo", '”');
		entities.Add("bdquo", '„');
		entities.Add("dagger", '†');
		entities.Add("Dagger", '‡');
		entities.Add("permil", '‰');
		entities.Add("lsaquo", '‹');
		entities.Add("rsaquo", '›');
		entities.Add("euro", '€');
	}
}
