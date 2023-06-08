using System.Xml;

namespace ns28;

internal class Class377 : Class369
{
	internal static readonly string string_0 = "columns";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public int ColumnCount
	{
		get
		{
			return method_13("position", string_1, 0);
		}
		set
		{
			method_15("position", string_1, value);
		}
	}

	public double ColumnGap
	{
		get
		{
			return method_7("column-gap", string_1, 0.0);
		}
		set
		{
			method_8("column-gap", string_1, value);
		}
	}

	public Class377(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
