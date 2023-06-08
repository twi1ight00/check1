using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class433 : Class369
{
	internal static readonly string string_0 = "section-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	public Color BackgroundColor
	{
		get
		{
			return method_16("background-color", string_1, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("background-color", string_1, value);
		}
	}

	public double MarginLeft
	{
		get
		{
			return method_7("margin-left", string_1, 0.0);
		}
		set
		{
			method_8("margin-left", string_1, value);
		}
	}

	public double MarginRight
	{
		get
		{
			return method_7("margin-right", string_1, 0.0);
		}
		set
		{
			method_8("margin-right", string_1, value);
		}
	}

	public bool Editable
	{
		get
		{
			return method_3("editable", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("editable", NamespaceURI, value);
		}
	}

	public bool Protect
	{
		get
		{
			return method_3("protect", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("protect", NamespaceURI, value);
		}
	}

	public bool DontBalanceTextColumns
	{
		get
		{
			return method_3("dont-balance-text-columns", string_2, defaultValue: true);
		}
		set
		{
			method_4("dont-balance-text-columns", string_2, value);
		}
	}

	public Class433(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
