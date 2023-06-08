using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class453 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("none", "dash", "dot-dash", "dot-dot-dash", "dotted", "long-dash", "solid", "wave");

	internal static readonly Class467 class467_1 = new Class467("auto", "normal", "bold", "thin", "medium", "thick");

	internal static readonly Class467 class467_2 = new Class467("none", "single", "double");

	internal static readonly Class467 class467_3 = new Class467("left", "center", "right", "char");

	internal static readonly string string_0 = "tab-stop";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	public double Position
	{
		get
		{
			return method_7("position", NamespaceURI, 0.0);
		}
		set
		{
			method_8("position", NamespaceURI, value);
		}
	}

	public Enum88 Type
	{
		get
		{
			return (Enum88)method_9(class467_3, "type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_3, "type", NamespaceURI, (int)value);
		}
	}

	public char Char
	{
		get
		{
			return method_20("char", NamespaceURI, ' ');
		}
		set
		{
			method_21("char", NamespaceURI, value);
		}
	}

	public Enum56 LeaderType
	{
		get
		{
			return (Enum56)method_9(class467_2, "leader-type", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "leader-type", NamespaceURI, (int)value);
		}
	}

	public Enum55 LeaderStyle
	{
		get
		{
			return (Enum55)method_9(class467_0, "leader-style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "leader-style", NamespaceURI, (int)value);
		}
	}

	public Enum57 LeaderWidth
	{
		get
		{
			return (Enum57)method_9(class467_1, "leader-width", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_1, "leader-width", NamespaceURI, (int)value);
		}
	}

	public Color LeaderColor
	{
		get
		{
			return method_16("leader-color", NamespaceURI, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("leader-color", NamespaceURI, value);
		}
	}

	public string LeaderText
	{
		get
		{
			return method_0("leader-text", NamespaceURI, "");
		}
		set
		{
			SetAttribute("leader-text", value);
		}
	}

	public Class453(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
