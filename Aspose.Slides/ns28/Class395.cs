using System.Xml;

namespace ns28;

internal class Class395 : Class369
{
	protected Class466 class466_0;

	protected string string_0 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	internal static readonly string string_1 = "g";

	public Class466 ShapeProperties
	{
		get
		{
			return class466_0;
		}
		set
		{
			class466_0 = value;
		}
	}

	public double Y
	{
		get
		{
			return method_7("y", string_0, double.NaN);
		}
		set
		{
			method_8("y", string_0, value);
		}
	}

	public Class395(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
	}
}
