using System.Xml;

namespace ns28;

internal class Class413 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("all", "left", "right", "mirrored");

	internal static readonly string string_0 = "page-layout";

	public new string Name
	{
		get
		{
			return method_0("name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("name", NamespaceURI, value);
		}
	}

	public Enum62 PageUsage
	{
		get
		{
			return (Enum62)method_9(class467_0, "page-usage", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "page-usage", NamespaceURI, (int)value);
		}
	}

	public Class413(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
