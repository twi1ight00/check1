using System.Xml;

namespace ns28;

internal class Class373 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "caption";

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

	public double CaptionPointX
	{
		get
		{
			return method_7("caption-point-x", NamespaceURI, -1.0);
		}
		set
		{
			method_8("caption-point-x", NamespaceURI, value);
		}
	}

	public double CaptionPointY
	{
		get
		{
			return method_7("caption-point-y", NamespaceURI, -1.0);
		}
		set
		{
			method_8("caption-point-y", NamespaceURI, value);
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

	public Class373(string prefix, string localName, string namespaceURI, XmlDocument doc)
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
