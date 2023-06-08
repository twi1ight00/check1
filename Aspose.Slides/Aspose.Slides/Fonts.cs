using System.Collections;
using ns24;
using ns4;

namespace Aspose.Slides;

public class Fonts : IFonts
{
	internal class Class47
	{
		internal string string_0;

		internal string string_1;

		internal Enum2 enum2_0;

		internal Class47(string lang, string script, Enum2 fontClass)
		{
			string_0 = lang;
			string_1 = script;
			enum2_0 = fontClass;
		}
	}

	private readonly Class48 class48_0;

	private ushort? nullable_0;

	private ushort? nullable_1;

	private ushort? nullable_2;

	private Class340 class340_0 = new Class340();

	private uint uint_0;

	internal static IDictionary idictionary_0 = smethod_1(new Class47("ar-SA", "Arab", Enum2.const_2), new Class47("bg-BG", "Cyrl", Enum2.const_0), new Class47("ca-ES", "Latn", Enum2.const_0), new Class47("zh-TW", "Hant", Enum2.const_1), new Class47("cs-CZ", "Latn", Enum2.const_0), new Class47("da-DK", "Latn", Enum2.const_0), new Class47("de-DE", "Latn", Enum2.const_0), new Class47("el-GR", "Grek", Enum2.const_0), new Class47("en-US", "Latn", Enum2.const_0), new Class47("fi-FI", "Latn", Enum2.const_0), new Class47("fr-FR", "Latn", Enum2.const_0), new Class47("he-IL", "Hebr", Enum2.const_2), new Class47("hu-HU", "Latn", Enum2.const_0), new Class47("is-IS", "Latn", Enum2.const_0), new Class47("it-IT", "Latn", Enum2.const_0), new Class47("ja-JP", "Jpan", Enum2.const_1), new Class47("ko-KR", "Hang", Enum2.const_1), new Class47("nl-NL", "Latn", Enum2.const_0), new Class47("nb-NO", "Latn", Enum2.const_0), new Class47("pl-PL", "Latn", Enum2.const_0), new Class47("pt-BR", "Latn", Enum2.const_0), new Class47("ro-RO", "Latn", Enum2.const_0), new Class47("ru-RU", "Cyrl", Enum2.const_0), new Class47("hr-HR", "Latn", Enum2.const_0), new Class47("sk-SK", "Latn", Enum2.const_0), new Class47("sq-AL", "Latn", Enum2.const_0), new Class47("sv-SE", "Latn", Enum2.const_0), new Class47("th-TH", "Thai", Enum2.const_2), new Class47("tr-TR", "Latn", Enum2.const_0), new Class47("ur-PK", "Arab", Enum2.const_2), new Class47("id-ID", "Latn", Enum2.const_0), new Class47("uk-UA", "Cyrl", Enum2.const_0), new Class47("be-BY", "Cyrl", Enum2.const_0), new Class47("sl-SI", "Latn", Enum2.const_0), new Class47("et-EE", "Latn", Enum2.const_0), new Class47("lv-LV", "Latn", Enum2.const_0), new Class47("lt-LT", "Latn", Enum2.const_0), new Class47("fa-IR", "Arab", Enum2.const_2), new Class47("hy-AM", "Armn", Enum2.const_0), new Class47("az-Latn-AZ", "Latn", Enum2.const_0), new Class47("eu-ES", "Latn", Enum2.const_0), new Class47("mk-MK", "Cyrl", Enum2.const_0), new Class47("af-ZA", "Latn", Enum2.const_0), new Class47("ka-GE", "Geor", Enum2.const_0), new Class47("fo-FO", "Latn", Enum2.const_0), new Class47("hi-IN", "Deva", Enum2.const_2), new Class47("ms-MY", "Latn", Enum2.const_0), new Class47("kk-KZ", "Cyrl", Enum2.const_0), new Class47("ky-KG", "Cyrl", Enum2.const_0), new Class47("sw-KE", "Latn", Enum2.const_0), new Class47("uz-Latn-UZ", "Latn", Enum2.const_0), new Class47("tt-RU", "Cyrl", Enum2.const_0), new Class47("pa-IN", "Guru", Enum2.const_2), new Class47("gu-IN", "Gujr", Enum2.const_2), new Class47("ta-IN", "Taml", Enum2.const_2), new Class47("te-IN", "Telu", Enum2.const_2), new Class47("kn-IN", "Knda", Enum2.const_2), new Class47("mr-IN", "Deva", Enum2.const_2), new Class47("sa-IN", "Deva", Enum2.const_2), new Class47("mn-MN", "Cyrl", Enum2.const_0), new Class47("gl-ES", "Latn", Enum2.const_0), new Class47("kok-IN", "Deva", Enum2.const_2), new Class47("syr-SY", "Syrc", Enum2.const_2), new Class47("dv-MV", "Thaa", Enum2.const_2), new Class47("ar-IQ", "Arab", Enum2.const_2), new Class47("zh-CN", "Hans", Enum2.const_1), new Class47("de-CH", "Latn", Enum2.const_0), new Class47("en-GB", "Latn", Enum2.const_0), new Class47("es-MX", "Latn", Enum2.const_0), new Class47("fr-BE", "Latn", Enum2.const_0), new Class47("it-CH", "Latn", Enum2.const_0), new Class47("nl-BE", "Latn", Enum2.const_0), new Class47("nn-NO", "Latn", Enum2.const_0), new Class47("pt-PT", "Latn", Enum2.const_0), new Class47("sr-Latn-CS", "Latn", Enum2.const_0), new Class47("sv-FI", "Latn", Enum2.const_0), new Class47("az-Cyrl-AZ", "Cyrl", Enum2.const_0), new Class47("ms-BN", "Latn", Enum2.const_0), new Class47("uz-Cyrl-UZ", "Cyrl", Enum2.const_0), new Class47("ar-EG", "Arab", Enum2.const_2), new Class47("zh-HK", "Hant", Enum2.const_1), new Class47("de-AT", "Latn", Enum2.const_0), new Class47("en-AU", "Latn", Enum2.const_0), new Class47("es-ES", "Latn", Enum2.const_0), new Class47("fr-CA", "Latn", Enum2.const_0), new Class47("sr-Cyrl-CS", "Cyrl", Enum2.const_0), new Class47("ar-LY", "Arab", Enum2.const_2), new Class47("zh-SG", "Hans", Enum2.const_1), new Class47("de-LU", "Latn", Enum2.const_0), new Class47("en-CA", "Latn", Enum2.const_0), new Class47("es-GT", "Latn", Enum2.const_0), new Class47("fr-CH", "Latn", Enum2.const_0), new Class47("ar-DZ", "Arab", Enum2.const_2), new Class47("zh-MO", "Hant", Enum2.const_1), new Class47("de-LI", "Latn", Enum2.const_0), new Class47("en-NZ", "Latn", Enum2.const_0), new Class47("es-CR", "Latn", Enum2.const_0), new Class47("fr-LU", "Latn", Enum2.const_0), new Class47("ar-MA", "Arab", Enum2.const_2), new Class47("en-IE", "Latn", Enum2.const_0), new Class47("es-PA", "Latn", Enum2.const_0), new Class47("fr-MC", "Latn", Enum2.const_0), new Class47("ar-TN", "Arab", Enum2.const_2), new Class47("en-ZA", "Latn", Enum2.const_0), new Class47("es-DO", "Latn", Enum2.const_0), new Class47("ar-OM", "Arab", Enum2.const_2), new Class47("en-JM", "Latn", Enum2.const_0), new Class47("es-VE", "Latn", Enum2.const_0), new Class47("ar-YE", "Arab", Enum2.const_2), new Class47("en-029", "Latn", Enum2.const_0), new Class47("es-CO", "Latn", Enum2.const_0), new Class47("ar-SY", "Arab", Enum2.const_2), new Class47("en-BZ", "Latn", Enum2.const_0), new Class47("es-PE", "Latn", Enum2.const_0), new Class47("ar-JO", "Arab", Enum2.const_2), new Class47("en-TT", "Latn", Enum2.const_0), new Class47("es-AR", "Latn", Enum2.const_0), new Class47("ar-LB", "Arab", Enum2.const_2), new Class47("en-ZW", "Latn", Enum2.const_0), new Class47("es-EC", "Latn", Enum2.const_0), new Class47("ar-KW", "Arab", Enum2.const_2), new Class47("en-PH", "Latn", Enum2.const_0), new Class47("es-CL", "Latn", Enum2.const_0), new Class47("ar-AE", "Arab", Enum2.const_2), new Class47("es-UY", "Latn", Enum2.const_0), new Class47("ar-BH", "Arab", Enum2.const_2), new Class47("es-PY", "Latn", Enum2.const_0), new Class47("ar-QA", "Arab", Enum2.const_2), new Class47("es-BO", "Latn", Enum2.const_0), new Class47("es-SV", "Latn", Enum2.const_0), new Class47("es-HN", "Latn", Enum2.const_0), new Class47("es-NI", "Latn", Enum2.const_0), new Class47("es-PR", "Latn", Enum2.const_0), new Class47("am-ET", "Ethi", Enum2.const_0), new Class47("tzm-Latn-DZ", "Latn", Enum2.const_0), new Class47("iu-Latn-CA", "Latn", Enum2.const_0), new Class47("sma-NO", "Latn", Enum2.const_0), new Class47("mn-Mong-CN", "Mong", Enum2.const_2), new Class47("gd-GB", "Latn", Enum2.const_0), new Class47("en-MY", "Latn", Enum2.const_0), new Class47("prs-AF", "Arab", Enum2.const_2), new Class47("bn-BD", "Beng", Enum2.const_2), new Class47("wo-SN", "Latn", Enum2.const_0), new Class47("rw-RW", "Latn", Enum2.const_0), new Class47("qut-GT", "Latn", Enum2.const_0), new Class47("sah-RU", "Cyrl", Enum2.const_0), new Class47("gsw-FR", "Latn", Enum2.const_0), new Class47("co-FR", "Latn", Enum2.const_0), new Class47("oc-FR", "Latn", Enum2.const_0), new Class47("mi-NZ", "Latn", Enum2.const_0), new Class47("ga-IE", "Latn", Enum2.const_0), new Class47("se-SE", "Latn", Enum2.const_0), new Class47("br-FR", "Latn", Enum2.const_0), new Class47("smn-FI", "Latn", Enum2.const_0), new Class47("moh-CA", "Latn", Enum2.const_0), new Class47("arn-CL", "Latn", Enum2.const_0), new Class47("ii-CN", "Yiii", Enum2.const_1), new Class47("dsb-DE", "Latn", Enum2.const_0), new Class47("ig-NG", "Latn", Enum2.const_0), new Class47("kl-GL", "Latn", Enum2.const_0), new Class47("lb-LU", "Latn", Enum2.const_0), new Class47("ba-RU", "Cyrl", Enum2.const_0), new Class47("nso-ZA", "Latn", Enum2.const_0), new Class47("quz-BO", "Latn", Enum2.const_0), new Class47("yo-NG", "Latn", Enum2.const_0), new Class47("ha-Latn-NG", "Latn", Enum2.const_0), new Class47("fil-PH", "Latn", Enum2.const_0), new Class47("ps-AF", "Arab", Enum2.const_2), new Class47("fy-NL", "Latn", Enum2.const_0), new Class47("ne-NP", "Deva", Enum2.const_2), new Class47("se-NO", "Latn", Enum2.const_0), new Class47("iu-Cans-CA", "Cans", Enum2.const_0), new Class47("sr-Latn-RS", "Latn", Enum2.const_0), new Class47("si-LK", "Sinh", Enum2.const_2), new Class47("sr-Cyrl-RS", "Cyrl", Enum2.const_0), new Class47("lo-LA", "Laoo", Enum2.const_2), new Class47("km-KH", "Khmr", Enum2.const_2), new Class47("cy-GB", "Latn", Enum2.const_0), new Class47("bo-CN", "Tibt", Enum2.const_2), new Class47("sms-FI", "Latn", Enum2.const_0), new Class47("as-IN", "Beng", Enum2.const_2), new Class47("ml-IN", "Mlym", Enum2.const_2), new Class47("en-IN", "Latn", Enum2.const_0), new Class47("or-IN", "Orya", Enum2.const_2), new Class47("bn-IN", "Beng", Enum2.const_2), new Class47("tk-TM", "Latn", Enum2.const_0), new Class47("bs-Latn-BA", "Latn", Enum2.const_0), new Class47("mt-MT", "Latn", Enum2.const_0), new Class47("sr-Cyrl-ME", "Cyrl", Enum2.const_0), new Class47("se-FI", "Latn", Enum2.const_0), new Class47("zu-ZA", "Latn", Enum2.const_0), new Class47("xh-ZA", "Latn", Enum2.const_0), new Class47("tn-ZA", "Latn", Enum2.const_0), new Class47("hsb-DE", "Latn", Enum2.const_0), new Class47("bs-Cyrl-BA", "Cyrl", Enum2.const_0), new Class47("tg-Cyrl-TJ", "Cyrl", Enum2.const_0), new Class47("sr-Latn-BA", "Latn", Enum2.const_0), new Class47("smj-NO", "Latn", Enum2.const_0), new Class47("rm-CH", "Latn", Enum2.const_0), new Class47("smj-SE", "Latn", Enum2.const_0), new Class47("quz-EC", "Latn", Enum2.const_0), new Class47("quz-PE", "Latn", Enum2.const_0), new Class47("hr-BA", "Latn", Enum2.const_0), new Class47("sr-Latn-ME", "Latn", Enum2.const_0), new Class47("sma-SE", "Latn", Enum2.const_0), new Class47("en-SG", "Latn", Enum2.const_0), new Class47("sr-Cyrl-BA", "Cyrl", Enum2.const_0), new Class47("es-US", "Latn", Enum2.const_0));

	private static Hashtable hashtable_0 = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);

	internal Class340 PPTXUnsupportedProps => class340_0;

	public IFontData LatinFont
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				return null;
			}
			return class48_0.method_5(nullable_0.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_0 = class48_0.Add(Enum2.const_0, value);
			}
			method_2();
		}
	}

	public IFontData EastAsianFont
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				return null;
			}
			return class48_0.method_5(nullable_1.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_1 = class48_0.Add(Enum2.const_1, value);
			}
			method_2();
		}
	}

	public IFontData ComplexScriptFont
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				return null;
			}
			return class48_0.method_5(nullable_2.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_2 = class48_0.Add(Enum2.const_2, value);
			}
			method_2();
		}
	}

	internal uint Version => uint_0;

	internal Fonts(Class48 fontsList)
	{
		class48_0 = fontsList;
		nullable_0 = class48_0.Add(Enum2.const_0, new FontData("Arial"));
		nullable_1 = class48_0.Add(Enum2.const_1, new FontData("Arial"));
		nullable_2 = class48_0.Add(Enum2.const_2, new FontData("Arial"));
	}

	internal static Enum2 smethod_0(string lang)
	{
		if (lang != null && lang.Length != 0)
		{
			return ((Class47)idictionary_0[lang])?.enum2_0 ?? Enum2.const_0;
		}
		return Enum2.const_0;
	}

	internal string method_0(string script)
	{
		if (script != null && PPTXUnsupportedProps.Fonts.ContainsKey(script))
		{
			return PPTXUnsupportedProps.Fonts[script];
		}
		return LatinFont.FontName;
	}

	private static IDictionary smethod_1(params Class47[] rules)
	{
		IDictionary dictionary = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
		for (int i = 0; i < rules.Length; i++)
		{
			dictionary.Add(rules[i].string_0, rules[i]);
		}
		return dictionary;
	}

	internal void method_1(Fonts fonts)
	{
		nullable_0 = fonts.nullable_0;
		nullable_1 = fonts.nullable_1;
		nullable_2 = fonts.nullable_2;
		if (fonts.class340_0.ExtensionList != null)
		{
			class340_0.ExtensionList = fonts.class340_0.ExtensionList.Clone();
		}
		method_2();
	}

	private void method_2()
	{
		uint_0++;
	}
}
