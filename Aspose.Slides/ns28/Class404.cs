using System.Xml;

namespace ns28;

internal class Class404 : Class369
{
	internal static readonly string string_0 = "list-level-style-bullet";

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

	public int Level
	{
		get
		{
			return method_13("level", NamespaceURI, 0);
		}
		set
		{
			method_15("level", NamespaceURI, value);
		}
	}

	public string StyleName
	{
		get
		{
			return GetAttribute("style-name", NamespaceURI);
		}
		set
		{
			SetAttribute("style-name", NamespaceURI, value);
		}
	}

	public char BulletCharacter
	{
		get
		{
			return method_20("bullet-char", NamespaceURI, '1');
		}
		set
		{
			method_21("bullet-char", NamespaceURI, value);
		}
	}

	public Class404(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
