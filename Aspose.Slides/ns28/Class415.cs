using System.Xml;

namespace ns28;

internal class Class415 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("current", "next", "previous");

	internal static readonly string string_0 = "page-number";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	public string NumFormat
	{
		get
		{
			return method_0("num-format", string_2, "");
		}
		set
		{
			SetAttribute("num-format", string_2, value);
		}
	}

	public bool NumLetterSync
	{
		get
		{
			return method_3("num-letter-sync", string_2, defaultValue: true);
		}
		set
		{
			method_4("num-letter-sync", string_2, value);
		}
	}

	public bool Fixed
	{
		get
		{
			return method_3("fixed", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("fixed", NamespaceURI, value);
		}
	}

	public int PageAdjust
	{
		get
		{
			return method_13("page-adjust", NamespaceURI, 0);
		}
		set
		{
			method_15("page-adjust", NamespaceURI, value);
		}
	}

	public Enum75 SelectPage
	{
		get
		{
			return (Enum75)method_9(class467_0, "select-page", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "select-page", NamespaceURI, (int)value);
		}
	}

	public Class415(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
