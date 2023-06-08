using System.Xml;

namespace ns28;

internal class Class393 : Class369
{
	internal static readonly string string_0 = "equation";

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

	public string Formula
	{
		get
		{
			return GetAttribute("formula", NamespaceURI);
		}
		set
		{
			SetAttribute("formula", NamespaceURI, value);
		}
	}

	public Class393(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
