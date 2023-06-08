using System.Xml;

namespace ns28;

internal class Class409 : Class369
{
	internal static readonly string string_0 = "marker";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

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

	public string ViewBox
	{
		get
		{
			return GetAttribute("viewBox", string_1);
		}
		set
		{
			SetAttribute("viewBox", string_1, value);
		}
	}

	public string D
	{
		get
		{
			return GetAttribute("d", string_1);
		}
		set
		{
			SetAttribute("d", string_1, value);
		}
	}

	public Class409(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
