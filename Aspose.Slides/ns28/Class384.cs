using System.Xml;

namespace ns28;

internal class Class384 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("title", "outline", "subtitle", "text", "graphic", "object", "chart", "table", "orgchart", "page", "notes", "handout", "header", "footer", "date-time", "page-number");

	internal static readonly string string_0 = "frame";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	internal static readonly string string_4 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	internal static readonly string string_5 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

	internal static readonly string string_6 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	protected Class386 class386_0;

	protected Class389 class389_0;

	protected Class466 class466_0;

	protected Class486 class486_0;

	public string CopyOf
	{
		get
		{
			return method_0("copy-of", NamespaceURI, "");
		}
		set
		{
			SetAttribute("copy-of", NamespaceURI, value);
		}
	}

	public Enum64 PresentationClass
	{
		get
		{
			return (Enum64)method_9(class467_0, "class", string_2, 16);
		}
		set
		{
			method_10(class467_0, "class", string_2, (int)value);
		}
	}

	public bool Placeholder
	{
		get
		{
			return method_3("placeholder", string_2, defaultValue: false);
		}
		set
		{
			method_4("placeholder", string_2, value);
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

	public Class386 Image => class386_0;

	public Class389 TextBox => class389_0;

	internal new string Name
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

	public Class384(string prefix, string localName, string namespaceURI, XmlDocument doc)
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
		class386_0 = method_31("image", string_6) as Class386;
		class389_0 = method_31("text-box", string_6) as Class389;
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class486_0.Write(this);
		base.vmethod_1();
	}
}
