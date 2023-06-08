using System.Xml;

namespace ns28;

internal class Class411 : Class369
{
	internal static readonly string string_0 = "measure";

	protected Class466 class466_0;

	protected Class473 class473_0;

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

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class466_0 = new Class466(this);
		class473_0 = new Class473(this);
	}

	internal override void vmethod_1()
	{
		class466_0.Write(this);
		class473_0.Write(this);
		base.vmethod_1();
	}

	public Class411(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
