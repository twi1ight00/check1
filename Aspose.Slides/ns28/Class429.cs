using System.Xml;

namespace ns28;

internal class Class429 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("enabled", "disabled");

	internal static readonly string string_0 = "settings";

	public Enum35 Animations
	{
		get
		{
			return (Enum35)method_9(class467_0, "animations", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "animations", NamespaceURI, (int)value);
		}
	}

	public bool Endless
	{
		get
		{
			return method_3("endless", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("endless", NamespaceURI, value);
		}
	}

	public bool ForceManual
	{
		get
		{
			return method_3("force-manual", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("force-manual", NamespaceURI, value);
		}
	}

	public bool FullScreen
	{
		get
		{
			return method_3("full-screen", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("full-screen", NamespaceURI, value);
		}
	}

	public bool MouseAsPen
	{
		get
		{
			return method_3("mouse-as-pen", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("mouse-as-pen", NamespaceURI, value);
		}
	}

	public bool MouseVisible
	{
		get
		{
			return method_3("mouse-visible", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("mouse-visible", NamespaceURI, value);
		}
	}

	public bool ShowEndOfPresentationSlide
	{
		get
		{
			return method_3("show-end-of-presentation-slide", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("show-end-of-presentation-slide", NamespaceURI, value);
		}
	}

	public bool ShowLogo
	{
		get
		{
			return method_3("show-logo", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("show-logo", NamespaceURI, value);
		}
	}

	public bool StartWithNavigator
	{
		get
		{
			return method_3("start-with-navigator", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("start-with-navigator", NamespaceURI, value);
		}
	}

	public bool StayOnTop
	{
		get
		{
			return method_3("stay-on-top", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("stay-on-top", NamespaceURI, value);
		}
	}

	public Enum35 TransitionOnClick
	{
		get
		{
			return (Enum35)method_9(class467_0, "transition-on-click", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_0, "transition-on-click", NamespaceURI, (int)value);
		}
	}

	public Class429(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
