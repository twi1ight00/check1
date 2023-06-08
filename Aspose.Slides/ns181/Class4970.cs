using System.Xml;
using ns171;
using ns173;

namespace ns181;

internal class Class4970 : Class4942
{
	private XmlDocument xmlDocument_0;

	internal Class5089 class5089_0;

	private string string_0;

	public Class4970(XmlDocument d, string ns)
	{
		xmlDocument_0 = d;
		string_0 = ns;
	}

	public Class4970(XmlDocument d, string ns, Class5089 childObj)
	{
		xmlDocument_0 = d;
		string_0 = ns;
		class5089_0 = childObj;
	}

	public Class4970(string ns)
	{
		string_0 = ns;
	}

	public void method_37(XmlDocument document)
	{
		xmlDocument_0 = document;
	}

	public XmlDocument method_38()
	{
		return xmlDocument_0;
	}

	public string method_39()
	{
		return string_0;
	}
}
