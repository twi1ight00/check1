using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ns286;

internal class Class6880 : IEnumerable, IEnumerable<Class6879>
{
	private class Class6881
	{
		private char char_0;

		private int int_0;

		private IList<Class6879> ilist_0;

		private Hashtable hashtable_0;

		private bool bool_0;

		private Class6879 class6879_0;

		private bool bool_1;

		public char Symbol => char_0;

		public bool IsEndNode
		{
			get
			{
				if (!bool_1)
				{
					Initialize();
				}
				return bool_0;
			}
		}

		public Class6881(char symbol, int index)
		{
			char_0 = symbol;
			int_0 = index;
			ilist_0 = new List<Class6879>();
		}

		public void Add(Class6879 entity)
		{
			ilist_0.Add(entity);
		}

		public bool method_0(Class6882 text, out Class6879 characterEntity)
		{
			if (!bool_1)
			{
				Initialize();
			}
			if (bool_0)
			{
				characterEntity = class6879_0;
				return true;
			}
			characterEntity = null;
			if (!hashtable_0.ContainsKey(text.Current))
			{
				return false;
			}
			Class6881 @class = (Class6881)hashtable_0[text.Current];
			if (@class.IsEndNode)
			{
				characterEntity = @class.class6879_0;
				return true;
			}
			if (!text.MoveNext())
			{
				return false;
			}
			return @class.method_0(text, out characterEntity);
		}

		private void Initialize()
		{
			if (!bool_1)
			{
				hashtable_0 = smethod_0(ilist_0, int_0 + 1, out bool_0, out class6879_0);
				bool_1 = true;
			}
		}

		public static Hashtable smethod_0(IList<Class6879> entities, int index, out bool isEndNode, out Class6879 characterEntity)
		{
			Hashtable hashtable = new Hashtable();
			foreach (Class6879 entity in entities)
			{
				if (index < entity.Entity.Length)
				{
					char c = entity.Entity[index];
					Class6881 @class;
					if (!hashtable.ContainsKey(c))
					{
						@class = new Class6881(c, index);
						hashtable.Add(c, @class);
					}
					else
					{
						@class = (Class6881)hashtable[c];
					}
					@class.Add(entity);
					continue;
				}
				isEndNode = true;
				characterEntity = entity;
				return hashtable;
			}
			isEndNode = false;
			characterEntity = null;
			return hashtable;
		}
	}

	private class Class6882 : IDisposable, IEnumerator, IEnumerator<char>
	{
		private string string_0;

		private int int_0;

		private int int_1;

		public char Current => string_0[int_0];

		object IEnumerator.Current => Current;

		public Class6882(string text, int index)
		{
			string_0 = text;
			int_0 = (int_1 = index);
		}

		public bool MoveNext()
		{
			if (int_0 + 1 < string_0.Length)
			{
				int_0++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			int_0 = int_1;
		}

		public void Dispose()
		{
		}
	}

	private IList<Class6879> ilist_0;

	private Hashtable hashtable_0;

	private static Class6880 class6880_0;

	public static Class6880 Instance
	{
		get
		{
			if (class6880_0 == null)
			{
				class6880_0 = new Class6880();
				class6880_0.ilist_0 = smethod_0();
			}
			return class6880_0;
		}
	}

	private static IList<Class6879> smethod_0()
	{
		IList<Class6879> list = new List<Class6879>();
		list.Add(new Class6879("nbsp", "&#160;"));
		list.Add(new Class6879("iexcl", "&#161;"));
		list.Add(new Class6879("cent", "&#162;"));
		list.Add(new Class6879("pound", "&#163;"));
		list.Add(new Class6879("curren", "&#164;"));
		list.Add(new Class6879("yen", "&#165;"));
		list.Add(new Class6879("brvbar", "&#166;"));
		list.Add(new Class6879("sect", "&#167;"));
		list.Add(new Class6879("uml", "&#168;"));
		list.Add(new Class6879("copy", "&#169;"));
		list.Add(new Class6879("ordf", "&#170;"));
		list.Add(new Class6879("laquo", "&#171;"));
		list.Add(new Class6879("not", "&#172;"));
		list.Add(new Class6879("shy", "&#173;"));
		list.Add(new Class6879("reg", "&#174;"));
		list.Add(new Class6879("macr", "&#175;"));
		list.Add(new Class6879("deg", "&#176;"));
		list.Add(new Class6879("plusmn", "&#177;"));
		list.Add(new Class6879("sup2", "&#178;"));
		list.Add(new Class6879("sup3", "&#179;"));
		list.Add(new Class6879("acute", "&#180;"));
		list.Add(new Class6879("micro", "&#181;"));
		list.Add(new Class6879("para", "&#182;"));
		list.Add(new Class6879("middot", "&#183;"));
		list.Add(new Class6879("cedil", "&#184;"));
		list.Add(new Class6879("sup1", "&#185;"));
		list.Add(new Class6879("ordm", "&#186;"));
		list.Add(new Class6879("raquo", "&#187;"));
		list.Add(new Class6879("frac14", "&#188;"));
		list.Add(new Class6879("frac12", "&#189;"));
		list.Add(new Class6879("frac34", "&#190;"));
		list.Add(new Class6879("iquest", "&#191;"));
		list.Add(new Class6879("Agrave", "&#192;"));
		list.Add(new Class6879("Aacute", "&#193;"));
		list.Add(new Class6879("Acirc", "&#194;"));
		list.Add(new Class6879("Atilde", "&#195;"));
		list.Add(new Class6879("Auml", "&#196;"));
		list.Add(new Class6879("Aring", "&#197;"));
		list.Add(new Class6879("AElig", "&#198;"));
		list.Add(new Class6879("Ccedil", "&#199;"));
		list.Add(new Class6879("Egrave", "&#200;"));
		list.Add(new Class6879("Eacute", "&#201;"));
		list.Add(new Class6879("Ecirc", "&#202;"));
		list.Add(new Class6879("Euml", "&#203;"));
		list.Add(new Class6879("Igrave", "&#204;"));
		list.Add(new Class6879("Iacute", "&#205;"));
		list.Add(new Class6879("Icirc", "&#206;"));
		list.Add(new Class6879("Iuml", "&#207;"));
		list.Add(new Class6879("ETH", "&#208;"));
		list.Add(new Class6879("Ntilde", "&#209;"));
		list.Add(new Class6879("Ograve", "&#210;"));
		list.Add(new Class6879("Oacute", "&#211;"));
		list.Add(new Class6879("Ocirc", "&#212;"));
		list.Add(new Class6879("Otilde", "&#213;"));
		list.Add(new Class6879("Ouml", "&#214;"));
		list.Add(new Class6879("times", "&#215;"));
		list.Add(new Class6879("Oslash", "&#216;"));
		list.Add(new Class6879("Ugrave", "&#217;"));
		list.Add(new Class6879("Uacute", "&#218;"));
		list.Add(new Class6879("Ucirc", "&#219;"));
		list.Add(new Class6879("Uuml", "&#220;"));
		list.Add(new Class6879("Yacute", "&#221;"));
		list.Add(new Class6879("THORN", "&#222;"));
		list.Add(new Class6879("szlig", "&#223;"));
		list.Add(new Class6879("agrave", "&#224;"));
		list.Add(new Class6879("aacute", "&#225;"));
		list.Add(new Class6879("acirc", "&#226;"));
		list.Add(new Class6879("atilde", "&#227;"));
		list.Add(new Class6879("auml", "&#228;"));
		list.Add(new Class6879("aring", "&#229;"));
		list.Add(new Class6879("aelig", "&#230;"));
		list.Add(new Class6879("ccedil", "&#231;"));
		list.Add(new Class6879("egrave", "&#232;"));
		list.Add(new Class6879("eacute", "&#233;"));
		list.Add(new Class6879("ecirc", "&#234;"));
		list.Add(new Class6879("euml", "&#235;"));
		list.Add(new Class6879("igrave", "&#236;"));
		list.Add(new Class6879("iacute", "&#237;"));
		list.Add(new Class6879("icirc", "&#238;"));
		list.Add(new Class6879("iuml", "&#239;"));
		list.Add(new Class6879("eth", "&#240;"));
		list.Add(new Class6879("ntilde", "&#241;"));
		list.Add(new Class6879("ograve", "&#242;"));
		list.Add(new Class6879("oacute", "&#243;"));
		list.Add(new Class6879("ocirc", "&#244;"));
		list.Add(new Class6879("otilde", "&#245;"));
		list.Add(new Class6879("ouml", "&#246;"));
		list.Add(new Class6879("divide", "&#247;"));
		list.Add(new Class6879("oslash", "&#248;"));
		list.Add(new Class6879("ugrave", "&#249;"));
		list.Add(new Class6879("uacute", "&#250;"));
		list.Add(new Class6879("ucirc", "&#251;"));
		list.Add(new Class6879("uuml", "&#252;"));
		list.Add(new Class6879("yacute", "&#253;"));
		list.Add(new Class6879("thorn", "&#254;"));
		list.Add(new Class6879("yuml", "&#255;"));
		list.Add(new Class6879("fnof", "&#402;"));
		list.Add(new Class6879("Alpha", "&#913;"));
		list.Add(new Class6879("Beta", "&#914;"));
		list.Add(new Class6879("Gamma", "&#915;"));
		list.Add(new Class6879("Delta", "&#916;"));
		list.Add(new Class6879("Epsilon", "&#917;"));
		list.Add(new Class6879("Zeta", "&#918;"));
		list.Add(new Class6879("Eta", "&#919;"));
		list.Add(new Class6879("Theta", "&#920;"));
		list.Add(new Class6879("Iota", "&#921;"));
		list.Add(new Class6879("Kappa", "&#922;"));
		list.Add(new Class6879("Lambda", "&#923;"));
		list.Add(new Class6879("Mu", "&#924;"));
		list.Add(new Class6879("Nu", "&#925;"));
		list.Add(new Class6879("Xi", "&#926;"));
		list.Add(new Class6879("Omicron", "&#927;"));
		list.Add(new Class6879("Pi", "&#928;"));
		list.Add(new Class6879("Rho", "&#929;"));
		list.Add(new Class6879("Sigma", "&#931;"));
		list.Add(new Class6879("Tau", "&#932;"));
		list.Add(new Class6879("Upsilon", "&#933;"));
		list.Add(new Class6879("Phi", "&#934;"));
		list.Add(new Class6879("Chi", "&#935;"));
		list.Add(new Class6879("Psi", "&#936;"));
		list.Add(new Class6879("Omega", "&#937;"));
		list.Add(new Class6879("alpha", "&#945;"));
		list.Add(new Class6879("beta", "&#946;"));
		list.Add(new Class6879("gamma", "&#947;"));
		list.Add(new Class6879("delta", "&#948;"));
		list.Add(new Class6879("epsilon", "&#949;"));
		list.Add(new Class6879("zeta", "&#950;"));
		list.Add(new Class6879("eta", "&#951;"));
		list.Add(new Class6879("theta", "&#952;"));
		list.Add(new Class6879("iota", "&#953;"));
		list.Add(new Class6879("kappa", "&#954;"));
		list.Add(new Class6879("lambda", "&#955;"));
		list.Add(new Class6879("mu", "&#956;"));
		list.Add(new Class6879("nu", "&#957;"));
		list.Add(new Class6879("xi", "&#958;"));
		list.Add(new Class6879("omicron", "&#959;"));
		list.Add(new Class6879("pi", "&#960;"));
		list.Add(new Class6879("rho", "&#961;"));
		list.Add(new Class6879("sigmaf", "&#962;"));
		list.Add(new Class6879("sigma", "&#963;"));
		list.Add(new Class6879("tau", "&#964;"));
		list.Add(new Class6879("upsilon", "&#965;"));
		list.Add(new Class6879("phi", "&#966;"));
		list.Add(new Class6879("chi", "&#967;"));
		list.Add(new Class6879("psi", "&#968;"));
		list.Add(new Class6879("omega", "&#969;"));
		list.Add(new Class6879("thetasym", "&#977;"));
		list.Add(new Class6879("upsih", "&#978;"));
		list.Add(new Class6879("piv", "&#982;"));
		list.Add(new Class6879("bull", "&#8226;"));
		list.Add(new Class6879("hellip", "&#8230;"));
		list.Add(new Class6879("prime", "&#8242;"));
		list.Add(new Class6879("Prime", "&#8243;"));
		list.Add(new Class6879("oline", "&#8254;"));
		list.Add(new Class6879("frasl", "&#8260;"));
		list.Add(new Class6879("weierp", "&#8472;"));
		list.Add(new Class6879("image", "&#8465;"));
		list.Add(new Class6879("real", "&#8476;"));
		list.Add(new Class6879("trade", "&#8482;"));
		list.Add(new Class6879("alefsym", "&#8501;"));
		list.Add(new Class6879("larr", "&#8592;"));
		list.Add(new Class6879("uarr", "&#8593;"));
		list.Add(new Class6879("rarr", "&#8594;"));
		list.Add(new Class6879("darr", "&#8595;"));
		list.Add(new Class6879("harr", "&#8596;"));
		list.Add(new Class6879("crarr", "&#8629;"));
		list.Add(new Class6879("lArr", "&#8656;"));
		list.Add(new Class6879("uArr", "&#8657;"));
		list.Add(new Class6879("rArr", "&#8658;"));
		list.Add(new Class6879("dArr", "&#8659;"));
		list.Add(new Class6879("hArr", "&#8660;"));
		list.Add(new Class6879("forall", "&#8704;"));
		list.Add(new Class6879("part", "&#8706;"));
		list.Add(new Class6879("exist", "&#8707;"));
		list.Add(new Class6879("empty", "&#8709;"));
		list.Add(new Class6879("nabla", "&#8711;"));
		list.Add(new Class6879("isin", "&#8712;"));
		list.Add(new Class6879("notin", "&#8713;"));
		list.Add(new Class6879("ni", "&#8715;"));
		list.Add(new Class6879("prod", "&#8719;"));
		list.Add(new Class6879("sum", "&#8721;"));
		list.Add(new Class6879("minus", "&#8722;"));
		list.Add(new Class6879("lowast", "&#8727;"));
		list.Add(new Class6879("radic", "&#8730;"));
		list.Add(new Class6879("prop", "&#8733;"));
		list.Add(new Class6879("infin", "&#8734;"));
		list.Add(new Class6879("ang", "&#8736;"));
		list.Add(new Class6879("and", "&#8743;"));
		list.Add(new Class6879("or", "&#8744;"));
		list.Add(new Class6879("cap", "&#8745;"));
		list.Add(new Class6879("cup", "&#8746;"));
		list.Add(new Class6879("int", "&#8747;"));
		list.Add(new Class6879("there4", "&#8756;"));
		list.Add(new Class6879("sim", "&#8764;"));
		list.Add(new Class6879("cong", "&#8773;"));
		list.Add(new Class6879("asymp", "&#8776;"));
		list.Add(new Class6879("ne", "&#8800;"));
		list.Add(new Class6879("equiv", "&#8801;"));
		list.Add(new Class6879("le", "&#8804;"));
		list.Add(new Class6879("ge", "&#8805;"));
		list.Add(new Class6879("sub", "&#8834;"));
		list.Add(new Class6879("sup", "&#8835;"));
		list.Add(new Class6879("nsub", "&#8836;"));
		list.Add(new Class6879("sube", "&#8838;"));
		list.Add(new Class6879("supe", "&#8839;"));
		list.Add(new Class6879("oplus", "&#8853;"));
		list.Add(new Class6879("otimes", "&#8855;"));
		list.Add(new Class6879("perp", "&#8869;"));
		list.Add(new Class6879("sdot", "&#8901;"));
		list.Add(new Class6879("lceil", "&#8968;"));
		list.Add(new Class6879("rceil", "&#8969;"));
		list.Add(new Class6879("lfloor", "&#8970;"));
		list.Add(new Class6879("rfloor", "&#8971;"));
		list.Add(new Class6879("lang", "&#9001;"));
		list.Add(new Class6879("rang", "&#9002;"));
		list.Add(new Class6879("loz", "&#9674;"));
		list.Add(new Class6879("spades", "&#9824;"));
		list.Add(new Class6879("clubs", "&#9827;"));
		list.Add(new Class6879("hearts", "&#9829;"));
		list.Add(new Class6879("diams", "&#9830;"));
		list.Add(new Class6879("quot", "&#34;"));
		list.Add(new Class6879("amp", "&#38;"));
		list.Add(new Class6879("lt", "&#60;"));
		list.Add(new Class6879("gt", "&#62;"));
		list.Add(new Class6879("OElig", "&#338;"));
		list.Add(new Class6879("oelig", "&#339;"));
		list.Add(new Class6879("Scaron", "&#352;"));
		list.Add(new Class6879("scaron", "&#353;"));
		list.Add(new Class6879("Yuml", "&#376;"));
		list.Add(new Class6879("circ", "&#710;"));
		list.Add(new Class6879("tilde", "&#732;"));
		list.Add(new Class6879("ensp", "&#8194;"));
		list.Add(new Class6879("emsp", "&#8195;"));
		list.Add(new Class6879("thinsp", "&#8201;"));
		list.Add(new Class6879("zwnj", "&#8204;"));
		list.Add(new Class6879("zwj", "&#8205;"));
		list.Add(new Class6879("lrm", "&#8206;"));
		list.Add(new Class6879("rlm", "&#8207;"));
		list.Add(new Class6879("ndash", "&#8211;"));
		list.Add(new Class6879("mdash", "&#8212;"));
		list.Add(new Class6879("lsquo", "&#8216;"));
		list.Add(new Class6879("rsquo", "&#8217;"));
		list.Add(new Class6879("sbquo", "&#8218;"));
		list.Add(new Class6879("ldquo", "&#8220;"));
		list.Add(new Class6879("rdquo", "&#8221;"));
		list.Add(new Class6879("bdquo", "&#8222;"));
		list.Add(new Class6879("dagger", "&#8224;"));
		list.Add(new Class6879("Dagger", "&#8225;"));
		list.Add(new Class6879("permil", "&#8240;"));
		list.Add(new Class6879("lsaquo", "&#8249;"));
		list.Add(new Class6879("rsaquo", "&#8250;"));
		list.Add(new Class6879("euro", "&#8364;"));
		return list;
	}

	public IEnumerator<Class6879> GetEnumerator()
	{
		return ilist_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal string method_0()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (IEnumerator<Class6879> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class6879 current = enumerator.Current;
				stringBuilder.Append(current.method_0());
			}
		}
		return stringBuilder.ToString();
	}

	public bool method_1(string text, int index, out Class6879 entry)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = Class6881.smethod_0(ilist_0, 0, out var _, out entry);
		}
		entry = null;
		Class6882 @class = new Class6882(text, index);
		if (!@class.MoveNext())
		{
			return false;
		}
		if (!hashtable_0.ContainsKey(@class.Current))
		{
			if (@class.Current == '#')
			{
				return true;
			}
			return false;
		}
		Class6881 class2 = (Class6881)hashtable_0[@class.Current];
		if (!@class.MoveNext())
		{
			return false;
		}
		return class2.method_0(@class, out entry);
	}
}
