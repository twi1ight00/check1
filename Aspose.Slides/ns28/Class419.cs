using System.Xml;

namespace ns28;

internal class Class419 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	protected Class489 class489_0;

	internal static readonly string string_0 = "path";

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

	public string DPath
	{
		get
		{
			return method_0("d", string_1, "");
		}
		set
		{
			SetAttribute("d", string_1, value);
		}
	}

	public Class419(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class486_0 = new Class486(this);
		class489_0 = new Class489(this);
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class486_0.Write(this);
		class489_0.Write(this);
		base.vmethod_1();
	}
}
