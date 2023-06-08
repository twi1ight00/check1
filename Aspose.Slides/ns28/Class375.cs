using System.Xml;

namespace ns28;

internal class Class375 : Class369
{
	internal static readonly string string_0 = "column";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public double StartIndent
	{
		get
		{
			return method_7("start-indent", string_1, 0.0);
		}
		set
		{
			method_8("start-indent", string_1, value);
		}
	}

	public double EndIndent
	{
		get
		{
			return method_7("end-indent", string_1, 0.0);
		}
		set
		{
			method_8("end-indent", string_1, value);
		}
	}

	public double SpaceAfter
	{
		get
		{
			return method_7("space-after", string_1, 0.0);
		}
		set
		{
			method_8("space-after", string_1, value);
		}
	}

	public double SpaceBefore
	{
		get
		{
			return method_7("space-before", string_1, 0.0);
		}
		set
		{
			method_8("space-before", string_1, value);
		}
	}

	public double RelWidth
	{
		get
		{
			return method_7("rel-width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("rel-width", NamespaceURI, value);
		}
	}

	public Class375(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
