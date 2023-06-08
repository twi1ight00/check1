using System.Security;
using System.Xml;

namespace ns28;

internal class Class458 : Class369
{
	private string string_0;

	internal Class437 class437_0;

	internal static readonly string string_1 = "span";

	internal static readonly string string_2 = "http://www.w3.org/1999/xhtml";

	internal static readonly string string_3 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

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

	public string StyleNameString => method_0("style-name", NamespaceURI, "");

	public Class437 StyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			SetAttribute("style-name", NamespaceURI, value.Name);
		}
	}

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class458(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		if (StyleNameString != "")
		{
			foreach (Class437 item in OwnerDocument.GetElementsByTagName("style", string_3))
			{
				if (item.Name == StyleNameString)
				{
					class437_0 = item;
					break;
				}
			}
		}
		foreach (XmlNode childNode in ChildNodes)
		{
			if (childNode.NodeType != XmlNodeType.Text && childNode.NodeType != XmlNodeType.Whitespace)
			{
				if (childNode.Name == "text:s")
				{
					Class435 class2 = (Class435)childNode;
					if (class2 != null)
					{
						string_0 += new string(' ', class2.SpacesCount);
					}
				}
				else if (childNode.Name == "text:tab")
				{
					string_0 += "\t";
				}
			}
			else
			{
				string_0 += childNode.InnerText;
			}
		}
	}

	internal override void vmethod_1()
	{
		string text = SecurityElement.Escape(InnerText);
		int num = 0;
		int num2 = 0;
		while (text.Length > 0 && text[0] == ' ')
		{
			num++;
			text = text.Remove(0, 1);
		}
		while (text.Length > 0 && text[text.Length - 1] == ' ')
		{
			num2++;
			text = text.Remove(text.Length - 1, 1);
		}
		if (num > 0)
		{
			text = $"<text:s text:c=\"{num}\" />{text}";
		}
		if (num2 > 0)
		{
			text = string.Format("{1}<text:s text:c=\"{0}\" />", num2, text);
		}
		InnerXml = text.Replace("\t", "<text:tab/>");
	}
}
