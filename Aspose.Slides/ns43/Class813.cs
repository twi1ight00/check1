using System.Xml;
using ns42;

namespace ns43;

internal class Class813 : Class810
{
	internal static readonly string string_1 = "definedName";

	internal string DefinedName
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

	public Class813(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
