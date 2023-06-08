using System.Xml;

namespace ns183;

internal class Class5619 : XmlQualifiedName
{
	public Class5619(string namespaceURI, string prefix, string localName)
		: base(prefix + ":" + localName, namespaceURI)
	{
	}

	public Class5619(string namespaceURI, string qName)
		: base(qName, namespaceURI)
	{
	}

	public string method_0()
	{
		return base.Namespace;
	}

	public string method_1()
	{
		if (base.Name.IndexOf(":") != -1)
		{
			string[] array = base.Name.Split(':');
			return array[0];
		}
		return string.Empty;
	}

	public string method_2()
	{
		if (base.Name.IndexOf(":") != -1)
		{
			string[] array = base.Name.Split(':');
			return array[1];
		}
		return base.Name;
	}

	public string method_3()
	{
		return base.Name;
	}
}
