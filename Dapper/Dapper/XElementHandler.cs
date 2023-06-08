using System.Xml.Linq;

namespace Dapper;

internal sealed class XElementHandler : XmlTypeHandler<XElement>
{
	protected override XElement Parse(string xml)
	{
		return XElement.Parse(xml);
	}

	protected override string Format(XElement xml)
	{
		return xml.ToString();
	}
}
