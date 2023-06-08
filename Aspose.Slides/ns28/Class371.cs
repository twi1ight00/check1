using System.Xml;

namespace ns28;

internal class Class371 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("show", "extended", "title", "resource", "locator", "arc");

	internal static readonly Class467 class467_1 = new Class467("new", "replace", "embed", "other", "none");

	internal static readonly Class467 class467_2 = new Class467("onRequest", "onLoad", "other", "none");

	internal static readonly Class467 class467_3 = new Class467("no-repeat", "repeat", "stretch");

	internal static readonly string string_0 = "background-image";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal static readonly string string_3 = "http://www.w3.org/1999/xlink";

	public int Opacity
	{
		get
		{
			return method_11("opacity", string_2, 100);
		}
		set
		{
			method_12("opacity", string_2, value);
		}
	}

	public string FilterName
	{
		get
		{
			return method_0("filter-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("filter-name", NamespaceURI, value);
		}
	}

	public Enum38 Repeat
	{
		get
		{
			return (Enum38)method_9(class467_3, "repeat", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_3, "repeat", NamespaceURI, (int)value);
		}
	}

	public Enum23 Actuate
	{
		get
		{
			return (Enum23)method_9(class467_2, "actuate", string_3, 1);
		}
		set
		{
			method_10(class467_2, "actuate", string_3, (int)value);
		}
	}

	public string Href
	{
		get
		{
			return method_0("href", string_3, "");
		}
		set
		{
			SetAttribute("href", string_3, value);
		}
	}

	public Enum110 Show
	{
		get
		{
			return (Enum110)method_9(class467_1, "show", string_3, 2);
		}
		set
		{
			method_10(class467_1, "show", string_3, (int)value);
		}
	}

	public Enum111 Type
	{
		get
		{
			return (Enum111)method_9(class467_0, "type", string_3, 0);
		}
		set
		{
			method_10(class467_0, "type", string_3, (int)value);
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
	}

	public Class371(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
