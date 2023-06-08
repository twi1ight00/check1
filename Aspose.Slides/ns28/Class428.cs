using System.Xml;

namespace ns28;

internal class Class428 : Class369
{
	private Class420[] class420_0;

	internal static readonly string string_0 = "presentation-page-layout";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";

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

	public Class420[] PlaceHolders => class420_0;

	internal override void vmethod_0()
	{
		base.vmethod_0();
		Class369[] array = method_29("placeholder", string_1);
		class420_0 = new Class420[array.Length];
		int num = 0;
		Class369[] array2 = array;
		foreach (Class369 @class in array2)
		{
			class420_0[num] = (Class420)@class;
			num++;
		}
	}

	public Class428(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
