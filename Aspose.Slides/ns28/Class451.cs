using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class451 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("auto", "always");

	internal static readonly Class467 class467_1 = new Class467("auto", "column", "page");

	internal static readonly string string_0 = "table-row-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public Enum26 BreakAfter
	{
		get
		{
			return (Enum26)method_9(class467_1, "break-after", string_1, 0);
		}
		set
		{
			method_10(class467_1, "break-after", string_1, (int)value);
		}
	}

	public Enum26 BreakBefore
	{
		get
		{
			return (Enum26)method_9(class467_1, "break-before", string_1, 0);
		}
		set
		{
			method_10(class467_1, "break-before", string_1, (int)value);
		}
	}

	public Enum51 KeepTogether
	{
		get
		{
			return (Enum51)method_9(class467_0, "keep-together", string_1, 0);
		}
		set
		{
			method_10(class467_0, "keep-together", string_1, (int)value);
		}
	}

	public double MinRowHeight
	{
		get
		{
			return method_7("min-row-height", NamespaceURI, 0.0);
		}
		set
		{
			method_8("min-row-height", NamespaceURI, value);
		}
	}

	public bool UseOptimalRowHeight
	{
		get
		{
			return method_3("use-optimal-row-height", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("use-optimal-row-height", NamespaceURI, value);
		}
	}

	public double RowHeight
	{
		get
		{
			return method_7("row-height", NamespaceURI, 0.0);
		}
		set
		{
			method_8("row-height", NamespaceURI, value);
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

	public Class451(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
