using System.Xml;

namespace ns28;

internal class Class378 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("boolean", "short", "int", "long", "double", "string", "date-time", "base64Binary");

	internal static readonly string string_0 = "config-item";

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

	public Enum30 Type
	{
		get
		{
			return (Enum30)method_9(class467_0, "type", NamespaceURI, 5);
		}
		set
		{
			method_10(class467_0, "type", NamespaceURI, (int)value);
		}
	}

	public Class378(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
