using System.Xml;

namespace ns28;

internal class Class407 : Class369
{
	internal static readonly string string_0 = "file-entry";

	public string ManifestMediaType
	{
		get
		{
			return GetAttribute("media-type", NamespaceURI);
		}
		set
		{
			SetAttribute("media-type", NamespaceURI, value);
		}
	}

	public string ManifestFullPath
	{
		get
		{
			return GetAttribute("full-path", NamespaceURI);
		}
		set
		{
			SetAttribute("full-path", NamespaceURI, value);
		}
	}

	public Class407(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
