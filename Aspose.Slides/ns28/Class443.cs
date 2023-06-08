using System.Xml;

namespace ns28;

internal class Class443 : Class369
{
	internal static readonly string string_0 = "even-rows";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	public string ParagraphStyleName
	{
		get
		{
			return method_0("paragraph-style-name", string_1, "");
		}
		set
		{
			SetAttribute("paragraph-style-name", string_1, value);
		}
	}

	public string StyleName
	{
		get
		{
			return method_0("style-name", string_1, "");
		}
		set
		{
			SetAttribute("style-name", string_1, value);
		}
	}

	public Class443(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
