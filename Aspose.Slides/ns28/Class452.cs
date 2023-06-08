using System.Xml;

namespace ns28;

internal class Class452 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("columns", "row");

	internal static readonly string string_0 = "table-template";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	internal static readonly string string_2 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";

	public Enum40 FirstRowEndColumn
	{
		get
		{
			return (Enum40)method_9(class467_0, "first-row-end-column", string_2, 0);
		}
		set
		{
			method_10(class467_0, "first-row-end-column", string_2, (int)value);
		}
	}

	public Enum40 FirstRowStartColumn
	{
		get
		{
			return (Enum40)method_9(class467_0, "first-row-start-column", string_2, 0);
		}
		set
		{
			method_10(class467_0, "first-row-start-column", string_2, (int)value);
		}
	}

	public Enum40 LastRowEndColumn
	{
		get
		{
			return (Enum40)method_9(class467_0, "last-row-end-column", string_2, 0);
		}
		set
		{
			method_10(class467_0, "last-row-end-column", string_2, (int)value);
		}
	}

	public Enum40 LastRowStartColumn
	{
		get
		{
			return (Enum40)method_9(class467_0, "last-row-start-column", string_2, 0);
		}
		set
		{
			method_10(class467_0, "last-row-start-column", string_2, (int)value);
		}
	}

	public new string Name
	{
		get
		{
			return method_0("name", string_2, "");
		}
		set
		{
			SetAttribute("name", string_2, value);
		}
	}

	public Class452(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
