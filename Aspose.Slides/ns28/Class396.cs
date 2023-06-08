using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class396 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("linear", "axial", "radial", "ellipsoid", "square", "rectangular");

	internal static readonly string string_0 = "gradient";

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

	public Enum48 Style
	{
		get
		{
			return (Enum48)method_9(class467_0, "style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "style", NamespaceURI, (int)value);
		}
	}

	public Color StartColor
	{
		get
		{
			return method_16("start-color", NamespaceURI, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("start-color", NamespaceURI, value);
		}
	}

	public Color EndColor
	{
		get
		{
			return method_16("end-color", NamespaceURI, ColorTranslator.FromWin32(255));
		}
		set
		{
			method_17("end-color", NamespaceURI, value);
		}
	}

	public int StartIntensity
	{
		get
		{
			return method_11("start-intensity", NamespaceURI, 100);
		}
		set
		{
			method_12("start-intensity", NamespaceURI, value);
		}
	}

	public int EndIntensity
	{
		get
		{
			return method_11("end-intensity", NamespaceURI, 100);
		}
		set
		{
			method_12("end-intensity", NamespaceURI, value);
		}
	}

	public int Angle
	{
		get
		{
			return method_13("angle", NamespaceURI, 0);
		}
		set
		{
			method_14("angle", NamespaceURI, value, 0);
		}
	}

	public int Border
	{
		get
		{
			return method_11("border", NamespaceURI, 0);
		}
		set
		{
			method_12("border", NamespaceURI, value);
		}
	}

	public int GradientCenterX
	{
		get
		{
			return method_11("cx", NamespaceURI, 0);
		}
		set
		{
			method_12("cx", NamespaceURI, value);
		}
	}

	public int GradientCenterY
	{
		get
		{
			return method_11("cy", NamespaceURI, 0);
		}
		set
		{
			method_12("cy", NamespaceURI, value);
		}
	}

	public Class396(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
