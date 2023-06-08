using System.Xml;

namespace ns28;

internal class Class400 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("always", "screen", "printer", "none");

	internal static readonly string string_0 = "layer";

	public Enum33 TableCentering
	{
		get
		{
			return (Enum33)method_9(class467_0, "display", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "display", NamespaceURI, (int)value);
		}
	}

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

	public bool Protected
	{
		get
		{
			return method_3("protected", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("protected", NamespaceURI, value);
		}
	}

	public Class400(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
