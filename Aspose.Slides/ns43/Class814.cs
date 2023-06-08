using System.Xml;
using ns42;

namespace ns43;

internal class Class814 : Class810
{
	internal static readonly string string_1 = "numFmt";

	internal uint NumFormatID
	{
		get
		{
			return (uint)method_11("numFmtId", "", 0);
		}
		set
		{
			method_13("numFmtId", "", (int)value);
		}
	}

	internal string FormatCode
	{
		get
		{
			return GetAttribute("formatCode", "");
		}
		set
		{
			SetAttribute("formatCode", value);
		}
	}

	public Class814(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}
}
