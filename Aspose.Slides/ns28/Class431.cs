using System.Xml;

namespace ns28;

internal class Class431 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "regular-polygon";

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

	public bool Concave
	{
		get
		{
			return method_3("concave", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("concave", NamespaceURI, value);
		}
	}

	public int Corners
	{
		get
		{
			return method_13("corners", NamespaceURI, 0);
		}
		set
		{
			method_15("corners", NamespaceURI, value);
		}
	}

	public int Sharpness
	{
		get
		{
			return method_11("sharpness", NamespaceURI, 0);
		}
		set
		{
			method_12("sharpness", NamespaceURI, value);
		}
	}

	public Class431(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
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
}
