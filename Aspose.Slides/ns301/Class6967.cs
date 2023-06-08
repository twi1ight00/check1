using System.Collections;

namespace ns301;

internal class Class6967
{
	public const string string_0 = "&gt;";

	public const string string_1 = "&lt;";

	private static readonly string[] string_2 = new string[252]
	{
		"\"-quot", "&-amp", "<-lt", ">-gt", "\u00a0-nbsp", "¡-iexcl", "¢-cent", "£-pound", "¤-curren", "¥-yen",
		"¦-brvbar", "§-sect", "\u00a8-uml", "©-copy", "ª-ordf", "«-laquo", "¬-not", "\u00ad-shy", "®-reg", "\u00af-macr",
		"°-deg", "±-plusmn", "²-sup2", "³-sup3", "\u00b4-acute", "µ-micro", "¶-para", "·-middot", "\u00b8-cedil", "¹-sup1",
		"º-ordm", "»-raquo", "¼-frac14", "½-frac12", "¾-frac34", "¿-iquest", "À-Agrave", "Á-Aacute", "Â-Acirc", "Ã-Atilde",
		"Ä-Auml", "Å-Aring", "Æ-AElig", "Ç-Ccedil", "È-Egrave", "É-Eacute", "Ê-Ecirc", "Ë-Euml", "Ì-Igrave", "Í-Iacute",
		"Î-Icirc", "Ï-Iuml", "Ð-ETH", "Ñ-Ntilde", "Ò-Ograve", "Ó-Oacute", "Ô-Ocirc", "Õ-Otilde", "Ö-Ouml", "×-times",
		"Ø-Oslash", "Ù-Ugrave", "Ú-Uacute", "Û-Ucirc", "Ü-Uuml", "Ý-Yacute", "Þ-THORN", "ß-szlig", "à-agrave", "á-aacute",
		"â-acirc", "ã-atilde", "ä-auml", "å-aring", "æ-aelig", "ç-ccedil", "è-egrave", "é-eacute", "ê-ecirc", "ë-euml",
		"ì-igrave", "í-iacute", "î-icirc", "ï-iuml", "ð-eth", "ñ-ntilde", "ò-ograve", "ó-oacute", "ô-ocirc", "õ-otilde",
		"ö-ouml", "÷-divide", "ø-oslash", "ù-ugrave", "ú-uacute", "û-ucirc", "ü-uuml", "ý-yacute", "þ-thorn", "ÿ-yuml",
		"Œ-OElig", "œ-oelig", "Š-Scaron", "š-scaron", "Ÿ-Yuml", "ƒ-fnof", "ˆ-circ", "\u02dc-tilde", "Α-Alpha", "Β-Beta",
		"Γ-Gamma", "Δ-Delta", "Ε-Epsilon", "Ζ-Zeta", "Η-Eta", "Θ-Theta", "Ι-Iota", "Κ-Kappa", "Λ-Lambda", "Μ-Mu",
		"Ν-Nu", "Ξ-Xi", "Ο-Omicron", "Π-Pi", "Ρ-Rho", "Σ-Sigma", "Τ-Tau", "Υ-Upsilon", "Φ-Phi", "Χ-Chi",
		"Ψ-Psi", "Ω-Omega", "α-alpha", "β-beta", "γ-gamma", "δ-delta", "ε-epsilon", "ζ-zeta", "η-eta", "θ-theta",
		"ι-iota", "κ-kappa", "λ-lambda", "μ-mu", "ν-nu", "ξ-xi", "ο-omicron", "π-pi", "ρ-rho", "ς-sigmaf",
		"σ-sigma", "τ-tau", "υ-upsilon", "φ-phi", "χ-chi", "ψ-psi", "ω-omega", "ϑ-thetasym", "ϒ-upsih", "ϖ-piv",
		"\u2002-ensp", "\u2003-emsp", "\u2009-thinsp", "\u200c-zwnj", "\u200d-zwj", "\u200e-lrm", "\u200f-rlm", "–-ndash", "—-mdash", "‘-lsquo",
		"’-rsquo", "‚-sbquo", "“-ldquo", "”-rdquo", "„-bdquo", "†-dagger", "‡-Dagger", "•-bull", "…-hellip", "‰-permil",
		"′-prime", "″-Prime", "‹-lsaquo", "›-rsaquo", "‾-oline", "⁄-frasl", "€-euro", "ℑ-image", "℘-weierp", "ℜ-real",
		"™-trade", "ℵ-alefsym", "←-larr", "↑-uarr", "→-rarr", "↓-darr", "↔-harr", "↵-crarr", "⇐-lArr", "⇑-uArr",
		"⇒-rArr", "⇓-dArr", "⇔-hArr", "∀-forall", "∂-part", "∃-exist", "∅-empty", "∇-nabla", "∈-isin", "∉-notin",
		"∋-ni", "∏-prod", "∑-sum", "−-minus", "∗-lowast", "√-radic", "∝-prop", "∞-infin", "∠-ang", "∧-and",
		"∨-or", "∩-cap", "∪-cup", "∫-int", "∴-there4", "∼-sim", "≅-cong", "≈-asymp", "≠-ne", "≡-equiv",
		"≤-le", "≥-ge", "⊂-sub", "⊃-sup", "⊄-nsub", "⊆-sube", "⊇-supe", "⊕-oplus", "⊗-otimes", "⊥-perp",
		"⋅-sdot", "⌈-lceil", "⌉-rceil", "⌊-lfloor", "⌋-rfloor", "〈-lang", "〉-rang", "◊-loz", "♠-spades", "♣-clubs",
		"♥-hearts", "♦-diams"
	};

	private static Hashtable hashtable_0;

	private static readonly object object_0 = new object();

	private Class6967()
	{
	}

	internal static char smethod_0(string entity)
	{
		if (hashtable_0 == null)
		{
			lock (object_0)
			{
				if (hashtable_0 == null)
				{
					Hashtable hashtable = new Hashtable();
					for (int i = 0; i < string_2.Length; i++)
					{
						string text = string_2[i];
						hashtable[text.Substring(2)] = text[0];
					}
					hashtable_0 = hashtable;
				}
			}
		}
		object obj = hashtable_0[entity];
		if (obj != null)
		{
			return (char)obj;
		}
		return '\0';
	}
}
