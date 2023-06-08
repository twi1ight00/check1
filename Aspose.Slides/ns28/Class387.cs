using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class387 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("full", "border");

	internal static readonly Class467 class467_1 = new Class467("visible", "hidden");

	internal static readonly Class467 class467_2 = new Class467("forward", "reverse");

	internal static readonly Class467 class467_3 = new Class467("slow", "medium", "fast");

	internal static readonly Class467 class467_4 = new Class467("none", "fade-from-left", "fade-from-top", "fade-from-right", "fade-from-bottom", "fade-from-upperleft", "fade-from-upperright", "fade-from-lowerleft", "fade-from-lowerright", "move-from-left", "move-from-top", "move-from-right", "move-from-bottom", "move-from-upperleft", "move-from-upperright", "move-from-lowerleft", "move-from-lowerright", "uncover-to-left", "uncover-to-top", "uncover-to-right", "uncover-to-bottom", "uncover-to-upperleft", "uncover-to-upperright", "uncover-to-lowerleft", "uncover-to-lowerright", "fade-to-center", "fade-from-center", "vertical-stripes", "horizontal-stripes", "clockwise", "counterclockwise", "open-vertical", "open-horizontal", "close-vertical", "close-horizontal", "wavyline-from-left", "wavyline-from-top", "wavyline-from-right", "wavyline-from-bottom", "spiralin-left", "spiralin-right", "spiralout-left", "spiralout-right", "roll-from-top", "roll-from-left", "roll-from-right", "roll-from-bottom", "stretch-from-left", "stretch-from-top", "stretch-from-right", "stretch-from-bottom", "vertical-lines", "horizontal-lines", "dissolve", "random", "vertical-checkerboard", "horizontal-checkerboard", "interlocking-horizontal-left", "interlocking-horizontal-right", "interlocking-vertical-top", "interlocking-vertical-bottom", "fly-away", "open", "closec", "melt");

	internal static readonly Class467 class467_5 = new Class467("manual", "automatic", "semi-automatic");

	internal static readonly string string_0 = "drawing-page-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:smil-compatible:1.0";

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

	public Enum103 TransitionType
	{
		get
		{
			return (Enum103)method_9(class467_5, "transition-type", string_1, 0);
		}
		set
		{
			method_10(class467_5, "transition-type", string_1, (int)value);
		}
	}

	public Enum102 TransitionStyle
	{
		get
		{
			return (Enum102)method_9(class467_4, "transition-style", string_1, 0);
		}
		set
		{
			method_10(class467_4, "transition-style", string_1, (int)value);
		}
	}

	public Enum101 TransitionSpeed
	{
		get
		{
			return (Enum101)method_9(class467_3, "transition-speed", string_1, 1);
		}
		set
		{
			method_10(class467_3, "transition-speed", string_1, (int)value);
		}
	}

	public string Type
	{
		get
		{
			return GetAttribute("type", string_3);
		}
		set
		{
			SetAttribute("type", string_3, value);
		}
	}

	public string SubType
	{
		get
		{
			return GetAttribute("subtype", string_3);
		}
		set
		{
			SetAttribute("subtype", string_3, value);
		}
	}

	public Enum80 Direction
	{
		get
		{
			return (Enum80)method_9(class467_2, "direction", string_3, 0);
		}
		set
		{
			method_10(class467_2, "direction", string_3, (int)value);
		}
	}

	public Color SymbolColor
	{
		get
		{
			return method_16("symbol-color", string_3, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("symbol-color", string_3, value);
		}
	}

	public Enum106 Visibility
	{
		get
		{
			return (Enum106)method_9(class467_1, "visibility", string_1, 0);
		}
		set
		{
			method_10(class467_1, "visibility", string_1, (int)value);
		}
	}

	public Enum25 BackgroundSize
	{
		get
		{
			return (Enum25)method_9(class467_0, "background-size", string_2, 0);
		}
		set
		{
			method_10(class467_0, "background-size", string_2, (int)value);
		}
	}

	public bool BackgroundObjectsVisible
	{
		get
		{
			return method_3("background-objects-visible", string_1, defaultValue: true);
		}
		set
		{
			method_4("background-objects-visible", string_1, value);
		}
	}

	public bool BackgroundVisible
	{
		get
		{
			return method_3("background-visible", string_1, defaultValue: false);
		}
		set
		{
			method_4("background-visible", string_1, value);
		}
	}

	public bool DisplayHeader
	{
		get
		{
			return method_3("display-header", string_1, defaultValue: false);
		}
		set
		{
			method_4("display-header", string_1, value);
		}
	}

	public bool DisplayFooter
	{
		get
		{
			return method_3("display-footer", string_1, defaultValue: false);
		}
		set
		{
			method_4("display-footer", string_1, value);
		}
	}

	public bool DisplayPageNumber
	{
		get
		{
			return method_3("display-page-number", string_1, defaultValue: false);
		}
		set
		{
			method_4("display-page-number", string_1, value);
		}
	}

	public bool DisplayDateTime
	{
		get
		{
			return method_3("display-date-time", string_1, defaultValue: false);
		}
		set
		{
			method_4("display-date-time", string_1, value);
		}
	}

	public Class387(string prefix, string localName, string namespaceURI, XmlDocument doc)
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
