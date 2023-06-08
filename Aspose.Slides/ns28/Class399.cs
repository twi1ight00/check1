using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class399 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("single", "double", "triple");

	internal static readonly string string_0 = "hatch";

	public new string Name
	{
		get
		{
			return GetAttribute("name", NamespaceURI);
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
			return GetAttribute("display-name", NamespaceURI);
		}
		set
		{
			SetAttribute("display-name", NamespaceURI, value);
		}
	}

	public Enum49 Style
	{
		get
		{
			return (Enum49)method_9(class467_0, "style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "style", NamespaceURI, (int)value);
		}
	}

	public Color Color
	{
		get
		{
			return method_16("color", NamespaceURI, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("color", NamespaceURI, value);
		}
	}

	public double Distance
	{
		get
		{
			return method_7("distance", NamespaceURI, double.NaN);
		}
		set
		{
			method_8("distance", NamespaceURI, value);
		}
	}

	public int Rotation
	{
		get
		{
			return method_13("rotation", NamespaceURI, 0);
		}
		set
		{
			method_14("rotation", NamespaceURI, value, 0);
		}
	}

	public Class399(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
