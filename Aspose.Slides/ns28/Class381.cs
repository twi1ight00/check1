using System.Xml;

namespace ns28;

internal class Class381 : Class369
{
	protected Class466 class466_0;

	protected Class486 class486_0;

	internal static readonly string string_0 = "control";

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

	public string Control
	{
		get
		{
			return GetAttribute("control", NamespaceURI);
		}
		set
		{
			SetAttribute("control", NamespaceURI, value);
		}
	}

	public Class381(string prefix, string localName, string namespaceURI, XmlDocument doc)
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
