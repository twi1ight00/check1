using System.Xml;

namespace ns42;

internal class Class1085 : XmlElement
{
	internal static readonly string string_0 = "Types";

	public Class1085(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	public void method_0()
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("Override", NamespaceURI);
		XmlNode[] array = new XmlNode[elementsByTagName.Count];
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			array[i] = elementsByTagName[i];
		}
		XmlNode[] array2 = array;
		foreach (XmlNode oldChild in array2)
		{
			RemoveChild(oldChild);
		}
	}
}
