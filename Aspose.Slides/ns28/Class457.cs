using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class457 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("none");

	internal static readonly Class467 class467_1 = new Class467("none", "embossed", "engraved");

	internal static readonly Class467 class467_2 = new Class467("normal", "italic", "oblique");

	internal static readonly Class467 class467_3 = new Class467("latin", "asian", "complex", "ignore");

	internal static readonly Class467 class467_4 = new Class467("fixed", "variable");

	internal static readonly Class467 class467_5 = new Class467("roman", "swiss", "modern", "decorative", "script", "system");

	internal static readonly Class467 class467_6 = new Class467("none", "single", "double");

	internal static readonly Class467 class467_7 = new Class467("none", "solid", "dotted", "dash", "long-dash", "dot-dash", "dot-dot-dash", "wave");

	internal static readonly Class467 class467_8 = new Class467("none", "lowercase", "uppercase", "capitalize");

	internal static readonly Class467 class467_9 = new Class467("normal", "small-caps");

	internal static readonly string string_0 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_1 = "text-properties";

	protected double double_0;

	protected double double_1;

	protected double double_2;

	public Enum45 FontVariant
	{
		get
		{
			return (Enum45)method_9(class467_9, "font-variant", string_0, 0);
		}
		set
		{
			method_10(class467_9, "font-variant", string_0, (int)value);
		}
	}

	public Enum99 TextTransform
	{
		get
		{
			return (Enum99)method_9(class467_8, "text-transform", string_0, 0);
		}
		set
		{
			method_10(class467_8, "text-transform", string_0, (int)value);
		}
	}

	public Color TextColor
	{
		get
		{
			return method_16("color", string_0, Color.Empty);
		}
		set
		{
			method_17("color", string_0, value);
		}
	}

	public bool UseWindowFontColor
	{
		get
		{
			return method_3("use-window-font-color", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("use-window-font-color", NamespaceURI, value);
		}
	}

	public bool TextOutline
	{
		get
		{
			return method_3("text-outline", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("text-outline", NamespaceURI, value);
		}
	}

	public Enum60 TextLineThroughType
	{
		get
		{
			return (Enum60)method_9(class467_6, "text-line-through-type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_6, "text-line-through-type", NamespaceURI, (int)value);
		}
	}

	public Enum59 TextLineThroughStyleOd
	{
		get
		{
			return (Enum59)method_9(class467_7, "text-line-through-style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_7, "text-line-through-style", NamespaceURI, (int)value);
		}
	}

	public string TextPosition
	{
		get
		{
			return GetAttribute("text-position", NamespaceURI);
		}
		set
		{
			SetAttribute("text-position", NamespaceURI, value);
		}
	}

	public string FontName
	{
		get
		{
			return GetAttribute("font-name", NamespaceURI);
		}
		set
		{
			SetAttribute("font-name", NamespaceURI, value);
		}
	}

	public string FontWeight
	{
		get
		{
			return GetAttribute("font-weight", string_0);
		}
		set
		{
			SetAttribute("font-weight", string_0, value);
		}
	}

	public string FontNameAsian
	{
		get
		{
			return GetAttribute("font-name-asian", NamespaceURI);
		}
		set
		{
			SetAttribute("font-name-asian", NamespaceURI, value);
		}
	}

	public string FontNameComplex
	{
		get
		{
			return GetAttribute("font-name-complex", NamespaceURI);
		}
		set
		{
			SetAttribute("font-name-complex", NamespaceURI, value);
		}
	}

	public string FontFamily
	{
		get
		{
			return GetAttribute("font-family", string_0);
		}
		set
		{
			SetAttribute("font-family", string_0, value);
		}
	}

	public string FontFamilyAsian
	{
		get
		{
			return GetAttribute("font-family-asian", NamespaceURI);
		}
		set
		{
			SetAttribute("font-family-asian", NamespaceURI, value);
		}
	}

	public string FontFamilyComplex
	{
		get
		{
			return GetAttribute("font-family-complex", NamespaceURI);
		}
		set
		{
			SetAttribute("font-family-complex", NamespaceURI, value);
		}
	}

	public Enum41 FontFamilyGeneric
	{
		get
		{
			return (Enum41)method_9(class467_5, "font-family-generic", NamespaceURI, 5);
		}
		set
		{
			method_10(class467_5, "font-family-generic", NamespaceURI, (int)value);
		}
	}

	public Enum41 FontFamilyGenericAsian
	{
		get
		{
			return (Enum41)method_9(class467_5, "font-family-generic-asian", NamespaceURI, 5);
		}
		set
		{
			method_10(class467_5, "font-family-generic-asian", NamespaceURI, (int)value);
		}
	}

	public Enum41 FontFamilyGenericComplex
	{
		get
		{
			return (Enum41)method_9(class467_5, "font-family-generic-complex", NamespaceURI, 5);
		}
		set
		{
			method_10(class467_5, "font-family-generic-complex", NamespaceURI, (int)value);
		}
	}

	public string FontStyleName
	{
		get
		{
			return GetAttribute("font-style-name", NamespaceURI);
		}
		set
		{
			SetAttribute("font-style-name", NamespaceURI, value);
		}
	}

	public string FontStyleNameAsian
	{
		get
		{
			return GetAttribute("font-style-name-asian", NamespaceURI);
		}
		set
		{
			SetAttribute("font-style-name-asian", NamespaceURI, value);
		}
	}

	public string FontStyleNameComplex
	{
		get
		{
			return GetAttribute("font-style-name-complex", NamespaceURI);
		}
		set
		{
			SetAttribute("font-style-name-complex", NamespaceURI, value);
		}
	}

	public Enum42 FontPitch
	{
		get
		{
			return (Enum42)method_9(class467_4, "font-pitch", NamespaceURI, 1);
		}
		set
		{
			method_10(class467_4, "font-pitch", NamespaceURI, (int)value);
		}
	}

	public Enum42 FontPitchAsian
	{
		get
		{
			return (Enum42)method_9(class467_4, "font-pitch-asian", NamespaceURI, 1);
		}
		set
		{
			method_10(class467_4, "font-pitch-asian", NamespaceURI, (int)value);
		}
	}

	public Enum42 FontPitchComplex
	{
		get
		{
			return (Enum42)method_9(class467_4, "font-pitch-complex", NamespaceURI, 1);
		}
		set
		{
			method_10(class467_4, "font-pitch-complex", NamespaceURI, (int)value);
		}
	}

	internal string FontSizeStr
	{
		get
		{
			return GetAttribute("font-size", string_0);
		}
		set
		{
			SetAttribute("font-size", string_0, value);
		}
	}

	internal string FontSizeAsianStr
	{
		get
		{
			return GetAttribute("font-size-asian", NamespaceURI);
		}
		set
		{
			SetAttribute("font-size-asian", NamespaceURI, value);
		}
	}

	internal string FontSizeComplexStr
	{
		get
		{
			return GetAttribute("font-size-complex", NamespaceURI);
		}
		set
		{
			SetAttribute("font-size-complex", NamespaceURI, value);
		}
	}

	public double FontSize
	{
		get
		{
			return double_0;
		}
		set
		{
			FontSizeStr = method_23(value);
		}
	}

	public double FontSizePercent
	{
		set
		{
			FontSizeStr = method_24(value);
		}
	}

	public double FontSizeAsian
	{
		get
		{
			return double_0;
		}
		set
		{
			FontSizeAsianStr = method_23(value);
		}
	}

	public double FontSizeComplex
	{
		get
		{
			return double_0;
		}
		set
		{
			FontSizeComplexStr = method_23(value);
		}
	}

	public double FontSizeRel
	{
		get
		{
			return method_7("font-size", NamespaceURI, double.NaN);
		}
		set
		{
			method_8("font-size", NamespaceURI, value);
		}
	}

	public double FontSizeRelAsian
	{
		get
		{
			return method_7("font-size-asian", NamespaceURI, double.NaN);
		}
		set
		{
			method_8("font-size-asian", NamespaceURI, value);
		}
	}

	public double FontSizeRelComplex
	{
		get
		{
			return method_7("font-size-rel-complex", NamespaceURI, double.NaN);
		}
		set
		{
			method_8("font-size-rel-complex", NamespaceURI, value);
		}
	}

	public Enum74 ScriptType
	{
		get
		{
			return (Enum74)method_9(class467_3, "script-type", NamespaceURI, 2);
		}
		set
		{
			method_10(class467_3, "script-type", NamespaceURI, (int)value);
		}
	}

	internal string language
	{
		get
		{
			return GetAttribute("language", string_0);
		}
		set
		{
			SetAttribute("language", string_0, value);
		}
	}

	internal string LanguageAsian
	{
		get
		{
			return GetAttribute("language-asian", string_0);
		}
		set
		{
			SetAttribute("language-asian", string_0, value);
		}
	}

	internal string LanguageComplex
	{
		get
		{
			return GetAttribute("language-complex", string_0);
		}
		set
		{
			SetAttribute("language-complex", string_0, value);
		}
	}

	internal string Country
	{
		get
		{
			return GetAttribute("country", string_0);
		}
		set
		{
			SetAttribute("country", string_0, value);
		}
	}

	internal string CountryAsian
	{
		get
		{
			return GetAttribute("country-asian", NamespaceURI);
		}
		set
		{
			SetAttribute("country-asian", NamespaceURI, value);
		}
	}

	internal string CountryComplex
	{
		get
		{
			return GetAttribute("country-complex", NamespaceURI);
		}
		set
		{
			SetAttribute("country-complex", NamespaceURI, value);
		}
	}

	public Enum44 FontStyle
	{
		get
		{
			return (Enum44)method_9(class467_2, "font-style", string_0, 0);
		}
		set
		{
			method_10(class467_2, "font-style", string_0, (int)value);
		}
	}

	public Enum44 FontStyleAsian
	{
		get
		{
			return (Enum44)method_9(class467_2, "font-style-asian", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "font-style-asian", NamespaceURI, (int)value);
		}
	}

	public Enum44 FontStyleComplex
	{
		get
		{
			return (Enum44)method_9(class467_2, "font-style-complex", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "font-style-complex", NamespaceURI, (int)value);
		}
	}

	public Enum43 FontRelief
	{
		get
		{
			return (Enum43)method_9(class467_1, "font-relief", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_1, "font-relief", NamespaceURI, (int)value);
		}
	}

	public Enum79 TextShadow
	{
		get
		{
			return (Enum79)method_9(class467_0, "text-shadow", string_0, 0);
		}
		set
		{
			method_10(class467_0, "text-shadow", string_0, (int)value);
		}
	}

	public Enum60 TextUnderlineType
	{
		get
		{
			return (Enum60)method_9(class467_6, "text-underline-type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_6, "text-underline-type", NamespaceURI, (int)value);
		}
	}

	public Enum59 TextUnderlineStyleOd
	{
		get
		{
			return (Enum59)method_9(class467_7, "text-underline-style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_7, "text-underline-style", NamespaceURI, (int)value);
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		if (FontSizeStr != "")
		{
			double_0 = method_22(FontSizeStr);
		}
		else
		{
			double_0 = double.NaN;
		}
		if (FontSizeAsianStr != "")
		{
			double_1 = method_22(FontSizeAsianStr);
		}
		else
		{
			double_1 = double.NaN;
		}
		if (FontSizeComplexStr != "")
		{
			double_2 = method_22(FontSizeComplexStr);
		}
		else
		{
			double_2 = double.NaN;
		}
	}

	public Class457(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
