using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class450 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("collapsing", "separating");

	internal static readonly Class467 class467_1 = new Class467("center", "left", "margins", "right");

	internal static readonly Class467 class467_2 = new Class467("lr-tb", "rl-tb", "tb-rl", "tb-lr", "lr", "rl", "tb", "page");

	internal static readonly Class467 class467_3 = new Class467("auto", "always");

	internal static readonly Class467 class467_4 = new Class467("auto", "column", "page");

	internal static readonly string string_0 = "table-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

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

	public Enum26 BreakAfter
	{
		get
		{
			return (Enum26)method_9(class467_4, "break-after", string_1, 0);
		}
		set
		{
			method_10(class467_4, "break-after", string_1, (int)value);
		}
	}

	public Enum26 BreakBefore
	{
		get
		{
			return (Enum26)method_9(class467_4, "break-before", string_1, 0);
		}
		set
		{
			method_10(class467_4, "break-before", string_1, (int)value);
		}
	}

	public Enum52 KeepWithNext
	{
		get
		{
			return (Enum52)method_9(class467_3, "keep-with-next", string_1, 0);
		}
		set
		{
			method_10(class467_3, "keep-with-next", string_1, (int)value);
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

	public bool MayBreakBetweenRows
	{
		get
		{
			return method_3("may-break-between-rows", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("may-break-between-rows", NamespaceURI, value);
		}
	}

	public double RelWidth
	{
		get
		{
			return method_7("rel-width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("rel-width", NamespaceURI, value);
		}
	}

	public double Width
	{
		get
		{
			return method_7("width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("width", NamespaceURI, value);
		}
	}

	public Enum109 WritingMode
	{
		get
		{
			return (Enum109)method_9(class467_2, "writing-mode", NamespaceURI, 7);
		}
		set
		{
			method_10(class467_2, "writing-mode", NamespaceURI, (int)value);
		}
	}

	public Enum85 Align
	{
		get
		{
			return (Enum85)method_9(class467_1, "align", string_2, 2);
		}
		set
		{
			method_10(class467_1, "align", string_2, (int)value);
		}
	}

	public Enum86 BorderModel
	{
		get
		{
			return (Enum86)method_9(class467_0, "align", string_2, 0);
		}
		set
		{
			method_10(class467_0, "align", string_2, (int)value);
		}
	}

	public bool Display
	{
		get
		{
			return method_3("display", string_2, defaultValue: true);
		}
		set
		{
			method_4("display", string_2, value);
		}
	}

	public Class450(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
