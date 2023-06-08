using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses header (status, QTime, etc) and status from a response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class ReplicationStatusResponseParser<T> : ISolrAbstractResponseParser<T>, ISolrReplicationStatusResponseParser
{
	/// <summary>
	/// Header parser
	/// </summary>
	/// <param name="xml">XML</param>
	/// <param name="results">results</param>
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		ReplicationStatusResponse header = Parse(xml);
		if (header != null)
		{
			results.Header = header.responseHeader;
		}
	}

	/// <summary>
	/// Parses XML response to response class
	/// </summary>
	/// <param name="response">XML</param>
	/// <returns>ReplicationStatusResponse class</returns>
	public ReplicationStatusResponse Parse(XDocument response)
	{
		ResponseHeader responseHeader = new ResponseHeader();
		string status = string.Empty;
		string message = string.Empty;
		XElement responseHeaderNode = response.XPathSelectElement("response/lst[@name='responseHeader']");
		if (responseHeaderNode != null)
		{
			responseHeader = ParseHeader(responseHeaderNode);
			status = response.XPathSelectElement("response/str[@name='status']")?.Value;
			message = response.XPathSelectElement("response/str[@name='message']")?.Value;
			return new ReplicationStatusResponse(responseHeader, status, message);
		}
		return null;
	}

	/// <summary>
	/// Parses response header
	/// </summary>
	/// <param name="node">XML</param>
	/// <returns>ResponseHeader</returns>
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
}
