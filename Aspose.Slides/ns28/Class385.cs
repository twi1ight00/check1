using System.Xml;

namespace ns28;

internal class Class385 : Class369
{
	internal static readonly string string_0 = "handle";

	public bool HandleMirrorHorizontal
	{
		get
		{
			return method_3("handle-mirror-horizontal", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("handle-mirror-horizontal", NamespaceURI, value);
		}
	}

	public bool HandleMirrorVertical
	{
		get
		{
			return method_3("handle-mirror-vertical", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("handle-mirror-vertical", NamespaceURI, value);
		}
	}

	public bool HandleSwitched
	{
		get
		{
			return method_3("handle-switched", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("handle-switched", NamespaceURI, value);
		}
	}

	public string HandlePosition
	{
		get
		{
			return method_0("handle-position", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-position", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeMaximum
	{
		get
		{
			return method_0("handle-radius-range-maximum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-radius-range-maximum", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeMinimum
	{
		get
		{
			return method_0("handle-radius-range-minimum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-radius-range-minimum", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeXMaximum
	{
		get
		{
			return method_0("handle-range-x-maximum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-range-x-maximum", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeXMinimum
	{
		get
		{
			return method_0("handle-range-x-minimum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-range-x-minimum", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeYMinimum
	{
		get
		{
			return method_0("handle-range-y-minimum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-range-y-minimum", NamespaceURI, value);
		}
	}

	public string HandleRadiusRangeYMaximum
	{
		get
		{
			return method_0("handle-range-y-maximum", NamespaceURI, "");
		}
		set
		{
			SetAttribute("handle-range-y-maximum", NamespaceURI, value);
		}
	}

	public Class385(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
