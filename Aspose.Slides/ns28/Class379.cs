using System.Xml;

namespace ns28;

internal class Class379 : Class369
{
	internal static readonly string[] string_0 = new string[3] { "config-item-set", "config-item-map-indexed", "config-item-map-entry" };

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

	public Class379(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
