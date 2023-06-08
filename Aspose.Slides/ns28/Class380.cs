using System.Xml;

namespace ns28;

internal class Class380 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("standard", "lines", "line", "curve");

	protected Class466 class466_0;

	protected Class473 class473_0;

	protected Class489 class489_0;

	internal static readonly string string_0 = "connector";

	protected string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

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

	public Class473 Line2D
	{
		get
		{
			return class473_0;
		}
		set
		{
			class473_0 = value;
		}
	}

	public Class489 ViewBox
	{
		get
		{
			return class489_0;
		}
		set
		{
			class489_0 = value;
		}
	}

	public object[,] DPath
	{
		get
		{
			return method_27("d", string_1, "");
		}
		set
		{
			method_28("d", string_1, value);
		}
	}

	public int EndGluePoint
	{
		get
		{
			return method_13("end-glue-point", NamespaceURI, -1);
		}
		set
		{
			method_15("end-glue-point", NamespaceURI, value);
		}
	}

	public string EndShape
	{
		get
		{
			return method_0("end-shape", NamespaceURI, "");
		}
		set
		{
			SetAttribute("end-shape", NamespaceURI, value);
		}
	}

	public int StartGluePoint
	{
		get
		{
			return method_13("start-glue-point", NamespaceURI, -1);
		}
		set
		{
			method_15("start-glue-point", NamespaceURI, value);
		}
	}

	public string StartShape
	{
		get
		{
			return method_0("start-shape", NamespaceURI, "");
		}
		set
		{
			SetAttribute("start-shape", NamespaceURI, value);
		}
	}

	public string LineSkew
	{
		get
		{
			return method_0("line-skew", NamespaceURI, "");
		}
		set
		{
			SetAttribute("line-skew", NamespaceURI, value);
		}
	}

	public Enum31 DrawType
	{
		get
		{
			return (Enum31)method_9(class467_0, "type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "type", NamespaceURI, (int)value);
		}
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class473_0 = new Class473(this);
		class489_0 = new Class489(this);
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class473_0.Write(this);
		class489_0.Write(this);
		base.vmethod_1();
	}

	public Class380(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		class466_0 = new Class466();
		class473_0 = new Class473();
		class489_0 = new Class489();
	}
}
