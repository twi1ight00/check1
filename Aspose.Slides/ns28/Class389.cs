using System.Xml;

namespace ns28;

internal class Class389 : Class369
{
	internal static readonly string string_0 = "text-box";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	public string ChainTextName
	{
		get
		{
			return method_0("chain-next-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("chain-next-name", NamespaceURI, value);
		}
	}

	public int CornerRadius
	{
		get
		{
			return method_13("corner-radius", NamespaceURI, 0);
		}
		set
		{
			method_13("corner-radius", NamespaceURI, value);
		}
	}

	public int MaxHeight
	{
		get
		{
			return method_13("max-height", string_1, 0);
		}
		set
		{
			method_13("max-height", string_1, value);
		}
	}

	public int MaxWidth
	{
		get
		{
			return method_13("max-width", string_1, 0);
		}
		set
		{
			method_13("max-width", string_1, value);
		}
	}

	public int MinHeight
	{
		get
		{
			return method_13("min-height", string_1, 0);
		}
		set
		{
			method_13("min-height", string_1, value);
		}
	}

	public int MinWidth
	{
		get
		{
			return method_13("min-width", string_1, 0);
		}
		set
		{
			method_13("min-width", string_1, value);
		}
	}

	public string Id
	{
		get
		{
			return method_0("id", string_2, "");
		}
		set
		{
			SetAttribute("id", string_2, value);
		}
	}

	public Class389(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
