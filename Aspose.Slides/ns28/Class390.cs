using System.Xml;

namespace ns28;

internal class Class390 : Class369
{
	internal static readonly string string_0 = "drop-cap";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public int Length
	{
		get
		{
			return method_13("length", NamespaceURI, 1);
		}
		set
		{
			method_15("length", NamespaceURI, value);
		}
	}

	public int Lines
	{
		get
		{
			return method_13("lines", NamespaceURI, 0);
		}
		set
		{
			method_15("lines", NamespaceURI, value);
		}
	}

	public double Distance
	{
		get
		{
			return method_7("distance", NamespaceURI, 0.0);
		}
		set
		{
			method_8("distance", NamespaceURI, value);
		}
	}

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

	internal override void vmethod_0()
	{
		base.vmethod_0();
	}

	public Class390(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
