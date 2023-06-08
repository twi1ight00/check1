using System.Xml;

namespace ns28;

internal class Class416 : Class369
{
	private Class437 class437_0;

	private Class428 class428_0;

	private Class410 class410_0;

	internal static readonly string string_0 = "page";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	internal static readonly string string_4 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

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

	public string StyleNameStr => GetAttribute("style-name", NamespaceURI);

	public Class437 StyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			class437_0 = value;
			SetAttribute("style-name", NamespaceURI, value.Name);
		}
	}

	public string MasterPageNameStr
	{
		get
		{
			return GetAttribute("master-page-name", NamespaceURI);
		}
		set
		{
			SetAttribute("master-page-name", NamespaceURI, value);
		}
	}

	public Class410 MasterPageName
	{
		get
		{
			return class410_0;
		}
		set
		{
			class410_0 = value;
			SetAttribute("master-page-name", NamespaceURI, value.Name);
		}
	}

	public string PresentationPageLayoutNameStr => GetAttribute("presentation-page-layout-name", string_3);

	public Class428 PresentationPageLayoutName
	{
		get
		{
			return class428_0;
		}
		set
		{
			class428_0 = value;
			SetAttribute("presentation-page-layout-name", string_3, value.Name);
		}
	}

	public string UseHeaderName
	{
		get
		{
			return GetAttribute("use-header-name", string_3);
		}
		set
		{
			SetAttribute("use-header-name", string_3, value);
		}
	}

	public string UseFooterName
	{
		get
		{
			return GetAttribute("use-footer-name", string_3);
		}
		set
		{
			SetAttribute("use-footer-name", string_3, value);
		}
	}

	public string UseDateTimeName
	{
		get
		{
			return GetAttribute("use-date-time-name", string_3);
		}
		set
		{
			SetAttribute("use-date-time-name", string_3, value);
		}
	}

	public string Id
	{
		get
		{
			return GetAttribute("id", NamespaceURI);
		}
		set
		{
			SetAttribute("id", NamespaceURI, value);
		}
	}

	public Class416(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
