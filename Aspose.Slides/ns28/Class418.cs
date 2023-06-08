using System.Drawing;
using System.Xml;
using Aspose.Slides;

namespace ns28;

internal class Class418 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("lr-tb", "rl-tb", "tb-rl", "tb-lr", "lr", "rl", "tb", "page");

	internal static readonly Class467 class467_1 = new Class467("top", "middle", "bottom", "auto", "baseline");

	internal static readonly Class467 class467_2 = new Class467("normal", "strict");

	internal static readonly Class467 class467_3 = new Class467("simple", "hanging");

	internal static readonly Class467 class467_4 = new Class467("auto", "ideograph-alpha");

	internal static readonly Class467 class467_5 = new Class467("auto", "always");

	internal static readonly Class467 class467_6 = new Class467("none");

	internal static readonly Class467 class467_7 = new Class467("auto", "page");

	internal static readonly Class467 class467_8 = new Class467("auto", "column", "page");

	internal static readonly Class467 class467_9 = new Class467("start", "end", "left", "right", "center", "justify");

	internal static readonly Class467 class467_10 = new Class467("start", "center", "justify");

	internal static readonly Class467 class467_11 = new Class467("auto", "always");

	internal static readonly string string_0 = "paragraph-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	protected Class471 class471_0;

	protected Class459 class459_0;

	protected Class459 class459_1;

	protected Class459 class459_2;

	protected Class459 class459_3;

	protected Class459 class459_4;

	public Class471 Font => class471_0;

	public int LineHeightAtLeast
	{
		get
		{
			return method_13("line-height-at-least", NamespaceURI, 0);
		}
		set
		{
			method_15("line-height-at-least", NamespaceURI, value);
		}
	}

	public int LineSpacing
	{
		get
		{
			return method_13("line-height-at-least", NamespaceURI, 0);
		}
		set
		{
			method_15("line-height-at-least", NamespaceURI, value);
		}
	}

	public NullableBool FontIndependentLineSpacing
	{
		get
		{
			return method_1("font-independent-line-spacing", NamespaceURI, NullableBool.NotDefined);
		}
		set
		{
			method_2("font-independent-line-spacing", NamespaceURI, value);
		}
	}

	public Enum89 TextWeightComplex
	{
		get
		{
			return (Enum89)method_9(class467_10, "text-align-last", string_1, 0);
		}
		set
		{
			method_10(class467_10, "text-align-last", string_1, (int)value);
		}
	}

	public bool JustifySingleWord
	{
		get
		{
			return method_3("justify-single-word", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("justify-single-word", NamespaceURI, value);
		}
	}

	public Enum51 KeepTogether
	{
		get
		{
			return (Enum51)method_9(class467_11, "keep-together", string_1, 0);
		}
		set
		{
			method_10(class467_11, "keep-together", string_1, (int)value);
		}
	}

	public int Windows
	{
		get
		{
			return method_13("widows", string_1, 2);
		}
		set
		{
			method_15("widows", string_1, value);
		}
	}

	public int Orphans
	{
		get
		{
			return method_13("orphans", string_1, 2);
		}
		set
		{
			method_15("orphans", string_1, value);
		}
	}

	public bool RegisterTrue
	{
		get
		{
			return method_3("register-true", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("register-true", NamespaceURI, value);
		}
	}

	public double Margin
	{
		get
		{
			return method_7("margin", string_1, double.NaN);
		}
		set
		{
			method_8("margin", string_1, value);
		}
	}

	public double MarginLeft
	{
		get
		{
			return method_7("margin-left", string_1, double.NaN);
		}
		set
		{
			method_8("margin-left", string_1, value);
		}
	}

	public double MarginRight
	{
		get
		{
			return method_7("margin-right", string_1, double.NaN);
		}
		set
		{
			method_8("margin-right", string_1, value);
		}
	}

	public double MarginTop
	{
		get
		{
			return method_7("margin-top", string_1, double.NaN);
		}
		set
		{
			method_8("margin-top", string_1, value);
		}
	}

	public double MarginBottom
	{
		get
		{
			return method_7("margin-bottom", string_1, double.NaN);
		}
		set
		{
			method_8("margin-bottom", string_1, value);
		}
	}

	public double TextIndent
	{
		get
		{
			return method_7("text-indent", string_1, double.NaN);
		}
		set
		{
			method_8("text-indent", string_1, value);
		}
	}

	public bool AutoTextIndent
	{
		get
		{
			return method_3("auto-text-indent", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("auto-text-indent", NamespaceURI, value);
		}
	}

	public Enum26 BreakBefore
	{
		get
		{
			return (Enum26)method_9(class467_8, "break-before", string_1, 0);
		}
		set
		{
			method_10(class467_8, "break-before", string_1, (int)value);
		}
	}

	public Enum26 BreakAfter
	{
		get
		{
			return (Enum26)method_9(class467_8, "break-after", string_1, 0);
		}
		set
		{
			method_10(class467_8, "break-after", string_1, (int)value);
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return method_16("background-color", string_1, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("background-color", string_1, value);
		}
	}

	public double TabStopDistance
	{
		get
		{
			return method_7("tab-stop-distance", NamespaceURI, 0.0);
		}
		set
		{
			method_8("tab-stop-distance", NamespaceURI, value);
		}
	}

	public Enum50 HyphenationKeep
	{
		get
		{
			return (Enum50)method_9(class467_7, "hyphenation-keep", string_1, 0);
		}
		set
		{
			method_10(class467_7, "hyphenation-keep", string_1, (int)value);
		}
	}

	public Class459 BorderLineWidth
	{
		get
		{
			return class459_0;
		}
		set
		{
			class459_0 = value;
		}
	}

	public Class459 BorderLineWidthTop
	{
		get
		{
			return class459_1;
		}
		set
		{
			class459_1 = value;
		}
	}

	public Class459 BorderLineWidthBottom
	{
		get
		{
			return class459_2;
		}
		set
		{
			class459_2 = value;
		}
	}

	public Class459 BorderLineWidthLeft
	{
		get
		{
			return class459_3;
		}
		set
		{
			class459_3 = value;
		}
	}

	public Class459 BorderLineWidthRight
	{
		get
		{
			return class459_4;
		}
		set
		{
			class459_4 = value;
		}
	}

	public int Padding
	{
		get
		{
			return method_13("padding", string_1, 0);
		}
		set
		{
			method_15("padding", string_1, value);
		}
	}

	public int PaddingTop
	{
		get
		{
			return method_13("padding-top", string_1, 0);
		}
		set
		{
			method_15("padding-top", string_1, value);
		}
	}

	public int PaddingBottom
	{
		get
		{
			return method_13("padding-bottom", string_1, 0);
		}
		set
		{
			method_15("padding-bottom", string_1, value);
		}
	}

	public int PaddingLeft
	{
		get
		{
			return method_13("padding-left", string_1, 0);
		}
		set
		{
			method_15("padding-left", string_1, value);
		}
	}

	public int PaddingRight
	{
		get
		{
			return method_13("padding-right", string_1, 0);
		}
		set
		{
			method_15("padding-right", string_1, value);
		}
	}

	public Enum79 Shadow
	{
		get
		{
			return (Enum79)method_9(class467_6, "text-shadow", string_1, 0);
		}
		set
		{
			method_10(class467_6, "text-shadow", string_1, (int)value);
		}
	}

	public Enum52 KeepWithNext
	{
		get
		{
			return (Enum52)method_9(class467_5, "keep-with-next", string_1, 0);
		}
		set
		{
			method_10(class467_5, "keep-with-next", string_1, (int)value);
		}
	}

	public bool NumberLines
	{
		get
		{
			return method_3("number-lines", string_2, defaultValue: false);
		}
		set
		{
			method_4("number-lines", string_2, value);
		}
	}

	public int LineNumber
	{
		get
		{
			return method_13("line-number", string_2, 0);
		}
		set
		{
			method_15("line-number", string_2, value);
		}
	}

	public Enum94 TextAutospace
	{
		get
		{
			return (Enum94)method_9(class467_4, "text-autospace", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_4, "text-autospace", NamespaceURI, (int)value);
		}
	}

	public Enum70 PunctuationWrap
	{
		get
		{
			return (Enum70)method_9(class467_3, "punctuation-wrap", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_3, "punctuation-wrap", NamespaceURI, (int)value);
		}
	}

	public Enum58 LineBreak
	{
		get
		{
			return (Enum58)method_9(class467_2, "line-break", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "line-break", NamespaceURI, (int)value);
		}
	}

	public Enum105 VerticalAlign
	{
		get
		{
			return (Enum105)method_9(class467_2, "vertical-align", NamespaceURI, 3);
		}
		set
		{
			method_10(class467_2, "vertical-align", NamespaceURI, (int)value);
		}
	}

	public Enum109 WritingMode
	{
		get
		{
			return (Enum109)method_9(class467_0, "writing-mode", NamespaceURI, 7);
		}
		set
		{
			method_10(class467_0, "writing-mode", NamespaceURI, (int)value);
		}
	}

	public bool WritingModeAutomatic
	{
		get
		{
			return method_3("writing-mode-automatic", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("writing-mode-automatic", NamespaceURI, value);
		}
	}

	public bool SnapToLayoutGrid
	{
		get
		{
			return method_3("snap-to-layout-grid", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("snap-to-layout-grid", NamespaceURI, value);
		}
	}

	public int BackgroundTransparency
	{
		get
		{
			return method_11("background-transparency", NamespaceURI, 0);
		}
		set
		{
			method_12("background-transparency", NamespaceURI, value);
		}
	}

	public int PageNumber
	{
		get
		{
			return method_13("page-number", NamespaceURI, 0);
		}
		set
		{
			method_15("page-number", NamespaceURI, value);
		}
	}

	public Enum91 TextAlign
	{
		get
		{
			return (Enum91)method_9(class467_9, "text-align", string_1, 6);
		}
		set
		{
			method_10(class467_9, "text-align", string_1, (int)value);
		}
	}

	public double LineHeight
	{
		get
		{
			return method_11("line-height", string_1, 100);
		}
		set
		{
			method_12("line-height", string_1, (int)value);
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class471_0 = new Class471(this);
		class459_0 = new Class459(this, "border-line-width");
		class459_1 = new Class459(this, "border-line-width-top");
		class459_2 = new Class459(this, "border-line-width-bottom");
		class459_3 = new Class459(this, "border-line-width-left");
		class459_4 = new Class459(this, "border-line-width-right");
	}

	internal override void vmethod_1()
	{
		base.vmethod_1();
	}

	public Class418(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
