using System.Xml;

namespace ns42;

internal class Class1084 : XmlElement
{
	internal static readonly string string_0 = "Override";

	public string PartName
	{
		get
		{
			return GetAttribute("PartName", "");
		}
		set
		{
			SetAttribute("PartName", "", value);
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

	public Class1084(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
