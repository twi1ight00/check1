using System.Xml;

namespace ns28;

internal class Class386 : Class369
{
	internal static readonly string string_0 = "image";

	internal static readonly string string_1 = "http://www.w3.org/1999/xlink";

	internal static readonly string string_2 = "xml";

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

	public string Actuate
	{
		get
		{
			return GetAttribute("actuate", string_1);
		}
		set
		{
			SetAttribute("actuate", string_1, "onLoad");
		}
	}

	public string Href
	{
		get
		{
			return GetAttribute("href", string_1);
		}
		set
		{
			SetAttribute("href", string_1, value);
		}
	}

	public string Show
	{
		get
		{
			return GetAttribute("show", string_1);
		}
		set
		{
			SetAttribute("show", string_1, "embed");
		}
	}

	public string Type
	{
		get
		{
			return GetAttribute("type", string_1);
		}
		set
		{
			SetAttribute("type", string_1, "simple");
		}
	}

	public Class386(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
