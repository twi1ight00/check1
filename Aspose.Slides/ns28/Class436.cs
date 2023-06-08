using System.Xml;

namespace ns28;

internal class Class436 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("rect", "round");

	internal static readonly string string_0 = "stroke-dash";

	private string string_1;

	private string string_2;

	private string string_3;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

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

	public Enum81 Family
	{
		get
		{
			return (Enum81)method_9(class467_0, "style", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "style", NamespaceURI, (int)value);
		}
	}

	public int Dots1
	{
		get
		{
			return method_13("dots1", NamespaceURI, 1);
		}
		set
		{
			method_15("dots1", NamespaceURI, value);
		}
	}

	public int Dots2
	{
		get
		{
			return method_13("dots2", NamespaceURI, 0);
		}
		set
		{
			method_15("dots2", NamespaceURI, value);
		}
	}

	public double Dots1Length
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_8("dots1-length", NamespaceURI, value);
		}
	}

	public double Dots2Length
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_8("dots2-length", NamespaceURI, value);
		}
	}

	public double Distance
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			method_8("distance", NamespaceURI, value);
		}
	}

	public Class436(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		string_1 = GetAttribute("dots1-length", NamespaceURI);
		if (string_1.IndexOf("%") > -1)
		{
			double_0 = method_11("dots1-length", NamespaceURI, 100);
			bool_0 = true;
		}
		else
		{
			double_0 = method_7("dots1-length", NamespaceURI, 1.0);
		}
		if (Dots2 > 0)
		{
			string_2 = GetAttribute("dots2-length", NamespaceURI);
			if (string_2.IndexOf("%") > -1)
			{
				double_1 = method_11("dots2-length", NamespaceURI, 100);
				bool_1 = true;
			}
			else
			{
				double_1 = method_7("dots2-length", NamespaceURI, 1.0);
			}
		}
		string_3 = GetAttribute("distance", NamespaceURI);
		if (string_3.IndexOf("%") > -1)
		{
			double_2 = method_11("distance", NamespaceURI, 100);
			bool_2 = true;
		}
		else
		{
			double_2 = method_7("distance", NamespaceURI, 0.0);
		}
	}
}
