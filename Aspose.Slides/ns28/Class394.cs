using System.Xml;

namespace ns28;

internal class Class394 : Class369
{
	internal static readonly string string_0 = "fill-image";

	internal static readonly string string_1 = "http://www.w3.org/1999/xlink";

	public new string Name
	{
		get
		{
			return GetAttribute("name", NamespaceURI);
		}
		set
		{
			SetAttribute("name", NamespaceURI, value);
		}
	}

	public string DisplayName
	{
		get
		{
			return GetAttribute("display-name", NamespaceURI);
		}
		set
		{
			SetAttribute("display-name", NamespaceURI, value);
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

	public Class394(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
