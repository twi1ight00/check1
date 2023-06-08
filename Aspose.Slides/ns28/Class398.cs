using System.Xml;

namespace ns28;

internal class Class398 : Class369
{
	internal static readonly string string_0 = "handout-master";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	public string StyleName
	{
		get
		{
			return method_0("style-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("style-name", NamespaceURI, value);
		}
	}

	public string PresentationPageLayout
	{
		get
		{
			return method_0("presentation-page-layout", string_1, "");
		}
		set
		{
			SetAttribute("presentation-page-layout", string_1, value);
		}
	}

	public string UseDateTimeName
	{
		get
		{
			return method_0("use-date-time-name", string_2, "");
		}
		set
		{
			SetAttribute("use-date-time-name", string_2, value);
		}
	}

	public string UseFooterName
	{
		get
		{
			return method_0("use-footer-name", string_2, "");
		}
		set
		{
			SetAttribute("use-footer-name", string_2, value);
		}
	}

	public string UseHeaderName
	{
		get
		{
			return method_0("use-header-name", string_2, "");
		}
		set
		{
			SetAttribute("use-header-name", string_2, value);
		}
	}

	public string PageLayoutName
	{
		get
		{
			return method_0("page-layout-name", string_1, "");
		}
		set
		{
			SetAttribute("page-layout-name", string_1, value);
		}
	}

	public Class398(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
