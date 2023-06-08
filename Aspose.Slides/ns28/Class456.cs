using System.Text.RegularExpressions;
using System.Xml;

namespace ns28;

internal class Class456 : Class369
{
	private string[] string_0;

	private Class437 class437_0;

	internal static readonly string string_1 = "p";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	internal static readonly string string_4 = "http://www.w3.org/1999/xhtml";

	public string ClassNames
	{
		get
		{
			return method_0("class-names", NamespaceURI, "");
		}
		set
		{
			SetAttribute("class-names", NamespaceURI, value);
		}
	}

	public string CondStyleName
	{
		get
		{
			return method_0("cond-style-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("cond-style-name", NamespaceURI, value);
		}
	}

	public string StyleNameString => method_0("style-name", NamespaceURI, "");

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

	public string About
	{
		get
		{
			return method_0("about", string_4, "");
		}
		set
		{
			SetAttribute("about", string_4, value);
		}
	}

	public string Content
	{
		get
		{
			return method_0("content", string_4, "");
		}
		set
		{
			SetAttribute("content", string_4, value);
		}
	}

	public string Datatype
	{
		get
		{
			return method_0("datatype", string_4, "");
		}
		set
		{
			SetAttribute("datatype", string_4, value);
		}
	}

	public string Property
	{
		get
		{
			return method_0("property", string_4, "");
		}
		set
		{
			SetAttribute("property", string_4, value);
		}
	}

	public string[] TextValue => string_0;

	public Class456(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		for (int num = ChildNodes.Count - 1; num >= 0; num--)
		{
			if (ChildNodes.Item(num).NodeType != XmlNodeType.Text && ChildNodes.Item(num).NodeType != XmlNodeType.Whitespace && ChildNodes.Item(num).Name != "text:span" && ChildNodes.Item(num).Name != "text:tab")
			{
				RemoveChild(ChildNodes.Item(num));
			}
		}
		MatchCollection matchCollection = Regex.Matches(InnerXml, "<(text:span).*?<\\/\\1>|[^<>]+");
		string_0 = new string[matchCollection.Count];
		for (int i = 0; i < matchCollection.Count; i++)
		{
			string_0[i] = matchCollection[i].Value;
		}
		if (!(StyleNameString != ""))
		{
			return;
		}
		foreach (Class437 item in OwnerDocument.GetElementsByTagName("style", string_3))
		{
			if (item.Name == StyleNameString)
			{
				class437_0 = item;
				break;
			}
		}
	}
}
