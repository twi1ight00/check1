using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses header (status, QTime, etc) from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class HeaderResponseParser<T> : ISolrAbstractResponseParser<T>, ISolrHeaderResponseParser
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		ResponseHeader header = Parse(xml);
		if (header != null)
		{
			results.Header = header;
		}
	}

	/// <summary>
	/// Parses response header
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public ResponseHeader ParseHeader(XElement node)
	{
		ResponseHeader r = new ResponseHeader();
		r.Status = int.Parse(node.XPathSelectElement("int[@name='status']").Value, CultureInfo.InvariantCulture.NumberFormat);
		r.QTime = int.Parse(node.XPathSelectElement("int[@name='QTime']").Value, CultureInfo.InvariantCulture.NumberFormat);
		r.Params = new Dictionary<string, string>();
		IEnumerable<XElement> paramNodes = node.XPathSelectElements("lst[@name='params']/str");
		foreach (XElement i in paramNodes)
		{
			r.Params[i.Attribute("name").Value] = i.Value;
		}
		return r;
	}

	public ResponseHeader Parse(XDocument response)
	{
		XElement responseHeaderNode = response.XPathSelectElement("response/lst[@name='responseHeader']");
		if (responseHeaderNode != null)
		{
			return ParseHeader(responseHeaderNode);
		}
		return null;
	}
}
