using System.Xml;

namespace ns28;

internal class Class441 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("auto", "column", "page");

	internal static readonly string string_0 = "table-column-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	public Enum26 BreakAfter
	{
		get
		{
			return (Enum26)method_9(class467_0, "break-after", string_1, 0);
		}
		set
		{
			method_10(class467_0, "break-after", string_1, (int)value);
		}
	}

	public Enum26 BreakBefore
	{
		get
		{
			return (Enum26)method_9(class467_0, "break-before", string_1, 0);
		}
		set
		{
			method_10(class467_0, "break-before", string_1, (int)value);
		}
	}

	public double ColumnWidth
	{
		get
		{
			return method_7("column-width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("column-width", NamespaceURI, value);
		}
	}

	public double RelColumnWidth
	{
		get
		{
			return method_7("rel-column-width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("rel-column-width", NamespaceURI, value);
		}
	}

	public bool UseOptimalColumnWidth
	{
		get
		{
			return method_3("use-optimal-column-width", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("use-optimal-column-width", NamespaceURI, value);
		}
	}

	public Class441(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
