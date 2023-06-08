using System.Collections.Generic;
using System.Xml;

namespace ns28;

internal class Class406 : Class369
{
	private List<Class369> list_0 = new List<Class369>();

	internal static readonly string string_0 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_1 = "list-style";

	public new string Name
	{
		get
		{
			return GetAttribute("name", string_0);
		}
		set
		{
			SetAttribute("name", string_0, value);
		}
	}

	public string DisplayName
	{
		get
		{
			return GetAttribute("display-name", string_0);
		}
		set
		{
			SetAttribute("display-name", string_0, value);
		}
	}

	public bool ConsecutiveNumbering
	{
		get
		{
			return method_3("consecutive-numbering", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("consecutive-numbering", NamespaceURI, value);
		}
	}

	public List<Class369> ListLevels => list_0;

	public Class406(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		string[] localNames = new string[2] { "list-level-style-bullet", "list-level-style-number" };
		Class369[] array = method_32(localNames, NamespaceURI);
		Class369[] array2 = array;
		foreach (Class369 item in array2)
		{
			list_0.Add(item);
		}
	}
}
