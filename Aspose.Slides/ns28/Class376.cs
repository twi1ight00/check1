using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class376 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("top", "middle", "bottom", "dashed");

	internal static readonly Class467 class467_1 = new Class467("none", "solid", "dotted", "dashed", "dot-dashed");

	internal static readonly string string_0 = "column-sep";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public Color Color
	{
		get
		{
			return method_16("color", NamespaceURI, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("color", NamespaceURI, value);
		}
	}

	public double Width
	{
		get
		{
			return method_7("width", NamespaceURI, 0.0);
		}
		set
		{
			method_8("width", NamespaceURI, value);
		}
	}

	public int Height
	{
		get
		{
			return method_11("height", NamespaceURI, 100);
		}
		set
		{
			method_12("height", NamespaceURI, value);
		}
	}

	public Enum76 Style
	{
		get
		{
			return (Enum76)method_9(class467_1, "style", NamespaceURI, 1);
		}
		set
		{
			method_10(class467_1, "style", NamespaceURI, (int)value);
		}
	}

	public Enum93 VerticalAlign
	{
		get
		{
			return (Enum93)method_9(class467_0, "vertical-align", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "vertical-align", NamespaceURI, (int)value);
		}
	}

	public Class376(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
