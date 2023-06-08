using System.Xml;

namespace ns28;

internal class Class417 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("title", "outline", "subtitle", "text", "graphic", "object", "chart", "orgchart", "page", "notes", "handout", "header", "footer", "date-time", "page-number");

	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "page-thumbnail";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

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

	public Enum64 PresentationClass
	{
		get
		{
			return (Enum64)method_9(class467_0, "class", string_1, 12);
		}
		set
		{
			method_10(class467_0, "class", string_1, (int)value);
		}
	}

	public bool Placeholder
	{
		get
		{
			return method_3("placeholder", string_1, defaultValue: false);
		}
		set
		{
			method_4("placeholder", string_1, value);
		}
	}

	public bool UserTransformed
	{
		get
		{
			return method_3("user-transformed", string_1, defaultValue: false);
		}
		set
		{
			method_4("user-transformed", string_1, value);
		}
	}

	public Class417(string prefix, string localName, string namespaceURI, XmlDocument doc)
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
