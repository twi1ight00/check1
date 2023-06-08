using System.Xml;

namespace ns28;

internal class Class432 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("above", "below");

	internal static readonly Class467 class467_1 = new Class467("left", "center", "right", "distribute-letter", "distribute-space");

	internal static readonly string string_0 = "ruby-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public Enum73 RubyPosition
	{
		get
		{
			return (Enum73)method_9(class467_0, "ruby-position", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "ruby-position", NamespaceURI, (int)value);
		}
	}

	public Enum72 RubyAlign
	{
		get
		{
			return (Enum72)method_9(class467_1, "ruby-align", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_1, "ruby-align", NamespaceURI, (int)value);
		}
	}

	public Class432(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
