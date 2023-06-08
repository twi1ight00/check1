using System.Xml;

namespace ns28;

internal class Class391 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("full", "section", "cut", "arc");

	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "ellipse";

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

	public double CenterX
	{
		get
		{
			return method_7("cx", string_1, -1.0);
		}
		set
		{
			method_8("cx", string_1, value);
		}
	}

	public double CenterY
	{
		get
		{
			return method_7("cy", string_1, -1.0);
		}
		set
		{
			method_8("cy", string_1, value);
		}
	}

	public double EndAngle
	{
		get
		{
			return method_25("end-angle", NamespaceURI, double.NaN);
		}
		set
		{
			method_26("end-angle", NamespaceURI, value);
		}
	}

	public double StartAngle
	{
		get
		{
			return method_25("start-angle", NamespaceURI, double.NaN);
		}
		set
		{
			method_26("start-angle", NamespaceURI, value);
		}
	}

	public Enum53 ColorMode
	{
		get
		{
			return (Enum53)method_9(class467_0, "kind", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "kind", NamespaceURI, (int)value);
		}
	}

	public Class391(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		class466_0 = new Class466();
		class486_0 = new Class486();
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
