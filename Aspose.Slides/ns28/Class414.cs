using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class414 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("lr-tb", "rl-tb", "tb-rl", "tb-lr", "lr", "rl", "tb", "page");

	internal static readonly Class467 class467_1 = new Class467("horizontal", "vertical", "both", "none");

	internal static readonly Class467 class467_2 = new Class467("ttb", "ltr");

	internal static readonly Class467 class467_3 = new Class467("landscape", "portrait");

	internal static readonly Class467 class467_4 = new Class467("headers", "grid", "annotations", "objects", "charts", "drawings", "formulas", "zero-values");

	internal static readonly Class467 class467_5 = new Class467("none", "line", "both");

	internal static readonly string string_0 = "page-layout-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	protected Class459 class459_0;

	protected Class459 class459_1;

	protected Class459 class459_2;

	protected Class459 class459_3;

	protected Class459 class459_4;

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

	public string Border
	{
		get
		{
			return GetAttribute("border", string_1);
		}
		set
		{
			SetAttribute("border", string_1, value);
		}
	}

	public string BorderBottom
	{
		get
		{
			return GetAttribute("border-bottom", string_1);
		}
		set
		{
			SetAttribute("border-bottom", string_1, value);
		}
	}

	public string BorderLeft
	{
		get
		{
			return GetAttribute("border-left", string_1);
		}
		set
		{
			SetAttribute("border-left", string_1, value);
		}
	}

	public string BorderRight
	{
		get
		{
			return GetAttribute("border-right", string_1);
		}
		set
		{
			SetAttribute("border-right", string_1, value);
		}
	}

	public string BorderTop
	{
		get
		{
			return GetAttribute("border-top", string_1);
		}
		set
		{
			SetAttribute("border-top", string_1, value);
		}
	}

	public double Margin
	{
		get
		{
			return method_7("margin", string_1, 0.0);
		}
		set
		{
			method_8("margin", string_1, value);
		}
	}

	public double MarginBottom
	{
		get
		{
			return method_7("margin-bottom", string_1, 0.0);
		}
		set
		{
			method_8("margin-bottom", string_1, value);
		}
	}

	public double MarginLeft
	{
		get
		{
			return method_7("margin-left", string_1, 0.0);
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
			return method_7("margin-right", string_1, 0.0);
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
			return method_7("margin-top", string_1, 0.0);
		}
		set
		{
			method_8("margin-top", string_1, value);
		}
	}

	public double Padding
	{
		get
		{
			return method_7("padding", string_1, 0.0);
		}
		set
		{
			method_8("padding", string_1, value);
		}
	}

	public double PaddingBottom
	{
		get
		{
			return method_7("padding-bottom", string_1, 0.0);
		}
		set
		{
			method_8("padding-bottom", string_1, value);
		}
	}

	public double PaddingLeft
	{
		get
		{
			return method_7("padding-left", string_1, 0.0);
		}
		set
		{
			method_8("padding-left", string_1, value);
		}
	}

	public double PaddingRight
	{
		get
		{
			return method_7("padding-right", string_1, 0.0);
		}
		set
		{
			method_8("padding-right", string_1, value);
		}
	}

	public double PaddingTop
	{
		get
		{
			return method_7("padding-top", string_1, 0.0);
		}
		set
		{
			method_8("padding-top", string_1, value);
		}
	}

	public double PageHeight
	{
		get
		{
			return method_7("page-height", string_1, 540.0);
		}
		set
		{
			method_8("page-height", string_1, value);
		}
	}

	public double PageWidth
	{
		get
		{
			return method_7("page-width", string_1, 720.0);
		}
		set
		{
			method_8("page-width", string_1, value);
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

	public int FirstPageNumber
	{
		get
		{
			return method_11("first-page-number", NamespaceURI, 1);
		}
		set
		{
			method_12("first-page-number", NamespaceURI, value);
		}
	}

	public double FootnoteMaxHeight
	{
		get
		{
			return method_7("footnote-max-height", NamespaceURI, 0.0);
		}
		set
		{
			method_8("footnote-max-height", NamespaceURI, value);
		}
	}

	public double LayoutGridBaseHeight
	{
		get
		{
			return method_7("layout-grid-base-height", NamespaceURI, 0.0);
		}
		set
		{
			method_8("layout-grid-base-height", NamespaceURI, value);
		}
	}

	public double LayoutGridBaseWidth
	{
		get
		{
			return method_7("layout-grid-base-width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("layout-grid-base-width", NamespaceURI, value);
		}
	}

	public Color LayoutGridColor
	{
		get
		{
			return method_16("layout-grid-color", NamespaceURI, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("layout-grid-color", NamespaceURI, value);
		}
	}

	public bool LayoutGridDisplay
	{
		get
		{
			return method_3("layout-grid-display", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("layout-grid-display", NamespaceURI, value);
		}
	}

	public int LayoutGridLines
	{
		get
		{
			return method_11("layout-grid-lines", NamespaceURI, 0);
		}
		set
		{
			method_12("layout-grid-lines", NamespaceURI, value);
		}
	}

	public Enum54 LayoutGridMode
	{
		get
		{
			return (Enum54)method_9(class467_5, "layout-grid-mode", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_5, "layout-grid-mode", NamespaceURI, (int)value);
		}
	}

	public bool LayoutGridPrint
	{
		get
		{
			return method_3("layout-grid-print", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("layout-grid-print", NamespaceURI, value);
		}
	}

	public bool LayoutGridRubyBelow
	{
		get
		{
			return method_3("layout-grid-ruby-below", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("layout-grid-ruby-below", NamespaceURI, value);
		}
	}

	public double LayoutGridRubyHeight
	{
		get
		{
			return method_7("layout-grid-ruby-height", NamespaceURI, 0.0);
		}
		set
		{
			method_8("layout-grid-ruby-height", NamespaceURI, value);
		}
	}

	public bool LayoutGridSnapTo
	{
		get
		{
			return method_3("layout-grid-snap-to", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("layout-grid-snap-to", NamespaceURI, value);
		}
	}

	public bool LayoutGridStandardMode
	{
		get
		{
			return method_3("layout-grid-standard-mode", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("layout-grid-standard-mode", NamespaceURI, value);
		}
	}

	public string NumFormat
	{
		get
		{
			return GetAttribute("num-format", NamespaceURI);
		}
		set
		{
			SetAttribute("num-format", NamespaceURI, value);
		}
	}

	public bool NumLetterSync
	{
		get
		{
			return method_3("num-letter-sync", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("num-letter-sync", NamespaceURI, value);
		}
	}

	public string NumPrefix
	{
		get
		{
			return GetAttribute("num-prefix", NamespaceURI);
		}
		set
		{
			SetAttribute("num-prefix", NamespaceURI, value);
		}
	}

	public string NumSuffix
	{
		get
		{
			return GetAttribute("num-suffix", NamespaceURI);
		}
		set
		{
			SetAttribute("num-suffix", NamespaceURI, value);
		}
	}

	public string PaperTrayName
	{
		get
		{
			return GetAttribute("paper-tray-name", NamespaceURI);
		}
		set
		{
			SetAttribute("paper-tray-name", NamespaceURI, value);
		}
	}

	public string Print
	{
		get
		{
			return GetAttribute("print", NamespaceURI);
		}
		set
		{
			SetAttribute("print", NamespaceURI, value);
		}
	}

	public Enum66 PrintOrientation
	{
		get
		{
			return (Enum66)method_9(class467_3, "print-orientation", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_3, "print-orientation", NamespaceURI, (int)value);
		}
	}

	public Enum67 PrintPageOrder
	{
		get
		{
			return (Enum67)method_9(class467_2, "print-page-order", NamespaceURI, 1);
		}
		set
		{
			method_10(class467_2, "print-page-order", NamespaceURI, (int)value);
		}
	}

	public string RegisterTruthRefStyleName
	{
		get
		{
			return GetAttribute("register-truth-ref-style-name", NamespaceURI);
		}
		set
		{
			SetAttribute("register-truth-ref-style-name", NamespaceURI, value);
		}
	}

	public int ScaleTo
	{
		get
		{
			return method_11("scale-to", NamespaceURI, 100);
		}
		set
		{
			method_12("scale-to", NamespaceURI, value);
		}
	}

	public int ScaleToPages
	{
		get
		{
			return method_11("scale-to-pages", NamespaceURI, 0);
		}
		set
		{
			method_12("scale-to-pages", NamespaceURI, value);
		}
	}

	public string Shadow
	{
		get
		{
			return GetAttribute("shadow", NamespaceURI);
		}
		set
		{
			SetAttribute("shadow", NamespaceURI, value);
		}
	}

	public Enum87 TableCentering
	{
		get
		{
			return (Enum87)method_9(class467_1, "table-centering", NamespaceURI, 3);
		}
		set
		{
			method_10(class467_1, "table-centering", NamespaceURI, (int)value);
		}
	}

	public Enum108 WritingMode
	{
		get
		{
			return (Enum108)method_9(class467_0, "writing-mode", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "writing-mode", NamespaceURI, (int)value);
		}
	}

	public Class414(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
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
}
