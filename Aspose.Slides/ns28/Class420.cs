using System.Xml;

namespace ns28;

internal class Class420 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("title", "outline", "subtitle", "text", "graphic", "object", "chart", "table", "orgchart", "page", "notes", "handout");

	internal static readonly string string_0 = "placeholder";

	protected Class486 class486_0;

	public Enum65 Object
	{
		get
		{
			return (Enum65)method_9(class467_0, "object", NamespaceURI, 5);
		}
		set
		{
			method_10(class467_0, "object", NamespaceURI, (int)value);
		}
	}

	public Class486 Coordinate => class486_0;

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class486_0 = new Class486(this);
	}

	public Class420(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_1()
	{
		class486_0.Write(this);
		base.vmethod_1();
	}
}
