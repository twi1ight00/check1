using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class397 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("greyscale", "mono", "watermark", "standard");

	internal static readonly Class467 class467_1 = new Class467("top", "middle", "bottom", "justify");

	internal static readonly Class467 class467_2 = new Class467("left", "center", "right", "justify");

	internal static readonly Class467 class467_3 = new Class467("visible", "hidden");

	internal static readonly Class467 class467_4 = new Class467("miter", "round", "bevel", "middle", "none", "inherit");

	internal static readonly Class467 class467_5 = new Class467("none", "dash", "solid");

	internal static readonly string string_0 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_3 = "graphic-properties";

	protected Class470 class470_0;

	public Class470 FillProperties
	{
		get
		{
			return class470_0;
		}
		set
		{
			class470_0 = value;
		}
	}

	public Enum83 StrokeStyle
	{
		get
		{
			return (Enum83)method_9(class467_5, "stroke", string_0, 2);
		}
		set
		{
			method_10(class467_5, "stroke", string_0, (int)value);
		}
	}

	public string StrokeDash
	{
		get
		{
			return GetAttribute("stroke-dash", string_0);
		}
		set
		{
			SetAttribute("stroke-dash", string_0, value);
		}
	}

	public string StrokeMultipleDashes
	{
		get
		{
			return GetAttribute("stroke-dash-names", string_0);
		}
		set
		{
			SetAttribute("stroke-dash-names", string_0, value);
		}
	}

	public double StrokeWidth
	{
		get
		{
			return method_7("stroke-width", string_1, double.NaN);
		}
		set
		{
			method_8("stroke-width", string_1, value);
		}
	}

	public Color StrokeColor
	{
		get
		{
			return method_16("stroke-color", string_1, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("stroke-color", string_1, value);
		}
	}

	public string StartMarker
	{
		get
		{
			return GetAttribute("marker-start", string_0);
		}
		set
		{
			SetAttribute("marker-start", string_0, value);
		}
	}

	public string EndMarker
	{
		get
		{
			return GetAttribute("marker-end", string_0);
		}
		set
		{
			SetAttribute("marker-end", string_0, value);
		}
	}

	public double StartMarkerWidth
	{
		get
		{
			return method_7("marker-start-width", string_0, 0.3);
		}
		set
		{
			method_8("marker-start-width", string_0, value);
		}
	}

	public double EndMarkerWidth
	{
		get
		{
			return method_7("marker-end-width", string_0, 0.0);
		}
		set
		{
			method_8("marker-end-width", string_0, value);
		}
	}

	public bool AutoGrowWidth
	{
		get
		{
			return method_3("auto-grow-width", string_0, defaultValue: false);
		}
		set
		{
			method_4("auto-grow-width", string_0, value);
		}
	}

	public bool AutoGrowHeight
	{
		get
		{
			return method_3("auto-grow-height", string_0, defaultValue: false);
		}
		set
		{
			method_4("auto-grow-height", string_0, value);
		}
	}

	public bool StartMarkerCenter
	{
		get
		{
			return method_3("marker-start-center", string_0, defaultValue: false);
		}
		set
		{
			method_4("marker-start-center", string_0, value);
		}
	}

	public bool EndMarkerCenter
	{
		get
		{
			return method_3("marker-end-center", string_0, defaultValue: false);
		}
		set
		{
			method_4("marker-end-center", string_0, value);
		}
	}

	public double StrokeOpacity
	{
		get
		{
			return method_5("stroke-opacity", string_1, double.NaN);
		}
		set
		{
			method_6("stroke-opacity", string_1, value);
		}
	}

	public Enum82 StrokeLineJoin
	{
		get
		{
			return (Enum82)method_9(class467_4, "stroke-linejoin", string_0, 4);
		}
		set
		{
			method_10(class467_4, "stroke-linejoin", string_0, (int)value);
		}
	}

	public double Padding
	{
		get
		{
			return method_7("padding", string_2, double.NaN);
		}
		set
		{
			method_8("padding", string_2, value);
		}
	}

	public double PaddingTop
	{
		get
		{
			return method_7("padding-top", string_2, double.NaN);
		}
		set
		{
			method_8("padding-top", string_2, value);
		}
	}

	public double PaddingBottom
	{
		get
		{
			return method_7("padding-bottom", string_2, double.NaN);
		}
		set
		{
			method_8("padding-bottom", string_2, value);
		}
	}

	public double PaddingLeft
	{
		get
		{
			return method_7("padding-left", string_2, double.NaN);
		}
		set
		{
			method_8("padding-left", string_2, value);
		}
	}

	public double PaddingRight
	{
		get
		{
			return method_7("padding-right", string_2, double.NaN);
		}
		set
		{
			method_8("padding-right", string_2, value);
		}
	}

	public Color SymbolColor
	{
		get
		{
			return method_16("symbol-color", string_0, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("symbol-color", string_0, value);
		}
	}

	public Enum78 Shadow
	{
		get
		{
			return (Enum78)method_9(class467_3, "shadow", string_0, 1);
		}
		set
		{
			method_10(class467_3, "shadow", string_0, (int)value);
		}
	}

	public double ShadowOffsetX
	{
		get
		{
			return method_7("shadow-offset-x", string_0, 0.3);
		}
		set
		{
			method_8("shadow-offset-x", string_0, value);
		}
	}

	public double ShadowOffsetY
	{
		get
		{
			return method_7("shadow-offset-y", string_0, 0.3);
		}
		set
		{
			method_8("shadow-offset-y", string_0, value);
		}
	}

	public Color ShadowColor
	{
		get
		{
			return method_16("shadow-color", string_0, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("shadow-color", string_0, value);
		}
	}

	public int ShadowOpacity
	{
		get
		{
			return method_11("shadow-opacity", string_0, 0);
		}
		set
		{
			method_12("shadow-opacity", string_0, value);
		}
	}

	public Enum93 TextareaVerticalAlign
	{
		get
		{
			return (Enum93)method_9(class467_1, "textarea-vertical-align", string_0, 4);
		}
		set
		{
			method_10(class467_1, "textarea-vertical-align", string_0, (int)value);
		}
	}

	public Enum92 TextareaHorizontalAlign
	{
		get
		{
			return (Enum92)method_9(class467_2, "textarea-horizontal-align", string_0, 1);
		}
		set
		{
			method_10(class467_2, "textarea-horizontal-align", string_0, (int)value);
		}
	}

	public Enum28 ColorMode
	{
		get
		{
			return (Enum28)method_9(class467_0, "color-mode", string_0, 3);
		}
		set
		{
			method_10(class467_0, "color-mode", string_0, (int)value);
		}
	}

	public bool ColorInversion
	{
		get
		{
			return method_3("color-inversion", string_0, defaultValue: false);
		}
		set
		{
			method_4("color-inversion", string_0, value);
		}
	}

	public int Luminance
	{
		get
		{
			return method_11("luminance", string_0, 0);
		}
		set
		{
			method_12("luminance", string_0, value);
		}
	}

	public int Contrast
	{
		get
		{
			return method_11("contrast", string_0, 0);
		}
		set
		{
			method_12("contrast", string_0, value);
		}
	}

	public int Gamma
	{
		get
		{
			return method_11("gamma", string_0, 100);
		}
		set
		{
			method_12("gamma", string_0, value);
		}
	}

	public int Red
	{
		get
		{
			return method_11("red", string_0, 0);
		}
		set
		{
			method_12("red", string_0, value);
		}
	}

	public int Green
	{
		get
		{
			return method_11("green", string_0, 0);
		}
		set
		{
			method_12("green", string_0, value);
		}
	}

	public int Blue
	{
		get
		{
			return method_11("blue", string_0, 0);
		}
		set
		{
			method_12("blue", string_0, value);
		}
	}

	public Class397(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		class470_0 = new Class470();
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class470_0 = new Class470(this);
	}

	internal override void vmethod_1()
	{
		class470_0.Write(this);
		base.vmethod_1();
	}
}
