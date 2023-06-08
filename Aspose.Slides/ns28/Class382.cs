using System.Xml;

namespace ns28;

internal class Class382 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "custom-shape";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	private Class437 class437_0;

	private Class437 class437_1;

	private Class392 class392_0;

	public string StyleNameStr => GetAttribute("style-name", NamespaceURI);

	public Class437 StyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			class437_0 = value;
			SetAttribute("style-name", NamespaceURI, value.Name);
		}
	}

	public string TextStyleNameStr => GetAttribute("text-style-name", NamespaceURI);

	public Class437 TextStyleName
	{
		get
		{
			return class437_1;
		}
		set
		{
			class437_1 = value;
			SetAttribute("text-style-name", NamespaceURI, value.Name);
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

	public Class392 Geometry => class392_0;

	public Class382(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
		class486_0 = new Class486();
		class466_0 = new Class466(this);
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class486_0 = new Class486(this);
		Class369 @class = method_31("enhanced-geometry", NamespaceURI);
		if (@class != null)
		{
			class392_0 = (Class392)@class;
		}
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class486_0.Write(this);
		base.vmethod_1();
	}
}
