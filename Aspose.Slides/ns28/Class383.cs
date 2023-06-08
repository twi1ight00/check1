using System.Xml;

namespace ns28;

internal class Class383 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("paragraph", "text", "section", "table", "table-column", "table-row", "table-cell", "table-page", "chart", "default", "drawing-page", "graphic", "presentation", "control", "ruby");

	internal static readonly string string_0 = "default-style";

	public Enum84 Family
	{
		get
		{
			return (Enum84)method_9(class467_0, "family", NamespaceURI, 9);
		}
		set
		{
			method_10(class467_0, "family", NamespaceURI, (int)value);
		}
	}

	public Class383(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
