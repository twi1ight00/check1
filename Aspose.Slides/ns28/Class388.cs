using System.Xml;

namespace ns28;

internal class Class388 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("as-char", "char", "frame", "page", "paragraph");

	internal static readonly Class467 class467_1 = new Class467("title", "outline", "subtitle", "text", "graphic", "object", "chart", "orgchart", "page", "notes", "handout", "header", "footer", "date-time", "page-number");

	internal static readonly string string_0 = "page-thumbnail";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	internal static readonly string string_4 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	internal static readonly string string_5 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	protected Class487 class487_0;

	public string CaptionId
	{
		get
		{
			return method_0("caption-id", NamespaceURI, "");
		}
		set
		{
			SetAttribute("caption-id", NamespaceURI, value);
		}
	}

	public string DrawClassNames
	{
		get
		{
			return method_0("class-names", NamespaceURI, "");
		}
		set
		{
			SetAttribute("class-names", NamespaceURI, value);
		}
	}

	public string Id
	{
		get
		{
			return method_0("id", NamespaceURI, "");
		}
		set
		{
			SetAttribute("id", NamespaceURI, value);
		}
	}

	public string Layer
	{
		get
		{
			return method_0("layer", NamespaceURI, "");
		}
		set
		{
			SetAttribute("layer", NamespaceURI, value);
		}
	}

	public new string Name
	{
		get
		{
			return method_0("name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("name", NamespaceURI, value);
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

	public Class487 Transform
	{
		get
		{
			return class487_0;
		}
		set
		{
			class487_0 = value;
		}
	}

	public int Zindex
	{
		get
		{
			return method_13("z-index", NamespaceURI, 0);
		}
		set
		{
			method_15("z-index", NamespaceURI, value);
		}
	}

	public Enum64 PresentationClass
	{
		get
		{
			return (Enum64)method_9(class467_1, "class", string_2, 12);
		}
		set
		{
			method_10(class467_1, "class", string_2, (int)value);
		}
	}

	public string PresentationClassNames
	{
		get
		{
			return method_0("class-names", string_2, "");
		}
		set
		{
			SetAttribute("class-names", string_2, value);
		}
	}

	public bool Placeholder
	{
		get
		{
			return method_3("placeholder", string_2, defaultValue: true);
		}
		set
		{
			method_4("placeholder", string_2, value);
		}
	}

	public string PresentationStyleNames
	{
		get
		{
			return method_0("style-name", string_2, "");
		}
		set
		{
			SetAttribute("style-name", string_2, value);
		}
	}

	public bool UserTransformed
	{
		get
		{
			return method_3("user-transformed", string_2, defaultValue: true);
		}
		set
		{
			method_4("user-transformed", string_2, value);
		}
	}

	public double Width
	{
		get
		{
			return method_7("width", string_3, 0.0);
		}
		set
		{
			method_8("width", string_3, value);
		}
	}

	public double Height
	{
		get
		{
			return method_7("height", string_3, 0.0);
		}
		set
		{
			method_8("height", string_3, value);
		}
	}

	public double X
	{
		get
		{
			return method_7("x", string_3, 0.0);
		}
		set
		{
			method_8("x", string_3, value);
		}
	}

	public double Y
	{
		get
		{
			return method_7("y", string_3, 0.0);
		}
		set
		{
			method_8("y", string_3, value);
		}
	}

	public double endX
	{
		get
		{
			return method_7("end-x", string_4, 0.0);
		}
		set
		{
			method_8("end-x", string_4, value);
		}
	}

	public double endY
	{
		get
		{
			return method_7("end-y", string_4, 0.0);
		}
		set
		{
			method_8("end-y", string_4, value);
		}
	}

	public bool TableBackground
	{
		get
		{
			return method_3("table-background", string_4, defaultValue: true);
		}
		set
		{
			method_4("table-background", string_4, value);
		}
	}

	public int AnchorPageNumber
	{
		get
		{
			return method_13("anchor-page-number", string_5, 0);
		}
		set
		{
			method_15("anchor-page-number", string_5, value);
		}
	}

	public Enum24 AncorType
	{
		get
		{
			return (Enum24)method_9(class467_0, "anchor-type", string_5, 0);
		}
		set
		{
			method_10(class467_0, "anchor-type", string_5, (int)value);
		}
	}

	public int PageNumber
	{
		get
		{
			return method_13("page-number", NamespaceURI, 0);
		}
		set
		{
			method_15("page-number", NamespaceURI, value);
		}
	}

	public Class388(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class487_0 = new Class487(this, "transform", NamespaceURI);
	}

	internal override void vmethod_1()
	{
		class487_0.Write(this, "transform", NamespaceURI);
		base.vmethod_1();
	}
}
