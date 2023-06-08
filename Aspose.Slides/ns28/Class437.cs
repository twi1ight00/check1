using System.Xml;

namespace ns28;

internal class Class437 : Class369
{
	public Class437 class437_0;

	internal static readonly Class467 class467_0 = new Class467("paragraph", "text", "section", "table", "table-column", "table-row", "table-cell", "table-page", "chart", "default", "drawing-page", "graphic", "presentation", "control", "ruby");

	internal static readonly string string_0 = "style";

	private Class437 class437_1;

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

	public Enum84 Family
	{
		get
		{
			return (Enum84)method_9(class467_0, "family", NamespaceURI, 9);
		}
		set
		{
			method_10(class467_0, "family", NamespaceURI, (int)value);
		}
	}

	public string ParentStyleNameStr => GetAttribute("parent-style-name", NamespaceURI);

	public Class437 ParentStyleName
	{
		get
		{
			return class437_1;
		}
		set
		{
			class437_1 = value;
			SetAttribute("parent-style-name", NamespaceURI, value.Name);
		}
	}

	public Class397 GraphicProperties
	{
		get
		{
			Class369 @class = method_31("graphic-properties", NamespaceURI);
			if (@class != null)
			{
				return (Class397)@class;
			}
			return null;
		}
	}

	public Class457 TextProperties
	{
		get
		{
			Class369 @class = method_31("text-properties", NamespaceURI);
			if (@class != null)
			{
				return (Class457)@class;
			}
			return null;
		}
	}

	public Class418 ParagraphProperties
	{
		get
		{
			Class369 @class = method_31("paragraph-properties", NamespaceURI);
			if (@class != null)
			{
				return (Class418)@class;
			}
			return null;
		}
	}

	public Class387 DrawingPageProperties
	{
		get
		{
			Class369 @class = method_31("drawing-page-properties", NamespaceURI);
			if (@class != null)
			{
				return (Class387)@class;
			}
			return null;
		}
	}

	public Class437(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal void method_36()
	{
		Class369 @class = method_31("drawing-page-properties", NamespaceURI);
		if (@class == null)
		{
			method_35("drawing-page-properties", NamespaceURI);
		}
	}

	internal void method_37()
	{
		Class369 @class = method_31("graphic-properties", NamespaceURI);
		if (@class == null)
		{
			method_35("graphic-properties", NamespaceURI);
		}
	}

	internal void method_38()
	{
		Class369 @class = method_31("paragraph-properties", NamespaceURI);
		if (@class == null)
		{
			method_35("paragraph-properties", NamespaceURI);
		}
	}

	internal void method_39()
	{
		Class369 @class = method_31("text-properties", NamespaceURI);
		if (@class == null)
		{
			method_35("text-properties", NamespaceURI);
		}
	}
}
