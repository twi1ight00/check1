using System.Xml;

namespace ns28;

internal class Class410 : Class369
{
	private Class437 class437_0;

	private Class413 class413_0;

	internal static readonly string string_0 = "master-page";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";

	internal bool bool_0;

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

	public string DisplayName
	{
		get
		{
			return method_0("display-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("display-name", NamespaceURI, value);
		}
	}

	public string PageLayoutNameStr => method_0("page-layout-name", NamespaceURI, "");

	public Class413 PageLayoutName
	{
		get
		{
			return class413_0;
		}
		set
		{
			class413_0 = value;
			SetAttribute("page-layout-name", NamespaceURI, value.Name);
		}
	}

	public string StyleNameStr => method_0("style-name", string_1, "");

	public Class437 StyleName
	{
		get
		{
			return class437_0;
		}
		set
		{
			class437_0 = value;
			SetAttribute("style-name", string_1, value.Name);
		}
	}

	public string NextStyleName
	{
		get
		{
			return method_0("next-style-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("next-style-name", NamespaceURI, value);
		}
	}

	public Class384[] Frames
	{
		get
		{
			Class369[] array = method_29("frame", string_1);
			Class384[] array2 = new Class384[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (Class384)array[i];
			}
			return array2;
		}
	}

	public Class410(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
