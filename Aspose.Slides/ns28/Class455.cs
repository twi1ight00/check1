using System.Xml;

namespace ns28;

internal class Class455 : Class369
{
	internal Class406 class406_0;

	internal static readonly string string_0 = "list";

	public string ListStyleNameString => method_0("style-name", NamespaceURI, "");

	public Class406 ListStyleName
	{
		get
		{
			return class406_0;
		}
		set
		{
			class406_0 = value;
			SetAttribute("style-name", NamespaceURI, value.Name);
		}
	}

	public Class455(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		if (!(ListStyleNameString != ""))
		{
			return;
		}
		foreach (Class406 item in OwnerDocument.GetElementsByTagName("list-style", NamespaceURI))
		{
			if (item.Name == ListStyleNameString)
			{
				class406_0 = item;
				break;
			}
		}
	}
}
