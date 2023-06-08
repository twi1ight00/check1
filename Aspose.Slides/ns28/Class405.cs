using System.Xml;

namespace ns28;

internal class Class405 : Class369
{
	internal static readonly string string_0 = "list-level-style-number";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";

	public Class457 TextProperties
	{
		get
		{
			Class369 @class = method_31("text-properties", string_1);
			if (@class != null)
			{
				return (Class457)@class;
			}
			return null;
		}
	}

	public Class403 ListLevelProperties
	{
		get
		{
			Class369 @class = method_31("list-level-properties", string_1);
			if (@class != null)
			{
				return (Class403)@class;
			}
			return null;
		}
	}

	public string NumFormat
	{
		get
		{
			return method_0("num-format", string_1, "");
		}
		set
		{
			SetAttribute("num-format", string_1, value);
		}
	}

	public bool NumLetterSync
	{
		get
		{
			return method_3("num-letter-sync", string_1, defaultValue: false);
		}
		set
		{
			method_3("num-letter-sync", string_1, value);
		}
	}

	public string NumPrefix
	{
		get
		{
			return method_0("num-prefix", string_1, "");
		}
		set
		{
			SetAttribute("num-prefix", string_1, value);
		}
	}

	public string NumSuffix
	{
		get
		{
			return method_0("num-suffix", string_1, "");
		}
		set
		{
			SetAttribute("num-suffix", string_1, value);
		}
	}

	public int DisplayLevels
	{
		get
		{
			return method_13("display-levels", NamespaceURI, 1);
		}
		set
		{
			method_13("display-levels", NamespaceURI, value);
		}
	}

	public int Level
	{
		get
		{
			return method_13("level", NamespaceURI, 1);
		}
		set
		{
			method_15("level", NamespaceURI, value);
		}
	}

	public int StartValue
	{
		get
		{
			return method_13("start-value", NamespaceURI, 1);
		}
		set
		{
			method_13("start-value", NamespaceURI, value);
		}
	}

	public string StyleName
	{
		get
		{
			return method_0("style-name", NamespaceURI, "");
		}
		set
		{
			SetAttribute("style-name", NamespaceURI, value);
		}
	}

	public Class405(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
