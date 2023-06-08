using System.Xml;

namespace ns28;

internal class Class430 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "rect";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

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

	public Class486 Transform2D
	{
		get
		{
			return class486_0;
		}
		set
		{
			class486_0 = value;
		}
	}

	public double CornerRadius
	{
		get
		{
			return method_7("corner-radius", NamespaceURI, -1.0);
		}
		set
		{
			method_8("corner-radius", NamespaceURI, value);
		}
	}

	public double RadiusX
	{
		get
		{
			return method_7("rx", string_1, -1.0);
		}
		set
		{
			method_8("rx", string_1, value);
		}
	}

	public double RadiusY
	{
		get
		{
			return method_7("ry", string_1, -1.0);
		}
		set
		{
			method_8("ry", string_1, value);
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class486_0 = new Class486(this);
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class486_0.Write(this);
		base.vmethod_1();
	}

	public Class430(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		class466_0 = new Class466();
		class486_0 = new Class486();
	}
}
