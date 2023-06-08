using System.Xml;

namespace ns28;

internal class Class427 : Class369
{
	internal static readonly string string_0 = "notes";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	private Class437 class437_0;

	private Class413 class413_0;

	public string StyleNameStr => GetAttribute("style-name", string_2);

	public Class437 StyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			class437_0 = value;
			SetAttribute("style-name", string_2, value.Name);
		}
	}

	public string PageLayoutNameStr => method_0("page-layout-name", string_1, "");

	public Class413 PageLayoutName
	{
		get
		{
			return class413_0;
		}
		set
		{
			class413_0 = value;
			SetAttribute("page-layout-name", string_1, value.Name);
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

	public Class427(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
