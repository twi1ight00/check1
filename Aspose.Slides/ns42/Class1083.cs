using System.Xml;

namespace ns42;

internal sealed class Class1083 : XmlDocument
{
	internal static Class1096 class1096_0;

	internal static readonly string string_0;

	public Class1085 Types => base.DocumentElement as Class1085;

	static Class1083()
	{
		string_0 = "http://schemas.openxmlformats.org/package/2006/content-types";
		class1096_0 = new Class1096(string_0);
		class1096_0.Add(Class1085.string_0, typeof(Class1085));
		class1096_0.Add(Class1084.string_0, typeof(Class1084));
		class1096_0.Add(Class1082.string_0, typeof(Class1082));
	}

	internal Class1083()
	{
	}

	public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
	{
		XmlElement xmlElement = class1096_0.CreateElement(prefix, localName, namespaceURI, this);
		if (xmlElement != null)
		{
			return xmlElement;
		}
		return base.CreateElement(prefix, localName, namespaceURI);
	}
}
