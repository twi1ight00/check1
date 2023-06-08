using System.Xml;

namespace ns42;

internal class Class1082 : XmlElement
{
	internal static readonly string string_0 = "Default";

	public string Extension
	{
		get
		{
			return GetAttribute("Extension", "");
		}
		set
		{
			SetAttribute("Extension", "", value);
		}
	}

	public string ContentType
	{
		get
		{
			return GetAttribute("ContentType", "");
		}
		set
		{
			SetAttribute("ContentType", "", value);
		}
	}

	public Class1082(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
