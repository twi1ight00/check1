using System.Xml;
using ns42;

namespace ns43;

internal class Class817 : Class810
{
	internal static readonly string string_1 = "table";

	internal string Reference
	{
		get
		{
			return GetAttribute("ref", "");
		}
		set
		{
			SetAttribute("ref", "", value);
		}
	}

	internal uint Id
	{
		get
		{
			return (uint)method_11("id", "", 0);
		}
		set
		{
			method_13("id", "", (int)value);
		}
	}

	internal string DisplayName
	{
		get
		{
			return GetAttribute("displayName", "");
		}
		set
		{
			SetAttribute("displayName", "", value);
		}
	}

	internal string TableName
	{
		get
		{
			return GetAttribute("name", "");
		}
		set
		{
			SetAttribute("name", "", value);
		}
	}

	public Class817(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
