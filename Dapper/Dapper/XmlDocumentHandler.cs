using System.Xml;

namespace Dapper;

internal sealed class XmlDocumentHandler : XmlTypeHandler<XmlDocument>
{
	protected override XmlDocument Parse(string xml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		return xmlDocument;
	}

	protected override string Format(XmlDocument xml)
	{
		return xml.OuterXml;
	}
}
