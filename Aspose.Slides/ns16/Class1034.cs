using System.Xml;
using ns56;

namespace ns16;

internal class Class1034
{
	public static Class2304 smethod_0(string innerXml)
	{
		Class1341 deserializationContext = new Class1341(null);
		new Class1030(deserializationContext, null);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.CreateElement("par");
		XmlElement xmlElement = xmlDocument.CreateElement("par");
		xmlElement.SetAttribute("xmlns:p", "http://schemas.openxmlformats.org/presentationml/2006/main");
		xmlElement.SetAttribute("xmlns:a", "http://schemas.openxmlformats.org/drawingml/2006/main");
		xmlElement.InnerXml = innerXml;
		XmlTextReader xmlTextReader = new XmlTextReader(xmlElement.OuterXml, XmlNodeType.Element, null);
		xmlTextReader.Read();
		return new Class2304(xmlTextReader);
	}
}
