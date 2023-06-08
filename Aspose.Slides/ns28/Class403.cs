using System.Xml;

namespace ns28;

internal class Class403 : Class369
{
	internal static readonly string string_0 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	internal static readonly string string_1 = "list-level-properties";

	public double SpaceBefore
	{
		get
		{
			return method_7("space-before", string_0, 0.0);
		}
		set
		{
			method_8("space-before", string_0, value);
		}
	}

	public double MinLabelWidth
	{
		get
		{
			return method_7("min-label-width", string_0, double.NaN);
		}
		set
		{
			method_8("min-label-width", string_0, value);
		}
	}

	public double MinLabelDistance
	{
		get
		{
			return method_7("min-label-distance", string_0, double.NaN);
		}
		set
		{
			method_8("min-label-distance", string_0, value);
		}
	}

	public Class403(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
